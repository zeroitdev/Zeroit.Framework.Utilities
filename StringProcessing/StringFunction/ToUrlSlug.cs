// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ToUrlSlug.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Text.RegularExpressions;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //var name = "Serdar Büyüktemiz çşğüİö";
        //var urlName = name.ToUrlSlug(); // returns serdar-buyuktemiz-csguio

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// If you get Turkish inputs you can use this method to create url slugs.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>System.String.</returns>
        public static string ToUrlSlug(this string text)
        {
            return Regex.Replace(
                Regex.Replace(
                    Regex.Replace(
                        text.Trim().ToLower()
                            .Replace("ö", "o")
                            .Replace("ç", "c")
                            .Replace("ş", "s")
                            .Replace("ı", "i")
                            .Replace("ğ", "g")
                            .Replace("ü", "u"),
                        @"\s+", " "), // multiple spaces to one space
                    @"\s", "-"), // spaces to hypens
                @"[^a-z0-9\s-]", ""); // removing invalid chars
        }

    }
}
