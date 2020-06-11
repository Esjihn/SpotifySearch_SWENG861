using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SpotifySearch_SWENG861.Constants;
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
                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
                doc.Open();

                Chunk headerChunk = new Chunk("Spotify Search", FontFactory.GetFont("Arial", 48));
                Chunk linkChunk = new Chunk("--------------------------------------------------------------------------" +
                                            "--------------------------------------------------------------------",
                    FontFactory.GetFont("Arial", 11));
                Chunk singleSpaceChunk = new Chunk(Environment.NewLine);
                Chunk doubleSpaceChunk = new Chunk(Environment.NewLine + Environment.NewLine);

                // List Item
                Chunk searchResultsHeaderChunk = new Chunk();
                Chunk searchResultsChunk = new Chunk();
                List<Chunk> searchResultsList = new List<Chunk>();

                // Meta Data Item

                for(int i = 0; i < list.Count; i++)
                {
                    SpotifySearchPO po = list[i];
                    searchResultsHeaderChunk = new Chunk("Basic Spotify Data", FontFactory.GetFont("Arial Bold", 22));
                    
                    string listItem
                        // List user control items
                        = SpotifySearchXMLConstants.Title + ": " + po.Title + po.NewLine
                          + SpotifySearchXMLConstants.Message + ": " + po.Message + po.NewLine;
                            
                    searchResultsChunk = new Chunk(listItem, FontFactory.GetFont("Arial, 11"));


                    // todo finish adding MetaData





                    searchResultsList.Add(searchResultsChunk);
                }

                DateTime date = DateTime.Now;
                Chunk dateChunk = new Chunk(date.ToString(CultureInfo.InvariantCulture), FontFactory.GetFont("Arial", 11));
                Chunk creatorChunk = new Chunk($"Developer: Matthew Miller, Email: sysnom@gmail.com, Export Date: {date}",
                    FontFactory.GetFont("Arial", 11));

                Paragraph headerParagraph = new Paragraph { Alignment = Element.ALIGN_CENTER };

                // list user control paragraph
                Paragraph searchResultsHeaderParagraph = new Paragraph { Alignment = Element.ALIGN_LEFT };
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
                    // todo add the same foreach for meta data item
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
