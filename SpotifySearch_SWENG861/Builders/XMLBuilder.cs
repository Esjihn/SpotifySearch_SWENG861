using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using SpotifySearch_SWENG861.Constants;
using SpotifySearch_SWENG861.PresentationObjects;
using SpotifySearch_SWENG861.Views;

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
                //      B. List Item UI
                //          i) List Item UI elements
                //      C. Meta Data UI
                //          i) Meta Data UI elements
                //      D. Import / Export location.

                XElement element =
                    new XElement(SpotifySearchXMLPDFConstants.SpotifySearchResults,
                        from po in list
                        select new XElement(SpotifySearchXMLPDFConstants.SearchResults,
                            new XElement(SpotifySearchXMLPDFConstants.Title, po.Title),
                            new XElement(SpotifySearchXMLPDFConstants.Message, po.Message),
                            new XElement(SpotifySearchXMLPDFConstants.EmptyLine, po.NewLine),
                            po.Name != null
                                ? new XElement(SpotifySearchXMLPDFConstants.Name, po.Name)
                                : new XElement(SpotifySearchXMLPDFConstants.Name, string.Empty),
                            new XElement(SpotifySearchXMLPDFConstants.ExplicitWords, po.ExplicitWords),
                            new XElement(SpotifySearchXMLPDFConstants.Popularity, po.Popularity),
                            new XElement(SpotifySearchXMLPDFConstants.FollowerTotal, po.FollowerTotal),
                            po.Id != null
                                ? new XElement(SpotifySearchXMLPDFConstants.Id, po.Id)
                                : new XElement(SpotifySearchXMLPDFConstants.Id, string.Empty),
                            new XElement(SpotifySearchXMLPDFConstants.IsLocal, po.IsLocal),
                            po.Href != null
                                ? new XElement(SpotifySearchXMLPDFConstants.Href, po.Href)
                                : new XElement(SpotifySearchXMLPDFConstants.Href, string.Empty),
                            po.AvailableMarkets != null
                                ? new XElement(SpotifySearchXMLPDFConstants.AvailableMarkets, po.AvailableMarkets)
                                : new XElement(SpotifySearchXMLPDFConstants.AvailableMarkets, string.Empty),
                            po.PreviewUrl != null
                                ? new XElement(SpotifySearchXMLPDFConstants.PreviewUrl, po.PreviewUrl)
                                : new XElement(SpotifySearchXMLPDFConstants.PreviewUrl, string.Empty),
                            po.Artists != null
                                ? new XElement(SpotifySearchXMLPDFConstants.Artists, po.Artists.Select(a => a.Name))
                                : new XElement(SpotifySearchXMLPDFConstants.Artists, string.Empty),
                            new XElement(SpotifySearchXMLPDFConstants.TrackNumber, po.TrackNumber),
                            new XElement(SpotifySearchXMLPDFConstants.DurationMS, po.DurationMS),
                            new XElement(SpotifySearchXMLPDFConstants.DiscNumber, po.DiscNumber),
                            po.ExternalUrls_Spotify != null
                                ? new XElement(SpotifySearchXMLPDFConstants.ExternalUrls, po.ExternalUrls_Spotify)
                                : new XElement(SpotifySearchXMLPDFConstants.ExternalUrls, string.Empty),
                            new XElement(SpotifySearchXMLPDFConstants.ImportExportLocationText, po.ImportExportLocationText)));
                
                // Write complete XML element as XML page to file.
                using (StreamWriter sw = new StreamWriter(path, true))
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
