using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpotifySearch_SWENG861.PresentationObjects;

namespace SpotifySearch_SWENG861.Builders
{
    public class PDFBuilder
    {
        // todo complete implementation.
        public void CreatePdfFromMainFrameDataPoList(List<SpotifySearchPO> list, string path)
        {
            if (list == null || !list.Any() || string.IsNullOrEmpty(path)) return;

            bool workComplete = false;

            try
            {
                // todo finish



                workComplete = true;
            }
            catch (Exception e)
            {
                MessageBox.Show($@"Reason: {e.Message}", @"Could not Export PDF",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }

            if (workComplete)
            {
                MessageBox.Show($@"Location: {path}", @"PDF Export Successful!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}
