using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using CSharp_SpotifyAPI;
using CSharp_SpotifyAPI.Enums;
using CSharp_SpotifyAPI.Models;
using SpotifySearch_SWENG861.Presenters;
using SpotifySearch_SWENG861.Properties;
using SpotifySearch_SWENG861.UserControls;
using SpotifySearch_SWENG861.ViewInterfaces;

namespace SpotifySearch_SWENG861
{
    public partial class SpotifySearchView : Form, ISpotifySearchView
    {
        #region Spotify Authentification

        public static bool authenticated = false;

        /// <summary>
        /// todo change these to project resource string variables
        /// </summary>
        static string clientID = "305dbadf23cd4d9688868eb01857b54b";
        static string redirectID = "http%3A%2F%2Flocalhost%3A62177";
        static string state = "123";

        static List<Scope> scope = new List<Scope>()
        {
            Scope.UserReadPrivate, Scope.UserReadBirthdate, Scope.UserModifyPlaybackState, Scope.UserModifyPlaybackState, Scope.UserFollowRead, Scope.UserFollowModify, Scope.UserReadRecentlyPlayed, Scope.UserReadPlaybackState
        };

        private static SpotifyAPI api = new SpotifyAPI(clientID, redirectID, state, scope, true);

        #endregion

        public SpotifySearchView()
        {
            InitializeComponent();
            // TODO keep disabled until closer to completion
            //AuthenticateAndStartService();
            
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
        #endregion

        #region Event Handlers

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
            // TODO place logic in here to go into an offline mode state where the search button is disabled
            // but the user can import songs via xml that have been exported.

            LoadResults();
        }
        
        /// <summary>
        /// Static boolean changed after successful authentication
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Api_Authenticated(object sender, EventArgs e)
        {
            authenticated = true;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Authenticate Spotify Service.
        /// </summary>
        private void AuthenticateAndStartService()
        {
            api.Authenticated += Api_Authenticated;

            Task.Run(() =>
            {
                api.Authenticate(true);
            });

            while (authenticated == false)
            {
                // todo add logic if authentication fails
            }
        }

        /// <summary>
        /// Load Results based on user selection
        /// </summary>
        private void LoadResults()
        {
            // todo get user selections and call presenter to process results and send us result objects.
            // todo add regex to remove special characters? research unique artist and album names
            // todo that spotify allows.
            // Clear panel for each subsequent search.
            if(this.flwSearchResultsFlowPanel.Controls.Count > 0 ) 
                this.flwSearchResultsFlowPanel.Controls.Clear();

            // Search query from user
            // todo find out what is not allowed in spotify search (test using UI)
            string searchQuery = this.txtArtistSongEntry.Text;

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

            // Search Limit from user // todo add search restrictions between 0-50
            // todo add restrictions to only be able to type in numbers preferably inside of Form
            int searchLimit = Convert.ToInt16(cbxMaxSearch.SelectedValue);

            string artistsJson = api.Search($"{searchQuery}", searchType, searchLimit, 0);

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
                    MessageBox.Show("Could not process Json");
                    return;
            }

            // Populate UI with result user control list.
            ListItemUserControl[] listItems = new ListItemUserControl[] { };
            if (searchType == SearchType.artist)
            {
                listItems = new ListItemUserControl[ArtistsResults.Artists.Items.Count];
            }

            if (searchType == SearchType.track)
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
