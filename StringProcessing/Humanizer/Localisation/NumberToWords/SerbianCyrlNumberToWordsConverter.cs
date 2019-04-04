// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="SerbianCyrlNumberToWordsConverter.cs" company="Zeroit Dev Technologies">
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
    /// Class SerbianCyrlNumberToWordsConverter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.GenderlessNumberToWordsConverter" />
    internal class SerbianCyrlNumberToWordsConverter : GenderlessNumberToWordsConverter
    {
        /// <summary>
        /// The units map
        /// </summary>
        private static readonly string[] UnitsMap = { "нула", "један", "два", "три", "четири", "пет", "шест", "седам", "осам", "девет", "десет", "једанест", "дванаест", "тринаест", "четрнаест", "петнаест", "шеснаест", "седамнаест", "осамнаест", "деветнаест" };
        /// <summary>
        /// The tens map
        /// </summary>
        private static readonly string[] TensMap = { "нула", "десет", "двадесет", "тридесет", "четрдесет", "петдесет", "шестдесет", "седамдесет", "осамдесет", "деветдесет" };

        /// <summary>
        /// The culture
        /// </summary>
        private readonly CultureInfo _culture;

        /// <summary>
        /// Initializes a new instance of the <see cref="SerbianCyrlNumberToWordsConverter"/> class.
        /// </summary>
        /// <param name="culture">The culture.</param>
        public SerbianCyrlNumberToWordsConverter(CultureInfo culture)
        {
            _culture = culture;
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
                return "нула";

            if (number < 0)
                return string.Format("- {0}", Convert(-number));

            var parts = new List<string>();
            var billions = number / 1000000000;

            if (billions > 0)
            {
                parts.Add(Part("милијарда", "две милијарде", "{0} милијарде", "{0} милијарда", billions));
                number %= 1000000000;

                if (number > 0)
                    parts.Add(" ");
            }

            var millions = number / 1000000;

            if (millions > 0)
            {
                parts.Add(Part("милион", "два милиона", "{0} милиона", "{0} милиона", millions));
                number %= 1000000;

                if (number > 0)
                    parts.Add(" ");
            }

            var thousands = number / 1000;

            if (thousands > 0)
            {
                parts.Add(Part("хиљаду", "две хиљаде", "{0} хиљаде", "{0} хиљада", thousands));
                number %= 1000;

                if (number > 0)
                    parts.Add(" ");
            }

            var hundreds = number / 100;

            if (hundreds > 0)
            {
                parts.Add(Part("сто", "двесто", "{0}сто", "{0}сто", hundreds));
                number %= 100;

                if (number > 0)
                    parts.Add(" ");
            }

            if (number > 0)
            {
                if (number < 20)
                    parts.Add(UnitsMap[number]);
                else
                {
                    parts.Add(TensMap[number / 10]);

                    var units = number % 10;

                    if (units > 0)
                        parts.Add(string.Format(" {0}", UnitsMap[units]));
                }
            }

            return string.Join("", parts);
        }

        /// <summary>
        /// Converts the number to ordinal string
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.String.</returns>
        public override string ConvertToOrdinal(int number)
        {
            //TODO: In progress
            return number.ToString(_culture);
        }

        /// <summary>
        /// Parts the specified singular.
        /// </summary>
        /// <param name="singular">The singular.</param>
        /// <param name="dual">The dual.</param>
        /// <param name="trialQuadral">The trial quadral.</param>
        /// <param name="plural">The plural.</param>
        /// <param name="number">The number.</param>
        /// <returns>System.String.</returns>
        private string Part(string singular, string dual, string trialQuadral, string plural, int number)
        {
            switch (number)
            {
                case 1:
                    return singular;
                case 2:
                    return dual;
                case 3:
                case 4:
                    return string.Format(trialQuadral, Convert(number));
                default:
                    return string.Format(plural, Convert(number));
            }
        }
    }
}
