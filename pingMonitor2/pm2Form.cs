﻿using System;
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

        public pm2Form()
        {
            rm = new ResourceManager("pingMonitor2.Resource.Res", typeof(pm2Form).Assembly);
            InitializeComponent();
            InitializeCulture();
            SetTexts();
            p = new Pinger(f: this);
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
            if (((Button)sender).Text.Equals(rm.GetString("btnStop", cul)))
            {
                // start pinging
                p.target = inputHost.Text;
                p.interval = (int)inputInterval.Value;
                pingThread = new Thread(p.doPing);
                pingThread.Start();
            }
            else
            {
                // stop pinging
                if (pingThread != null)
                {
                    pingThread.Abort();
                }
            }
        }

        public void updateOutput()
        {
            realtimeOutput.AppendText(p.target+" || "+p.reply.RoundtripTime+"\n");
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
    }
}
