using HaberturkAnakumandaTicker.Models;

namespace HaberturkAnakumandaTicker.Viz
{
    /// <summary>
    /// HT_TICKER_2026_V03 sahnesindeki isimler. Sahne değişirse sadece burası güncellenir.
    ///
    /// Template container adları "LCL_" ön ekli: ticker verisi yanlışlıkla başka bir
    /// engine'e ulaşsa bile oradaki sahnede bu template'ler olmadığı için gösterilemez.
    /// </summary>
    public static class SceneConfig
    {
        public const string SceneName = "HT_TICKER_2026_V03";

        /// <summary>Graphic Hub yolu; bağlanınca ana katmanda değilse bu sahne yüklenir.</summary>
        public const string ScenePath = "HABERTURK_2026/ANAKUMANDA/TICKER/" + SceneName;

        // ---- Layer director'ları (Scroller "Layer" ayarı)
        public const string LayerMain = "MainTickerLayer";
        public const string LayerSonDakika = "SonDakikaLayerContainer";
        public const string LayerTobleron = "TobleronLayerContainer";

        // ---- Layer director durakları
        public const string StopOut = "O";              // tüm layer'larda out durağı
        public const string StopMainTicker = "TICKER";  // MainTickerLayer: ana haber bandı
        public const string StopSdTek = "SDTEK";        // MainTickerLayer: son dakika tek satır bandı
        public const string StopBirazdan = "BIRAZDAN";  // MainTickerLayer: birazdan bandı

        // ---- SonDakikaLayerContainer durakları
        public const string StopSdCift = "TickerBuyukSonDakika";
        public const string StopSdKj = "KJSonDakika";

        /// <summary>
        /// SonDakikaLayerContainer: zaman → durak (2026-10-06 engine'de ölçüldü).
        /// 0=O, 1=KJSonDakika, 9=TickerBuyukSonDakika, ~9.98=O (SD Çift çıkışı).
        /// </summary>
        public static readonly System.Collections.Generic.Dictionary<int, string> SonDakikaLayerStopsByTime =
            new System.Collections.Generic.Dictionary<int, string>
            {
                { 0, StopOut },
                { 1, StopSdKj },
                { 9, StopSdCift },
                { 10, StopOut }
            };

        // ---- TobleronLayerContainer (2026-10-06 engine'de ölçüldü: 0=O, 1=Tobleron)
        public const string StopTobleron = "Tobleron";

        public static readonly System.Collections.Generic.Dictionary<int, string> TobleronLayerStopsByTime =
            new System.Collections.Generic.Dictionary<int, string>
            {
                { 0, StopOut },
                { 1, StopTobleron }
            };

        /// <summary>
        /// Tobleron kutuları: TOBANIM$1 ↔ TOBANIM$2 kendini tekrarlayan zincir. Her geçişte
        /// ticker_tobleron_onair değişir, Scroller reinitialize edilir ve LCL_TOBLERON'daki TEK öğe
        /// boştaki kutuya yüklenir. Bu yüzden uygulama her geçişten sonra sıradaki öğeyi gönderir.
        /// </summary>
        public const string DirectorTobAnim1 = "TOBANIM$1";
        public const string DirectorTobAnim2 = "TOBANIM$2";

        /// <summary>Shared memory alt anahtarları: anahtar + "/" + alan. Sadece yerel Viz'e yazılır.</summary>
        public const string EconomyValueField = "LCL_CF_LAST";   // ControlNum field_id (gerçek yayındaki CF_LAST'tan ayrı)
        public const string EconomyChangeField = "change";       // ControlSignContainer field_id
        public const string EconomyDecimalField = "decimalVal";  // template script'i okuyor

        // ---- Köşe logosu (LOGO_SCENE$LOGO_MAIN). Engine'e doğrudan director komutu gider.
        public const string DirectorLogo = "REKLAM_DONUS";      // ileri: logo normal (reklamdan dönüş), geri: logo al
        public const string DirectorReklamLogo = "REKLAM_VER";  // ileri: logo reklam görünümü

        /// <summary>
        /// Logo director'larının action'ları reji / reklam makinelerine uzaktan komut gönderen
        /// scriptleri tetikleyebilir (SetCornerLogo*, branding_send). Bu alanlardaki IP'lerin hepsi
        /// 127.0.0.1 (ya da boş) değilse hiçbir logo komutu gönderilmez.
        /// </summary>
        public static readonly string[] RemoteIpFieldPaths =
        {
            "reji_control_scripts$program_logo_kontrol$HIDDEN_CONTROLLERS$Reji1IP",
            "reji_control_scripts$program_logo_kontrol$HIDDEN_CONTROLLERS$Reji2IP",
            "reji_control_scripts$program_logo_kontrol$HIDDEN_CONTROLLERS$Reji3IP",
            "reji_control_scripts$program_logo_kontrol$HIDDEN_CONTROLLERS$Reji4IP",
            "reji_control_scripts$program_logo_kontrol$HIDDEN_CONTROLLERS$tcpIP",
            "REKLAM_CONTROLLERS$tcpIP"
        };

        /// <summary>SD Çift giriş animasyonunu seçen alan: ON = tobleron ekranda, OFF = değil.</summary>
        public const string TobleronStatusPath = "HIDDEN_CONTROLLERS$tobleronStatus";

        /// <summary>Bant zeminini (bant, saat) getiren director ve bitiş zamanı (sn).</summary>
        public const string DirectorTickerIn = "TICKER_IN";
        public const double TickerInEnd = 0.6;

        /// <summary>
        /// MainTickerLayer director'ında durakların zamanı (saniye) → durak adı.
        /// Her durağın birden fazla kopyası var (geçiş animasyonları farklı). 2026-10-05'te engine'de
        /// her duraktan her hedefe GOTO_TRIO yapılıp varılan zaman okunarak çıkarıldı.
        /// Katman bu duraklara gidince sahne ilgili Scroller'ı kendisi açıp kapatıyor (active).
        /// </summary>
        public static readonly System.Collections.Generic.Dictionary<int, string> MainLayerStopsByTime =
            new System.Collections.Generic.Dictionary<int, string>
            {
                { 0, StopOut },
                { 1, StopMainTicker },
                { 2, StopSdTek },
                { 3, StopOut },
                { 4, StopBirazdan },
                { 5, StopMainTicker },
                { 6, StopBirazdan },
                { 7, StopSdTek }
            };

        /// <summary>Bir ticker tipinin sahnedeki karşılığı.</summary>
        public sealed class TickerDef
        {
            public string Layer;          // Scroller Layer (director)
            public string ElementSource;  // Scroller Element Source = VizTicker ticker adı
            public string Template;       // ticker_templates altındaki container adı (<design>)
            public string Label1;         // <value label=...>: template içindeki ControlText'li container'ın adı
            public string Label2;         // 2. alanın container adı (yoksa null)
            public string Label3;         // 3. alanın container adı (yoksa null)
        }

        // Label = container adı (2026-10-05 testte doğrulandı: "text").
        // ControlText açıklaması, field_id ve template adı eşleşmedi ("property setting failed").
        // Element Source'u sadece MAIN için "LCL_TICKER" olarak değiştirdik ve doğruladık;
        // diğer scroller'lar da LCL_ ile yeniden adlandırılınca buradan güncellenecek.

        public static readonly TickerDef Main = new TickerDef
        {
            Layer = LayerMain, ElementSource = "LCL_TICKER",
            Template = "LCL_MainTicker_Template", Label1 = "text"
        };

        public static readonly TickerDef SdTek = new TickerDef
        {
            Layer = LayerMain, ElementSource = "LCL_SDTEK",
            Template = "LCL_SD_Tek", Label1 = "text"
        };

        public static readonly TickerDef Birazdan = new TickerDef
        {
            Layer = LayerMain, ElementSource = "LCL_BIRAZDAN",
            Template = "LCL_Birazdan", Label1 = "text"
        };

        public static readonly TickerDef SdCift = new TickerDef
        {
            Layer = LayerSonDakika, ElementSource = "LCL_SDCIFT",
            Template = "LCL_SD_Cift", Label1 = "text"
        };

        public static readonly TickerDef SdKj = new TickerDef
        {
            Layer = LayerSonDakika, ElementSource = "LCL_SDKJ",
            Template = "LCL_SD_KJ", Label1 = "ust_satir", Label2 = "alt_satir", Label3 = "bumper_type"
        };

        public static readonly TickerDef Tobleron = new TickerDef
        {
            Layer = LayerTobleron, ElementSource = "LCL_TOBLERON",
            Template = "LCL_Tobleron_Template", Label1 = "user_info", Label2 = "text"
        };

        /// <summary>DB'deki mesaj tipinin ticker tanımı.</summary>
        public static TickerDef For(MessageType type)
        {
            switch (type)
            {
                case MessageType.MAIN: return Main;
                case MessageType.SD_TEK: return SdTek;
                case MessageType.BIRAZDAN: return Birazdan;
                case MessageType.SD_CIFT: return SdCift;
                case MessageType.SD_KJ: return SdKj;
                default: return null;
            }
        }
    }
}
