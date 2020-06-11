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
                    new XElement(SpotifySearchXMLConstants.SpotifySearchResults,
                        from po in list 
                            select new XElement(SpotifySearchXMLConstants.ListItemUIElements,
                                new XElement(SpotifySearchXMLConstants.Title, po.Title),
                                new XElement(SpotifySearchXMLConstants.Message, po.Message)),
                        from po in list 
                            select new XElement(SpotifySearchXMLConstants.MetaDataUIElements,
                                new XElement(SpotifySearchXMLConstants.EmptyLine, po.NewLine),
                                new XElement(SpotifySearchXMLConstants.Name, po.Name),
                                new XElement(SpotifySearchXMLConstants.ExplicitWords, po.ExplicitWords),
                                new XElement(SpotifySearchXMLConstants.Popularity, po.Popularity),
                                new XElement(SpotifySearchXMLConstants.Followers, po.Followers),
                                new XElement(SpotifySearchXMLConstants.FollowerTotal, po.FollowerTotal),
                                new XElement(SpotifySearchXMLConstants.Id, po.Id),
                                new XElement(SpotifySearchXMLConstants.IsLocal, po.IsLocal),
                                new XElement(SpotifySearchXMLConstants.Href, po.Href),
                                new XElement(SpotifySearchXMLConstants.AvailableMarkets, po.AvailableMarkets),
                                new XElement(SpotifySearchXMLConstants.PreviewUrl, po.PreviewUrl),
                                new XElement(SpotifySearchXMLConstants.ArtistsResults, po.ArtistsResults),
                                po.Artists.Select(a => new XElement(SpotifySearchXMLConstants.Artists)),
                                new XElement(SpotifySearchXMLConstants.TrackResults, po.TracksResults),
                                new XElement(SpotifySearchXMLConstants.TrackNumber, po.TrackNumber),
                                new XElement(SpotifySearchXMLConstants.DurationMS, po.DurationMS),
                                new XElement(SpotifySearchXMLConstants.DiscNumber, po.DiscNumber),
                                new XElement(SpotifySearchXMLConstants.ExternalUrls, po.ExternalUrls)),
                        from po in list
                            select new XElement(SpotifySearchXMLConstants.ImportExport,
                                new XElement(SpotifySearchXMLConstants.ImportExportLocationText, po.ImportExportLocationText)));
                
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
