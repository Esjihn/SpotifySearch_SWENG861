using System.Collections.Generic;

namespace CSharp_SpotifyAPI.Models
{
    public class Tracks
    {
        public string Href { get; set; }
        public IList<Item> Items { get; set; }
        public int Limit { get; set; }
        public string Next { get; set; }
        public int Offset { get; set; }
        public object Previous { get; set; }
        public int Total { get; set; }
    }
}