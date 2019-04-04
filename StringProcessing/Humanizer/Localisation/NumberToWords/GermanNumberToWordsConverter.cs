// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="GermanNumberToWordsConverter.cs" company="Zeroit Dev Technologies">
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
    /// Class GermanNumberToWordsConverter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.GenderedNumberToWordsConverter" />
    internal class GermanNumberToWordsConverter : GenderedNumberToWordsConverter
    {
        /// <summary>
        /// The units map
        /// </summary>
        private static readonly string[] UnitsMap = { "null", "ein", "zwei", "drei", "vier", "fünf", "sechs", "sieben", "acht", "neun", "zehn", "elf", "zwölf", "dreizehn", "vierzehn", "fünfzehn", "sechzehn", "siebzehn", "achtzehn", "neunzehn" };
        /// <summary>
        /// The tens map
        /// </summary>
        private static readonly string[] TensMap = { "null", "zehn", "zwanzig", "dreißig", "vierzig", "fünfzig", "sechzig", "siebzig", "achtzig", "neunzig" };
        /// <summary>
        /// The units ordinal
        /// </summary>
        private static readonly string[] UnitsOrdinal = { string.Empty, "ers", "zwei", "drit", "vier", "fünf", "sechs", "sieb", "ach", "neun", "zehn", "elf", "zwölf", "dreizehn", "vierzehn", "fünfzehn", "sechzehn", "siebzehn", "achtzehn", "neunzehn" };
        /// <summary>
        /// The million ordinal singular
        /// </summary>
        private static readonly string[] MillionOrdinalSingular = {"einmillion", "einemillion"};
        /// <summary>
        /// The million ordinal plural
        /// </summary>
        private static readonly string[] MillionOrdinalPlural = {"{0}million", "{0}millionen"};
        /// <summary>
        /// The billion ordinal singular
        /// </summary>
        private static readonly string[] BillionOrdinalSingular = {"einmilliard", "einemilliarde"};
        /// <summary>
        /// The billion ordinal plural
        /// </summary>
        private static readonly string[] BillionOrdinalPlural = {"{0}milliard", "{0}milliarden"};

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
                return "null";

            if (number < 0)
                return string.Format("minus {0}", Convert(-number));

            var parts = new List<string>();

            var billions = number/1000000000;
            if (billions > 0)
            {
                parts.Add(Part("{0} Milliarden", "eine Milliarde", billions));
                number %= 1000000000;
                if (number > 0)
                    parts.Add(" ");
            }

            var millions = number/1000000;
            if (millions > 0)
            {
                parts.Add(Part("{0} Millionen", "eine Million", millions));
                number %= 1000000;
                if (number > 0)
                    parts.Add(" ");
            }

            var thousands = number/1000;
            if (thousands > 0)
            {
                parts.Add(Part("{0}tausend", "eintausend", thousands));
                number %= 1000;
            }

            var hundreds = number/100;
            if (hundreds > 0)
            {
                parts.Add(Part("{0}hundert", "einhundert", hundreds));
                number %= 100;
            }

            if (number > 0)
            {
                if (number < 20)
                {
                    if (number > 1)
                        parts.Add(UnitsMap[number]);
                    else
                        parts.Add("eins");
                }
                else
                {
                    var units = number%10;
                    if (units > 0)
                        parts.Add(string.Format("{0}und", UnitsMap[units]));

                    parts.Add(TensMap[number/10]);
                }
            }

            return string.Join("", parts);
        }

        /// <summary>
        /// Converts the number to ordinal string using the provided grammatical gender
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>System.String.</returns>
        public override string ConvertToOrdinal(int number, GrammaticalGender gender)
        {
            if (number == 0)
                return "null" + GetEndingForGender(gender);

            var parts = new List<string>();
            if (number < 0)
            {
                parts.Add("minus ");
                number = -number;
            }

            var billions = number/1000000000;
            if (billions > 0)
            {
                number %= 1000000000;
                var noRest = NoRestIndex(number);
                parts.Add(Part(BillionOrdinalPlural[noRest], BillionOrdinalSingular[noRest], billions));
            }

            var millions = number/1000000;
            if (millions > 0)
            {
                number %= 1000000;
                var noRest = NoRestIndex(number);
                parts.Add(Part(MillionOrdinalPlural[noRest], MillionOrdinalSingular[noRest], millions));
            }

            var thousands = number/1000;
            if (thousands > 0)
            {
                parts.Add(Part("{0}tausend", "eintausend", thousands));
                number %= 1000;
            }

            var hundreds = number/100;
            if (hundreds > 0)
            {
                parts.Add(Part("{0}hundert", "einhundert", hundreds));
                number %= 100;
            }

            if (number > 0)
                parts.Add(number < 20 ? UnitsOrdinal[number] : Convert(number));

            if (number == 0 || number >= 20)
                parts.Add("s");

            parts.Add(GetEndingForGender(gender));

            return string.Join("", parts);
        }

        /// <summary>
        /// Parts the specified plural format.
        /// </summary>
        /// <param name="pluralFormat">The plural format.</param>
        /// <param name="singular">The singular.</param>
        /// <param name="number">The number.</param>
        /// <returns>System.String.</returns>
        private string Part(string pluralFormat, string singular, int number)
        {
            if (number == 1)
                return singular;
            return string.Format(pluralFormat, Convert(number));
        }

        /// <summary>
        /// Noes the index of the rest.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.Int32.</returns>
        private static int NoRestIndex(int number)
        {
            return number == 0 ? 0 : 1;
        }

        /// <summary>
        /// Gets the ending for gender.
        /// </summary>
        /// <param name="gender">The gender.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentOutOfRangeException">gender</exception>
        private static string GetEndingForGender(GrammaticalGender gender)
        {
            switch (gender)
            {
                case GrammaticalGender.Masculine:
                    return "ter";
                case GrammaticalGender.Feminine:
                    return "te";
                case GrammaticalGender.Neuter:
                    return "tes";
                default:
                    throw new ArgumentOutOfRangeException(nameof(gender));
            }
        }
    }
}