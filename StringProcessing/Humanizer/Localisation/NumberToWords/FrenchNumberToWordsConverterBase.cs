// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="FrenchNumberToWordsConverterBase.cs" company="Zeroit Dev Technologies">
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
using Zeroit.Framework.Utilities.StringProcessing.Humanizer;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords
{
    /// <summary>
    /// Class FrenchNumberToWordsConverterBase.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.GenderedNumberToWordsConverter" />
    abstract class FrenchNumberToWordsConverterBase : GenderedNumberToWordsConverter
    {
        /// <summary>
        /// The units map
        /// </summary>
        static readonly string[] UnitsMap = { "zéro", "un", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf", "dix", "onze", "douze", "treize", "quatorze", "quinze", "seize", "dix-sept", "dix-huit", "dix-neuf"};
        /// <summary>
        /// The tens map
        /// </summary>
        static readonly string[] TensMap = { "zéro", "dix", "vingt", "trente", "quarante", "cinquante", "soixante", "septante", "octante", "nonante" };

        /// <summary>
        /// Converts the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override string Convert(long input, GrammaticalGender gender)
        {
            if (input > Int32.MaxValue || input < Int32.MinValue)
            {
                throw new NotImplementedException();
            }
            var number = (int)input;

            if (number == 0)
                return UnitsMap[0];
            var parts = new List<string>();

            if (number < 0)
            {
                parts.Add("moins");
                number = -number;
            }

            CollectParts(parts, ref number, 1000000000, "milliard");
            CollectParts(parts, ref number, 1000000, "million");
            CollectThousands(parts, ref number, 1000, "mille");

            CollectPartsUnderAThousand(parts, number, gender, true);

            return string.Join(" ", parts);
        }

        /// <summary>
        /// Converts the number to ordinal string using the provided grammatical gender
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>System.String.</returns>
        public override string ConvertToOrdinal(int number, GrammaticalGender gender)
        {
            if (number == 1)
                return gender == GrammaticalGender.Feminine ? "première" : "premier";

            var convertedNumber = Convert(number);

            if (convertedNumber.EndsWith("s") && !convertedNumber.EndsWith("trois"))
                convertedNumber = convertedNumber.TrimEnd('s');
            else if (convertedNumber.EndsWith("cinq"))
                convertedNumber += "u";
            else if (convertedNumber.EndsWith("neuf"))
                convertedNumber = convertedNumber.TrimEnd('f') + "v";

            if (convertedNumber.StartsWith("un "))
                convertedNumber = convertedNumber.Remove(0, 3);

            if (number == 0)
                convertedNumber += "t";

            convertedNumber = convertedNumber.TrimEnd('e');
            convertedNumber += "ième";
            return convertedNumber;
        }

        /// <summary>
        /// Gets the units.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>System.String.</returns>
        protected static string GetUnits(int number, GrammaticalGender gender)
        {
            if (number == 1 && gender == GrammaticalGender.Feminine)
            {
                return "une";
            }

            return UnitsMap[number];
        }

        /// <summary>
        /// Collects the hundreds.
        /// </summary>
        /// <param name="parts">The parts.</param>
        /// <param name="number">The number.</param>
        /// <param name="d">The d.</param>
        /// <param name="form">The form.</param>
        /// <param name="pluralize">if set to <c>true</c> [pluralize].</param>
        static void CollectHundreds(ICollection<string> parts, ref int number, int d, string form, bool pluralize)
        {
            if (number < d) return;

            var result = number/d;
            if (result == 1)
            {
                parts.Add(form);
            }
            else
            {
                parts.Add(GetUnits(result, GrammaticalGender.Masculine));
                if (number%d == 0 && pluralize)
                {
                    parts.Add(form + "s");
                }
                else
                {
                    parts.Add(form);
                }
            }

            number %= d;
        }

        /// <summary>
        /// Collects the parts.
        /// </summary>
        /// <param name="parts">The parts.</param>
        /// <param name="number">The number.</param>
        /// <param name="d">The d.</param>
        /// <param name="form">The form.</param>
        void CollectParts(ICollection<string> parts, ref int number, int d, string form)
        {
            if (number < d) return;

            var result = number/d;

            CollectPartsUnderAThousand(parts, result, GrammaticalGender.Masculine, true);

            if (result == 1)
            {
                parts.Add(form);
            }
            else
            {
                parts.Add(form + "s");
            }

            number %= d;
        }

        /// <summary>
        /// Collects the parts under a thousand.
        /// </summary>
        /// <param name="parts">The parts.</param>
        /// <param name="number">The number.</param>
        /// <param name="gender">The gender.</param>
        /// <param name="pluralize">if set to <c>true</c> [pluralize].</param>
        void CollectPartsUnderAThousand(ICollection<string> parts, int number, GrammaticalGender gender, bool pluralize)
        {
            CollectHundreds(parts, ref number, 100, "cent", pluralize);

            if (number > 0)
            {
                CollectPartsUnderAHundred(parts, ref number, gender, pluralize);
            }
        }

        /// <summary>
        /// Collects the thousands.
        /// </summary>
        /// <param name="parts">The parts.</param>
        /// <param name="number">The number.</param>
        /// <param name="d">The d.</param>
        /// <param name="form">The form.</param>
        void CollectThousands(ICollection<string> parts, ref int number, int d, string form)
        {
            if (number < d) return;

            var result = number/d;
            if (result > 1)
            {
                CollectPartsUnderAThousand(parts, result, GrammaticalGender.Masculine, false);
            }

            parts.Add(form);

            number %= d;
        }

        /// <summary>
        /// Collects the parts under a hundred.
        /// </summary>
        /// <param name="parts">The parts.</param>
        /// <param name="number">The number.</param>
        /// <param name="gender">The gender.</param>
        /// <param name="pluralize">if set to <c>true</c> [pluralize].</param>
        protected virtual void CollectPartsUnderAHundred(ICollection<string> parts, ref int number, GrammaticalGender gender, bool pluralize)
        {
            if (number < 20)
            {
                parts.Add(GetUnits(number, gender));
            }
            else
            {
                var units = number%10;
                var tens = GetTens(number/10);
                if (units == 0)
                {
                    parts.Add(tens);
                }
                else if (units == 1)
                {
                    parts.Add(tens);
                    parts.Add("et");
                    parts.Add(GetUnits(1, gender));
                }
                else
                {
                    parts.Add($"{tens}-{GetUnits(units, gender)}");
                }
            }
        }

        /// <summary>
        /// Gets the tens.
        /// </summary>
        /// <param name="tens">The tens.</param>
        /// <returns>System.String.</returns>
        protected virtual string GetTens(int tens)
        {
            return TensMap[tens];
        }
    }
}