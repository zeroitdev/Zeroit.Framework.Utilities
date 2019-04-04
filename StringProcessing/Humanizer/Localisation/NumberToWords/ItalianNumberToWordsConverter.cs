// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="ItalianNumberToWordsConverter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Zeroit.Framework.Utilities.StringProcessing.Humanizer;
using Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.Italian;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords
{
    /// <summary>
    /// Class ItalianNumberToWordsConverter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.GenderedNumberToWordsConverter" />
    internal class ItalianNumberToWordsConverter : GenderedNumberToWordsConverter
    {
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

            if (number < 0)
                return "meno " + Convert(Math.Abs(number), gender);
        
            var cruncher = new ItalianCardinalNumberCruncher(number, gender);
            
            return cruncher.Convert();
        }

        /// <summary>
        /// Converts the number to ordinal string using the provided grammatical gender
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>System.String.</returns>
        public override string ConvertToOrdinal(int number, GrammaticalGender gender)
        {
            var cruncher = new ItalianOrdinalNumberCruncher(number, gender);
            
            return cruncher.Convert();
        }
    }
}