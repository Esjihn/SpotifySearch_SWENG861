using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharp_SpotifyAPI.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SpotifySearch_SWENG861.Constants;
using SpotifySearch_SWENG861.PresentationObjects;

namespace SpotifySearch_SWENG861.Builders
{
    public class PDFBuilder
    {
        public void CreatePdfFromMainFrameDataPoList(List<SpotifySearchPO> list, string path)
        {
            if (list == null || !list.Any() || string.IsNullOrEmpty(path)) return;

            bool workComplete = false;

            try
            {
                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
                doc.Open();

                Chunk headerChunk = new Chunk("Spotify Search", FontFactory.GetFont("Arial", 48));
                Chunk linkChunk = new Chunk(SpotifySearchXMLPDFConstants.HyphenLineHeaderFooter, FontFactory.GetFont("Arial", 11));
                Chunk singleSpaceChunk = new Chunk(Environment.NewLine);
                Chunk doubleSpaceChunk = new Chunk(Environment.NewLine + Environment.NewLine);

                // Search results
                Chunk searchResultsHeaderChunk = new Chunk();
                List<Chunk> searchResultsList = new List<Chunk>();
                string colon = ": ";


                for (int i = 0; i < list.Count; i++)
                {
                    SpotifySearchPO po = list[i];
                    searchResultsHeaderChunk = new Chunk(SpotifySearchXMLPDFConstants.SpotifySearchResultsHeader, FontFactory.GetFont("Arial Bold", 22));

                    string listItem
                        // List user control items
                        = SpotifySearchXMLPDFConstants.Title + colon + po.Title + po.NewLine
                          + SpotifySearchXMLPDFConstants.Message + colon + po.Message + po.NewLine
                          + po.NewLine
                          + SpotifySearchXMLPDFConstants.MetaData + po.NewLine;
                    
                    if (po.Name != null) listItem += SpotifySearchXMLPDFConstants.Name + colon + po.Name + po.NewLine;
                    listItem += SpotifySearchXMLPDFConstants.ExplicitWords + colon + po.ExplicitWords + po.NewLine;
                    listItem += SpotifySearchXMLPDFConstants.Popularity + colon + po.Popularity + po.NewLine;
                    if (po.Followers != null) listItem += SpotifySearchXMLPDFConstants.FollowerTotal + colon + po.FollowerTotal + po.NewLine;
                    if (po.Id != null) listItem += SpotifySearchXMLPDFConstants.Id + colon + po.Id + po.NewLine;
                    listItem += SpotifySearchXMLPDFConstants.IsLocal + colon + po.IsLocal + po.NewLine;
                    if (po.Href != null) listItem += SpotifySearchXMLPDFConstants.Href + colon + po.Href + po.NewLine;

                    if (po.AvailableMarkets != null)
                    {
                        listItem += SpotifySearchXMLPDFConstants.AvailableMarkets + colon + po.NewLine;
                        listItem = po.AvailableMarkets.Aggregate(listItem, (current, market) => current + (market + ", "));
                        listItem += po.NewLine;
                    }

                    if (po.PreviewUrl != null)
                    {
                        listItem += SpotifySearchXMLPDFConstants.PreviewUrl + colon + po.PreviewUrl + po.NewLine;
                    }

                    if (po.Artists != null)
                    {
                        listItem += SpotifySearchXMLPDFConstants.Artists + colon + po.NewLine;
                        listItem = po.Artists.Aggregate(listItem, (current, artist) => current + artist.Name + " ");
                        listItem += po.NewLine;
                    }

                    listItem += SpotifySearchXMLPDFConstants.TrackNumber + colon + po.TrackNumber + po.NewLine;
                    listItem += SpotifySearchXMLPDFConstants.DurationMS + colon + po.DurationMS + po.NewLine;
                    listItem += SpotifySearchXMLPDFConstants.DiscNumber + colon + po.DiscNumber + po.NewLine;

                    if (po.ExternalUrls != null)
                        listItem += SpotifySearchXMLPDFConstants.ExternalUrls + colon + po.ExternalUrls + po.NewLine;

                    if (!string.IsNullOrEmpty(po.ImportExportLocationText))
                    {
                        listItem += SpotifySearchXMLPDFConstants.ImportExportPDF + colon + po.ImportExportLocationText + po.NewLine;
                    }

                    listItem += po.NewLine + po.NewLine + po.NewLine;

                    Chunk searchResultsChunk = new Chunk(listItem, FontFactory.GetFont("Arial, 11"));
                    
                    searchResultsList.Add(searchResultsChunk);
                }

                DateTime date = DateTime.Now;
                Chunk dateChunk = new Chunk($"Export Date: {date}", FontFactory.GetFont("Arial", 11));
                Chunk creatorChunk = new Chunk($"Developer: Matthew Miller, Email: sysnom@gmail.com, Export Date: {date}",
                    FontFactory.GetFont("Arial", 11));

                Paragraph headerParagraph = new Paragraph { Alignment = Element.ALIGN_CENTER };

                // list user control paragraph
                Paragraph searchResultsHeaderParagraph = new Paragraph { Alignment = Element.ALIGN_CENTER };
                Paragraph searchResultsParagraph = new Paragraph { Alignment = Element.ALIGN_LEFT };

                Paragraph creatorParagraph = new Paragraph { Alignment = Element.ALIGN_RIGHT };
                Paragraph dateParagraph = new Paragraph { Alignment = Element.ALIGN_RIGHT };
                Paragraph lineParagraph = new Paragraph { Alignment = Element.ALIGN_CENTER };
                Paragraph singleSpaceParagraph = new Paragraph { Alignment = Element.ALIGN_CENTER };
                Paragraph doubleSpaceParagraph = new Paragraph { Alignment = Element.ALIGN_CENTER };

                // Header
                headerParagraph.Add(headerChunk);

                // list ui
                searchResultsHeaderParagraph.Add(searchResultsHeaderChunk);
                foreach (Chunk item in searchResultsList)
                {
                    searchResultsParagraph.Add(item + Environment.NewLine);
                }
                
                // Dev 
                creatorParagraph.Add(creatorChunk);
                dateParagraph.Add(dateChunk);

                // Formatting
                singleSpaceParagraph.Add(singleSpaceChunk);
                doubleSpaceParagraph.Add(doubleSpaceChunk);
                lineParagraph.Add(linkChunk);

                // Header doc
                doc.Add(headerParagraph);
                doc.Add(lineParagraph);
                doc.Add(dateParagraph);
                doc.Add(singleSpaceParagraph);

                // Search Results doc
                doc.Add(searchResultsHeaderParagraph);
                doc.Add(singleSpaceParagraph);
                doc.Add(searchResultsParagraph);
                doc.Add(singleSpaceParagraph);

                // Footer doc
                doc.Add(lineParagraph);
                doc.Add(creatorParagraph);

                doc.Close();

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
