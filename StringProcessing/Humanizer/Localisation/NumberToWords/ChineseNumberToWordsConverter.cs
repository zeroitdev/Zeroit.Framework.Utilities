// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ChineseNumberToWordsConverter.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords
{
    /// <summary>
    /// Class ChineseNumberToWordsConverter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.GenderlessNumberToWordsConverter" />
    internal class ChineseNumberToWordsConverter : GenderlessNumberToWordsConverter
    {
        /// <summary>
        /// The units map
        /// </summary>
        private static readonly string[] UnitsMap = { "零", "一", "二", "三", "四", "五", "六", "七", "八", "九", "十" };

        /// <summary>
        /// Converts the number to string
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.String.</returns>
        public override string Convert(long number)
        {
            return Convert(number, false, IsSpecial(number));
        }

        /// <summary>
        /// Converts the number to ordinal string
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.String.</returns>
        public override string ConvertToOrdinal(int number)
        {
            return Convert(number, true, IsSpecial(number));
        }

        /// <summary>
        /// Determines whether the specified number is special.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns><c>true</c> if the specified number is special; otherwise, <c>false</c>.</returns>
        private bool IsSpecial(long number) => number > 10 && number < 20;

        /// <summary>
        /// Converts the specified number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="isOrdinal">if set to <c>true</c> [is ordinal].</param>
        /// <param name="isSpecial">if set to <c>true</c> [is special].</param>
        /// <returns>System.String.</returns>
        private string Convert(long number, bool isOrdinal, bool isSpecial)
        {
            if (number == 0)
                return UnitsMap[0];

            if (number < 0)
                return string.Format("负 {0}", Convert(-number, false, false));

            var parts = new List<string>();            

            if ((number / 1000000000000) > 0)
            {
                var format = "{0}兆";
                if (number % 1000000000000 < 100000000000 && number % 1000000000000 > 0)
                    format = "{0}兆零";
                parts.Add(string.Format(format, Convert(number / 1000000000000, false, false)));
                number %= 1000000000000;
            }

            if ((number / 100000000) > 0)
            {
                var format = "{0}亿";
                if (number % 100000000 < 10000000 && number % 100000000 > 0)
                    format = "{0}亿零";
                parts.Add(string.Format(format, Convert(number / 100000000, false, false)));
                number %= 100000000;
            }     

            if ((number / 10000) > 0)
            {
                var format = "{0}万";
                if (number % 10000 < 1000 && number % 10000 > 0)
                    format = "{0}万零";
                parts.Add(string.Format(format, Convert(number / 10000, false, false)));
                number %= 10000;
            }

            if ((number / 1000) > 0)
            {
                var format = "{0}千";
                if (number % 1000 < 100 && number % 1000 > 0)
                    format = "{0}千零";
                parts.Add(string.Format(format, Convert(number / 1000, false, false)));
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                var format = "{0}百";
                if (number % 100 < 10  && number % 100 > 0)
                    format = "{0}百零";
                parts.Add(string.Format(format, Convert(number / 100, false, false)));                
                number %= 100;
            }

            if (number > 0)
            {                
                if (number <= 10)
                    parts.Add(UnitsMap[number]);
                else
                {
                    var lastPart = string.Format("{0}十", UnitsMap[number / 10]);
                    if ((number % 10) > 0)
                        lastPart += string.Format("{0}", UnitsMap[number % 10]);                    

                    parts.Add(lastPart);
                }
            }

            var toWords = string.Join("", parts.ToArray());

            if (isSpecial)
                toWords = toWords.Substring(1);

            if (isOrdinal)
                toWords = string.Format("第 {0}", toWords);            

            return toWords;
        }        
    }
}
