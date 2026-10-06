using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HaberturkAnakumandaTicker.Data;
using HaberturkAnakumandaTicker.Models;
using HaberturkAnakumandaTicker.Viz;

namespace HaberturkAnakumandaTicker.UI
{
    /// <summary>
    /// Yayın listesi (ana ticker kuyruğu):
    ///  1) Tarih aralığı (haberin girildiği tarih) ve kategori başına adet seçilir.
    ///  2) "Listele / Otomatik Seç": aralıktaki TÜM haberler kategori sırasıyla, en yeni üstte listelenir;
    ///     her kategoride en yeni N tanesi otomatik işaretlenir.
    ///  3) Operatör işaretleri düzeltebilir (ör. dünün 11. haberini de ekler).
    ///  4) "Ana Ticker'a Gönder": sadece işaretliler, kategori sırasıyla gönderilir.
    /// Adet + saat ayarları isimli şablon olarak saklanabilir.
    /// </summary>
    public partial class PlaylistControl : UserControl, IReloadable
    {
        private const int MaxListPerCategory = 500;

        /// <summary>
        /// Kulakçıklı (ayraçlı) kategorilerde en az bu kadar haber gönderilir. Sahnede yeni kategorinin
        /// ayracı önceki başlığı "SHOW 0" ile anında kapatıyor; kategori kısa kalırsa kulakçık
        /// ekrandan çıkmadan kesiliyor. Kulakçıksız (ayraçsız) kategoriler bu kurala tabi değil.
        /// </summary>
        public const int MinPerTaggedCategory = 3;

        private static bool IsTagged(Category c)
        {
            return c != null && !string.IsNullOrEmpty(c.SeparatorTemplate);
        }

        /// <summary>Kulakçıklı kategoride 1..(min-1) girilirse min'e çıkarır; 0 = gönderme.</summary>
        private static int NormalizeCount(Category c, int n)
        {
            if (n <= 0) return 0;
            return IsTagged(c) && n < MinPerTaggedCategory ? MinPerTaggedCategory : n;
        }

        private readonly CategoryRepository _categories = new CategoryRepository();
        private readonly TickerMessageRepository _messages = new TickerMessageRepository();
        private readonly PlaylistTemplateRepository _templates = new PlaylistTemplateRepository();

        private Broadcaster _broadcaster;
        private List<Category> _cats = new List<Category>();
        private bool _filling;
        private bool _rangeInitialized;

        public PlaylistControl()
        {
            InitializeComponent();
            SetMainInEnabled(false);
        }

        /// <summary>
        /// "ANA BANDI VER" ancak bu oturumda liste ana banda gönderildikten sonra açılır;
        /// böylece reji boş/eski bandı yanlışlıkla ekrana veremez.
        /// </summary>
        private void SetMainInEnabled(bool enabled)
        {
            btnMainIn.Enabled = enabled;
            btnMainIn.BackColor = enabled ? Color.FromArgb(46, 139, 87) : Color.Gainsboro;
            btnMainIn.ForeColor = enabled ? Color.White : Color.Gray;
            btnMainIn.Text = enabled ? "▶  ANA BANDI VER" : "▶  ANA BANDI VER\n(önce listeyi gönderin)";
        }

        public void Initialize(Broadcaster broadcaster)
        {
            _broadcaster = broadcaster;
        }

        private void btnMainIn_Click(object sender, EventArgs e)
        {
            Safe(() =>
            {
                if (_broadcaster == null) throw new InvalidOperationException("Yayın bağlantısı hazır değil.");
                _broadcaster.TakeIn(MessageType.MAIN);
                lblSummary.Text = DateTime.Now.ToString("HH:mm:ss") + "  Ana bant ekranda.";
            });
        }

        private void btnMainOut_Click(object sender, EventArgs e)
        {
            Safe(() =>
            {
                if (_broadcaster == null) throw new InvalidOperationException("Yayın bağlantısı hazır değil.");
                _broadcaster.TakeOut(MessageType.MAIN);
                lblSummary.Text = DateTime.Now.ToString("HH:mm:ss") + "  Ana bant ekrandan alındı.";
            });
        }

        // ------------------------------------------------------------------ yükleme

        public void ReloadData()
        {
            try
            {
                if (!_rangeInitialized)
                {
                    ApplyHours((int)numHours.Value);
                    _rangeInitialized = true;
                }
                var oldCounts = ReadCounts();
                _cats = _categories.GetAll(true);
                _filling = true;
                dgvCounts.Rows.Clear();
                foreach (var c in _cats)
                {
                    int count;
                    oldCounts.TryGetValue(c.Id, out count);
                    var r = dgvCounts.Rows[dgvCounts.Rows.Add(c.Title, "", count)];
                    r.Tag = c;
                }
                _filling = false;
                RefreshAvailability();
                LoadTemplateList(cmbTemplate.SelectedItem as PlaylistTemplate);
            }
            catch (Exception ex)
            {
                _filling = false;
                Ui.Error(ex);
            }
        }

        private void LoadTemplateList(PlaylistTemplate keep)
        {
            _filling = true;
            cmbTemplate.Items.Clear();
            cmbTemplate.Items.Add("(şablon seç)");
            foreach (var t in _templates.GetAll())
                cmbTemplate.Items.Add(t);
            cmbTemplate.SelectedIndex = 0;
            if (keep != null)
            {
                for (int i = 1; i < cmbTemplate.Items.Count; i++)
                {
                    if (((PlaylistTemplate)cmbTemplate.Items[i]).Id == keep.Id) { cmbTemplate.SelectedIndex = i; break; }
                }
            }
            _filling = false;
        }

        /// <summary>Her kategori için aralıkta kaç uygun haber olduğunu gösterir.</summary>
        private void RefreshAvailability()
        {
            if (dgvCounts.Rows.Count == 0) return;
            DateTime from = dtpFrom.Value, to = dtpTo.Value;
            foreach (DataGridViewRow r in dgvCounts.Rows)
            {
                var c = (Category)r.Tag;
                r.Cells[colAvailable.Index].Value = _messages.GetLatestForPlaylist(c.Id, from, to, MaxListPerCategory).Count;
            }
        }

        // ------------------------------------------------------------------ olaylar

        private void btnApplyHours_Click(object sender, EventArgs e)
        {
            ApplyHours((int)numHours.Value);
            Safe(RefreshAvailability);
        }

        private void dtpRange_ValueChanged(object sender, EventArgs e)
        {
            if (!_filling) Safe(RefreshAvailability);
        }

        private void dgvCounts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != colCount.Index) return;
            var row = dgvCounts.Rows[e.RowIndex];
            var cell = row.Cells[colCount.Index];
            int n;
            if (!int.TryParse(Convert.ToString(cell.Value), out n)) n = 0;
            int fixedN = NormalizeCount((Category)row.Tag, n);
            cell.Value = fixedN;
            if (fixedN != n && n > 0)
                lblSummary.Text = ((Category)row.Tag).Title + ": kulakçıklı kategoride en az " + MinPerTaggedCategory + " haber gönderilir, " + MinPerTaggedCategory + " yapıldı.";
        }

        private void cmbTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_filling) return;
            var sel = cmbTemplate.SelectedItem as PlaylistTemplate;
            if (sel == null) return;
            Safe(() =>
            {
                var t = _templates.Get(sel.Id);
                if (t == null) return;
                txtTplName.Text = t.Name;
                numHours.Value = Math.Max(numHours.Minimum, Math.Min(numHours.Maximum, t.HoursBack));
                ApplyHours(t.HoursBack);
                foreach (DataGridViewRow r in dgvCounts.Rows)
                {
                    int count;
                    t.Counts.TryGetValue(((Category)r.Tag).Id, out count);
                    r.Cells[colCount.Index].Value = NormalizeCount((Category)r.Tag, count);
                }
                RefreshAvailability();
                dgvQueue.Rows.Clear();
                lblSummary.Text = "Şablon yüklendi: " + t.Name + ". Listele ile kuyruğu oluştur.";
            });
        }

        private void btnTplSave_Click(object sender, EventArgs e)
        {
            Safe(() =>
            {
                dgvCounts.EndEdit();
                var t = new PlaylistTemplate
                {
                    Name = txtTplName.Text.Trim(),
                    HoursBack = (int)numHours.Value,
                    Counts = ReadCounts()
                };
                _templates.Save(t);
                LoadTemplateList(t);
                lblSummary.Text = "Şablon kaydedildi: " + t.Name;
            });
        }

        private void btnTplDelete_Click(object sender, EventArgs e)
        {
            var sel = cmbTemplate.SelectedItem as PlaylistTemplate;
            if (sel == null) return;
            if (!Ui.Confirm("'" + sel.Name + "' şablonu silinsin mi?")) return;
            Safe(() =>
            {
                _templates.Delete(sel.Id);
                txtTplName.Text = "";
                LoadTemplateList(null);
            });
        }

        /// <summary>"Listele / Otomatik Seç"</summary>
        private void btnPreview_Click(object sender, EventArgs e)
        {
            Safe(LoadQueue);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Safe(() =>
            {
                if (dgvQueue.Rows.Count == 0) LoadQueue();
                dgvQueue.EndEdit();

                var selection = CheckedMessages();
                if (selection.Count == 0)
                {
                    Ui.Info("Kuyrukta işaretli haber yok.");
                    return;
                }

                // Kulakçıklı kategorilerde 1-2 haber varsa gönderme: kulakçık ekrandan çıkmadan kesilir.
                var tooFew = _cats
                    .Where(IsTagged)
                    .Select(c => new { c.Title, N = selection.Count(m => m.CategoryId == c.Id) })
                    .Where(x => x.N > 0 && x.N < MinPerTaggedCategory)
                    .ToList();
                if (tooFew.Count > 0)
                {
                    Ui.Info("Kulakçıklı kategorilerden en az " + MinPerTaggedCategory + " haber gönderilmeli:\n\n" +
                            string.Join("\n", tooFew.Select(x => "• " + x.Title + ": " + x.N + " haber")) +
                            "\n\nKuyrukta bu kategorilerden haber ekleyin ya da hepsinin işaretini kaldırın.");
                    return;
                }
                if (_broadcaster == null) throw new InvalidOperationException("Yayın bağlantısı hazır değil.");
                _broadcaster.Connect();

                var groups = TickerPlaylistBuilder.BuildMain(_cats, selection);
                _broadcaster.SendMain(groups);
                SetMainInEnabled(true);
                lblSummary.Text = DateTime.Now.ToString("HH:mm:ss") + "  Gönderildi: " + SummaryText(selection) + "  (" + groups.Count + " grup)";
            });
        }

        // Onay kutusu tıklanınca değer hemen işlensin (yoksa hücreden çıkana kadar beklenir)
        private void dgvQueue_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvQueue.IsCurrentCellDirty && dgvQueue.CurrentCell is DataGridViewCheckBoxCell)
                dgvQueue.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvQueue_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_filling || e.RowIndex < 0 || e.ColumnIndex != colSend.Index) return;
            StyleRow(dgvQueue.Rows[e.RowIndex]);
            lblSummary.Text = "Seçili: " + SummaryText(CheckedMessages());
        }

        // ------------------------------------------------------------------ kuyruk

        /// <summary>
        /// Aralıktaki tüm haberleri kategori sırasıyla (kategori içinde en yeni üstte) listeler,
        /// her kategoride en yeni N tanesini işaretler. Adet 0 olan kategoriler de listelenir
        /// (elle eklenebilsin diye) ama işaretlenmez.
        /// </summary>
        private void LoadQueue()
        {
            dgvCounts.EndEdit();
            DateTime from = dtpFrom.Value, to = dtpTo.Value;
            if (from > to) throw new ArgumentException("Başlangıç tarihi bitişten sonra olamaz.");
            var counts = ReadCounts();
            var missing = new List<string>();

            _filling = true;
            dgvQueue.Rows.Clear();
            foreach (var c in _cats.OrderBy(x => x.SortOrder))
            {
                int wanted;
                counts.TryGetValue(c.Id, out wanted);
                wanted = NormalizeCount(c, wanted);
                var list = _messages.GetLatestForPlaylist(c.Id, from, to, MaxListPerCategory);
                for (int i = 0; i < list.Count; i++)
                {
                    var m = list[i];
                    var r = dgvQueue.Rows[dgvQueue.Rows.Add(i < wanted, c.Title, m.CreatedAt.ToString("dd.MM HH:mm"), m.Text1)];
                    r.Tag = m;
                    StyleRow(r);
                }
                if (wanted > list.Count) missing.Add(c.Title + " (" + list.Count + "/" + wanted + ")");
            }
            _filling = false;

            lblSummary.Text = "Seçili: " + SummaryText(CheckedMessages()) +
                (missing.Count > 0 ? "   Eksik: " + string.Join(", ", missing) : "");
        }

        /// <summary>İşaretli haberler, kuyruktaki sırayla (kategori sırası, en yeni önce).</summary>
        private List<TickerMessage> CheckedMessages()
        {
            var result = new List<TickerMessage>();
            foreach (DataGridViewRow r in dgvQueue.Rows)
            {
                if (Convert.ToBoolean(r.Cells[colSend.Index].Value))
                    result.Add((TickerMessage)r.Tag);
            }
            return result;
        }

        private string SummaryText(List<TickerMessage> selection)
        {
            var parts = new List<string>();
            foreach (var c in _cats.OrderBy(x => x.SortOrder))
            {
                int n = selection.Count(m => m.CategoryId == c.Id);
                if (n > 0) parts.Add(c.Title + " " + n);
            }
            return selection.Count + " haber" + (parts.Count > 0 ? " (" + string.Join(", ", parts) + ")" : "");
        }

        private void StyleRow(DataGridViewRow r)
        {
            bool on = Convert.ToBoolean(r.Cells[colSend.Index].Value);
            r.DefaultCellStyle.ForeColor = on ? SystemColors.ControlText : Color.Gray;
        }

        // ------------------------------------------------------------------ yardımcılar

        private void ApplyHours(int hours)
        {
            _filling = true;
            dtpTo.Value = DateTime.Now;
            dtpFrom.Value = DateTime.Now.AddHours(-hours);
            _filling = false;
        }

        private Dictionary<int, int> ReadCounts()
        {
            var d = new Dictionary<int, int>();
            foreach (DataGridViewRow r in dgvCounts.Rows)
            {
                int n;
                if (int.TryParse(Convert.ToString(r.Cells[colCount.Index].Value), out n) && n > 0)
                    d[((Category)r.Tag).Id] = n;
            }
            return d;
        }

        private void Safe(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                _filling = false;
                Ui.Error(ex);
            }
        }
    }
}
