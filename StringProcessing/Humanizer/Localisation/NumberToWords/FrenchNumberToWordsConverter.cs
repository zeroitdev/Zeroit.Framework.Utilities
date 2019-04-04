// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="FrenchNumberToWordsConverter.cs" company="Zeroit Dev Technologies">
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