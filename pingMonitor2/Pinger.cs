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

        public Pinger(pm2Form f, string t = "www.google.de", int i = 1000)
        {
            this.target = t;
            this.interval = i;
            this.f = f;
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
                    System.Threading.Thread.Sleep(this.interval);
                    f.Invoke(new MethodInvoker(f.updateOutput));
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
        }

    }
}
