// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="URLSlug.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //Console.WriteLine(@"I'm a cute Post Title/""\/".toSlug());
        //// => i_m_a_cute_post_title

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Generate slugs for friendly urls.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>String.</returns>
        public static String URLToSlug(this string text)
        {
            String value = text.Normalize(NormalizationForm.FormD).Trim();
            StringBuilder builder = new StringBuilder();

            foreach (char c in text.ToCharArray())
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    builder.Append(c);

            value = builder.ToString();

            byte[] bytes = Encoding.GetEncoding("Cyrillic").GetBytes(text);

            value = Regex.Replace(Regex.Replace(Encoding.ASCII.GetString(bytes), @"\s{2,}|[^\w]", " ", RegexOptions.ECMAScript).Trim(), @"\s+", "_");

            return value.ToLowerInvariant();
        }

    }
}
