// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="GenderlessNumberToWordsConverter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Zeroit.Framework.Utilities.StringProcessing.Humanizer;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords
{
    /// <summary>
    /// Class GenderlessNumberToWordsConverter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.INumberToWordsConverter" />
    abstract class GenderlessNumberToWordsConverter : INumberToWordsConverter
    {
        /// <summary>
        /// Converts the number to string
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.String.</returns>
        public abstract string Convert(long number);

        /// <summary>
        /// Converts the number to string ignoring the provided grammatical gender
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>System.String.</returns>
        public string Convert(long number, GrammaticalGender gender)
        {
            return Convert(number);
        }

        /// <summary>
        /// Converts the number to ordinal string
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.String.</returns>
        public abstract string ConvertToOrdinal(int number);

        /// <summary>
        /// Converts the number to ordinal string ignoring  the provided grammatical gender
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>System.String.</returns>
        public string ConvertToOrdinal(int number, GrammaticalGender gender)
        {
            return ConvertToOrdinal(number);
        }
    }
}
