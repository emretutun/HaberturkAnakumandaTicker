namespace HaberturkAnakumandaTicker.Models
{
    /// <summary>
    /// categories tablosu. Ana ticker kategorisi ve sahnedeki ayrac template'i.
    /// </summary>
    public class Category
    {
        public int Id { get; set; }

        /// <summary>DUNYA, EKONOMI, GUNDEM, HAVAYOL, SPOR</summary>
        public string Code { get; set; }

        /// <summary>Ekranda gorunen baslik (GÜNDEM, DÜNYA...)</summary>
        public string Title { get; set; }

        /// <summary>Sahnedeki ayrac template adi (DUNYA_IN vb.)</summary>
        public string SeparatorTemplate { get; set; }

        public int SortOrder { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
