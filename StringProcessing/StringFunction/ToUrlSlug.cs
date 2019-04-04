// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ToUrlSlug.cs" company="Zeroit Dev Technologies">
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
