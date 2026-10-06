using System.Collections.Generic;
using System.Security;
using System.Text;

namespace HaberturkAnakumandaTicker.Viz
{
    /// <summary>VizTicker grubundaki tek eleman: bir template ve alan değerleri.</summary>
    public sealed class TickerElement
    {
        public int Key;
        public string Design;              // ticker_templates altındaki template container adı
        public int Ttl = -1;               // -1 = sürekli döner, 1 = bir kez gösterilir
        public readonly List<KeyValuePair<string, string>> Values = new List<KeyValuePair<string, string>>();

        public TickerElement(int key, string design)
        {
            Key = key;
            Design = design;
        }

        /// <summary>label = template içindeki container adı (ör. "text").</summary>
        public TickerElement Value(string label, string text)
        {
            if (!string.IsNullOrEmpty(label))
                Values.Add(new KeyValuePair<string, string>(label, text ?? ""));
            return this;
        }
    }

    /// <summary>VizTicker grubu. Scroller grupları sırayla gösterir.</summary>
    public sealed class TickerGroup
    {
        public readonly string Name;
        public readonly List<TickerElement> Elements = new List<TickerElement>();

        public TickerGroup(string name)
        {
            Name = name;
        }

        public TickerGroup Add(TickerElement e)
        {
            Elements.Add(e);
            return this;
        }

        public string ToXml()
        {
            var sb = new StringBuilder();
            sb.Append("<group name=\"").Append(TickerXml.Escape(Name)).Append("\">");
            foreach (var e in Elements)
            {
                sb.Append("<element key=\"").Append(e.Key).Append("\">");
                sb.Append("<design>").Append(TickerXml.Escape(e.Design)).Append("</design>");
                sb.Append("<ttl>").Append(e.Ttl).Append("</ttl>");
                foreach (var v in e.Values)
                {
                    sb.Append("<value label=\"").Append(TickerXml.Escape(v.Key)).Append("\" attribute=\"text\">")
                      .Append(TickerXml.Text(v.Value))
                      .Append("</value>");
                }
                sb.Append("</element>");
            }
            sb.Append("</group>");
            return sb.ToString();
        }
    }

    public static class TickerXml
    {
        /// <summary>
        /// Eski projelerdeki ConvertStupidEncoding dönüşümü (harf tablosu). Bu sistemde ekranda
        /// "├Ç" gibi bozuk çıkıyor (test edildi); sadece deneme için duruyor, varsayılan kapalı.
        /// </summary>
        public static bool LegacyTurkishEncoding { get; set; }

        /// <summary>
        /// TickerService'e gidecek XML'i hazırlar: ASCII dışı bütün karakterler XML sayısal
        /// karakter referansına çevrilir (ü → &amp;#252;). XML tamamen ASCII olduğu için COM/kod sayfası
        /// dönüşümlerinden etkilenmez; servisin XML parser'ı referansları doğru harfe çözer.
        ///
        /// 2026-10-05'te sahnede test edildi (LCL_TICKER, "ÇçĞğİıÖöŞşÜü"):
        ///  - sayısal referans → doğru  ✔ (bu yöntem)
        ///  - ham metin         → bu testte doğru, ama daha önce servis logunda "Parse error" vermişti
        ///  - UTF-8 baytlarını ANSI olarak göndermek → "Ã‡Ã§..." (bozuk)
        ///  - eski ConvertStupidEncoding → "├Ç├ç..." (bozuk)
        /// </summary>
        public static string ForService(string xml)
        {
            if (string.IsNullOrEmpty(xml)) return "";
            var sb = new StringBuilder(xml.Length + 32);
            for (int i = 0; i < xml.Length; i++)
            {
                char ch = xml[i];
                if (ch < 128)
                {
                    sb.Append(ch);
                }
                else if (char.IsHighSurrogate(ch) && i + 1 < xml.Length && char.IsLowSurrogate(xml[i + 1]))
                {
                    sb.Append("&#").Append(char.ConvertToUtf32(ch, xml[i + 1])).Append(';');
                    i++;
                }
                else
                {
                    sb.Append("&#").Append((int)ch).Append(';');
                }
            }
            return sb.ToString();
        }

        public static string Escape(string s)
        {
            return SecurityElement.Escape(s ?? "");
        }

        /// <summary>Değer metni: XML kaçışı + (gerekirse) eski Türkçe dönüşümü.</summary>
        public static string Text(string s)
        {
            string escaped = Escape(s);
            return LegacyTurkishEncoding ? ConvertLegacyTurkish(escaped) : escaped;
        }

        private static string ConvertLegacyTurkish(string s)
        {
            return s.Replace("Ç", "├Ç").Replace("ç", "├ç")
                    .Replace("Ö", "├Ö").Replace("ö", "├ö")
                    .Replace("ı", "├ı").Replace("İ", "├İ")
                    .Replace("Ğ", "├Ğ").Replace("ğ", "├ğ")
                    .Replace("Ş", "├Ş").Replace("ş", "├ş")
                    .Replace("Ü", "├Ü").Replace("ü", "├ü");
        }
    }
}
