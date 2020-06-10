using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.WinForms;

namespace SpotifySearch_SWENG861.ViewInterfaces
{
    public interface IListenOnSpotifyView
    {
        void DockBrowserInstance(ChromiumWebBrowser chromeWebBrowser);
    }
}
