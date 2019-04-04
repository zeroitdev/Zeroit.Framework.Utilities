// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ToUrlString.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Globalization;
using System.Linq;
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

        //MyWebItem.Name.ToUrlString()

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Takes a string, replacing special characters and spaces with - (one dash per one or many contiguous special charachters or spaces). makes lower-case and trims.
        /// Good for seo.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>System.String.</returns>
        public static string ToUrlString(this string str)
        {
            if (String.IsNullOrEmpty(str)) return "";
            // Unicode Character Handling: http://blogs.msdn.com/b/michkap/archive/2007/05/14/2629747.aspx
            string stFormD = str.Trim().ToLowerInvariant().Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (char t in
                from t in stFormD
                let uc = CharUnicodeInfo.GetUnicodeCategory(t)
                where uc != UnicodeCategory.NonSpacingMark
                select t)
            {
                sb.Append(t);
            }
            return Regex.Replace(sb.ToString().Normalize(NormalizationForm.FormC), "[\\W\\s]{1,}", "-").Trim('-');
        }

    }
}
