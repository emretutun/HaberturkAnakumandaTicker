namespace HaberturkAnakumandaTicker.UI
{
    partial class CategoryCrudControl
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
            this.lblMode = new System.Windows.Forms.Label();
            this.tlpEditor = new System.Windows.Forms.TableLayoutPanel();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblSeparator = new System.Windows.Forms.Label();
            this.cmbSeparator = new System.Windows.Forms.ComboBox();
            this.lblSort = new System.Windows.Forms.Label();
            this.numSort = new System.Windows.Forms.NumericUpDown();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeparator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            // lblMode
            //
            this.lblMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMode.AutoSize = true;
            this.lblMode.ForeColor = System.Drawing.Color.DimGray;
            this.lblMode.Location = new System.Drawing.Point(340, 12);
            this.lblMode.Margin = new System.Windows.Forms.Padding(13, 0, 3, 0);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(60, 15);
            this.lblMode.TabIndex = 4;
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
            this.tlpEditor.Controls.Add(this.lblCode, 0, 0);
            this.tlpEditor.Controls.Add(this.txtCode, 1, 0);
            this.tlpEditor.Controls.Add(this.lblTitle, 2, 0);
            this.tlpEditor.Controls.Add(this.txtTitle, 3, 0);
            this.tlpEditor.Controls.Add(this.lblSeparator, 0, 1);
            this.tlpEditor.Controls.Add(this.cmbSeparator, 1, 1);
            this.tlpEditor.Controls.Add(this.lblSort, 2, 1);
            this.tlpEditor.Controls.Add(this.numSort, 3, 1);
            this.tlpEditor.Controls.Add(this.chkActive, 1, 2);
            this.tlpEditor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpEditor.Location = new System.Drawing.Point(0, 459);
            this.tlpEditor.Name = "tlpEditor";
            this.tlpEditor.Padding = new System.Windows.Forms.Padding(6);
            this.tlpEditor.RowCount = 3;
            this.tlpEditor.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEditor.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEditor.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEditor.Size = new System.Drawing.Size(900, 91);
            this.tlpEditor.TabIndex = 1;
            //
            // lblCode
            //
            this.lblCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(9, 13);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(31, 15);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Kod:";
            //
            // txtCode
            //
            this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCode.Location = new System.Drawing.Point(110, 9);
            this.txtCode.MaxLength = 20;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(345, 23);
            this.txtCode.TabIndex = 1;
            //
            // lblTitle
            //
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(461, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(43, 15);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Başlık:";
            //
            // txtTitle
            //
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTitle.Location = new System.Drawing.Point(510, 9);
            this.txtTitle.MaxLength = 50;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(381, 23);
            this.txtTitle.TabIndex = 3;
            //
            // lblSeparator
            //
            this.lblSeparator.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSeparator.AutoSize = true;
            this.lblSeparator.Location = new System.Drawing.Point(9, 42);
            this.lblSeparator.Name = "lblSeparator";
            this.lblSeparator.Size = new System.Drawing.Size(95, 15);
            this.lblSeparator.TabIndex = 4;
            this.lblSeparator.Text = "Ayraç Template:";
            //
            // cmbSeparator
            //
            this.cmbSeparator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSeparator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSeparator.FormattingEnabled = true;
            this.cmbSeparator.Items.AddRange(new object[] {
            "(ayraç yok - kulakçıksız)",
            "LCL_DUNYA_IN",
            "LCL_EKONOMI_IN",
            "LCL_GUNDEM_IN",
            "LCL_HAVAYOL_IN",
            "LCL_SPOR_IN"});
            this.cmbSeparator.Location = new System.Drawing.Point(110, 38);
            this.cmbSeparator.Name = "cmbSeparator";
            this.cmbSeparator.Size = new System.Drawing.Size(345, 23);
            this.cmbSeparator.TabIndex = 5;
            //
            // lblSort
            //
            this.lblSort.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSort.AutoSize = true;
            this.lblSort.Location = new System.Drawing.Point(461, 42);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(30, 15);
            this.lblSort.TabIndex = 6;
            this.lblSort.Text = "Sıra:";
            //
            // numSort
            //
            this.numSort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numSort.Location = new System.Drawing.Point(510, 38);
            this.numSort.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSort.Name = "numSort";
            this.numSort.Size = new System.Drawing.Size(381, 23);
            this.numSort.TabIndex = 7;
            //
            // chkActive
            //
            this.chkActive.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(110, 67);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(51, 19);
            this.chkActive.TabIndex = 8;
            this.chkActive.Text = "Aktif";
            this.chkActive.UseVisualStyleBackColor = true;
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
            this.colCode,
            this.colTitle,
            this.colSeparator,
            this.colSort,
            this.colActive});
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(0, 39);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(900, 420);
            this.dgvItems.TabIndex = 2;
            this.dgvItems.SelectionChanged += new System.EventHandler(this.dgvItems_SelectionChanged);
            //
            // colId
            //
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // colCode
            //
            this.colCode.HeaderText = "Kod";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            this.colCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // colTitle
            //
            this.colTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTitle.HeaderText = "Başlık";
            this.colTitle.Name = "colTitle";
            this.colTitle.ReadOnly = true;
            this.colTitle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // colSeparator
            //
            this.colSeparator.HeaderText = "Ayraç Template";
            this.colSeparator.Name = "colSeparator";
            this.colSeparator.ReadOnly = true;
            this.colSeparator.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // colSort
            //
            this.colSort.HeaderText = "Sıra";
            this.colSort.Name = "colSort";
            this.colSort.ReadOnly = true;
            this.colSort.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // colActive
            //
            this.colActive.HeaderText = "Aktif";
            this.colActive.Name = "colActive";
            this.colActive.ReadOnly = true;
            this.colActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // CategoryCrudControl
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.tlpEditor);
            this.Controls.Add(this.flpToolbar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "CategoryCrudControl";
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
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.TableLayoutPanel tlpEditor;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblSeparator;
        private System.Windows.Forms.ComboBox cmbSeparator;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.NumericUpDown numSort;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeparator;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSort;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActive;
    }
}
