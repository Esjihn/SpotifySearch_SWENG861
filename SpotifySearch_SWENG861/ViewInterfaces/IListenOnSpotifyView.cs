using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotifySearch_SWENG861.ViewInterfaces
{
    public interface IListenOnSpotifyView
    {
        // todo complete interface
        // may also need to change to use Chrome browser equivalent
        WebBrowser WebBrowser { get; set; }
    }
}
