// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="UzbekCyrlNumberToWordConverter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Text;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords
{
    /// <summary>
    /// Class UzbekCyrlNumberToWordConverter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.GenderlessNumberToWordsConverter" />
    internal class UzbekCyrlNumberToWordConverter : GenderlessNumberToWordsConverter
    {
        /// <summary>
        /// The units map
        /// </summary>
        private static readonly string[] UnitsMap = { "нол", "бир", "икки", "уч", "тўрт", "беш", "олти", "етти", "саккиз", "тўққиз" };
        /// <summary>
        /// The tens map
        /// </summary>
        private static readonly string[] TensMap = { "нол", "ўн", "йигирма", "ўттиз", "қирқ", "эллик", "олтмиш", "етмиш", "саксон", "тўқсон" };

        /// <summary>
        /// The ordinal suffixes
        /// </summary>
        private static readonly string[] OrdinalSuffixes = new string[] { "инчи", "нчи" };

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
                return string.Format("минус {0}", Convert(-number, true));
            return Convert(number, true);
        }

        /// <summary>
        /// Converts the specified number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="checkForHoundredRule">if set to <c>true</c> [check for houndred rule].</param>
        /// <returns>System.String.</returns>
        private string Convert(int number, bool checkForHoundredRule)
        {
            if (number == 0)
                return UnitsMap[0];

            if (checkForHoundredRule && number == 100)
                return "юз";

            var sb = new StringBuilder();

            if ((number / 1000000000) > 0)
            {
                sb.AppendFormat("{0} миллиард ", Convert(number / 1000000000, false));
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                sb.AppendFormat("{0} миллион ", Convert(number / 1000000, true));
                number %= 1000000;
            }

            var thousand = (number / 1000);
            if (thousand > 0)
            {
                sb.AppendFormat("{0} минг ", Convert(thousand, true));
                number %= 1000;
            }

            var hundred = (number / 100);
            if (hundred > 0)
            {
                sb.AppendFormat("{0} юз ", Convert(hundred, false));
                number %= 100;
            }

            if ((number / 10) > 0)
            {
                sb.AppendFormat("{0} ", TensMap[number / 10]);
                number %= 10;
            }

            if (number > 0)
            {
                sb.AppendFormat("{0} ", UnitsMap[number]);
            }

            return sb.ToString().Trim();
        }

        /// <summary>
        /// Converts the number to ordinal string
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.String.</returns>
        public override string ConvertToOrdinal(int number)
        {
            var word = Convert(number);
            var i = 0;
            if (string.IsNullOrEmpty(word))
                return string.Empty;

            var lastChar = word[word.Length - 1];
            if (lastChar == 'и' || lastChar == 'а')
                i = 1;

            return string.Format("{0}{1}", word, OrdinalSuffixes[i]);
        }
    }
}
