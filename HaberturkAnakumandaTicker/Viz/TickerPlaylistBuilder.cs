using System.Collections.Generic;
using System.Linq;
using HaberturkAnakumandaTicker.Models;

namespace HaberturkAnakumandaTicker.Viz
{
    /// <summary>DB kayıtlarını VizTicker gruplarına çevirir.</summary>
    public static class TickerPlaylistBuilder
    {
        /// <summary>
        /// Ana ticker: kategori sırasıyla, her kategorinin İLK haberinin önüne kategori ayracı
        /// (LCL_GUNDEM_IN vb.) eklenir. Ayraç Scroller'a girince ScrollerAction ile kategori
        /// director'ını (EKONOMI_IN...) oynatır ve o kategorinin kulakçığı çıkar.
        /// Her haber ayrı bir gruptur.
        /// </summary>
        public static List<TickerGroup> BuildMain(IEnumerable<Category> categories, IEnumerable<TickerMessage> playable)
        {
            var def = SceneConfig.Main;
            var groups = new List<TickerGroup>();
            var messages = playable.ToList();
            int n = 0;

            foreach (var cat in categories.Where(c => c.IsActive).OrderBy(c => c.SortOrder))
            {
                bool first = true;
                // Kategori içindeki sıra, verilen listenin sırası (DB'den Gönder: sort_order,
                // Yayın Listesi: en yeni önce). Burada yeniden sıralanmıyor.
                foreach (var m in messages.Where(x => x.CategoryId == cat.Id))
                {
                    var g = new TickerGroup("main_" + (++n));
                    int key = 1;
                    if (first && !string.IsNullOrEmpty(cat.SeparatorTemplate))
                        g.Add(new TickerElement(key++, cat.SeparatorTemplate));
                    g.Add(new TickerElement(key, def.Template).Value(def.Label1, m.Text1));
                    groups.Add(g);
                    first = false;
                }
            }
            return groups;
        }

        /// <summary>Tek template'li tipler (SD_TEK, BIRAZDAN, SD_CIFT, SD_KJ).</summary>
        public static List<TickerGroup> BuildSimple(MessageType type, IEnumerable<TickerMessage> playable)
        {
            var def = SceneConfig.For(type);
            var groups = new List<TickerGroup>();
            int n = 0;
            foreach (var m in playable.OrderBy(x => x.SortOrder))
            {
                var e = new TickerElement(1, def.Template).Value(def.Label1, m.Text1);
                if (type == MessageType.SD_KJ)
                {
                    e.Value(def.Label2, m.Text2 ?? "");
                    e.Value(def.Label3, ((int)m.BumperType).ToString());
                }
                groups.Add(new TickerGroup(type.ToString().ToLowerInvariant() + "_" + (++n)).Add(e));
            }
            return groups;
        }
    }
}
