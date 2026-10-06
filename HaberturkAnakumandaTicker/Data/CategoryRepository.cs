using System.Collections.Generic;
using HaberturkAnakumandaTicker.Models;
using MySql.Data.MySqlClient;

namespace HaberturkAnakumandaTicker.Data
{
    public class CategoryRepository
    {
        private const string SelectSql =
            "SELECT id, code, title, separator_template, sort_order, is_active FROM categories";

        public List<Category> GetAll(bool onlyActive = false)
        {
            string sql = SelectSql + (onlyActive ? " WHERE is_active = 1" : "") + " ORDER BY sort_order, id";
            var list = new List<Category>();
            using (var conn = Db.Open())
            using (var cmd = new MySqlCommand(sql, conn))
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                    list.Add(Map(r));
            }
            return list;
        }

        public Category GetById(int id)
        {
            using (var conn = Db.Open())
            using (var cmd = new MySqlCommand(SelectSql + " WHERE id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (var r = cmd.ExecuteReader())
                    return r.Read() ? Map(r) : null;
            }
        }

        public int Insert(Category c)
        {
            const string sql =
                "INSERT INTO categories (code, title, separator_template, sort_order, is_active) " +
                "VALUES (@code, @title, @sep, @sort, @active)";
            using (var conn = Db.Open())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                AddParams(cmd, c);
                cmd.ExecuteNonQuery();
                c.Id = (int)cmd.LastInsertedId;
                return c.Id;
            }
        }

        public bool Update(Category c)
        {
            const string sql =
                "UPDATE categories SET code = @code, title = @title, separator_template = @sep, " +
                "sort_order = @sort, is_active = @active WHERE id = @id";
            using (var conn = Db.Open())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                AddParams(cmd, c);
                cmd.Parameters.AddWithValue("@id", c.Id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Kategoriye bagli mesaj varsa MySQL foreign key hatasi verir (MySqlException 1451).
        /// </summary>
        public bool Delete(int id)
        {
            using (var conn = Db.Open())
            using (var cmd = new MySqlCommand("DELETE FROM categories WHERE id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private static void AddParams(MySqlCommand cmd, Category c)
        {
            cmd.Parameters.AddWithValue("@code", c.Code);
            cmd.Parameters.AddWithValue("@title", c.Title);
            cmd.Parameters.AddWithValue("@sep", c.SeparatorTemplate);
            cmd.Parameters.AddWithValue("@sort", c.SortOrder);
            cmd.Parameters.AddWithValue("@active", c.IsActive);
        }

        private static Category Map(MySqlDataReader r)
        {
            return new Category
            {
                Id = r.GetInt("id"),
                Code = r.GetString("code"),
                Title = r.GetString("title"),
                SeparatorTemplate = r.GetString("separator_template"),
                SortOrder = r.GetInt("sort_order"),
                IsActive = r.GetBool("is_active")
            };
        }
    }
}
