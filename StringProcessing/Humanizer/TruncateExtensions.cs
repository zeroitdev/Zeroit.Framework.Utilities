// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="TruncateExtensions.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Allow strings to be truncated
    /// </summary>
    public static class TruncateExtensions
    {
        /// <summary>
        /// Truncate the string
        /// </summary>
        /// <param name="input">The string to be truncated</param>
        /// <param name="length">The length to truncate to</param>
        /// <returns>The truncated string</returns>
        public static string Truncate(this string input, int length)
        {
            return input.Truncate(length, "…", Truncator.FixedLength);
        }

        /// <summary>
        /// Truncate the string
        /// </summary>
        /// <param name="input">The string to be truncated</param>
        /// <param name="length">The length to truncate to</param>
        /// <param name="truncator">The truncate to use</param>
        /// <param name="from">The enum value used to determine from where to truncate the string</param>
        /// <returns>The truncated string</returns>
        public static string Truncate(this string input, int length, ITruncator truncator, TruncateFrom from = TruncateFrom.Right)
        {
            return input.Truncate(length, "…", truncator, from);
        }

        /// <summary>
        /// Truncate the string
        /// </summary>
        /// <param name="input">The string to be truncated</param>
        /// <param name="length">The length to truncate to</param>
        /// <param name="truncationString">The string used to truncate with</param>
        /// <param name="from">The enum value used to determine from where to truncate the string</param>
        /// <returns>The truncated string</returns>
        public static string Truncate(this string input, int length, string truncationString, TruncateFrom from = TruncateFrom.Right)
        {
            return input.Truncate(length, truncationString, Truncator.FixedLength, from);
        }

        /// <summary>
        /// Truncate the string
        /// </summary>
        /// <param name="input">The string to be truncated</param>
        /// <param name="length">The length to truncate to</param>
        /// <param name="truncationString">The string used to truncate with</param>
        /// <param name="truncator">The truncator to use</param>
        /// <param name="from">The enum value used to determine from where to truncate the string</param>
        /// <returns>The truncated string</returns>
        /// <exception cref="ArgumentNullException">truncator</exception>
        public static string Truncate(this string input, int length, string truncationString, ITruncator truncator, TruncateFrom from = TruncateFrom.Right)
        {
            if (truncator == null)
                throw new ArgumentNullException(nameof(truncator));

            if (input == null)
                return null;

            return truncator.Truncate(input, length, truncationString, from);
        }
    }

    /// <summary>
    /// Truncation location for humanizer
    /// </summary>
    public enum TruncateFrom
    {
        /// <summary>
        /// Truncate letters from the left (start) of the string
        /// </summary>
        Left,
        /// <summary>
        /// Truncate letters from the right (end) of the string
        /// </summary>
        Right
    }
}
