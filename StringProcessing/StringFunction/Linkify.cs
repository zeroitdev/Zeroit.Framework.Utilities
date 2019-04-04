// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Linkify.cs" company="Zeroit Dev Technologies">
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
using System;
using System.Text.RegularExpressions;

namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //void Main()
        //{
        //    Console.WriteLine("This goes to the https://www.test.com website".Linkify());
        //    Console.WriteLine("This goes to the http://www.test.com website".Linkify("_blank"));
        //    Console.WriteLine("This goes to the www.test.com website".Linkify());
        //    Console.WriteLine("This goes to the test.com website".Linkify("_blank"));
        //    Console.WriteLine("This goes to the test.com/page.html page".Linkify());
        //    Console.WriteLine("This goes to the https://wwwtest.com/folder/page.html page".Linkify("_blank"));
        //}

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// The domain regex
        /// </summary>
        private readonly static Regex domainRegex = new Regex(@"(((?<scheme>http(s)?):\/\/)?([\w-]+?\.\w+)+([a-zA-Z0-9\~\!\@\#\$\%\^\&amp;\*\(\)_\-\=\+\\\/\?\.\:\;\,]*)?)", RegexOptions.Compiled | RegexOptions.Multiline);


        /// <summary>
        /// akes a string of text and replaces text matching a link pattern to a hyperlink .
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="target">The target.</param>
        /// <returns>System.String.</returns>
        public static string Linkify(this string text, string target = "_self")
        {
            return domainRegex.Replace(
                text,
                match => {
                    var link = match.ToString();
                    var scheme = match.Groups["scheme"].Value == "https" ? Uri.UriSchemeHttps : Uri.UriSchemeHttp;

                    var url = new UriBuilder(link) { Scheme = scheme }.Uri.ToString();

                    return string.Format(@"<a href=""{0}"" target=""{1}"">{2}</a>", url, target, link);
                }
            );
        }

    }
}
