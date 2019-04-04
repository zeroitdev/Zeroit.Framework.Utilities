﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="PortugueseOrdinalizer.cs" company="Zeroit Dev Technologies">
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
using Zeroit.Framework.Utilities.StringProcessing.Humanizer;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.Ordinalizers
{
    /// <summary>
    /// Class PortugueseOrdinalizer.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.Ordinalizers.DefaultOrdinalizer" />
    internal class PortugueseOrdinalizer : DefaultOrdinalizer
    {
        /// <summary>
        /// Ordinalizes the number
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="numberString">The number string.</param>
        /// <returns>System.String.</returns>
        public override string Convert(int number, string numberString)
        {
            return Convert(number, numberString, GrammaticalGender.Masculine);
        }

        /// <summary>
        /// Ordinalizes the number using the provided grammatical gender
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="numberString">The number string.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>System.String.</returns>
        public override string Convert(int number, string numberString, GrammaticalGender gender)
        {
            // N/A in Portuguese
            if (number == 0)
                return "0";

            if (gender == GrammaticalGender.Feminine)
                return numberString + "ª";

            return numberString + "º";
        }
    }
}
