// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="ToQuantityExtensions.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Enumerates the ways of displaying a quantity value when converting
    /// a word to a quantity string.
    /// </summary>
    public enum ShowQuantityAs
    {
        /// <summary>
        /// Indicates that no quantity will be included in the formatted string.
        /// </summary>
        None = 0,

        /// <summary>
        /// Indicates that the quantity will be included in the output, formatted
        /// as its numeric value (e.g. "1").
        /// </summary>
        Numeric,

        /// <summary>
        /// Incidates that the quantity will be included in the output, formatted as
        /// words (e.g. 123 =&gt; "one hundred and twenty three").
        /// </summary>
        Words
    }

    /// <summary>
    /// Provides extensions for formatting a <see cref="string" /> word as a quantity.
    /// </summary>
    public static class ToQuantityExtensions
    {
        /// <summary>
        /// Prefixes the provided word with the number and accordingly pluralizes or singularizes the word
        /// </summary>
        /// <param name="input">The word to be prefixed</param>
        /// <param name="quantity">The quantity of the word</param>
        /// <param name="showQuantityAs">How to show the quantity. Numeric by default</param>
        /// <returns>System.String.</returns>
        /// <example>
        /// "request".ToQuantity(0) =&gt; "0 requests"
        /// "request".ToQuantity(1) =&gt; "1 request"
        /// "request".ToQuantity(2) =&gt; "2 requests"
        /// "men".ToQuantity(2) =&gt; "2 men"
        /// "process".ToQuantity(1200, ShowQuantityAs.Words) =&gt; "one thousand two hundred processes"
        /// </example>
        public static string ToQuantity(this string input, int quantity, ShowQuantityAs showQuantityAs = ShowQuantityAs.Numeric)
        {
            return input.ToQuantity(quantity, showQuantityAs, format: null, formatProvider: null);
        }

        /// <summary>
        /// Prefixes the provided word with the number and accordingly pluralizes or singularizes the word
        /// </summary>
        /// <param name="input">The word to be prefixed</param>
        /// <param name="quantity">The quantity of the word</param>
        /// <param name="format">A standard or custom numeric format string.</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
        /// <returns>System.String.</returns>
        /// <example>
        /// "request".ToQuantity(0) =&gt; "0 requests"
        /// "request".ToQuantity(10000, format: "N0") =&gt; "10,000 requests"
        /// "request".ToQuantity(1, format: "N0") =&gt; "1 request"
        /// </example>
        public static string ToQuantity(this string input, int quantity, string format, IFormatProvider formatProvider = null)
        {
            return input.ToQuantity(quantity, showQuantityAs: ShowQuantityAs.Numeric, format: format, formatProvider: formatProvider);
        }

        /// <summary>
        /// Prefixes the provided word with the number and accordingly pluralizes or singularizes the word
        /// </summary>
        /// <param name="input">The word to be prefixed</param>
        /// <param name="quantity">The quantity of the word</param>
        /// <param name="showQuantityAs">How to show the quantity. Numeric by default</param>
        /// <returns>System.String.</returns>
        /// <example>
        /// "request".ToQuantity(0) =&gt; "0 requests"
        /// "request".ToQuantity(1) =&gt; "1 request"
        /// "request".ToQuantity(2) =&gt; "2 requests"
        /// "men".ToQuantity(2) =&gt; "2 men"
        /// "process".ToQuantity(1200, ShowQuantityAs.Words) =&gt; "one thousand two hundred processes"
        /// </example>
        public static string ToQuantity(this string input, long quantity, ShowQuantityAs showQuantityAs = ShowQuantityAs.Numeric)
        {
            return input.ToQuantity(quantity, showQuantityAs, format: null, formatProvider: null);
        }

        /// <summary>
        /// Prefixes the provided word with the number and accordingly pluralizes or singularizes the word
        /// </summary>
        /// <param name="input">The word to be prefixed</param>
        /// <param name="quantity">The quantity of the word</param>
        /// <param name="format">A standard or custom numeric format string.</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
        /// <returns>System.String.</returns>
        /// <example>
        /// "request".ToQuantity(0) =&gt; "0 requests"
        /// "request".ToQuantity(10000, format: "N0") =&gt; "10,000 requests"
        /// "request".ToQuantity(1, format: "N0") =&gt; "1 request"
        /// </example>
        public static string ToQuantity(this string input, long quantity, string format, IFormatProvider formatProvider = null)
        {
            return input.ToQuantity(quantity, showQuantityAs: ShowQuantityAs.Numeric, format: format, formatProvider: formatProvider);
        }

        /// <summary>
        /// To the quantity.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="showQuantityAs">The show quantity as.</param>
        /// <param name="format">The format.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>System.String.</returns>
        private static string ToQuantity(this string input, long quantity, ShowQuantityAs showQuantityAs = ShowQuantityAs.Numeric, string format = null, IFormatProvider formatProvider = null)
        {
            var transformedInput = quantity == 1
                ? input.Singularize(inputIsKnownToBePlural: false)
                : input.Pluralize(inputIsKnownToBeSingular: false);

            if (showQuantityAs == ShowQuantityAs.None)
                return transformedInput;

            if (showQuantityAs == ShowQuantityAs.Numeric)
                return string.Format(formatProvider, "{0} {1}", quantity.ToString(format, formatProvider), transformedInput);

            
            return string.Format("{0} {1}", quantity.ToWords(), transformedInput);
        }
    }
}
