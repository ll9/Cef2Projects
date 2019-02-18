using CefSharp;
using CefSharp.WinForms;
using SecondCefProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cef2Projects
{
    public partial class Form1 : Form
    {
        public ChromiumWebBrowser chromeBrowser;

        public Form1()
        {
            InitializeComponent();
            // Start the browser after initialize global component
            InitializeChromium();
        }

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            // Initialize cef with the provided settings
            Cef.Initialize(settings);

            String page = string.Format(@"{0}\wwwroot\index.html", Application.StartupPath);
            //String page = @"C:\Users\SDkCarlos\Desktop\artyom-HOMEPAGE\index.html";

            if (!File.Exists(page))
            {
                MessageBox.Show("Error The html file doesn't exists : " + page);
            }
            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser(page);
            chromeBrowser.LoadingStateChanged += ChromeBrowser_LoadingStateChanged;
            // Add it to the form and fill it to the form window.
            panel1.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }

        private void ChromeBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (e.IsLoading == false)
            {
                chromeBrowser.ShowDevTools();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new SecondForm(new ChromiumWebBrowser("https://stackoverflow.com/questions/51079522/asp-core-2-1-email-confirmation")).ShowDialog();
        }
    }
}
