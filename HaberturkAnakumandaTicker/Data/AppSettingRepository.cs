using System.Collections.Generic;
using HaberturkAnakumandaTicker.Models;
using MySql.Data.MySqlClient;

namespace HaberturkAnakumandaTicker.Data
{
    public class AppSettingRepository
    {
        private const string SelectSql =
            "SELECT setting_key, setting_value, viz_container, description FROM app_settings";

        public List<AppSetting> GetAll()
        {
            var list = new List<AppSetting>();
            using (var conn = Db.Open())
            using (var cmd = new MySqlCommand(SelectSql + " ORDER BY setting_key", conn))
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                    list.Add(Map(r));
            }
            return list;
        }

        public AppSetting Get(string key)
        {
            using (var conn = Db.Open())
            using (var cmd = new MySqlCommand(SelectSql + " WHERE setting_key = @key", conn))
            {
                cmd.Parameters.AddWithValue("@key", key);
                using (var r = cmd.ExecuteReader())
                    return r.Read() ? Map(r) : null;
            }
        }

        public string GetValue(string key, string defaultValue = null)
        {
            var s = Get(key);
            return s != null ? s.Value : defaultValue;
        }

        /// <summary>Varsa gunceller, yoksa ekler.</summary>
        public void Save(AppSetting s)
        {
            const string sql =
                "INSERT INTO app_settings (setting_key, setting_value, viz_container, description) " +
                "VALUES (@key, @value, @viz, @desc) " +
                "ON DUPLICATE KEY UPDATE setting_value = VALUES(setting_value), " +
                "viz_container = VALUES(viz_container), description = VALUES(description)";
            using (var conn = Db.Open())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@key", s.Key);
                cmd.Parameters.AddWithValue("@value", s.Value ?? "");
                cmd.Parameters.AddWithValue("@viz", Db.ToDb(s.VizContainer));
                cmd.Parameters.AddWithValue("@desc", Db.ToDb(s.Description));
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>Sadece degeri gunceller (formdaki hizli degisiklikler icin).</summary>
        public bool SetValue(string key, string value)
        {
            using (var conn = Db.Open())
            using (var cmd = new MySqlCommand("UPDATE app_settings SET setting_value = @value WHERE setting_key = @key", conn))
            {
                cmd.Parameters.AddWithValue("@key", key);
                cmd.Parameters.AddWithValue("@value", value ?? "");
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(string key)
        {
            using (var conn = Db.Open())
            using (var cmd = new MySqlCommand("DELETE FROM app_settings WHERE setting_key = @key", conn))
            {
                cmd.Parameters.AddWithValue("@key", key);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private static AppSetting Map(MySqlDataReader r)
        {
            return new AppSetting
            {
                Key = r.GetString("setting_key"),
                Value = r.GetString("setting_value"),
                VizContainer = r.GetStringOrNull("viz_container"),
                Description = r.GetStringOrNull("description")
            };
        }
    }
}
