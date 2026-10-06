using System;
using System.Drawing;
using System.Windows.Forms;
using HaberturkAnakumandaTicker.Data;
using HaberturkAnakumandaTicker.UI;
using HaberturkAnakumandaTicker.Viz;

namespace HaberturkAnakumandaTicker
{
    /// <summary>
    /// Operatör ekranı: Ana Bant / Son Dakika / Birazdan + Yönetim.
    /// Üstteki "Yayına Bağlan" Viz Engine (sadece 127.0.0.1:6100) ve VizTicker'a bağlanır.
    /// </summary>
    public partial class MainForm : Form
    {
        private static readonly Color Ok = Color.FromArgb(46, 204, 113);
        private static readonly Color Off = Color.Silver;
        private static readonly Color Warn = Color.FromArgb(241, 196, 15);
        private static readonly Color OnAir = Color.FromArgb(231, 76, 60);

        private readonly VizEngineClient _viz = new VizEngineClient();
        private VizTickerManager _ticker;
        private Broadcaster _broadcaster;
        private TobleronController _tobleron;

        public MainForm()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                _ticker = new VizTickerManager();   // UI thread'inde oluşturulmalı (olaylar buraya aktarılır)
                _broadcaster = new Broadcaster(_viz, _ticker);
                _viz.CommandSent += OnVizCommand;

                playlistControl.Initialize(_broadcaster);
                quickSonDakika.Initialize(_broadcaster);
                quickBirazdan.Initialize(_broadcaster);
                _tobleron = new TobleronController(_broadcaster);
                tobleronControl.Initialize(_tobleron);

                // Yönetim sekmeleri
                controlPanel.Initialize(_viz, _ticker);
                msgSdTek.InitializeTicker(_ticker);
                msgSdCift.InitializeTicker(_ticker);
                msgSdKj.InitializeTicker(_ticker);
                msgBirazdan.InitializeTicker(_ticker);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            tmrStatus.Stop();
            if (_tobleron != null) _tobleron.Dispose();
            if (_ticker != null) _ticker.Dispose();
            _viz.Dispose();
            base.OnFormClosed(e);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (TestDb(false))
                ReloadCurrentTab();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (DesignMode) return;
            // Açılışta otomatik bağlan; operatör ayrıca "Yayına Bağlan"a basmak zorunda kalmasın.
            // Hata olursa sessiz kalır, durum panelinde "Bağlı değil" görünür (butonla yeniden denenebilir).
            Connect(false);
        }

        // ------------------------------------------------------------------ bağlantı

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect(true);
        }

        private void Connect(bool showErrors)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                _broadcaster.Connect();
                string scene = _viz.GetMainSceneName();
                if (scene != SceneConfig.SceneName)
                    Ui.Info("Viz'de beklenen sahne yüklü değil.\n\nBeklenen: " + SceneConfig.SceneName + "\nYüklü: " + scene);
                lblVizStatus.Text = "Viz: " + VizEngineClient.Host + ":" + VizEngineClient.Port + " | Sahne: " + scene;
                tmrStatus.Start();
                RefreshStatus();
            }
            catch (Exception ex)
            {
                if (showErrors) Ui.Error(ex);
                else lblVizStatus.Text = "Otomatik bağlanılamadı: " + ex.Message;
                RefreshStatus();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>Yazma komutlarını ve Viz cevabını alt çubukta gösterir (GET'ler gösterilmez).</summary>
        private void OnVizCommand(string command, string answer)
        {
            if (VizEngineClient.IsReadCommand(command)) return;
            string text = DateTime.Now.ToString("HH:mm:ss") + "  " + command + "  →  " + (answer == "" ? "OK" : answer);
            if (InvokeRequired) BeginInvoke((Action)(() => lblVizStatus.Text = text));
            else lblVizStatus.Text = text;
        }

        // ------------------------------------------------------------------ logo (doğrudan engine komutu)

        private void btnLogoIn_Click(object sender, EventArgs e) { LogoCommand(_broadcaster.LogoIn); }
        private void btnLogoOut_Click(object sender, EventArgs e) { LogoCommand(_broadcaster.LogoOut); }
        private void btnLogoReklam_Click(object sender, EventArgs e) { LogoCommand(_broadcaster.LogoReklam); }

        private void LogoCommand(Action action)
        {
            try { action(); }
            catch (Exception ex) { Ui.Error(ex); }
            RefreshStatus();
        }

        private void tmrStatus_Tick(object sender, EventArgs e)
        {
            RefreshStatus();
        }

        /// <summary>Bağlantı ve katman durumlarını üst panele yazar (salt okuma).</summary>
        private void RefreshStatus()
        {
            bool ready = _broadcaster != null && _broadcaster.IsReady;
            lblConnState.Text = ready ? "● Bağlı" : "● Bağlı değil";
            lblConnState.ForeColor = ready ? Ok : Off;
            btnConnect.Text = ready ? "Bağlı ✓" : "Yayına Bağlan";

            string[] st = null;
            try { st = ready ? _broadcaster.ReadLayerStates() : null; }
            catch { st = null; }

            if (st == null)
            {
                SetState(lblMainState, "Ana bant: -", Off);
                SetState(lblSdState, "Son dakika KJ: -", Off);
                return;
            }

            string main = st[0];
            if (main == SceneConfig.StopMainTicker) SetState(lblMainState, "Ana bant: HABER BANDI", Ok);
            else if (main == SceneConfig.StopSdTek) SetState(lblMainState, "Ana bant: SON DAKİKA (tek)", OnAir);
            else if (main == SceneConfig.StopBirazdan) SetState(lblMainState, "Ana bant: BİRAZDAN", Warn);
            else if (main == SceneConfig.StopOut) SetState(lblMainState, "Ana bant: kapalı", Off);
            else SetState(lblMainState, "Ana bant: geçişte…", Off);

            string sd = st[1];
            if (sd == SceneConfig.StopSdKj) SetState(lblSdState, "Son dakika KJ: EKRANDA", OnAir);
            else if (sd == SceneConfig.StopSdCift) SetState(lblSdState, "SD Çift: EKRANDA", OnAir);
            else if (sd == SceneConfig.StopOut) SetState(lblSdState, "Son dakika KJ: kapalı", Off);
            else SetState(lblSdState, "Son dakika KJ: geçişte…", Off);
        }

        private static void SetState(Label l, string text, Color c)
        {
            l.Text = text;
            l.ForeColor = c;
        }

        // ------------------------------------------------------------------ sekmeler

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadCurrentTab();
        }

        private void tabYonetim_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadPage(tabYonetim.SelectedTab);
        }

        private void btnDbTest_Click(object sender, EventArgs e)
        {
            TestDb(true);
        }

        /// <summary>Seçili sekmedeki kontrolün verisini DB'den yeniden yükler (iç içe sekmeler dahil).</summary>
        private void ReloadCurrentTab()
        {
            ReloadPage(tabMain.SelectedTab);
        }

        private static void ReloadPage(TabPage page)
        {
            if (page == null) return;
            foreach (Control c in page.Controls)
            {
                var r = c as IReloadable;
                if (r != null) r.ReloadData();
                var inner = c as TabControl;
                if (inner != null) ReloadPage(inner.SelectedTab);
            }
        }

        private bool TestDb(bool showMessage)
        {
            try
            {
                string version = Db.TestConnection();
                lblDbStatus.Text = "DB: bağlı (MySQL " + version + ")";
                lblDbStatus.ForeColor = Color.DarkGreen;
                if (showMessage) Ui.Info("MySQL bağlantısı başarılı.\nSürüm: " + version);
                return true;
            }
            catch (Exception ex)
            {
                lblDbStatus.Text = "DB: HATA";
                lblDbStatus.ForeColor = Color.Red;
                Ui.Error(ex);
                return false;
            }
        }
    }
}
