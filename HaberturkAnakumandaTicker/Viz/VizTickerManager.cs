using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using VIZTICKERLib;

namespace HaberturkAnakumandaTicker.Viz
{
    /// <summary>6301 tickertalk olayı. Örnek: "* run 1 LCL_TICKER", "* run SCROLLER_EMPTY LCL_TICKER".</summary>
    public sealed class TickerEvent
    {
        public string Raw;
        public string Kind;    // run / event / protocol
        public string Arg;     // grup adı, at_end, empty, SCROLLER_EMPTY...
        public string Ticker;  // ticker (element source) adı

        public bool IsScrollerEmpty
        {
            get { return Kind == "run" && Arg == "SCROLLER_EMPTY"; }
        }

        public static TickerEvent Parse(string line)
        {
            var e = new TickerEvent { Raw = line };
            var p = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (p.Length >= 2) e.Kind = p[1];
            if (p.Length >= 3) e.Arg = p[2];
            if (p.Length >= 4) e.Ticker = p[3];
            return e;
        }
    }

    /// <summary>
    /// VizTickerService (COM) yöneticisi. Akış eski HTSPOR uygulamasıyla aynı ve 2026-10-05'te
    /// sahnede doğrulandı:
    ///  - new VizTickers() → AddTicker/GetTicker (ticker adı = Scroller Element Source)
    ///  - StartVizCommunication ÇAĞRILMAZ (çağrılınca veri sahneye gelmiyordu)
    ///  - 127.0.0.1:6301'e "* protocol tickertalk" ile bağlanıp olaylar dinlenir
    ///
    /// GÜVENLİK:
    ///  - COM nesnesi sadece bu makinedeki TickerService.exe'ye bağlanır (LocalServer32).
    ///  - Tam olarak 1 TickerService süreci yoksa bağlanılmaz (COM yeni süreç başlatmasın).
    ///  - Konsol bağlantısı sadece loopback'e açılır.
    ///  - COM nesneleri uygulama açık kaldığı sürece tutulur; bırakılınca servis ticker'ı kapatır.
    /// Bütün çağrılar UI thread'inden yapılmalı (COM STA).
    /// </summary>
    public sealed class VizTickerManager : IDisposable
    {
        private const string ServiceProcessName = "TickerService";
        private const int ConsolePort = 6301;

        private readonly SynchronizationContext _ui;
        private readonly Dictionary<string, IVizTickerControl> _controls = new Dictionary<string, IVizTickerControl>();
        private IVizTickers _tickers;
        private TcpClient _console;
        private Thread _reader;

        public VizTickerManager()
        {
            _ui = SynchronizationContext.Current;
        }

        /// <summary>6301'den gelen olaylar (UI thread'ine aktarılır).</summary>
        public event Action<TickerEvent> EventReceived;

        /// <summary>Bilgi/log mesajları.</summary>
        public event Action<string> Log;

        public bool IsConnected
        {
            get { return _tickers != null; }
        }

        public void Connect()
        {
            if (IsConnected) return;

            var procs = Process.GetProcessesByName(ServiceProcessName);
            if (procs.Length == 0)
                throw new VizException("VizTickerService çalışmıyor. Masaüstündeki kısayolla (yönetici olarak) başlatın.");
            if (procs.Length > 1)
                throw new VizException("Birden fazla TickerService çalışıyor (" + procs.Length + "). Fazla olanları kapatın.");

            try
            {
                _tickers = new VizTickers();
            }
            catch (COMException ex)
            {
                _tickers = null;
                throw new VizException("VizTickerService'e COM ile bağlanılamadı. Uygulama yönetici olarak mı çalışıyor?\n" + ex.Message);
            }

            ConnectConsole();
            RaiseLog("VizTicker bağlandı. Tanımlı ticker'lar: " + ListTickers());
        }

        public string ListTickers()
        {
            EnsureConnected();
            return (_tickers.ListTickers() ?? "").Replace("\n", " ").Trim();
        }

        /// <summary>Ticker'ı (yoksa oluşturup) döndürür ve açık tutar.</summary>
        private IVizTickerControl GetControl(string tickerName)
        {
            EnsureConnected();
            IVizTickerControl ctl;
            if (_controls.TryGetValue(tickerName, out ctl)) return ctl;

            if (_tickers.GetTicker(tickerName) == null)
                _tickers.AddTicker(tickerName);
            ctl = _tickers.GetTicker(tickerName);
            if (ctl == null)
                throw new VizException("Ticker oluşturulamadı: " + tickerName);
            _controls[tickerName] = ctl;
            return ctl;
        }

        /// <summary>Ticker'ın içeriğini tamamen verilen gruplarla değiştirir.</summary>
        public void ReplaceAll(string tickerName, IList<TickerGroup> groups)
        {
            var ctl = GetControl(tickerName);
            ctl.ClearAll();
            string previous = "";
            foreach (var g in groups)
            {
                ctl.AddGroupAfterGroup(previous, TickerXml.ForService(g.ToXml()));
                previous = g.Name;
            }
            RaiseLog(tickerName + ": " + groups.Count + " grup gönderildi.");
        }

        public void Clear(string tickerName)
        {
            GetControl(tickerName).ClearAll();
            RaiseLog(tickerName + ": temizlendi.");
        }

        public string ListGroups(string tickerName)
        {
            return (GetControl(tickerName).ListGroups() ?? "").Replace("\n", " ").Trim();
        }

        // ------------------------------------------------------------------ 6301 tickertalk

        private void ConnectConsole()
        {
            var client = new TcpClient(AddressFamily.InterNetwork);
            client.Connect(IPAddress.Loopback, ConsolePort);
            var remote = (IPEndPoint)client.Client.RemoteEndPoint;
            if (!IPAddress.IsLoopback(remote.Address))
            {
                client.Close();
                throw new VizException("Güvenlik: ticker konsolu yerel değil.");
            }

            var stream = client.GetStream();
            byte[] cmd = Encoding.GetEncoding("ISO-8859-9").GetBytes("* protocol tickertalk\n");
            stream.Write(cmd, 0, cmd.Length);
            _console = client;

            _reader = new Thread(() => ReadLoop(stream)) { IsBackground = true, Name = "TickerTalkReader" };
            _reader.Start();
        }

        private void ReadLoop(NetworkStream stream)
        {
            var buffer = new byte[4096];
            var pending = new StringBuilder();
            try
            {
                int n;
                while ((n = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    pending.Append(Encoding.UTF8.GetString(buffer, 0, n));
                    string all = pending.ToString();
                    int nl;
                    while ((nl = all.IndexOf('\n')) >= 0)
                    {
                        string line = all.Substring(0, nl).Trim('\r', '\0', ' ');
                        all = all.Substring(nl + 1);
                        if (line.Length > 0) Dispatch(TickerEvent.Parse(line));
                    }
                    pending.Clear().Append(all);
                }
            }
            catch (Exception)
            {
                // bağlantı kapandı / uygulama kapanıyor
            }
            RaiseLog("Ticker konsol bağlantısı kapandı.");
        }

        private void Dispatch(TickerEvent e)
        {
            var handler = EventReceived;
            if (handler == null) return;
            if (_ui != null) _ui.Post(_ => handler(e), null);
            else handler(e);
        }

        private void RaiseLog(string message)
        {
            var handler = Log;
            if (handler == null) return;
            if (_ui != null) _ui.Post(_ => handler(message), null);
            else handler(message);
        }

        private void EnsureConnected()
        {
            if (!IsConnected)
                throw new VizException("VizTicker'a bağlı değil.");
        }

        public void Dispose()
        {
            if (_console != null)
            {
                _console.Close();
                _console = null;
            }
            foreach (var ctl in _controls.Values)
            {
                try { Marshal.FinalReleaseComObject(ctl); } catch { }
            }
            _controls.Clear();
            if (_tickers != null)
            {
                try { Marshal.FinalReleaseComObject(_tickers); } catch { }
                _tickers = null;
            }
        }
    }
}
