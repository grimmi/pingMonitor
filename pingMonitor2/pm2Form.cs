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

namespace pingMonitor2
{
    public partial class pm2Form : Form
    {
        ResourceManager rm;
        CultureInfo cul;

        public pm2Form()
        {
            rm = new ResourceManager("pingMonitor2.Resource.Res", typeof(pm2Form).Assembly);
            InitializeComponent();
            InitializeCulture();
            SetTexts();
        }

        public void SetTexts()
        {
            btnExit.Text = rm.GetString("quitPingMonitor", cul);
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

        // exit the app
        public void quit(object sender, EventArgs e)
        {
            cleanup();
            Close();
        }

        // all the stuff that needs to be done before we exit
        public void cleanup(object sender, EventArgs e)
        {
            //Debug.WriteLine(rm.GetString("appClosing", cul));
        }

        public void cleanup()
        {
            cleanup(null, null);
        }
    }
}
