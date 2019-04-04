// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="StripHtml.cs" company="Zeroit Dev Technologies">
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

        //var htmlText = "<p>Here is some text. <span class="bold">This is bold.</span> Talk to you later.</p>;
        //var cleanString = htmlText.StripHtml();

        //---------------------------------Implementation-----------------------------//


        // Used when we want to completely remove HTML code and not encode it with XML entities.
        /// <summary>
        /// Strips the HTML.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        public static string StripHtml(this string input)
        {
            // Will this simple expression replace all tags???
            var tagsExpression = new Regex(@"</?.+?>");
            return tagsExpression.Replace(input, " ");
        }

        /// <summary>
        /// Strips the HTML.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="doConversion">if set to <c>true</c> [do conversion].</param>
        /// <returns>String.</returns>
        public static String StripHtml(this String str, bool doConversion = true)
        {
            return Regex.Replace(str, @"<(.|\n)*?>", String.Empty);
        }
    }
}
