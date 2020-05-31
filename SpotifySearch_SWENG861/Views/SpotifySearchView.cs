using System;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using SpotifySearch_SWENG861.Properties;

namespace SpotifySearch_SWENG861
{
    public partial class SpotifySearchView : Form
    {
        public SpotifySearchView()
        {
            InitializeComponent();
        }
        
        private void SpotifySearchView_Load(object sender, EventArgs e)
        {
            PopulateItems();
        }

        private void PopulateItems()
        {
            // populate it here
            UcSearchResultItem[] listItems  = new UcSearchResultItem[20];
            // loop through each item
            for (int i = 0; i < listItems.Length; i++)
            {
                listItems[i] = new UcSearchResultItem();
                listItems[i].Width = flwSearchResultsFlowPanel.Width;
                listItems[i].Icon = Resources.spotify_icon_01;
                listItems[i].IconBackGround = Color.Black;
                listItems[i].Title = "Get Data For Title";
                listItems[i].Message = "Get Data For Message";


                if (flwSearchResultsFlowPanel.Controls.Count < 0)
                {
                    flwSearchResultsFlowPanel.Controls.Clear();
                }
                else
                    this.flwSearchResultsFlowPanel.Controls.Add(listItems[i]);
            }
        }
    }
}
