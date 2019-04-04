// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="PrecisionDateTimeOffsetHumanizeStrategy.cs" company="Zeroit Dev Technologies">
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
using System;
using System.Globalization;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerDateTimeHumanizeStrategy
{
    /// <summary>
    /// Precision-based calculator for distance between two times
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerDateTimeHumanizeStrategy.IDateTimeOffsetHumanizeStrategy" />
    public class PrecisionDateTimeOffsetHumanizeStrategy :  IDateTimeOffsetHumanizeStrategy
    {
        /// <summary>
        /// The precision
        /// </summary>
        private readonly double _precision;

        /// <summary>
        /// Constructs a precision-based calculator for distance of time with default precision 0.75.
        /// </summary>
        /// <param name="precision">precision of approximation, if not provided  0.75 will be used as a default precision.</param>
        public PrecisionDateTimeOffsetHumanizeStrategy(double precision = .75)
        {
            _precision = precision;
        }

        /// <summary>
        /// Returns localized &amp; humanized distance of time between two dates; given a specific precision.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="comparisonBase">The comparison base.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>System.String.</returns>
        public string Humanize(DateTimeOffset input, DateTimeOffset comparisonBase, CultureInfo culture)
        {
            return DateTimeHumanizeAlgorithms.PrecisionHumanize(input.UtcDateTime, comparisonBase.UtcDateTime, _precision, culture);
        }
    }
}