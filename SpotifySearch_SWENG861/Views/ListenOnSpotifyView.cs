using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using SpotifySearch_SWENG861.ViewInterfaces;

namespace SpotifySearch_SWENG861.Views
{
    public partial class ListenOnSpotifyView : Form, IListenOnSpotifyView
    {
        private ChromiumWebBrowser _chromiumWebBrowser;

        public ListenOnSpotifyView(ChromiumWebBrowser chromeWebBrowser)
        {
            InitializeComponent();
            this._chromiumWebBrowser = chromeWebBrowser;
            DockBrowserInstance(chromeWebBrowser);
        }

        #region Events

        #endregion

        #region IListenOnSpotifyView Properties

        /// <summary>
        /// Initializes Chromium. Dragging from toolbox in designer
        /// does not work.
        /// </summary>
        public void DockBrowserInstance(ChromiumWebBrowser chromeWebBrowser)
        {
            if (chromeWebBrowser == null) return;

            this.Controls.Add(chromeWebBrowser);
            chromeWebBrowser.Dock = DockStyle.Fill;
        }

        #endregion
    }
}
