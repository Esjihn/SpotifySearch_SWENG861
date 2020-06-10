﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CSharp_SpotifyAPI;
using CSharp_SpotifyAPI.Models;
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
            if(dataObject.Genres != null) data.Add("Genres: " + dataObject.Genres[index]);
            data.Add("Popularity Total: " + dataObject.Popularity);
            if(dataObject.Followers != null) data.Add("Followers: " + dataObject.Followers.Total);
            if(dataObject.Id != null) data.Add("ID: " + dataObject.Id);
            if(dataObject.available_markets != null)
                data.Add("Available Markets: " + dataObject.available_markets[index]);
            data.Add("Is Local: " + dataObject.Is_local);
            if(dataObject.Href != null) data.Add("Link: " + dataObject.Href);
            data.Add("Track Number: " + dataObject.Track_number);
            if(dataObject.available_markets != null) 
                data.Add("Available Markets: " + dataObject.available_markets[index]);
            if(dataObject.Preview_url != null); data.Add("Preview Url: " + dataObject.Preview_url);
            if(dataObject.artists != null) data.Add("Artists: " + dataObject.artists[index]);
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
