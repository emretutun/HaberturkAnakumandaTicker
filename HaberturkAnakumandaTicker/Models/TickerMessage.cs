using System;

namespace HaberturkAnakumandaTicker.Models
{
    /// <summary>
    /// ticker_messages.message_type ile birebir ayni isimler (DB'de ENUM string olarak tutuluyor).
    /// </summary>
    public enum MessageType
    {
        MAIN,       // MainTicker_Template  -> MainTickerLayer / MAIN
        SD_TEK,     // SD_Tek               -> MainTickerLayer / SDTEK
        BIRAZDAN,   // Birazdan             -> MainTickerLayer / BIRAZDAN
        SD_CIFT,    // SD_Cift              -> SonDakikaLayerContainer / SDCIFT
        SD_KJ       // SD_KJ                -> SonDakikaLayerContainer / SDKJ
    }

    /// <summary>
    /// SD_KJ bumper davranisi (sahnedeki bumper_type, field 3).
    /// </summary>
    public enum BumperType : byte
    {
        Yok = 0,
        Sessiz = 1,
        Sesli = 2
    }

    /// <summary>
    /// ticker_messages tablosu. Tum metin template'leri tek tabloda.
    /// </summary>
    public class TickerMessage
    {
        public int Id { get; set; }
        public MessageType MessageType { get; set; }

        /// <summary>Sadece MAIN icin dolu.</summary>
        public int? CategoryId { get; set; }

        /// <summary>Field 1 (KJ'de ust satir).</summary>
        public string Text1 { get; set; }

        /// <summary>Field 2 - sadece SD_KJ alt satir.</summary>
        public string Text2 { get; set; }

        /// <summary>Field 3 - sadece SD_KJ.</summary>
        public BumperType BumperType { get; set; }

        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        /// <summary>Aktif mi ve verilen anda gecerlilik araliginda mi?</summary>
        public bool IsPlayableAt(DateTime now)
        {
            return IsActive
                && (!ValidFrom.HasValue || ValidFrom.Value <= now)
                && (!ValidTo.HasValue || ValidTo.Value >= now);
        }
    }
}
