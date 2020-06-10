using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharp_SpotifyAPI;
using CSharp_SpotifyAPI.Models;
using Microsoft.SqlServer.Server;
using SpotifySearch_SWENG861.ViewInterfaces;

namespace SpotifySearch_SWENG861.Views
{
    public partial class AdditionalMetaDataView : Form, IAdditionalMetaDataView
    {
        private readonly SearchSongs _songData;
        private readonly SearchArtists _artistData;

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
        public AdditionalMetaDataView(SearchSongs songData, SearchArtists artistData)
        {
            InitializeComponent();
            this._songData = songData;
            this._artistData = artistData;
        }

        /// <summary>
        /// Loads Search Songs meta data into rtxtMetaData rich text box
        /// </summary>
        /// <param name="type">artist or song constant</param>
        /// <param name="index">index of item selected</param>
        public void LoadMetaData(string type, int index)
        {
            if (type == Constants.Artist)
            {
                if (_artistData == null) return;

                // High level item object of type track (includes nested elements)
                Item artistObject = _artistData.Artists.Items[index];

                DataToTextBox(CreateDataList(artistObject, index));
            }

            if (type == Constants.Song)
            {
                if (_songData == null) return;

                // High level item object of type track (includes nested elements)
                Item trackObject = _songData.Tracks.Items[index];

                DataToTextBox(CreateDataList(trackObject, index));
            }

            if (type != Constants.Artist && type != Constants.Song)
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

        private List<string> CreateDataList(Item dataObject, int index)
        {
            if (dataObject == null) return new List<string>();

            Debug.Print(dataObject.Name.FirstOrDefault().ToString());


            List<string> data = new List<string>
            {
                // todo find the null object in this list. a regular string works fine. 
                "Name: " + dataObject.Name,
                "Explicit Content: " + dataObject.ExplicitWords,
                // todo genres for only works for one. 
                //"Genres: " + dataObject.Genres[index].FirstOrDefault(),
                //"Popularity Total: " + dataObject.Popularity,
                //"Followers: " + dataObject.Followers.Total,
                //"ID: " + dataObject.Id.FirstOrDefault(),
                //"Available Markets: " + dataObject.available_markets[index].FirstOrDefault(),
                //"Is Local: " + dataObject.Is_local,
                //"Link: " + dataObject.Href.FirstOrDefault()
            };

            return data;
        }

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
