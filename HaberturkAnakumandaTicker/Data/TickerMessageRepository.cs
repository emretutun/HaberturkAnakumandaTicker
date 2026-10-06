using System;
using System.Collections.Generic;
using HaberturkAnakumandaTicker.Models;
using MySql.Data.MySqlClient;

namespace HaberturkAnakumandaTicker.Data
{
    public class TickerMessageRepository
    {
        private const string SelectSql =
            "SELECT id, message_type, category_id, text1, text2, bumper_type, sort_order, is_active, " +
            "valid_from, valid_to, created_at, updated_at FROM ticker_messages";

        public List<TickerMessage> GetAll()
        {
            return Query(SelectSql + " ORDER BY message_type, category_id, sort_order, id", null);
        }

        /// <summary>Bir template tipinin tum mesajlari (CRUD listeleri icin).</summary>
        public List<TickerMessage> GetByType(MessageType type)
        {
            return Query(SelectSql + " WHERE message_type = @type ORDER BY category_id, sort_order, id",
                cmd => cmd.Parameters.AddWithValue("@type", type.ToString()));
        }

        /// <summary>
        /// Yayina gidebilecek mesajlar: aktif ve su an gecerlilik araliginda.
        /// MAIN icin kategori sirasina gore gelir (ayrac -> haberler -> ayrac -> ...).
        /// </summary>
        public List<TickerMessage> GetPlayable(MessageType type)
        {
            const string where =
                " m WHERE m.message_type = @type AND m.is_active = 1" +
                " AND (m.valid_from IS NULL OR m.valid_from <= NOW())" +
                " AND (m.valid_to IS NULL OR m.valid_to >= NOW())";

            string sql = type == MessageType.MAIN
                ? SelectSql + where +
                  " AND EXISTS (SELECT 1 FROM categories c WHERE c.id = m.category_id AND c.is_active = 1)" +
                  " ORDER BY (SELECT c.sort_order FROM categories c WHERE c.id = m.category_id), m.sort_order, m.id"
                : SelectSql + where + " ORDER BY m.sort_order, m.id";

            return Query(sql, cmd => cmd.Parameters.AddWithValue("@type", type.ToString()));
        }

        /// <summary>
        /// Yayın listesi için: bir kategorinin, verilen tarih aralığında GİRİLMİŞ (created_at),
        /// aktif ve şu an geçerli MAIN mesajlarından en yeni <paramref name="limit"/> tanesi.
        /// </summary>
        public List<TickerMessage> GetLatestForPlaylist(int categoryId, DateTime from, DateTime to, int limit)
        {
            if (limit <= 0) return new List<TickerMessage>();
            const string where =
                " WHERE message_type = 'MAIN' AND category_id = @cat AND is_active = 1" +
                " AND (valid_from IS NULL OR valid_from <= NOW())" +
                " AND (valid_to IS NULL OR valid_to >= NOW())" +
                " AND created_at BETWEEN @from AND @to" +
                " ORDER BY created_at DESC, id DESC LIMIT @limit";
            return Query(SelectSql + where, cmd =>
            {
                cmd.Parameters.AddWithValue("@cat", categoryId);
                cmd.Parameters.AddWithValue("@from", from);
                cmd.Parameters.AddWithValue("@to", to);
                cmd.Parameters.AddWithValue("@limit", limit);
            });
        }

        public TickerMessage GetById(int id)
        {
            var list = Query(SelectSql + " WHERE id = @id", cmd => cmd.Parameters.AddWithValue("@id", id));
            return list.Count > 0 ? list[0] : null;
        }

        public int Insert(TickerMessage m)
        {
            Validate(m);
            const string sql =
                "INSERT INTO ticker_messages (message_type, category_id, text1, text2, bumper_type, sort_order, is_active, valid_from, valid_to) " +
                "VALUES (@type, @cat, @t1, @t2, @bumper, @sort, @active, @from, @to)";
            using (var conn = Db.Open())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                AddParams(cmd, m);
                cmd.ExecuteNonQuery();
                m.Id = (int)cmd.LastInsertedId;
                return m.Id;
            }
        }

        public bool Update(TickerMessage m)
        {
            Validate(m);
            const string sql =
                "UPDATE ticker_messages SET message_type = @type, category_id = @cat, text1 = @t1, text2 = @t2, " +
                "bumper_type = @bumper, sort_order = @sort, is_active = @active, valid_from = @from, valid_to = @to " +
                "WHERE id = @id";
            using (var conn = Db.Open())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                AddParams(cmd, m);
                cmd.Parameters.AddWithValue("@id", m.Id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var conn = Db.Open())
            using (var cmd = new MySqlCommand("DELETE FROM ticker_messages WHERE id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>Tip kurallari: MAIN kategorisiz olamaz, text2/bumper sadece SD_KJ'de anlamli.</summary>
        private static void Validate(TickerMessage m)
        {
            if (string.IsNullOrWhiteSpace(m.Text1))
                throw new ArgumentException("Metin (text1) bos olamaz.");
            if (m.MessageType == MessageType.MAIN && !m.CategoryId.HasValue)
                throw new ArgumentException("MAIN mesajinin kategorisi secilmeli.");
            if (m.ValidFrom.HasValue && m.ValidTo.HasValue && m.ValidFrom > m.ValidTo)
                throw new ArgumentException("Baslangic tarihi bitis tarihinden sonra olamaz.");

            if (m.MessageType != MessageType.MAIN)
                m.CategoryId = null;
            if (m.MessageType != MessageType.SD_KJ)
            {
                m.Text2 = null;
                m.BumperType = BumperType.Yok;
            }
        }

        private static void AddParams(MySqlCommand cmd, TickerMessage m)
        {
            cmd.Parameters.AddWithValue("@type", m.MessageType.ToString());
            cmd.Parameters.AddWithValue("@cat", Db.ToDb(m.CategoryId));
            cmd.Parameters.AddWithValue("@t1", m.Text1);
            cmd.Parameters.AddWithValue("@t2", Db.ToDb(string.IsNullOrWhiteSpace(m.Text2) ? null : m.Text2));
            cmd.Parameters.AddWithValue("@bumper", (byte)m.BumperType);
            cmd.Parameters.AddWithValue("@sort", m.SortOrder);
            cmd.Parameters.AddWithValue("@active", m.IsActive);
            cmd.Parameters.AddWithValue("@from", Db.ToDb(m.ValidFrom));
            cmd.Parameters.AddWithValue("@to", Db.ToDb(m.ValidTo));
        }

        private static List<TickerMessage> Query(string sql, Action<MySqlCommand> addParams)
        {
            var list = new List<TickerMessage>();
            using (var conn = Db.Open())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                addParams?.Invoke(cmd);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                        list.Add(Map(r));
                }
            }
            return list;
        }

        private static TickerMessage Map(MySqlDataReader r)
        {
            return new TickerMessage
            {
                Id = r.GetInt("id"),
                MessageType = (MessageType)Enum.Parse(typeof(MessageType), r.GetString("message_type")),
                CategoryId = r.GetIntOrNull("category_id"),
                Text1 = r.GetString("text1"),
                Text2 = r.GetStringOrNull("text2"),
                BumperType = (BumperType)r.GetInt("bumper_type"),
                SortOrder = r.GetInt("sort_order"),
                IsActive = r.GetBool("is_active"),
                ValidFrom = r.GetDateTimeOrNull("valid_from"),
                ValidTo = r.GetDateTimeOrNull("valid_to"),
                CreatedAt = r.GetDateTime("created_at"),
                UpdatedAt = r.GetDateTime("updated_at")
            };
        }
    }
}
