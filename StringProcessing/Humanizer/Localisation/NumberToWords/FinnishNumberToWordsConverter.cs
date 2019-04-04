// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="FinnishNumberToWordsConverter.cs" company="Zeroit Dev Technologies">
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
    /// Class FinnishNumberToWordsConverter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.GenderlessNumberToWordsConverter" />
    internal class FinnishNumberToWordsConverter : GenderlessNumberToWordsConverter
    {
        /// <summary>
        /// The units map
        /// </summary>
        private static readonly string[] UnitsMap = { "nolla", "yksi", "kaksi", "kolme", "neljä", "viisi", "kuusi", "seitsemän", "kahdeksan", "yhdeksän", "kymmenen"};
        /// <summary>
        /// The ordinal units map
        /// </summary>
        private static readonly string[] OrdinalUnitsMap = {"nollas", "ensimmäinen", "toinen", "kolmas", "neljäs", "viides", "kuudes", "seitsemäs", "kahdeksas", "yhdeksäs", "kymmenes"};

        /// <summary>
        /// The ordinal exceptions
        /// </summary>
        private static readonly Dictionary<int, string> OrdinalExceptions = new Dictionary<int, string>
        {
            {1, "yhdes" },
            {2, "kahdes" }
        };

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
                return string.Format("miinus {0}", Convert(-number));

            if (number == 0)
                return UnitsMap[0];

            var parts = new List<string>();

            if ((number / 1000000000) > 0)
            {
                parts.Add(number / 1000000000 == 1
                    ? "miljardi "
                    : string.Format("{0}miljardia ", Convert(number / 1000000000)));

                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                parts.Add(number / 1000000 == 1
                    ? "miljoona "
                    : string.Format("{0}miljoonaa ", Convert(number / 1000000)));

                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                parts.Add(number / 1000 == 1
                    ? "tuhat "
                    : string.Format("{0}tuhatta ", Convert(number / 1000)));

                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                parts.Add(number / 100 == 1
                    ? "sata"
                    : string.Format("{0}sataa", Convert(number / 100)));

                number %= 100;
            }

            if (number >= 20 && (number / 10) > 0)
            {
                parts.Add(string.Format("{0}kymmentä", Convert(number / 10)));
                number %= 10;
            }
            else if (number > 10 && number < 20)
                parts.Add(string.Format("{0}toista", UnitsMap[number % 10]));

            if (number > 0 && number <= 10)
                parts.Add(UnitsMap[number]);

            return string.Join("", parts).Trim();
        }

        /// <summary>
        /// Gets the ordinal unit.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="useExceptions">if set to <c>true</c> [use exceptions].</param>
        /// <returns>System.String.</returns>
        private string GetOrdinalUnit(int number, bool useExceptions)
        {
            if (useExceptions && OrdinalExceptions.ContainsKey(number))
            {
                return OrdinalExceptions[number];
            }

            return OrdinalUnitsMap[number];
        }

        /// <summary>
        /// To the ordinal.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="useExceptions">if set to <c>true</c> [use exceptions].</param>
        /// <returns>System.String.</returns>
        private string ToOrdinal(int number, bool useExceptions)
        {
            if (number == 0)
                return OrdinalUnitsMap[0];

            var parts = new List<string>();

            if ((number / 1000000000) > 0)
            {
                parts.Add(string.Format("{0}miljardis", (number / 1000000000) == 1 ? "" : ToOrdinal(number / 1000000000, true)));
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                parts.Add(string.Format("{0}miljoonas", (number / 1000000) == 1 ? "" : ToOrdinal(number / 1000000, true)));
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                parts.Add(string.Format("{0}tuhannes", (number / 1000) == 1 ? "" : ToOrdinal(number / 1000, true)));
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                parts.Add(string.Format("{0}sadas", (number / 100) == 1 ? "" : ToOrdinal(number / 100, true)));
                number %= 100;
            }

            if (number >= 20 && (number / 10) > 0)
            {
                parts.Add(string.Format("{0}kymmenes", ToOrdinal(number / 10, true)));
                number %= 10;
            }
            else if (number > 10 && number < 20)
                parts.Add(string.Format("{0}toista", GetOrdinalUnit(number % 10, true)));

            if (number > 0 && number <= 10)
                parts.Add(GetOrdinalUnit(number, useExceptions));

            return string.Join("", parts);
        }

        /// <summary>
        /// Converts the number to ordinal string
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.String.</returns>
        public override string ConvertToOrdinal(int number)
        {
            return ToOrdinal(number, false);
        }
    }
}
