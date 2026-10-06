using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HaberturkAnakumandaTicker.Data;
using HaberturkAnakumandaTicker.Models;
using HaberturkAnakumandaTicker.Viz;

namespace HaberturkAnakumandaTicker.UI
{
    /// <summary>
    /// ticker_messages CRUD. Tek kontrol tüm tipler için kullanılıyor; tip Designer'daki
    /// MessageType özelliğinden seçilir. MAIN'de kategori, SD_KJ'de alt satır + bumper alanları görünür.
    /// </summary>
    public partial class MessageCrudControl : UserControl, IReloadable
    {
        private readonly TickerMessageRepository _repo = new TickerMessageRepository();
        private readonly CategoryRepository _catRepo = new CategoryRepository();

        private MessageType _messageType = MessageType.MAIN;
        private List<Category> _categories = new List<Category>();
        private List<TickerMessage> _all = new List<TickerMessage>();
        private List<TickerMessage> _items = new List<TickerMessage>();   // filtrelenmiş, gridde görünen
        private int _editingId;                                           // 0 = yeni kayıt
        private bool _filling;

        /// <summary>"Seçiliyi Yayına Gönder" için (MainForm verir). Yoksa buton uyarı verir.</summary>
        private VizTickerManager _ticker;

        public MessageCrudControl()
        {
            InitializeComponent();
            ApplyMessageType();
        }

        public void InitializeTicker(VizTickerManager ticker)
        {
            _ticker = ticker;
        }

        /// <summary>Bu kontrolün yönettiği mesaj tipi (Designer'da Properties penceresinden seçilir).</summary>
        [Category("Ticker")]
        [DefaultValue(MessageType.MAIN)]
        [Description("Bu kontrolün yönettiği ticker_messages tipi.")]
        public MessageType MessageType
        {
            get { return _messageType; }
            set
            {
                _messageType = value;
                ApplyMessageType();
            }
        }

        private bool HasCategory { get { return _messageType == MessageType.MAIN; } }
        private bool IsKj { get { return _messageType == MessageType.SD_KJ; } }

        /// <summary>Tipe göre alanları gösterir/gizler.</summary>
        private void ApplyMessageType()
        {
            lblFilter.Visible = cmbFilter.Visible = HasCategory;
            lblCategory.Visible = cmbCategory.Visible = HasCategory;
            colCategory.Visible = HasCategory;

            lblText2.Visible = txtText2.Visible = IsKj;
            lblBumper.Visible = cmbBumper.Visible = IsKj;
            colText2.Visible = colBumper.Visible = IsKj;

            // Ana ticker "Yayın Listesi" sekmesinden gönderiliyor; diğer tiplerde tek mesaj gönderilir
            btnSendSelected.Visible = !HasCategory;

            lblText1.Text = IsKj ? "Üst Satır:" : "Metin:";
            colText1.HeaderText = IsKj ? "Üst Satır" : "Metin";
        }

        // ------------------------------------------------------------------ olaylar

        private void btnRefresh_Click(object sender, EventArgs e) { ReloadData(); }
        private void btnNew_Click(object sender, EventArgs e) { NewRecord(); }
        private void btnSave_Click(object sender, EventArgs e) { Save(); }
        private void btnDelete_Click(object sender, EventArgs e) { DeleteSelected(); }
        private void btnUp_Click(object sender, EventArgs e) { MoveSelected(-1); }
        private void btnDown_Click(object sender, EventArgs e) { MoveSelected(+1); }

        /// <summary>
        /// Listede seçili (kayıtlı) mesajı tek başına ilgili ticker'a gönderir; önceki içerik silinir.
        /// Ekrana almak Kontrol sekmesindeki VER butonuyla yapılır.
        /// </summary>
        private void btnSendSelected_Click(object sender, EventArgs e)
        {
            var m = SelectedMessage;
            if (m == null)
            {
                Ui.Info("Önce listeden bir mesaj seçin.");
                return;
            }
            var def = SceneConfig.For(_messageType);
            if (def == null || !def.ElementSource.StartsWith("LCL_", StringComparison.Ordinal))
            {
                Ui.Info("Bu bandın Scroller kaynağı sahnede henüz LCL_ ile yeniden adlandırılmadı (" +
                        (def == null ? "?" : def.ElementSource) + "). Önce sahneyi ve SceneConfig'i güncelleyin.");
                return;
            }
            if (!m.IsPlayableAt(DateTime.Now) &&
                !Ui.Confirm("Bu mesaj pasif ya da geçerlilik tarihi dışında. Yine de gönderilsin mi?"))
                return;

            try
            {
                if (_ticker == null) throw new InvalidOperationException("VizTicker yöneticisi hazır değil.");
                if (!_ticker.IsConnected) _ticker.Connect();
                _ticker.ReplaceAll(def.ElementSource, TickerPlaylistBuilder.BuildSimple(_messageType, new[] { m }));
                lblMode.Text = "Yayına gönderildi: #" + m.Id + " (" + DateTime.Now.ToString("HH:mm:ss") + ")";
            }
            catch (Exception ex)
            {
                Ui.Error(ex);
            }
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_filling) ApplyFilter();
        }

        private void dgvItems_SelectionChanged(object sender, EventArgs e)
        {
            if (!_filling) LoadEditorFromSelection();
        }

        // ------------------------------------------------------------------ veri

        public void ReloadData()
        {
            int keepId = _editingId;
            try
            {
                if (HasCategory)
                {
                    _categories = _catRepo.GetAll();
                    FillCategoryCombos();
                }
                _all = _repo.GetByType(_messageType);
            }
            catch (Exception ex)
            {
                Ui.Error(ex);
                return;
            }
            ApplyFilter(keepId);
        }

        private void FillCategoryCombos()
        {
            _filling = true;
            var oldFilter = cmbFilter.SelectedItem as Category;
            cmbFilter.Items.Clear();
            cmbFilter.Items.Add("(Tümü)");
            cmbCategory.Items.Clear();
            foreach (var c in _categories)
            {
                cmbFilter.Items.Add(c);
                cmbCategory.Items.Add(c);
            }
            if (oldFilter != null)
                cmbFilter.SelectedItem = _categories.FirstOrDefault(c => c.Id == oldFilter.Id);
            if (cmbFilter.SelectedIndex < 0) cmbFilter.SelectedIndex = 0;
            _filling = false;
        }

        private Category FilterCategory
        {
            get { return HasCategory ? cmbFilter.SelectedItem as Category : null; }
        }

        private void ApplyFilter(int selectId = 0)
        {
            var f = FilterCategory;
            _items = f == null ? _all.ToList() : _all.Where(m => m.CategoryId == f.Id).ToList();
            FillGrid(selectId);
        }

        private void FillGrid(int selectId)
        {
            _filling = true;
            dgvItems.Rows.Clear();
            var catNames = _categories.ToDictionary(c => c.Id, c => c.Title);
            var now = DateTime.Now;
            foreach (var m in _items)
            {
                var r = dgvItems.Rows[dgvItems.Rows.Add()];
                r.Tag = m;
                r.Cells[colId.Index].Value = m.Id;
                r.Cells[colCategory.Index].Value = m.CategoryId.HasValue && catNames.ContainsKey(m.CategoryId.Value) ? catNames[m.CategoryId.Value] : "";
                r.Cells[colText1.Index].Value = m.Text1;
                r.Cells[colText2.Index].Value = m.Text2;
                r.Cells[colBumper.Index].Value = m.BumperType;
                r.Cells[colSort.Index].Value = m.SortOrder;
                r.Cells[colActive.Index].Value = m.IsActive ? "Evet" : "Hayır";
                r.Cells[colFrom.Index].Value = Ui.FormatDate(m.ValidFrom);
                r.Cells[colTo.Index].Value = Ui.FormatDate(m.ValidTo);
                if (!m.IsPlayableAt(now))
                    r.DefaultCellStyle.ForeColor = Color.Gray;   // yayına gitmeyecek
            }
            dgvItems.ClearSelection();
            _filling = false;

            var sel = dgvItems.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => ((TickerMessage)r.Tag).Id == selectId);
            if (sel != null)
            {
                sel.Selected = true;
                dgvItems.CurrentCell = sel.Cells[colId.Index];
                LoadEditorFromSelection();
            }
            else
            {
                NewRecord();
            }
        }

        private TickerMessage SelectedMessage
        {
            get { return dgvItems.SelectedRows.Count > 0 ? dgvItems.SelectedRows[0].Tag as TickerMessage : null; }
        }

        private void LoadEditorFromSelection()
        {
            var m = SelectedMessage;
            if (m == null) return;
            _editingId = m.Id;
            lblMode.Text = "Düzenleniyor: #" + m.Id;
            numSort.Value = Math.Max(numSort.Minimum, Math.Min(numSort.Maximum, m.SortOrder));
            chkActive.Checked = m.IsActive;
            if (HasCategory)
                cmbCategory.SelectedItem = _categories.FirstOrDefault(c => c.Id == m.CategoryId);
            txtText1.Text = m.Text1;
            txtText2.Text = m.Text2 ?? "";
            cmbBumper.SelectedIndex = (int)m.BumperType;
            Ui.SetDate(dtpFrom, m.ValidFrom);
            Ui.SetDate(dtpTo, m.ValidTo);
        }

        private void NewRecord()
        {
            _editingId = 0;
            lblMode.Text = "Yeni kayıt";
            _filling = true;
            dgvItems.ClearSelection();
            _filling = false;

            var f = FilterCategory;
            var sameGroup = _items.Where(m => f == null || m.CategoryId == f.Id).ToList();
            numSort.Value = Math.Min(numSort.Maximum, sameGroup.Count == 0 ? 10 : sameGroup.Max(m => m.SortOrder) + 10);
            chkActive.Checked = true;
            if (HasCategory)
                cmbCategory.SelectedItem = f ?? (_categories.Count > 0 ? _categories[0] : null);
            txtText1.Text = "";
            txtText2.Text = "";
            cmbBumper.SelectedIndex = 0;
            Ui.SetDate(dtpFrom, null);
            Ui.SetDate(dtpTo, null);
            txtText1.Focus();
        }

        private void Save()
        {
            var cat = cmbCategory.SelectedItem as Category;
            var m = new TickerMessage
            {
                Id = _editingId,
                MessageType = _messageType,
                CategoryId = HasCategory && cat != null ? cat.Id : (int?)null,
                Text1 = txtText1.Text.Trim(),
                Text2 = IsKj ? txtText2.Text.Trim() : null,
                BumperType = IsKj && cmbBumper.SelectedIndex >= 0 ? (BumperType)cmbBumper.SelectedIndex : BumperType.Yok,
                SortOrder = (int)numSort.Value,
                IsActive = chkActive.Checked,
                ValidFrom = Ui.GetDate(dtpFrom),
                ValidTo = Ui.GetDate(dtpTo)
            };
            try
            {
                if (m.Id == 0) _repo.Insert(m);
                else _repo.Update(m);
                _editingId = m.Id;
                ReloadData();
            }
            catch (Exception ex)
            {
                Ui.Error(ex);
            }
        }

        private void DeleteSelected()
        {
            var m = SelectedMessage;
            if (m == null) return;
            if (!Ui.Confirm("#" + m.Id + " silinsin mi?\n\n" + m.Text1)) return;
            try
            {
                _repo.Delete(m.Id);
                _editingId = 0;
                ReloadData();
            }
            catch (Exception ex)
            {
                Ui.Error(ex);
            }
        }

        /// <summary>
        /// Seçili mesajı aynı gruptaki (MAIN'de aynı kategori) komşusuyla yer değiştirir,
        /// gruptaki sıra numaralarını 10, 20, 30... olarak yeniden yazar.
        /// </summary>
        private void MoveSelected(int dir)
        {
            var m = SelectedMessage;
            if (m == null) return;
            var group = _items.Where(x => x.CategoryId == m.CategoryId).ToList();
            int i = group.IndexOf(m);
            int j = i + dir;
            if (j < 0 || j >= group.Count) return;

            group[i] = group[j];
            group[j] = m;
            try
            {
                for (int k = 0; k < group.Count; k++)
                {
                    int newSort = (k + 1) * 10;
                    if (group[k].SortOrder != newSort)
                    {
                        group[k].SortOrder = newSort;
                        _repo.Update(group[k]);
                    }
                }
                _editingId = m.Id;
                ReloadData();
            }
            catch (Exception ex)
            {
                Ui.Error(ex);
            }
        }
    }
}
