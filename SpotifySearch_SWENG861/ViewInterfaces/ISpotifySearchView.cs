using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_SpotifyAPI.Models;

namespace SpotifySearch_SWENG861.ViewInterfaces
{
    public interface ISpotifySearchView
    {
        SearchArtists ArtistsResults { get; set; }
        SearchSongs TracksResults { get; set; }

        bool IsSongSearch { get; set; }
        bool IsArtistSearch { get; set; }
    }
}
