// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="AfrikaansNumberToWordsConverter.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords
{
    /// <summary>
    /// Class AfrikaansNumberToWordsConverter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.GenderlessNumberToWordsConverter" />
    internal class AfrikaansNumberToWordsConverter : GenderlessNumberToWordsConverter
    {
        /// <summary>
        /// The units map
        /// </summary>
        private static readonly string[] UnitsMap = { "nul", "een", "twee", "drie", "vier", "vyf", "ses", "sewe", "agt", "nege", "tien", "elf", "twaalf", "dertien", "veertien", "vyftien", "sestien", "sewentien", "agtien", "negentien" };
        /// <summary>
        /// The tens map
        /// </summary>
        private static readonly string[] TensMap = { "nul", "tien", "twintig", "dertig", "veertig", "vyftig", "sestig", "sewentig", "tagtig", "negentig" };

        /// <summary>
        /// The ordinal exceptions
        /// </summary>
        private static readonly Dictionary<int, string> OrdinalExceptions = new Dictionary<int, string>
        {
            {0, "nulste"},
            {1, "eerste"},
            {3, "derde"},
            {7, "sewende"},
            {8, "agste"},
            {9, "negende"},
            {10, "tiende"},
            {14, "veertiende"},
            {17, "sewentiende"},
            {19, "negentiende"}
        };

        /// <summary>
        /// Converts the number to string
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override string Convert(long number)
        {
            if(number > Int32.MaxValue|| number < Int32.MinValue)
            {
                throw new NotImplementedException();
            }
            return Convert((int)number, false);
        }

        /// <summary>
        /// Converts the number to ordinal string
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.String.</returns>
        public override string ConvertToOrdinal(int number)
        {
            return Convert(number, true);
        }

        /// <summary>
        /// Converts the specified number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="isOrdinal">if set to <c>true</c> [is ordinal].</param>
        /// <returns>System.String.</returns>
        private string Convert(int number, bool isOrdinal)
        {
            if (number == 0)
                return GetUnitValue(0, isOrdinal);

            if (number < 0)
                return string.Format("minus {0}", Convert(-number));

            var parts = new List<string>();

            if ((number / 1000000000) > 0)
            {
                parts.Add(string.Format("{0} miljard", Convert(number / 1000000000)));
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                parts.Add(string.Format("{0} miljoen", Convert(number / 1000000)));
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                parts.Add(string.Format("{0} duisend", Convert(number / 1000)));
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                parts.Add(string.Format("{0} honderd", Convert(number / 100)));
                number %= 100;
            }

            if (number > 0)
            {
                //if (parts.Count != 0)
                //    parts.Add("en");

                if (number < 20)
                {
                    if (parts.Count > 0)
                    parts.Add("en");
                    parts.Add(GetUnitValue(number, isOrdinal));
                }
                else
                {
                    var lastPartValue = (number/10)*10;
                    var lastPart = TensMap[number/10];
                    if ((number%10) > 0)
                        lastPart = string.Format("{0} en {1}",GetUnitValue(number % 10, false), isOrdinal ? GetUnitValue(lastPartValue, isOrdinal) : lastPart);
                    else if ((number%10) == 0)
                        lastPart = string.Format("{0}{1}{2}", parts.Count > 0 ? "en " : "", lastPart, isOrdinal ? "ste" : "");
                    else if (isOrdinal)
                        lastPart = lastPart.TrimEnd('~') + "ste";

                    parts.Add(lastPart);
                }
            }
            else if (isOrdinal)
                parts[parts.Count - 1] += "ste";

            var toWords = string.Join(" ", parts.ToArray());

            if (isOrdinal)
                toWords = RemoveOnePrefix(toWords);

            return toWords;
        }

        /// <summary>
        /// Gets the unit value.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="isOrdinal">if set to <c>true</c> [is ordinal].</param>
        /// <returns>System.String.</returns>
        private static string GetUnitValue(int number, bool isOrdinal)
        {
            if (isOrdinal)
            {
                if (ExceptionNumbersToWords(number, out var exceptionString))
                    return exceptionString;
                else if (number > 19)
                    return TensMap[number/10] + "ste";
                else
                    return UnitsMap[number] + "de";
            }
            else
                return UnitsMap[number];
        }

        /// <summary>
        /// Removes the one prefix.
        /// </summary>
        /// <param name="toWords">To words.</param>
        /// <returns>System.String.</returns>
        private static string RemoveOnePrefix(string toWords)
        {
            // one hundred => hundredth
            if (toWords.IndexOf("een", StringComparison.Ordinal) == 0)
                if (toWords.IndexOf("een en", StringComparison.Ordinal) != 0)
                    toWords = toWords.Remove(0, 4);

            return toWords;
        }

        /// <summary>
        /// Exceptions the numbers to words.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="words">The words.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private static bool ExceptionNumbersToWords(int number, out string words)
        {
            return OrdinalExceptions.TryGetValue(number, out words);
        }
    }
}
