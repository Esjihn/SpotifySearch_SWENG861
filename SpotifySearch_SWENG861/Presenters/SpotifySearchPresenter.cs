using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using CSharp_SpotifyAPI.Enums;
using CSharp_SpotifyAPI.Models;
using Newtonsoft.Json;
using SpotifySearch_SWENG861.Builders;
using SpotifySearch_SWENG861.PresentationObjects;
using SpotifySearch_SWENG861.Properties;
using SpotifySearch_SWENG861.UserControls;
using SpotifySearch_SWENG861.ViewInterfaces;

namespace SpotifySearch_SWENG861.Presenters
{
    /// <summary>
    /// Presenter for ListenOnSpotifyView, SpotifySearchView, ListenItemUserControl, and AdditionalMetaDataView
    /// </summary>
    public class SpotifySearchPresenter
    {
        #region Interface variables

        private readonly ISpotifySearchView _viewMain;
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
        /// Imports XML to UI.
        /// </summary>
        /// <param name="xmlImportList"></param>
        public void ImportData(List<SpotifySearchPO> xmlImportList)
        {
            if (xmlImportList == null || xmlImportList.Count == 0) return;

            // Populate UI with result user control list.
            ListItemUserControl[] listItems = new ListItemUserControl[xmlImportList.Count];
            
            for (int i = 0; i < listItems.Length; i++)
            {
                listItems[i] = new ListItemUserControl
                {
                    Width = _viewMain.FlowPanelObject.Width,
                    Icon = Resources.spotify_icon_01,
                    IconBackGround = Color.Black
                };

                foreach (SpotifySearchPO po in xmlImportList)
                {
                    listItems[i].Title = po.Title;
                    listItems[i].Message = $"Artist Spotify ID: {po.Message}"
                                           + Environment.NewLine + "Click to view metadata.";
                }
                
                if (_viewMain.FlowPanelObject.Controls.Count > 0)
                {
                    _viewMain.FlowPanelObject.Controls.Clear();
                }
                else
                {
                    this._viewMain.FlowPanelObject.Controls.Add(listItems[i]);
                }
            }
        }

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

            // 1. Build Export XML for import (leverage XMLBuilder)
            XMLBuilder xmlBuilder = new XMLBuilder();
            SpotifySearchPO path = CompleteSpotifySearchList.FirstOrDefault(s => !string.IsNullOrEmpty(s.ImportExportLocationText));
            DateTime date = DateTime.Now;

            string fileAppendDateFormat = $"{date.Year}{date.Day}{date.Month}{date.Hour}{date.Minute}";
            string codedPathXml = @"\" + fileAppendDateFormat + "_SpotifySearchResults.xml";
            string codedPathPdf = @"\" + fileAppendDateFormat + "_SpotifySearchResults.pdf";

            if (path != null && !string.IsNullOrEmpty(path.ImportExportLocationText))
            {
                xmlBuilder.CreateXMLFromSpotifySearchPOList(CompleteSpotifySearchList,
                    path.ImportExportLocationText + codedPathXml);

            }
            else
            {
                // Place into my documents folder if user hasn't set an actual folder
                string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string myPath = myDocuments + @"\" + fileAppendDateFormat + "_SpotifySearchResults.xml";
                xmlBuilder.CreateXMLFromSpotifySearchPOList(CompleteSpotifySearchList, myPath);
            }

            // 2. Build Export PDF for easy viewing (leverage PDFBuilder)
            PDFBuilder pdfBuilder = new PDFBuilder();
            if (path != null && !string.IsNullOrEmpty(path.ImportExportLocationText))
            {
                pdfBuilder.CreatePdfFromMainFrameDataPoList(
                    CompleteSpotifySearchList,
                    path.ImportExportLocationText + codedPathPdf);
            }
            else
            {
                // Place into my documents folder if user hasn't set an actual folder
                string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string myPath = myDocuments + @"\" + fileAppendDateFormat + "_SpotifySearchResults.pdf";
                pdfBuilder.CreatePdfFromMainFrameDataPoList(CompleteSpotifySearchList, myPath);
            }
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
