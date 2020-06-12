using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharp_SpotifyAPI.Models;
using SpotifySearch_SWENG861.PresentationObjects;

namespace SpotifySearch_SWENG861.ViewInterfaces
{
    public interface ISpotifySearchView
    {
        SearchArtists ArtistsResults { get; set; }
        SearchSongs TracksResults { get; set; }
        List<SpotifySearchPO> ImportResults { get; set; }
        bool IsSongSearch { get; set; }
        bool IsArtistSearch { get; set; }
        bool IsOnlineSearch { get; set; }
        FlowLayoutPanel FlowPanelObject { get; set; }
    }
}
