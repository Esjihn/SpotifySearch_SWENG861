using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CSharp_SpotifyAPI.Models
{
    public class Item
    {
        public ExternalUrls External_urls { get; set; }
        public Followers Followers { get; set; }
        public IList<string> Genres { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public IList<Image> Images { get; set; }
        public string Name { get; set; }
        public int Popularity { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }

        public Album album { get; set; }
        public IList<Artist> artists { get; set; }
        public IList<string> available_markets { get; set; }
        public int disc_number { get; set; }
        public int duration_ms { get; set; }

        [JsonProperty("explicit")]
        public bool ExplicitWords { get; set; }
        public ExternalIds external_ids { get; set; }
        public bool Is_local { get; set; }
        public string Preview_url { get; set; }
        public int Track_number { get; set; }
    }
}