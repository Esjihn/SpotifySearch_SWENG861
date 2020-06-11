using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using SpotifySearch_SWENG861.Constants;
using SpotifySearch_SWENG861.PresentationObjects;

namespace SpotifySearch_SWENG861.Builders
{
    public class XMLBuilder
    {
        /// <summary>
        /// Creates XML Export file.
        /// </summary>
        /// <param name="list">UI SpotifySearchPO list</param>
        /// <param name="path">file path</param>
        public void CreateXMLFromSpotifySearchPOList(List<SpotifySearchPO> list, string path)
        {
            if (list == null || !list.Any() || string.IsNullOrEmpty(path)) return;

            bool workComplete = false;
            try
            {
                // Hierarchy
                // 1. SpotifySearchPOConstants.SpotifySearchPO (Simple parent tag name)
                //    A. New line (metadata import)
                //      B. List Item UI elements
                //         C. Meta Data UI
                //             D. Import / Export location.

                // todo 

                XElement element = 
                    new XElement(SpotifySearchXMLConstants.SpotifySearchData,
                        from po in list
                        select new XElement(po.Title));

                // Write complete XML element as XML page to file.
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(element);
                }

                workComplete = true;
            }
            catch (Exception e)
            {
                MessageBox.Show($@"Reason: {e.Message}", @"Could not Export XML",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }

            if (workComplete)
            {
                MessageBox.Show($@"Location: {path}", @"XML Export Successful!", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}
