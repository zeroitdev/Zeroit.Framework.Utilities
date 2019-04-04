// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="BanglaNumberToWordsConverter.cs" company="Zeroit Dev Technologies">
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
    /// Class BanglaNumberToWordsConverter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.GenderlessNumberToWordsConverter" />
    internal class BanglaNumberToWordsConverter : GenderlessNumberToWordsConverter
    {
        /// <summary>
        /// The units map
        /// </summary>
        private static readonly string[] UnitsMap =
            {
                "শূন্য", "এক", "দুই", "তিন", "চার", "পাঁচ", "ছয়", "সাত", "আট", "নয়", "দশ",
                "এগারো", "বারো", "তেরো", "চোদ্দ", "পনেরো", "ষোল", "সতেরো", "আঠারো", "উনিশ", "বিশ",
                "একুশ", "বাইশ", "তেইশ", "চব্বিশ", "পঁচিশ", "ছাব্বিশ", "সাতাশ", "আঠাশ", "উনতিরিশ", "তিরিশ",
                "একতিরিশ", "বত্রিশ", "তেত্রিশ", "চৌঁতিরিশ", "পঁয়তিরিশ", "ছত্রিশ", "সাঁইতিরিশ", "আটতিরিশ", "উনচল্লিশ","চল্লিশ",
                "একচল্লিশ", "বিয়াল্লিশ", "তেতাল্লিশ", "চুয়াল্লিশ", "পঁয়তাল্লিশ", "ছেচাল্লিশ", "সাতচল্লিশ", "আটচল্লিশ","উনপঞ্চাশ", "পঞ্চাশ",
                "একান্ন", "বাহান্ন", "তিপ্পান্ন", "চুয়ান্ন", "পঞ্চান্ন", "ছাপ্পান্ন", "সাতান্ন", "আটান্ন", "উনষাট","ষাট",
                "একষট্টি", "বাষট্টি", "তেষট্টি", "চৌষট্টি", "পঁয়ষট্টি", "ছেষট্টি", "সাতষট্টি", "আটষট্টি", "উনসত্তর","সত্তর",
                "একাত্তর", "বাহাত্তর", "তিয়াত্তর", "চুয়াত্তর", "পঁচাত্তর", "ছিয়াত্তর", "সাতাত্তর", "আটাত্তর", "উনআশি", "আশি",
                "একাশি", "বিরাশি", "তিরাশি", "চুরাশি", "পঁচাশি", "ছিয়াশি", "সাতাশি", "আটাশি", "উননব্বই", "নব্বই",
                "একানব্বই", "বিরানব্বই", "তিরানব্বিই", "চুরানব্বই", "পঁচানব্বই", "ছিয়ানব্বই", "সাতানব্বই", "আটানব্বই","নিরানব্বই"
            };

        /// <summary>
        /// The hundreds map
        /// </summary>
        private static readonly string[] HundredsMap =
            {
                "শূন্য", "একশ", "দুইশ", "তিনশ", "চারশ", "পাঁচশ", "ছয়শ", "সাতশ","আটশ", "নয়শ"
            };

        /// <summary>
        /// The ordinal exceptions
        /// </summary>
        private static readonly Dictionary<int, string> OrdinalExceptions = new Dictionary<int, string>
            {
                {1, "প্রথম"},
                {2, "দ্বিতীয়"},
                {3, "তৃতীয়"},
                {4, "চতুর্থ"},
                {5, "পঞ্চম"},
                {6, "ষষ্ট"},
                {7, "সপ্তম"},
                {8, "অষ্টম"},
                {9, "নবম"},
                {10, "দশম"},
                {11, "একাদশ"},
                {12, "দ্বাদশ"},
                {13, "ত্রয়োদশ"},
                {14, "চতুর্দশ"},
                {15, "পঞ্চদশ"},
                {16, "ষোড়শ"},
                {17, "সপ্তদশ"},
                {18, "অষ্টাদশ"},
                {100, "শত তম"},
                {1000, "হাজার তম"},
                {100000, "লক্ষ তম"},
                {10000000, "কোটি তম"},
            };

        /// <summary>
        /// Converts the number to ordinal string
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.String.</returns>
        public override string ConvertToOrdinal(int number)
        {
            if (ExceptionNumbersToWords(number, out var exceptionString))
                return exceptionString;

            return Convert(number) + " তম";
        }

        /// <summary>
        /// Converts the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override string Convert(long input)
        {
            if (input > Int32.MaxValue || input < Int32.MinValue)
            {
                throw new NotImplementedException();
            }
            var number = (int)input;

            if (number == 0)
                return UnitsMap[0];

            if (number < 0)
                return string.Format("ঋণাত্মক {0}", Convert(-number));

            var parts = new List<string>();

            if ((number/10000000) > 0)
            {
                parts.Add(string.Format("{0} কোটি", Convert(number/10000000)));
                number %= 10000000;
            }

            if ((number/100000) > 0)
            {
                parts.Add(string.Format("{0} লক্ষ", Convert(number/100000)));
                number %= 100000;
            }

            if ((number/1000) > 0)
            {
                parts.Add(string.Format("{0} হাজার", Convert(number/1000)));
                number %= 1000;
            }

            if ((number/100) > 0)
            {
                parts.Add(string.Format("{0}", HundredsMap[number/100]));
                number %= 100;
            }

            if (number > 0)
                parts.Add(UnitsMap[number]);

            return string.Join(" ", parts.ToArray());
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
