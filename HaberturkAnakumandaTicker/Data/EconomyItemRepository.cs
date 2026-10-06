using System;
using System.Collections.Generic;
using HaberturkAnakumandaTicker.Models;
using MySql.Data.MySqlClient;

namespace HaberturkAnakumandaTicker.Data
{
    public class EconomyItemRepository
    {
        private const string SelectSql =
            "SELECT id, display_name, shm_base_key, decimal_places, value_num, change_dir, sort_order, is_active, updated_at FROM economy_items";

        private static bool _schemaChecked;

        /// <summary>Eski şemada olmayan value_num / change_dir sütunlarını ekler (bir kez).</summary>
        private static void EnsureSchema(MySqlConnection conn)
        {
            if (_schemaChecked) return;
            AddColumnIfMissing(conn, "value_num", "DECIMAL(18,6) NULL AFTER decimal_places");
            AddColumnIfMissing(conn, "change_dir", "TINYINT NOT NULL DEFAULT 0 AFTER value_num");
            _schemaChecked = true;
        }

        private static void AddColumnIfMissing(MySqlConnection conn, string column, string definition)
        {
            using (var cmd = new MySqlCommand(
                "SELECT COUNT(*) FROM information_schema.columns WHERE table_schema = DATABASE() " +
                "AND table_name = 'economy_items' AND column_name = @c", conn))
            {
                cmd.Parameters.AddWithValue("@c", column);
                if (Convert.ToInt32(cmd.ExecuteScalar()) > 0) return;
            }
            using (var cmd = new MySqlCommand("ALTER TABLE economy_items ADD COLUMN " + column + " " + definition, conn))
                cmd.ExecuteNonQuery();
        }

        private static MySqlConnection Open()
        {
            var conn = Db.Open();
            EnsureSchema(conn);
            return conn;
        }

        public List<EconomyItem> GetAll(bool onlyActive = false)
        {
            string sql = SelectSql + (onlyActive ? " WHERE is_active = 1" : "") + " ORDER BY sort_order, id";
            var list = new List<EconomyItem>();
            using (var conn = Open())
            using (var cmd = new MySqlCommand(sql, conn))
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                    list.Add(Map(r));
            }
            return list;
        }

        public EconomyItem GetById(int id)
        {
            using (var conn = Open())
            using (var cmd = new MySqlCommand(SelectSql + " WHERE id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (var r = cmd.ExecuteReader())
                    return r.Read() ? Map(r) : null;
            }
        }

        public int Insert(EconomyItem e)
        {
            Validate(e);
            const string sql =
                "INSERT INTO economy_items (display_name, shm_base_key, decimal_places, value_num, change_dir, sort_order, is_active) " +
                "VALUES (@name, @shm, @dec, @val, @chg, @sort, @active)";
            using (var conn = Open())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                AddParams(cmd, e);
                cmd.ExecuteNonQuery();
                e.Id = (int)cmd.LastInsertedId;
                return e.Id;
            }
        }

        public bool Update(EconomyItem e)
        {
            Validate(e);
            const string sql =
                "UPDATE economy_items SET display_name = @name, shm_base_key = @shm, decimal_places = @dec, " +
                "value_num = @val, change_dir = @chg, sort_order = @sort, is_active = @active WHERE id = @id";
            using (var conn = Open())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                AddParams(cmd, e);
                cmd.Parameters.AddWithValue("@id", e.Id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>Sadece değer / yön / aktiflik günceller (Tobleron ekranı).</summary>
        public bool UpdateValue(int id, decimal? value, int change, bool isActive)
        {
            const string sql = "UPDATE economy_items SET value_num = @val, change_dir = @chg, is_active = @active WHERE id = @id";
            using (var conn = Open())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@val", Db.ToDb(value));
                cmd.Parameters.AddWithValue("@chg", Math.Sign(change));
                cmd.Parameters.AddWithValue("@active", isActive);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var conn = Open())
            using (var cmd = new MySqlCommand("DELETE FROM economy_items WHERE id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>Sahne script'i logo için "/" ile bölünmüş 3. parçayı bekliyor: "/economy/1604".</summary>
        private static void Validate(EconomyItem e)
        {
            if (string.IsNullOrWhiteSpace(e.DisplayName))
                throw new ArgumentException("Görünen ad boş olamaz.");
            var p = (e.ShmBaseKey ?? "").Split('/');
            if (p.Length != 3 || p[0] != "" || p[1] == "" || p[2] == "")
                throw new ArgumentException("SHM anahtarı '/economy/LOGO_KODU' biçiminde olmalı (örnek: /economy/1604).");
        }

        private static void AddParams(MySqlCommand cmd, EconomyItem e)
        {
            cmd.Parameters.AddWithValue("@name", e.DisplayName);
            cmd.Parameters.AddWithValue("@shm", e.ShmBaseKey);
            cmd.Parameters.AddWithValue("@dec", Db.ToDb(e.DecimalPlaces));
            cmd.Parameters.AddWithValue("@val", Db.ToDb(e.Value));
            cmd.Parameters.AddWithValue("@chg", Math.Sign(e.Change));
            cmd.Parameters.AddWithValue("@sort", e.SortOrder);
            cmd.Parameters.AddWithValue("@active", e.IsActive);
        }

        private static EconomyItem Map(MySqlDataReader r)
        {
            int? dec = r.GetIntOrNull("decimal_places");
            int vi = r.GetOrdinal("value_num");
            return new EconomyItem
            {
                Id = r.GetInt("id"),
                DisplayName = r.GetString("display_name"),
                ShmBaseKey = r.GetString("shm_base_key"),
                DecimalPlaces = dec.HasValue ? (byte?)dec.Value : null,
                Value = r.IsDBNull(vi) ? (decimal?)null : r.GetDecimal(vi),
                Change = r.GetInt("change_dir"),
                SortOrder = r.GetInt("sort_order"),
                IsActive = r.GetBool("is_active"),
                UpdatedAt = r.GetDateTime("updated_at")
            };
        }
    }
}
