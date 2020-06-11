using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotifySearch_SWENG861.Constants
{
    public class SpotifySearchXMLConstants
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
        public const string EmptyLine = "";
        public const string MetaDataUIElements = "MetaDataUIElements";
        public const string Name = "Name";

        #endregion
    }
}
