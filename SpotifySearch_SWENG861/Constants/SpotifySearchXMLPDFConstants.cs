﻿using System;
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
        public const string SpotifySearchResultsHeader = "Search Results";
        #endregion

        #region List Item constants
        public const string SearchResults = "SearchResults";
        public const string Title = "Title";
        public const string Message = "Message";
        #endregion

        #region Meta Data constants
        // mimics NewLine in XML
        public const string EmptyLine = "EmptyLine";
        public const string MetaData = "MetaData: ";
        public const string Name = "Name";
        public const string ExplicitWords = "ExplicitWords";
        public const string Popularity = "Popularity";
        public const string FollowerTotal = "FollowerTotal";
        public const string Id = "Id";
        public const string IsLocal = "Is_local";
        public const string Href = "Href";
        public const string AvailableMarkets = "available_markets";
        public const string PreviewUrl = "Preview_url";
        public const string Artists = "Artists";
        public const string TrackNumber = "TrackNumber";
        public const string DurationMS = "duration_ms";
        public const string DiscNumber = "disc_number";
        public const string ExternalUrls = "ExternalUrls_Spotify";
        #endregion
        
        #region Import/Export Directory
        public const string ImportExportPDF = "Import / Export Location";
        public const string ImportExportLocationText = "ImportExportLocationText";
        #endregion

        #region Formatting
        public const string HyphenLineHeaderFooter = "--------------------------------------------------------------------------" +
                                          "--------------------------------------------------------------------";
        #endregion
    }
}
