using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpotifySearch_SWENG861.ViewInterfaces;

namespace SpotifySearch_SWENG861.Views
{
    public partial class ListenOnSpotifyView : Form, IListenOnSpotifyView
    {
        public ListenOnSpotifyView()
        {
            InitializeComponent();
        }

        #region Properties
        /// <summary>
        /// Property to communicate with webbrowser object.
        /// </summary>
        public WebBrowser WebBrowser
        {
            get
            {
                return this.webListenOnSpotify;
            }
            set
            {
                if (value != null)
                    this.webListenOnSpotify = value;
            }
        }
        #endregion
    }
}
