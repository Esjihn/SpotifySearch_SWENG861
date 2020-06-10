using System;
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
            // search query from user
            string searchQuery = this.richTextBox2.Text;

            string artistsJson = api.Search($"{searchQuery}", SearchType.artist, 10, 0);
            string tracksJson = api.Search($"{searchQuery}", SearchType.track, 10, 0);

            SearchArtists desArtist = JsonConvert.DeserializeObject<SearchArtists>(artistsJson);
            SearchSongs searchSongs = JsonConvert.DeserializeObject<SearchSongs>(tracksJson);

            // iterates ver each item
            this.richTextBox1.Text = @"Artists Search Results: " + Environment.NewLine + Environment.NewLine;
            foreach (var item in desArtist.Artists.Items)
            {
                this.richTextBox1.Text += item.Name + Environment.NewLine;
            }

            this.richTextBox1.Text += Environment.NewLine;

            this.richTextBox1.Text += @"Songs Search Results: " + Environment.NewLine + Environment.NewLine;
            foreach (var item in searchSongs.Tracks.Items)
            {
                this.richTextBox1.Text += item.Name + Environment.NewLine;
            }
        }
    }
}