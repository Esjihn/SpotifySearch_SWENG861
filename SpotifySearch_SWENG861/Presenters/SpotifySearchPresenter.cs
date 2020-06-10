using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharp_SpotifyAPI.Models;
using Newtonsoft.Json;
using SpotifySearch_SWENG861.PresentationObjects;
using SpotifySearch_SWENG861.ViewInterfaces;

namespace SpotifySearch_SWENG861.Presenters
{
    /// <summary>
    /// Presenter for ListenOnSpotifyView, SpotifySearchView, ListenItemUserControl, and AdditionalMetaDataView
    /// </summary>
    public class SpotifySearchPresenter
    {
        #region Interface variables

        private ISpotifySearchView _viewMain;
        private IListenOnSpotifyView _viewWeb;
        private IListItemUserControl _userControl;
        private IAdditionalMetaDataView _viewMetalData;

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

        /// <summary>
        /// IAdditionalMetaDataView constructor
        /// </summary>
        /// <param name="viewMetaData"></param>
        public SpotifySearchPresenter(IAdditionalMetaDataView viewMetaData)
        {
            this._viewMetalData = viewMetaData;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Complete Frame Data list from UI
        /// </summary>
        private List<SpotifySearchPO> CompleteSpotifySearchList { get; set; }

        /// <summary>
        /// Determines if CollectSpotifySearchViewList has a valid list. If not then
        /// ExportData is not run. 
        /// </summary>
        public bool IsValidPOList { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Exports Data to XML and PDF File
        /// </summary>
        public void ExportData()
        {
            if (IsValidPOList == false)
            {
                MessageBox.Show(@"Exception: export could not be completed.", @"Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);

                return;
            }

            // todo finish
            // leverage XMLBuilder, SpotifySearchPO path from CompleteSpotifySearchList.FirstOrDefault LINQ
            // leverage DateTime date = DateTime.Now
        }

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

        /// <summary>
        /// Collect Frame Data UI data and place into property for use. 
        /// </summary>
        /// <param name="list"></param>
        /// <returns>List of SpotifySearchPO</returns>
        internal void CollectSpotifySearchViewList(List<SpotifySearchPO> list)
        {
            if (list == null || list.Count == 0)
            {
                IsValidPOList = false;
                return;
            }

            IsValidPOList = true;
            CompleteSpotifySearchList = list;
        }
    }
}
