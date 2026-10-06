using System;
using System.Collections.Generic;
using HaberturkAnakumandaTicker.Models;

namespace HaberturkAnakumandaTicker.Viz
{
    /// <summary>
    /// Operatör ekranlarının kullandığı tek giriş noktası: bağlan, mesaj gönder, yayına al, yayından al.
    /// Viz komutları VizEngineClient üzerinden (sadece 127.0.0.1:6100), veri VizTickerManager üzerinden gider.
    /// </summary>
    public sealed class Broadcaster
    {
        public VizEngineClient Viz { get; private set; }
        public VizTickerManager Ticker { get; private set; }

        public Broadcaster(VizEngineClient viz, VizTickerManager ticker)
        {
            Viz = viz;
            Ticker = ticker;
        }

        /// <summary>Bilgi mesajları (UI'da gösterilir).</summary>
        public event Action<string> Log;

        public bool IsReady
        {
            get { return Viz.IsConnected && Ticker.IsConnected; }
        }

        /// <summary>Viz Engine ve VizTicker'a bağlanır, Viz yazma komutlarına izin verir (yalnızca yerel).</summary>
        public void Connect()
        {
            if (!Viz.IsConnected) Viz.Connect();
            Viz.ReadOnly = false;
            EnsureSceneLoaded();
            if (!Ticker.IsConnected) Ticker.Connect();
        }

        /// <summary>
        /// Ana katmanda (main layer) ticker sahnesi yoksa yükler. Yüklüyse dokunmaz
        /// (yeniden yükleme yayındaki grafikleri sıfırlar).
        /// </summary>
        public void EnsureSceneLoaded()
        {
            string current = "";
            try { current = Viz.GetMainSceneName().Trim(); }
            catch (VizException) { }   // ana katman boş
            if (current == SceneConfig.SceneName) return;

            Viz.Send("RENDERER SET_OBJECT SCENE*" + SceneConfig.ScenePath);
            for (int i = 0; i < 50; i++)
            {
                try { if (Viz.GetMainSceneName().Trim() == SceneConfig.SceneName) break; }
                catch (VizException) { }
                System.Threading.Thread.Sleep(100);
            }
            var h = Log;
            if (h != null) h("Sahne ana katmana yüklendi: " + SceneConfig.ScenePath);
        }

        // ------------------------------------------------------------------ veri

        /// <summary>Verilen mesajları tipin ticker'ına gönderir (önceki içerik silinir).</summary>
        public void Send(MessageType type, IEnumerable<TickerMessage> messages)
        {
            Connect();
            var def = SceneConfig.For(type);
            Ticker.ReplaceAll(def.ElementSource, TickerPlaylistBuilder.BuildSimple(type, messages));
        }

        // ------------------------------------------------------------------ yayına al / yayından al

        /// <summary>Tipin grafiğini ekrana alır.</summary>
        public void TakeIn(MessageType type)
        {
            Connect();
            switch (type)
            {
                case MessageType.MAIN:
                    EnsureBandBackground();
                    GoLayer(SceneConfig.LayerMain, SceneConfig.MainLayerStopsByTime, SceneConfig.StopMainTicker); break;
                case MessageType.SD_TEK:
                    EnsureMainOnAir();
                    GoLayer(SceneConfig.LayerMain, SceneConfig.MainLayerStopsByTime, SceneConfig.StopSdTek); break;
                case MessageType.BIRAZDAN:
                    EnsureMainOnAir();
                    GoLayer(SceneConfig.LayerMain, SceneConfig.MainLayerStopsByTime, SceneConfig.StopBirazdan); break;
                case MessageType.SD_KJ:
                    GoLayer(SceneConfig.LayerSonDakika, SceneConfig.SonDakikaLayerStopsByTime, SceneConfig.StopSdKj); break;
                case MessageType.SD_CIFT:
                    // Giriş animasyonu tobleronStatus'a göre seçiliyor; tobleron henüz yönetilmiyor → OFF
                    Viz.SetText(SceneConfig.TobleronStatusPath, "OFF");
                    GoLayer(SceneConfig.LayerSonDakika, SceneConfig.SonDakikaLayerStopsByTime, SceneConfig.StopSdCift); break;
            }
        }

        /// <summary>Tipin grafiğini ekrandan alır. Ana banttaki grafikler (SD Tek, Birazdan) ana haber bandına döner.</summary>
        public void TakeOut(MessageType type)
        {
            Connect();
            switch (type)
            {
                case MessageType.MAIN:
                    GoLayer(SceneConfig.LayerMain, SceneConfig.MainLayerStopsByTime, SceneConfig.StopOut); break;
                case MessageType.SD_TEK:
                case MessageType.BIRAZDAN:
                    // SD Tek / Birazdan ana bandın üstünde durur; çıkınca ana bant ekranda kalır
                    GoLayer(SceneConfig.LayerMain, SceneConfig.MainLayerStopsByTime, SceneConfig.StopMainTicker); break;
                case MessageType.SD_KJ:
                case MessageType.SD_CIFT:
                    GoLayer(SceneConfig.LayerSonDakika, SceneConfig.SonDakikaLayerStopsByTime, SceneConfig.StopOut); break;
            }
        }

        /// <summary>Bu oturumda ana banda (LCL_TICKER) veri gönderildi mi.</summary>
        public bool MainHasData { get; private set; }

        /// <summary>Ana bant listesini gönderir (Yayın Listesi ekranı bunu kullanır).</summary>
        public void SendMain(IList<TickerGroup> groups)
        {
            Connect();
            Ticker.ReplaceAll(SceneConfig.Main.ElementSource, groups);
            MainHasData = true;
        }

        /// <summary>
        /// SD Tek / Birazdan ana bandın üstünde durur: bant boşsa yayındaki haberlerle doldurur,
        /// ekranda değilse önce ana bandı ekrana alır (yoksa bandın arkası boş görünür).
        /// </summary>
        private void EnsureMainOnAir()
        {
            if (!MainHasData)
            {
                var cats = new Data.CategoryRepository().GetAll(true);
                var msgs = new Data.TickerMessageRepository().GetPlayable(MessageType.MAIN);
                if (msgs.Count == 0)
                    throw new VizException("Ana bantta yayınlanabilir haber yok. Yönetim > Ana Bant Haberleri'nden haber ekleyin.");
                SendMain(TickerPlaylistBuilder.BuildMain(cats, msgs));
                var h = Log;
                if (h != null) h("Ana bant boştu, yayındaki " + msgs.Count + " haberle dolduruldu.");
            }
            EnsureBandBackground();
            string cur = WaitForStop(SceneConfig.LayerMain, SceneConfig.MainLayerStopsByTime);
            if (cur == SceneConfig.StopOut)
                GoLayer(SceneConfig.LayerMain, SceneConfig.MainLayerStopsByTime, SceneConfig.StopMainTicker);
        }

        /// <summary>
        /// Bant zemini (kırmızı/beyaz bant, saat) TICKER_IN director'ı ile gelir. Layer director'ı bunu
        /// oynatmıyor; sonunda değilse burada başlatılır.
        /// </summary>
        private void EnsureBandBackground()
        {
            double t;
            string raw = Viz.GetDirectorTime(SceneConfig.DirectorTickerIn).Trim();
            if (double.TryParse(raw, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out t)
                && t >= SceneConfig.TickerInEnd - 0.01)
                return;
            Viz.Send("MAIN_SCENE*STAGE*DIRECTOR*" + SceneConfig.DirectorTickerIn + " START");
            var h = Log;
            if (h != null) h(SceneConfig.DirectorTickerIn + " başlatıldı (bant zemini).");
        }

        /// <summary>Geçiş animasyonu sürüyorsa en fazla ~3 sn bitmesini bekler.</summary>
        private string WaitForStop(string layer, IDictionary<int, string> stopsByTime)
        {
            for (int i = 0; i < 30; i++)
            {
                string cur = Viz.GetCurrentStop(layer, stopsByTime);
                if (cur != null) return cur;
                System.Threading.Thread.Sleep(100);
            }
            return null;
        }

        // ------------------------------------------------------------------ logo

        /// <summary>Logoyu ekrana verir / reklamdan döndürür (REKLAM_DONUS ileri).</summary>
        public void LogoIn() { PlayGuarded(SceneConfig.DirectorLogo, false); }

        /// <summary>Logoyu ekrandan alır (REKLAM_DONUS geri).</summary>
        public void LogoOut() { PlayGuarded(SceneConfig.DirectorLogo, true); }

        /// <summary>Logoyu reklam görünümüne alır (REKLAM_VER ileri).</summary>
        public void LogoReklam() { PlayGuarded(SceneConfig.DirectorReklamLogo, false); }

        /// <summary>Director'ı oynatır; önce uzak komut gönderen scriptlerin IP alanlarını doğrular.</summary>
        private void PlayGuarded(string director, bool reverse)
        {
            // Sadece engine gerekir (TickerService kapalı olsa da çalışsın)
            if (!Viz.IsConnected) Viz.Connect();
            Viz.ReadOnly = false;
            EnsureRemoteIpsLocal();
            Viz.Send("MAIN_SCENE*STAGE*DIRECTOR*" + director + (reverse ? " CONTINUE REVERSE" : " START"));
            var h = Log;
            if (h != null) h(director + (reverse ? " geri" : " ileri"));
        }

        /// <summary>Sahnedeki reji/reklam IP alanları 127.0.0.1 ya da boş değilse VizException.</summary>
        private void EnsureRemoteIpsLocal()
        {
            foreach (var path in SceneConfig.RemoteIpFieldPaths)
            {
                string ip;
                try { ip = Viz.GetText(path).Trim(); }
                catch (VizException) { continue; }   // alan bu sahnede yoksa script de gönderemez
                if (ip != "" && ip != VizEngineClient.Host)
                    throw new VizException("Güvenlik: sahnedeki " + path + " alanı " + ip +
                        " (127.0.0.1 değil). Logo komutu gönderilmedi; bu alanı sahnede 127.0.0.1 yapın.");
            }
        }

        /// <summary>Ana bant ve son dakika katmanlarının şu anki durakları (salt okuma). Bağlı değilse null.</summary>
        public string[] ReadLayerStates()
        {
            if (!Viz.IsConnected) return null;
            return new[]
            {
                Viz.GetCurrentStop(SceneConfig.LayerMain, SceneConfig.MainLayerStopsByTime),
                Viz.GetCurrentStop(SceneConfig.LayerSonDakika, SceneConfig.SonDakikaLayerStopsByTime)
            };
        }

        /// <summary>
        /// Layer director'ını bulunduğu duraktan hedef durağa götürür. Bulunduğu durak director
        /// zamanından okunur; böylece butonlar hangi sırayla basılırsa basılsın doğru çalışır.
        /// </summary>
        public void GoLayer(string layer, IDictionary<int, string> stopsByTime, string targetStop)
        {
            string current = WaitForStop(layer, stopsByTime);
            if (current == null)
                throw new VizException("Grafik geçiş animasyonundan çıkmadı. Tekrar deneyin.");
            if (current == targetStop) return;
            Viz.GotoTrio(layer, current, targetStop);
            // Hedef durağa varana kadar bekle (ardışık geçişler birbirini kesmesin)
            for (int i = 0; i < 40 && Viz.GetCurrentStop(layer, stopsByTime) != targetStop; i++)
                System.Threading.Thread.Sleep(100);
            var h = Log;
            if (h != null) h(layer + ": " + current + " → " + targetStop);
        }
    }
}
