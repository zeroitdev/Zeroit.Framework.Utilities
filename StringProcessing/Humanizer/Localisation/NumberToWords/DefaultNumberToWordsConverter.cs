// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="DefaultNumberToWordsConverter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Globalization;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords
{
    /// <summary>
    /// Class DefaultNumberToWordsConverter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.GenderlessNumberToWordsConverter" />
    internal class DefaultNumberToWordsConverter : GenderlessNumberToWordsConverter
    {
        /// <summary>
        /// The culture
        /// </summary>
        private readonly CultureInfo _culture;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="culture">Culture to use.</param>
        public DefaultNumberToWordsConverter(CultureInfo culture)
        {
            _culture = culture;
        }

        /// <summary>
        /// 3501.ToWords() -&gt; "three thousand five hundred and one"
        /// </summary>
        /// <param name="number">Number to be turned to words</param>
        /// <returns>System.String.</returns>
        public override string Convert(long number)
        {
            return number.ToString(_culture);
        }

        /// <summary>
        /// 1.ToOrdinalWords() -&gt; "first"
        /// </summary>
        /// <param name="number">Number to be turned to ordinal words</param>
        /// <returns>System.String.</returns>
        public override string ConvertToOrdinal(int number)
        {
            return number.ToString(_culture);
        }
    }
}