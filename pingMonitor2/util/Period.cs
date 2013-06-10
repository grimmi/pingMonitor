using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace pingMonitor2
{
    public class Period
    {
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string status { get; set; }
        public string host { get; set; }
        public int count { get; set; }
        public List<LogEntry> periodEntries { get; set; }

        public Period(DateTime start, DateTime end, string status = "n/a", int count = 0, List<LogEntry> entries = null, string host = "n/a")
        {
            this.start = start;
            this.end = end;
            this.status = status;
            this.count = count;
            if (entries == null)
            {
                this.periodEntries = new List<LogEntry>();
            }
            else
            {
                this.periodEntries = entries;
            }
            this.host = host;
        }

        public TimeSpan getTimeSpan()
        {
            return this.end - this.start;
        }
    }
}
