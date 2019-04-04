// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="RussianGrammaticalNumberDetector.cs" company="Zeroit Dev Technologies">
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
namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.GrammaticalNumber
{
    /// <summary>
    /// Class RussianGrammaticalNumberDetector.
    /// </summary>
    internal static class RussianGrammaticalNumberDetector
    {
        /// <summary>
        /// Detects the specified number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>RussianGrammaticalNumber.</returns>
        public static RussianGrammaticalNumber Detect(int number)
        {
            var tens = number % 100 / 10;
            if (tens != 1)
            {
                var unity = number % 10;

                if (unity == 1) // 1, 21, 31, 41 ... 91, 101, 121 ...
                    return RussianGrammaticalNumber.Singular;

                if (unity > 1 && unity < 5) // 2, 3, 4, 22, 23, 24 ...
                    return RussianGrammaticalNumber.Paucal;
            }

            return RussianGrammaticalNumber.Plural;
        }
    }
}