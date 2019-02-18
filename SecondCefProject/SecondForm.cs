using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecondCefProject
{
    public partial class SecondForm : Form
    {
        public ChromiumWebBrowser _chromeBrowser;

        public SecondForm(ChromiumWebBrowser chromeBrowser = null)
        {
            InitializeComponent();

            var _cefIsInternal = chromeBrowser == null;
            _chromeBrowser = chromeBrowser;

            if (_cefIsInternal)
            {
                CefSettings settings = new CefSettings();
                // Initialize cef with the provided settings
                Cef.Initialize(settings);
                // Create a browser component
                _chromeBrowser = new ChromiumWebBrowser("http://www.nsbloggers.com/index.cfm");
                this.FormClosing += Form1_FormClosing;
            }

            // Add it to the form and fill it to the form window.
            this.Controls.Add(_chromeBrowser);
            _chromeBrowser.Dock = DockStyle.Fill;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
    }
}
