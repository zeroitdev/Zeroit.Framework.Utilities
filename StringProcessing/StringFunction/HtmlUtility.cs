// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="HtmlUtility.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Specialized;

namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //string html = "<title>this is the Test Title</title>";
        //string url = "http://www.domain.com?q=test&a=123&g=test";

        //Console.WriteLine("UrlEncode: {0}", url.UrlEncode());
        //Console.WriteLine("UrlDecode: {0}", url.UrlDecode());
        //Console.WriteLine("UrlPathEncode: {0}", url.UrlPathEncode());
        //Console.WriteLine("HtmlEncode: {0}", html.HtmlEncode());
        //Console.WriteLine("HtmlDecode: {0}", html.HtmlDecode());

        //int idx = url.IndexOf('?');
        //String querystring = null;
        //    if (idx >= 0)
        //{
        //    querystring = (idx<url.Length - 1) ? url.Substring(idx + 1) : String.Empty;
        //}

        //System.Collections.Specialized.NameValueCollection coll = querystring.ParseQueryString();
        //Console.WriteLine("   [INDEX] KEY        VALUE");
        //for (int i = 0; i<coll.Count; i++)
        //Console.WriteLine("   [{0}]     {1,-10} {2}", i, coll.GetKey(i), coll.Get(i));

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// HTMLs the encode.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>System.String.</returns>
        public static string HtmlEncode(this string data)
        {
            return HtmlEncode(data);
        }

        /// <summary>
        /// HTMLs the decode.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>System.String.</returns>
        public static string HtmlDecode(this string data)
        {
            return HtmlDecode(data);
        }

        /// <summary>
        /// Parses the query string.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>NameValueCollection.</returns>
        public static NameValueCollection ParseQueryString(this string query)
        {
            return ParseQueryString(query);
        }

        /// <summary>
        /// URLs the encode.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>System.String.</returns>
        public static string UrlEncode(this string url)
        {
            return UrlEncode(url);
        }

        /// <summary>
        /// URLs the decode.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>System.String.</returns>
        public static string UrlDecode(this string url)
        {
            return UrlDecode(url);
        }

        /// <summary>
        /// URLs the path encode.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>System.String.</returns>
        public static string UrlPathEncode(this string url)
        {
            return UrlPathEncode(url);
        }

    }
}
