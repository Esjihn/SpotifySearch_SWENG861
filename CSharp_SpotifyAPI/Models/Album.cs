using System.Collections.Generic;

namespace CSharp_SpotifyAPI.Models
{
    public class Album
    {
        public string Album_type { get; set; }
        public IList<Artist> Artists { get; set; }
        public IList<string> Available_markets { get; set; }
        public ExternalUrls External_urls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public IList<Image> Images { get; set; }
        public string name { get; set; }
        public string Release_date { get; set; }
        public string Release_date_precision { get; set; }
        public int Total_tracks { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }
}