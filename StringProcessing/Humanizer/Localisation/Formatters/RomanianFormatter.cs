// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="RomanianFormatter.cs" company="Zeroit Dev Technologies">
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
