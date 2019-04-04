// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="FrenchBelgianNumberToWordsConverter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using Zeroit.Framework.Utilities.StringProcessing.Humanizer;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords
{
    /// <summary>
    /// Class FrenchBelgianNumberToWordsConverter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.FrenchNumberToWordsConverterBase" />
    internal class FrenchBelgianNumberToWordsConverter : FrenchNumberToWordsConverterBase
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
            if (number == 80)
                parts.Add(pluralize ? "quatre-vingts" : "quatre-vingt");
            else if (number == 81)
                parts.Add(gender == GrammaticalGender.Feminine ? "quatre-vingt-une" : "quatre-vingt-un");
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