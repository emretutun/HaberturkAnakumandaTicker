using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HaberturkAnakumandaTicker.Data;
using HaberturkAnakumandaTicker.Models;
using HaberturkAnakumandaTicker.Viz;

namespace HaberturkAnakumandaTicker.UI
{
    /// <summary>Operatör ekranının çalışma şekli.</summary>
    public enum QuickMode
    {
        /// <summary>Son dakika: tek satır (SD_TEK) ya da iki satır KJ (SD_KJ).</summary>
        SonDakika,
        /// <summary>Birazdan bandı (BIRAZDAN).</summary>
        Birazdan
    }

    /// <summary>
    /// Operatör ekranı: mesajı yaz → listeye ekle → seç → YAYINA AL / YAYINDAN AL.
    /// Yayına al = seçili mesajı ilgili ticker'a gönder + grafiği ekrana al.
    /// </summary>
    public partial class QuickBroadcastControl : UserControl, IReloadable
    {
        private readonly TickerMessageRepository _repo = new TickerMessageRepository();
        private Broadcaster _broadcaster;
        private QuickMode _mode = QuickMode.SonDakika;

        public QuickBroadcastControl()
        {
            InitializeComponent();
            cmbBumper.SelectedIndex = 0;
            ApplyMode();
        }

        [Category("Ticker")]
        [DefaultValue(QuickMode.SonDakika)]
        public QuickMode Mode
        {
            get { return _mode; }
            set { _mode = value; ApplyMode(); }
        }

        public void Initialize(Broadcaster broadcaster)
        {
            _broadcaster = broadcaster;
        }

        /// <summary>Şu an seçili mesaj tipi.</summary>
        private MessageType CurrentType
        {
            get
            {
                if (_mode == QuickMode.Birazdan) return MessageType.BIRAZDAN;
                return rbKj.Checked ? MessageType.SD_KJ : MessageType.SD_TEK;
            }
        }

        private bool IsKj { get { return CurrentType == MessageType.SD_KJ; } }

        private void ApplyMode()
        {
            bool sd = _mode == QuickMode.SonDakika;
            lblTitle.Text = sd ? "SON DAKİKA" : "BİRAZDAN";
            rbTek.Visible = rbKj.Visible = sd;

            lblText1.Text = IsKj ? "Üst satır:" : "Metin:";
            lblText2.Visible = txtText2.Visible = IsKj;
            lblBumper.Visible = cmbBumper.Visible = IsKj;
            colText1.HeaderText = IsKj ? "Üst satır" : "Metin";
            colText2.Visible = colBumper.Visible = IsKj;
        }

        // ------------------------------------------------------------------ liste

        public void ReloadData()
        {
            try
            {
                var keep = Selected;
                var list = _repo.GetByType(CurrentType)
                    .Where(m => m.IsActive)
                    .OrderByDescending(m => m.CreatedAt).ThenByDescending(m => m.Id)
                    .ToList();
                dgvList.Rows.Clear();
                foreach (var m in list)
                {
                    var r = dgvList.Rows[dgvList.Rows.Add(
                        m.CreatedAt.ToString("dd.MM HH:mm"), m.Text1, m.Text2,
                        m.BumperType == BumperType.Yok ? "" : m.BumperType.ToString())];
                    r.Tag = m;
                    if (keep != null && keep.Id == m.Id) { r.Selected = true; dgvList.CurrentCell = r.Cells[0]; }
                }
                if (keep == null) dgvList.ClearSelection();
            }
            catch (Exception ex)
            {
                Ui.Error(ex);
            }
        }

        private TickerMessage Selected
        {
            get { return dgvList.SelectedRows.Count > 0 ? dgvList.SelectedRows[0].Tag as TickerMessage : null; }
        }

        private void SelectById(int id)
        {
            foreach (DataGridViewRow r in dgvList.Rows)
            {
                if (((TickerMessage)r.Tag).Id == id) { r.Selected = true; dgvList.CurrentCell = r.Cells[0]; return; }
            }
        }

        // ------------------------------------------------------------------ olaylar

        private void rbType_CheckedChanged(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked) return;
            ApplyMode();
            ReloadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var m = SaveNew();
            if (m != null) txtText1.Focus();
        }

        private void btnSaveAir_Click(object sender, EventArgs e)
        {
            var m = SaveNew();
            if (m != null) Air(m);
        }

        private void btnAir_Click(object sender, EventArgs e)
        {
            var m = Selected;
            if (m == null) { Ui.Info("Önce listeden bir mesaj seçin."); return; }
            Air(m);
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Çift tıklama: metni giriş alanına kopyalar (düzeltip yeniden eklemek için)
            var m = Selected;
            if (m == null) return;
            txtText1.Text = m.Text1;
            txtText2.Text = m.Text2 ?? "";
            cmbBumper.SelectedIndex = (int)m.BumperType;
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            Do(() =>
            {
                _broadcaster.TakeOut(CurrentType);
                SetOnAir(null);
            });
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var m = Selected;
            if (m == null) return;
            if (!Ui.Confirm("Seçili mesaj silinsin mi?\n\n" + m.Text1)) return;
            Do(() =>
            {
                _repo.Delete(m.Id);
                ReloadData();
            });
        }

        // ------------------------------------------------------------------ işlemler

        private TickerMessage SaveNew()
        {
            if (txtText1.Text.Trim() == "")
            {
                Ui.Info((IsKj ? "Üst satır" : "Metin") + " boş olamaz.");
                return null;
            }
            var m = new TickerMessage
            {
                MessageType = CurrentType,
                Text1 = txtText1.Text.Trim(),
                Text2 = IsKj ? txtText2.Text.Trim() : null,
                BumperType = IsKj ? (BumperType)Math.Max(0, cmbBumper.SelectedIndex) : BumperType.Yok,
                IsActive = true
            };
            try
            {
                _repo.Insert(m);
                txtText1.Text = "";
                txtText2.Text = "";
                cmbBumper.SelectedIndex = 0;
                ReloadData();
                SelectById(m.Id);
                return m;
            }
            catch (Exception ex)
            {
                Ui.Error(ex);
                return null;
            }
        }

        /// <summary>Mesajı gönderir ve grafiği ekrana alır.</summary>
        private void Air(TickerMessage m)
        {
            Do(() =>
            {
                _broadcaster.Send(m.MessageType, new[] { m });
                _broadcaster.TakeIn(m.MessageType);
                SetOnAir(m);
            });
        }

        private void SetOnAir(TickerMessage m)
        {
            if (m == null)
            {
                lblOnAir.Text = "Yayında değil";
                lblOnAir.ForeColor = Color.DimGray;
            }
            else
            {
                lblOnAir.Text = "YAYINDA (" + DateTime.Now.ToString("HH:mm") + "): " + m.Text1;
                lblOnAir.ForeColor = Color.FromArgb(192, 57, 43);
            }
        }

        private void Do(Action action)
        {
            if (_broadcaster == null) { Ui.Info("Yayın bağlantısı hazır değil."); return; }
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
