using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using HaberturkAnakumandaTicker.Data;
using HaberturkAnakumandaTicker.Models;
using HaberturkAnakumandaTicker.Viz;

namespace HaberturkAnakumandaTicker.UI
{
    /// <summary>
    /// Yayın kontrol sekmesi: VizTicker bağlantısı, ana ticker gönder / ver / al.
    /// Viz'e giden yazma komutları sadece "izin ver" kutusu işaretliyken gönderilir.
    /// </summary>
    public partial class ControlPanelControl : UserControl
    {
        private const int MaxLogLines = 500;

        private readonly TickerMessageRepository _messages = new TickerMessageRepository();
        private readonly CategoryRepository _categories = new CategoryRepository();

        private VizEngineClient _viz;
        private VizTickerManager _ticker;

        public ControlPanelControl()
        {
            InitializeComponent();
            UpdateState();
        }

        /// <summary>MainForm'daki ortak bağlantıları verir.</summary>
        public void Initialize(VizEngineClient viz, VizTickerManager ticker)
        {
            _viz = viz;
            _ticker = ticker;
            _ticker.Log += AddLog;
            _ticker.EventReceived += OnTickerEvent;
            chkAllowWrite.Checked = !_viz.ReadOnly;
            UpdateState();
        }

        // ------------------------------------------------------------------ bağlantı

        private void btnTickerConnect_Click(object sender, EventArgs e)
        {
            try
            {
                _ticker.Connect();
            }
            catch (Exception ex)
            {
                AddLog("HATA: " + ex.Message);
                Ui.Error(ex);
            }
            UpdateState();
        }

        private void chkAllowWrite_CheckedChanged(object sender, EventArgs e)
        {
            if (_viz == null) return;
            _viz.ReadOnly = !chkAllowWrite.Checked;
            AddLog(_viz.ReadOnly ? "Viz: salt okunur mod." : "Viz: yazma komutlarına izin verildi (127.0.0.1:6100).");
        }

        private void chkLegacyTr_CheckedChanged(object sender, EventArgs e)
        {
            TickerXml.LegacyTurkishEncoding = chkLegacyTr.Checked;
            AddLog("Eski Türkçe dönüşümü: " + (chkLegacyTr.Checked ? "açık" : "kapalı"));
        }

        // ------------------------------------------------------------------ ana ticker

        private void btnSendMain_Click(object sender, EventArgs e)
        {
            Run("Ana ticker gönder", () =>
            {
                var groups = TickerPlaylistBuilder.BuildMain(
                    _categories.GetAll(true),
                    _messages.GetPlayable(MessageType.MAIN));
                if (groups.Count == 0)
                {
                    Ui.Info("Yayına gidecek aktif ana ticker mesajı yok.");
                    return;
                }
                _ticker.ReplaceAll(SceneConfig.Main.ElementSource, groups);
            });
        }

        private void btnMainIn_Click(object sender, EventArgs e)
        {
            RunViz("Ticker VER", () => GoMainLayer(SceneConfig.StopMainTicker));
        }

        private void btnMainOut_Click(object sender, EventArgs e)
        {
            RunViz("Ticker AL", () => GoMainLayer(SceneConfig.StopOut));
        }

        // ------------------------------------------------------------------ son dakika tek

        private void btnSdTekSend_Click(object sender, EventArgs e)
        {
            Run("SD Tek gönder", () =>
            {
                var groups = TickerPlaylistBuilder.BuildSimple(MessageType.SD_TEK, _messages.GetPlayable(MessageType.SD_TEK));
                if (groups.Count == 0)
                {
                    Ui.Info("Yayına gidecek aktif 'Son Dakika Tek' mesajı yok.");
                    return;
                }
                _ticker.ReplaceAll(SceneConfig.SdTek.ElementSource, groups);
            });
        }

        /// <summary>Son dakika bandı ana bandın yerine gelir (MainTickerLayer → SDTEK).</summary>
        private void btnSdTekIn_Click(object sender, EventArgs e)
        {
            RunViz("SD Tek VER", () => GoMainLayer(SceneConfig.StopSdTek));
        }

        /// <summary>Ana haber bandına geri döner (MainTickerLayer → TICKER).</summary>
        private void btnSdTekOut_Click(object sender, EventArgs e)
        {
            RunViz("SD Tek AL", () => GoMainLayer(SceneConfig.StopMainTicker));
        }

        private void btnSdTekClear_Click(object sender, EventArgs e)
        {
            if (!Ui.Confirm("Son Dakika Tek mesajları silinsin mi?")) return;
            Run("SD Tek temizle", () => _ticker.Clear(SceneConfig.SdTek.ElementSource));
        }

        // ------------------------------------------------------------------ birazdan

        private void btnBirazdanSend_Click(object sender, EventArgs e)
        {
            Run("Birazdan gönder", () =>
            {
                var groups = TickerPlaylistBuilder.BuildSimple(MessageType.BIRAZDAN, _messages.GetPlayable(MessageType.BIRAZDAN));
                if (groups.Count == 0)
                {
                    Ui.Info("Yayına gidecek aktif 'Birazdan' mesajı yok.");
                    return;
                }
                _ticker.ReplaceAll(SceneConfig.Birazdan.ElementSource, groups);
            });
        }

        /// <summary>Birazdan bandı ana bandın yerine gelir (MainTickerLayer → BIRAZDAN).</summary>
        private void btnBirazdanIn_Click(object sender, EventArgs e)
        {
            RunViz("Birazdan VER", () => GoMainLayer(SceneConfig.StopBirazdan));
        }

        /// <summary>Ana haber bandına geri döner (MainTickerLayer → TICKER).</summary>
        private void btnBirazdanOut_Click(object sender, EventArgs e)
        {
            RunViz("Birazdan AL", () => GoMainLayer(SceneConfig.StopMainTicker));
        }

        private void btnBirazdanClear_Click(object sender, EventArgs e)
        {
            if (!Ui.Confirm("Birazdan mesajları silinsin mi?")) return;
            Run("Birazdan temizle", () => _ticker.Clear(SceneConfig.Birazdan.ElementSource));
        }

        // ------------------------------------------------------------------ son dakika çift

        private void btnSdCiftSend_Click(object sender, EventArgs e)
        {
            Run("SD Çift gönder", () =>
            {
                var groups = TickerPlaylistBuilder.BuildSimple(MessageType.SD_CIFT, _messages.GetPlayable(MessageType.SD_CIFT));
                if (groups.Count == 0)
                {
                    Ui.Info("Yayına gidecek aktif 'Son Dakika Çift' mesajı yok.");
                    return;
                }
                _ticker.ReplaceAll(SceneConfig.SdCift.ElementSource, groups);
            });
        }

        /// <summary>
        /// Büyük son dakika ekrana gelir (SonDakikaLayerContainer → TickerBuyukSonDakika).
        /// Sahne giriş animasyonunu tobleronStatus'a göre seçiyor; tobleron henüz uygulamada
        /// yönetilmediği için OFF yazılıyor.
        /// </summary>
        private void btnSdCiftIn_Click(object sender, EventArgs e)
        {
            RunViz("SD Çift VER", () =>
            {
                _viz.SetText(SceneConfig.TobleronStatusPath, "OFF");
                GoLayer(SceneConfig.LayerSonDakika, SceneConfig.SonDakikaLayerStopsByTime, SceneConfig.StopSdCift);
            });
        }

        private void btnSdCiftOut_Click(object sender, EventArgs e)
        {
            RunViz("SD Çift AL", () =>
                GoLayer(SceneConfig.LayerSonDakika, SceneConfig.SonDakikaLayerStopsByTime, SceneConfig.StopOut));
        }

        private void btnSdCiftClear_Click(object sender, EventArgs e)
        {
            if (!Ui.Confirm("Son Dakika Çift mesajları silinsin mi?")) return;
            Run("SD Çift temizle", () => _ticker.Clear(SceneConfig.SdCift.ElementSource));
        }

        // ------------------------------------------------------------------ son dakika KJ

        private void btnSdKjSend_Click(object sender, EventArgs e)
        {
            Run("SD KJ gönder", () =>
            {
                var groups = TickerPlaylistBuilder.BuildSimple(MessageType.SD_KJ, _messages.GetPlayable(MessageType.SD_KJ));
                if (groups.Count == 0)
                {
                    Ui.Info("Yayına gidecek aktif 'Son Dakika KJ' mesajı yok.");
                    return;
                }
                _ticker.ReplaceAll(SceneConfig.SdKj.ElementSource, groups);
            });
        }

        /// <summary>
        /// Kırmızı iki satırlı son dakika ekrana gelir (SonDakikaLayerContainer → KJSonDakika).
        /// Ekrandayken yeni mesaj gönderilirse sahnedeki INTRO_SD_KJ_CHECK döngüsü onu kendisi
        /// fark edip geçiş animasyonuyla değiştirir.
        /// </summary>
        private void btnSdKjIn_Click(object sender, EventArgs e)
        {
            RunViz("SD KJ VER", () =>
                GoLayer(SceneConfig.LayerSonDakika, SceneConfig.SonDakikaLayerStopsByTime, SceneConfig.StopSdKj));
        }

        private void btnSdKjOut_Click(object sender, EventArgs e)
        {
            RunViz("SD KJ AL", () =>
                GoLayer(SceneConfig.LayerSonDakika, SceneConfig.SonDakikaLayerStopsByTime, SceneConfig.StopOut));
        }

        private void btnSdKjClear_Click(object sender, EventArgs e)
        {
            if (!Ui.Confirm("Son Dakika KJ mesajları silinsin mi?")) return;
            Run("SD KJ temizle", () => _ticker.Clear(SceneConfig.SdKj.ElementSource));
        }

        private void GoMainLayer(string targetStop)
        {
            GoLayer(SceneConfig.LayerMain, SceneConfig.MainLayerStopsByTime, targetStop);
        }

        /// <summary>
        /// Layer director'ını bulunduğu duraktan hedef durağa götürür. Bulunduğu durak director
        /// zamanından okunur; böylece VER/AL butonları hangi sırayla basılırsa basılsın doğru çalışır.
        /// </summary>
        private void GoLayer(string layer, IDictionary<int, string> stopsByTime, string targetStop)
        {
            string current = _viz.GetCurrentStop(layer, stopsByTime);
            if (current == null)
                throw new VizException(layer + " şu an animasyon halinde ya da bilinmeyen bir durakta. Bir saniye sonra tekrar deneyin.");
            if (current == targetStop)
            {
                AddLog(layer + " zaten '" + targetStop + "' durumunda.");
                return;
            }
            _viz.GotoTrio(layer, current, targetStop);
            AddLog(layer + ": " + current + " → " + targetStop);
        }

        private void btnMainClear_Click(object sender, EventArgs e)
        {
            if (!Ui.Confirm("Ana ticker'daki tüm mesajlar silinsin mi?")) return;
            Run("Ana ticker temizle", () => _ticker.Clear(SceneConfig.Main.ElementSource));
        }

        // ------------------------------------------------------------------ yardımcılar

        private void Run(string name, Action action)
        {
            try
            {
                if (!_ticker.IsConnected) _ticker.Connect();
                action();
                AddLog(name + ": tamam");
            }
            catch (Exception ex)
            {
                AddLog(name + " HATA: " + ex.Message);
                Ui.Error(ex);
            }
            UpdateState();
        }

        private void RunViz(string name, Action action)
        {
            try
            {
                if (!_viz.IsConnected) _viz.Connect();
                action();
                AddLog(name + ": tamam");
            }
            catch (Exception ex)
            {
                AddLog(name + " HATA: " + ex.Message);
                Ui.Error(ex);
            }
        }

        private void OnTickerEvent(TickerEvent e)
        {
            lblLastEvent.Text = "Son ticker olayı: " + DateTime.Now.ToString("HH:mm:ss") + "  " + e.Raw;
            // "run <grup>" her geçişte gelir; log'u doldurmasın diye sadece diğerlerini yaz
            if (e.Kind != "run" || e.IsScrollerEmpty)
                AddLog("Ticker: " + e.Raw);
        }

        private void AddLog(string message)
        {
            lstLog.Items.Insert(0, DateTime.Now.ToString("HH:mm:ss") + "  " + message);
            while (lstLog.Items.Count > MaxLogLines)
                lstLog.Items.RemoveAt(lstLog.Items.Count - 1);
        }

        private void UpdateState()
        {
            bool connected = _ticker != null && _ticker.IsConnected;
            lblTickerStatus.Text = connected ? "VizTicker: bağlı" : "VizTicker: bağlı değil";
            lblTickerStatus.ForeColor = connected ? Color.DarkGreen : SystemColors.ControlText;
            btnTickerConnect.Enabled = !connected;
        }
    }
}
