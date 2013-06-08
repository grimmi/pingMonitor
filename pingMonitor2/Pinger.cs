using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pingMonitor2;

namespace pingMonitor2
{
    class Pinger
    {
        public string target { get; set; }
        public PingReply r { get; set; }
        public Ping p { get; set; }
        public int interval { get; set; }
        public pm2Form f;
        public LogEntry l;
        public Exception ex;

        private string NOCONNECTION = "No Connection";

        public Pinger(pm2Form f, string t = "www.google.de", int i = 1000)
        {
            this.target = t;
            this.interval = i;
            this.f = f;
            this.ex = new Exception();
        }

        public void doPing()
        {
            p = new Ping();
            while (true)
            {
                try
                {
                    r = p.Send(this.target);
                    l = new LogEntry(date: DateTime.Now,
                                                host: this.target, roundTrip: r.RoundtripTime,
                                                status: r.Status.ToString(), ip: r.Address.ToString(), reply: r);
                    f.Invoke(new MethodInvoker(f.updateOutput));
                }
                catch (Exception e)
                {
                    ex = e;
                    l = new LogEntry(date: DateTime.Now,
                                                host: this.target, roundTrip: -1L,
                                                status: NOCONNECTION, ip: "0.0.0.0", reply: null, error: ex.ToString());
                    f.Invoke(new MethodInvoker(f.updateOutput));
                    Debug.WriteLine(e);
                }
                System.Threading.Thread.Sleep(this.interval);
            }
        }

    }
}
