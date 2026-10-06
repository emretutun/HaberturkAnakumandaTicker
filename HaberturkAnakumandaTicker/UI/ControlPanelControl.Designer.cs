namespace HaberturkAnakumandaTicker.UI
{
    partial class ControlPanelControl
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flpTop = new System.Windows.Forms.FlowLayoutPanel();
            this.grpConnection = new System.Windows.Forms.GroupBox();
            this.flpConnection = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTickerConnect = new System.Windows.Forms.Button();
            this.lblTickerStatus = new System.Windows.Forms.Label();
            this.chkAllowWrite = new System.Windows.Forms.CheckBox();
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSendMain = new System.Windows.Forms.Button();
            this.btnMainIn = new System.Windows.Forms.Button();
            this.btnMainOut = new System.Windows.Forms.Button();
            this.btnMainClear = new System.Windows.Forms.Button();
            this.chkLegacyTr = new System.Windows.Forms.CheckBox();
            this.grpSdTek = new System.Windows.Forms.GroupBox();
            this.flpSdTek = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSdTekSend = new System.Windows.Forms.Button();
            this.btnSdTekIn = new System.Windows.Forms.Button();
            this.btnSdTekOut = new System.Windows.Forms.Button();
            this.btnSdTekClear = new System.Windows.Forms.Button();
            this.grpBirazdan = new System.Windows.Forms.GroupBox();
            this.flpBirazdan = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBirazdanSend = new System.Windows.Forms.Button();
            this.btnBirazdanIn = new System.Windows.Forms.Button();
            this.btnBirazdanOut = new System.Windows.Forms.Button();
            this.btnBirazdanClear = new System.Windows.Forms.Button();
            this.grpSdCift = new System.Windows.Forms.GroupBox();
            this.flpSdCift = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSdCiftSend = new System.Windows.Forms.Button();
            this.btnSdCiftIn = new System.Windows.Forms.Button();
            this.btnSdCiftOut = new System.Windows.Forms.Button();
            this.btnSdCiftClear = new System.Windows.Forms.Button();
            this.grpSdKj = new System.Windows.Forms.GroupBox();
            this.flpSdKj = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSdKjSend = new System.Windows.Forms.Button();
            this.btnSdKjIn = new System.Windows.Forms.Button();
            this.btnSdKjOut = new System.Windows.Forms.Button();
            this.btnSdKjClear = new System.Windows.Forms.Button();
            this.lblLastEvent = new System.Windows.Forms.Label();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.flpTop.SuspendLayout();
            this.grpConnection.SuspendLayout();
            this.flpConnection.SuspendLayout();
            this.grpMain.SuspendLayout();
            this.flpMain.SuspendLayout();
            this.grpSdTek.SuspendLayout();
            this.flpSdTek.SuspendLayout();
            this.grpBirazdan.SuspendLayout();
            this.flpBirazdan.SuspendLayout();
            this.grpSdCift.SuspendLayout();
            this.flpSdCift.SuspendLayout();
            this.grpSdKj.SuspendLayout();
            this.flpSdKj.SuspendLayout();
            this.SuspendLayout();
            //
            // flpTop
            //
            this.flpTop.AutoSize = true;
            this.flpTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpTop.Controls.Add(this.grpConnection);
            this.flpTop.Controls.Add(this.grpMain);
            this.flpTop.Controls.Add(this.grpSdTek);
            this.flpTop.Controls.Add(this.grpBirazdan);
            this.flpTop.Controls.Add(this.grpSdKj);
            this.flpTop.Controls.Add(this.grpSdCift);
            this.flpTop.Controls.Add(this.lblLastEvent);
            this.flpTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpTop.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpTop.Location = new System.Drawing.Point(0, 0);
            this.flpTop.Name = "flpTop";
            this.flpTop.Padding = new System.Windows.Forms.Padding(6);
            this.flpTop.Size = new System.Drawing.Size(900, 170);
            this.flpTop.TabIndex = 0;
            this.flpTop.WrapContents = false;
            //
            // grpConnection
            //
            this.grpConnection.AutoSize = true;
            this.grpConnection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpConnection.Controls.Add(this.flpConnection);
            this.grpConnection.Location = new System.Drawing.Point(9, 9);
            this.grpConnection.Name = "grpConnection";
            this.grpConnection.Padding = new System.Windows.Forms.Padding(6);
            this.grpConnection.Size = new System.Drawing.Size(600, 57);
            this.grpConnection.TabIndex = 0;
            this.grpConnection.TabStop = false;
            this.grpConnection.Text = "Bağlantı";
            //
            // flpConnection
            //
            this.flpConnection.AutoSize = true;
            this.flpConnection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpConnection.Controls.Add(this.btnTickerConnect);
            this.flpConnection.Controls.Add(this.lblTickerStatus);
            this.flpConnection.Controls.Add(this.chkAllowWrite);
            this.flpConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpConnection.Location = new System.Drawing.Point(6, 22);
            this.flpConnection.Name = "flpConnection";
            this.flpConnection.Size = new System.Drawing.Size(588, 29);
            this.flpConnection.TabIndex = 0;
            this.flpConnection.WrapContents = false;
            //
            // btnTickerConnect
            //
            this.btnTickerConnect.AutoSize = true;
            this.btnTickerConnect.Location = new System.Drawing.Point(3, 3);
            this.btnTickerConnect.Name = "btnTickerConnect";
            this.btnTickerConnect.Size = new System.Drawing.Size(110, 27);
            this.btnTickerConnect.TabIndex = 0;
            this.btnTickerConnect.Text = "VizTicker Bağlan";
            this.btnTickerConnect.UseVisualStyleBackColor = true;
            this.btnTickerConnect.Click += new System.EventHandler(this.btnTickerConnect_Click);
            //
            // lblTickerStatus
            //
            this.lblTickerStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTickerStatus.AutoSize = true;
            this.lblTickerStatus.Location = new System.Drawing.Point(119, 9);
            this.lblTickerStatus.Margin = new System.Windows.Forms.Padding(3, 0, 20, 0);
            this.lblTickerStatus.Name = "lblTickerStatus";
            this.lblTickerStatus.Size = new System.Drawing.Size(65, 15);
            this.lblTickerStatus.TabIndex = 1;
            this.lblTickerStatus.Text = "Bağlı değil";
            //
            // chkAllowWrite
            //
            this.chkAllowWrite.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkAllowWrite.AutoSize = true;
            this.chkAllowWrite.Location = new System.Drawing.Point(207, 7);
            this.chkAllowWrite.Name = "chkAllowWrite";
            this.chkAllowWrite.Size = new System.Drawing.Size(330, 19);
            this.chkAllowWrite.TabIndex = 2;
            this.chkAllowWrite.Text = "Viz\'e komut göndermeye izin ver (sadece 127.0.0.1:6100)";
            this.chkAllowWrite.UseVisualStyleBackColor = true;
            this.chkAllowWrite.CheckedChanged += new System.EventHandler(this.chkAllowWrite_CheckedChanged);
            //
            // grpMain
            //
            this.grpMain.AutoSize = true;
            this.grpMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpMain.Controls.Add(this.flpMain);
            this.grpMain.Location = new System.Drawing.Point(9, 72);
            this.grpMain.Name = "grpMain";
            this.grpMain.Padding = new System.Windows.Forms.Padding(6);
            this.grpMain.Size = new System.Drawing.Size(600, 57);
            this.grpMain.TabIndex = 1;
            this.grpMain.TabStop = false;
            this.grpMain.Text = "Ana Ticker";
            //
            // flpMain
            //
            this.flpMain.AutoSize = true;
            this.flpMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpMain.Controls.Add(this.btnSendMain);
            this.flpMain.Controls.Add(this.btnMainIn);
            this.flpMain.Controls.Add(this.btnMainOut);
            this.flpMain.Controls.Add(this.btnMainClear);
            this.flpMain.Controls.Add(this.chkLegacyTr);
            this.flpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMain.Location = new System.Drawing.Point(6, 22);
            this.flpMain.Name = "flpMain";
            this.flpMain.Size = new System.Drawing.Size(588, 29);
            this.flpMain.TabIndex = 0;
            this.flpMain.WrapContents = false;
            //
            // btnSendMain
            //
            this.btnSendMain.AutoSize = true;
            this.btnSendMain.Location = new System.Drawing.Point(3, 3);
            this.btnSendMain.Name = "btnSendMain";
            this.btnSendMain.Size = new System.Drawing.Size(100, 27);
            this.btnSendMain.TabIndex = 0;
            this.btnSendMain.Text = "DB\'den Gönder";
            this.btnSendMain.UseVisualStyleBackColor = true;
            this.btnSendMain.Click += new System.EventHandler(this.btnSendMain_Click);
            //
            // btnMainIn
            //
            this.btnMainIn.AutoSize = true;
            this.btnMainIn.Location = new System.Drawing.Point(109, 3);
            this.btnMainIn.Name = "btnMainIn";
            this.btnMainIn.Size = new System.Drawing.Size(80, 27);
            this.btnMainIn.TabIndex = 1;
            this.btnMainIn.Text = "Ticker VER";
            this.btnMainIn.UseVisualStyleBackColor = true;
            this.btnMainIn.Click += new System.EventHandler(this.btnMainIn_Click);
            //
            // btnMainOut
            //
            this.btnMainOut.AutoSize = true;
            this.btnMainOut.Location = new System.Drawing.Point(195, 3);
            this.btnMainOut.Name = "btnMainOut";
            this.btnMainOut.Size = new System.Drawing.Size(80, 27);
            this.btnMainOut.TabIndex = 2;
            this.btnMainOut.Text = "Ticker AL";
            this.btnMainOut.UseVisualStyleBackColor = true;
            this.btnMainOut.Click += new System.EventHandler(this.btnMainOut_Click);
            //
            // btnMainClear
            //
            this.btnMainClear.AutoSize = true;
            this.btnMainClear.Location = new System.Drawing.Point(281, 3);
            this.btnMainClear.Name = "btnMainClear";
            this.btnMainClear.Size = new System.Drawing.Size(75, 27);
            this.btnMainClear.TabIndex = 3;
            this.btnMainClear.Text = "Temizle";
            this.btnMainClear.UseVisualStyleBackColor = true;
            this.btnMainClear.Click += new System.EventHandler(this.btnMainClear_Click);
            //
            // chkLegacyTr
            //
            this.chkLegacyTr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkLegacyTr.AutoSize = true;
            this.chkLegacyTr.Location = new System.Drawing.Point(379, 7);
            this.chkLegacyTr.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.chkLegacyTr.Name = "chkLegacyTr";
            this.chkLegacyTr.Size = new System.Drawing.Size(170, 19);
            this.chkLegacyTr.TabIndex = 4;
            this.chkLegacyTr.Text = "Eski Türkçe dönüşümü";
            this.chkLegacyTr.UseVisualStyleBackColor = true;
            this.chkLegacyTr.CheckedChanged += new System.EventHandler(this.chkLegacyTr_CheckedChanged);
            //
            // grpSdTek
            //
            this.grpSdTek.AutoSize = true;
            this.grpSdTek.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpSdTek.Controls.Add(this.flpSdTek);
            this.grpSdTek.Location = new System.Drawing.Point(9, 135);
            this.grpSdTek.Name = "grpSdTek";
            this.grpSdTek.Padding = new System.Windows.Forms.Padding(6);
            this.grpSdTek.Size = new System.Drawing.Size(400, 57);
            this.grpSdTek.TabIndex = 3;
            this.grpSdTek.TabStop = false;
            this.grpSdTek.Text = "Son Dakika Tek";
            //
            // flpSdTek
            //
            this.flpSdTek.AutoSize = true;
            this.flpSdTek.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpSdTek.Controls.Add(this.btnSdTekSend);
            this.flpSdTek.Controls.Add(this.btnSdTekIn);
            this.flpSdTek.Controls.Add(this.btnSdTekOut);
            this.flpSdTek.Controls.Add(this.btnSdTekClear);
            this.flpSdTek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSdTek.Location = new System.Drawing.Point(6, 22);
            this.flpSdTek.Name = "flpSdTek";
            this.flpSdTek.Size = new System.Drawing.Size(388, 29);
            this.flpSdTek.TabIndex = 0;
            this.flpSdTek.WrapContents = false;
            //
            // btnSdTekSend
            //
            this.btnSdTekSend.AutoSize = true;
            this.btnSdTekSend.Location = new System.Drawing.Point(3, 3);
            this.btnSdTekSend.Name = "btnSdTekSend";
            this.btnSdTekSend.Size = new System.Drawing.Size(100, 27);
            this.btnSdTekSend.TabIndex = 0;
            this.btnSdTekSend.Text = "DB\'den Gönder";
            this.btnSdTekSend.UseVisualStyleBackColor = true;
            this.btnSdTekSend.Click += new System.EventHandler(this.btnSdTekSend_Click);
            //
            // btnSdTekIn
            //
            this.btnSdTekIn.AutoSize = true;
            this.btnSdTekIn.Location = new System.Drawing.Point(109, 3);
            this.btnSdTekIn.Name = "btnSdTekIn";
            this.btnSdTekIn.Size = new System.Drawing.Size(85, 27);
            this.btnSdTekIn.TabIndex = 1;
            this.btnSdTekIn.Text = "SD Tek VER";
            this.btnSdTekIn.UseVisualStyleBackColor = true;
            this.btnSdTekIn.Click += new System.EventHandler(this.btnSdTekIn_Click);
            //
            // btnSdTekOut
            //
            this.btnSdTekOut.AutoSize = true;
            this.btnSdTekOut.Location = new System.Drawing.Point(200, 3);
            this.btnSdTekOut.Name = "btnSdTekOut";
            this.btnSdTekOut.Size = new System.Drawing.Size(85, 27);
            this.btnSdTekOut.TabIndex = 2;
            this.btnSdTekOut.Text = "SD Tek AL";
            this.btnSdTekOut.UseVisualStyleBackColor = true;
            this.btnSdTekOut.Click += new System.EventHandler(this.btnSdTekOut_Click);
            //
            // btnSdTekClear
            //
            this.btnSdTekClear.AutoSize = true;
            this.btnSdTekClear.Location = new System.Drawing.Point(291, 3);
            this.btnSdTekClear.Name = "btnSdTekClear";
            this.btnSdTekClear.Size = new System.Drawing.Size(75, 27);
            this.btnSdTekClear.TabIndex = 3;
            this.btnSdTekClear.Text = "Temizle";
            this.btnSdTekClear.UseVisualStyleBackColor = true;
            this.btnSdTekClear.Click += new System.EventHandler(this.btnSdTekClear_Click);
            //
            // grpBirazdan
            //
            this.grpBirazdan.AutoSize = true;
            this.grpBirazdan.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpBirazdan.Controls.Add(this.flpBirazdan);
            this.grpBirazdan.Location = new System.Drawing.Point(9, 198);
            this.grpBirazdan.Name = "grpBirazdan";
            this.grpBirazdan.Padding = new System.Windows.Forms.Padding(6);
            this.grpBirazdan.Size = new System.Drawing.Size(400, 57);
            this.grpBirazdan.TabIndex = 4;
            this.grpBirazdan.TabStop = false;
            this.grpBirazdan.Text = "Birazdan";
            //
            // flpBirazdan
            //
            this.flpBirazdan.AutoSize = true;
            this.flpBirazdan.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpBirazdan.Controls.Add(this.btnBirazdanSend);
            this.flpBirazdan.Controls.Add(this.btnBirazdanIn);
            this.flpBirazdan.Controls.Add(this.btnBirazdanOut);
            this.flpBirazdan.Controls.Add(this.btnBirazdanClear);
            this.flpBirazdan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpBirazdan.Location = new System.Drawing.Point(6, 22);
            this.flpBirazdan.Name = "flpBirazdan";
            this.flpBirazdan.Size = new System.Drawing.Size(388, 29);
            this.flpBirazdan.TabIndex = 0;
            this.flpBirazdan.WrapContents = false;
            //
            // btnBirazdanSend
            //
            this.btnBirazdanSend.AutoSize = true;
            this.btnBirazdanSend.Location = new System.Drawing.Point(3, 3);
            this.btnBirazdanSend.Name = "btnBirazdanSend";
            this.btnBirazdanSend.Size = new System.Drawing.Size(100, 27);
            this.btnBirazdanSend.TabIndex = 0;
            this.btnBirazdanSend.Text = "DB\'den Gönder";
            this.btnBirazdanSend.UseVisualStyleBackColor = true;
            this.btnBirazdanSend.Click += new System.EventHandler(this.btnBirazdanSend_Click);
            //
            // btnBirazdanIn
            //
            this.btnBirazdanIn.AutoSize = true;
            this.btnBirazdanIn.Location = new System.Drawing.Point(109, 3);
            this.btnBirazdanIn.Name = "btnBirazdanIn";
            this.btnBirazdanIn.Size = new System.Drawing.Size(95, 27);
            this.btnBirazdanIn.TabIndex = 1;
            this.btnBirazdanIn.Text = "Birazdan VER";
            this.btnBirazdanIn.UseVisualStyleBackColor = true;
            this.btnBirazdanIn.Click += new System.EventHandler(this.btnBirazdanIn_Click);
            //
            // btnBirazdanOut
            //
            this.btnBirazdanOut.AutoSize = true;
            this.btnBirazdanOut.Location = new System.Drawing.Point(210, 3);
            this.btnBirazdanOut.Name = "btnBirazdanOut";
            this.btnBirazdanOut.Size = new System.Drawing.Size(95, 27);
            this.btnBirazdanOut.TabIndex = 2;
            this.btnBirazdanOut.Text = "Birazdan AL";
            this.btnBirazdanOut.UseVisualStyleBackColor = true;
            this.btnBirazdanOut.Click += new System.EventHandler(this.btnBirazdanOut_Click);
            //
            // btnBirazdanClear
            //
            this.btnBirazdanClear.AutoSize = true;
            this.btnBirazdanClear.Location = new System.Drawing.Point(311, 3);
            this.btnBirazdanClear.Name = "btnBirazdanClear";
            this.btnBirazdanClear.Size = new System.Drawing.Size(75, 27);
            this.btnBirazdanClear.TabIndex = 3;
            this.btnBirazdanClear.Text = "Temizle";
            this.btnBirazdanClear.UseVisualStyleBackColor = true;
            this.btnBirazdanClear.Click += new System.EventHandler(this.btnBirazdanClear_Click);
            //
            // grpSdCift
            //
            this.grpSdCift.AutoSize = true;
            this.grpSdCift.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpSdCift.Controls.Add(this.flpSdCift);
            this.grpSdCift.Location = new System.Drawing.Point(9, 324);
            this.grpSdCift.Name = "grpSdCift";
            this.grpSdCift.Padding = new System.Windows.Forms.Padding(6);
            this.grpSdCift.Size = new System.Drawing.Size(400, 57);
            this.grpSdCift.TabIndex = 6;
            this.grpSdCift.TabStop = false;
            this.grpSdCift.Text = "Son Dakika Çift (büyük)";
            //
            // flpSdCift
            //
            this.flpSdCift.AutoSize = true;
            this.flpSdCift.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpSdCift.Controls.Add(this.btnSdCiftSend);
            this.flpSdCift.Controls.Add(this.btnSdCiftIn);
            this.flpSdCift.Controls.Add(this.btnSdCiftOut);
            this.flpSdCift.Controls.Add(this.btnSdCiftClear);
            this.flpSdCift.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSdCift.Location = new System.Drawing.Point(6, 22);
            this.flpSdCift.Name = "flpSdCift";
            this.flpSdCift.Size = new System.Drawing.Size(388, 29);
            this.flpSdCift.TabIndex = 0;
            this.flpSdCift.WrapContents = false;
            //
            // btnSdCiftSend
            //
            this.btnSdCiftSend.AutoSize = true;
            this.btnSdCiftSend.Location = new System.Drawing.Point(3, 3);
            this.btnSdCiftSend.Name = "btnSdCiftSend";
            this.btnSdCiftSend.Size = new System.Drawing.Size(100, 27);
            this.btnSdCiftSend.TabIndex = 0;
            this.btnSdCiftSend.Text = "DB\'den Gönder";
            this.btnSdCiftSend.UseVisualStyleBackColor = true;
            this.btnSdCiftSend.Click += new System.EventHandler(this.btnSdCiftSend_Click);
            //
            // btnSdCiftIn
            //
            this.btnSdCiftIn.AutoSize = true;
            this.btnSdCiftIn.Location = new System.Drawing.Point(109, 3);
            this.btnSdCiftIn.Name = "btnSdCiftIn";
            this.btnSdCiftIn.Size = new System.Drawing.Size(85, 27);
            this.btnSdCiftIn.TabIndex = 1;
            this.btnSdCiftIn.Text = "SD Çift VER";
            this.btnSdCiftIn.UseVisualStyleBackColor = true;
            this.btnSdCiftIn.Click += new System.EventHandler(this.btnSdCiftIn_Click);
            //
            // btnSdCiftOut
            //
            this.btnSdCiftOut.AutoSize = true;
            this.btnSdCiftOut.Location = new System.Drawing.Point(200, 3);
            this.btnSdCiftOut.Name = "btnSdCiftOut";
            this.btnSdCiftOut.Size = new System.Drawing.Size(85, 27);
            this.btnSdCiftOut.TabIndex = 2;
            this.btnSdCiftOut.Text = "SD Çift AL";
            this.btnSdCiftOut.UseVisualStyleBackColor = true;
            this.btnSdCiftOut.Click += new System.EventHandler(this.btnSdCiftOut_Click);
            //
            // btnSdCiftClear
            //
            this.btnSdCiftClear.AutoSize = true;
            this.btnSdCiftClear.Location = new System.Drawing.Point(291, 3);
            this.btnSdCiftClear.Name = "btnSdCiftClear";
            this.btnSdCiftClear.Size = new System.Drawing.Size(75, 27);
            this.btnSdCiftClear.TabIndex = 3;
            this.btnSdCiftClear.Text = "Temizle";
            this.btnSdCiftClear.UseVisualStyleBackColor = true;
            this.btnSdCiftClear.Click += new System.EventHandler(this.btnSdCiftClear_Click);
            //
            // grpSdKj
            //
            this.grpSdKj.AutoSize = true;
            this.grpSdKj.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpSdKj.Controls.Add(this.flpSdKj);
            this.grpSdKj.Location = new System.Drawing.Point(9, 261);
            this.grpSdKj.Name = "grpSdKj";
            this.grpSdKj.Padding = new System.Windows.Forms.Padding(6);
            this.grpSdKj.Size = new System.Drawing.Size(400, 57);
            this.grpSdKj.TabIndex = 5;
            this.grpSdKj.TabStop = false;
            this.grpSdKj.Text = "Son Dakika KJ (kırmızı iki satır)";
            //
            // flpSdKj
            //
            this.flpSdKj.AutoSize = true;
            this.flpSdKj.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpSdKj.Controls.Add(this.btnSdKjSend);
            this.flpSdKj.Controls.Add(this.btnSdKjIn);
            this.flpSdKj.Controls.Add(this.btnSdKjOut);
            this.flpSdKj.Controls.Add(this.btnSdKjClear);
            this.flpSdKj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSdKj.Location = new System.Drawing.Point(6, 22);
            this.flpSdKj.Name = "flpSdKj";
            this.flpSdKj.Size = new System.Drawing.Size(388, 29);
            this.flpSdKj.TabIndex = 0;
            this.flpSdKj.WrapContents = false;
            //
            // btnSdKjSend
            //
            this.btnSdKjSend.AutoSize = true;
            this.btnSdKjSend.Location = new System.Drawing.Point(3, 3);
            this.btnSdKjSend.Name = "btnSdKjSend";
            this.btnSdKjSend.Size = new System.Drawing.Size(100, 27);
            this.btnSdKjSend.TabIndex = 0;
            this.btnSdKjSend.Text = "DB\'den Gönder";
            this.btnSdKjSend.UseVisualStyleBackColor = true;
            this.btnSdKjSend.Click += new System.EventHandler(this.btnSdKjSend_Click);
            //
            // btnSdKjIn
            //
            this.btnSdKjIn.AutoSize = true;
            this.btnSdKjIn.Location = new System.Drawing.Point(109, 3);
            this.btnSdKjIn.Name = "btnSdKjIn";
            this.btnSdKjIn.Size = new System.Drawing.Size(85, 27);
            this.btnSdKjIn.TabIndex = 1;
            this.btnSdKjIn.Text = "SD KJ VER";
            this.btnSdKjIn.UseVisualStyleBackColor = true;
            this.btnSdKjIn.Click += new System.EventHandler(this.btnSdKjIn_Click);
            //
            // btnSdKjOut
            //
            this.btnSdKjOut.AutoSize = true;
            this.btnSdKjOut.Location = new System.Drawing.Point(200, 3);
            this.btnSdKjOut.Name = "btnSdKjOut";
            this.btnSdKjOut.Size = new System.Drawing.Size(85, 27);
            this.btnSdKjOut.TabIndex = 2;
            this.btnSdKjOut.Text = "SD KJ AL";
            this.btnSdKjOut.UseVisualStyleBackColor = true;
            this.btnSdKjOut.Click += new System.EventHandler(this.btnSdKjOut_Click);
            //
            // btnSdKjClear
            //
            this.btnSdKjClear.AutoSize = true;
            this.btnSdKjClear.Location = new System.Drawing.Point(291, 3);
            this.btnSdKjClear.Name = "btnSdKjClear";
            this.btnSdKjClear.Size = new System.Drawing.Size(75, 27);
            this.btnSdKjClear.TabIndex = 3;
            this.btnSdKjClear.Text = "Temizle";
            this.btnSdKjClear.UseVisualStyleBackColor = true;
            this.btnSdKjClear.Click += new System.EventHandler(this.btnSdKjClear_Click);
            //
            // lblLastEvent
            //
            this.lblLastEvent.AutoSize = true;
            this.lblLastEvent.ForeColor = System.Drawing.Color.DimGray;
            this.lblLastEvent.Location = new System.Drawing.Point(9, 138);
            this.lblLastEvent.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.lblLastEvent.Name = "lblLastEvent";
            this.lblLastEvent.Size = new System.Drawing.Size(120, 15);
            this.lblLastEvent.TabIndex = 2;
            this.lblLastEvent.Text = "Son ticker olayı: -";
            //
            // lstLog
            //
            this.lstLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLog.FormattingEnabled = true;
            this.lstLog.HorizontalScrollbar = true;
            this.lstLog.IntegralHeight = false;
            this.lstLog.ItemHeight = 15;
            this.lstLog.Location = new System.Drawing.Point(0, 170);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(900, 380);
            this.lstLog.TabIndex = 1;
            //
            // ControlPanelControl
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.flpTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "ControlPanelControl";
            this.Size = new System.Drawing.Size(900, 550);
            this.flpTop.ResumeLayout(false);
            this.flpTop.PerformLayout();
            this.grpConnection.ResumeLayout(false);
            this.grpConnection.PerformLayout();
            this.flpConnection.ResumeLayout(false);
            this.flpConnection.PerformLayout();
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            this.flpMain.ResumeLayout(false);
            this.flpMain.PerformLayout();
            this.grpSdTek.ResumeLayout(false);
            this.grpSdTek.PerformLayout();
            this.flpSdTek.ResumeLayout(false);
            this.flpSdTek.PerformLayout();
            this.grpBirazdan.ResumeLayout(false);
            this.grpBirazdan.PerformLayout();
            this.flpBirazdan.ResumeLayout(false);
            this.flpBirazdan.PerformLayout();
            this.grpSdCift.ResumeLayout(false);
            this.grpSdCift.PerformLayout();
            this.flpSdCift.ResumeLayout(false);
            this.flpSdCift.PerformLayout();
            this.grpSdKj.ResumeLayout(false);
            this.grpSdKj.PerformLayout();
            this.flpSdKj.ResumeLayout(false);
            this.flpSdKj.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpTop;
        private System.Windows.Forms.GroupBox grpConnection;
        private System.Windows.Forms.FlowLayoutPanel flpConnection;
        private System.Windows.Forms.Button btnTickerConnect;
        private System.Windows.Forms.Label lblTickerStatus;
        private System.Windows.Forms.CheckBox chkAllowWrite;
        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.FlowLayoutPanel flpMain;
        private System.Windows.Forms.Button btnSendMain;
        private System.Windows.Forms.Button btnMainIn;
        private System.Windows.Forms.Button btnMainOut;
        private System.Windows.Forms.Button btnMainClear;
        private System.Windows.Forms.CheckBox chkLegacyTr;
        private System.Windows.Forms.GroupBox grpSdTek;
        private System.Windows.Forms.FlowLayoutPanel flpSdTek;
        private System.Windows.Forms.Button btnSdTekSend;
        private System.Windows.Forms.Button btnSdTekIn;
        private System.Windows.Forms.Button btnSdTekOut;
        private System.Windows.Forms.Button btnSdTekClear;
        private System.Windows.Forms.GroupBox grpBirazdan;
        private System.Windows.Forms.FlowLayoutPanel flpBirazdan;
        private System.Windows.Forms.Button btnBirazdanSend;
        private System.Windows.Forms.Button btnBirazdanIn;
        private System.Windows.Forms.Button btnBirazdanOut;
        private System.Windows.Forms.Button btnBirazdanClear;
        private System.Windows.Forms.GroupBox grpSdCift;
        private System.Windows.Forms.FlowLayoutPanel flpSdCift;
        private System.Windows.Forms.Button btnSdCiftSend;
        private System.Windows.Forms.Button btnSdCiftIn;
        private System.Windows.Forms.Button btnSdCiftOut;
        private System.Windows.Forms.Button btnSdCiftClear;
        private System.Windows.Forms.GroupBox grpSdKj;
        private System.Windows.Forms.FlowLayoutPanel flpSdKj;
        private System.Windows.Forms.Button btnSdKjSend;
        private System.Windows.Forms.Button btnSdKjIn;
        private System.Windows.Forms.Button btnSdKjOut;
        private System.Windows.Forms.Button btnSdKjClear;
        private System.Windows.Forms.Label lblLastEvent;
        private System.Windows.Forms.ListBox lstLog;
    }
}
