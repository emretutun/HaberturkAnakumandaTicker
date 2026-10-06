namespace HaberturkAnakumandaTicker.UI
{
    partial class MessageCrudControl
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
            this.flpToolbar = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnSendSelected = new System.Windows.Forms.Button();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.lblMode = new System.Windows.Forms.Label();
            this.tlpEditor = new System.Windows.Forms.TableLayoutPanel();
            this.lblSort = new System.Windows.Forms.Label();
            this.numSort = new System.Windows.Forms.NumericUpDown();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblText1 = new System.Windows.Forms.Label();
            this.txtText1 = new System.Windows.Forms.TextBox();
            this.lblText2 = new System.Windows.Forms.Label();
            this.txtText2 = new System.Windows.Forms.TextBox();
            this.lblBumper = new System.Windows.Forms.Label();
            this.cmbBumper = new System.Windows.Forms.ComboBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colText1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colText2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBumper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flpToolbar.SuspendLayout();
            this.tlpEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // flpToolbar
            // 
            this.flpToolbar.AutoSize = true;
            this.flpToolbar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpToolbar.Controls.Add(this.btnRefresh);
            this.flpToolbar.Controls.Add(this.btnNew);
            this.flpToolbar.Controls.Add(this.btnSave);
            this.flpToolbar.Controls.Add(this.btnDelete);
            this.flpToolbar.Controls.Add(this.btnUp);
            this.flpToolbar.Controls.Add(this.btnDown);
            this.flpToolbar.Controls.Add(this.btnSendSelected);
            this.flpToolbar.Controls.Add(this.lblFilter);
            this.flpToolbar.Controls.Add(this.cmbFilter);
            this.flpToolbar.Controls.Add(this.lblMode);
            this.flpToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpToolbar.Location = new System.Drawing.Point(0, 0);
            this.flpToolbar.Name = "flpToolbar";
            this.flpToolbar.Padding = new System.Windows.Forms.Padding(3);
            this.flpToolbar.Size = new System.Drawing.Size(900, 39);
            this.flpToolbar.TabIndex = 0;
            this.flpToolbar.WrapContents = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.Location = new System.Drawing.Point(6, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 27);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Yenile";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNew
            // 
            this.btnNew.AutoSize = true;
            this.btnNew.Location = new System.Drawing.Point(87, 6);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 27);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "Yeni";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.Location = new System.Drawing.Point(168, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 27);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.Location = new System.Drawing.Point(249, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 27);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUp
            // 
            this.btnUp.AutoSize = true;
            this.btnUp.Location = new System.Drawing.Point(330, 6);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 27);
            this.btnUp.TabIndex = 4;
            this.btnUp.Text = "▲ Yukarı";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.AutoSize = true;
            this.btnDown.Location = new System.Drawing.Point(411, 6);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(75, 27);
            this.btnDown.TabIndex = 5;
            this.btnDown.Text = "▼ Aşağı";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            //
            // btnSendSelected
            //
            this.btnSendSelected.AutoSize = true;
            this.btnSendSelected.Location = new System.Drawing.Point(492, 6);
            this.btnSendSelected.Margin = new System.Windows.Forms.Padding(13, 3, 3, 3);
            this.btnSendSelected.Name = "btnSendSelected";
            this.btnSendSelected.Size = new System.Drawing.Size(140, 27);
            this.btnSendSelected.TabIndex = 9;
            this.btnSendSelected.Text = "Seçiliyi Yayına Gönder";
            this.btnSendSelected.UseVisualStyleBackColor = true;
            this.btnSendSelected.Click += new System.EventHandler(this.btnSendSelected_Click);
            // 
            // lblFilter
            // 
            this.lblFilter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(502, 12);
            this.lblFilter.Margin = new System.Windows.Forms.Padding(13, 0, 3, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(36, 15);
            this.lblFilter.TabIndex = 6;
            this.lblFilter.Text = "Filtre:";
            // 
            // cmbFilter
            // 
            this.cmbFilter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Location = new System.Drawing.Point(544, 9);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(160, 23);
            this.cmbFilter.TabIndex = 7;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            // 
            // lblMode
            // 
            this.lblMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMode.AutoSize = true;
            this.lblMode.ForeColor = System.Drawing.Color.DimGray;
            this.lblMode.Location = new System.Drawing.Point(720, 12);
            this.lblMode.Margin = new System.Windows.Forms.Padding(13, 0, 3, 0);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(57, 15);
            this.lblMode.TabIndex = 8;
            this.lblMode.Text = "Yeni kayıt";
            // 
            // tlpEditor
            // 
            this.tlpEditor.AutoSize = true;
            this.tlpEditor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpEditor.ColumnCount = 4;
            this.tlpEditor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpEditor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEditor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpEditor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEditor.Controls.Add(this.lblSort, 0, 0);
            this.tlpEditor.Controls.Add(this.numSort, 1, 0);
            this.tlpEditor.Controls.Add(this.chkActive, 3, 0);
            this.tlpEditor.Controls.Add(this.lblCategory, 0, 1);
            this.tlpEditor.Controls.Add(this.cmbCategory, 1, 1);
            this.tlpEditor.Controls.Add(this.lblText1, 0, 2);
            this.tlpEditor.Controls.Add(this.txtText1, 1, 2);
            this.tlpEditor.Controls.Add(this.lblText2, 0, 3);
            this.tlpEditor.Controls.Add(this.txtText2, 1, 3);
            this.tlpEditor.Controls.Add(this.lblBumper, 0, 4);
            this.tlpEditor.Controls.Add(this.cmbBumper, 1, 4);
            this.tlpEditor.Controls.Add(this.lblFrom, 0, 5);
            this.tlpEditor.Controls.Add(this.dtpFrom, 1, 5);
            this.tlpEditor.Controls.Add(this.lblTo, 2, 5);
            this.tlpEditor.Controls.Add(this.dtpTo, 3, 5);
            this.tlpEditor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpEditor.Location = new System.Drawing.Point(0, 368);
            this.tlpEditor.Name = "tlpEditor";
            this.tlpEditor.Padding = new System.Windows.Forms.Padding(6);
            this.tlpEditor.RowCount = 6;
            this.tlpEditor.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEditor.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEditor.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEditor.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEditor.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEditor.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEditor.Size = new System.Drawing.Size(900, 182);
            this.tlpEditor.TabIndex = 1;
            // 
            // lblSort
            // 
            this.lblSort.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSort.AutoSize = true;
            this.lblSort.Location = new System.Drawing.Point(9, 13);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(29, 15);
            this.lblSort.TabIndex = 0;
            this.lblSort.Text = "Sıra:";
            // 
            // numSort
            // 
            this.numSort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numSort.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSort.Location = new System.Drawing.Point(75, 9);
            this.numSort.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numSort.Name = "numSort";
            this.numSort.Size = new System.Drawing.Size(386, 23);
            this.numSort.TabIndex = 1;
            // 
            // chkActive
            // 
            this.chkActive.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(505, 11);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(101, 19);
            this.chkActive.TabIndex = 2;
            this.chkActive.Text = "Yayında (aktif)";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // lblCategory
            // 
            this.lblCategory.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(9, 41);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(54, 15);
            this.lblCategory.TabIndex = 3;
            this.lblCategory.Text = "Kategori:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(75, 38);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(386, 23);
            this.cmbCategory.TabIndex = 4;
            // 
            // lblText1
            // 
            this.lblText1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblText1.AutoSize = true;
            this.lblText1.Location = new System.Drawing.Point(9, 69);
            this.lblText1.Name = "lblText1";
            this.lblText1.Size = new System.Drawing.Size(41, 15);
            this.lblText1.TabIndex = 5;
            this.lblText1.Text = "Metin:";
            // 
            // txtText1
            // 
            this.tlpEditor.SetColumnSpan(this.txtText1, 3);
            this.txtText1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtText1.Location = new System.Drawing.Point(75, 65);
            this.txtText1.MaxLength = 500;
            this.txtText1.Name = "txtText1";
            this.txtText1.Size = new System.Drawing.Size(816, 23);
            this.txtText1.TabIndex = 6;
            // 
            // lblText2
            // 
            this.lblText2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblText2.AutoSize = true;
            this.lblText2.Location = new System.Drawing.Point(9, 98);
            this.lblText2.Name = "lblText2";
            this.lblText2.Size = new System.Drawing.Size(51, 15);
            this.lblText2.TabIndex = 7;
            this.lblText2.Text = "Alt Satır:";
            // 
            // txtText2
            // 
            this.tlpEditor.SetColumnSpan(this.txtText2, 3);
            this.txtText2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtText2.Location = new System.Drawing.Point(75, 94);
            this.txtText2.MaxLength = 500;
            this.txtText2.Name = "txtText2";
            this.txtText2.Size = new System.Drawing.Size(816, 23);
            this.txtText2.TabIndex = 8;
            // 
            // lblBumper
            // 
            this.lblBumper.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBumper.AutoSize = true;
            this.lblBumper.Location = new System.Drawing.Point(9, 126);
            this.lblBumper.Name = "lblBumper";
            this.lblBumper.Size = new System.Drawing.Size(52, 15);
            this.lblBumper.TabIndex = 9;
            this.lblBumper.Text = "Bumper:";
            // 
            // cmbBumper
            // 
            this.cmbBumper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbBumper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBumper.FormattingEnabled = true;
            this.cmbBumper.Items.AddRange(new object[] {
            "Yok (0)",
            "Sessiz (1)",
            "Sesli (2)"});
            this.cmbBumper.Location = new System.Drawing.Point(75, 123);
            this.cmbBumper.Name = "cmbBumper";
            this.cmbBumper.Size = new System.Drawing.Size(386, 23);
            this.cmbBumper.TabIndex = 10;
            // 
            // lblFrom
            // 
            this.lblFrom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(9, 154);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(60, 15);
            this.lblFrom.TabIndex = 11;
            this.lblFrom.Text = "Başlangıç:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Checked = false;
            this.dtpFrom.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(75, 150);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.ShowCheckBox = true;
            this.dtpFrom.Size = new System.Drawing.Size(386, 23);
            this.dtpFrom.TabIndex = 12;
            // 
            // lblTo
            // 
            this.lblTo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(467, 154);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(32, 15);
            this.lblTo.TabIndex = 13;
            this.lblTo.Text = "Bitiş:";
            // 
            // dtpTo
            // 
            this.dtpTo.Checked = false;
            this.dtpTo.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(505, 150);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.ShowCheckBox = true;
            this.dtpTo.Size = new System.Drawing.Size(386, 23);
            this.dtpTo.TabIndex = 14;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvItems.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colCategory,
            this.colText1,
            this.colText2,
            this.colBumper,
            this.colSort,
            this.colActive,
            this.colFrom,
            this.colTo});
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(0, 39);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(900, 329);
            this.dgvItems.TabIndex = 2;
            this.dgvItems.SelectionChanged += new System.EventHandler(this.dgvItems_SelectionChanged);
            // 
            // colId
            // 
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colId.Width = 23;
            // 
            // colCategory
            // 
            this.colCategory.HeaderText = "Kategori";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCategory.Width = 57;
            // 
            // colText1
            // 
            this.colText1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colText1.HeaderText = "Metin";
            this.colText1.Name = "colText1";
            this.colText1.ReadOnly = true;
            this.colText1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colText2
            // 
            this.colText2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colText2.HeaderText = "Alt Satır";
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
            this.colBumper.Width = 55;
            // 
            // colSort
            // 
            this.colSort.HeaderText = "Sıra";
            this.colSort.Name = "colSort";
            this.colSort.ReadOnly = true;
            this.colSort.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSort.Width = 32;
            // 
            // colActive
            // 
            this.colActive.HeaderText = "Aktif";
            this.colActive.Name = "colActive";
            this.colActive.ReadOnly = true;
            this.colActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colActive.Width = 38;
            // 
            // colFrom
            // 
            this.colFrom.HeaderText = "Başlangıç";
            this.colFrom.Name = "colFrom";
            this.colFrom.ReadOnly = true;
            this.colFrom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colFrom.Width = 63;
            // 
            // colTo
            // 
            this.colTo.HeaderText = "Bitiş";
            this.colTo.Name = "colTo";
            this.colTo.ReadOnly = true;
            this.colTo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTo.Width = 35;
            // 
            // MessageCrudControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.tlpEditor);
            this.Controls.Add(this.flpToolbar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "MessageCrudControl";
            this.Size = new System.Drawing.Size(900, 550);
            this.flpToolbar.ResumeLayout(false);
            this.flpToolbar.PerformLayout();
            this.tlpEditor.ResumeLayout(false);
            this.tlpEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpToolbar;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnSendSelected;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.TableLayoutPanel tlpEditor;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.NumericUpDown numSort;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblText1;
        private System.Windows.Forms.TextBox txtText1;
        private System.Windows.Forms.Label lblText2;
        private System.Windows.Forms.TextBox txtText2;
        private System.Windows.Forms.Label lblBumper;
        private System.Windows.Forms.ComboBox cmbBumper;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colText1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colText2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBumper;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSort;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTo;
    }
}
