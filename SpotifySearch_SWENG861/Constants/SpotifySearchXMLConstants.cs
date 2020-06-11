using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotifySearch_SWENG861.Constants
{
    public class SpotifySearchXMLPDFConstants
    {
        #region Parent XML constant
        public const string SpotifySearchResults = "SpotifySearchResults";
        #endregion

        #region List Item constants
        public const string ListItemUIElements = "ListItemUIElements";
        public const string Title = "Title";
        public const string Message = "Message";
        #endregion

        #region Meta Data constants
        // mimics NewLine in XML
        public const string EmptyLine = "EmptyLine";
        public const string MetaDataUIElements = "MetaDataUIElements";
        public const string MetaData = "MetaData: ";
        public const string Name = "Name";
        public const string ExplicitWords = "ExplicitWords";
        public const string Popularity = "Popularity";
        public const string Followers = "Followers";
        public const string FollowerTotal = "FollowerTotal";
        public const string Id = "Id";
        public const string IsLocal = "IsLocal";
        public const string Href = "Href";
        public const string AvailableMarkets = "AvailableMarkets";
        public const string PreviewUrl = "PreviewUrl";
        public const string ArtistsResults = "ArtistsResults";
        public const string Artists = "Artists";
        public const string TrackResults = "TrackResults";
        public const string TrackNumber = "TrackNumber";
        public const string DurationMS = "DurationMS";
        public const string DiscNumber = "DiscNumber";
        public const string ExternalUrls = "ExternalUrls";
        #endregion
        
        #region Import/Export Directory
        public const string ImportExport = "ImportExport";
        public const string ImportExportLocationText = "ImportExportLocationText";
        #endregion

        #region Formatting
        public static string HyphenLineHeaderFooter = "--------------------------------------------------------------------------" +
                                          "--------------------------------------------------------------------";
        public static string HyphenLineListSplit = "--------------------------------------------------------------------------" +
                                          "------------------------------------------------";
        #endregion
    }
}
