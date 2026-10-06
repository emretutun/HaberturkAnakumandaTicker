# Habertürk Anakumanda Ticker 2026

Bu bir test projesidir gerçekliği bulunmamaktadır.

`HT_TICKER_2026_V03` Viz sahnesini **VizTickerService** ve Viz Engine komutlarıyla yöneten
Windows Forms (.NET Framework 4.8) anakumanda uygulaması. Veriler yerel MySQL'den gelir.

> **Test / öğrenme projesi.** Uygulama yalnızca bu bilgisayardaki Viz Engine'e
> (`127.0.0.1:6100`) ve VizTickerService'e komut gönderir. Ayrıntılar: [Güvenlik](#güvenlik).

## Özellikler

| Sekme | Ne yapar |
|---|---|
| **Ana Bant** | Tarih aralığı + kategori başına adet ile yayın listesi oluşturur, elle düzeltilebilir, şablon olarak kaydedilir. Kulakçıklı kategorilerde en az 3 haber zorunlu. **ANA BANDI VER / AL**. |
| **Son Dakika** | Tek satır (SD Tek) ya da iki satır (SD KJ). Yaz → *Ekle ve Hemen Yayına Al* → *Yayından Al*. Ana bant kapalıysa bandı ve zemini kendisi getirir. |
| **Birazdan** | Birazdan bandı, Son Dakika ile aynı akış. |
| **Tobleron** | Ekonomi verileri (BIST, dolar, euro, altın…). Değerler Viz shared memory'ye yazılır, kutular sırayla döner. DB 2 sn'de bir kontrol edilir; değişen değer ekranda canlı güncellenir, yön (▲/▼) otomatik belirlenir. |
| **⚙ Yönetim** | Haber, kategori, son dakika / birazdan listeleri, ekonomi verileri, ayarlar ve gelişmiş/log ekranı. |

Üst panel: bağlantı durumu, ana bant / son dakika durumu ve **LOGO VER / LOGO AL / REKLAM LOGO** butonları.
Uygulama açılınca otomatik bağlanır; sahne ana katmanda yüklü değilse yükler.

## Gereksinimler

- Windows, Visual Studio 2022+ (.NET Framework 4.8 hedefi)
- Viz Engine 3.14 (aynı makinede, `127.0.0.1:6100`)
- VizTickerService 3.1 (aynı makinede, yönetici olarak çalışıyor)
- MySQL 8 (yerel)
- Graphic Hub'da `HABERTURK_2026/ANAKUMANDA/TICKER/HT_TICKER_2026_V03` sahnesi

## Kurulum

1. **Veritabanı:** `ht_ticker_db.sql` dosyasını MySQL'de çalıştırın (`ht_ticker` veritabanını ve örnek verileri oluşturur).
2. **Bağlantı:** `HaberturkAnakumandaTicker/App.config` içindeki `connectionString`'i kendi MySQL kullanıcı/şifrenize göre düzenleyin.
3. **Derleme:** `HaberturkAnakumandaTicker.slnx`'i açıp **x86 / Debug** derleyin.
   VizTicker COM interop'u `HaberturkAnakumandaTicker/lib/Interop.VIZTICKERLib.dll` olarak projede.
4. **Çalıştırma:** Uygulama **yönetici olarak** çalışır (`app.manifest` → `requireAdministrator`),
   çünkü VizTickerService yönetici olarak çalışıyor; aksi halde COM bağlantısı `CO_E_SERVER_EXEC_FAILURE` verir.
5. Viz Engine **On Air** modunda olmalı (director komutları başka modda reddedilir).

## Sahne ayarları (V03)

Yayındaki sahneyi bozmamak için test sahnesi V02'den kopyalandı ve şu isimler `LCL_` ile değiştirildi.
Veri yanlışlıkla başka bir engine'e gitse bile oradaki sahnede bu isimler olmadığı için gösterilmez.

| Ne | Değer |
|---|---|
| Scroller Element Source'ları | `LCL_TICKER`, `LCL_SDTEK`, `LCL_BIRAZDAN`, `LCL_SDCIFT`, `LCL_SDKJ`, `LCL_TOBLERON` |
| Template'ler | `ticker_templates` altında `LCL_…` |
| Tobleron değer alanı | ControlNum field `LCL_CF_LAST` (her iki kutuda) |
| Uzak IP alanları | `Reji1IP`–`Reji4IP`, `tcpIP` (2 adet) = `127.0.0.1` |

Bütün sahne isimleri tek yerde: `Viz/SceneConfig.cs`.

## Nasıl çalışır (kısa)

- **Ticker verisi:** `VizTickerManager` → VizTickerService COM (`AddTicker` / `AddGroupAfterGroup`), olaylar `127.0.0.1:6301` tickertalk üzerinden dinlenir. Türkçe karakterler XML'de sayısal referans (`&#304;`) olarak gönderilir.
- **Grafik ver/al:** `Broadcaster` → layer director'larında `GOTO_TRIO` (bulunduğu durak director zamanından okunur). Bant zemini için `TICKER_IN` oynatılır.
- **Tobleron:** Değerler `/economy/<logo>/LCL_CF_LAST`, `/change`, `/decimalVal` shared memory anahtarlarına yazılır. `LCL_TOBLERON`'da her zaman tek öğe olur; `TOBANIM` her geçişte scroller'ı yeniler, uygulama servisten gelen `run` olayından 2 sn sonra sıradaki öğeyi gönderir.
- **Logo:** `REKLAM_DONUS` (ileri = logo ver / reklamdan dönüş, geri = logo al), `REKLAM_VER` (reklam logo).

## Güvenlik

Uygulama yayın ağındaki bir makinede çalıştığı için şu kurallar kodda zorunlu:

- Viz Engine adresi sabit `127.0.0.1:6100`; değiştirilemez. İçinde `127.0.0.1` dışında IPv4 adresi geçen komut gönderilmez.
- VizTickerService'e yalnızca aynı makinedeki COM sunucusu üzerinden bağlanılır; tam olarak 1 `TickerService` süreci yoksa bağlanılmaz. Tickertalk bağlantısı yalnızca loopback'e açılır.
- Logo komutlarından önce sahnedeki uzak IP alanları okunur; biri `127.0.0.1` değilse komut gönderilmez.
- Shared memory yazımları yereldir (engine config'te `smm_udp_service` / `smm_tcp_service` = `NONE`).
- Uygulama Viz ve VizTickerService ayarlarını değiştirmez.

## Proje yapısı

```
HaberturkAnakumandaTicker/
  Data/      MySQL repository'leri (Db.cs, *Repository.cs)
  Models/    Veri sınıfları
  Viz/       VizEngineClient, VizTickerManager, Broadcaster, TobleronController, SceneConfig, TickerXml
  UI/        Ekranlar (UserControl + .Designer.cs, Visual Studio Designer ile düzenlenebilir)
  lib/       Interop.VIZTICKERLib.dll
ht_ticker_db.sql   Veritabanı şeması ve örnek veriler
```

Kaynak dosyalar **UTF-8 (BOM'lu)** kaydedilir (`.editorconfig`); Türkçe karakterler için bu gerekli.
