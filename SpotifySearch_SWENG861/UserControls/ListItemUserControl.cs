using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using CSharp_SpotifyAPI;
using CSharp_SpotifyAPI.Models;
using SpotifySearch_SWENG861.PresentationObjects;
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
            FindSelectedUserControlIndexAndPlayTrackSample();
        }

        /// <summary>
        /// lblDoubleclick SINGLE click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblDoubleClick_Click(object sender, EventArgs e)
        {
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
        /// Loads meta data from import list in SpotifySearchView
        /// </summary>
        /// <returns></returns>
        private List<SpotifySearchPO> LoadImportMetaData()
        {
            SpotifySearchView view = this.Parent.Parent as SpotifySearchView;

            if (view != null)
            {
                return view.ImportResults;
            }

            return new List<SpotifySearchPO>();
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

                // todo Preview should support import. .....
                if (view.TracksResults != null && view.IsOnlineSearch)
                {
                    ListenOnSpotifyView listenView = new ListenOnSpotifyView(new ChromiumWebBrowser(
                        view.TracksResults.Tracks.Items[selectedIndex].Preview_url));
                    
                    listenView.Text = @"Listen On Spotify Preview! " + '"' + view.TracksResults.Tracks.Items[selectedIndex].Name + '"' + @" playing!";
                    listenView.Refresh();
                    listenView.ShowDialog();
                }
                else if (!view.IsOnlineSearch)
                {
                    ListenOnSpotifyView listenView = new ListenOnSpotifyView(new ChromiumWebBrowser(view.ImportResults[selectedIndex].PreviewUrl));
                    listenView.Refresh();
                    listenView.ShowDialog();
                    listenView.TopMost = true;
                    listenView.BringToFront();
                }
                else
                {
                    DialogResult result = MessageBox.Show(@"No preview link found for this item or use Song Search if Artist Search Type selected.", @"Prompt",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);

                    if (result == DialogResult.OK)
                    {
                        view.TopMost = true;
                        view.BringToFront();
                    }
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Loads, Fills, and shows AdditionalMetaDataView with active meta data from user control
        /// </summary>
        /// <param name="view"></param>
        private void LoadAndFillMetaDataView(SpotifySearchView view)
        {
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

                AdditionalMetaDataView metaView = new AdditionalMetaDataView(LoadSearchSongsMetaData(), LoadSearchArtistsMetaData(), LoadImportMetaData());

                if (view.IsOnlineSearch)
                {
                    if (view.IsSongSearch)
                    {
                        metaView.LoadMetaData(SpotifyAPIConstants.Song, selectedIndex);
                    }

                    if (view.IsArtistSearch)
                    {
                        metaView.LoadMetaData(SpotifyAPIConstants.Artist, selectedIndex);
                    }
                }
                else // search "offline" import
                {
                    metaView.LoadMetaData(SpotifyAPIConstants.Import, selectedIndex);
                }

                metaView.TopMost = true;
                metaView.ShowDialog();
                metaView.BringToFront();
            }
        }

        #endregion
    }
}
