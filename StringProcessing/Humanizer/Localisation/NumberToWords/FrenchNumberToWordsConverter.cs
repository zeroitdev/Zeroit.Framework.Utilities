// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="FrenchNumberToWordsConverter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using Zeroit.Framework.Utilities.StringProcessing.Humanizer;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords
{
    /// <summary>
    /// Class FrenchNumberToWordsConverter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.FrenchNumberToWordsConverterBase" />
    class FrenchNumberToWordsConverter : FrenchNumberToWordsConverterBase
    {
        /// <summary>
        /// Collects the parts under a hundred.
        /// </summary>
        /// <param name="parts">The parts.</param>
        /// <param name="number">The number.</param>
        /// <param name="gender">The gender.</param>
        /// <param name="pluralize">if set to <c>true</c> [pluralize].</param>
        protected override void CollectPartsUnderAHundred(ICollection<string> parts, ref int number, GrammaticalGender gender, bool pluralize)
        {
            if (number == 71)
                parts.Add("soixante et onze");
            else if (number == 80)
                parts.Add(pluralize ? "quatre-vingts" : "quatre-vingt");
            else if (number >= 70)
            {
                var @base = number < 80 ? 60 : 80;
                int units = number - @base;
                var tens = @base/10;
                parts.Add($"{GetTens(tens)}-{GetUnits(units, gender)}");
            }
            else
                base.CollectPartsUnderAHundred(parts, ref number, gender, pluralize);
        }

        /// <summary>
        /// Gets the tens.
        /// </summary>
        /// <param name="tens">The tens.</param>
        /// <returns>System.String.</returns>
        protected override string GetTens(int tens)
        {
            if (tens == 8)
                return "quatre-vingt";

            return base.GetTens(tens);
        }
    }
}