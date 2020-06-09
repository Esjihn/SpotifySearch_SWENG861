using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SpotifySearch_SWENG861.ViewInterfaces;
using SpotifySearch_SWENG861.Views;

namespace SpotifySearch_SWENG861.UserControls
{
    public partial class ListItemUserControl : UserControl, IListItemUserControl
    {
        public ListItemUserControl()
        {
            InitializeComponent();
        }

        #region Properties

        [Category("Custom Props")]
        public string Title
        {
            get
            {
                return this.lblTitle.Text;
            }
            set
            {
                if (value != null)
                    this.lblTitle.Text = value;
            }
        }

        [Category("Custom Props")]
        public Color IconBackGround
        {
            get
            {
                return this.pnlListenOnSpotify.BackColor;
            }
            set
            {
                if (value != null)
                    this.pnlListenOnSpotify.BackColor = value;
            }
        }

        [Category("Custom Props")]
        public string Message 
        {
            get
            {
                return this.lblMessage.Text;
            }
            set
            {
                if (value != null) 
                    this.lblMessage.Text = value;
            }
        }

        [Category("Custom Props")]
        public Image Icon
        {
            get
            {
                return this.picListenOnSpotify.Image;
            }
            set
            {
                if (value != null)
                    this.picListenOnSpotify.Image = value;
            }
        }

        #endregion

        #region EventHandlers
        private void ListItem_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
        }

        private void ListItem_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void LblTitle_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
        }

        private void LblTitle_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void LblMessage_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
        }

        private void LblMessage_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void ListItem_MouseClick(object sender, MouseEventArgs e)
        {
            // todo listitem,title, message should all trigger a single method with result meta data.
            // todo either replace message box with new view that displays all object meta data or show it inside of the message box.
            // user may want to copy this information so i will probably go with a new simple text that can with readonly text that can be copied.
            MessageBox.Show("More data here");
        }

        private void LblTitle_MouseClick(object sender, MouseEventArgs e)
        {
            // todo listitem,title, message should all trigger a single method with result meta data.
            // todo either replace message box with new view that displays all object meta data or show it inside of the message box.
            // user may want to copy this information so i will probably go with a new simple text that can with readonly text that can be copied.
            MessageBox.Show("More data here");
        }

        private void LblMessage_Click(object sender, EventArgs e)
        {
            // todo listitem,title, message should all trigger a single method with result meta data.
            // todo either replace message box with new view that displays all object meta data or show it inside of the message box.
            // user may want to copy this information so i will probably go with a new simple text that can with readonly text that can be copied.
            MessageBox.Show("More data here");
        }

        private void PicListenOnSpotify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // todo test internal i.e. browser with spotify's sample uri 
            // if i.e. is not up to the task I may need to add another api that will open a newer browser like edge chromium, chrome, firefox. 
            FindSelectedUserControlIndexAndPlayTrackSample();
        }

        private void LblDoubleClick_Click(object sender, EventArgs e)
        {
            // todo test internal i.e. browser with spotify's sample uri 
            // if i.e. is not up to the task I may need to add another api that will open a newer browser like edge chromium, chrome, firefox. 
            //
            FindSelectedUserControlIndexAndPlayTrackSample();
        }

        #endregion

        #region IListItemUserControl Methods

        /// <summary>
        /// Matches current selected control index in flow panel to track sample play index.
        /// </summary>
        public void FindSelectedUserControlIndexAndPlayTrackSample()
        {
            SpotifySearchView view = this.Parent.Parent as SpotifySearchView;
            string currentTitle = this.Title;

            if (view != null)
            {
                ControlCollection controls = view.FlowPanelObject.Controls;
                int selectedIndex = 0;

                for (int i = 0; i < controls.Count; i++)
                {
                    ListItemUserControl cnt = controls[i] as ListItemUserControl;
                    if (cnt != null && cnt.Title == currentTitle)
                    {
                        selectedIndex = i;
                    }
                }

                // todo will need to chnage from .WebBrowser to 
                // ChromiumWebBrowser object if i decide to go with 
                // CEFSharp API. 
                ListenOnSpotifyView listenView = new ListenOnSpotifyView();
                listenView.WebBrowser.Url = new Uri(view.TracksResults.Tracks.Items[selectedIndex].Preview_url);
                listenView.Show();
            }
        }

        #endregion
    }
}
