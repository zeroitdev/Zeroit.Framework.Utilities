// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="NorwegianBokmalNumberToWordsConverter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using Zeroit.Framework.Utilities.StringProcessing.Humanizer;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords
{
    /// <summary>
    /// Class NorwegianBokmalNumberToWordsConverter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.GenderedNumberToWordsConverter" />
    internal class NorwegianBokmalNumberToWordsConverter : GenderedNumberToWordsConverter
    {
        /// <summary>
        /// The units map
        /// </summary>
        private static readonly string[] UnitsMap = { "null", "en", "to", "tre", "fire", "fem", "seks", "sju", "åtte", "ni", "ti", "elleve", "tolv", "tretten", "fjorten", "femten", "seksten", "sytten", "atten", "nitten" };
        /// <summary>
        /// The tens map
        /// </summary>
        private static readonly string[] TensMap = { "null", "ti", "tjue", "tretti", "førti", "femti", "seksti", "sytti", "åtti", "nitti" };

        /// <summary>
        /// The ordinal exceptions
        /// </summary>
        private static readonly Dictionary<int, string> OrdinalExceptions = new Dictionary<int, string>
        {
            {0, "nullte"},
            {1, "første"},
            {2, "andre"},
            {3, "tredje"},
            {4, "fjerde"},
            {5, "femte"},
            {6, "sjette"},
            {11, "ellevte"},
            {12, "tolvte"}
        };

        /// <summary>
        /// Converts the number to string using the provided grammatical gender
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override string Convert(long number, GrammaticalGender gender)
        {
            if (number > Int32.MaxValue || number < Int32.MinValue)
            {
                throw new NotImplementedException();
            }

            return Convert((int)number, false, gender);
        }

        /// <summary>
        /// Converts the number to ordinal string using the provided grammatical gender
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>System.String.</returns>
        public override string ConvertToOrdinal(int number, GrammaticalGender gender)
        {
            return Convert(number, true, gender);
        }

        /// <summary>
        /// Converts the specified number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="isOrdinal">if set to <c>true</c> [is ordinal].</param>
        /// <param name="gender">The gender.</param>
        /// <returns>System.String.</returns>
        private string Convert(int number, bool isOrdinal, GrammaticalGender gender)
        {
            if (number == 0)
                return GetUnitValue(0, isOrdinal);

            if (number < 0)
                return string.Format("minus {0}", Convert(-number, isOrdinal, gender));

            if (number == 1)
            {
                switch (gender)
                {
                    case GrammaticalGender.Feminine:
                        return "ei";
                    case GrammaticalGender.Neuter:
                        return "et";
                }
            }

            var parts = new List<string>();

            var millionOrMore = false;

            const int billion = 1000000000;
            if ((number / billion) > 0)
            {
                millionOrMore = true;
                var isExactOrdinal = isOrdinal && number % billion == 0;
                parts.Add(Part("{0} milliard" + (isExactOrdinal ? "" : "er"), (isExactOrdinal ? "" : "en ") + "milliard", number / billion, !isExactOrdinal));
                number %= billion;
            }

            const int million = 1000000;
            if ((number / million) > 0)
            {
                millionOrMore = true;
                var isExactOrdinal = isOrdinal && number % million == 0;
                parts.Add(Part("{0} million" + (isExactOrdinal ? "" : "er"), (isExactOrdinal ? "" : "en ") + "million", number / million, !isExactOrdinal));
                number %= million;
            }

            var thousand = false;
            if ((number / 1000) > 0)
            {
                thousand = true;
                parts.Add(Part("{0}tusen", number % 1000 < 100 ? "tusen" : "ettusen", number / 1000));
                number %= 1000;
            }

            var hundred = false;
            if ((number / 100) > 0)
            {
                hundred = true;
                parts.Add(Part("{0}hundre", thousand || millionOrMore ? "ethundre" : "hundre", number / 100));
                number %= 100;
            }

            if (number > 0)
            {
                if (parts.Count != 0)
                    if (millionOrMore && !hundred && !thousand)
                        parts.Add("og ");
                    else
                        parts.Add("og");

                if (number < 20)
                    parts.Add(GetUnitValue(number, isOrdinal));
                else
                {
                    var lastPart = TensMap[number / 10];
                    if ((number % 10) > 0)
                        lastPart += string.Format("{0}", GetUnitValue(number % 10, isOrdinal));
                    else if (isOrdinal)
                        lastPart = lastPart.TrimEnd('e') + "ende";

                    parts.Add(lastPart);
                }
            }
            else if (isOrdinal)
                parts[parts.Count - 1] += (number == 0 ? "" : "en") + (millionOrMore ? "te" : "de");

            var toWords = string.Join("", parts.ToArray()).Trim();

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
                else if (number < 13)
                    return UnitsMap[number].TrimEnd('e') + "ende";
                else
                    return UnitsMap[number] + "de";
            }
            else
                return UnitsMap[number];
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

        /// <summary>
        /// Parts the specified plural format.
        /// </summary>
        /// <param name="pluralFormat">The plural format.</param>
        /// <param name="singular">The singular.</param>
        /// <param name="number">The number.</param>
        /// <param name="postfixSpace">if set to <c>true</c> [postfix space].</param>
        /// <returns>System.String.</returns>
        private string Part(string pluralFormat, string singular, int number, bool postfixSpace = false)
        {
            var postfix = postfixSpace ? " " : "";
            if (number == 1)
                return singular + postfix;
            return string.Format(pluralFormat, Convert(number)) + postfix;
        }
    }
}
