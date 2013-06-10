using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;
using System.Diagnostics;
using System.Threading;
using System.Net.NetworkInformation;

namespace pingMonitor2
{
    public partial class pm2Form : Form
    {
        ResourceManager rm;
        CultureInfo cul;
        Thread pingThread;
        Pinger p;
        Statistics s;
        List<HostStatistics> hostStatistics;
        bool newData;
        bool pingRunning;
        LogHandler lh;

        public pm2Form()
        {
            rm = new ResourceManager("pingMonitor2.Resource.Res", typeof(pm2Form).Assembly);
            InitializeComponent();
            InitializeCulture();
            SetTexts();
            p = new Pinger(f: this);
            s = new Statistics();
            lh = new LogHandler();
            //hostStatistics = s.getAllHostStatistics();
            newData = false;
            pingRunning = false;
        }

        public void SetTexts()
        {
            btnExit.Text = rm.GetString("quitPingMonitor", cul);
            btnStartStop.Text = rm.GetString("btnStart", cul);
            labelTarget.Text = rm.GetString("labelTarget", cul);
            realtimeOutput.Text = rm.GetString("welcome", cul);
        }        

        // get the culture from windows
        public void InitializeCulture()
        {
            CultureInfo ci = CultureInfo.InstalledUICulture;
            if (new string[] { "en", "de" }.Contains(ci.TwoLetterISOLanguageName))
            {
                cul = CultureInfo.CreateSpecificCulture(ci.TwoLetterISOLanguageName);
            }
            else
            {
                cul = CultureInfo.CreateSpecificCulture("en");
            }
        }

        public void updateStartBtn(object sender, EventArgs e)
        {
            if (btnStartStop.Text.Equals(rm.GetString("btnStart", cul)))
            {
                btnStartStop.Text = rm.GetString("btnStop", cul);
            }
            else
            {
                btnStartStop.Text = rm.GetString("btnStart", cul);
            }
        }

        public void startstop(object sender, EventArgs e)
        {
            changeEnabled();
            newData = true;
            if (!pingRunning)
            {
                // start pinging
                if(realtimeOutput.Text.Equals(rm.GetString("welcome",cul)))
                    realtimeOutput.Text = "";
                p.target = inputHost.Text;
                p.interval = (int)inputInterval.Value;
                pingThread = new Thread(p.doPing);
                pingThread.Start();
                pingRunning = true;
            }
            else
            {
                pingRunning = false;
                // stop pinging
                if (pingThread != null)
                {
                    pingThread.Abort();
                }
            }
        }

        public void changeEnabled()
        {
            inputHost.Enabled = !inputHost.Enabled;
            inputInterval.Enabled = !inputInterval.Enabled;
        }

        public void updateRealTimeOutput()
        {
            realtimeOutput.AppendText(p.l.printExact() + "\n");
        }

        public void updateStatsOutput(List<HostStatistics> hostStats)
        {
            outputStats.Clear();
            
            if (hostStats.Count() > 0)
            {
                hostStats.ForEach(x => outputStats.AppendText(x.print()));
            }
        }

        public void showTimeSpans(List<LogEntry> entries)
        {
            List<Period> periods = lh.getPeriods(entries);
            periods.ForEach(x => outputStats.AppendText(printPeriod(x) + "\r\n"));
        }

        // exit the app
        public void quit(object sender, EventArgs e)
        {
            cleanup();
            Close();
        }

        // all the stuff that needs to be done before we exit
        public void cleanup(object sender, EventArgs e)
        {
            if (pingThread != null)
            {
                pingThread.Abort();
            }
            //Debug.WriteLine(rm.GetString("appClosing", cul));
        }

        public void cleanup()
        {
            cleanup(null, null);
        }

        public bool isRunning(Thread t)
        {
            if(t != null)
                return (t.ThreadState == System.Threading.ThreadState.Running);
            return false;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0: // monitor
                    break;
                case 1: // stats
                    /*
                    if (newData)
                    {
                        hostStatistics = s.getAllHostStatistics();
                    }
                    updateStatsOutput(hostStatistics);
                     */
                    showTimeSpans(lh.getAllEntries());
                    newData = false;
                    break;
                case 2: // charts
                    break;
                default: break;
            }
        }        

        public string printPeriod(Period p)
        {
            string ret = String.Format(rm.GetString("periodPrint",cul), p.start.ToString(), p.end.ToString(), p.getTimeSpan().TotalMinutes, p.count, p.host, p.status);
            return ret;
        }
    }
}
