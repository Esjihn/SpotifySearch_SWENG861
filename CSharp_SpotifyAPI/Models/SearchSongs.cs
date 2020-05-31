using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_SpotifyAPI.Models
{
    public class SearchSongs
    {
        public Tracks Tracks { get; set; }
    }
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
