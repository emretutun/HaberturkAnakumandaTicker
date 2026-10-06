using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace HaberturkAnakumandaTicker.Viz
{
    /// <summary>Viz Engine'in "ERROR ..." cevabı ya da güvenlik kuralı ihlali.</summary>
    public class VizException : Exception
    {
        public VizException(string message) : base(message) { }
    }

    /// <summary>
    /// Viz Engine komut istemcisi (TCP, "id komut\0" protokolü).
    ///
    /// GÜVENLİK KURALLARI:
    ///  1) Adres kodda sabit: 127.0.0.1:6100. Dışarıdan değiştirilemez.
    ///  2) Bağlantıdan önce ve sonra uç noktanın loopback olduğu doğrulanır.
    ///  3) ReadOnly = true iken (varsayılan) sadece GET / VERSION komutları gider.
    ///  4) İçinde 127.0.0.1 dışında IPv4 adresi geçen komut hiçbir durumda gönderilmez.
    /// </summary>
    public sealed class VizEngineClient : IDisposable
    {
        public const string Host = "127.0.0.1";
        public const int Port = 6100;

        private const int ConnectTimeoutMs = 2000;
        private const int ReadTimeoutMs = 5000;

        private static readonly Regex Ipv4Regex = new Regex(@"\b(\d{1,3})\.(\d{1,3})\.(\d{1,3})\.(\d{1,3})\b", RegexOptions.Compiled);

        private readonly object _lock = new object();
        private TcpClient _client;
        private NetworkStream _stream;
        private int _commandId;

        public VizEngineClient()
        {
            ReadOnly = true;
        }

        /// <summary>true iken sadece okuma komutlarına izin verilir.</summary>
        public bool ReadOnly { get; set; }

        public bool IsConnected
        {
            get { return _client != null && _client.Connected; }
        }

        /// <summary>Son gönderilen komut ve cevap (log/hata ayıklama için).</summary>
        public event Action<string, string> CommandSent;

        public void Connect()
        {
            lock (_lock)
            {
                if (IsConnected) return;

                var address = IPAddress.Parse(Host);
                if (!IPAddress.IsLoopback(address))
                    throw new VizException("Güvenlik: Viz adresi loopback değil (" + Host + ").");

                var client = new TcpClient(AddressFamily.InterNetwork);
                var ar = client.BeginConnect(address, Port, null, null);
                if (!ar.AsyncWaitHandle.WaitOne(ConnectTimeoutMs))
                {
                    client.Close();
                    throw new VizException("Viz Engine'e bağlanılamadı (" + Host + ":" + Port + ", zaman aşımı).");
                }
                try
                {
                    client.EndConnect(ar);
                }
                catch (SocketException ex)
                {
                    client.Close();
                    throw new VizException("Viz Engine'e bağlanılamadı (" + Host + ":" + Port + "): " + ex.Message);
                }

                var remote = client.Client.RemoteEndPoint as IPEndPoint;
                if (remote == null || !IPAddress.IsLoopback(remote.Address) || remote.Port != Port)
                {
                    client.Close();
                    throw new VizException("Güvenlik: bağlanılan uç nokta beklenen yerel adres değil.");
                }

                _client = client;
                _client.NoDelay = true;
                _stream = _client.GetStream();
                _stream.ReadTimeout = ReadTimeoutMs;
                _stream.WriteTimeout = ReadTimeoutMs;
            }
        }

        public void Disconnect()
        {
            lock (_lock)
            {
                if (_stream != null) _stream.Dispose();
                if (_client != null) _client.Close();
                _stream = null;
                _client = null;
            }
        }

        public void Dispose()
        {
            Disconnect();
        }

        /// <summary>
        /// Komutu gönderir, cevabı döndürür (baştaki id atılmış hali).
        /// Viz "ERROR" dönerse VizException fırlatır.
        /// </summary>
        public string Send(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
                throw new ArgumentException("Komut boş.");
            command = command.Trim();
            EnsureAllowed(command);

            lock (_lock)
            {
                if (!IsConnected)
                    throw new VizException("Viz Engine'e bağlı değil.");

                int id = ++_commandId;
                byte[] data = Encoding.UTF8.GetBytes(id + " " + command + "\0");
                string answer;
                try
                {
                    _stream.Write(data, 0, data.Length);
                    answer = ReadAnswer();
                }
                catch (IOException ex)
                {
                    Disconnect();
                    throw new VizException("Viz bağlantısı koptu: " + ex.Message);
                }

                // Cevap "id cevap" biçiminde gelir
                string prefix = id + " ";
                if (answer.StartsWith(prefix)) answer = answer.Substring(prefix.Length);
                else if (answer == id.ToString()) answer = "";

                var handler = CommandSent;
                if (handler != null) handler(command, answer);

                if (answer.StartsWith("ERROR"))
                    throw new VizException(answer);
                return answer;
            }
        }

        private string ReadAnswer()
        {
            using (var ms = new MemoryStream())
            {
                while (true)
                {
                    int b = _stream.ReadByte();
                    if (b < 0) throw new IOException("Bağlantı kapandı.");
                    if (b == 0) break;
                    ms.WriteByte((byte)b);
                }
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        /// <summary>Güvenlik kuralları 3 ve 4.</summary>
        private void EnsureAllowed(string command)
        {
            foreach (Match m in Ipv4Regex.Matches(command))
            {
                if (m.Value != Host)
                    throw new VizException("Güvenlik: komut içinde yerel olmayan IP adresi var (" + m.Value + "). Gönderilmedi.");
            }

            if (ReadOnly && !IsReadCommand(command))
                throw new VizException("Salt okunur mod: yazma komutu gönderilmedi.\n" + command);
        }

        public static bool IsReadCommand(string command)
        {
            return command == "VERSION" || command.EndsWith(" GET", StringComparison.Ordinal);
        }

        // ------------------------------------------------------------------ okuma yardımcıları

        public string GetVersion()
        {
            return Send("VERSION");
        }

        /// <summary>Ana katmandaki sahne adı (örnek: HT_TICKER_2026_V02).</summary>
        public string GetMainSceneName()
        {
            return Send("MAIN_SCENE*NAME GET");
        }

        /// <summary>
        /// Container yolundaki text geometrisinin değeri. Yol örneği: HIDDEN_CONTROLLERS$tobleronStatus
        /// Viz cevabın sonuna satır sonu ekliyor; kırpılarak döndürülür.
        /// </summary>
        public string GetText(string containerPath)
        {
            return Send("MAIN_SCENE*TREE*$" + containerPath + "*GEOM*TEXT GET").TrimEnd('\r', '\n');
        }

        /// <summary>Container yolundaki text geometrisine değer yazar. Yazma komutudur.</summary>
        public void SetText(string containerPath, string value)
        {
            Send("MAIN_SCENE*TREE*$" + containerPath + "*GEOM*TEXT SET " + (value ?? ""));
        }

        /// <summary>
        /// Viz shared memory'ye (VizCommunication.Map) değer yazar. Yazma komutudur.
        /// Bu engine'de shared memory ağ paylaşımı kapalı (smm_udp/tcp_service = NONE), değer yerelde kalır.
        /// </summary>
        public void SetSharedMemory(string key, string value)
        {
            if (string.IsNullOrEmpty(key) || key.IndexOf('"') >= 0 || (value ?? "").IndexOfAny(new[] { '"', ';', '\0' }) >= 0)
                throw new ArgumentException("Geçersiz shared memory anahtarı/değeri.");
            Send("VIZ_COMMUNICATION*MAP SET_STRING_ELEMENT \"" + key + "\" " + (value ?? ""));
        }

        /// <summary>
        /// Layer director'ını bir durak noktasından diğerine götürür (Media Sequencer'ın yaptığı gibi).
        /// Yazma komutudur: ReadOnly = false olmalı.
        /// </summary>
        public void GotoTrio(string directorName, string fromStop, string toStop)
        {
            Send("MAIN_SCENE*STAGE*DIRECTOR*" + directorName + " GOTO_TRIO $" + fromStop + " $" + toStop);
        }

        /// <summary>
        /// Director'ın şu an hangi durakta olduğunu zamanından bulur (zaman → durak tablosuyla).
        /// Durak üzerinde değilse (animasyon sürüyor) null döner.
        /// </summary>
        public string GetCurrentStop(string directorName, System.Collections.Generic.IDictionary<int, string> stopsByTime)
        {
            double t;
            string raw = GetDirectorTime(directorName).Trim();
            if (!double.TryParse(raw, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out t))
                return null;
            foreach (var kv in stopsByTime)
            {
                if (Math.Abs(t - kv.Key) < 0.05) return kv.Value;   // ör. 9.98 → 10
            }
            return null;
        }

        /// <summary>Director'ın şu anki zamanı (saniye).</summary>
        public string GetDirectorTime(string directorName)
        {
            return Send("MAIN_SCENE*STAGE*DIRECTOR*" + directorName + "*TIME GET");
        }
    }
}
