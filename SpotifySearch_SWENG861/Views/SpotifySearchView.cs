﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using CefSharp;
using CefSharp.WinForms;
using CSharp_SpotifyAPI;
using CSharp_SpotifyAPI.Enums;
using CSharp_SpotifyAPI.Models;
using SpotifySearch_SWENG861.Constants;
using SpotifySearch_SWENG861.Helpers;
using SpotifySearch_SWENG861.PresentationObjects;
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
            AuthenticateAndStartService();
            InitializeChromeBrowser();
        }

        #region Properties

        /// <summary>
        /// Boolean that represents if user has activated an online search prior to
        /// clicking meta data view.
        /// </summary>
        public bool IsOnlineSearch { get; set; }
        
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
        /// Array of Import Search results
        /// </summary>
        public List<SpotifySearchPO> ImportResults { get; set; }

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
        /// btnExportSearch click event. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportSearch_Click(object sender, EventArgs e)
        {
            SpotifySearchPresenter p = new SpotifySearchPresenter(this);
            p.CollectSpotifySearchViewList(SpotifySearchPOListFromUI());
            p.ExportData();
            KeepTopMostAndBringToFront();
        }

        /// <summary>
        /// btnImportSearch click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportSearch_Click(object sender, EventArgs e)
        {
            if (fileBrowserDialog != null)
            {
                fileBrowserDialog.Filter = @"xml files (*.xml)|*.xml";

                if (this.fileBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileNameAndPath = fileBrowserDialog.FileName;

                    FileImportHelper helper = new FileImportHelper();
                    if (helper.DetermineIfSelectedXmlIsValid(fileNameAndPath))
                    {
                        SpotifySearchPresenter p = new SpotifySearchPresenter(this);
                        p.ImportData(XMLImportList(fileNameAndPath));
                        KeepTopMostAndBringToFront();
                    }
                    else
                    {
                        MessageBox.Show(
                            @"The selected file is not compatible for import. SpotifySearch *.xml files only. See manual for more details.", @"File Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        KeepTopMostAndBringToFront();
                    }
                }
            }
        }

        /// <summary>
        /// rtxtImportExportLocation text changed event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rtxtImportExportLocation_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// btnImportDirectory click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportDirectory_Click(object sender, EventArgs e)
        {
            if (fldrBrowserDialog != null)
            {
                fldrBrowserDialog.ShowNewFolderButton = true;

                if (this.fldrBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    if (this.rtxtExportLocation != null)
                    {
                        this.rtxtExportLocation.Text = fldrBrowserDialog.SelectedPath;
                        this.rtxtExportLocation.Focus();
                        this.rtxtExportLocation.Select(this.rtxtExportLocation.Text.Length, 0);
                    }
                }
            }
        }

        /// <summary>
        /// SpotifySearchView form closing event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpotifySearchView_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Shutdown Chrome browser instance
            Cef.Shutdown();
        }

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
                && this.lblExport != null
                && this.rtxtExportLocation != null
                && this.btnImportDirectory != null)
            {
                if(this.btnImportSearch.Visible
                   && this.btnExportSearch.Visible
                   && this.lblExport.Visible
                   && this.rtxtExportLocation.Visible
                   && this.btnImportDirectory.Visible)
                {
                    this.btnImportSearch.Visible = false;
                    this.btnExportSearch.Visible = false;
                    this.lblExport.Visible = false;
                    this.rtxtExportLocation.Visible = false;
                    this.btnImportDirectory.Visible = false;
                }
                else
                {
                    this.btnImportSearch.Visible = true;
                    this.btnExportSearch.Visible = true;
                    this.lblExport.Visible = true;
                    this.rtxtExportLocation.Visible = true;
                    this.rtxtExportLocation.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    this.rtxtExportLocation.Focus();
                    this.rtxtExportLocation.Select(this.rtxtExportLocation.Text.Length, 0);
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
            HideAdvancedOptionsOnLoad();
            this.rtxtExportLocation.ReadOnly = true;
            this.btnSearch.Enabled = false;
            this.btnSearch.BackColor = Color.DimGray;
        }

        /// <summary>
        /// btnSearch click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.rtxtArtistSongEntry.Text))
            {
                MessageBox.Show(@"Please enter an artist or song to search and try again.", @"Invalid search parameters",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);

                return;
            }

            LoadResults();
            IsOnlineSearch = true;
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
        /// Creates SpotifySearchPO list from XML Import file.
        /// </summary>
        /// <param name="fileNameAndPath"></param>
        /// <returns></returns>
        private List<SpotifySearchPO> XMLImportList(string fileNameAndPath)
        {
            if (string.IsNullOrEmpty(fileNameAndPath)) return new List<SpotifySearchPO>();

            List<SpotifySearchPO> importList = new List<SpotifySearchPO>();

            try
            {
                XDocument doc = XDocument.Load(fileNameAndPath);
                XElement spotifySearchResults 
                    = doc.Element(SpotifySearchXMLPDFConstants.SpotifySearchResults);

                foreach (XElement item in spotifySearchResults.Elements())
                {
                    SpotifySearchPO po = new SpotifySearchPO();


                    if (item.Name == SpotifySearchXMLPDFConstants.SearchResults)
                    {
                        po.Title = item
                            .Element(SpotifySearchXMLPDFConstants.Title)
                            .Value;

                        po.Message = item
                            .Element(SpotifySearchXMLPDFConstants.Message)
                            .Value;

                        po.NewLineImport = item
                            .Element(SpotifySearchXMLPDFConstants.EmptyLine)
                            .Value;

                        po.Name = item
                            .Element(SpotifySearchXMLPDFConstants.Name)
                            .Value;

                        po.ExplicitWords = Convert.ToBoolean(item
                            .Element(SpotifySearchXMLPDFConstants.ExplicitWords)
                            .Value);

                        po.Popularity = Convert.ToInt32(item
                            .Element(SpotifySearchXMLPDFConstants.Popularity)
                            .Value);

                        po.FollowerTotal = Convert.ToInt32(item
                            .Element(SpotifySearchXMLPDFConstants.FollowerTotal)
                            .Value);

                        po.Id = item
                            .Element(SpotifySearchXMLPDFConstants.Id)
                            .Value;

                        po.IsLocal = Convert.ToBoolean(item
                            .Element(SpotifySearchXMLPDFConstants.IsLocal)
                            .Value);

                        po.Href = item
                            .Element(SpotifySearchXMLPDFConstants.Href)
                            .Value;

                        po.AvailableMarkets = new string[]
                        {
                            item
                                .Element(SpotifySearchXMLPDFConstants.AvailableMarkets)
                                .Value
                        };

                        po.PreviewUrl = item
                            .Element(SpotifySearchXMLPDFConstants.PreviewUrl)
                            .Value;

                        string artists = item
                            .Element(SpotifySearchXMLPDFConstants.Artists).Value;

                        string[] artistList = artists.Split(' ');

                        po.Artists = new List<Artist>();
                        for (int i = 0; i < artistList.Length; i++)
                        {
                            for (int j = 0; j < po.Artists.Count; i++)
                            {
                                artistList[i] = po.Artists[j].Name;
                            }
                        }

                        po.TrackNumber = Convert.ToInt32(item
                            .Element(SpotifySearchXMLPDFConstants.TrackNumber)
                            .Value);

                        po.DurationMS = Convert.ToInt32(item
                            .Element(SpotifySearchXMLPDFConstants.DurationMS)
                            .Value);

                        po.DiscNumber = Convert.ToInt32(item
                            .Element(SpotifySearchXMLPDFConstants.DiscNumber)
                            .Value);

                        po.ExternalUrls_Spotify = item
                            .Element(SpotifySearchXMLPDFConstants.ExternalUrls)
                            .Value;

                        po.ImportExportLocationText = item
                            .Element(SpotifySearchXMLPDFConstants.ImportExportLocationText)
                            .Value;
                    }

                    importList.Add(po);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(@"Unable to Import file. File is either corrupt or xml tags are from a deprecated version of export."
                                + Environment.NewLine
                                + $@" Error: {e}", @"Import File Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);

                KeepTopMostAndBringToFront();
                return new List<SpotifySearchPO>();
            }

            MessageBox.Show(@"Import Successful! Click 'OK' to update app.", @"Success");
   
            IsOnlineSearch = false;
            KeepTopMostAndBringToFront();
            ImportResults = importList;

            return ImportResults;
        }

        /// <summary>
        /// Brings main form to front of form hierarchy
        /// </summary>
        private void KeepTopMostAndBringToFront()
        {
            this.TopMost = true;
            this.BringToFront();
        }

        /// <summary>
        /// Create SpotifySearchPO list from relevant UI elements.
        /// </summary>
        /// <returns></returns>
        private List<SpotifySearchPO> SpotifySearchPOListFromUI()
        {
            int searchCount = 0;

            if (IsArtistSearch)
            {
                if(ArtistsResults == null) return new List<SpotifySearchPO>();
                searchCount = ArtistsResults.Artists.Items.Count;
            }

            if (IsSongSearch)
            {
                if(TracksResults == null) return new List<SpotifySearchPO>();
                searchCount = TracksResults.Tracks.Items.Count;
            }

            List<SpotifySearchPO> list = new List<SpotifySearchPO>();
            
            string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string selectedDirectory = this.rtxtExportLocation.Text;

            for (int i = 0; i < searchCount; i++)
            {
                SpotifySearchPO po = new SpotifySearchPO();

                if (IsArtistSearch)
                {
                    Item artistObject = ArtistsResults.Artists.Items[i];
                    po.Title = artistObject.Name;
                    po.Message = $"Artist Spotify ID: {artistObject.Id}"
                                      + Environment.NewLine + "Click to view metadata.";
                    
                    // high level artists object
                    FillSpotifySearchPOWithMetaDataPortion(po, artistObject);
                }

                if (IsSongSearch)
                {
                    Item trackObject = TracksResults.Tracks.Items[i];
                    po.Title = trackObject.Name;
                    po.Message = $"Track Spotify ID: {trackObject.Id}"
                                      + Environment.NewLine + "Click to view metadata.";

                    FillSpotifySearchPOWithMetaDataPortion(po, trackObject);
                }
                
                if (rtxtExportLocation != null && !string.IsNullOrEmpty(selectedDirectory))
                {
                    po.ImportExportLocationText = selectedDirectory;
                }
                else
                {
                    // Default import / export location is "MyDocuments" environment variable if none selected.
                    po.ImportExportLocationText = defaultPath;
                }

                list.Add(po);
            }

            return list;
        }

        /// <summary>
        /// Fill meta data portion of SpotifySearchPO via injected Item object
        /// </summary>
        /// <param name="po">SpotifySearchPO</param>
        /// <param name="dataObject">dataObject</param>
        private void FillSpotifySearchPOWithMetaDataPortion(SpotifySearchPO po, Item dataObject)
        {
            po.ArtistsResults = ArtistsResults;
            po.TracksResults = TracksResults;
            if (dataObject.Name != null) po.Name = dataObject.Name;
            po.ExplicitWords = dataObject.ExplicitWords;
            if (dataObject.Genres != null) po.Genres = dataObject.Genres;
            po.Popularity = dataObject.Popularity;
            
            if (dataObject.Followers != null)
            {
                po.FollowerTotal = dataObject.Followers.Total;
            }

            if (dataObject.Id != null) po.Id = dataObject.Id;
            po.IsLocal = dataObject.Is_local;
            if (dataObject.Href != null)
            {
                dataObject.Href = dataObject.Href.Replace("https://", "");
                po.Href = dataObject.Href;
            }

            po.TrackNumber = dataObject.Track_number;
            if (dataObject.available_markets != null) po.AvailableMarkets = dataObject.available_markets;
            if (dataObject.Preview_url != null) po.PreviewUrl = dataObject.Preview_url;
            if (dataObject.artists != null)
            {
                po.Artists = new List<Artist>();
                for (int i = 0; i < dataObject.artists.Count; i++)
                {
                    po.Artists.Add(dataObject.artists[i]);
                }
            }
                
            po.DurationMS = dataObject.duration_ms;
            if (dataObject.External_urls.Spotify != null)
                po.ExternalUrls_Spotify = dataObject.External_urls.Spotify;
            po.DiscNumber = dataObject.disc_number;
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
        /// Initializes Chrome Browser on app start up.
        /// If 'this' changes from main form this initialize() should be moved to it.
        /// </summary>
        private void InitializeChromeBrowser()
        {
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
        }

        /// <summary>
        /// Hides Import / Export UI elements which requires options to be clicked first
        /// </summary>
        private void HideAdvancedOptionsOnLoad()
        {
            if (this.btnImportSearch != null && this.btnExportSearch != null)
            {
                this.btnImportSearch.Visible = false;
                this.btnExportSearch.Visible = false;
                this.lblExport.Visible = false;
                this.rtxtExportLocation.Visible = false;
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
                if (MessageBox.Show(
                        @"Please confirm Spotify account in web browser window that opened and then click ok... or click cancel to use offline import/export (options) features.",
                        @"Check Browser",
                        MessageBoxButtons.OKCancel, 
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly) == DialogResult.Cancel)
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
                MessageBox.Show(@"Invalid search parameters or user not authenticated. 
Relaunch app and sign into Spotify via the web browser that launches on application startup. 
If you receive error again please contact admin @ 1-888-555-5555. 

Error Message: " + e.Message, @"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                        if (ArtistsResults != null)
                        {
                            listItems[i].Title = ArtistsResults.Artists.Items[i].Name;
                            listItems[i].Message = $"Artist Spotify ID: {ArtistsResults.Artists.Items[i].Id}"
                                                   + Environment.NewLine + "Click to view metadata.";
                        }

                        break;
                    case SearchType.track:
                        if (TracksResults != null)
                        {
                            listItems[i].Title = TracksResults.Tracks.Items[i].Name;
                            listItems[i].Message = $"Track Spotify ID: {TracksResults.Tracks.Items[i].Id}"
                                                   + Environment.NewLine + "Click to view metadata.";
                        }

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
            
            if (flwSearchResultsFlowPanel.Controls.Count == 0)
            {
                MessageBox.Show(@"No results found. Please modify search text and / or parameters and try again.",
                    @"Prompt",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        #endregion
    }
}
