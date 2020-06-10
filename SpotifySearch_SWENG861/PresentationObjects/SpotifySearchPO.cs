using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_SpotifyAPI.Models;
using SpotifySearch_SWENG861.Constants;

namespace SpotifySearch_SWENG861.PresentationObjects
{
    public class SpotifySearchPO
    {
        #region Header
        // For use with import.
        public string SpotifySearchXmlHeader = SpotifySearchPOConstants.SpotifySearchPO;
        #endregion

        #region List Item UI
        public string Title { get; set; }
        public string Message { get; set; }
        #endregion

        #region Meta Data UI
        // Used for import alignment in MetaDataView
        public string NewLine { get { return Environment.NewLine; } }

        public string Name { get; set; }
        public bool ExplicitWords { get; set; }
        public IList<string> Genres { get; set; }
        public int Popularity { get; set; }
        public Followers Followers { get; set; }
        public int FollowerTotal { get; set; }
        public string Id { get; set; }
        public bool IsLocal { get; set; }
        public string Href { get; set; }
        public IList<string> AvailableMarkets { get; set; }
        public string PreviewUrl { get; set; }
        public SearchArtists ArtistsResults { get; set; }
        public IList<Artist> Artists { get; set; }
        public SearchSongs TracksResults { get; set; }
        public int TrackNumber { get; set; }
        public string ArtistName { get; set; }
        public int DurationMS { get; set; }
        public int DiscNumber { get; set; }
        public string ExternalUrls { get; set; }

        #endregion
    }
}
