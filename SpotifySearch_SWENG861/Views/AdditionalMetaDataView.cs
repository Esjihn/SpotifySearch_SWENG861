using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CSharp_SpotifyAPI;
using CSharp_SpotifyAPI.Models;
using SpotifySearch_SWENG861.PresentationObjects;
using SpotifySearch_SWENG861.ViewInterfaces;

namespace SpotifySearch_SWENG861.Views
{
    public partial class AdditionalMetaDataView : Form, IAdditionalMetaDataView
    {
        private readonly SearchSongs _songData;
        private readonly SearchArtists _artistData;
        private readonly List<SpotifySearchPO> _importData;

        /// <summary>
        /// Default constructor
        /// </summary>
        public AdditionalMetaDataView()
        {

        }

        /// <summary>
        /// Track / Artist version constructor
        /// </summary>
        /// <param name="songData"></param>
        /// <param name="artistData"></param>
        /// <param name="importData"></param>
        public AdditionalMetaDataView(SearchSongs songData, SearchArtists artistData, List<SpotifySearchPO> importData)
        {
            InitializeComponent();
            this._songData = songData;
            this._artistData = artistData;
            this._importData = importData;
        }

        #region Event Handlers
        
        /// <summary>
        /// Link clicked in meta data rich text box event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rtxtMetaData_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (e.LinkText != null)
            {
                System.Diagnostics.Process.Start(e.LinkText);
            }
        }

        #endregion

        /// <summary>
        /// Loads Search Songs meta data into rtxtMetaData rich text box
        /// </summary>
        /// <param name="type">artist or song constant</param>
        /// <param name="index">index of item selected</param>
        public void LoadMetaData(string type, int index)
        {
            if (type == SpotifyAPIConstants.Artist && index <= _artistData.Artists.Items.Count)
            {
                if (_artistData == null) return;

                // High level item object of type track (includes nested elements)
                Item artistObject = _artistData.Artists.Items[index];

                DataToTextBox(CreateDataList(artistObject, index));
            }

            if (type == SpotifyAPIConstants.Song && index <= _songData.Tracks.Items.Count)
            {
                if (_songData == null) return;

                // High level item object of type track (includes nested elements)
                Item trackObject = _songData.Tracks.Items[index];

                DataToTextBox(CreateDataList(trackObject, index));
            }

            if (type == SpotifyAPIConstants.Import && index <= _importData.Count)
            {
                if (_importData == null) return;

                ImportDataToTextBox(_importData[index], index);
            }

            if (type != SpotifyAPIConstants.Artist 
                && type != SpotifyAPIConstants.Song
                && type != SpotifyAPIConstants.Import)
            {
                if (this.rtxtMetaData != null)
                {
                    if (!string.IsNullOrEmpty(this.rtxtMetaData.Text))
                    {
                        this.rtxtMetaData.Text = string.Empty;
                    }

                    this.rtxtMetaData.Text = @"MetaData could not be located.";
                }
            }
        }

        /// <summary>
        /// Import SpotifySearchPO per item
        /// Do not use item.TrackResults or item.ArtistsResults
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>
        private void ImportDataToTextBox(SpotifySearchPO item, int index)
        {
            if (item == null) return;

            if (this.rtxtMetaData != null)
            {
                if (!string.IsNullOrEmpty(this.rtxtMetaData.Text))
                {
                    this.rtxtMetaData.Text = string.Empty;
                }

                RichTextBox txt = this.rtxtMetaData;
                string newLine = Environment.NewLine;
                
                if (txt != null)
                {
                    if (item.Name != null) txt.Text = @"Name: " + item.Name + newLine;
                    txt.Text += @"Explicit Content: " + item.ExplicitWords + newLine;
                    if (item.Genres != null && index <= item.Genres.Count)
                        txt.Text += @"Genres: " + item.Genres[index] + newLine;
                    txt.Text += @"Popularity Total: " + item.Popularity + newLine;
                    if (item.Followers != null) txt.Text += @"Followers: " + item.Followers.Total + newLine;
                    if (item.Id != null) txt.Text += @"ID: " + item.Id + newLine;
                    txt.Text += @"Is Local: " + item.IsLocal + newLine;

                    if (item.Href != null)
                    {
                        // This link requires a token so remove link state from view. 
                        item.Href = item.Href.Replace("https://", "");
                        txt.Text += @"Internal API Link: " + item.Href + newLine;
                    }

                    txt.Text += @"Track Number: " + item.TrackNumber + newLine;
                    if (item.AvailableMarkets != null && index <= item.AvailableMarkets.Count)
                        txt.Text += @"Available Markets: " + item.AvailableMarkets[index] + newLine;
                    if (item.PreviewUrl != null) txt.Text += @"Preview Url: " + item.PreviewUrl + newLine;
                    if (item.Artists != null && item.Artists.Count > 0) txt.Text += @"Artists: " + item.Artists[index].Name + newLine;
                    txt.Text += @"Song Duration: " + item.DurationMS + newLine;
                    txt.Text += @"Disc Number: " + item.DiscNumber + newLine;
                    if (item.ExternalUrls_Spotify != null)
                        txt.Text += @"External Urls: " + item.ExternalUrls_Spotify;
                }
            }
        }

        /// <summary>
        /// Massages Spotify Objects into readable list for view
        /// </summary>
        /// <param name="dataObject"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private List<string> CreateDataList(Item dataObject, int index)
        {
            if (dataObject == null) return new List<string>();

            List<string> data = new List<string> {Environment.NewLine};
            if(dataObject.Name != null) data.Add("Name: " + dataObject.Name);
            data.Add("Explicit Content: " + dataObject.ExplicitWords);
            if(dataObject.Genres != null && dataObject.Genres.Count > 0 && index <= dataObject.Genres.Count) data.Add("Genres: " + dataObject.Genres[index]);
            data.Add("Popularity Total: " + dataObject.Popularity);
            if(dataObject.Followers != null) data.Add("Followers: " + dataObject.Followers.Total);
            if(dataObject.Id != null) data.Add("ID: " + dataObject.Id);
            data.Add("Is Local: " + dataObject.Is_local);
            
            if (dataObject.Href != null)
            {
                // This link requires a token so remove link state from view. 
                dataObject.Href = dataObject.Href.Replace("https://", "");
                data.Add("Internal API Link: " + dataObject.Href);
            }

            data.Add("Track Number: " + dataObject.Track_number);
            if(dataObject.available_markets != null && index <= dataObject.available_markets.Count) 
                data.Add("Available Markets: " + dataObject.available_markets[index]);
            if(dataObject.Preview_url != null) data.Add("Preview Url: " + dataObject.Preview_url);
            if(dataObject.artists != null && dataObject.artists.Count > 0) data.Add("Artists: " + dataObject.artists[0].Name);
            data.Add("Song Duration: " + dataObject.duration_ms);
            data.Add("Disc Number: " + dataObject.disc_number);
            if(dataObject.External_urls.Spotify != null) 
                data.Add("External Urls: " + dataObject.External_urls.Spotify);

            return data;
        }

        /// <summary>
        /// Sends massaged data to views textbox
        /// </summary>
        /// <param name="data"></param>
        private void DataToTextBox(List<string> data)
        {
            if (this.rtxtMetaData != null)
            {
                if (!string.IsNullOrEmpty(this.rtxtMetaData.Text))
                {
                    this.rtxtMetaData.Text = string.Empty;
                }

                foreach (string item in data)
                {
                    this.rtxtMetaData.Text += item + Environment.NewLine;
                }
            }
        }
    }
}
