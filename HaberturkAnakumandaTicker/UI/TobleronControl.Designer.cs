namespace HaberturkAnakumandaTicker.UI
{
    partial class TobleronControl
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
            this.components = new System.ComponentModel.Container();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHint = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChange = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colLogo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flpBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSaveSend = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnOut = new System.Windows.Forms.Button();
            this.lblNow = new System.Windows.Forms.Label();
            this.chkAuto = new System.Windows.Forms.CheckBox();
            this.lblPoll = new System.Windows.Forms.Label();
            this.tmrPoll = new System.Windows.Forms.Timer(this.components);
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.flpBottom.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.Controls.Add(this.lblHint);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(10, 8, 10, 4);
            this.pnlHeader.Size = new System.Drawing.Size(900, 62);
            this.pnlHeader.TabIndex = 0;
            //
            // lblHint
            //
            this.lblHint.AutoSize = true;
            this.lblHint.ForeColor = System.Drawing.Color.DimGray;
            this.lblHint.Location = new System.Drawing.Point(12, 38);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(520, 15);
            this.lblHint.TabIndex = 1;
            this.lblHint.Text = "Değeri ve yönü yazıp \"Değerleri Kaydet ve Gönder\"e basın. Yeni veri / logo: Yönetim > Ekonomi.";
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(8, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(215, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "TOBLERON (EKONOMİ)";
            //
            // dgvItems
            //
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colValue,
            this.colChange,
            this.colActive,
            this.colLogo});
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvItems.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dgvItems.Location = new System.Drawing.Point(0, 62);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.RowTemplate.Height = 32;
            this.dgvItems.Size = new System.Drawing.Size(900, 426);
            this.dgvItems.TabIndex = 1;
            this.dgvItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellValueChanged);
            this.dgvItems.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvItems_CurrentCellDirtyStateChanged);
            //
            // colName
            //
            this.colName.FillWeight = 160F;
            this.colName.HeaderText = "Veri";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            //
            // colValue
            //
            this.colValue.FillWeight = 120F;
            this.colValue.HeaderText = "Değer";
            this.colValue.Name = "colValue";
            //
            // colChange
            //
            this.colChange.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colChange.FillWeight = 110F;
            this.colChange.HeaderText = "Yön";
            this.colChange.Items.AddRange(new object[] {
            "▲ Arttı",
            "▼ Düştü",
            "= Değişmedi"});
            this.colChange.Name = "colChange";
            //
            // colActive
            //
            this.colActive.FillWeight = 50F;
            this.colActive.HeaderText = "Göster";
            this.colActive.Name = "colActive";
            //
            // colLogo
            //
            this.colLogo.FillWeight = 50F;
            this.colLogo.HeaderText = "Logo";
            this.colLogo.Name = "colLogo";
            this.colLogo.ReadOnly = true;
            //
            // flpBottom
            //
            this.flpBottom.AutoSize = true;
            this.flpBottom.Controls.Add(this.btnSaveSend);
            this.flpBottom.Controls.Add(this.btnIn);
            this.flpBottom.Controls.Add(this.btnOut);
            this.flpBottom.Controls.Add(this.lblNow);
            this.flpBottom.Controls.Add(this.chkAuto);
            this.flpBottom.Controls.Add(this.lblPoll);
            this.flpBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpBottom.Location = new System.Drawing.Point(0, 488);
            this.flpBottom.Name = "flpBottom";
            this.flpBottom.Padding = new System.Windows.Forms.Padding(6);
            this.flpBottom.Size = new System.Drawing.Size(900, 62);
            this.flpBottom.TabIndex = 2;
            //
            // btnSaveSend
            //
            this.btnSaveSend.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSaveSend.Location = new System.Drawing.Point(9, 9);
            this.btnSaveSend.Name = "btnSaveSend";
            this.btnSaveSend.Size = new System.Drawing.Size(230, 40);
            this.btnSaveSend.TabIndex = 0;
            this.btnSaveSend.Text = "Değerleri Kaydet ve Gönder";
            this.btnSaveSend.UseVisualStyleBackColor = true;
            this.btnSaveSend.Click += new System.EventHandler(this.btnSaveSend_Click);
            //
            // btnIn
            //
            this.btnIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnIn.ForeColor = System.Drawing.Color.White;
            this.btnIn.Location = new System.Drawing.Point(262, 9);
            this.btnIn.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(200, 40);
            this.btnIn.TabIndex = 1;
            this.btnIn.Text = "▶  TOBLERON VER";
            this.btnIn.UseVisualStyleBackColor = false;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            //
            // btnOut
            //
            this.btnOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOut.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnOut.ForeColor = System.Drawing.Color.White;
            this.btnOut.Location = new System.Drawing.Point(468, 9);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(200, 40);
            this.btnOut.TabIndex = 2;
            this.btnOut.Text = "■  TOBLERON AL";
            this.btnOut.UseVisualStyleBackColor = false;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            //
            // lblNow
            //
            this.lblNow.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNow.AutoSize = true;
            this.lblNow.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNow.ForeColor = System.Drawing.Color.DimGray;
            this.lblNow.Location = new System.Drawing.Point(686, 19);
            this.lblNow.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblNow.Name = "lblNow";
            this.lblNow.Size = new System.Drawing.Size(95, 19);
            this.lblNow.TabIndex = 3;
            this.lblNow.Text = "Yayında değil";
            //
            // chkAuto
            //
            this.chkAuto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkAuto.AutoSize = true;
            this.chkAuto.Checked = true;
            this.chkAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAuto.Location = new System.Drawing.Point(800, 19);
            this.chkAuto.Margin = new System.Windows.Forms.Padding(25, 3, 3, 3);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(200, 19);
            this.chkAuto.TabIndex = 4;
            this.chkAuto.Text = "DB'den otomatik güncelle (2 sn)";
            this.chkAuto.UseVisualStyleBackColor = true;
            this.chkAuto.CheckedChanged += new System.EventHandler(this.chkAuto_CheckedChanged);
            //
            // lblPoll
            //
            this.lblPoll.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPoll.AutoSize = true;
            this.lblPoll.ForeColor = System.Drawing.Color.DimGray;
            this.lblPoll.Location = new System.Drawing.Point(1006, 21);
            this.lblPoll.Name = "lblPoll";
            this.lblPoll.Size = new System.Drawing.Size(12, 15);
            this.lblPoll.TabIndex = 5;
            this.lblPoll.Text = "-";
            //
            // tmrPoll
            //
            this.tmrPoll.Interval = 2000;
            this.tmrPoll.Tick += new System.EventHandler(this.tmrPoll_Tick);
            //
            // TobleronControl
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.flpBottom);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "TobleronControl";
            this.Size = new System.Drawing.Size(900, 550);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.flpBottom.ResumeLayout(false);
            this.flpBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.DataGridViewComboBoxColumn colChange;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogo;
        private System.Windows.Forms.FlowLayoutPanel flpBottom;
        private System.Windows.Forms.Button btnSaveSend;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.Label lblNow;
        private System.Windows.Forms.CheckBox chkAuto;
        private System.Windows.Forms.Label lblPoll;
        private System.Windows.Forms.Timer tmrPoll;
    }
}
