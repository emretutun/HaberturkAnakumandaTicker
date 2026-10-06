namespace HaberturkAnakumandaTicker.UI
{
    partial class QuickBroadcastControl
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
            this.flpHeader = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.rbTek = new System.Windows.Forms.RadioButton();
            this.rbKj = new System.Windows.Forms.RadioButton();
            this.tlpEntry = new System.Windows.Forms.TableLayoutPanel();
            this.lblText1 = new System.Windows.Forms.Label();
            this.txtText1 = new System.Windows.Forms.TextBox();
            this.lblText2 = new System.Windows.Forms.Label();
            this.txtText2 = new System.Windows.Forms.TextBox();
            this.lblBumper = new System.Windows.Forms.Label();
            this.cmbBumper = new System.Windows.Forms.ComboBox();
            this.flpEntryButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSaveAir = new System.Windows.Forms.Button();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colText1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colText2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBumper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flpActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAir = new System.Windows.Forms.Button();
            this.btnOff = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblOnAir = new System.Windows.Forms.Label();
            this.flpHeader.SuspendLayout();
            this.tlpEntry.SuspendLayout();
            this.flpEntryButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.flpActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpHeader
            // 
            this.flpHeader.AutoSize = true;
            this.flpHeader.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpHeader.Controls.Add(this.lblTitle);
            this.flpHeader.Controls.Add(this.rbTek);
            this.flpHeader.Controls.Add(this.rbKj);
            this.flpHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpHeader.Location = new System.Drawing.Point(0, 0);
            this.flpHeader.Name = "flpHeader";
            this.flpHeader.Padding = new System.Windows.Forms.Padding(6);
            this.flpHeader.Size = new System.Drawing.Size(900, 43);
            this.flpHeader.TabIndex = 0;
            this.flpHeader.WrapContents = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(9, 9);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(127, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "SON DAKİKA";
            // 
            // rbTek
            // 
            this.rbTek.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbTek.AutoSize = true;
            this.rbTek.Checked = true;
            this.rbTek.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbTek.Location = new System.Drawing.Point(169, 10);
            this.rbTek.Name = "rbTek";
            this.rbTek.Size = new System.Drawing.Size(117, 23);
            this.rbTek.TabIndex = 1;
            this.rbTek.TabStop = true;
            this.rbTek.Text = "Tek satır (bant)";
            this.rbTek.UseVisualStyleBackColor = true;
            this.rbTek.CheckedChanged += new System.EventHandler(this.rbType_CheckedChanged);
            // 
            // rbKj
            // 
            this.rbKj.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbKj.AutoSize = true;
            this.rbKj.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbKj.Location = new System.Drawing.Point(292, 10);
            this.rbKj.Name = "rbKj";
            this.rbKj.Size = new System.Drawing.Size(140, 23);
            this.rbKj.TabIndex = 2;
            this.rbKj.Text = "İki satır (kırmızı KJ)";
            this.rbKj.UseVisualStyleBackColor = true;
            this.rbKj.CheckedChanged += new System.EventHandler(this.rbType_CheckedChanged);
            // 
            // tlpEntry
            // 
            this.tlpEntry.AutoSize = true;
            this.tlpEntry.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpEntry.ColumnCount = 4;
            this.tlpEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpEntry.Controls.Add(this.lblText1, 0, 0);
            this.tlpEntry.Controls.Add(this.txtText1, 1, 0);
            this.tlpEntry.Controls.Add(this.lblText2, 0, 1);
            this.tlpEntry.Controls.Add(this.txtText2, 1, 1);
            this.tlpEntry.Controls.Add(this.lblBumper, 0, 2);
            this.tlpEntry.Controls.Add(this.cmbBumper, 1, 2);
            this.tlpEntry.Controls.Add(this.flpEntryButtons, 3, 2);
            this.tlpEntry.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpEntry.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tlpEntry.Location = new System.Drawing.Point(0, 43);
            this.tlpEntry.Name = "tlpEntry";
            this.tlpEntry.Padding = new System.Windows.Forms.Padding(6);
            this.tlpEntry.RowCount = 3;
            this.tlpEntry.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEntry.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEntry.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEntry.Size = new System.Drawing.Size(900, 115);
            this.tlpEntry.TabIndex = 1;
            // 
            // lblText1
            // 
            this.lblText1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblText1.AutoSize = true;
            this.lblText1.Location = new System.Drawing.Point(9, 12);
            this.lblText1.Name = "lblText1";
            this.lblText1.Size = new System.Drawing.Size(48, 19);
            this.lblText1.TabIndex = 0;
            this.lblText1.Text = "Metin:";
            // 
            // txtText1
            // 
            this.tlpEntry.SetColumnSpan(this.txtText1, 3);
            this.txtText1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtText1.Location = new System.Drawing.Point(75, 9);
            this.txtText1.MaxLength = 500;
            this.txtText1.Name = "txtText1";
            this.txtText1.Size = new System.Drawing.Size(816, 25);
            this.txtText1.TabIndex = 1;
            // 
            // lblText2
            // 
            this.lblText2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblText2.AutoSize = true;
            this.lblText2.Location = new System.Drawing.Point(9, 43);
            this.lblText2.Name = "lblText2";
            this.lblText2.Size = new System.Drawing.Size(59, 19);
            this.lblText2.TabIndex = 2;
            this.lblText2.Text = "Alt satır:";
            // 
            // txtText2
            // 
            this.tlpEntry.SetColumnSpan(this.txtText2, 3);
            this.txtText2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtText2.Location = new System.Drawing.Point(75, 40);
            this.txtText2.MaxLength = 500;
            this.txtText2.Name = "txtText2";
            this.txtText2.Size = new System.Drawing.Size(816, 25);
            this.txtText2.TabIndex = 3;
            // 
            // lblBumper
            // 
            this.lblBumper.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBumper.AutoSize = true;
            this.lblBumper.Location = new System.Drawing.Point(9, 79);
            this.lblBumper.Name = "lblBumper";
            this.lblBumper.Size = new System.Drawing.Size(60, 19);
            this.lblBumper.TabIndex = 4;
            this.lblBumper.Text = "Bumper:";
            // 
            // cmbBumper
            // 
            this.cmbBumper.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbBumper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBumper.FormattingEnabled = true;
            this.cmbBumper.Items.AddRange(new object[] {
            "Yok",
            "Sessiz",
            "Sesli"});
            this.cmbBumper.Location = new System.Drawing.Point(75, 78);
            this.cmbBumper.Name = "cmbBumper";
            this.cmbBumper.Size = new System.Drawing.Size(140, 25);
            this.cmbBumper.TabIndex = 5;
            // 
            // flpEntryButtons
            // 
            this.flpEntryButtons.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.flpEntryButtons.AutoSize = true;
            this.flpEntryButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpEntryButtons.Controls.Add(this.btnSave);
            this.flpEntryButtons.Controls.Add(this.btnSaveAir);
            this.flpEntryButtons.Location = new System.Drawing.Point(598, 71);
            this.flpEntryButtons.Name = "flpEntryButtons";
            this.flpEntryButtons.Size = new System.Drawing.Size(293, 35);
            this.flpEntryButtons.TabIndex = 6;
            this.flpEntryButtons.WrapContents = false;
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.btnSave.Size = new System.Drawing.Size(115, 29);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "+ Listeye Ekle";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveAir
            // 
            this.btnSaveAir.AutoSize = true;
            this.btnSaveAir.Location = new System.Drawing.Point(124, 3);
            this.btnSaveAir.Name = "btnSaveAir";
            this.btnSaveAir.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.btnSaveAir.Size = new System.Drawing.Size(209, 29);
            this.btnSaveAir.TabIndex = 1;
            this.btnSaveAir.Text = "+ Ekle ve Hemen Yayına Al";
            this.btnSaveAir.UseVisualStyleBackColor = true;
            this.btnSaveAir.Click += new System.EventHandler(this.btnSaveAir_Click);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTime,
            this.colText1,
            this.colText2,
            this.colBumper});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvList.Location = new System.Drawing.Point(0, 158);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowTemplate.Height = 28;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(900, 322);
            this.dgvList.TabIndex = 2;
            this.dgvList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellDoubleClick);
            // 
            // colTime
            // 
            this.colTime.HeaderText = "Eklendi";
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            this.colTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTime.Width = 110;
            // 
            // colText1
            // 
            this.colText1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colText1.FillWeight = 60F;
            this.colText1.HeaderText = "Metin";
            this.colText1.Name = "colText1";
            this.colText1.ReadOnly = true;
            this.colText1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colText2
            // 
            this.colText2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colText2.FillWeight = 40F;
            this.colText2.HeaderText = "Alt satır";
            this.colText2.Name = "colText2";
            this.colText2.ReadOnly = true;
            this.colText2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colBumper
            // 
            this.colBumper.HeaderText = "Bumper";
            this.colBumper.Name = "colBumper";
            this.colBumper.ReadOnly = true;
            this.colBumper.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBumper.Width = 80;
            // 
            // flpActions
            // 
            this.flpActions.AutoSize = true;
            this.flpActions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpActions.Controls.Add(this.btnAir);
            this.flpActions.Controls.Add(this.btnOff);
            this.flpActions.Controls.Add(this.btnDelete);
            this.flpActions.Controls.Add(this.lblOnAir);
            this.flpActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpActions.Location = new System.Drawing.Point(0, 480);
            this.flpActions.Name = "flpActions";
            this.flpActions.Padding = new System.Windows.Forms.Padding(6);
            this.flpActions.Size = new System.Drawing.Size(900, 70);
            this.flpActions.TabIndex = 3;
            this.flpActions.WrapContents = false;
            // 
            // btnAir
            // 
            this.btnAir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnAir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAir.ForeColor = System.Drawing.Color.White;
            this.btnAir.Location = new System.Drawing.Point(9, 9);
            this.btnAir.Name = "btnAir";
            this.btnAir.Size = new System.Drawing.Size(260, 52);
            this.btnAir.TabIndex = 0;
            this.btnAir.Text = "▶  SEÇİLİYİ YAYINA AL";
            this.btnAir.UseVisualStyleBackColor = false;
            this.btnAir.Click += new System.EventHandler(this.btnAir_Click);
            // 
            // btnOff
            // 
            this.btnOff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOff.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnOff.ForeColor = System.Drawing.Color.White;
            this.btnOff.Location = new System.Drawing.Point(275, 9);
            this.btnOff.Name = "btnOff";
            this.btnOff.Size = new System.Drawing.Size(200, 52);
            this.btnOff.TabIndex = 1;
            this.btnOff.Text = "■  YAYINDAN AL";
            this.btnOff.UseVisualStyleBackColor = false;
            this.btnOff.Click += new System.EventHandler(this.btnOff_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnDelete.AutoSize = true;
            this.btnDelete.Location = new System.Drawing.Point(493, 20);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 29);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Seçiliyi Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblOnAir
            // 
            this.lblOnAir.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOnAir.AutoSize = true;
            this.lblOnAir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblOnAir.ForeColor = System.Drawing.Color.DimGray;
            this.lblOnAir.Location = new System.Drawing.Point(596, 25);
            this.lblOnAir.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblOnAir.Name = "lblOnAir";
            this.lblOnAir.Size = new System.Drawing.Size(100, 19);
            this.lblOnAir.TabIndex = 3;
            this.lblOnAir.Text = "Yayında değil";
            // 
            // QuickBroadcastControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.flpActions);
            this.Controls.Add(this.tlpEntry);
            this.Controls.Add(this.flpHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "QuickBroadcastControl";
            this.Size = new System.Drawing.Size(900, 550);
            this.flpHeader.ResumeLayout(false);
            this.flpHeader.PerformLayout();
            this.tlpEntry.ResumeLayout(false);
            this.tlpEntry.PerformLayout();
            this.flpEntryButtons.ResumeLayout(false);
            this.flpEntryButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.flpActions.ResumeLayout(false);
            this.flpActions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RadioButton rbTek;
        private System.Windows.Forms.RadioButton rbKj;
        private System.Windows.Forms.TableLayoutPanel tlpEntry;
        private System.Windows.Forms.Label lblText1;
        private System.Windows.Forms.TextBox txtText1;
        private System.Windows.Forms.Label lblText2;
        private System.Windows.Forms.TextBox txtText2;
        private System.Windows.Forms.Label lblBumper;
        private System.Windows.Forms.ComboBox cmbBumper;
        private System.Windows.Forms.FlowLayoutPanel flpEntryButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSaveAir;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colText1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colText2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBumper;
        private System.Windows.Forms.FlowLayoutPanel flpActions;
        private System.Windows.Forms.Button btnAir;
        private System.Windows.Forms.Button btnOff;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblOnAir;
    }
}
