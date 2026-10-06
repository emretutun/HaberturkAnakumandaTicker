using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HaberturkAnakumandaTicker.Data;
using HaberturkAnakumandaTicker.Models;

namespace HaberturkAnakumandaTicker.UI
{
    /// <summary>economy_items CRUD (Tobleron).</summary>
    public partial class EconomyCrudControl : UserControl, IReloadable
    {
        private readonly EconomyItemRepository _repo = new EconomyItemRepository();
        private List<EconomyItem> _items = new List<EconomyItem>();
        private int _editingId;
        private bool _filling;

        public EconomyCrudControl()
        {
            InitializeComponent();
        }

        // ------------------------------------------------------------------ olaylar

        private void btnRefresh_Click(object sender, EventArgs e) { ReloadData(); }
        private void btnNew_Click(object sender, EventArgs e) { NewRecord(); }
        private void btnSave_Click(object sender, EventArgs e) { Save(); }
        private void btnDelete_Click(object sender, EventArgs e) { DeleteSelected(); }

        private void chkDefaultDecimal_CheckedChanged(object sender, EventArgs e)
        {
            numDecimal.Enabled = !chkDefaultDecimal.Checked;
        }

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
            foreach (var item in _items)
            {
                var r = dgvItems.Rows[dgvItems.Rows.Add(item.Id, item.DisplayName, item.ShmBaseKey,
                    item.DecimalPlaces.HasValue ? item.DecimalPlaces.Value.ToString() : "(2)",
                    item.SortOrder, item.IsActive ? "Evet" : "Hayır")];
                r.Tag = item;
            }
            dgvItems.ClearSelection();
            _filling = false;

            var sel = dgvItems.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => ((EconomyItem)r.Tag).Id == keepId);
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

        private EconomyItem Selected
        {
            get { return dgvItems.SelectedRows.Count > 0 ? dgvItems.SelectedRows[0].Tag as EconomyItem : null; }
        }

        private void LoadEditor()
        {
            var item = Selected;
            if (item == null) return;
            _editingId = item.Id;
            lblMode.Text = "Düzenleniyor: #" + item.Id;
            txtName.Text = item.DisplayName;
            txtShm.Text = item.ShmBaseKey;
            chkDefaultDecimal.Checked = !item.DecimalPlaces.HasValue;
            numDecimal.Value = Math.Min(numDecimal.Maximum, item.DecimalPlaces ?? 2);
            numSort.Value = Math.Max(numSort.Minimum, Math.Min(numSort.Maximum, item.SortOrder));
            chkActive.Checked = item.IsActive;
        }

        private void NewRecord()
        {
            _editingId = 0;
            lblMode.Text = "Yeni kayıt";
            _filling = true;
            dgvItems.ClearSelection();
            _filling = false;
            txtName.Text = "";
            txtShm.Text = "";
            chkDefaultDecimal.Checked = false;
            numDecimal.Value = 2;
            numSort.Value = Math.Min(numSort.Maximum, _items.Count == 0 ? 1 : _items.Max(x => x.SortOrder) + 1);
            chkActive.Checked = true;
        }

        private void Save()
        {
            var item = new EconomyItem
            {
                Id = _editingId,
                DisplayName = txtName.Text.Trim(),
                ShmBaseKey = txtShm.Text.Trim(),
                DecimalPlaces = chkDefaultDecimal.Checked ? (byte?)null : (byte)numDecimal.Value,
                SortOrder = (int)numSort.Value,
                IsActive = chkActive.Checked
            };
            try
            {
                if (item.Id == 0) _repo.Insert(item);
                else _repo.Update(item);
                _editingId = item.Id;
                ReloadData();
            }
            catch (Exception ex)
            {
                Ui.Error(ex);
            }
        }

        private void DeleteSelected()
        {
            var item = Selected;
            if (item == null) return;
            if (!Ui.Confirm("'" + item.DisplayName + "' silinsin mi?")) return;
            try
            {
                _repo.Delete(item.Id);
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
