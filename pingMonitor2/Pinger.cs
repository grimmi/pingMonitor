using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pingMonitor2
{
    class Pinger
    {
        public string target { get; set; }
        public PingReply reply { get; set; }
        public Ping p { get; set; }
        public int interval { get; set; }
        public List<PingReply> replies { get; set; }
        public pm2Form f;

        public Pinger(pm2Form f, string t = "www.google.de", int i = 1000)
        {
            this.target = t;
            this.interval = i;
            this.replies = new List<PingReply>();
            this.f = f;
        }

        public void doPing()
        {
            p = new Ping();
            while (true)
            {
                try
                {
                    reply = p.Send(this.target);
                    replies.Add(reply);
                    System.Threading.Thread.Sleep(this.interval);
                    f.Invoke(new MethodInvoker(f.updateOutput));
                    Debug.WriteLine(reply.Address + " || " + reply.RoundtripTime);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
        }

    }
}
