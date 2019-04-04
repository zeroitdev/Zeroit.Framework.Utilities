// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="EnglishNumberToWordsConverter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords
{
    /// <summary>
    /// Class EnglishNumberToWordsConverter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.GenderlessNumberToWordsConverter" />
    internal class EnglishNumberToWordsConverter : GenderlessNumberToWordsConverter
    {
        /// <summary>
        /// The units map
        /// </summary>
        private static readonly string[] UnitsMap = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        /// <summary>
        /// The tens map
        /// </summary>
        private static readonly string[] TensMap = { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        /// <summary>
        /// The ordinal exceptions
        /// </summary>
        private static readonly Dictionary<long, string> OrdinalExceptions = new Dictionary<long, string>
        {
            {1, "first"},
            {2, "second"},
            {3, "third"},
            {4, "fourth"},
            {5, "fifth"},
            {8, "eighth"},
            {9, "ninth"},
            {12, "twelfth"},
        };

        /// <summary>
        /// Converts the number to string
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.String.</returns>
        public override string Convert(long number)
        {
            return Convert(number, false);
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
        private string Convert(long number, bool isOrdinal)
        {
            if (number == 0)
                return GetUnitValue(0, isOrdinal);

            if (number < 0)
                return string.Format("minus {0}", Convert(-number));

            var parts = new List<string>();

            if ((number / 1000000000000000000) > 0)
            {
                parts.Add(string.Format("{0} quintillion", Convert(number / 1000000000000000000)));
                number %= 1000000000000000000;
            }

            if ((number / 1000000000000000) > 0)
            {
                parts.Add(string.Format("{0} quadrillion", Convert(number / 1000000000000000)));
                number %= 1000000000000000;
            }

            if ((number / 1000000000000) > 0)
            {
                parts.Add(string.Format("{0} trillion", Convert(number / 1000000000000)));
                number %= 1000000000000;
            }

            if ((number / 1000000000) > 0)
            {
                parts.Add(string.Format("{0} billion", Convert(number / 1000000000)));
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                parts.Add(string.Format("{0} million", Convert(number / 1000000)));
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                parts.Add(string.Format("{0} thousand", Convert(number / 1000)));
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                parts.Add(string.Format("{0} hundred", Convert(number / 100)));
                number %= 100;
            }

            if (number > 0)
            {
                if (parts.Count != 0)
                    parts.Add("and");

                if (number < 20)
                    parts.Add(GetUnitValue(number, isOrdinal));
                else
                {
                    var lastPart = TensMap[number / 10];
                    if ((number % 10) > 0)
                        lastPart += string.Format("-{0}", GetUnitValue(number % 10, isOrdinal));
                    else if (isOrdinal)
                        lastPart = lastPart.TrimEnd('y') + "ieth";

                    parts.Add(lastPart);
                }
            }
            else if (isOrdinal)
                parts[parts.Count - 1] += "th";

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
        private static string GetUnitValue(long number, bool isOrdinal)
        {
            if (isOrdinal)
            {
                if (ExceptionNumbersToWords(number, out var exceptionString))
                    return exceptionString;
                else
                    return UnitsMap[number] + "th";
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
            if (toWords.IndexOf("one", StringComparison.Ordinal) == 0)
                toWords = toWords.Remove(0, 4);

            return toWords;
        }

        /// <summary>
        /// Exceptions the numbers to words.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="words">The words.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private static bool ExceptionNumbersToWords(long number, out string words)
        {
            return OrdinalExceptions.TryGetValue(number, out words);
        }
    }
}
