using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using CSharp_SpotifyAPI;
using CSharp_SpotifyAPI.Enums;
using CSharp_SpotifyAPI.Models;
using SpotifySearch_SWENG861.Presenters;
using SpotifySearch_SWENG861.Properties;
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
            AuthenticateAndStartService();
            
        }

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
        /// btnSearch click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
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
            int searchLimit = Convert.ToInt16(txtMaxSearch.Text);

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
            UcSearchResultItem[] listItems = new UcSearchResultItem[] { };
            if (searchType == SearchType.artist)
            {
                listItems = new UcSearchResultItem[ArtistsResults.Artists.Items.Count];
            }

            if (searchType == SearchType.track)
            {
                listItems = new UcSearchResultItem[TracksResults.Tracks.Items.Count];
            }

            for (int i = 0; i < listItems.Length; i++)
            {
                listItems[i] = new UcSearchResultItem();
                listItems[i].Width = flwSearchResultsFlowPanel.Width;
                listItems[i].Icon = Resources.spotify_icon_01;
                listItems[i].IconBackGround = Color.Black;


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
