// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="SpanishNumberToWordsConverter.cs" company="Zeroit Dev Technologies">
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
    /// Class SpanishNumberToWordsConverter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.GenderedNumberToWordsConverter" />
    internal class SpanishNumberToWordsConverter : GenderedNumberToWordsConverter
    {
        /// <summary>
        /// The units map
        /// </summary>
        private static readonly string[] UnitsMap = { "cero", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve", "diez", "once", "doce", 
                                                        "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve", "veinte", "veintiuno",
                                                        "veintidós", "veintitrés", "veinticuatro", "veinticinco", "veintiséis", "veintisiete", "veintiocho", "veintinueve"};
        /// <summary>
        /// The feminine1
        /// </summary>
        private const string Feminine1 = "una";
        /// <summary>
        /// The feminine21
        /// </summary>
        private const string Feminine21 = "veintiuna";
        /// <summary>
        /// The tens map
        /// </summary>
        private static readonly string[] TensMap = { "cero", "diez", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };
        /// <summary>
        /// The hundreds map
        /// </summary>
        private static readonly string[] HundredsMap = { "cero", "ciento", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos" };
        /// <summary>
        /// The feminine hundreds map
        /// </summary>
        private static readonly string[] FeminineHundredsMap = { "cero", "ciento", "doscientas", "trescientas", "cuatrocientas", "quinientas", "seiscientas", "setecientas", "ochocientas", "novecientas" };
        /// <summary>
        /// The tens map ordinal
        /// </summary>
        private static readonly string[] TensMapOrdinal = { "", "décimo", "vigésimo", "trigésimo", "cuadragésimo", "quincuagésimo", "sexagésimo", "septuagésimo", "octogésimo", "nonagésimo" };
        /// <summary>
        /// The hundreds map ordinal
        /// </summary>
        private static readonly string[] HundredsMapOrdinal = { "", "centésimo", "ducentésimo", "tricentésimo", "cuadringentésimo", "quingentésimo", "sexcentésimo", "septingentésimo", "octingentésimo", "noningentésimo" };
        /// <summary>
        /// The thousands map ordinal
        /// </summary>
        private static readonly string[] ThousandsMapOrdinal = { "", "milésimo", "dosmilésimo", "tresmilésimo", "cuatromilésimo", "cincomilésimo", "seismilésimo", "sietemilésimo", "ochomilésimo", "nuevemilésimo" };
        /// <summary>
        /// The ordinals
        /// </summary>
        private static readonly Dictionary<int, string> Ordinals = new Dictionary<int, string>
        {
            {1, "primero"},
            {2, "segundo"},
            {3, "tercero"},
            {4, "cuarto"},
            {5, "quinto"},
            {6, "sexto"},
            {7, "séptimo"},
            {8, "octavo"},
            {9, "noveno"},
        };

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
                return "cero";

            if (number < 0)
                return string.Format("menos {0}", Convert(Math.Abs(number)));

            var parts = new List<string>();

            if ((number / 1000000000) > 0)
            {
                parts.Add(number / 1000000000 == 1
                    ? "mil millones"
                    : string.Format("{0} mil millones", Convert(number / 1000000000)));

                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                parts.Add(number / 1000000 == 1
                    ? "un millón"
                    : string.Format("{0} millones", Convert(number / 1000000)));

                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                parts.Add(number / 1000 == 1
                    ? "mil"
                    : string.Format("{0} mil", Convert(number / 1000, gender)));

                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                parts.Add(number == 100 
                    ? "cien"
                    : gender == GrammaticalGender.Feminine 
                        ? FeminineHundredsMap[(number / 100)]
                        : HundredsMap[(number / 100)]);
                number %= 100;
            }

            if (number > 0)
            {
                if (number < 30)
                {
                    if (gender == GrammaticalGender.Feminine && (number == 1 || number == 21))
                    {
                        parts.Add(number == 1 ? Feminine1 : Feminine21);
                    }
                    else
                    {
                        parts.Add(UnitsMap[number]);
                    }
                }
                else
                {
                    var lastPart = TensMap[number/10];
                    int units = number%10;
                    if (units == 1 && gender == GrammaticalGender.Feminine)
                    {
                        lastPart += " y una";
                    }
                    else if (units > 0)
                    {
                        lastPart += string.Format(" y {0}", UnitsMap[number % 10]);
                    }

                    parts.Add(lastPart);
                }
            }

            return string.Join(" ", parts.ToArray());
        }

        /// <summary>
        /// Converts the number to ordinal string using the provided grammatical gender
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>System.String.</returns>
        public override string ConvertToOrdinal(int number, GrammaticalGender gender)
        {
            var parts = new List<string>();

            if (number > 9999) // @mihemihe: Implemented only up to 9999 - Dec-2017
            {
                return Convert(number, gender);
            }

            if (number < 0)
                return string.Format("menos {0}", Convert(Math.Abs(number)));

            if (number == 0)
                return string.Format("cero");

            if ((number / 1000) > 0)
            {
                var thousandsPart = ThousandsMapOrdinal[(number / 1000)];
                if (gender == GrammaticalGender.Feminine) thousandsPart = thousandsPart.TrimEnd('o') + "a";
                parts.Add(thousandsPart);
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                var hundredsPart = HundredsMapOrdinal[(number / 100)];
                if (gender == GrammaticalGender.Feminine) hundredsPart = hundredsPart.TrimEnd('o') + "a";
                parts.Add(hundredsPart);
                number %= 100;
            }

            if ((number / 10) > 0)
            {
                var tensPart = TensMapOrdinal[(number / 10)];
                if (gender == GrammaticalGender.Feminine) tensPart = tensPart.TrimEnd('o') + "a";
                parts.Add(tensPart);
                number %= 10;
            }

            if (Ordinals.TryGetValue(number, out var towords))
            {
                if (gender == GrammaticalGender.Feminine) towords = towords.TrimEnd('o') + "a";
                parts.Add(towords);
            }

            return string.Join(" ", parts.ToArray());
        }
    }
}
