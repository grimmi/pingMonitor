using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pingMonitor2
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            pm2Form form = new pm2Form();
            Application.Run(form);
        }
    }

    class LogEntry
    {
        public DateTime date { get; set; }
        public long roundTrip { get; set; }
        public string status { get; set; }
        public string host { get; set; }

        LogEntry(DateTime date, string host, long roundTrip, string status)
        {
            this.date = date;
            this.host = host;
            this.roundTrip = roundTrip;
            this.status = status;
        }

        LogEntry(string line)
        {
            string[] parts = line.Split(';');
            this.date = DateTime.Parse(parts[0]);
            string status = parts[1];
            long time = long.Parse(parts[2]);
            string host = parts[3];

            this.date = date;
            this.status = status;
            this.roundTrip = roundTrip;
            this.host = host;
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

            string ret = String.Format("{0}: {1} ( {2} ms )",host,status,time);
            return ret;
        }
    }
}
