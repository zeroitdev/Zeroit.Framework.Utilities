// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="GenderedNumberToWordsConverter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
