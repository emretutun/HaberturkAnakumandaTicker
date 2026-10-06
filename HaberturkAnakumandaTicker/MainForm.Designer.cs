namespace HaberturkAnakumandaTicker
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlTop = new System.Windows.Forms.FlowLayoutPanel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblConnState = new System.Windows.Forms.Label();
            this.lblMainState = new System.Windows.Forms.Label();
            this.lblSdState = new System.Windows.Forms.Label();
            this.btnLogoIn = new System.Windows.Forms.Button();
            this.btnLogoOut = new System.Windows.Forms.Button();
            this.btnLogoReklam = new System.Windows.Forms.Button();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tpAnaBant = new System.Windows.Forms.TabPage();
            this.playlistControl = new HaberturkAnakumandaTicker.UI.PlaylistControl();
            this.tpSonDakika = new System.Windows.Forms.TabPage();
            this.quickSonDakika = new HaberturkAnakumandaTicker.UI.QuickBroadcastControl();
            this.tpBirazdan = new System.Windows.Forms.TabPage();
            this.quickBirazdan = new HaberturkAnakumandaTicker.UI.QuickBroadcastControl();
            this.tpTobleron = new System.Windows.Forms.TabPage();
            this.tobleronControl = new HaberturkAnakumandaTicker.UI.TobleronControl();
            this.tpYonetim = new System.Windows.Forms.TabPage();
            this.tabYonetim = new System.Windows.Forms.TabControl();
            this.tpHaberler = new System.Windows.Forms.TabPage();
            this.msgMain = new HaberturkAnakumandaTicker.UI.MessageCrudControl();
            this.tpCategories = new System.Windows.Forms.TabPage();
            this.categoryCrud = new HaberturkAnakumandaTicker.UI.CategoryCrudControl();
            this.tpSdTek = new System.Windows.Forms.TabPage();
            this.msgSdTek = new HaberturkAnakumandaTicker.UI.MessageCrudControl();
            this.tpSdKj = new System.Windows.Forms.TabPage();
            this.msgSdKj = new HaberturkAnakumandaTicker.UI.MessageCrudControl();
            this.tpBirazdanList = new System.Windows.Forms.TabPage();
            this.msgBirazdan = new HaberturkAnakumandaTicker.UI.MessageCrudControl();
            this.tpSdCift = new System.Windows.Forms.TabPage();
            this.msgSdCift = new HaberturkAnakumandaTicker.UI.MessageCrudControl();
            this.tpEconomy = new System.Windows.Forms.TabPage();
            this.economyCrud = new HaberturkAnakumandaTicker.UI.EconomyCrudControl();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.settingsControl = new HaberturkAnakumandaTicker.UI.SettingsControl();
            this.tpGelismis = new System.Windows.Forms.TabPage();
            this.controlPanel = new HaberturkAnakumandaTicker.UI.ControlPanelControl();
            this.statusMain = new System.Windows.Forms.StatusStrip();
            this.lblDbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnDbTest = new System.Windows.Forms.ToolStripButton();
            this.lblVizStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrStatus = new System.Windows.Forms.Timer(this.components);
            this.pnlTop.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tpAnaBant.SuspendLayout();
            this.tpSonDakika.SuspendLayout();
            this.tpBirazdan.SuspendLayout();
            this.tpTobleron.SuspendLayout();
            this.tpYonetim.SuspendLayout();
            this.tabYonetim.SuspendLayout();
            this.tpHaberler.SuspendLayout();
            this.tpCategories.SuspendLayout();
            this.tpSdTek.SuspendLayout();
            this.tpSdKj.SuspendLayout();
            this.tpBirazdanList.SuspendLayout();
            this.tpSdCift.SuspendLayout();
            this.tpEconomy.SuspendLayout();
            this.tpSettings.SuspendLayout();
            this.tpGelismis.SuspendLayout();
            this.statusMain.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlTop
            //
            this.pnlTop.AutoSize = true;
            this.pnlTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.pnlTop.Controls.Add(this.btnConnect);
            this.pnlTop.Controls.Add(this.lblConnState);
            this.pnlTop.Controls.Add(this.lblMainState);
            this.pnlTop.Controls.Add(this.lblSdState);
            this.pnlTop.Controls.Add(this.btnLogoIn);
            this.pnlTop.Controls.Add(this.btnLogoOut);
            this.pnlTop.Controls.Add(this.btnLogoReklam);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(8);
            this.pnlTop.Size = new System.Drawing.Size(1184, 58);
            this.pnlTop.TabIndex = 0;
            this.pnlTop.WrapContents = false;
            //
            // btnConnect
            //
            this.btnConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(101)))), ((int)(((byte)(164)))));
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Location = new System.Drawing.Point(11, 11);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(160, 36);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Yayına Bağlan";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            //
            // lblConnState
            //
            this.lblConnState.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblConnState.AutoSize = true;
            this.lblConnState.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblConnState.ForeColor = System.Drawing.Color.Silver;
            this.lblConnState.Location = new System.Drawing.Point(189, 19);
            this.lblConnState.Margin = new System.Windows.Forms.Padding(15, 0, 25, 0);
            this.lblConnState.Name = "lblConnState";
            this.lblConnState.Size = new System.Drawing.Size(90, 19);
            this.lblConnState.TabIndex = 1;
            this.lblConnState.Text = "● Bağlı değil";
            //
            // lblMainState
            //
            this.lblMainState.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMainState.AutoSize = true;
            this.lblMainState.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMainState.ForeColor = System.Drawing.Color.Silver;
            this.lblMainState.Location = new System.Drawing.Point(307, 19);
            this.lblMainState.Margin = new System.Windows.Forms.Padding(3, 0, 25, 0);
            this.lblMainState.Name = "lblMainState";
            this.lblMainState.Size = new System.Drawing.Size(90, 19);
            this.lblMainState.TabIndex = 2;
            this.lblMainState.Text = "Ana bant: -";
            //
            // lblSdState
            //
            this.lblSdState.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSdState.AutoSize = true;
            this.lblSdState.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSdState.ForeColor = System.Drawing.Color.Silver;
            this.lblSdState.Location = new System.Drawing.Point(425, 19);
            this.lblSdState.Name = "lblSdState";
            this.lblSdState.Size = new System.Drawing.Size(110, 19);
            this.lblSdState.TabIndex = 3;
            this.lblSdState.Text = "Son dakika KJ: -";
            //
            // btnLogoIn
            //
            this.btnLogoIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnLogoIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogoIn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogoIn.ForeColor = System.Drawing.Color.White;
            this.btnLogoIn.Location = new System.Drawing.Point(568, 11);
            this.btnLogoIn.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.btnLogoIn.Name = "btnLogoIn";
            this.btnLogoIn.Size = new System.Drawing.Size(110, 36);
            this.btnLogoIn.TabIndex = 4;
            this.btnLogoIn.Text = "LOGO VER";
            this.btnLogoIn.UseVisualStyleBackColor = false;
            this.btnLogoIn.Click += new System.EventHandler(this.btnLogoIn_Click);
            //
            // btnLogoOut
            //
            this.btnLogoOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnLogoOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogoOut.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogoOut.ForeColor = System.Drawing.Color.White;
            this.btnLogoOut.Location = new System.Drawing.Point(684, 11);
            this.btnLogoOut.Name = "btnLogoOut";
            this.btnLogoOut.Size = new System.Drawing.Size(110, 36);
            this.btnLogoOut.TabIndex = 5;
            this.btnLogoOut.Text = "LOGO AL";
            this.btnLogoOut.UseVisualStyleBackColor = false;
            this.btnLogoOut.Click += new System.EventHandler(this.btnLogoOut_Click);
            //
            // btnLogoReklam
            //
            this.btnLogoReklam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.btnLogoReklam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogoReklam.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogoReklam.ForeColor = System.Drawing.Color.White;
            this.btnLogoReklam.Location = new System.Drawing.Point(800, 11);
            this.btnLogoReklam.Name = "btnLogoReklam";
            this.btnLogoReklam.Size = new System.Drawing.Size(120, 36);
            this.btnLogoReklam.TabIndex = 6;
            this.btnLogoReklam.Text = "REKLAM LOGO";
            this.btnLogoReklam.UseVisualStyleBackColor = false;
            this.btnLogoReklam.Click += new System.EventHandler(this.btnLogoReklam_Click);
            //
            // tabMain
            //
            this.tabMain.Controls.Add(this.tpAnaBant);
            this.tabMain.Controls.Add(this.tpSonDakika);
            this.tabMain.Controls.Add(this.tpBirazdan);
            this.tabMain.Controls.Add(this.tpTobleron);
            this.tabMain.Controls.Add(this.tpYonetim);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabMain.ItemSize = new System.Drawing.Size(140, 30);
            this.tabMain.Location = new System.Drawing.Point(0, 58);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Drawing.Point(12, 4);
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1184, 641);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMain.TabIndex = 1;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            //
            // tpAnaBant
            //
            this.tpAnaBant.Controls.Add(this.playlistControl);
            this.tpAnaBant.Location = new System.Drawing.Point(4, 34);
            this.tpAnaBant.Name = "tpAnaBant";
            this.tpAnaBant.Padding = new System.Windows.Forms.Padding(3);
            this.tpAnaBant.Size = new System.Drawing.Size(1176, 603);
            this.tpAnaBant.TabIndex = 0;
            this.tpAnaBant.Text = "Ana Bant";
            this.tpAnaBant.UseVisualStyleBackColor = true;
            //
            // playlistControl
            //
            this.playlistControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playlistControl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.playlistControl.Location = new System.Drawing.Point(3, 3);
            this.playlistControl.Name = "playlistControl";
            this.playlistControl.Size = new System.Drawing.Size(1170, 597);
            this.playlistControl.TabIndex = 0;
            //
            // tpSonDakika
            //
            this.tpSonDakika.Controls.Add(this.quickSonDakika);
            this.tpSonDakika.Location = new System.Drawing.Point(4, 34);
            this.tpSonDakika.Name = "tpSonDakika";
            this.tpSonDakika.Padding = new System.Windows.Forms.Padding(3);
            this.tpSonDakika.Size = new System.Drawing.Size(1176, 603);
            this.tpSonDakika.TabIndex = 1;
            this.tpSonDakika.Text = "Son Dakika";
            this.tpSonDakika.UseVisualStyleBackColor = true;
            //
            // quickSonDakika
            //
            this.quickSonDakika.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quickSonDakika.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.quickSonDakika.Location = new System.Drawing.Point(3, 3);
            this.quickSonDakika.Mode = HaberturkAnakumandaTicker.UI.QuickMode.SonDakika;
            this.quickSonDakika.Name = "quickSonDakika";
            this.quickSonDakika.Size = new System.Drawing.Size(1170, 597);
            this.quickSonDakika.TabIndex = 0;
            //
            // tpBirazdan
            //
            this.tpBirazdan.Controls.Add(this.quickBirazdan);
            this.tpBirazdan.Location = new System.Drawing.Point(4, 34);
            this.tpBirazdan.Name = "tpBirazdan";
            this.tpBirazdan.Padding = new System.Windows.Forms.Padding(3);
            this.tpBirazdan.Size = new System.Drawing.Size(1176, 603);
            this.tpBirazdan.TabIndex = 2;
            this.tpBirazdan.Text = "Birazdan";
            this.tpBirazdan.UseVisualStyleBackColor = true;
            //
            // quickBirazdan
            //
            this.quickBirazdan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quickBirazdan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.quickBirazdan.Location = new System.Drawing.Point(3, 3);
            this.quickBirazdan.Mode = HaberturkAnakumandaTicker.UI.QuickMode.Birazdan;
            this.quickBirazdan.Name = "quickBirazdan";
            this.quickBirazdan.Size = new System.Drawing.Size(1170, 597);
            this.quickBirazdan.TabIndex = 0;
            //
            // tpTobleron
            //
            this.tpTobleron.Controls.Add(this.tobleronControl);
            this.tpTobleron.Location = new System.Drawing.Point(4, 34);
            this.tpTobleron.Name = "tpTobleron";
            this.tpTobleron.Padding = new System.Windows.Forms.Padding(3);
            this.tpTobleron.Size = new System.Drawing.Size(1176, 603);
            this.tpTobleron.TabIndex = 3;
            this.tpTobleron.Text = "Tobleron";
            this.tpTobleron.UseVisualStyleBackColor = true;
            //
            // tobleronControl
            //
            this.tobleronControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tobleronControl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tobleronControl.Location = new System.Drawing.Point(3, 3);
            this.tobleronControl.Name = "tobleronControl";
            this.tobleronControl.Size = new System.Drawing.Size(1170, 597);
            this.tobleronControl.TabIndex = 0;
            //
            // tpYonetim
            //
            this.tpYonetim.Controls.Add(this.tabYonetim);
            this.tpYonetim.Location = new System.Drawing.Point(4, 34);
            this.tpYonetim.Name = "tpYonetim";
            this.tpYonetim.Padding = new System.Windows.Forms.Padding(3);
            this.tpYonetim.Size = new System.Drawing.Size(1176, 603);
            this.tpYonetim.TabIndex = 4;
            this.tpYonetim.Text = "⚙ Yönetim";
            this.tpYonetim.UseVisualStyleBackColor = true;
            //
            // tabYonetim
            //
            this.tabYonetim.Controls.Add(this.tpHaberler);
            this.tabYonetim.Controls.Add(this.tpCategories);
            this.tabYonetim.Controls.Add(this.tpSdTek);
            this.tabYonetim.Controls.Add(this.tpSdKj);
            this.tabYonetim.Controls.Add(this.tpBirazdanList);
            this.tabYonetim.Controls.Add(this.tpSdCift);
            this.tabYonetim.Controls.Add(this.tpEconomy);
            this.tabYonetim.Controls.Add(this.tpSettings);
            this.tabYonetim.Controls.Add(this.tpGelismis);
            this.tabYonetim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabYonetim.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabYonetim.Location = new System.Drawing.Point(3, 3);
            this.tabYonetim.Name = "tabYonetim";
            this.tabYonetim.SelectedIndex = 0;
            this.tabYonetim.Size = new System.Drawing.Size(1170, 597);
            this.tabYonetim.TabIndex = 0;
            this.tabYonetim.SelectedIndexChanged += new System.EventHandler(this.tabYonetim_SelectedIndexChanged);
            //
            // tpHaberler
            //
            this.tpHaberler.Controls.Add(this.msgMain);
            this.tpHaberler.Location = new System.Drawing.Point(4, 24);
            this.tpHaberler.Name = "tpHaberler";
            this.tpHaberler.Padding = new System.Windows.Forms.Padding(3);
            this.tpHaberler.Size = new System.Drawing.Size(1162, 569);
            this.tpHaberler.TabIndex = 0;
            this.tpHaberler.Text = "Ana Bant Haberleri";
            this.tpHaberler.UseVisualStyleBackColor = true;
            //
            // msgMain
            //
            this.msgMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msgMain.Location = new System.Drawing.Point(3, 3);
            this.msgMain.MessageType = HaberturkAnakumandaTicker.Models.MessageType.MAIN;
            this.msgMain.Name = "msgMain";
            this.msgMain.Size = new System.Drawing.Size(1156, 563);
            this.msgMain.TabIndex = 0;
            //
            // tpCategories
            //
            this.tpCategories.Controls.Add(this.categoryCrud);
            this.tpCategories.Location = new System.Drawing.Point(4, 24);
            this.tpCategories.Name = "tpCategories";
            this.tpCategories.Padding = new System.Windows.Forms.Padding(3);
            this.tpCategories.Size = new System.Drawing.Size(1162, 569);
            this.tpCategories.TabIndex = 1;
            this.tpCategories.Text = "Kategoriler";
            this.tpCategories.UseVisualStyleBackColor = true;
            //
            // categoryCrud
            //
            this.categoryCrud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoryCrud.Location = new System.Drawing.Point(3, 3);
            this.categoryCrud.Name = "categoryCrud";
            this.categoryCrud.Size = new System.Drawing.Size(1156, 563);
            this.categoryCrud.TabIndex = 0;
            //
            // tpSdTek
            //
            this.tpSdTek.Controls.Add(this.msgSdTek);
            this.tpSdTek.Location = new System.Drawing.Point(4, 24);
            this.tpSdTek.Name = "tpSdTek";
            this.tpSdTek.Padding = new System.Windows.Forms.Padding(3);
            this.tpSdTek.Size = new System.Drawing.Size(1162, 569);
            this.tpSdTek.TabIndex = 2;
            this.tpSdTek.Text = "Son Dakika Tek (liste)";
            this.tpSdTek.UseVisualStyleBackColor = true;
            //
            // msgSdTek
            //
            this.msgSdTek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msgSdTek.Location = new System.Drawing.Point(3, 3);
            this.msgSdTek.MessageType = HaberturkAnakumandaTicker.Models.MessageType.SD_TEK;
            this.msgSdTek.Name = "msgSdTek";
            this.msgSdTek.Size = new System.Drawing.Size(1156, 563);
            this.msgSdTek.TabIndex = 0;
            //
            // tpSdKj
            //
            this.tpSdKj.Controls.Add(this.msgSdKj);
            this.tpSdKj.Location = new System.Drawing.Point(4, 24);
            this.tpSdKj.Name = "tpSdKj";
            this.tpSdKj.Padding = new System.Windows.Forms.Padding(3);
            this.tpSdKj.Size = new System.Drawing.Size(1162, 569);
            this.tpSdKj.TabIndex = 3;
            this.tpSdKj.Text = "Son Dakika KJ (liste)";
            this.tpSdKj.UseVisualStyleBackColor = true;
            //
            // msgSdKj
            //
            this.msgSdKj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msgSdKj.Location = new System.Drawing.Point(3, 3);
            this.msgSdKj.MessageType = HaberturkAnakumandaTicker.Models.MessageType.SD_KJ;
            this.msgSdKj.Name = "msgSdKj";
            this.msgSdKj.Size = new System.Drawing.Size(1156, 563);
            this.msgSdKj.TabIndex = 0;
            //
            // tpBirazdanList
            //
            this.tpBirazdanList.Controls.Add(this.msgBirazdan);
            this.tpBirazdanList.Location = new System.Drawing.Point(4, 24);
            this.tpBirazdanList.Name = "tpBirazdanList";
            this.tpBirazdanList.Padding = new System.Windows.Forms.Padding(3);
            this.tpBirazdanList.Size = new System.Drawing.Size(1162, 569);
            this.tpBirazdanList.TabIndex = 4;
            this.tpBirazdanList.Text = "Birazdan (liste)";
            this.tpBirazdanList.UseVisualStyleBackColor = true;
            //
            // msgBirazdan
            //
            this.msgBirazdan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msgBirazdan.Location = new System.Drawing.Point(3, 3);
            this.msgBirazdan.MessageType = HaberturkAnakumandaTicker.Models.MessageType.BIRAZDAN;
            this.msgBirazdan.Name = "msgBirazdan";
            this.msgBirazdan.Size = new System.Drawing.Size(1156, 563);
            this.msgBirazdan.TabIndex = 0;
            //
            // tpSdCift
            //
            this.tpSdCift.Controls.Add(this.msgSdCift);
            this.tpSdCift.Location = new System.Drawing.Point(4, 24);
            this.tpSdCift.Name = "tpSdCift";
            this.tpSdCift.Padding = new System.Windows.Forms.Padding(3);
            this.tpSdCift.Size = new System.Drawing.Size(1162, 569);
            this.tpSdCift.TabIndex = 5;
            this.tpSdCift.Text = "SD Çift (kullanılmıyor)";
            this.tpSdCift.UseVisualStyleBackColor = true;
            //
            // msgSdCift
            //
            this.msgSdCift.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msgSdCift.Location = new System.Drawing.Point(3, 3);
            this.msgSdCift.MessageType = HaberturkAnakumandaTicker.Models.MessageType.SD_CIFT;
            this.msgSdCift.Name = "msgSdCift";
            this.msgSdCift.Size = new System.Drawing.Size(1156, 563);
            this.msgSdCift.TabIndex = 0;
            //
            // tpEconomy
            //
            this.tpEconomy.Controls.Add(this.economyCrud);
            this.tpEconomy.Location = new System.Drawing.Point(4, 24);
            this.tpEconomy.Name = "tpEconomy";
            this.tpEconomy.Padding = new System.Windows.Forms.Padding(3);
            this.tpEconomy.Size = new System.Drawing.Size(1162, 569);
            this.tpEconomy.TabIndex = 6;
            this.tpEconomy.Text = "Ekonomi (Tobleron)";
            this.tpEconomy.UseVisualStyleBackColor = true;
            //
            // economyCrud
            //
            this.economyCrud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.economyCrud.Location = new System.Drawing.Point(3, 3);
            this.economyCrud.Name = "economyCrud";
            this.economyCrud.Size = new System.Drawing.Size(1156, 563);
            this.economyCrud.TabIndex = 0;
            //
            // tpSettings
            //
            this.tpSettings.Controls.Add(this.settingsControl);
            this.tpSettings.Location = new System.Drawing.Point(4, 24);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpSettings.Size = new System.Drawing.Size(1162, 569);
            this.tpSettings.TabIndex = 7;
            this.tpSettings.Text = "Ayarlar";
            this.tpSettings.UseVisualStyleBackColor = true;
            //
            // settingsControl
            //
            this.settingsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsControl.Location = new System.Drawing.Point(3, 3);
            this.settingsControl.Name = "settingsControl";
            this.settingsControl.Size = new System.Drawing.Size(1156, 563);
            this.settingsControl.TabIndex = 0;
            //
            // tpGelismis
            //
            this.tpGelismis.Controls.Add(this.controlPanel);
            this.tpGelismis.Location = new System.Drawing.Point(4, 24);
            this.tpGelismis.Name = "tpGelismis";
            this.tpGelismis.Padding = new System.Windows.Forms.Padding(3);
            this.tpGelismis.Size = new System.Drawing.Size(1162, 569);
            this.tpGelismis.TabIndex = 8;
            this.tpGelismis.Text = "Gelişmiş / Log";
            this.tpGelismis.UseVisualStyleBackColor = true;
            //
            // controlPanel
            //
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlPanel.Location = new System.Drawing.Point(3, 3);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(1156, 563);
            this.controlPanel.TabIndex = 0;
            //
            // statusMain
            //
            this.statusMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDbStatus,
            this.btnDbTest,
            this.lblVizStatus});
            this.statusMain.Location = new System.Drawing.Point(0, 699);
            this.statusMain.Name = "statusMain";
            this.statusMain.Size = new System.Drawing.Size(1184, 22);
            this.statusMain.TabIndex = 2;
            //
            // lblDbStatus
            //
            this.lblDbStatus.Name = "lblDbStatus";
            this.lblDbStatus.Size = new System.Drawing.Size(36, 17);
            this.lblDbStatus.Text = "DB: ?";
            //
            // btnDbTest
            //
            this.btnDbTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDbTest.Name = "btnDbTest";
            this.btnDbTest.Size = new System.Drawing.Size(51, 20);
            this.btnDbTest.Text = "DB Test";
            this.btnDbTest.Click += new System.EventHandler(this.btnDbTest_Click);
            //
            // lblVizStatus
            //
            this.lblVizStatus.Name = "lblVizStatus";
            this.lblVizStatus.Size = new System.Drawing.Size(1082, 17);
            this.lblVizStatus.Spring = true;
            this.lblVizStatus.Text = "Viz: sadece 127.0.0.1:6100";
            this.lblVizStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // tmrStatus
            //
            this.tmrStatus.Interval = 2000;
            this.tmrStatus.Tick += new System.EventHandler(this.tmrStatus_Tick);
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 721);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.statusMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Habertürk Anakumanda Ticker 2026 - TEST";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tpAnaBant.ResumeLayout(false);
            this.tpSonDakika.ResumeLayout(false);
            this.tpBirazdan.ResumeLayout(false);
            this.tpTobleron.ResumeLayout(false);
            this.tpYonetim.ResumeLayout(false);
            this.tabYonetim.ResumeLayout(false);
            this.tpHaberler.ResumeLayout(false);
            this.tpCategories.ResumeLayout(false);
            this.tpSdTek.ResumeLayout(false);
            this.tpSdKj.ResumeLayout(false);
            this.tpBirazdanList.ResumeLayout(false);
            this.tpSdCift.ResumeLayout(false);
            this.tpEconomy.ResumeLayout(false);
            this.tpSettings.ResumeLayout(false);
            this.tpGelismis.ResumeLayout(false);
            this.statusMain.ResumeLayout(false);
            this.statusMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlTop;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblConnState;
        private System.Windows.Forms.Label lblMainState;
        private System.Windows.Forms.Label lblSdState;
        private System.Windows.Forms.Button btnLogoIn;
        private System.Windows.Forms.Button btnLogoOut;
        private System.Windows.Forms.Button btnLogoReklam;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tpAnaBant;
        private HaberturkAnakumandaTicker.UI.PlaylistControl playlistControl;
        private System.Windows.Forms.TabPage tpSonDakika;
        private HaberturkAnakumandaTicker.UI.QuickBroadcastControl quickSonDakika;
        private System.Windows.Forms.TabPage tpBirazdan;
        private HaberturkAnakumandaTicker.UI.QuickBroadcastControl quickBirazdan;
        private System.Windows.Forms.TabPage tpTobleron;
        private HaberturkAnakumandaTicker.UI.TobleronControl tobleronControl;
        private System.Windows.Forms.TabPage tpYonetim;
        private System.Windows.Forms.TabControl tabYonetim;
        private System.Windows.Forms.TabPage tpHaberler;
        private HaberturkAnakumandaTicker.UI.MessageCrudControl msgMain;
        private System.Windows.Forms.TabPage tpCategories;
        private HaberturkAnakumandaTicker.UI.CategoryCrudControl categoryCrud;
        private System.Windows.Forms.TabPage tpSdTek;
        private HaberturkAnakumandaTicker.UI.MessageCrudControl msgSdTek;
        private System.Windows.Forms.TabPage tpSdKj;
        private HaberturkAnakumandaTicker.UI.MessageCrudControl msgSdKj;
        private System.Windows.Forms.TabPage tpBirazdanList;
        private HaberturkAnakumandaTicker.UI.MessageCrudControl msgBirazdan;
        private System.Windows.Forms.TabPage tpSdCift;
        private HaberturkAnakumandaTicker.UI.MessageCrudControl msgSdCift;
        private System.Windows.Forms.TabPage tpEconomy;
        private HaberturkAnakumandaTicker.UI.EconomyCrudControl economyCrud;
        private System.Windows.Forms.TabPage tpSettings;
        private HaberturkAnakumandaTicker.UI.SettingsControl settingsControl;
        private System.Windows.Forms.TabPage tpGelismis;
        private HaberturkAnakumandaTicker.UI.ControlPanelControl controlPanel;
        private System.Windows.Forms.StatusStrip statusMain;
        private System.Windows.Forms.ToolStripStatusLabel lblDbStatus;
        private System.Windows.Forms.ToolStripButton btnDbTest;
        private System.Windows.Forms.ToolStripStatusLabel lblVizStatus;
        private System.Windows.Forms.Timer tmrStatus;
    }
}
