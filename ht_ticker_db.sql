-- =====================================================================
-- HT_TICKER_2026_V02 Anakumanda - test / ogrenme veritabani
-- MySQL 8.x  |  localhost:3306
-- Sahne: HABERTURK_2026/ANAKUMANDA/TICKER/HT_TICKER_2026_V02
-- =====================================================================

CREATE DATABASE IF NOT EXISTS ht_ticker
  CHARACTER SET utf8mb4
  COLLATE utf8mb4_turkish_ci;

USE ht_ticker;

-- ---------------------------------------------------------------------
-- 1) Kategoriler -> ana ticker ayraclari (ticker_templates/*_IN)
--    separator_template: sahnedeki ayrac template adi (DUNYA_IN vb.)
-- ---------------------------------------------------------------------
CREATE TABLE categories (
  id                  INT AUTO_INCREMENT PRIMARY KEY,
  code                VARCHAR(20)  NOT NULL UNIQUE,   -- DUNYA, EKONOMI, GUNDEM, HAVAYOL, SPOR
  title               VARCHAR(50)  NOT NULL,          -- ekranda gorunen baslik
  separator_template  VARCHAR(50)  NOT NULL,          -- DUNYA_IN ...
  sort_order          INT          NOT NULL DEFAULT 0,
  is_active           TINYINT(1)   NOT NULL DEFAULT 1
);

-- ---------------------------------------------------------------------
-- 2) Ticker mesajlari -> tum metin template'leri tek tabloda
--
--   message_type   template              layer                    alanlar
--   ------------   -------------------   -----------------------  ---------------------------
--   MAIN           MainTicker_Template   MainTickerLayer / MAIN   text1 (field 1), category_id
--   SD_TEK         SD_Tek                MainTickerLayer / SDTEK  text1 (field 1)
--   BIRAZDAN       Birazdan              MainTickerLayer / BIRAZDAN text1 (field 1)
--   SD_CIFT        SD_Cift               SonDakikaLayer / SDCIFT  text1 (field 1)
--   SD_KJ          SD_KJ                 SonDakikaLayer / SDKJ    text1 (1), text2 (2), bumper_type (3)
--
--   bumper_type (sadece SD_KJ): 0 = bumpersiz, 1 = bumperli sessiz, 2 = bumperli sesli
-- ---------------------------------------------------------------------
CREATE TABLE ticker_messages (
  id            INT AUTO_INCREMENT PRIMARY KEY,
  message_type  ENUM('MAIN','SD_TEK','BIRAZDAN','SD_CIFT','SD_KJ') NOT NULL,
  category_id   INT          NULL,                    -- sadece MAIN icin
  text1         VARCHAR(500) NOT NULL,
  text2         VARCHAR(500) NULL,                    -- sadece SD_KJ alt satir
  bumper_type   TINYINT      NOT NULL DEFAULT 0,      -- sadece SD_KJ
  sort_order    INT          NOT NULL DEFAULT 0,
  is_active     TINYINT(1)   NOT NULL DEFAULT 1,
  valid_from    DATETIME     NULL,                    -- bos = hemen gecerli
  valid_to      DATETIME     NULL,                    -- bos = suresiz
  created_at    DATETIME     NOT NULL DEFAULT CURRENT_TIMESTAMP,
  updated_at    DATETIME     NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  CONSTRAINT fk_msg_category FOREIGN KEY (category_id) REFERENCES categories(id),
  CONSTRAINT chk_bumper CHECK (bumper_type IN (0,1,2)),
  INDEX ix_type_active (message_type, is_active, sort_order)
);

-- ---------------------------------------------------------------------
-- 3) Ekonomi verileri -> Tobleron_Template (TobleronLayerContainer)
--    field 1 = display_name, field 2 = shm_base_key
--    Sahne script'i shm_base_key'i "/" ile boluyor; 3. parca (index 2)
--    EKONOMI_LOGOS klasorundeki logo adi. Ornek: "/economy/1604" (BIST)
--    decimal_places bos ise sahne 2 kullaniyor.
-- ---------------------------------------------------------------------
CREATE TABLE economy_items (
  id              INT AUTO_INCREMENT PRIMARY KEY,
  display_name    VARCHAR(50)  NOT NULL,
  shm_base_key    VARCHAR(100) NOT NULL,
  decimal_places  TINYINT      NULL,
  value_num       DECIMAL(18,6) NULL,
  change_dir      TINYINT      NOT NULL DEFAULT 0,
  sort_order      INT          NOT NULL DEFAULT 0,
  is_active       TINYINT(1)   NOT NULL DEFAULT 1,
  updated_at      DATETIME     NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- ---------------------------------------------------------------------
-- 4) Ayarlar -> sahnedeki gizli kontrol container'larina yazilacak degerler
--    viz_container: Viz'e gonderilecek container yolu (GEOM*TEXT SET)
-- ---------------------------------------------------------------------
CREATE TABLE app_settings (
  setting_key    VARCHAR(50)  PRIMARY KEY,
  setting_value  VARCHAR(255) NOT NULL,
  viz_container  VARCHAR(100) NULL,
  description    VARCHAR(255) NULL
);

-- =====================================================================
-- Ornek veriler
-- =====================================================================
INSERT INTO categories (code, title, separator_template, sort_order) VALUES
  ('GUNDEM',  'GÜNDEM',  'GUNDEM_IN',  1),
  ('DUNYA',   'DÜNYA',   'DUNYA_IN',   2),
  ('EKONOMI', 'EKONOMİ', 'EKONOMI_IN', 3),
  ('SPOR',    'SPOR',    'SPOR_IN',    4),
  ('HAVAYOL', 'HAVAYOLU','HAVAYOL_IN', 5);

INSERT INTO ticker_messages (message_type, category_id, text1, sort_order) VALUES
  ('MAIN', 1, 'Test gündem haberi 1', 1),
  ('MAIN', 1, 'Test gündem haberi 2', 2),
  ('MAIN', 2, 'Test dünya haberi 1', 1),
  ('MAIN', 3, 'Test ekonomi haberi 1', 1),
  ('MAIN', 4, 'Test spor haberi 1', 1);

INSERT INTO ticker_messages (message_type, text1, sort_order) VALUES
  ('SD_TEK',   'TEST SON DAKİKA TEK SATIR', 1),
  ('BIRAZDAN', 'Birazdan: Test Programı', 1),
  ('SD_CIFT',  'TEST BÜYÜK SON DAKİKA', 1);

INSERT INTO ticker_messages (message_type, text1, text2, bumper_type, sort_order) VALUES
  ('SD_KJ', 'SON DAKİKA ÜST SATIR', 'Alt satır test metni', 0, 1);

INSERT INTO economy_items (display_name, shm_base_key, decimal_places, value_num, change_dir, sort_order) VALUES
  ('BIST 100', '/economy/1604', 2, 14300.55,  1, 1),
  ('DOLAR',    '/economy/1590', 4, 48.7001,  -1, 2),
  ('EURO',     '/economy/1586', 4, 52.315,    0, 3),
  ('ALTIN',    '/economy/1415', 2, 5123.40,   1, 4);

INSERT INTO app_settings (setting_key, setting_value, viz_container, description) VALUES
  ('viz_host',            '127.0.0.1', NULL, 'SADECE 127.0.0.1 - degistirilmez'),
  ('viz_port',            '6100',      NULL, 'Viz Engine portu'),
  ('tobleron_status',     'ON',        'HIDDEN_CONTROLLERS$tobleronStatus', 'SD Cift animasyon secimi ON/OFF'),
  ('sd_kj_type',          'NORMAL',    'SonDkKj$type',                      'NORMAL / YAS'),
  ('sd_main_volume_on',   '1',         'SonDkKj$isMainSdBumperVolumeOn',    'Master ses 0/1'),
  ('sd_volume_on',        '1',         'SonDkKj$isSdBumperVolumeOn',        'Mesaj bazli ses 0/1'),
  ('sd_volume_level',     '55',        'SonDkKj$SdBumperVolumeControl',     'Bumper ses seviyesi'),
  ('ramazan_status',      '0',         'HIDDEN_CONTROLLERS$ramazanStatus',  'Ramazan banner 0/1'),
  ('ramazan_city_list',   '6,34,35',   'sabitList',                         'Iftar/imsak sehir plakalari');

-- =====================================================================
-- Yayın listesi şablonları (2026-10-05 eklendi)
-- =====================================================================
-- Yayın listesi şablonları: "son X saatteki haberlerden kategori başına N adet"
CREATE TABLE IF NOT EXISTS playlist_templates (
  id          INT AUTO_INCREMENT PRIMARY KEY,
  name        VARCHAR(100) NOT NULL UNIQUE,
  hours_back  INT          NOT NULL DEFAULT 24,
  created_at  DATETIME     NOT NULL DEFAULT CURRENT_TIMESTAMP,
  updated_at  DATETIME     NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS playlist_template_items (
  template_id  INT NOT NULL,
  category_id  INT NOT NULL,
  item_count   INT NOT NULL DEFAULT 0,
  PRIMARY KEY (template_id, category_id),
  CONSTRAINT fk_pti_template FOREIGN KEY (template_id) REFERENCES playlist_templates(id) ON DELETE CASCADE,
  CONSTRAINT fk_pti_category FOREIGN KEY (category_id) REFERENCES categories(id) ON DELETE CASCADE
);

-- Örnek şablon: son 24 saat, 10 genel + 3 spor + 3 dünya
INSERT INTO playlist_templates (name, hours_back)
SELECT 'Örnek: 10 genel + 3 spor + 3 dünya', 24 FROM DUAL
WHERE NOT EXISTS (SELECT 1 FROM playlist_templates WHERE name = 'Örnek: 10 genel + 3 spor + 3 dünya');

INSERT IGNORE INTO playlist_template_items (template_id, category_id, item_count)
SELECT t.id, c.id, CASE c.code WHEN 'GENEL' THEN 10 WHEN 'SPOR' THEN 3 WHEN 'DUNYA' THEN 3 ELSE 0 END
FROM playlist_templates t CROSS JOIN categories c
WHERE t.name = 'Örnek: 10 genel + 3 spor + 3 dünya';

SELECT t.name, t.hours_back, c.code, i.item_count
FROM playlist_templates t JOIN playlist_template_items i ON i.template_id = t.id JOIN categories c ON c.id = i.category_id
ORDER BY c.sort_order;
