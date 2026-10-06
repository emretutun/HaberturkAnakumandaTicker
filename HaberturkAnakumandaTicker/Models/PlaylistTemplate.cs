using System.Collections.Generic;

namespace HaberturkAnakumandaTicker.Models
{
    /// <summary>
    /// playlist_templates + playlist_template_items: "son X saatteki haberlerden
    /// kategori başına N adet" yayın listesi şablonu.
    /// </summary>
    public class PlaylistTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HoursBack { get; set; }

        /// <summary>CategoryId → adet.</summary>
        public Dictionary<int, int> Counts { get; set; }

        public PlaylistTemplate()
        {
            HoursBack = 24;
            Counts = new Dictionary<int, int>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
