// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="IDateTimeHumanizeStrategy.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Globalization;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerDateTimeHumanizeStrategy
{
    /// <summary>
    /// Implement this interface to create a new strategy for DateTime.Humanize and hook it in the Configurator.DateTimeHumanizeStrategy
    /// </summary>
    public interface IDateTimeHumanizeStrategy
    {
        /// <summary>
        /// Calculates the distance of time in words between two provided dates used for DateTime.Humanize
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="comparisonBase">The comparison base.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>System.String.</returns>
        string Humanize(DateTime input, DateTime comparisonBase, CultureInfo culture);
    }
}