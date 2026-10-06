namespace HaberturkAnakumandaTicker.Models
{
    /// <summary>
    /// app_settings tablosu. Sahnedeki gizli kontrol container'larina yazilacak degerler.
    /// </summary>
    public class AppSetting
    {
        public string Key { get; set; }
        public string Value { get; set; }

        /// <summary>Degerin yazilacagi Viz container yolu (ornek: HIDDEN_CONTROLLERS$tobleronStatus). Bos olabilir.</summary>
        public string VizContainer { get; set; }

        public string Description { get; set; }
    }
}
