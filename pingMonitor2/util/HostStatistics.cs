using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pingMonitor2
{
    public class HostStatistics
    {
        public int pingCount { get; set; }
        public string host { get; set; }
        public List<string> ips { get; set; }
        public double avgTime { get; set; }
        public long maxTime { get; set; }
        public long minTime { get; set; }

        public LogHandler lh;

        public HostStatistics(string host)
        {
            this.host = host;
            lh = new LogHandler();
            List<LogEntry> entries = lh.getLogEntriesByHost(this.host);
            entries.ForEach(x => Debug.WriteLine(x.printLog()));
            if (entries.Count() > 0)
            {
                if ((entries.Where(x => x.roundTrip > 0).Count()) > 0)
                {
                    this.minTime = entries.Where(x => x.roundTrip > 0).Min(x => x.roundTrip);
                    this.maxTime = entries.Where(x => x.roundTrip > 0).Max(x => x.roundTrip);
                    this.avgTime = entries.Average(x => x.roundTrip);
                }
                else
                {
                    this.minTime = 0;
                    this.maxTime = 0;
                    this.avgTime = 0.0;
                }
                this.pingCount = entries.Count();
                this.ips = entries.Select(x => x.ip).Distinct().ToList();
            }
            else
            {
                this.minTime = 0L;
                this.maxTime = 0L;
                this.avgTime = 0.0;
                this.pingCount = 0;
                this.ips = new List<string>();
            }
        }

        public string print()
        {
            string o = String.Format("{0}:\r\n{1} Pings insgesamt\r\n{2} ms maximale Laufzeit || {3} ms minimale Laufzeit\r\n{4:0.00} ms durchschnittliche Laufzeit\r\n",
                                    this.host, this.pingCount, this.maxTime, this.minTime, this.avgTime);
            return o;
        }

    }
}
