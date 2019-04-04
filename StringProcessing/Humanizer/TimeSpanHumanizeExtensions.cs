// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="TimeSpanHumanizeExtensions.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Zeroit.Framework.Utilities.StringProcessing.HumanizerConfiguration;
using Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation;
using Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.Formatters;

namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Humanizes TimeSpan into human readable form
    /// </summary>
    public static class TimeSpanHumanizeExtensions
    {
        /// <summary>
        /// The days in a week
        /// </summary>
        private const int _daysInAWeek = 7;
        /// <summary>
        /// The days in a year
        /// </summary>
        private const double _daysInAYear = 365.2425; // see https://en.wikipedia.org/wiki/Gregorian_calendar
        /// <summary>
        /// The days in a month
        /// </summary>
        private const double _daysInAMonth = _daysInAYear / 12;

        /// <summary>
        /// Turns a TimeSpan into a human readable form. E.g. 1 day.
        /// </summary>
        /// <param name="timeSpan">The time span.</param>
        /// <param name="precision">The maximum number of time units to return. Defaulted is 1 which means the largest unit is returned</param>
        /// <param name="culture">Culture to use. If null, current thread's UI culture is used.</param>
        /// <param name="maxUnit">The maximum unit of time to output. The default value is <see cref="TimeUnit.Week" />. The time units <see cref="TimeUnit.Month" /> and <see cref="TimeUnit.Year" /> will give approximations for time spans bigger 30 days by calculating with 365.2425 days a year and 30.4369 days a month.</param>
        /// <param name="minUnit">The minimum unit of time to output.</param>
        /// <param name="collectionSeparator">The separator to use when combining humanized time parts. If null, the default collection formatter for the current culture is used.</param>
        /// <param name="toWords">if set to <c>true</c> [to words].</param>
        /// <returns>System.String.</returns>
        public static string Humanize(this TimeSpan timeSpan, int precision = 1, CultureInfo culture = null, TimeUnit maxUnit = TimeUnit.Week, TimeUnit minUnit = TimeUnit.Millisecond, string collectionSeparator = ", ", bool toWords = false)
        {
            return Humanize(timeSpan, precision, false, culture, maxUnit, minUnit, collectionSeparator, toWords);
        }

        /// <summary>
        /// Turns a TimeSpan into a human readable form. E.g. 1 day.
        /// </summary>
        /// <param name="timeSpan">The time span.</param>
        /// <param name="precision">The maximum number of time units to return.</param>
        /// <param name="countEmptyUnits">Controls whether empty time units should be counted towards maximum number of time units. Leading empty time units never count.</param>
        /// <param name="culture">Culture to use. If null, current thread's UI culture is used.</param>
        /// <param name="maxUnit">The maximum unit of time to output. The default value is <see cref="TimeUnit.Week" />. The time units <see cref="TimeUnit.Month" /> and <see cref="TimeUnit.Year" /> will give approximations for time spans bigger than 30 days by calculating with 365.2425 days a year and 30.4369 days a month.</param>
        /// <param name="minUnit">The minimum unit of time to output.</param>
        /// <param name="collectionSeparator">The separator to use when combining humanized time parts. If null, the default collection formatter for the current culture is used.</param>
        /// <param name="toWords">if set to <c>true</c> [to words].</param>
        /// <returns>System.String.</returns>
        public static string Humanize(this TimeSpan timeSpan, int precision, bool countEmptyUnits, CultureInfo culture = null, TimeUnit maxUnit = TimeUnit.Week, TimeUnit minUnit = TimeUnit.Millisecond, string collectionSeparator = ", ", bool toWords = false)
        {
            var timeParts = CreateTheTimePartsWithUpperAndLowerLimits(timeSpan, culture, maxUnit, minUnit, toWords);
            timeParts = SetPrecisionOfTimeSpan(timeParts, precision, countEmptyUnits);

            return ConcatenateTimeSpanParts(timeParts, culture, collectionSeparator);
        }

        /// <summary>
        /// Creates the time parts with upper and lower limits.
        /// </summary>
        /// <param name="timespan">The timespan.</param>
        /// <param name="culture">The culture.</param>
        /// <param name="maxUnit">The maximum unit.</param>
        /// <param name="minUnit">The minimum unit.</param>
        /// <param name="toWords">if set to <c>true</c> [to words].</param>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        private static IEnumerable<string> CreateTheTimePartsWithUpperAndLowerLimits(TimeSpan timespan, CultureInfo culture, TimeUnit maxUnit, TimeUnit minUnit, bool toWords = false)
        {
            var cultureFormatter = Configurator.GetFormatter(culture);
            var firstValueFound = false;
            var timeUnitsEnumTypes = GetEnumTypesForTimeUnit();
            var timeParts = new List<string>();

            foreach (var timeUnitType in timeUnitsEnumTypes)
            {
                var timepart = GetTimeUnitPart(timeUnitType, timespan, culture, maxUnit, minUnit, cultureFormatter, toWords);

                if (timepart != null || firstValueFound)
                {
                    firstValueFound = true;
                    timeParts.Add(timepart);
                }
            }
            if (IsContainingOnlyNullValue(timeParts))
            {
                var noTimeValueCultureFarmated = cultureFormatter.TimeSpanHumanize_Zero();
                timeParts = CreateTimePartsWithNoTimeValue(noTimeValueCultureFarmated);
            }
            return timeParts;
        }

        /// <summary>
        /// Gets the enum types for time unit.
        /// </summary>
        /// <returns>IEnumerable&lt;TimeUnit&gt;.</returns>
        private static IEnumerable<TimeUnit> GetEnumTypesForTimeUnit()
        {
            var enumTypeEnumerator = (IEnumerable<TimeUnit>)Enum.GetValues(typeof(TimeUnit));
            return enumTypeEnumerator.Reverse();
        }

        /// <summary>
        /// Gets the time unit part.
        /// </summary>
        /// <param name="timeUnitToGet">The time unit to get.</param>
        /// <param name="timespan">The timespan.</param>
        /// <param name="culture">The culture.</param>
        /// <param name="maximumTimeUnit">The maximum time unit.</param>
        /// <param name="minimumTimeUnit">The minimum time unit.</param>
        /// <param name="cultureFormatter">The culture formatter.</param>
        /// <param name="toWords">if set to <c>true</c> [to words].</param>
        /// <returns>System.String.</returns>
        private static string GetTimeUnitPart(TimeUnit timeUnitToGet, TimeSpan timespan, CultureInfo culture, TimeUnit maximumTimeUnit, TimeUnit minimumTimeUnit, IFormatter cultureFormatter, bool toWords = false)
        {
            if (timeUnitToGet <= maximumTimeUnit && timeUnitToGet >= minimumTimeUnit)
            {
                var isTimeUnitToGetTheMaximumTimeUnit = (timeUnitToGet == maximumTimeUnit);
                var numberOfTimeUnits = GetTimeUnitNumericalValue(timeUnitToGet, timespan, isTimeUnitToGetTheMaximumTimeUnit);
                return BuildFormatTimePart(cultureFormatter, timeUnitToGet, numberOfTimeUnits, toWords);
            }
            return null;
        }

        /// <summary>
        /// Gets the time unit numerical value.
        /// </summary>
        /// <param name="timeUnitToGet">The time unit to get.</param>
        /// <param name="timespan">The timespan.</param>
        /// <param name="isTimeUnitToGetTheMaximumTimeUnit">if set to <c>true</c> [is time unit to get the maximum time unit].</param>
        /// <returns>System.Int32.</returns>
        private static int GetTimeUnitNumericalValue(TimeUnit timeUnitToGet, TimeSpan timespan, bool isTimeUnitToGetTheMaximumTimeUnit)
        {
            switch (timeUnitToGet)
            {
                case TimeUnit.Millisecond:
                    return GetNormalCaseTimeAsInteger(timespan.Milliseconds, timespan.TotalMilliseconds, isTimeUnitToGetTheMaximumTimeUnit);
                case TimeUnit.Second:
                    return GetNormalCaseTimeAsInteger(timespan.Seconds, timespan.TotalSeconds, isTimeUnitToGetTheMaximumTimeUnit);
                case TimeUnit.Minute:
                    return GetNormalCaseTimeAsInteger(timespan.Minutes, timespan.TotalMinutes, isTimeUnitToGetTheMaximumTimeUnit);
                case TimeUnit.Hour:
                    return GetNormalCaseTimeAsInteger(timespan.Hours, timespan.TotalHours, isTimeUnitToGetTheMaximumTimeUnit);
                case TimeUnit.Day:
                    return GetSpecialCaseDaysAsInteger(timespan, isTimeUnitToGetTheMaximumTimeUnit);
                case TimeUnit.Week:
                    return GetSpecialCaseWeeksAsInteger(timespan, isTimeUnitToGetTheMaximumTimeUnit);
                case TimeUnit.Month:
                    return GetSpecialCaseMonthAsInteger(timespan, isTimeUnitToGetTheMaximumTimeUnit);
                case TimeUnit.Year:
                    return GetSpecialCaseYearAsInteger(timespan);
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Gets the special case month as integer.
        /// </summary>
        /// <param name="timespan">The timespan.</param>
        /// <param name="isTimeUnitToGetTheMaximumTimeUnit">if set to <c>true</c> [is time unit to get the maximum time unit].</param>
        /// <returns>System.Int32.</returns>
        private static int GetSpecialCaseMonthAsInteger(TimeSpan timespan, bool isTimeUnitToGetTheMaximumTimeUnit)
        {
            if (isTimeUnitToGetTheMaximumTimeUnit)
            {
                return (int)((double)timespan.Days / _daysInAMonth);
            }
            else
            {
                var remainingDays = (double)timespan.Days % _daysInAYear;
                return (int)(remainingDays / _daysInAMonth);
            }
        }

        /// <summary>
        /// Gets the special case year as integer.
        /// </summary>
        /// <param name="timespan">The timespan.</param>
        /// <returns>System.Int32.</returns>
        private static int GetSpecialCaseYearAsInteger(TimeSpan timespan)
        {
            return (int)((double)timespan.Days / _daysInAYear);
        }

        /// <summary>
        /// Gets the special case weeks as integer.
        /// </summary>
        /// <param name="timespan">The timespan.</param>
        /// <param name="isTimeUnitToGetTheMaximumTimeUnit">if set to <c>true</c> [is time unit to get the maximum time unit].</param>
        /// <returns>System.Int32.</returns>
        private static int GetSpecialCaseWeeksAsInteger(TimeSpan timespan, bool isTimeUnitToGetTheMaximumTimeUnit)
        {
            if (isTimeUnitToGetTheMaximumTimeUnit || timespan.Days < _daysInAMonth)
            {
                return timespan.Days / _daysInAWeek;
            }
            return 0;
        }

        /// <summary>
        /// Gets the special case days as integer.
        /// </summary>
        /// <param name="timespan">The timespan.</param>
        /// <param name="isTimeUnitToGetTheMaximumTimeUnit">if set to <c>true</c> [is time unit to get the maximum time unit].</param>
        /// <returns>System.Int32.</returns>
        private static int GetSpecialCaseDaysAsInteger(TimeSpan timespan, bool isTimeUnitToGetTheMaximumTimeUnit)
        {
            if (isTimeUnitToGetTheMaximumTimeUnit)
            {
                return timespan.Days;
            }
            if (timespan.Days < _daysInAMonth)
            {
                var remainingDays = timespan.Days % _daysInAWeek;
                return remainingDays;
            }
            return (int)((double)timespan.Days % _daysInAMonth);
        }

        /// <summary>
        /// Gets the normal case time as integer.
        /// </summary>
        /// <param name="timeNumberOfUnits">The time number of units.</param>
        /// <param name="totalTimeNumberOfUnits">The total time number of units.</param>
        /// <param name="isTimeUnitToGetTheMaximumTimeUnit">if set to <c>true</c> [is time unit to get the maximum time unit].</param>
        /// <returns>System.Int32.</returns>
        private static int GetNormalCaseTimeAsInteger(int timeNumberOfUnits, double totalTimeNumberOfUnits, bool isTimeUnitToGetTheMaximumTimeUnit)
        {
            if (isTimeUnitToGetTheMaximumTimeUnit)
            {
                try
                {
                    return (int)totalTimeNumberOfUnits;
                }
                catch
                {
                    //To be implemented so that TimeSpanHumanize method accepts double type as unit
                    return 0;
                }
            }
            return timeNumberOfUnits;
        }

        /// <summary>
        /// Builds the format time part.
        /// </summary>
        /// <param name="cultureFormatter">The culture formatter.</param>
        /// <param name="timeUnitType">Type of the time unit.</param>
        /// <param name="amountOfTimeUnits">The amount of time units.</param>
        /// <param name="toWords">if set to <c>true</c> [to words].</param>
        /// <returns>System.String.</returns>
        private static string BuildFormatTimePart(IFormatter cultureFormatter, TimeUnit timeUnitType, int amountOfTimeUnits, bool toWords = false)
        {
            // Always use positive units to account for negative timespans
            return amountOfTimeUnits != 0
                ? cultureFormatter.TimeSpanHumanize(timeUnitType, Math.Abs(amountOfTimeUnits), toWords)
                : null;
        }

        /// <summary>
        /// Creates the time parts with no time value.
        /// </summary>
        /// <param name="noTimeValue">The no time value.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        private static List<string> CreateTimePartsWithNoTimeValue(string noTimeValue)
        {
            return new List<string>() { noTimeValue };
        }

        /// <summary>
        /// Determines whether [is containing only null value] [the specified time parts].
        /// </summary>
        /// <param name="timeParts">The time parts.</param>
        /// <returns><c>true</c> if [is containing only null value] [the specified time parts]; otherwise, <c>false</c>.</returns>
        private static bool IsContainingOnlyNullValue(IEnumerable<string> timeParts)
        {
            return (timeParts.Count(x => x != null) == 0);
        }

        /// <summary>
        /// Sets the precision of time span.
        /// </summary>
        /// <param name="timeParts">The time parts.</param>
        /// <param name="precision">The precision.</param>
        /// <param name="countEmptyUnits">if set to <c>true</c> [count empty units].</param>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        private static IEnumerable<string> SetPrecisionOfTimeSpan(IEnumerable<string> timeParts, int precision, bool countEmptyUnits)
        {
            if (!countEmptyUnits)
                timeParts = timeParts.Where(x => x != null);
            timeParts = timeParts.Take(precision);
            if (countEmptyUnits)
                timeParts = timeParts.Where(x => x != null);

            return timeParts;
        }

        /// <summary>
        /// Concatenates the time span parts.
        /// </summary>
        /// <param name="timeSpanParts">The time span parts.</param>
        /// <param name="culture">The culture.</param>
        /// <param name="collectionSeparator">The collection separator.</param>
        /// <returns>System.String.</returns>
        private static string ConcatenateTimeSpanParts(IEnumerable<string> timeSpanParts, CultureInfo culture, string collectionSeparator)
        {
            if (collectionSeparator == null)
            {
                return Configurator.CollectionFormatters.ResolveForCulture(culture).Humanize(timeSpanParts);
            }

            return string.Join(collectionSeparator, timeSpanParts);
        }
    }
}
