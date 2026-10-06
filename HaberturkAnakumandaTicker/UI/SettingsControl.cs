using System;
using System.Drawing;
using System.Windows.Forms;
using HaberturkAnakumandaTicker.Data;
using HaberturkAnakumandaTicker.Models;

namespace HaberturkAnakumandaTicker.UI
{
    /// <summary>
    /// app_settings: sadece "Değer" sütunu düzenlenebilir.
    /// viz_host / viz_port kilitli - Viz adresi kodda 127.0.0.1:6100 olarak sabit.
    /// </summary>
    public partial class SettingsControl : UserControl, IReloadable
    {
        private static readonly string[] LockedKeys = { "viz_host", "viz_port" };

        private readonly AppSettingRepository _repo = new AppSettingRepository();

        public SettingsControl()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e) { ReloadData(); }
        private void btnSave_Click(object sender, EventArgs e) { Save(); }

        private static bool IsLocked(string key)
        {
            return Array.IndexOf(LockedKeys, key) >= 0;
        }

        public void ReloadData()
        {
            try
            {
                var list = _repo.GetAll();
                dgvSettings.Rows.Clear();
                foreach (var s in list)
                {
                    var r = dgvSettings.Rows[dgvSettings.Rows.Add(s.Key, s.Value, s.VizContainer, s.Description)];
                    r.Tag = s;
                    if (IsLocked(s.Key))
                    {
                        r.ReadOnly = true;
                        r.DefaultCellStyle.ForeColor = Color.Gray;
                    }
                }
            }
            catch (Exception ex)
            {
                Ui.Error(ex);
            }
        }

        private void Save()
        {
            dgvSettings.EndEdit();
            int changed = 0;
            try
            {
                foreach (DataGridViewRow r in dgvSettings.Rows)
                {
                    var s = (AppSetting)r.Tag;
                    if (IsLocked(s.Key)) continue;
                    string newValue = Convert.ToString(r.Cells[colValue.Index].Value) ?? "";
                    if (newValue != s.Value)
                    {
                        _repo.SetValue(s.Key, newValue);
                        changed++;
                    }
                }
                Ui.Info(changed + " ayar kaydedildi.");
                ReloadData();
            }
            catch (Exception ex)
            {
                Ui.Error(ex);
            }
        }
    }
}
