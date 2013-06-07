using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace pingMonitor2
{
    class LogEntry
    {
        public DateTime date { get; set; }
        public long roundTrip { get; set; }
        public string status { get; set; }
        public string host { get; set; }
        public string? ip { get; set; }
        public PingReply? reply { get; set; }

        LogEntry(DateTime date, string host, long roundTrip, string status, PingReply reply, string ip = "0.0.0.0")
        {
            this.date = date;
            this.host = host;
            this.roundTrip = roundTrip;
            this.status = status;
            this.reply = reply;
            this.ip = ip;
        }

        LogEntry(string line)
        {
            string[] parts = line.Split(';');
            this.date = DateTime.Parse(parts[0]);
            this.status = parts[1];
            this.roundTrip = long.Parse(parts[2]);
            this.host = parts[3];
            if (parts.Count() > 4)
            {
                this.ip = parts[4];
            }
        }

        public string toString()
        {
            return String.Format("{0}: {1}", date.ToString("yyyy-MM-dd"), printReply());
        }

        public string printReply()
        {
            string status = this.status.ToString();
            long time = this.roundTrip;
            string host = this.host;

            string ret = String.Format("{0}: {1} ( {2} ms )", host, status, time);
            return ret;
        }
    }
}
