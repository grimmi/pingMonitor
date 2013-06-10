using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace pingMonitor2
{
    public class LogEntry
    {
        public DateTime date { get; set; }
        public long roundTrip { get; set; }
        public string status { get; set; }
        public string host { get; set; }
        public string ip { get; set; }
        public string error { get; set; }
        public PingReply reply { get; set; }

        public LogEntry(DateTime date, string host, long roundTrip, string status, PingReply reply, string ip = "0.0.0.0", string error = "")
        {
            this.date = date;
            this.host = host;
            this.roundTrip = roundTrip;
            this.status = status;
            this.reply = reply;
            this.ip = ip;
            this.error = error;
        }

        public LogEntry(string line)
        {
            string[] parts = line.Split(';');
            this.date = DateTime.Parse(parts[0]);
            this.host = parts[1];
            this.status = parts[2];
            this.roundTrip = long.Parse(parts[3]);
            Debug.WriteLine(this.roundTrip);
            this.ip = parts[4];
            this.error = "";
            this.reply = null;
        }

        public string printExact()
        {
            return String.Format("{0}: {1}", date.ToString(), printReply());
        }

        public string printReply()
        {
            string status = this.status.ToString();
            long time = this.roundTrip;
            string host = this.host;

            string ret = String.Format("{0}: {1} ( {2} ms )", host, status, time);
            return ret;
        }

        public string printLog()
        {
            string log = String.Format("{0};{1};{2};{3};{4};{5}",
                                this.date.ToString(), this.host, this.status, this.roundTrip, this.ip, "");
            return log;
        }
    }
}
