using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharp_SpotifyAPI.Models;
using SpotifySearch_SWENG861.ViewInterfaces;

namespace SpotifySearch_SWENG861.Views
{
    public partial class AdditionalMetaDataView : Form, IAdditionalMetaDataView
    {
        public AdditionalMetaDataView()
        {
            InitializeComponent();
        }

        public void LoadMetaData(SearchSongs loadSearchSongsMetaData)
        {
            // todo guard clause, load data into form after formatting "pretty" results
        }

        public void LoadMetaData(SearchArtists loadSearchArtistsMetaData)
        {
            // todo guard clause, load data into form after formatting "pretty" results
            
        }
    }
}
