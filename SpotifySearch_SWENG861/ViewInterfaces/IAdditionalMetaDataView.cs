using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_SpotifyAPI.Models;

namespace SpotifySearch_SWENG861.ViewInterfaces
{
    public interface IAdditionalMetaDataView
    {
        void LoadMetaData(string type, int index);
    }
}
