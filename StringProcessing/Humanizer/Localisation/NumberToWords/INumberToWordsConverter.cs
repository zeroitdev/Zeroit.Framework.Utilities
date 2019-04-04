// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="INumberToWordsConverter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Zeroit.Framework.Utilities.StringProcessing.Humanizer;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords
{
    /// <summary>
    /// An interface you should implement to localise ToWords and ToOrdinalWords methods
    /// </summary>
    public interface INumberToWordsConverter
    {
        /// <summary>
        /// Converts the number to string using the locale's default grammatical gender
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.String.</returns>
        string Convert(long number);

        /// <summary>
        /// Converts the number to string using the provided grammatical gender
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>System.String.</returns>
        string Convert(long number, GrammaticalGender gender);

        /// <summary>
        /// Converts the number to ordinal string using the locale's default grammatical gender
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.String.</returns>
        string ConvertToOrdinal(int number);

        /// <summary>
        /// Converts the number to ordinal string using the provided grammatical gender
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>System.String.</returns>
        string ConvertToOrdinal(int number, GrammaticalGender gender);
    }
}
