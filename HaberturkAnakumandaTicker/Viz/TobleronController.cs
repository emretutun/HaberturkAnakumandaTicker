using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using HaberturkAnakumandaTicker.Models;

namespace HaberturkAnakumandaTicker.Viz
{
    /// <summary>
    /// Tobleron (sağ alttaki ekonomi kutusu) yönetimi. 2026-10-06'da sahnede doğrulanan akış:
    ///  1) Değerler Viz shared memory'ye yazılır: "/economy/1604/LCL_CF_LAST", ".../change", ".../decimalVal".
    ///  2) LCL_TOBLERON ticker'ında her zaman TEK öğe olur (text = "/economy/1604").
    ///  3) TOBANIM$1 ↔ $2 her geçişte scroller'ı yeniler; servis "* run ... LCL_TOBLERON" olayı gönderir.
    ///     Olaydan ~2 sn sonra sıradaki öğe gönderilir, bir sonraki geçişte boştaki kutuya yüklenir.
    ///     (Olay gelir gelmez gönderilirse o anki geçiş yeni öğeyi alıyor ve bir veri atlanıyor.)
    /// UI thread'inde kullanılmalı (COM + WinForms Timer).
    /// </summary>
    public sealed class TobleronController : IDisposable
    {
        private const int SendDelayMs = 2000;       // run olayından sonra bekleme
        private const double IgnoreAfterSendSec = 1.5; // kendi gönderimimizin tetiklediği run olaylarını yok say

        private readonly Broadcaster _b;
        private readonly System.Windows.Forms.Timer _delay = new System.Windows.Forms.Timer();
        private List<EconomyItem> _items = new List<EconomyItem>();
        private int _next;
        private DateTime _lastSend = DateTime.MinValue;

        public TobleronController(Broadcaster broadcaster)
        {
            _b = broadcaster;
            _delay.Interval = SendDelayMs;
            _delay.Tick += (s, e) => { _delay.Stop(); SendNextSafe(); };
            _b.Ticker.EventReceived += OnTickerEvent;
        }

        /// <summary>Viz ve VizTicker bağlı mı (otomatik güncelleme sadece bağlıyken yazar).</summary>
        public bool IsReady { get { return _b.IsReady; } }

        /// <summary>Döngü çalışıyor mu (TOBLERON VER'den sonra true).</summary>
        public bool Running { get; private set; }

        /// <summary>Şu an gönderilen (sıradaki kutuya yüklenecek) veri.</summary>
        public event Action<EconomyItem> ItemSent;
        public event Action<string> Error;

        // ------------------------------------------------------------------ değerler

        /// <summary>Aktif verilerin değerlerini yerel Viz shared memory'ye yazar ve döngü listesini günceller.</summary>
        public void WriteValues(IEnumerable<EconomyItem> items)
        {
            _b.Connect();
            var list = items.Where(i => i.IsActive).OrderBy(i => i.SortOrder).ThenBy(i => i.Id).ToList();
            foreach (var i in list)
            {
                if (i.Value.HasValue)
                {
                    int dec = i.DecimalPlaces ?? 2;
                    _b.Viz.SetSharedMemory(i.ShmBaseKey + "/" + SceneConfig.EconomyValueField,
                        i.Value.Value.ToString("F" + dec, CultureInfo.InvariantCulture));
                }
                _b.Viz.SetSharedMemory(i.ShmBaseKey + "/" + SceneConfig.EconomyChangeField, Math.Sign(i.Change).ToString(CultureInfo.InvariantCulture));
                _b.Viz.SetSharedMemory(i.ShmBaseKey + "/" + SceneConfig.EconomyDecimalField,
                    i.DecimalPlaces.HasValue ? i.DecimalPlaces.Value.ToString(CultureInfo.InvariantCulture) : "");
            }
            _items = list;
            if (_next >= _items.Count) _next = 0;
        }

        // ------------------------------------------------------------------ ver / al

        /// <summary>Değerleri yazar, döngüyü başlatır ve tobleronu ekrana alır.</summary>
        public void TakeIn(IEnumerable<EconomyItem> items)
        {
            WriteValues(items);
            if (_items.Count == 0)
                throw new VizException("Tobleron'da gösterilecek aktif ekonomi verisi yok.");
            Running = true;
            _next = 0;
            SendNext();
            EnsureFlipChain();
            _b.Viz.SetText(SceneConfig.TobleronStatusPath, "ON");
            _b.GoLayer(SceneConfig.LayerTobleron, SceneConfig.TobleronLayerStopsByTime, SceneConfig.StopTobleron);
        }

        /// <summary>Tobleronu ekrandan alır ve döngüyü durdurur.</summary>
        public void TakeOut()
        {
            _b.Connect();
            Running = false;
            _delay.Stop();
            _b.GoLayer(SceneConfig.LayerTobleron, SceneConfig.TobleronLayerStopsByTime, SceneConfig.StopOut);
            _b.Viz.SetText(SceneConfig.TobleronStatusPath, "OFF");
        }

        /// <summary>TOBANIM zinciri durmuşsa başlatır (iki alt director'ın zamanı ilerlemiyorsa).</summary>
        private void EnsureFlipChain()
        {
            string a1 = _b.Viz.GetDirectorTime(SceneConfig.DirectorTobAnim1);
            string a2 = _b.Viz.GetDirectorTime(SceneConfig.DirectorTobAnim2);
            System.Threading.Thread.Sleep(300);
            if (a1 == _b.Viz.GetDirectorTime(SceneConfig.DirectorTobAnim1) &&
                a2 == _b.Viz.GetDirectorTime(SceneConfig.DirectorTobAnim2))
            {
                _b.Viz.Send("MAIN_SCENE*STAGE*DIRECTOR*" + SceneConfig.DirectorTobAnim1 + " START");
            }
        }

        // ------------------------------------------------------------------ döngü

        private void OnTickerEvent(TickerEvent e)
        {
            if (!Running || e.Kind != "run" || e.Ticker != SceneConfig.Tobleron.ElementSource || e.IsScrollerEmpty) return;
            if ((DateTime.Now - _lastSend).TotalSeconds < IgnoreAfterSendSec) return;
            if (!_delay.Enabled) _delay.Start();
        }

        private void SendNextSafe()
        {
            if (!Running) return;
            try { SendNext(); }
            catch (Exception ex)
            {
                var h = Error;
                if (h != null) h(ex.Message);
            }
        }

        private void SendNext()
        {
            if (_items.Count == 0) return;
            var item = _items[_next % _items.Count];
            _next = (_next + 1) % _items.Count;

            var def = SceneConfig.Tobleron;
            var group = new TickerGroup("tobleron_" + item.Id)
                .Add(new TickerElement(1, def.Template)
                    .Value(def.Label1, item.DisplayName)
                    .Value(def.Label2, item.ShmBaseKey));
            _b.Ticker.ReplaceAll(def.ElementSource, new List<TickerGroup> { group });
            _lastSend = DateTime.Now;

            var h = ItemSent;
            if (h != null) h(item);
        }

        public void Dispose()
        {
            _delay.Dispose();
            _b.Ticker.EventReceived -= OnTickerEvent;
        }
    }
}
