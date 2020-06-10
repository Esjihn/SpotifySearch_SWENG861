﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharp_SpotifyAPI;
using CSharp_SpotifyAPI.Enums;
using CSharp_SpotifyAPI.Models;
using SpotifySearch_SWENG861.Presenters;
using SpotifySearch_SWENG861.Properties;
using SpotifySearch_SWENG861.UserControls;
using SpotifySearch_SWENG861.ViewInterfaces;

namespace SpotifySearch_SWENG861.Views
{
    public partial class SpotifySearchView : Form, ISpotifySearchView
    {
        #region Spotify Authentification

        public static bool Authenticated;

        static readonly List<Scope> Scope = new List<Scope>()
        {
            CSharp_SpotifyAPI.Enums.Scope.UserReadPrivate, CSharp_SpotifyAPI.Enums.Scope.UserReadBirthdate, CSharp_SpotifyAPI.Enums.Scope.UserModifyPlaybackState, CSharp_SpotifyAPI.Enums.Scope.UserModifyPlaybackState, CSharp_SpotifyAPI.Enums.Scope.UserFollowRead, CSharp_SpotifyAPI.Enums.Scope.UserFollowModify, CSharp_SpotifyAPI.Enums.Scope.UserReadRecentlyPlayed, CSharp_SpotifyAPI.Enums.Scope.UserReadPlaybackState
        };

        // ClientId, redirectId, state are in project resources via project properties
        private static readonly SpotifyAPI Api = new SpotifyAPI(Resources.clientId, Resources.redirectId, Resources.state, Scope, true);

        #endregion

        public SpotifySearchView()
        {
            InitializeComponent();
            // TODO keep disabled until closer to completion
            AuthenticateAndStartService();
        }

        #region Properties

        /// <summary>
        /// Flow Layout Panel in SpotifySearchView
        /// </summary>
        public FlowLayoutPanel FlowPanelObject
        {
            get
            {
                return this.flwSearchResultsFlowPanel;
            }
            set
            {
                if (value != null)
                    this.flwSearchResultsFlowPanel = value;
            }
        }

        #endregion

        #region ISpotifySearchView Properties
        /// <summary>
        /// Array of Artists results from presenter
        /// </summary>
        public SearchArtists ArtistsResults { get; set; }

        /// <summary>
        /// Array of Track results from presenter
        /// </summary>
        public SearchSongs TracksResults { get; set; }

        /// <summary>
        /// Boolean flag corresponds to radio button artists search checked
        /// </summary>
        public bool IsArtistSearch { get; set; }

        /// <summary>
        /// Boolean flag corresponds to radio button song search checked
        /// </summary>
        public bool IsSongSearch { get; set; }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Artist / Song search rich text box text changed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rtxtArtistSongEntry_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Radio Artist search button event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnArtistSearch_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton btn = sender as RadioButton;

            if (btn != null)
            {
                if (btn.Checked)
                {
                    IsArtistSearch = true;
                }
                else
                {
                    IsArtistSearch = false;
                }
            }

            if (this.btnSearch.Enabled == false && this.btnSearch.UseVisualStyleBackColor == false) 
            {
                this.btnSearch.Enabled = true;
                this.btnSearch.UseVisualStyleBackColor = true;
            }
        }

        /// <summary>
        /// Radio Song search button event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnSongSearch_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton btn = sender as RadioButton;

            if (btn != null)
            {
                if (btn.Checked)
                {
                    IsSongSearch = true;
                }
                else
                {
                    IsSongSearch = false;
                }
            }

            if (btnSearch.Enabled == false && this.btnSearch.UseVisualStyleBackColor == false)
            {
                this.btnSearch.Enabled = true;
                this.btnSearch.UseVisualStyleBackColor = true;
            }
        }

        /// <summary>
        /// Offline Mode button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOptions_Click(object sender, EventArgs e)
        {
            if (this.btnImportSearch != null 
                && this.btnExportSearch != null
                && this.lblImportExport != null
                && this.rtxtImportExportLocation != null
                && this.btnImportDirectory != null)
            {
                if(this.btnImportSearch.Visible
                   && this.btnExportSearch.Visible
                   && this.lblImportExport.Visible
                   && this.rtxtImportExportLocation.Visible
                   && this.btnImportDirectory.Visible)
                {
                    this.btnImportSearch.Visible = false;
                    this.btnExportSearch.Visible = false;
                    this.lblImportExport.Visible = false;
                    this.rtxtImportExportLocation.Visible = false;
                    this.btnImportDirectory.Visible = false;
                }
                else
                {
                    this.btnImportSearch.Visible = true;
                    this.btnExportSearch.Visible = true;
                    this.lblImportExport.Visible = true;
                    this.rtxtImportExportLocation.Visible = true;
                    this.btnImportDirectory.Visible = true;
                }
            }
        }

        /// <summary>
        /// Artist / Song search rich tech box key press event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rtxtArtistSongEntry_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        /// <summary>
        /// Key Down event handler for artist/song entry text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtArtistSongEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// SpotifySearchView's On Load Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpotifySearchView_Load(object sender, EventArgs e)
        {
            PopulateMaxSearchComboBox();
            this.rtxtImportExportLocation.Enabled = false;
            HideAdvancedOptionsOnLoad();
            this.btnSearch.Enabled = false;
            this.btnSearch.BackColor = Color.DimGray;
        }

        /// <summary>
        /// Populates max search combo box on form load
        /// </summary>
        private void PopulateMaxSearchComboBox()
        {
            if (string.IsNullOrEmpty(this.cbxMaxSearch.Text))
            {
                List<string> data = new List<string>
                {
                    "1", "2", "3", "4", "5", "10", "15", "20", "25", "30", "35", "40", "45", "50"
                };

                this.cbxMaxSearch.DataSource = data;
            }
        }

        /// <summary>
        /// btnSearch click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadResults();
        }
        
        /// <summary>
        /// Static boolean changed after successful authentication
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Api_Authenticated(object sender, EventArgs e)
        {
            Authenticated = true;
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Hides Import / Export UI elements which requires options to be clicked first
        /// </summary>
        private void HideAdvancedOptionsOnLoad()
        {
            if (this.btnImportSearch != null && this.btnExportSearch != null)
            {
                this.btnImportSearch.Visible = false;
                this.btnExportSearch.Visible = false;
                this.lblImportExport.Visible = false;
                this.rtxtImportExportLocation.Visible = false;
                this.btnImportDirectory.Visible = false;
            }
        }

        /// <summary>
        /// Authenticate Spotify Service.
        /// </summary>
        private void AuthenticateAndStartService()
        {
            Api.Authenticated += Api_Authenticated;

            Task.Run(() =>
            {
                Api.Authenticate(true);
            });

            while (Authenticated == false)
            {
                // do something
                if (MessageBox.Show(
                    @"Please confirm Spotify account in web browser window that opened and then click ok... or click cancel to use offline import/export (options) features",
                    @"Check Browser",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Hand) == DialogResult.Cancel)
                {
                    this.btnSearch.Visible = false;
                    break;
                }
            }
        }

        /// <summary>
        /// Load Results based on user selection
        /// </summary>
        private void LoadResults()
        {
            // Clear panel for each subsequent search.
            if(this.flwSearchResultsFlowPanel.Controls.Count > 0 ) 
                this.flwSearchResultsFlowPanel.Controls.Clear();

            string searchQuery = this.rtxtArtistSongEntry.Text;

            // SearchType.* from user
            SearchType searchType;
            if (this.rbtnArtistSearch.Checked)
            {
                searchType = SearchType.artist;
            }
            else
            {
                searchType = SearchType.track;
            }

            // Search Limit from user
            int searchLimit = Convert.ToInt16(cbxMaxSearch.SelectedValue);

            string artistsJson = string.Empty;

            try
            {
                artistsJson = Api.Search($"{searchQuery}", searchType, searchLimit, 0);
            }
            catch (Exception e)
            {
                MessageBox.Show(@"Invalid search parameters or user not authenticated. Relaunch app and sign into Spotify via the web browser that launches on applicaton startup. If you receive error again please contact admin @ 1-888-555-5555. Error Message: " 
                                + e.Message, @"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.btnSearch.Enabled = false;
                this.btnSearch.BackColor = Color.DimGray;
            }
            
            SpotifySearchPresenter p = new SpotifySearchPresenter(this);
            switch (searchType)
            {
                case SearchType.artist:
                    p.ProcessStringJsonIntoSpotifyArtistsModel(artistsJson);
                    break;
                case SearchType.track:
                    p.ProcessStringJsonIntoSpotifyTracksModel(artistsJson);
                    break;
                default:
                    // leave method if cannot process
                    MessageBox.Show(@"Could not process Json");
                    return;
            }

            // Populate UI with result user control list.
            ListItemUserControl[] listItems = new ListItemUserControl[] { };
            if (searchType == SearchType.artist && ArtistsResults != null)
            {
                listItems = new ListItemUserControl[ArtistsResults.Artists.Items.Count];
            }

            if (searchType == SearchType.track && TracksResults != null)
            {
                listItems = new ListItemUserControl[TracksResults.Tracks.Items.Count];
            }

            for (int i = 0; i < listItems.Length; i++)
            {
                listItems[i] = new ListItemUserControl
                {
                    Width = flwSearchResultsFlowPanel.Width,
                    Icon = Resources.spotify_icon_01,
                    IconBackGround = Color.Black
                };

                switch (searchType)
                {
                    case SearchType.artist:
                        listItems[i].Title = ArtistsResults.Artists.Items[i].Name;
                        listItems[i].Message = $"Artist Spotify ID: {ArtistsResults.Artists.Items[i].Id}"
                                               + Environment.NewLine + "Click to view metadata.";
                        break;
                    case SearchType.track:
                        listItems[i].Title = TracksResults.Tracks.Items[i].Name;
                        listItems[i].Message = $"Track Spotify ID: {TracksResults.Tracks.Items[i].Id}"
                            + Environment.NewLine + "Click to view metadata.";
                        break;
                }

                if (flwSearchResultsFlowPanel.Controls.Count < 0)
                {
                    flwSearchResultsFlowPanel.Controls.Clear();
                }
                else
                {
                    this.flwSearchResultsFlowPanel.Controls.Add(listItems[i]);
                }
            }
        }

        #endregion
    }
}
