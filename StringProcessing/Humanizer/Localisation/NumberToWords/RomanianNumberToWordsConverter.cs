// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="RomanianNumberToWordsConverter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Zeroit.Framework.Utilities.StringProcessing.Humanizer;
using Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.Romanian;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords
{
    /// <summary>
    /// Class RomanianNumberToWordsConverter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.GenderedNumberToWordsConverter" />
    internal class RomanianNumberToWordsConverter : GenderedNumberToWordsConverter
    {
        /// <summary>
        /// Converts the number to string using the provided grammatical gender
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override string Convert(long number, GrammaticalGender gender)
        {
            if (number > Int32.MaxValue || number < Int32.MinValue)
            {
                throw new NotImplementedException();
            }
            var converter = new RomanianCardinalNumberConverter();
            return converter.Convert((int)number, gender);
        }

        /// <summary>
        /// Converts the number to ordinal string using the provided grammatical gender
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>System.String.</returns>
        public override string ConvertToOrdinal(int number, GrammaticalGender gender)
        {
            var converter = new RomanianOrdinalNumberConverter();
            return converter.Convert(number, gender);
        }
    }
}
