// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="DateHumanizeExtensions.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Globalization;
using Zeroit.Framework.Utilities.StringProcessing.HumanizerConfiguration;

namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Humanizes DateTime into human readable sentence
    /// </summary>
    public static class DateHumanizeExtensions
    {
        /// <summary>
        /// Turns the current or provided date into a human readable sentence
        /// </summary>
        /// <param name="input">The date to be humanized</param>
        /// <param name="utcDate">Boolean value indicating whether the date is in UTC or local</param>
        /// <param name="dateToCompareAgainst">Date to compare the input against. If null, current date is used as base</param>
        /// <param name="culture">Culture to use. If null, current thread's UI culture is used.</param>
        /// <returns>distance of time in words</returns>
        public static string Humanize(this DateTime input, bool utcDate = true, DateTime? dateToCompareAgainst = null, CultureInfo culture = null)
        {
            var comparisonBase = dateToCompareAgainst ?? DateTime.UtcNow;

            if (!utcDate)
                comparisonBase = comparisonBase.ToLocalTime();

            return Configurator.DateTimeHumanizeStrategy.Humanize(input, comparisonBase, culture);
        }

        /// <summary>
        /// Turns the current or provided date into a human readable sentence, overload for the nullable DateTime, returning 'never' in case null
        /// </summary>
        /// <param name="input">The date to be humanized</param>
        /// <param name="utcDate">Boolean value indicating whether the date is in UTC or local</param>
        /// <param name="dateToCompareAgainst">Date to compare the input against. If null, current date is used as base</param>
        /// <param name="culture">Culture to use. If null, current thread's UI culture is used.</param>
        /// <returns>distance of time in words</returns>
        public static string Humanize(this DateTime? input, bool utcDate = true, DateTime? dateToCompareAgainst = null, CultureInfo culture = null)
        {
            if (input.HasValue)
                return Humanize(input.Value, utcDate, dateToCompareAgainst, culture);
            else
                return Configurator.GetFormatter(culture).DateHumanize_Never();            
        }

        /// <summary>
        /// Turns the current or provided date into a human readable sentence
        /// </summary>
        /// <param name="input">The date to be humanized</param>
        /// <param name="dateToCompareAgainst">Date to compare the input against. If null, current date is used as base</param>
        /// <param name="culture">Culture to use. If null, current thread's UI culture is used.</param>
        /// <returns>distance of time in words</returns>
        public static string Humanize(this DateTimeOffset input, DateTimeOffset? dateToCompareAgainst = null, CultureInfo culture = null)
        {
            var comparisonBase = dateToCompareAgainst ?? DateTimeOffset.UtcNow;

            return Configurator.DateTimeOffsetHumanizeStrategy.Humanize(input, comparisonBase, culture);
        }

        /// <summary>
        /// Turns the current or provided date into a human readable sentence, overload for the nullable DateTimeOffset, returning 'never' in case null
        /// </summary>
        /// <param name="input">The date to be humanized</param>
        /// <param name="dateToCompareAgainst">Date to compare the input against. If null, current date is used as base</param>
        /// <param name="culture">Culture to use. If null, current thread's UI culture is used.</param>
        /// <returns>distance of time in words</returns>
        public static string Humanize(this DateTimeOffset? input, DateTimeOffset? dateToCompareAgainst = null, CultureInfo culture = null)
        {
            if (input.HasValue)
                return Humanize(input.Value, dateToCompareAgainst, culture);
            else
                return Configurator.GetFormatter(culture).DateHumanize_Never();
        }
    }
}