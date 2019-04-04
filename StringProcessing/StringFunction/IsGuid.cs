// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="IsGuid.cs" company="Zeroit Dev Technologies">
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

        //string s = Guid.NewGuid().ToString();

        //Assert.IsTrue(s.IsGuid());

        //--------------------Method 2------------------//
        //string testValue = "{CA761232-ED42-11CE-BACD-00AA0057B223}";
        //bool isGuid = testValue.IsGuid();

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Determines whether the specified s is unique identifier.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns><c>true</c> if the specified s is unique identifier; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">s</exception>
        public static bool IsGuid(this string s)
        {
            if (s == null)
                throw new ArgumentNullException("s");

            Regex format = new Regex(
                "^[A-Fa-f0-9]{32}$|" +
                "^({|\\()?[A-Fa-f0-9]{8}-([A-Fa-f0-9]{4}-){3}[A-Fa-f0-9]{12}(}|\\))?$|" +
                "^({)?[0xA-Fa-f0-9]{3,10}(, {0,1}[0xA-Fa-f0-9]{3,6}){2}, {0,1}({)([0xA-Fa-f0-9]{3,4}, {0,1}){7}[0xA-Fa-f0-9]{3,4}(}})$");
            Match match = format.Match(s);

            return match.Success;
        }

        /// <summary>
        /// Validate if a String contains a GUID in groups of 8, 4, 4, 4, and 12 digits with hyphens between the groups.
        /// The entire GUID can optionally be enclosed in matching braces or parentheses.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="doConversion">if set to <c>true</c> [do conversion].</param>
        /// <returns><c>true</c> if the specified do conversion is unique identifier; otherwise, <c>false</c>.</returns>
        public static bool IsGuid(this string value, bool doConversion = true)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            const string pattern = @"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$";
            return Regex.IsMatch(value, pattern);
        }

    }
}
