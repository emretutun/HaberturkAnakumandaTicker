using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using HaberturkAnakumandaTicker.Data;
using HaberturkAnakumandaTicker.Models;
using HaberturkAnakumandaTicker.Viz;

namespace HaberturkAnakumandaTicker.UI
{
    /// <summary>
    /// Operatör ekranı: ekonomi değerlerini yaz → kaydet ve gönder → TOBLERON VER / AL.
    /// Ad, logo kodu, ondalık ve sıra Yönetim > Ekonomi'den düzenlenir.
    /// </summary>
    public partial class TobleronControl : UserControl, IReloadable
    {
        private static readonly CultureInfo Tr = new CultureInfo("tr-TR");
        private const int ChangeUp = 0, ChangeDown = 1, ChangeSame = 2;   // colChange öğe sırası

        private readonly EconomyItemRepository _repo = new EconomyItemRepository();
        private TobleronController _tob;
        private bool _filling;
        private bool _dirty;

        /// <summary>
        /// Operatörün tabloda değiştirdiği satırlar. Kaydederken sadece bunlar DB'ye yazılır;
        /// diğer satırlar DB'den taze okunur (DB'de elle yapılan değişiklik ezilmesin).
        /// </summary>
        private readonly HashSet<int> _edited = new HashSet<int>();

        public TobleronControl()
        {
            InitializeComponent();
        }

        public void Initialize(TobleronController tobleron)
        {
            _tob = tobleron;
            _tob.ItemSent += item => lblNow.Text = "Sırada: " + item.DisplayName;
            _tob.Error += msg => lblNow.Text = "HATA: " + msg;
            tmrPoll.Enabled = chkAuto.Checked;
        }

        // ------------------------------------------------------------------ otomatik güncelleme

        /// <summary>Viz'e en son yazılan hali (id → imza). Değişeni bulmak için.</summary>
        private readonly Dictionary<int, EconomyItem> _sent = new Dictionary<int, EconomyItem>();

        private static string Signature(EconomyItem i)
        {
            return i.ShmBaseKey + "|" + i.DisplayName + "|" + i.DecimalPlaces + "|" +
                   (i.Value.HasValue ? i.Value.Value.ToString(CultureInfo.InvariantCulture) : "") + "|" +
                   Math.Sign(i.Change) + "|" + i.IsActive + "|" + i.SortOrder;
        }

        private void Remember(IEnumerable<EconomyItem> items)
        {
            _sent.Clear();
            foreach (var i in items) _sent[i.Id] = i.Clone();
        }

        private void chkAuto_CheckedChanged(object sender, EventArgs e)
        {
            tmrPoll.Enabled = chkAuto.Checked;
            lblPoll.Text = chkAuto.Checked ? "-" : "kapalı";
        }

        /// <summary>
        /// 2 sn'de bir DB'yi okur; değişen veri varsa yerel Viz'e yazar. Değer değişip yön
        /// değişmemişse yön eski/yeni değere göre otomatik belirlenir (▲ / ▼ / =) ve DB'ye kaydedilir.
        /// </summary>
        private void tmrPoll_Tick(object sender, EventArgs e)
        {
            if (_tob == null || !_tob.IsReady) { lblPoll.Text = "bağlı değil"; return; }
            try
            {
                var items = _repo.GetAll();
                var changed = new List<string>();
                foreach (var i in items)
                {
                    EconomyItem old;
                    if (!_sent.TryGetValue(i.Id, out old)) { changed.Add(i.DisplayName); continue; }
                    if (Signature(old) == Signature(i)) continue;
                    if (i.Value.HasValue && old.Value.HasValue && i.Value != old.Value && Math.Sign(i.Change) == Math.Sign(old.Change))
                    {
                        i.Change = Math.Sign(i.Value.Value - old.Value.Value);
                        _repo.UpdateValue(i.Id, i.Value, i.Change, i.IsActive);
                    }
                    changed.Add(i.DisplayName);
                }
                if (changed.Count > 0 || _sent.Count != items.Count)
                {
                    _tob.WriteValues(items);
                    Remember(items);
                    if (!_dirty && !dgvItems.IsCurrentCellInEditMode) ReloadData();
                    else RefreshUntouchedRows(items);
                    lblPoll.Text = DateTime.Now.ToString("HH:mm:ss") + " güncellendi: " + string.Join(", ", changed);
                }
                else
                {
                    lblPoll.Text = DateTime.Now.ToString("HH:mm:ss") + " değişiklik yok";
                }
            }
            catch (Exception ex)
            {
                lblPoll.Text = "HATA: " + ex.Message;
            }
        }

        // ------------------------------------------------------------------ liste

        public void ReloadData()
        {
            if (_dirty && !Ui.Confirm("Kaydedilmemiş değişiklikler var. Yeniden yüklensin mi?")) return;
            try
            {
                var items = _repo.GetAll();
                _filling = true;
                dgvItems.Rows.Clear();
                foreach (var i in items)
                {
                    var r = dgvItems.Rows[dgvItems.Rows.Add(i.DisplayName, FormatValue(i), colChange.Items[ChangeIndex(i.Change)], i.IsActive, i.LogoCode)];
                    r.Tag = i;
                }
                _filling = false;
                _edited.Clear();
                SetDirty(false);
            }
            catch (Exception ex)
            {
                _filling = false;
                Ui.Error(ex);
            }
        }

        /// <summary>Operatörün dokunmadığı satırları DB'deki güncel değerlerle yeniler.</summary>
        private void RefreshUntouchedRows(List<EconomyItem> fresh)
        {
            var byId = fresh.ToDictionary(i => i.Id);
            _filling = true;
            foreach (DataGridViewRow r in dgvItems.Rows)
            {
                var old = (EconomyItem)r.Tag;
                EconomyItem i;
                if (_edited.Contains(old.Id) || !byId.TryGetValue(old.Id, out i)) continue;
                if (r.Cells[colValue.Index].IsInEditMode) continue;
                r.Cells[colName.Index].Value = i.DisplayName;
                r.Cells[colValue.Index].Value = FormatValue(i);
                r.Cells[colChange.Index].Value = colChange.Items[ChangeIndex(i.Change)];
                r.Cells[colActive.Index].Value = i.IsActive;
                r.Cells[colLogo.Index].Value = i.LogoCode;
                r.Tag = i;
            }
            _filling = false;
        }

        private static string FormatValue(EconomyItem i)
        {
            return i.Value.HasValue ? i.Value.Value.ToString("N" + (i.DecimalPlaces ?? 2), Tr) : "";
        }

        private static int ChangeIndex(int change)
        {
            return change > 0 ? ChangeUp : change < 0 ? ChangeDown : ChangeSame;
        }

        /// <summary>
        /// "14.300,55" ve "14300,55" (Türkçe) ile "48.7001" (nokta ondalık) kabul edilir:
        /// virgül varsa ondalık ayracı virgüldür, yoksa nokta.
        /// </summary>
        private static bool TryParseValue(string s, out decimal value)
        {
            s = (s ?? "").Trim().Replace(" ", "");
            if (s.Contains(","))
                s = s.Replace(".", "").Replace(",", ".");
            return decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out value);
        }

        /// <summary>Tablodaki değerleri doğrular ve model listesine çevirir. Hata varsa null.</summary>
        private List<EconomyItem> ReadGrid()
        {
            dgvItems.EndEdit();
            var list = new List<EconomyItem>();
            foreach (DataGridViewRow r in dgvItems.Rows)
            {
                var i = (EconomyItem)r.Tag;
                string text = Convert.ToString(r.Cells[colValue.Index].Value);
                if (text.Trim() == "") i.Value = null;
                else
                {
                    decimal v;
                    if (!TryParseValue(text, out v))
                    {
                        Ui.Info(i.DisplayName + ": değer sayı olmalı (örnek: 14.300,55 ya da 48,7001).");
                        dgvItems.CurrentCell = r.Cells[colValue.Index];
                        return null;
                    }
                    i.Value = v;
                }
                int idx = colChange.Items.IndexOf(r.Cells[colChange.Index].Value);
                i.Change = idx == ChangeUp ? 1 : idx == ChangeDown ? -1 : 0;
                i.IsActive = Convert.ToBoolean(r.Cells[colActive.Index].Value);
                list.Add(i);
            }
            return list;
        }

        private void SetDirty(bool dirty)
        {
            _dirty = dirty;
            btnSaveSend.BackColor = dirty ? Color.FromArgb(241, 196, 15) : SystemColors.Control;
            btnSaveSend.Text = dirty ? "Değerleri Kaydet ve Gönder *" : "Değerleri Kaydet ve Gönder";
        }

        // ------------------------------------------------------------------ olaylar

        private void dgvItems_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // Onay kutusu / açılır liste değişince hemen işlensin
            if (dgvItems.IsCurrentCellDirty && !(dgvItems.CurrentCell is DataGridViewTextBoxCell))
                dgvItems.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_filling || e.RowIndex < 0) return;
            _edited.Add(((EconomyItem)dgvItems.Rows[e.RowIndex].Tag).Id);
            SetDirty(true);

            // Değer değişince yönü kayıtlı değere göre öner (operatör yine elle değiştirebilir)
            if (e.ColumnIndex == colValue.Index)
            {
                var row = dgvItems.Rows[e.RowIndex];
                var item = (EconomyItem)row.Tag;
                decimal v;
                if (item.Value.HasValue && TryParseValue(Convert.ToString(row.Cells[colValue.Index].Value), out v))
                {
                    _filling = true;
                    row.Cells[colChange.Index].Value = colChange.Items[ChangeIndex(Math.Sign(v - item.Value.Value))];
                    _filling = false;
                }
            }
        }

        private void btnSaveSend_Click(object sender, EventArgs e)
        {
            SaveAndSend();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            var items = Save();
            if (items == null) return;
            Do(() =>
            {
                _tob.TakeIn(items);
                Remember(items);
                lblNow.ForeColor = Color.FromArgb(192, 57, 43);
            });
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            Do(() =>
            {
                _tob.TakeOut();
                lblNow.Text = "Yayında değil";
                lblNow.ForeColor = Color.DimGray;
            });
        }

        // ------------------------------------------------------------------ işlemler

        /// <summary>Değerleri DB'ye kaydeder. Hata varsa null.</summary>
        private List<EconomyItem> Save()
        {
            var items = ReadGrid();
            if (items == null) return null;
            try
            {
                // Sadece operatörün değiştirdiği satırlar yazılır; gönderilecek liste DB'den taze okunur
                foreach (var i in items.Where(x => _edited.Contains(x.Id)))
                    _repo.UpdateValue(i.Id, i.Value, i.Change, i.IsActive);
                SetDirty(false);
                ReloadData();
                return _repo.GetAll();
            }
            catch (Exception ex)
            {
                Ui.Error(ex);
                return null;
            }
        }

        private void SaveAndSend()
        {
            var items = Save();
            if (items == null) return;
            Do(() =>
            {
                _tob.WriteValues(items);
                Remember(items);
                if (!_tob.Running) lblNow.Text = "Değerler gönderildi (tobleron ekranda değil)";
            });
        }

        private void Do(Action action)
        {
            if (_tob == null) { Ui.Info("Yayın bağlantısı hazır değil."); return; }
            Cursor = Cursors.WaitCursor;
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Ui.Error(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
