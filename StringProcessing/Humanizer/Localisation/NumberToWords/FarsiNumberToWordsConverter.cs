// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="FarsiNumberToWordsConverter.cs" company="Zeroit Dev Technologies">
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
    /// Class FarsiNumberToWordsConverter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.GenderlessNumberToWordsConverter" />
    internal class FarsiNumberToWordsConverter : GenderlessNumberToWordsConverter
    {
        /// <summary>
        /// The farsi hundreds map
        /// </summary>
        private static readonly string[] FarsiHundredsMap = { "صفر", "صد", "دویست", "سیصد", "چهارصد", "پانصد", "ششصد", "هفتصد", "هشتصد", "نهصد" };
        /// <summary>
        /// The farsi tens map
        /// </summary>
        private static readonly string[] FarsiTensMap = { "صفر", "ده", "بیست", "سی", "چهل", "پنجاه", "شصت", "هفتاد", "هشتاد", "نود" };
        /// <summary>
        /// The farsi units map
        /// </summary>
        private static readonly string[] FarsiUnitsMap = { "صفر", "یک", "دو", "سه", "چهار", "پنج", "شش", "هفت", "هشت", "نه", "ده", "یازده", "دوازده", "سیزده", "چهارده", "پانزده", "شانزده", "هفده", "هجده", "نوزده" };

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

            if (number < 0)
                return string.Format("منفی {0}", Convert(-number));

            if (number == 0)
                return "صفر";

            var farsiGroupsMap = new Dictionary<int, Func<int, string>> 
            { 
                {(int)Math.Pow(10, 9), n => string.Format("{0} میلیارد", Convert(n)) },
                {(int)Math.Pow(10, 6), n => string.Format("{0} میلیون", Convert(n)) },
                {(int)Math.Pow(10, 3), n => string.Format("{0} هزار", Convert(n)) },
                {(int)Math.Pow(10, 2), n => FarsiHundredsMap[n]}
            };

            var parts = new List<string>();
            foreach (var group in farsiGroupsMap.Keys)
            {
                if (number / group > 0)
                {
                    parts.Add(farsiGroupsMap[group](number / group));
                    number %= group;
                }
            }

            if (number >= 20)
            {
                parts.Add(FarsiTensMap[number / 10]);
                number %= 10;
            }

            if (number > 0)
                parts.Add(FarsiUnitsMap[number]);

            return string.Join(" و ", parts);
        }

        /// <summary>
        /// Converts the number to ordinal string
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.String.</returns>
        public override string ConvertToOrdinal(int number)
        {
            if (number == 1)
                return "اول";

            if (number == 3)
                return "سوم";

            if (number % 10 == 3 && number != 13)
                return Convert((number / 10) * 10) + " و سوم";

            var word = Convert(number);
            return string.Format("{0}{1}", word, word.EndsWith("ی") ? " ام" : "م");
        }
    }
}
