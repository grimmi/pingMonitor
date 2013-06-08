using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pingMonitor2
{
    class Statistics
    {
        public List<string> Hostlist;
        public List<string> Daylist;
        public LogHandler lh;

        public Statistics()
        {
            this.lh = new LogHandler();
            this.Hostlist = lh.getHosts();
            this.Daylist = lh.getDays();
        }

        public List<HostStatistics> getAllHostStatistics()
        {
            List<HostStatistics> hostStats = new List<HostStatistics>();
            List<string> hosts = lh.getHosts();
            hosts.ForEach(x => hostStats.Add(new HostStatistics(x)));
            return hostStats;
        }
    }
}
