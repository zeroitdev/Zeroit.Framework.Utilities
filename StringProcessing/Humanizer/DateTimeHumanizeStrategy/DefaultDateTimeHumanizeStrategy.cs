// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="DefaultDateTimeHumanizeStrategy.cs" company="Zeroit Dev Technologies">
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
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerDateTimeHumanizeStrategy.IDateTimeHumanizeStrategy" />
    public class DefaultDateTimeHumanizeStrategy : IDateTimeHumanizeStrategy
    {
        /// <summary>
        /// Calculates the distance of time in words between two provided dates
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="comparisonBase">The comparison base.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>System.String.</returns>
        public string Humanize(DateTime input, DateTime comparisonBase, CultureInfo culture)
        {
            return DateTimeHumanizeAlgorithms.DefaultHumanize(input, comparisonBase, culture);
        }
    }
}