// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="FixedNumberOfWordsTruncator.cs" company="Zeroit Dev Technologies">
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
using System.Linq;

namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Truncate a string to a fixed number of words
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.Humanizer.ITruncator" />
    class FixedNumberOfWordsTruncator : ITruncator
    {
        /// <summary>
        /// Truncate a string
        /// </summary>
        /// <param name="value">The string to truncate</param>
        /// <param name="length">The length to truncate to</param>
        /// <param name="truncationString">The string used to truncate with</param>
        /// <param name="truncateFrom">The enum value used to determine from where to truncate the string</param>
        /// <returns>The truncated string</returns>
        public string Truncate(string value, int length, string truncationString, TruncateFrom truncateFrom = TruncateFrom.Right)
        {
            if (value == null)
                return null;

            if (value.Length == 0)
                return value;

            var numberOfWords = value.Split((char[])null, StringSplitOptions.RemoveEmptyEntries).Count();
            if (numberOfWords <= length)
                return value;

            return truncateFrom == TruncateFrom.Left
                ? TruncateFromLeft(value, length, truncationString)
                : TruncateFromRight(value, length, truncationString);
        }

        /// <summary>
        /// Truncates from right.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="length">The length.</param>
        /// <param name="truncationString">The truncation string.</param>
        /// <returns>System.String.</returns>
        private static string TruncateFromRight(string value, int length, string truncationString)
        {
            var lastCharactersWasWhiteSpace = true;
            var numberOfWordsProcessed = 0;
            for (var i = 0; i < value.Length; i++)
            {
                if (char.IsWhiteSpace(value[i]))
                {
                    if (!lastCharactersWasWhiteSpace)
                        numberOfWordsProcessed++;

                    lastCharactersWasWhiteSpace = true;

                    if (numberOfWordsProcessed == length)
                        return value.Substring(0, i) + truncationString;
                }
                else
                    lastCharactersWasWhiteSpace = false;

            }
            return value + truncationString;
        }

        /// <summary>
        /// Truncates from left.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="length">The length.</param>
        /// <param name="truncationString">The truncation string.</param>
        /// <returns>System.String.</returns>
        private static string TruncateFromLeft(string value, int length, string truncationString)
        {
            var lastCharactersWasWhiteSpace = true;
            var numberOfWordsProcessed = 0;
            for (var i = value.Length - 1; i > 0; i--)
            {
                if (char.IsWhiteSpace(value[i]))
                {
                    if (!lastCharactersWasWhiteSpace)
                        numberOfWordsProcessed++;

                    lastCharactersWasWhiteSpace = true;

                    if (numberOfWordsProcessed == length)
                        return truncationString + value.Substring(i + 1).TrimEnd();
                }
                else
                    lastCharactersWasWhiteSpace = false;

            }
            return truncationString + value;
        }
    }
}