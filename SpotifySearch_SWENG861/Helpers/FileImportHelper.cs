using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifySearch_SWENG861.Helpers
{
    public class FileImportHelper
    {
        /// <summary>
        /// Determines if user selected xml file is a valid xml by checking for beginning "<SpotifySearchResults>" tag.
        /// </summary>
        /// <param name="fileNameAndPath">The file name and path the user has selected.</param>
        /// <returns></returns>
        public bool DetermineIfSelectedXmlIsValid(string fileNameAndPath)
        {
            if (string.IsNullOrEmpty(fileNameAndPath)) return false;

            using (StreamReader sr = new StreamReader(fileNameAndPath))
            {
                string line;
                while (!string.IsNullOrEmpty(line = sr.ReadLine()))
                {
                    if (line == "<SpotifySearchResults>")
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
