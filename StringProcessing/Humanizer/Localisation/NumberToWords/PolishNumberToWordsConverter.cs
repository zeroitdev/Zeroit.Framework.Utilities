// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="PolishNumberToWordsConverter.cs" company="Zeroit Dev Technologies">
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
using System.Globalization;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords
{
    /// <summary>
    /// Class PolishNumberToWordsConverter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.GenderlessNumberToWordsConverter" />
    internal class PolishNumberToWordsConverter : GenderlessNumberToWordsConverter
    {
        /// <summary>
        /// The hundreds map
        /// </summary>
        private static readonly string[] HundredsMap = { "zero", "sto", "dwieście", "trzysta", "czterysta", "pięćset", "sześćset", "siedemset", "osiemset", "dziewięćset" };
        /// <summary>
        /// The tens map
        /// </summary>
        private static readonly string[] TensMap = { "zero", "dziesięć", "dwadzieścia", "trzydzieści", "czterdzieści", "pięćdziesiąt", "sześćdziesiąt", "siedemdziesiąt", "osiemdziesiąt", "dziewięćdziesiąt" };
        /// <summary>
        /// The units map
        /// </summary>
        private static readonly string[] UnitsMap = { "zero", "jeden", "dwa", "trzy", "cztery", "pięć", "sześć", "siedem", "osiem", "dziewięć", "dziesięć", "jedenaście", "dwanaście", "trzynaście", "czternaście", "piętnaście", "szesnaście", "siedemnaście", "osiemnaście", "dziewiętnaście" };

        /// <summary>
        /// The culture
        /// </summary>
        private readonly CultureInfo _culture;

        /// <summary>
        /// Initializes a new instance of the <see cref="PolishNumberToWordsConverter"/> class.
        /// </summary>
        /// <param name="culture">The culture.</param>
        public PolishNumberToWordsConverter(CultureInfo culture)
        {
            _culture = culture;
        }

        /// <summary>
        /// Collects the parts under thousand.
        /// </summary>
        /// <param name="parts">The parts.</param>
        /// <param name="number">The number.</param>
        private static void CollectPartsUnderThousand(ICollection<string> parts, int number)
        {
            var hundreds = number/100;
            if (hundreds > 0)
            {
                parts.Add(HundredsMap[hundreds]);
                number = number%100;
            }

            var tens = number/10;
            if (tens > 1)
            {
                parts.Add(TensMap[tens]);
                number = number%10;
            }

            if (number > 0)
                parts.Add(UnitsMap[number]);
        }

        /// <summary>
        /// Gets the index of the mapping.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.Int32.</returns>
        private static int GetMappingIndex(int number)
        {
            if (number == 1)
                return 0;

            if (number > 1 && number < 5)
                return 1; //denominator

            var tens = number/10;
            if (tens > 1)
            {
                var unity = number%10;
                if (unity > 1 && unity < 5)
                    return 1; //denominator
            }

            return 2; //genitive
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
                return "zero";

            var parts = new List<string>();

            if (number < 0)
            {
                parts.Add("minus");
                number = -number;
            }

            var milliard = number/1000000000;
            if (milliard > 0)
            {
                if (milliard > 1)
                    CollectPartsUnderThousand(parts, milliard);

                var map = new[] { "miliard", "miliardy", "miliardów" }; //one, denominator, genitive
                parts.Add(map[GetMappingIndex(milliard)]);
                number %= 1000000000;
            }

            var million = number/1000000;
            if (million > 0)
            {
                if (million > 1)
                    CollectPartsUnderThousand(parts, million);

                var map = new[] { "milion", "miliony", "milionów" }; //one, denominator, genitive
                parts.Add(map[GetMappingIndex(million)]);
                number %= 1000000;
            }

            var thouthand = number/1000;
            if (thouthand > 0)
            {
                if (thouthand > 1)
                    CollectPartsUnderThousand(parts, thouthand);

                var thousand = new[] { "tysiąc", "tysiące", "tysięcy" }; //one, denominator, genitive
                parts.Add(thousand[GetMappingIndex(thouthand)]);
                number %= 1000;
            }

            var units = number/1;
            if (units > 0)
                CollectPartsUnderThousand(parts, units);

            return string.Join(" ", parts);
        }

        /// <summary>
        /// Converts the number to ordinal string
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.String.</returns>
        public override string ConvertToOrdinal(int number)
        {
            return number.ToString(_culture);
        }
    }
}
