namespace HaberturkAnakumandaTicker.UI
{
    partial class EconomyCrudControl
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblShm = new System.Windows.Forms.Label();
            this.txtShm = new System.Windows.Forms.TextBox();
            this.lblDecimal = new System.Windows.Forms.Label();
            this.numDecimal = new System.Windows.Forms.NumericUpDown();
            this.chkDefaultDecimal = new System.Windows.Forms.CheckBox();
            this.lblSort = new System.Windows.Forms.Label();
            this.numSort = new System.Windows.Forms.NumericUpDown();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDecimal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flpToolbar.SuspendLayout();
            this.tlpEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDecimal)).BeginInit();
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
            this.tlpEditor.Controls.Add(this.lblName, 0, 0);
            this.tlpEditor.Controls.Add(this.txtName, 1, 0);
            this.tlpEditor.Controls.Add(this.lblShm, 2, 0);
            this.tlpEditor.Controls.Add(this.txtShm, 3, 0);
            this.tlpEditor.Controls.Add(this.lblDecimal, 0, 1);
            this.tlpEditor.Controls.Add(this.numDecimal, 1, 1);
            this.tlpEditor.Controls.Add(this.chkDefaultDecimal, 3, 1);
            this.tlpEditor.Controls.Add(this.lblSort, 0, 2);
            this.tlpEditor.Controls.Add(this.numSort, 1, 2);
            this.tlpEditor.Controls.Add(this.chkActive, 3, 2);
            this.tlpEditor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpEditor.Location = new System.Drawing.Point(0, 455);
            this.tlpEditor.Name = "tlpEditor";
            this.tlpEditor.Padding = new System.Windows.Forms.Padding(6);
            this.tlpEditor.RowCount = 3;
            this.tlpEditor.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEditor.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEditor.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEditor.Size = new System.Drawing.Size(900, 95);
            this.tlpEditor.TabIndex = 1;
            //
            // lblName
            //
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(72, 15);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Görünen Ad:";
            //
            // txtName
            //
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Location = new System.Drawing.Point(87, 9);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(334, 23);
            this.txtName.TabIndex = 1;
            //
            // lblShm
            //
            this.lblShm.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblShm.AutoSize = true;
            this.lblShm.Location = new System.Drawing.Point(427, 13);
            this.lblShm.Name = "lblShm";
            this.lblShm.Size = new System.Drawing.Size(120, 15);
            this.lblShm.TabIndex = 2;
            this.lblShm.Text = "SHM (/economy/LOGO):";
            //
            // txtShm
            //
            this.txtShm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtShm.Location = new System.Drawing.Point(553, 9);
            this.txtShm.MaxLength = 100;
            this.txtShm.Name = "txtShm";
            this.txtShm.Size = new System.Drawing.Size(338, 23);
            this.txtShm.TabIndex = 3;
            //
            // lblDecimal
            //
            this.lblDecimal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDecimal.AutoSize = true;
            this.lblDecimal.Location = new System.Drawing.Point(9, 42);
            this.lblDecimal.Name = "lblDecimal";
            this.lblDecimal.Size = new System.Drawing.Size(51, 15);
            this.lblDecimal.TabIndex = 4;
            this.lblDecimal.Text = "Ondalık:";
            //
            // numDecimal
            //
            this.numDecimal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numDecimal.Location = new System.Drawing.Point(87, 38);
            this.numDecimal.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numDecimal.Name = "numDecimal";
            this.numDecimal.Size = new System.Drawing.Size(334, 23);
            this.numDecimal.TabIndex = 5;
            this.numDecimal.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            //
            // chkDefaultDecimal
            //
            this.chkDefaultDecimal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkDefaultDecimal.AutoSize = true;
            this.chkDefaultDecimal.Location = new System.Drawing.Point(553, 40);
            this.chkDefaultDecimal.Name = "chkDefaultDecimal";
            this.chkDefaultDecimal.Size = new System.Drawing.Size(101, 19);
            this.chkDefaultDecimal.TabIndex = 6;
            this.chkDefaultDecimal.Text = "Varsayılan (2)";
            this.chkDefaultDecimal.UseVisualStyleBackColor = true;
            this.chkDefaultDecimal.CheckedChanged += new System.EventHandler(this.chkDefaultDecimal_CheckedChanged);
            //
            // lblSort
            //
            this.lblSort.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSort.AutoSize = true;
            this.lblSort.Location = new System.Drawing.Point(9, 71);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(30, 15);
            this.lblSort.TabIndex = 7;
            this.lblSort.Text = "Sıra:";
            //
            // numSort
            //
            this.numSort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numSort.Location = new System.Drawing.Point(87, 67);
            this.numSort.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSort.Name = "numSort";
            this.numSort.Size = new System.Drawing.Size(334, 23);
            this.numSort.TabIndex = 8;
            //
            // chkActive
            //
            this.chkActive.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(553, 69);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(51, 19);
            this.chkActive.TabIndex = 9;
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
            this.colName,
            this.colShm,
            this.colDecimal,
            this.colSort,
            this.colActive});
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(0, 39);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(900, 416);
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
            // colName
            //
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.HeaderText = "Görünen Ad";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // colShm
            //
            this.colShm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colShm.HeaderText = "SHM Anahtarı";
            this.colShm.Name = "colShm";
            this.colShm.ReadOnly = true;
            this.colShm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // colDecimal
            //
            this.colDecimal.HeaderText = "Ondalık";
            this.colDecimal.Name = "colDecimal";
            this.colDecimal.ReadOnly = true;
            this.colDecimal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            // EconomyCrudControl
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.tlpEditor);
            this.Controls.Add(this.flpToolbar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "EconomyCrudControl";
            this.Size = new System.Drawing.Size(900, 550);
            this.flpToolbar.ResumeLayout(false);
            this.flpToolbar.PerformLayout();
            this.tlpEditor.ResumeLayout(false);
            this.tlpEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDecimal)).EndInit();
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
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblShm;
        private System.Windows.Forms.TextBox txtShm;
        private System.Windows.Forms.Label lblDecimal;
        private System.Windows.Forms.NumericUpDown numDecimal;
        private System.Windows.Forms.CheckBox chkDefaultDecimal;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.NumericUpDown numSort;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShm;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDecimal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSort;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActive;
    }
}
