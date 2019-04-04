// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="InnerTruncate.cs" company="Zeroit Dev Technologies">
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
namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //string sentence = "Truncate the really long string.";

        //var truncated = sentence.InnerTruncate(10);

        //Assert.AreEqual("Truncate...string.", truncated);

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Truncates the given string by stripping out the center and replacing it with
        /// an elipsis so that the beginning and end of the string are retained.
        /// For example, "This string has too many characters for its own good."InnerTruncate(32) yields "This string has...its own good."
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="maxLength">The maximum length.</param>
        /// <returns>System.String.</returns>
        public static string InnerTruncate(this string value,
            int maxLength)
        {
            // If there is no need to truncate then
            // return what we were given.
            if (string.IsNullOrEmpty(value)
                || value.Length <= maxLength)
            {
                return value;
            } // end if

            // Figure out how many characters would be in 
            // each  half if we were to have
            // exactly the same length string on either side 
            // of the elipsis.
            int charsInEachHalf = (maxLength - 3) / 2;

            // Get the string to the right of the elipsis 
            // and then trim the beginning.  There is no
            // need to have a space immediately following 
            // the elipsis.
            string right = value.Substring(
                    value.Length - charsInEachHalf, charsInEachHalf)
                .TrimStart();

            // Get the string to the left of the elipsis.
            // We don't use "charsInEachHalf " here
            // because we may be able to take more characters
            // than that if "right" was trimmed.
            string left = value.Substring(
                    0, (maxLength - 3) - right.Length)
                .TrimEnd();

            // Concatenate and return the result.
            return string.Format("{0}...{1}", left, right);
        } // end InnerTruncate

    }
}
