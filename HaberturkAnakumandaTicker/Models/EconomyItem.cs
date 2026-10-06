using System;

namespace HaberturkAnakumandaTicker.Models
{
    /// <summary>
    /// economy_items tablosu. Tobleron'da (TobleronLayerContainer$EKONOMI_DATA) dönen bir veri.
    /// </summary>
    public class EconomyItem
    {
        public int Id { get; set; }

        /// <summary>Ekranda görünen ad (template'teki user_info alanı).</summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Shared memory anahtarı, örnek: "/economy/1604". Sahne script'i "/" ile bölüp
        /// 3. parçayı (index 2) EKONOMI_LOGOS altındaki logo adı olarak kullanıyor.
        /// </summary>
        public string ShmBaseKey { get; set; }

        /// <summary>Boş ise sahne 2 basamak kullanır.</summary>
        public byte? DecimalPlaces { get; set; }

        /// <summary>Son değer (boşsa Viz'e değer yazılmaz).</summary>
        public decimal? Value { get; set; }

        /// <summary>Yön: 1 artış, -1 düşüş, 0 değişim yok (sahnedeki change container'ı).</summary>
        public int Change { get; set; }

        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdatedAt { get; set; }

        public EconomyItem Clone()
        {
            return (EconomyItem)MemberwiseClone();
        }

        /// <summary>Logo kodu (anahtarın son parçası, örnek: 1604).</summary>
        public string LogoCode
        {
            get
            {
                var p = (ShmBaseKey ?? "").Split('/');
                return p.Length >= 3 ? p[2] : "";
            }
        }
    }
}
