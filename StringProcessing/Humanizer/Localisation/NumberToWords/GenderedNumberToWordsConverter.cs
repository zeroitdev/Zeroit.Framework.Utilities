// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="GenderedNumberToWordsConverter.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords
{
    /// <summary>
    /// Class GenderedNumberToWordsConverter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.INumberToWordsConverter" />
    abstract class GenderedNumberToWordsConverter : INumberToWordsConverter
    {
        /// <summary>
        /// The default gender
        /// </summary>
        private readonly GrammaticalGender _defaultGender;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenderedNumberToWordsConverter"/> class.
        /// </summary>
        /// <param name="defaultGender">The default gender.</param>
        protected GenderedNumberToWordsConverter(GrammaticalGender defaultGender = GrammaticalGender.Masculine)
        {
            _defaultGender = defaultGender;
        }

        /// <summary>
        /// Converts the number to string using the locale's default grammatical gender
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.String.</returns>
        public string Convert(long number)
        {
            return Convert(number, _defaultGender);
        }

        /// <summary>
        /// Converts the number to string using the provided grammatical gender
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>System.String.</returns>
        public abstract string Convert(long number, GrammaticalGender gender);

        /// <summary>
        /// Converts the number to ordinal string using the locale's default grammatical gender
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.String.</returns>
        public string ConvertToOrdinal(int number)
        {
            return ConvertToOrdinal(number, _defaultGender);
        }

        /// <summary>
        /// Converts the number to ordinal string using the provided grammatical gender
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>System.String.</returns>
        public abstract string ConvertToOrdinal(int number, GrammaticalGender gender);
    }
}
