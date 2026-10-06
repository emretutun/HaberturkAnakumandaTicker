using System;
using System.Collections.Generic;
using HaberturkAnakumandaTicker.Models;
using MySql.Data.MySqlClient;

namespace HaberturkAnakumandaTicker.Data
{
    public class PlaylistTemplateRepository
    {
        /// <summary>Şablon listesi (adetler olmadan).</summary>
        public List<PlaylistTemplate> GetAll()
        {
            var list = new List<PlaylistTemplate>();
            using (var conn = Db.Open())
            using (var cmd = new MySqlCommand("SELECT id, name, hours_back FROM playlist_templates ORDER BY name", conn))
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                    list.Add(new PlaylistTemplate { Id = r.GetInt("id"), Name = r.GetString("name"), HoursBack = r.GetInt("hours_back") });
            }
            return list;
        }

        /// <summary>Şablonu adetleriyle birlikte getirir.</summary>
        public PlaylistTemplate Get(int id)
        {
            PlaylistTemplate t = null;
            using (var conn = Db.Open())
            {
                using (var cmd = new MySqlCommand("SELECT id, name, hours_back FROM playlist_templates WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                            t = new PlaylistTemplate { Id = r.GetInt("id"), Name = r.GetString("name"), HoursBack = r.GetInt("hours_back") };
                    }
                }
                if (t == null) return null;

                using (var cmd = new MySqlCommand("SELECT category_id, item_count FROM playlist_template_items WHERE template_id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                            t.Counts[r.GetInt("category_id")] = r.GetInt("item_count");
                    }
                }
            }
            return t;
        }

        /// <summary>Aynı isimde şablon varsa günceller, yoksa ekler. Adetleri tamamen yeniden yazar.</summary>
        public int Save(PlaylistTemplate t)
        {
            if (string.IsNullOrWhiteSpace(t.Name))
                throw new ArgumentException("Şablon adı boş olamaz.");
            if (t.HoursBack <= 0)
                throw new ArgumentException("Saat değeri 0'dan büyük olmalı.");

            using (var conn = Db.Open())
            using (var tx = conn.BeginTransaction())
            {
                using (var cmd = new MySqlCommand(
                    "INSERT INTO playlist_templates (name, hours_back) VALUES (@name, @hours) " +
                    "ON DUPLICATE KEY UPDATE hours_back = VALUES(hours_back), id = LAST_INSERT_ID(id)", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@name", t.Name.Trim());
                    cmd.Parameters.AddWithValue("@hours", t.HoursBack);
                    cmd.ExecuteNonQuery();
                    t.Id = (int)cmd.LastInsertedId;
                }

                using (var cmd = new MySqlCommand("DELETE FROM playlist_template_items WHERE template_id = @id", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@id", t.Id);
                    cmd.ExecuteNonQuery();
                }

                foreach (var kv in t.Counts)
                {
                    using (var cmd = new MySqlCommand(
                        "INSERT INTO playlist_template_items (template_id, category_id, item_count) VALUES (@t, @c, @n)", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@t", t.Id);
                        cmd.Parameters.AddWithValue("@c", kv.Key);
                        cmd.Parameters.AddWithValue("@n", Math.Max(0, kv.Value));
                        cmd.ExecuteNonQuery();
                    }
                }
                tx.Commit();
            }
            return t.Id;
        }

        public bool Delete(int id)
        {
            using (var conn = Db.Open())
            using (var cmd = new MySqlCommand("DELETE FROM playlist_templates WHERE id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
