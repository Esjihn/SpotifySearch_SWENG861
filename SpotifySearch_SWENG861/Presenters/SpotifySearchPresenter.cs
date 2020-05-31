using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_SpotifyAPI.Models;
using Newtonsoft.Json;
using SpotifySearch_SWENG861.ViewInterfaces;

namespace SpotifySearch_SWENG861.Presenters
{
    /// <summary>
    /// Presenter for ListenOnSpotifyView, SpotifySearchView and ListenItemUserControl
    /// </summary>
    public class SpotifySearchPresenter
    {
        #region Interface variables

        private ISpotifySearchView _viewMain;
        private IListenOnSpotifyView _viewWeb;
        private IListItemUserControl _userControl;

        #endregion

        #region Constructors
        /// <summary>
        /// Base presenter constructor
        /// </summary>
        public SpotifySearchPresenter()
        {
            
        }

        /// <summary>
        /// ISpotifySearchView constructor
        /// </summary>
        /// <param name="viewMain"></param>
        public SpotifySearchPresenter(ISpotifySearchView viewMain)
        {
            this._viewMain = viewMain;
        }

        /// <summary>
        /// IListenOnSpotifyView constructor
        /// </summary>
        /// <param name="viewWeb"></param>
        public SpotifySearchPresenter(IListenOnSpotifyView viewWeb)
        {
            this._viewWeb = viewWeb;
        }

        /// <summary>
        /// IListItemUserControl constructor
        /// </summary>
        /// <param name="userControl"></param>
        public SpotifySearchPresenter(IListItemUserControl userControl)
        {
            this._userControl = userControl;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Parse json into SpotifySearchView ArtistResults property.
        /// </summary>
        /// <param name="artistsJson">artists json from spotify api result set</param>
        public void ProcessStringJsonIntoSpotifyArtistsModel(string artistsJson)
        {
            if (string.IsNullOrEmpty(artistsJson)) return;

            SearchArtists desArtist = JsonConvert.DeserializeObject<SearchArtists>(artistsJson);

            _viewMain.ArtistsResults = desArtist;
        }

        /// <summary>
        /// Parse json into SpotifySearchView TrackResults property.
        /// </summary>
        /// <param name="tracksJson">tracks json from spotify api result set</param>
        public void ProcessStringJsonIntoSpotifyTracksModel(string tracksJson)
        {
            if (string.IsNullOrEmpty(tracksJson)) return;

            SearchSongs searchSongs = JsonConvert.DeserializeObject<SearchSongs>(tracksJson);

            _viewMain.TracksResults = searchSongs;
        }

        #endregion
    }
}
