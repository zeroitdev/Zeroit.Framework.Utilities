// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="TurkishNumberToWordConverter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords
{
    /// <summary>
    /// Class TurkishNumberToWordConverter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.GenderlessNumberToWordsConverter" />
    internal class TurkishNumberToWordConverter : GenderlessNumberToWordsConverter
    {
        /// <summary>
        /// The units map
        /// </summary>
        private static readonly string[] UnitsMap = { "sıfır", "bir", "iki", "üç", "dört", "beş", "altı", "yedi", "sekiz", "dokuz" };
        /// <summary>
        /// The tens map
        /// </summary>
        private static readonly string[] TensMap = { "sıfır", "on", "yirmi", "otuz", "kırk", "elli", "altmış", "yetmiş", "seksen", "doksan" };

        /// <summary>
        /// The ordinal suffix
        /// </summary>
        private static readonly Dictionary<char, string> OrdinalSuffix = new Dictionary<char, string>
        {
            {'ı', "ıncı"},
            {'i', "inci"},
            {'u', "uncu"},
            {'ü', "üncü"},
            {'o', "uncu"},
            {'ö', "üncü"},
            {'e', "inci"},
            {'a', "ıncı"},
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
            if (number == 0)
                return UnitsMap[0];

            if (number < 0)
                return string.Format("eksi {0}", Convert(-number));

            var parts = new List<string>();

            if ((number / 1000000000) > 0)
            {
                parts.Add(string.Format("{0} milyar", Convert(number / 1000000000)));
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                parts.Add(string.Format("{0} milyon", Convert(number / 1000000)));
                number %= 1000000;
            }

            var thousand = (number / 1000);
            if (thousand > 0)
            {
                parts.Add(string.Format("{0} bin", thousand > 1 ? Convert(thousand) : "").Trim());
                number %= 1000;
            }

            var hundred = (number / 100);
            if (hundred > 0)
            {
                parts.Add(string.Format("{0} yüz", hundred > 1 ? Convert(hundred) : "").Trim());
                number %= 100;
            }

            if ((number / 10) > 0)
            {
                parts.Add(TensMap[number / 10]);
                number %= 10;
            }

            if (number > 0)
            {
                parts.Add(UnitsMap[number]);
            }

            var toWords = string.Join(" ", parts.ToArray());

            return toWords;
        }

        /// <summary>
        /// Converts the number to ordinal string
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.String.</returns>
        public override string ConvertToOrdinal(int number)
        {
            var word = Convert(number);
            var wordSuffix = string.Empty;
            var suffixFoundOnLastVowel = false;

            for (var i = word.Length - 1; i >= 0; i--)
            {
                if (OrdinalSuffix.TryGetValue(word[i], out wordSuffix))
                {
                    suffixFoundOnLastVowel = i == word.Length - 1;
                    break;
                }
            }

            if (word[word.Length - 1] == 't')
                word = word.Substring(0, word.Length - 1) + 'd';

            if (suffixFoundOnLastVowel)
                word = word.Substring(0, word.Length - 1);

            return string.Format("{0}{1}", word, wordSuffix);
        }
    }
}
