// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Linkify.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
