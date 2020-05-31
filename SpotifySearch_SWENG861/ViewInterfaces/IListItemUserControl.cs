using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifySearch_SWENG861.ViewInterfaces
{
    public interface IListItemUserControl
    {
        // todo add final method used for meta data
        void FindSelectedUserControlIndexAndPlayTrackSample();

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
