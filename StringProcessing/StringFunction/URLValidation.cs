// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="URLValidation.cs" company="Zeroit Dev Technologies">
//    This program contains Utilities for all C# programming activities.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Net;
using System.Text.RegularExpressions;

namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//



        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Returns true when a string is a valid url.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns><c>true</c> if [is valid URL] [the specified text]; otherwise, <c>false</c>.</returns>
        public static bool IsValidUrl(this string text)
        {
            Regex rx = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
            return rx.IsMatch(text);
        }


        /// <summary>
        /// Checks if url is valid.
        /// from http://www.osix.net/modules/article/?id=586 and changed to match http://localhost
        /// complete (not only http) url regex can be found
        /// at http://internet.ls-la.net/folklore/url-regexpr.html
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns><c>true</c> if [is URL valid] [the specified URL]; otherwise, <c>false</c>.</returns>
        public static bool IsUrlValid(this string url)
        {
            string strRegex = "^(https?://)"
                              + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" //user@
                              + @"(([0-9]{1,3}\.){3}[0-9]{1,3}" // IP- 199.194.52.184
                              + "|" // allows either IP or domain
                              + @"([0-9a-z_!~*'()-]+\.)*" // tertiary domain(s)- www.
                              + @"([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]" // second level domain
                              + @"(\.[a-z]{2,6})?)" // first level domain- .com or .museum is optional
                              + "(:[0-9]{1,5})?" // port number- :80
                              + "((/?)|" // a slash isn't required if there is no file name
                              + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";
            return new Regex(strRegex).IsMatch(url);
        }


        /// <summary>
        /// Check if url (http) is available.
        /// </summary>
        /// <param name="httpUrl">The HTTP URL.</param>
        /// <returns>true if available</returns>
        /// <example>
        /// string url = "www.codeproject.com;
        /// if( !url.UrlAvailable())
        /// ...codeproject is not available
        /// </example>
        public static bool UrlAvailable(this string httpUrl)
        {
            if (!httpUrl.StartsWith("http://") || !httpUrl.StartsWith("https://"))
                httpUrl = "http://" + httpUrl;
            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(httpUrl);
                myRequest.Method = "GET";
                myRequest.ContentType = "application/x-www-form-urlencoded";
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myRequest.GetResponse();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
