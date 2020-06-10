﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CSharp_SpotifyAPI.Models;
using SpotifySearch_SWENG861.ViewInterfaces;
using SpotifySearch_SWENG861.Views;
using Image = System.Drawing.Image;

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
        /// <summary>
        /// List Item mouse enter event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListItem_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
        }

        /// <summary>
        /// List Item mouse leave event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListItem_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        /// <summary>
        /// lblTitle mouse enter event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblTitle_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
        }

        /// <summary>
        /// lblTitle mouse leave event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblTitle_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        /// <summary>
        /// lblMessage mouse enter event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblMessage_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
        }

        /// <summary>
        /// lblMessage mouse leave event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblMessage_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        /// <summary>
        /// List Item mouse click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListItem_MouseClick(object sender, MouseEventArgs e)
        {
            SpotifySearchView view = this.Parent.Parent as SpotifySearchView;

            if (view != null)
            {
                LoadAndFillMetaDataView(view);
            }
        }

        /// <summary>
        /// lblTitle mouse click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblTitle_MouseClick(object sender, MouseEventArgs e)
        {
            SpotifySearchView view = this.Parent.Parent as SpotifySearchView;

            if (view != null)
            {
                LoadAndFillMetaDataView(view);
            }
        }

        /// <summary>
        /// lblMessage click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblMessage_Click(object sender, EventArgs e)
        {
            SpotifySearchView view = this.Parent.Parent as SpotifySearchView;

            if (view != null)
            {
                LoadAndFillMetaDataView(view);
            }
        }

        /// <summary>
        /// Spotify pic mouse double click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PicListenOnSpotify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // todo test internal i.e. browser with spotify's sample uri 
            // if i.e. is not up to the task I may need to add another api that will open a newer browser like edge chromium, chrome, firefox. 
            FindSelectedUserControlIndexAndPlayTrackSample();
        }

        /// <summary>
        /// lblDoubleclick SINGLE click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblDoubleClick_Click(object sender, EventArgs e)
        {
            // todo test internal i.e. browser with spotify's sample uri 
            // if i.e. is not up to the task I may need to add another api that will open a newer browser like edge chromium, chrome, firefox. 
            FindSelectedUserControlIndexAndPlayTrackSample();
        }

        #endregion

        #region IListItemUserControl Methods

        /// <summary>
        /// Loads meta data from view and sends it to Additional Meta Data View
        /// </summary>
        public SearchArtists LoadSearchArtistsMetaData()
        {
            SpotifySearchView view = this.Parent.Parent as SpotifySearchView;
            
            if (view != null)
            {
                return view.ArtistsResults;
            }

            return new SearchArtists();
        }

        /// <summary>
        /// Loads meta data from view and sends it to Additional Meta Data View
        /// </summary>
        public SearchSongs LoadSearchSongsMetaData()
        {
            SpotifySearchView view = this.Parent.Parent as SpotifySearchView;

            if (view != null)
            {
                return view.TracksResults;
            }

            return new SearchSongs();
        }

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

                // todo will need to change from .WebBrowser to 
                // ChromiumWebBrowser object if i decide to go with 
                // CEFSharp API. 
                ListenOnSpotifyView listenView = new ListenOnSpotifyView();
                listenView.WebBrowser.Url = new Uri(view.TracksResults.Tracks.Items[selectedIndex].Preview_url);
                listenView.Show();
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Loads, Fills, and shows AdditionalMetaDataView with active meta data.
        /// </summary>
        /// <param name="view"></param>
        private void LoadAndFillMetaDataView(SpotifySearchView view)
        {
            AdditionalMetaDataView metaView = new AdditionalMetaDataView();

            if (view.IsSongSearch)
            {
                metaView.LoadMetaData(LoadSearchSongsMetaData());
            }

            if (view.IsArtistSearch)
            {
                metaView.LoadMetaData(LoadSearchArtistsMetaData());
            }

            metaView.ShowDialog();
        }

        #endregion

    }
}
