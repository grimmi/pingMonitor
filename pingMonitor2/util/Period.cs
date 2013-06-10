using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pingMonitor2
{
    public class Period
    {
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string status { get; set; }
        public int count { get; set; }

        public Period(DateTime start, DateTime end, string status = "n/a", int count = 0)
        {
            this.start = start;
            this.end = end;
            this.status = status;
            this.count = count;
        }

        public TimeSpan getTimeSpan()
        {
            return this.end - this.start;
        }
    }
}
