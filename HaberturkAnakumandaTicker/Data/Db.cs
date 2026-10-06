using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace HaberturkAnakumandaTicker.Data
{
    /// <summary>
    /// MySQL baglanti yardimcisi. Baglanti cumlesi App.config -> connectionStrings["HtTicker"].
    /// </summary>
    public static class Db
    {
        private const string ConnectionName = "HtTicker";

        public static string ConnectionString
        {
            get
            {
                var cs = ConfigurationManager.ConnectionStrings[ConnectionName];
                if (cs == null || string.IsNullOrWhiteSpace(cs.ConnectionString))
                    throw new ConfigurationErrorsException("App.config icinde '" + ConnectionName + "' baglanti cumlesi yok.");
                return cs.ConnectionString;
            }
        }

        /// <summary>Acilmis bir baglanti dondurur; using ile kullanin.</summary>
        public static MySqlConnection Open()
        {
            var conn = new MySqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        /// <summary>Baglanti testi. Basariliysa MySQL surumunu dondurur.</summary>
        public static string TestConnection()
        {
            using (var conn = Open())
            {
                return conn.ServerVersion;
            }
        }

        // --- DataReader yardimcilari (NULL kontrolu) ---

        public static string GetStringOrNull(this IDataRecord r, string column)
        {
            int i = r.GetOrdinal(column);
            return r.IsDBNull(i) ? null : r.GetString(i);
        }

        public static int? GetIntOrNull(this IDataRecord r, string column)
        {
            int i = r.GetOrdinal(column);
            return r.IsDBNull(i) ? (int?)null : Convert.ToInt32(r.GetValue(i));
        }

        public static DateTime? GetDateTimeOrNull(this IDataRecord r, string column)
        {
            int i = r.GetOrdinal(column);
            return r.IsDBNull(i) ? (DateTime?)null : r.GetDateTime(i);
        }

        public static int GetInt(this IDataRecord r, string column)
        {
            return Convert.ToInt32(r[column]);
        }

        public static bool GetBool(this IDataRecord r, string column)
        {
            return Convert.ToInt32(r[column]) != 0;
        }

        /// <summary>C# null -> DBNull.Value</summary>
        public static object ToDb(object value)
        {
            return value ?? DBNull.Value;
        }
    }
}
