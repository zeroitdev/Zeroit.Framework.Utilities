// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="RomanianFormatter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Zeroit.Framework.Utilities.StringProcessing.Humanizer;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.Formatters
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Class RomanianFormatter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.Formatters.DefaultFormatter" />
    internal class RomanianFormatter : DefaultFormatter
    {
        /// <summary>
        /// The preposition indicating decimals
        /// </summary>
        private const int PrepositionIndicatingDecimals = 2;
        /// <summary>
        /// The maximum numeral with no preposition
        /// </summary>
        private const int MaxNumeralWithNoPreposition = 19;
        /// <summary>
        /// The minimum numeral with no preposition
        /// </summary>
        private const int MinNumeralWithNoPreposition = 1;
        /// <summary>
        /// The unit preposition
        /// </summary>
        private const string UnitPreposition = " de";
        /// <summary>
        /// The romanian culture code
        /// </summary>
        private const string RomanianCultureCode = "ro";

        /// <summary>
        /// The divider
        /// </summary>
        private static readonly double Divider = Math.Pow(10, PrepositionIndicatingDecimals);

        /// <summary>
        /// The romanian culture
        /// </summary>
        private readonly CultureInfo _romanianCulture;

        /// <summary>
        /// Initializes a new instance of the <see cref="RomanianFormatter"/> class.
        /// </summary>
        public RomanianFormatter()
            : base(RomanianCultureCode)
        {
            _romanianCulture = new CultureInfo(RomanianCultureCode);
        }

        /// <summary>
        /// Formats the specified resource key.
        /// </summary>
        /// <param name="resourceKey">The resource key.</param>
        /// <param name="number">The number.</param>
        /// <param name="toWords">if set to <c>true</c> [to words].</param>
        /// <returns>System.String.</returns>
        protected override string Format(string resourceKey, int number, bool toWords = false)
        {
            var format = Resources.GetResource(GetResourceKey(resourceKey, number), _romanianCulture);
            var preposition = ShouldUsePreposition(number)
                                     ? UnitPreposition
                                     : string.Empty;

            return format.FormatWith(number, preposition);
        }

        /// <summary>
        /// Shoulds the use preposition.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private static bool ShouldUsePreposition(int number)
        {
            var prepositionIndicatingNumeral = Math.Abs(number % Divider);
            return prepositionIndicatingNumeral < MinNumeralWithNoPreposition
                   || prepositionIndicatingNumeral > MaxNumeralWithNoPreposition;
        }
    }
}
