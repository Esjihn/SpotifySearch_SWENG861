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

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create your items
            PopulateItems();

        }

        private void PopulateItems()
        {
            // populate it here
            ucSearchResultItem[] listItems  = new ucSearchResultItem[20];
            // loop through each item
            for (int i = 0; i < listItems.Length; i++)
            {
                listItems[i] = new ucSearchResultItem();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
