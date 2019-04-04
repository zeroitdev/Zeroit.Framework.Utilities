// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="DateTimeHumanizeAlgorithms.cs" company="Zeroit Dev Technologies">
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
using Zeroit.Framework.Utilities.StringProcessing.HumanizerConfiguration;
using Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerDateTimeHumanizeStrategy
{
    /// <summary>
    /// Algorithms used to convert distance between two dates into words.
    /// </summary>
    internal static class DateTimeHumanizeAlgorithms
    {
        /// <summary>
        /// Returns localized &amp; humanized distance of time between two dates; given a specific precision.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="comparisonBase">The comparison base.</param>
        /// <param name="precision">The precision.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>System.String.</returns>
        public static string PrecisionHumanize(DateTime input, DateTime comparisonBase, double precision, CultureInfo culture)
        {
            var ts = new TimeSpan(Math.Abs(comparisonBase.Ticks - input.Ticks));
            var tense = input > comparisonBase ? Tense.Future : Tense.Past;

            int seconds = ts.Seconds, minutes = ts.Minutes, hours = ts.Hours, days = ts.Days;
            int years = 0, months = 0;

            // start approximate from smaller units towards bigger ones
            if (ts.Milliseconds >= 999 * precision) seconds += 1;
            if (seconds >= 59 * precision) minutes += 1;
            if (minutes >= 59 * precision) hours += 1;
            if (hours >= 23 * precision) days += 1;

            // month calculation 
            if (days >= 30 * precision & days <= 31) months = 1;
            if (days > 31 && days < 365 * precision)
            {
                var factor = Convert.ToInt32(Math.Floor((double)days / 30));
                var maxMonths = Convert.ToInt32(Math.Ceiling((double)days / 30));
                months = (days >= 30 * (factor + precision)) ? maxMonths : maxMonths - 1;
            }

            // year calculation
            if (days >= 365 * precision && days <= 366) years = 1;
            if (days > 365)
            {
                var factor = Convert.ToInt32(Math.Floor((double)days / 365));
                var maxMonths = Convert.ToInt32(Math.Ceiling((double)days / 365));
                years = (days >= 365 * (factor + precision)) ? maxMonths : maxMonths - 1;
            }

            // start computing result from larger units to smaller ones
            var formatter = Configurator.GetFormatter(culture);
            if (years > 0) return formatter.DateHumanize(TimeUnit.Year, tense, years);
            if (months > 0) return formatter.DateHumanize(TimeUnit.Month, tense, months);
            if (days > 0) return formatter.DateHumanize(TimeUnit.Day, tense, days);
            if (hours > 0) return formatter.DateHumanize(TimeUnit.Hour, tense, hours);
            if (minutes > 0) return formatter.DateHumanize(TimeUnit.Minute, tense, minutes);
            if (seconds > 0) return formatter.DateHumanize(TimeUnit.Second, tense, seconds);
            return formatter.DateHumanize(TimeUnit.Millisecond, tense, 0);
        }

        // http://stackoverflow.com/questions/11/how-do-i-calculate-relative-time
        /// <summary>
        /// Calculates the distance of time in words between two provided dates
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="comparisonBase">The comparison base.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>System.String.</returns>
        public static string DefaultHumanize(DateTime input, DateTime comparisonBase, CultureInfo culture)
        {
            var tense = input > comparisonBase ? Tense.Future : Tense.Past;
            var ts = new TimeSpan(Math.Abs(comparisonBase.Ticks - input.Ticks));

            var formatter = Configurator.GetFormatter(culture);

            if (ts.TotalMilliseconds < 500)
                return formatter.DateHumanize(TimeUnit.Millisecond, tense, 0);

            if (ts.TotalSeconds < 60)
                return formatter.DateHumanize(TimeUnit.Second, tense, ts.Seconds);

            if (ts.TotalSeconds < 120)
                return formatter.DateHumanize(TimeUnit.Minute, tense, 1);

            if (ts.TotalMinutes < 60)
                return formatter.DateHumanize(TimeUnit.Minute, tense, ts.Minutes);

            if (ts.TotalMinutes < 90)
                return formatter.DateHumanize(TimeUnit.Hour, tense, 1);

            if (ts.TotalHours < 24)
                return formatter.DateHumanize(TimeUnit.Hour, tense, ts.Hours);

            if (ts.TotalHours < 48)
            {
                var days = Math.Abs((input.Date - comparisonBase.Date).Days);
                return formatter.DateHumanize(TimeUnit.Day, tense, days);
            }

            if (ts.TotalDays < 28)
                return formatter.DateHumanize(TimeUnit.Day, tense, ts.Days);

            if (ts.TotalDays >= 28 && ts.TotalDays < 30)
            {
                if (comparisonBase.Date.AddMonths(tense == Tense.Future ? 1 : -1) == input.Date)
                    return formatter.DateHumanize(TimeUnit.Month, tense, 1);
                return formatter.DateHumanize(TimeUnit.Day, tense, ts.Days);
            }

            if (ts.TotalDays < 345)
            {
                var months = Convert.ToInt32(Math.Floor(ts.TotalDays / 29.5));
                return formatter.DateHumanize(TimeUnit.Month, tense, months);
            }

            var years = Convert.ToInt32(Math.Floor(ts.TotalDays / 365));
            if (years == 0) years = 1;

            return formatter.DateHumanize(TimeUnit.Year, tense, years);
        }
    }
}