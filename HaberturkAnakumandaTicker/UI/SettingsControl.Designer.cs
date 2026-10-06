namespace HaberturkAnakumandaTicker.UI
{
    partial class SettingsControl
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
            this.btnSave = new System.Windows.Forms.Button();
            this.lblNote = new System.Windows.Forms.Label();
            this.dgvSettings = new System.Windows.Forms.DataGridView();
            this.colKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colViz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flpToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSettings)).BeginInit();
            this.SuspendLayout();
            //
            // flpToolbar
            //
            this.flpToolbar.AutoSize = true;
            this.flpToolbar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpToolbar.Controls.Add(this.btnRefresh);
            this.flpToolbar.Controls.Add(this.btnSave);
            this.flpToolbar.Controls.Add(this.lblNote);
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
            // btnSave
            //
            this.btnSave.AutoSize = true;
            this.btnSave.Location = new System.Drawing.Point(87, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(137, 27);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Değişiklikleri Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // lblNote
            //
            this.lblNote.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNote.AutoSize = true;
            this.lblNote.ForeColor = System.Drawing.Color.DimGray;
            this.lblNote.Location = new System.Drawing.Point(240, 12);
            this.lblNote.Margin = new System.Windows.Forms.Padding(13, 0, 3, 0);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(420, 15);
            this.lblNote.TabIndex = 2;
            this.lblNote.Text = "Not: Bu ekran sadece DB\'ye yazar. viz_host / viz_port kilitli (127.0.0.1:6100).";
            //
            // dgvSettings
            //
            this.dgvSettings.AllowUserToAddRows = false;
            this.dgvSettings.AllowUserToDeleteRows = false;
            this.dgvSettings.AllowUserToResizeRows = false;
            this.dgvSettings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvSettings.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSettings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colKey,
            this.colValue,
            this.colViz,
            this.colDesc});
            this.dgvSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSettings.Location = new System.Drawing.Point(0, 39);
            this.dgvSettings.MultiSelect = false;
            this.dgvSettings.Name = "dgvSettings";
            this.dgvSettings.RowHeadersVisible = false;
            this.dgvSettings.Size = new System.Drawing.Size(900, 511);
            this.dgvSettings.TabIndex = 1;
            //
            // colKey
            //
            this.colKey.HeaderText = "Anahtar";
            this.colKey.Name = "colKey";
            this.colKey.ReadOnly = true;
            this.colKey.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // colValue
            //
            this.colValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colValue.HeaderText = "Değer";
            this.colValue.Name = "colValue";
            this.colValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colValue.Width = 200;
            //
            // colViz
            //
            this.colViz.HeaderText = "Viz Container";
            this.colViz.Name = "colViz";
            this.colViz.ReadOnly = true;
            this.colViz.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // colDesc
            //
            this.colDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDesc.HeaderText = "Açıklama";
            this.colDesc.Name = "colDesc";
            this.colDesc.ReadOnly = true;
            this.colDesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // SettingsControl
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvSettings);
            this.Controls.Add(this.flpToolbar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(900, 550);
            this.flpToolbar.ResumeLayout(false);
            this.flpToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSettings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpToolbar;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.DataGridView dgvSettings;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colViz;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesc;
    }
}
