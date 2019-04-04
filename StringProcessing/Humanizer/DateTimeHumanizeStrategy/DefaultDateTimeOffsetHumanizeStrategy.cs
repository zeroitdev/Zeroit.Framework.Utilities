// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="DefaultDateTimeOffsetHumanizeStrategy.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Globalization;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerDateTimeHumanizeStrategy
{
    /// <summary>
    /// The default 'distance of time' -&gt; words calculator.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerDateTimeHumanizeStrategy.IDateTimeOffsetHumanizeStrategy" />
    public class DefaultDateTimeOffsetHumanizeStrategy : IDateTimeOffsetHumanizeStrategy
    {
        /// <summary>
        /// Calculates the distance of time in words between two provided dates
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="comparisonBase">The comparison base.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>System.String.</returns>
        public string Humanize(DateTimeOffset input, DateTimeOffset comparisonBase, CultureInfo culture)
        {
            return DateTimeHumanizeAlgorithms.DefaultHumanize(input.UtcDateTime, comparisonBase.UtcDateTime, culture);
        }
    }
}