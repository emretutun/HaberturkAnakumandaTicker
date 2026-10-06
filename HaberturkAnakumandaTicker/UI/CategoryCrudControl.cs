using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HaberturkAnakumandaTicker.Data;
using HaberturkAnakumandaTicker.Models;

namespace HaberturkAnakumandaTicker.UI
{
    /// <summary>
    /// categories CRUD. Ayraç template listesi (cmbSeparator) sahnedeki
    /// ticker_templates altındaki ScrollerAction template'leri ile aynı olmalı.
    /// Listenin ilk öğesi "ayraç yok": DB'ye boş yazılır, o kategorinin haberleri kulakçıksız gider.
    /// </summary>
    public partial class CategoryCrudControl : UserControl, IReloadable
    {
        /// <summary>cmbSeparator'daki ilk öğe (index 0) = ayraç yok.</summary>
        private const int NoSeparatorIndex = 0;

        private readonly CategoryRepository _repo = new CategoryRepository();
        private List<Category> _items = new List<Category>();
        private int _editingId;
        private bool _filling;

        public CategoryCrudControl()
        {
            InitializeComponent();
        }

        // ------------------------------------------------------------------ olaylar

        private void btnRefresh_Click(object sender, EventArgs e) { ReloadData(); }
        private void btnNew_Click(object sender, EventArgs e) { NewRecord(); }
        private void btnSave_Click(object sender, EventArgs e) { Save(); }
        private void btnDelete_Click(object sender, EventArgs e) { DeleteSelected(); }

        private void dgvItems_SelectionChanged(object sender, EventArgs e)
        {
            if (!_filling) LoadEditor();
        }

        // ------------------------------------------------------------------ veri

        public void ReloadData()
        {
            int keepId = _editingId;
            try
            {
                _items = _repo.GetAll();
            }
            catch (Exception ex)
            {
                Ui.Error(ex);
                return;
            }

            _filling = true;
            dgvItems.Rows.Clear();
            foreach (var c in _items)
            {
                string sep = string.IsNullOrEmpty(c.SeparatorTemplate) ? "(yok)" : c.SeparatorTemplate;
                var r = dgvItems.Rows[dgvItems.Rows.Add(c.Id, c.Code, c.Title, sep, c.SortOrder, c.IsActive ? "Evet" : "Hayır")];
                r.Tag = c;
            }
            dgvItems.ClearSelection();
            _filling = false;

            var sel = dgvItems.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => ((Category)r.Tag).Id == keepId);
            if (sel != null)
            {
                sel.Selected = true;
                dgvItems.CurrentCell = sel.Cells[colId.Index];
                LoadEditor();
            }
            else
            {
                NewRecord();
            }
        }

        private Category Selected
        {
            get { return dgvItems.SelectedRows.Count > 0 ? dgvItems.SelectedRows[0].Tag as Category : null; }
        }

        private void LoadEditor()
        {
            var c = Selected;
            if (c == null) return;
            _editingId = c.Id;
            lblMode.Text = "Düzenleniyor: #" + c.Id;
            txtCode.Text = c.Code;
            txtTitle.Text = c.Title;
            if (string.IsNullOrEmpty(c.SeparatorTemplate))
                cmbSeparator.SelectedIndex = NoSeparatorIndex;
            else
                cmbSeparator.SelectedItem = c.SeparatorTemplate;
            numSort.Value = Math.Max(numSort.Minimum, Math.Min(numSort.Maximum, c.SortOrder));
            chkActive.Checked = c.IsActive;
        }

        private void NewRecord()
        {
            _editingId = 0;
            lblMode.Text = "Yeni kayıt";
            _filling = true;
            dgvItems.ClearSelection();
            _filling = false;
            txtCode.Text = "";
            txtTitle.Text = "";
            cmbSeparator.SelectedIndex = -1;
            numSort.Value = Math.Min(numSort.Maximum, _items.Count == 0 ? 1 : _items.Max(c => c.SortOrder) + 1);
            chkActive.Checked = true;
        }

        private void Save()
        {
            if (txtCode.Text.Trim() == "" || txtTitle.Text.Trim() == "" || cmbSeparator.SelectedItem == null)
            {
                Ui.Info("Kod, başlık ve ayraç template zorunlu.");
                return;
            }
            var c = new Category
            {
                Id = _editingId,
                Code = txtCode.Text.Trim(),
                Title = txtTitle.Text.Trim(),
                SeparatorTemplate = cmbSeparator.SelectedIndex == NoSeparatorIndex ? "" : (string)cmbSeparator.SelectedItem,
                SortOrder = (int)numSort.Value,
                IsActive = chkActive.Checked
            };
            try
            {
                if (c.Id == 0) _repo.Insert(c);
                else _repo.Update(c);
                _editingId = c.Id;
                ReloadData();
            }
            catch (Exception ex)
            {
                Ui.Error(ex);
            }
        }

        private void DeleteSelected()
        {
            var c = Selected;
            if (c == null) return;
            if (!Ui.Confirm("'" + c.Title + "' kategorisi silinsin mi?")) return;
            try
            {
                _repo.Delete(c.Id);
                _editingId = 0;
                ReloadData();
            }
            catch (Exception ex)
            {
                Ui.Error(ex);
            }
        }
    }
}
