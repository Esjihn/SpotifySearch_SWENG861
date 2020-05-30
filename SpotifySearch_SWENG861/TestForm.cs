﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharp_SpotifyAPI;
using CSharp_SpotifyAPI.Enums;
using CSharp_SpotifyAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SpotifySearch_SWENG861
{
    public partial class TestForm : Form
    {
        public static bool authenticated = false;

        static string clientID = "305dbadf23cd4d9688868eb01857b54b";
        static string redirectID = "http%3A%2F%2Flocalhost%3A62177";
        static string state = "123";

        static List<Scope> scope = new List<Scope>()
        {
            Scope.UserReadPrivate, Scope.UserReadBirthdate, Scope.UserModifyPlaybackState, Scope.UserModifyPlaybackState, Scope.UserFollowRead, Scope.UserFollowModify, Scope.UserReadRecentlyPlayed, Scope.UserReadPlaybackState
        };

        private SpotifyAPI api = new SpotifyAPI(clientID, redirectID, state, scope, true);

        public TestForm()
        {
            InitializeComponent();
            AuthenticateAndStartService();
        }

        public void AuthenticateAndStartService()
        {
            api.Authenticated += Api_Authenticated;

            Task.Run(() =>
            {
                api.Authenticate(true);
            });

            while (authenticated == false)
            {

            }
        }

        private static void Api_Authenticated(object sender, EventArgs e)
        {
            //Do something
            authenticated = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchQuery = this.richTextBox2.Text;
            string json = api.Search($"{searchQuery}", SearchType.artist, 1, 0);

            Artists desArtist = JsonConvert.DeserializeObject<Artists>(json);
            var here = desArtist.items;

            // send over to presenter
            using (JsonTextReader reader = new JsonTextReader(new StringReader(json)))
            {
                while (reader.Read())
                {
                    if (reader.Value != null)
                    {
                        
                        JObject obj = JObject.Load(reader);
                        this.richTextBox1.Text += obj["name"].ToString();
                        this.richTextBox1.Text += obj["href"].ToString();
                        this.richTextBox1.Text += obj["name"].ToString();

                        
                        
                        // if reader.value = "artists"
                        // reader.value = href
                    }
                    else
                    {
                    }
                }
            }
        }

            //JToken token = JObject.Parse(json);

            //Artist artistObject = new Artist
            //{
            //    Name = (string) token.SelectToken("name"),
            //    Href = (string) token.SelectToken("href")
            //};

    }
}
