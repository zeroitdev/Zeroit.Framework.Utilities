// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="UkrainianNumberToWordsConverter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
    /// Class UkrainianNumberToWordsConverter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.GenderedNumberToWordsConverter" />
    internal class UkrainianNumberToWordsConverter : GenderedNumberToWordsConverter
    {
        /// <summary>
        /// The hundreds map
        /// </summary>
        private static readonly string[] HundredsMap = { "нуль", "сто", "двісті", "триста", "чотириста", "п'ятсот", "шістсот", "сімсот", "вісімсот", "дев'ятсот" };
        /// <summary>
        /// The tens map
        /// </summary>
        private static readonly string[] TensMap = { "нуль", "десять", "двадцять", "тридцять", "сорок", "п'ятдесят", "шістдесят", "сімдесят", "вісімдесят", "дев'яносто" };
        /// <summary>
        /// The units map
        /// </summary>
        private static readonly string[] UnitsMap = { "нуль", "один", "два", "три", "чотири", "п'ять", "шість", "сім", "вісім", "дев'ять", "десять", "одинадцять", "дванадцять", "тринадцять", "чотирнадцять", "п'ятнадцять", "шістнадцять", "сімнадцять", "вісімнадцять", "дев'ятнадцять" };
        /// <summary>
        /// The units ordinal prefixes
        /// </summary>
        private static readonly string[] UnitsOrdinalPrefixes = { string.Empty, string.Empty, "двох", "трьох", "чотирьох", "п'яти", "шести", "семи", "восьми", "дев'яти", "десяти", "одинадцяти", "дванадцяти", "тринадцяти", "чотирнадцяти", "п'ятнадцяти", "шістнадцяти", "сімнадцяти", "вісімнадцяти", "дев'ятнадцяти", "двадцяти" };
        /// <summary>
        /// The tens ordinal prefixes
        /// </summary>
        private static readonly string[] TensOrdinalPrefixes = { string.Empty, "десяти", "двадцяти", "тридцяти", "сорока", "п'ятдесяти", "шістдесяти", "сімдесяти", "вісімдесяти", "дев'яносто" };
        /// <summary>
        /// The tens ordinal
        /// </summary>
        private static readonly string[] TensOrdinal = { string.Empty, "десят", "двадцят", "тридцят", "сороков", "п'ятдесят", "шістдесят", "сімдесят", "вісімдесят", "дев'яност" };
        /// <summary>
        /// The units ordinal
        /// </summary>
        private static readonly string[] UnitsOrdinal = { "нульов", "перш", "друг", "трет", "четверт", "п'ят", "шост", "сьом", "восьм", "дев'ят", "десят", "одинадцят", "дванадцят", "тринадцят", "чотирнадцят", "п'ятнадцят", "шістнадцят", "сімнадцят", "вісімнадцят", "дев'ятнадцят" };

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
                return "нуль";

            var parts = new List<string>();

            if (number < 0)
            {
                parts.Add("мінус");
                number = -number;
            }

            CollectParts(parts, ref number, 1000000000, GrammaticalGender.Masculine, "мільярд", "мільярда", "мільярдів");
            CollectParts(parts, ref number, 1000000, GrammaticalGender.Masculine, "мільйон", "мільйона", "мільйонів");
            CollectParts(parts, ref number, 1000, GrammaticalGender.Feminine, "тисяча", "тисячі", "тисяч");

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
                return "нульов" + GetEndingForGender(gender, number);

            var parts = new List<string>();

            if (number < 0)
            {
                parts.Add("мінус");
                number = -number;
            }

            CollectOrdinalParts(parts, ref number, 1000000000, GrammaticalGender.Masculine, "мільярдн" + GetEndingForGender(gender, number), "мільярд", "мільярда", "мільярдів");
            CollectOrdinalParts(parts, ref number, 1000000, GrammaticalGender.Masculine, "мільйонн" + GetEndingForGender(gender, number), "мільйон", "мільйона", "мільйонів");
            CollectOrdinalParts(parts, ref number, 1000, GrammaticalGender.Feminine, "тисячн" + GetEndingForGender(gender, number), "тисяча", "тисячі", "тисяч");

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
                    parts.Add("одне");
                else if (number == 2 && gender == GrammaticalGender.Feminine)
                    parts.Add("дві");
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
                    if (number == 3)
                        return "ій";
                    return "ий";
                case GrammaticalGender.Feminine:
                    if (number == 3)
                        return "я";
                    return "а";
                case GrammaticalGender.Neuter:
                    if (number == 3)
                        return "є";
                    return "е";
                default:
                    throw new ArgumentOutOfRangeException(nameof(gender));
            }
        }
    }
}
