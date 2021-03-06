﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="RussianNumberToWordsConverter.cs" company="Zeroit Dev Technologies">
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
using Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.GrammaticalNumber;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords
{
    /// <summary>
    /// Class RussianNumberToWordsConverter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.GenderedNumberToWordsConverter" />
    internal class RussianNumberToWordsConverter : GenderedNumberToWordsConverter
    {
        /// <summary>
        /// The hundreds map
        /// </summary>
        private static readonly string[] HundredsMap = { "ноль", "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" };
        /// <summary>
        /// The tens map
        /// </summary>
        private static readonly string[] TensMap = { "ноль", "десять", "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто" };
        /// <summary>
        /// The units map
        /// </summary>
        private static readonly string[] UnitsMap = { "ноль", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять", "десять", "одиннадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать" };
        /// <summary>
        /// The units ordinal prefixes
        /// </summary>
        private static readonly string[] UnitsOrdinalPrefixes = { string.Empty, string.Empty, "двух", "трёх", "четырёх", "пяти", "шести", "семи", "восьми", "девяти", "десяти", "одиннадцати", "двенадцати", "тринадцати", "четырнадцати", "пятнадцати", "шестнадцати", "семнадцати", "восемнадцати", "девятнадцати" };
        /// <summary>
        /// The tens ordinal prefixes
        /// </summary>
        private static readonly string[] TensOrdinalPrefixes = { string.Empty, "десяти", "двадцати", "тридцати", "сорока", "пятидесяти", "шестидесяти", "семидесяти", "восьмидесяти", "девяносто" };
        /// <summary>
        /// The tens ordinal
        /// </summary>
        private static readonly string[] TensOrdinal = { string.Empty, "десят", "двадцат", "тридцат", "сороков", "пятидесят", "шестидесят", "семидесят", "восьмидесят", "девяност" };
        /// <summary>
        /// The units ordinal
        /// </summary>
        private static readonly string[] UnitsOrdinal = { string.Empty, "перв", "втор", "трет", "четверт", "пят", "шест", "седьм", "восьм", "девят", "десят", "одиннадцат", "двенадцат", "тринадцат", "четырнадцат", "пятнадцат", "шестнадцат", "семнадцат", "восемнадцат", "девятнадцат" };

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
                return "ноль";

            var parts = new List<string>();

            if (number < 0)
            {
                parts.Add("минус");
                number = -number;
            }

            CollectParts(parts, ref number, 1000000000, GrammaticalGender.Masculine, "миллиард", "миллиарда", "миллиардов");
            CollectParts(parts, ref number, 1000000, GrammaticalGender.Masculine, "миллион", "миллиона", "миллионов");
            CollectParts(parts, ref number, 1000, GrammaticalGender.Feminine, "тысяча", "тысячи", "тысяч");

            if (number > 0)
                CollectPartsUnderOneThousand(parts, number, gender);

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
            if (number == 0)
                return "нулев" + GetEndingForGender(gender, number);

            var parts = new List<string>();

            if (number < 0)
            {
                parts.Add("минус");
                number = -number;
            }

            CollectOrdinalParts(parts, ref number, 1000000000, GrammaticalGender.Masculine, "миллиардн" + GetEndingForGender(gender, number), "миллиард", "миллиарда", "миллиардов");
            CollectOrdinalParts(parts, ref number, 1000000, GrammaticalGender.Masculine, "миллионн" + GetEndingForGender(gender, number), "миллион", "миллиона", "миллионов");
            CollectOrdinalParts(parts, ref number, 1000, GrammaticalGender.Feminine, "тысячн" + GetEndingForGender(gender, number), "тысяча", "тысячи", "тысяч");

            if (number >= 100)
            {
                var ending = GetEndingForGender(gender, number);
                var hundreds = number/100;
                number %= 100;
                if (number == 0)
                    parts.Add(UnitsOrdinalPrefixes[hundreds] + "сот" + ending);
                else
                    parts.Add(HundredsMap[hundreds]);
            }

            if (number >= 20)
            {
                var ending = GetEndingForGender(gender, number);
                var tens = number/10;
                number %= 10;
                if (number == 0)
                    parts.Add(TensOrdinal[tens] + ending);
                else
                    parts.Add(TensMap[tens]);
            }

            if (number > 0)
                parts.Add(UnitsOrdinal[number] + GetEndingForGender(gender, number));

            return string.Join(" ", parts);
        }

        /// <summary>
        /// Collects the parts under one thousand.
        /// </summary>
        /// <param name="parts">The parts.</param>
        /// <param name="number">The number.</param>
        /// <param name="gender">The gender.</param>
        private static void CollectPartsUnderOneThousand(ICollection<string> parts, int number, GrammaticalGender gender)
        {
            if (number >= 100)
            {
                var hundreds = number/100;
                number %= 100;
                parts.Add(HundredsMap[hundreds]);
            }

            if (number >= 20)
            {
                var tens = number/10;
                parts.Add(TensMap[tens]);
                number %= 10;
            }

            if (number > 0)
            {
                if (number == 1 && gender == GrammaticalGender.Feminine)
                    parts.Add("одна");
                else if (number == 1 && gender == GrammaticalGender.Neuter)
                    parts.Add("одно");
                else if (number == 2 && gender == GrammaticalGender.Feminine)
                    parts.Add("две");
                else if (number < 20)
                    parts.Add(UnitsMap[number]);
            }
        }

        /// <summary>
        /// Gets the prefix.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.String.</returns>
        private static string GetPrefix(int number)
        {
            var parts = new List<string>();

            if (number >= 100)
            {
                var hundreds = number/100;
                number %= 100;
                if (hundreds != 1)
                    parts.Add(UnitsOrdinalPrefixes[hundreds] + "сот");
                else
                    parts.Add("сто");
            }

            if (number >= 20)
            {
                var tens = number/10;
                number %= 10;
                parts.Add(TensOrdinalPrefixes[tens]);
            }

            if (number > 0)
            {
                parts.Add(number == 1 ? "одно" : UnitsOrdinalPrefixes[number]);
            }

            return string.Join("", parts);
        }

        /// <summary>
        /// Collects the parts.
        /// </summary>
        /// <param name="parts">The parts.</param>
        /// <param name="number">The number.</param>
        /// <param name="divisor">The divisor.</param>
        /// <param name="gender">The gender.</param>
        /// <param name="forms">The forms.</param>
        private static void CollectParts(ICollection<string> parts, ref int number, int divisor, GrammaticalGender gender, params string[] forms)
        {
            if (number < divisor) return;
            var result = number/divisor;
            number %= divisor;

            CollectPartsUnderOneThousand(parts, result, gender);
            parts.Add(ChooseOneForGrammaticalNumber(result, forms));
        }

        /// <summary>
        /// Collects the ordinal parts.
        /// </summary>
        /// <param name="parts">The parts.</param>
        /// <param name="number">The number.</param>
        /// <param name="divisor">The divisor.</param>
        /// <param name="gender">The gender.</param>
        /// <param name="prefixedForm">The prefixed form.</param>
        /// <param name="forms">The forms.</param>
        private static void CollectOrdinalParts(ICollection<string> parts, ref int number, int divisor, GrammaticalGender gender, string prefixedForm, params string[] forms)
        {
            if (number < divisor) return;
            var result = number/divisor;
            number %= divisor;
            if (number == 0)
            {
                if (result == 1)
                    parts.Add(prefixedForm);
                else
                    parts.Add(GetPrefix(result) + prefixedForm);
            }
            else
            {
                CollectPartsUnderOneThousand(parts, result, gender);
                parts.Add(ChooseOneForGrammaticalNumber(result, forms));
            }
        }

        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.Int32.</returns>
        private static int GetIndex(RussianGrammaticalNumber number)
        {
            if (number == RussianGrammaticalNumber.Singular)
                return 0;

            if (number == RussianGrammaticalNumber.Paucal)
                return 1;

            return 2;
        }

        /// <summary>
        /// Chooses the one for grammatical number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="forms">The forms.</param>
        /// <returns>System.String.</returns>
        private static string ChooseOneForGrammaticalNumber(int number, string[] forms)
        {
            return forms[GetIndex(RussianGrammaticalNumberDetector.Detect(number))];
        }

        /// <summary>
        /// Gets the ending for gender.
        /// </summary>
        /// <param name="gender">The gender.</param>
        /// <param name="number">The number.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentOutOfRangeException">gender</exception>
        private static string GetEndingForGender(GrammaticalGender gender, int number)
        {
            switch (gender)
            {
                case GrammaticalGender.Masculine:
                    if (number == 0 || number == 2 || number == 6 || number == 7 || number == 8 || number == 40)
                        return "ой";
                    if (number == 3)
                        return "ий";
                    return "ый";
                case GrammaticalGender.Feminine:
                    if (number == 3)
                        return "ья";
                    return "ая";
                case GrammaticalGender.Neuter:
                    if (number == 3)
                        return "ье";
                    return "ое";
                default:
                    throw new ArgumentOutOfRangeException(nameof(gender));
            }
        }
    }
}
