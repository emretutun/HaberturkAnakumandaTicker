namespace HaberturkAnakumandaTicker.UI
{
    partial class PlaylistControl
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
            this.flpTemplate = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTemplate = new System.Windows.Forms.Label();
            this.cmbTemplate = new System.Windows.Forms.ComboBox();
            this.lblTplName = new System.Windows.Forms.Label();
            this.txtTplName = new System.Windows.Forms.TextBox();
            this.btnTplSave = new System.Windows.Forms.Button();
            this.btnTplDelete = new System.Windows.Forms.Button();
            this.flpRange = new System.Windows.Forms.FlowLayoutPanel();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblLast = new System.Windows.Forms.Label();
            this.numHours = new System.Windows.Forms.NumericUpDown();
            this.lblHours = new System.Windows.Forms.Label();
            this.btnApplyHours = new System.Windows.Forms.Button();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.dgvCounts = new System.Windows.Forms.DataGridView();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAvailable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvQueue = new System.Windows.Forms.DataGridView();
            this.colSend = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colQCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flpBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblSummary = new System.Windows.Forms.Label();
            this.btnMainIn = new System.Windows.Forms.Button();
            this.btnMainOut = new System.Windows.Forms.Button();
            this.flpTemplate.SuspendLayout();
            this.flpRange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueue)).BeginInit();
            this.flpBottom.SuspendLayout();
            this.SuspendLayout();
            //
            // flpTemplate
            //
            this.flpTemplate.AutoSize = true;
            this.flpTemplate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpTemplate.Controls.Add(this.lblTemplate);
            this.flpTemplate.Controls.Add(this.cmbTemplate);
            this.flpTemplate.Controls.Add(this.lblTplName);
            this.flpTemplate.Controls.Add(this.txtTplName);
            this.flpTemplate.Controls.Add(this.btnTplSave);
            this.flpTemplate.Controls.Add(this.btnTplDelete);
            this.flpTemplate.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpTemplate.Location = new System.Drawing.Point(0, 0);
            this.flpTemplate.Name = "flpTemplate";
            this.flpTemplate.Padding = new System.Windows.Forms.Padding(3);
            this.flpTemplate.Size = new System.Drawing.Size(900, 39);
            this.flpTemplate.TabIndex = 0;
            this.flpTemplate.WrapContents = false;
            //
            // lblTemplate
            //
            this.lblTemplate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTemplate.AutoSize = true;
            this.lblTemplate.Location = new System.Drawing.Point(6, 12);
            this.lblTemplate.Name = "lblTemplate";
            this.lblTemplate.Size = new System.Drawing.Size(46, 15);
            this.lblTemplate.TabIndex = 0;
            this.lblTemplate.Text = "Şablon:";
            //
            // cmbTemplate
            //
            this.cmbTemplate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTemplate.FormattingEnabled = true;
            this.cmbTemplate.Location = new System.Drawing.Point(58, 8);
            this.cmbTemplate.Name = "cmbTemplate";
            this.cmbTemplate.Size = new System.Drawing.Size(260, 23);
            this.cmbTemplate.TabIndex = 1;
            this.cmbTemplate.SelectedIndexChanged += new System.EventHandler(this.cmbTemplate_SelectedIndexChanged);
            //
            // lblTplName
            //
            this.lblTplName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTplName.AutoSize = true;
            this.lblTplName.Location = new System.Drawing.Point(334, 12);
            this.lblTplName.Margin = new System.Windows.Forms.Padding(13, 0, 3, 0);
            this.lblTplName.Name = "lblTplName";
            this.lblTplName.Size = new System.Drawing.Size(70, 15);
            this.lblTplName.TabIndex = 2;
            this.lblTplName.Text = "Şablon adı:";
            //
            // txtTplName
            //
            this.txtTplName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTplName.Location = new System.Drawing.Point(410, 8);
            this.txtTplName.MaxLength = 100;
            this.txtTplName.Name = "txtTplName";
            this.txtTplName.Size = new System.Drawing.Size(220, 23);
            this.txtTplName.TabIndex = 3;
            //
            // btnTplSave
            //
            this.btnTplSave.AutoSize = true;
            this.btnTplSave.Location = new System.Drawing.Point(636, 6);
            this.btnTplSave.Name = "btnTplSave";
            this.btnTplSave.Size = new System.Drawing.Size(100, 27);
            this.btnTplSave.TabIndex = 4;
            this.btnTplSave.Text = "Şablonu Kaydet";
            this.btnTplSave.UseVisualStyleBackColor = true;
            this.btnTplSave.Click += new System.EventHandler(this.btnTplSave_Click);
            //
            // btnTplDelete
            //
            this.btnTplDelete.AutoSize = true;
            this.btnTplDelete.Location = new System.Drawing.Point(742, 6);
            this.btnTplDelete.Name = "btnTplDelete";
            this.btnTplDelete.Size = new System.Drawing.Size(85, 27);
            this.btnTplDelete.TabIndex = 5;
            this.btnTplDelete.Text = "Şablonu Sil";
            this.btnTplDelete.UseVisualStyleBackColor = true;
            this.btnTplDelete.Click += new System.EventHandler(this.btnTplDelete_Click);
            //
            // flpRange
            //
            this.flpRange.AutoSize = true;
            this.flpRange.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpRange.Controls.Add(this.lblFrom);
            this.flpRange.Controls.Add(this.dtpFrom);
            this.flpRange.Controls.Add(this.lblTo);
            this.flpRange.Controls.Add(this.dtpTo);
            this.flpRange.Controls.Add(this.lblLast);
            this.flpRange.Controls.Add(this.numHours);
            this.flpRange.Controls.Add(this.lblHours);
            this.flpRange.Controls.Add(this.btnApplyHours);
            this.flpRange.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpRange.Location = new System.Drawing.Point(0, 39);
            this.flpRange.Name = "flpRange";
            this.flpRange.Padding = new System.Windows.Forms.Padding(3);
            this.flpRange.Size = new System.Drawing.Size(900, 39);
            this.flpRange.TabIndex = 1;
            this.flpRange.WrapContents = false;
            //
            // lblFrom
            //
            this.lblFrom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(6, 12);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(96, 15);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "Girildiği tarih: ilk";
            //
            // dtpFrom
            //
            this.dtpFrom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpFrom.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(108, 8);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(140, 23);
            this.dtpFrom.TabIndex = 1;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpRange_ValueChanged);
            //
            // lblTo
            //
            this.lblTo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(254, 12);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(28, 15);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "son";
            //
            // dtpTo
            //
            this.dtpTo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpTo.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(288, 8);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(140, 23);
            this.dtpTo.TabIndex = 3;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpRange_ValueChanged);
            //
            // lblLast
            //
            this.lblLast.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLast.AutoSize = true;
            this.lblLast.Location = new System.Drawing.Point(447, 12);
            this.lblLast.Margin = new System.Windows.Forms.Padding(16, 0, 3, 0);
            this.lblLast.Name = "lblLast";
            this.lblLast.Size = new System.Drawing.Size(48, 15);
            this.lblLast.TabIndex = 4;
            this.lblLast.Text = "ya da son";
            //
            // numHours
            //
            this.numHours.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numHours.Location = new System.Drawing.Point(501, 8);
            this.numHours.Maximum = new decimal(new int[] {
            720,
            0,
            0,
            0});
            this.numHours.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHours.Name = "numHours";
            this.numHours.Size = new System.Drawing.Size(60, 23);
            this.numHours.TabIndex = 5;
            this.numHours.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            //
            // lblHours
            //
            this.lblHours.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHours.AutoSize = true;
            this.lblHours.Location = new System.Drawing.Point(567, 12);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(29, 15);
            this.lblHours.TabIndex = 6;
            this.lblHours.Text = "saat";
            //
            // btnApplyHours
            //
            this.btnApplyHours.AutoSize = true;
            this.btnApplyHours.Location = new System.Drawing.Point(602, 6);
            this.btnApplyHours.Name = "btnApplyHours";
            this.btnApplyHours.Size = new System.Drawing.Size(75, 27);
            this.btnApplyHours.TabIndex = 7;
            this.btnApplyHours.Text = "Uygula";
            this.btnApplyHours.UseVisualStyleBackColor = true;
            this.btnApplyHours.Click += new System.EventHandler(this.btnApplyHours_Click);
            //
            // splitMain
            //
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 78);
            this.splitMain.Name = "splitMain";
            //
            // splitMain.Panel1
            //
            this.splitMain.Panel1.Controls.Add(this.dgvCounts);
            //
            // splitMain.Panel2
            //
            this.splitMain.Panel2.Controls.Add(this.dgvQueue);
            this.splitMain.Size = new System.Drawing.Size(900, 433);
            this.splitMain.SplitterDistance = 330;
            this.splitMain.TabIndex = 2;
            //
            // dgvCounts
            //
            this.dgvCounts.AllowUserToAddRows = false;
            this.dgvCounts.AllowUserToDeleteRows = false;
            this.dgvCounts.AllowUserToResizeRows = false;
            this.dgvCounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCounts.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCategory,
            this.colAvailable,
            this.colCount});
            this.dgvCounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCounts.Location = new System.Drawing.Point(0, 0);
            this.dgvCounts.MultiSelect = false;
            this.dgvCounts.Name = "dgvCounts";
            this.dgvCounts.RowHeadersVisible = false;
            this.dgvCounts.Size = new System.Drawing.Size(330, 433);
            this.dgvCounts.TabIndex = 0;
            this.dgvCounts.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCounts_CellEndEdit);
            //
            // colCategory
            //
            this.colCategory.FillWeight = 140F;
            this.colCategory.HeaderText = "Kategori";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // colAvailable
            //
            this.colAvailable.HeaderText = "Aralıkta";
            this.colAvailable.Name = "colAvailable";
            this.colAvailable.ReadOnly = true;
            this.colAvailable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // colCount
            //
            this.colCount.HeaderText = "Gönderilecek (kulakçıklı: en az 3)";
            this.colCount.Name = "colCount";
            this.colCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // dgvQueue
            // 
            this.dgvQueue.AllowUserToAddRows = false;
            this.dgvQueue.AllowUserToDeleteRows = false;
            this.dgvQueue.AllowUserToResizeRows = false;
            this.dgvQueue.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQueue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSend,
            this.colQCategory,
            this.colQDate,
            this.colQText});
            this.dgvQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQueue.Location = new System.Drawing.Point(0, 0);
            this.dgvQueue.MultiSelect = false;
            this.dgvQueue.Name = "dgvQueue";
            this.dgvQueue.RowHeadersVisible = false;
            this.dgvQueue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQueue.Size = new System.Drawing.Size(566, 433);
            this.dgvQueue.TabIndex = 0;
            this.dgvQueue.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQueue_CellValueChanged);
            this.dgvQueue.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvQueue_CurrentCellDirtyStateChanged);
            // 
            // colSend
            // 
            this.colSend.HeaderText = "Gönder";
            this.colSend.Name = "colSend";
            this.colSend.Width = 60;
            // 
            // colQCategory
            // 
            this.colQCategory.HeaderText = "Kategori";
            this.colQCategory.Name = "colQCategory";
            this.colQCategory.ReadOnly = true;
            this.colQCategory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colQCategory.Width = 110;
            // 
            // colQDate
            // 
            this.colQDate.HeaderText = "Girildi";
            this.colQDate.Name = "colQDate";
            this.colQDate.ReadOnly = true;
            this.colQDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colQDate.Width = 95;
            // 
            // colQText
            // 
            this.colQText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colQText.HeaderText = "Haber";
            this.colQText.Name = "colQText";
            this.colQText.ReadOnly = true;
            this.colQText.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // flpBottom
            //
            this.flpBottom.AutoSize = true;
            this.flpBottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpBottom.Controls.Add(this.btnPreview);
            this.flpBottom.Controls.Add(this.btnSend);
            this.flpBottom.Controls.Add(this.btnMainIn);
            this.flpBottom.Controls.Add(this.btnMainOut);
            this.flpBottom.Controls.Add(this.lblSummary);
            this.flpBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpBottom.Location = new System.Drawing.Point(0, 511);
            this.flpBottom.Name = "flpBottom";
            this.flpBottom.Padding = new System.Windows.Forms.Padding(3);
            this.flpBottom.Size = new System.Drawing.Size(900, 39);
            this.flpBottom.TabIndex = 3;
            this.flpBottom.WrapContents = false;
            //
            // btnPreview
            //
            this.btnPreview.AutoSize = true;
            this.btnPreview.Location = new System.Drawing.Point(6, 6);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(150, 27);
            this.btnPreview.TabIndex = 0;
            this.btnPreview.Text = "Listele / Otomatik Seç";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            //
            // btnSend
            //
            this.btnSend.AutoSize = true;
            this.btnSend.Location = new System.Drawing.Point(87, 6);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(190, 27);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Seçilenleri Ana Banda Gönder";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            //
            // btnMainIn
            //
            this.btnMainIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnMainIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainIn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnMainIn.ForeColor = System.Drawing.Color.White;
            this.btnMainIn.Location = new System.Drawing.Point(233, 6);
            this.btnMainIn.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnMainIn.Name = "btnMainIn";
            this.btnMainIn.Size = new System.Drawing.Size(190, 40);
            this.btnMainIn.TabIndex = 3;
            this.btnMainIn.Text = "▶  ANA BANDI VER";
            this.btnMainIn.UseVisualStyleBackColor = false;
            this.btnMainIn.Click += new System.EventHandler(this.btnMainIn_Click);
            //
            // btnMainOut
            //
            this.btnMainOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnMainOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainOut.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnMainOut.ForeColor = System.Drawing.Color.White;
            this.btnMainOut.Location = new System.Drawing.Point(429, 6);
            this.btnMainOut.Name = "btnMainOut";
            this.btnMainOut.Size = new System.Drawing.Size(190, 40);
            this.btnMainOut.TabIndex = 4;
            this.btnMainOut.Text = "■  ANA BANDI AL";
            this.btnMainOut.UseVisualStyleBackColor = false;
            this.btnMainOut.Click += new System.EventHandler(this.btnMainOut_Click);
            //
            // lblSummary
            //
            this.lblSummary.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSummary.AutoSize = true;
            this.lblSummary.ForeColor = System.Drawing.Color.DimGray;
            this.lblSummary.Location = new System.Drawing.Point(243, 12);
            this.lblSummary.Margin = new System.Windows.Forms.Padding(13, 0, 3, 0);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(12, 15);
            this.lblSummary.TabIndex = 2;
            this.lblSummary.Text = "-";
            //
            // PlaylistControl
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.flpBottom);
            this.Controls.Add(this.flpRange);
            this.Controls.Add(this.flpTemplate);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "PlaylistControl";
            this.Size = new System.Drawing.Size(900, 550);
            this.flpTemplate.ResumeLayout(false);
            this.flpTemplate.PerformLayout();
            this.flpRange.ResumeLayout(false);
            this.flpRange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).EndInit();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueue)).EndInit();
            this.flpBottom.ResumeLayout(false);
            this.flpBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpTemplate;
        private System.Windows.Forms.Label lblTemplate;
        private System.Windows.Forms.ComboBox cmbTemplate;
        private System.Windows.Forms.Label lblTplName;
        private System.Windows.Forms.TextBox txtTplName;
        private System.Windows.Forms.Button btnTplSave;
        private System.Windows.Forms.Button btnTplDelete;
        private System.Windows.Forms.FlowLayoutPanel flpRange;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblLast;
        private System.Windows.Forms.NumericUpDown numHours;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.Button btnApplyHours;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.DataGridView dgvCounts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAvailable;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        private System.Windows.Forms.DataGridView dgvQueue;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSend;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQText;
        private System.Windows.Forms.FlowLayoutPanel flpBottom;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Button btnMainIn;
        private System.Windows.Forms.Button btnMainOut;
    }
}
