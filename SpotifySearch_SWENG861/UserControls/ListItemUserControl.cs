﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SpotifySearch_SWENG861.Views;

namespace SpotifySearch_SWENG861
{
    public partial class UcSearchResultItem : UserControl
    {
        public UcSearchResultItem()
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

        private void ListItem_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
        }

        private void ListItem_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void lblTitle_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
        }

        private void lblTitle_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void lblMessage_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
        }

        private void lblMessage_MouseLeave(object sender, EventArgs e)
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

        private void lblTitle_MouseClick(object sender, MouseEventArgs e)
        {
            // todo listitem,title, message should all trigger a single method with result meta data.
            // todo either replace message box with new view that displays all object meta data or show it inside of the message box.
            // user may want to copy this information so i will probably go with a new simple text that can with readonly text that can be copied.
            MessageBox.Show("More data here");
        }

        private void lblMessage_Click(object sender, EventArgs e)
        {
            // todo listitem,title, message should all trigger a single method with result meta data.
            // todo either replace message box with new view that displays all object meta data or show it inside of the message box.
            // user may want to copy this information so i will probably go with a new simple text that can with readonly text that can be copied.
            MessageBox.Show("More data here");
        }

        private void picListenOnSpotify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // todo test internal i.e. browser with spotify's sample uri 
            // if i.e. is not up to the task I may need to add another api that will open a newer browser like edge chromium, chrome, firefox. 
            WebBrowser wb = new WebBrowser();
            // todo setup ListenOnSpotifyView
            ListenOnSpotifyView listenView = new ListenOnSpotifyView();
            listenView.WebBrowser.Url = new Uri("https://www.google.com");
            listenView.Show();
        }

        private void lblDoubleClick_Click(object sender, EventArgs e)
        {
            // todo test internal i.e. browser with spotify's sample uri 
            // if i.e. is not up to the task I may need to add another api that will open a newer browser like edge chromium, chrome, firefox. 
            WebBrowser wb = new WebBrowser();
            // todo setup ListenOnSpotifyView
            ListenOnSpotifyView listenView = new ListenOnSpotifyView();
            listenView.WebBrowser.Url = new Uri("https://www.google.com");
            listenView.Show();
        }
    }
}
