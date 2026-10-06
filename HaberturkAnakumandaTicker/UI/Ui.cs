using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HaberturkAnakumandaTicker.UI
{
    /// <summary>Sekmeler seçildiğinde verisini yeniden yükleyen kontroller.</summary>
    public interface IReloadable
    {
        void ReloadData();
    }

    /// <summary>Mesaj kutuları ve tarih seçici yardımcıları.</summary>
    internal static class Ui
    {
        public static DateTime? GetDate(DateTimePicker p)
        {
            return p.Checked ? p.Value : (DateTime?)null;
        }

        public static void SetDate(DateTimePicker p, DateTime? value)
        {
            p.Value = value ?? DateTime.Now;
            p.Checked = value.HasValue;
        }

        public static string FormatDate(DateTime? value)
        {
            return value.HasValue ? value.Value.ToString("dd.MM.yyyy HH:mm") : "";
        }

        public static bool Confirm(string message)
        {
            return MessageBox.Show(message, "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static void Info(string message)
        {
            MessageBox.Show(message, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Error(Exception ex)
        {
            MessageBox.Show(FriendlyError(ex), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>Sık görülen MySQL hatalarını anlaşılır mesaja çevirir.</summary>
        public static string FriendlyError(Exception ex)
        {
            var my = ex as MySqlException;
            if (my != null)
            {
                switch (my.Number)
                {
                    case 1451: return "Bu kayda bağlı başka kayıtlar var, önce onları silin.\n\n" + my.Message;
                    case 1062: return "Bu değer zaten kayıtlı (benzersiz olmalı).\n\n" + my.Message;
                    case 1045: return "MySQL kullanıcı adı/şifre hatalı (App.config).\n\n" + my.Message;
                    case 1042:
                    case 0: return "MySQL'e bağlanılamadı (127.0.0.1:3306).\n\n" + my.Message;
                }
            }
            return ex.Message;
        }
    }
}
