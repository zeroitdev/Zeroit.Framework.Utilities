﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="ArabicNumberToWordsConverter.cs" company="Zeroit Dev Technologies">
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
using System.Linq;
using Zeroit.Framework.Utilities.StringProcessing.Humanizer;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords
{
    /// <summary>
    /// Class ArabicNumberToWordsConverter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.GenderedNumberToWordsConverter" />
    internal class ArabicNumberToWordsConverter : GenderedNumberToWordsConverter
    {
        /// <summary>
        /// The groups
        /// </summary>
        private static readonly string[] Groups = { "مئة", "ألف", "مليون", "مليار", "تريليون", "كوادريليون", "كوينتليون", "سكستيليون" };
        /// <summary>
        /// The appended groups
        /// </summary>
        private static readonly string[] AppendedGroups = { "", "ألفاً", "مليوناً", "ملياراً", "تريليوناً", "كوادريليوناً", "كوينتليوناً", "سكستيليوناً" };
        /// <summary>
        /// The plural groups
        /// </summary>
        private static readonly string[] PluralGroups = { "", "آلاف", "ملايين", "مليارات", "تريليونات", "كوادريليونات", "كوينتليونات", "سكستيليونات" };
        /// <summary>
        /// The ones group
        /// </summary>
        private static readonly string[] OnesGroup = { "", "واحد", "اثنان", "ثلاثة", "أربعة", "خمسة", "ستة", "سبعة", "ثمانية", "تسعة", "عشرة", "أحد عشر", "اثنا عشر", "ثلاثة عشر", "أربعة عشر", "خمسة عشر", "ستة عشر", "سبعة عشر", "ثمانية عشر", "تسعة عشر" };
        /// <summary>
        /// The tens group
        /// </summary>
        private static readonly string[] TensGroup = { "", "عشرة", "عشرون", "ثلاثون", "أربعون", "خمسون", "ستون", "سبعون", "ثمانون", "تسعون" };
        /// <summary>
        /// The hundreds group
        /// </summary>
        private static readonly string[] HundredsGroup = { "", "مئة", "مئتان", "ثلاث مئة", "أربع مئة", "خمس مئة", "ست مئة", "سبع مئة", "ثمان مئة", "تسع مئة" };
        /// <summary>
        /// The appended twos
        /// </summary>
        private static readonly string[] AppendedTwos = { "مئتان", "ألفان", "مليونان", "ملياران", "تريليونان", "كوادريليونان", "كوينتليونان", "سكستيليونلن" };
        /// <summary>
        /// The twos
        /// </summary>
        private static readonly string[] Twos = { "مئتان", "ألفان", "مليونان", "ملياران", "تريليونان", "كوادريليونان", "كوينتليونان", "سكستيليونان" };

        /// <summary>
        /// The feminine ones group
        /// </summary>
        private static readonly string[] FeminineOnesGroup = { "", "واحدة", "اثنتان", "ثلاث", "أربع", "خمس", "ست", "سبع", "ثمان", "تسع", "عشر", "إحدى عشرة", "اثنتا عشرة", "ثلاث عشرة", "أربع عشرة", "خمس عشرة", "ست عشرة", "سبع عشرة", "ثمان عشرة", "تسع عشرة" };

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
                return "صفر";

            var result = string.Empty;
            var groupLevel = 0;

            while (number >= 1)
            {
                var groupNumber = number % 1000;
                number /= 1000;

                var tens = groupNumber % 100;
                var hundreds = groupNumber / 100;
                var process = string.Empty;

                if (hundreds > 0)
                {
                    if (tens == 0 && hundreds == 2)
                        process = AppendedTwos[0];
                    else
                        process = HundredsGroup[hundreds];
                }

                if (tens > 0)
                {
                    if (tens < 20)
                    {
                        if (tens == 2 && hundreds == 0 && groupLevel > 0)
                        {
                            if (number == 2000 || number == 2000000 || number == 2000000000)
                                process = AppendedTwos[groupLevel];
                            else
                                process = Twos[groupLevel];
                        }
                        else
                        {
                            if (process != string.Empty)
                                process += " و ";

                            if (tens == 1 && groupLevel > 0 && hundreds == 0)
                                process += " ";
                            else
                                process += gender == GrammaticalGender.Feminine && groupLevel == 0 ? FeminineOnesGroup[tens] : OnesGroup[tens];
                        }
                    }
                    else
                    {
                        var ones = tens % 10;
                        tens = (tens / 10);

                        if (ones > 0)
                        {
                            if (process != string.Empty)
                                process += " و ";

                            process += gender == GrammaticalGender.Feminine ? FeminineOnesGroup[ones] : OnesGroup[ones];
                        }

                        if (process != string.Empty)
                            process += " و ";

                        process += TensGroup[tens];
                    }
                }

                if (process != string.Empty)
                {
                    if (groupLevel > 0)
                    {
                        if (result != string.Empty)
                            result = string.Format("{0} {1}", "و", result);

                        if (groupNumber != 2)
                        {
                            if (groupNumber % 100 != 1)
                            {
                                if (groupNumber >= 3 && groupNumber <= 10)
                                    result = string.Format("{0} {1}", PluralGroups[groupLevel], result);
                                else
                                    result = string.Format("{0} {1}", result != string.Empty ? AppendedGroups[groupLevel] : Groups[groupLevel], result);
                            }
                            else
                                result = string.Format("{0} {1}", Groups[groupLevel], result);
                        }
                    }

                    result = string.Format("{0} {1}", process, result);
                }

                groupLevel++;
            }

            return result.Trim();
        }

        /// <summary>
        /// The ordinal exceptions
        /// </summary>
        private static readonly Dictionary<string, string> OrdinalExceptions = new Dictionary<string, string>
        {
            {"واحد", "الحادي"},
            {"أحد", "الحادي"},
            {"اثنان", "الثاني"},
            {"اثنا", "الثاني"},
            {"ثلاثة", "الثالث"},
            {"أربعة", "الرابع"},
            {"خمسة", "الخامس"},
            {"ستة", "السادس"},
            {"سبعة", "السابع"},
            {"ثمانية", "الثامن"},
            {"تسعة", "التاسع"},
            {"عشرة", "العاشر"},
        };

        /// <summary>
        /// The feminine ordinal exceptions
        /// </summary>
        private static readonly Dictionary<string, string> FeminineOrdinalExceptions = new Dictionary<string, string>
        {
            {"واحدة", "الحادية"},
            {"إحدى", "الحادية"},
            {"اثنتان", "الثانية"},
            {"اثنتا", "الثانية"},
            {"ثلاث", "الثالثة"},
            {"أربع", "الرابعة"},
            {"خمس", "الخامسة"},
            {"ست", "السادسة"},
            {"سبع", "السابعة"},
            {"ثمان", "الثامنة"},
            {"تسع", "التاسعة"},
            {"عشر", "العاشرة"},
        };

        /// <summary>
        /// Converts the number to ordinal string using the provided grammatical gender
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>System.String.</returns>
        public override string ConvertToOrdinal(int number, GrammaticalGender gender)
        {
            if (number == 0) return "الصفر";
            var beforeOneHundredNumber = number % 100;
            var overTensPart = number / 100 * 100;
            var beforeOneHundredWord = string.Empty;
            var overTensWord = string.Empty;

            if (beforeOneHundredNumber > 0)
            {
                beforeOneHundredWord = Convert(beforeOneHundredNumber, gender);
                beforeOneHundredWord = ParseNumber(beforeOneHundredWord, beforeOneHundredNumber, gender);
            }

            if (overTensPart > 0)
            {
                overTensWord = Convert(overTensPart);
                overTensWord = ParseNumber(overTensWord, overTensPart, gender);
            }

            var word = beforeOneHundredWord +
                (overTensPart > 0
                    ? (string.IsNullOrWhiteSpace(beforeOneHundredWord) ? string.Empty : " بعد ") + overTensWord
                    : string.Empty);
            return word.Trim();
        }

        /// <summary>
        /// Parses the number.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <param name="number">The number.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>System.String.</returns>
        private static string ParseNumber(string word, int number, GrammaticalGender gender)
        {
            if (number == 1)
                return gender == GrammaticalGender.Feminine ? "الأولى" : "الأول";

            if (number <= 10)
            {
                var ordinals = gender == GrammaticalGender.Feminine ? FeminineOrdinalExceptions : OrdinalExceptions;
                foreach (var kv in ordinals.Where(kv => word.EndsWith(kv.Key)))
                {
                    // replace word with exception
                    return word.Substring(0, word.Length - kv.Key.Length) + kv.Value;
                }
            }
            else if (number > 10 && number < 100)
            {
                var parts = word.Split(' ');
                var newParts = new string[parts.Length];
                var count = 0;

                foreach (var part in parts)
                {
                    var newPart = part;
                    var oldPart = part;

                    var ordinals = gender == GrammaticalGender.Feminine ? FeminineOrdinalExceptions : OrdinalExceptions;
                    foreach (var kv in ordinals.Where(kv => oldPart.EndsWith(kv.Key)))
                    {
                        // replace word with exception
                        newPart = oldPart.Substring(0, oldPart.Length - kv.Key.Length) + kv.Value;
                    }

                    if (number > 19 && newPart == oldPart && oldPart.Length > 1)
                        newPart = "ال" + oldPart;

                    newParts[count++] = newPart;
                }

                word = string.Join(" ", newParts);
            }
            else
                word = "ال" + word;

            return word;
        }
    }
}