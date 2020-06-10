using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_SpotifyAPI.Models;
using Image = System.Drawing.Image;

namespace SpotifySearch_SWENG861.ViewInterfaces
{
    public interface IListItemUserControl
    {
        void FindSelectedUserControlIndexAndPlayTrackSample();

        SearchArtists LoadSearchArtistsMetaData();

        SearchSongs LoadSearchSongsMetaData();

        [Category("Custom Props")]
        string Title { get; set; }

        [Category("Custom Props")]
        Color IconBackGround { get; set; }

        [Category("Custom Props")]
        string Message { get; set; }

        [Category("Custom Props")]
        Image Icon { get; set; }
    }
}
