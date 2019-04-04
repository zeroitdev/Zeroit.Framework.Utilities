// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="DefaultFormatter.cs" company="Zeroit Dev Technologies">
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
using Zeroit.Framework.Utilities.StringProcessing.Humanizer;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.Formatters
{
    /// <summary>
    /// Default implementation of IFormatter interface.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.Formatters.IFormatter" />
    public class DefaultFormatter : IFormatter
    {
        /// <summary>
        /// The culture
        /// </summary>
        private readonly CultureInfo _culture;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="localeCode">Name of the culture to use.</param>
        public DefaultFormatter(string localeCode)
        {
            _culture = new CultureInfo(localeCode);
        }

        /// <summary>
        /// Now
        /// </summary>
        /// <returns>Returns Now</returns>
        public virtual string DateHumanize_Now()
        {
            return GetResourceForDate(TimeUnit.Millisecond, Tense.Past, 0);
        }

        /// <summary>
        /// Never
        /// </summary>
        /// <returns>Returns Never</returns>
        public virtual string DateHumanize_Never()
        {
            return Format(ResourceKeys.DateHumanize.Never);
        }

        /// <summary>
        /// Returns the string representation of the provided DateTime
        /// </summary>
        /// <param name="timeUnit">The time unit.</param>
        /// <param name="timeUnitTense">The time unit tense.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>System.String.</returns>
        public virtual string DateHumanize(TimeUnit timeUnit, Tense timeUnitTense, int unit)
        {
            return GetResourceForDate(timeUnit, timeUnitTense, unit);
        }

        /// <summary>
        /// 0 seconds
        /// </summary>
        /// <returns>Returns 0 seconds as the string representation of Zero TimeSpan</returns>
        public virtual string TimeSpanHumanize_Zero()
        {
            return GetResourceForTimeSpan(TimeUnit.Millisecond, 0);
        }

        /// <summary>
        /// Returns the string representation of the provided TimeSpan
        /// </summary>
        /// <param name="timeUnit">A time unit to represent.</param>
        /// <param name="unit">The unit.</param>
        /// <param name="toWords">if set to <c>true</c> [to words].</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Is thrown when timeUnit is larger than TimeUnit.Week</exception>
        public virtual string TimeSpanHumanize(TimeUnit timeUnit, int unit, bool toWords = false)
        {
            return GetResourceForTimeSpan(timeUnit, unit, toWords);
        }

        /// <summary>
        /// Gets the resource for date.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <param name="timeUnitTense">The time unit tense.</param>
        /// <param name="count">The count.</param>
        /// <returns>System.String.</returns>
        private string GetResourceForDate(TimeUnit unit, Tense timeUnitTense, int count)
        {
            var resourceKey = ResourceKeys.DateHumanize.GetResourceKey(unit, timeUnitTense: timeUnitTense, count: count);
            return count == 1 ? Format(resourceKey) : Format(resourceKey, count);
        }

        /// <summary>
        /// Gets the resource for time span.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <param name="count">The count.</param>
        /// <param name="toWords">if set to <c>true</c> [to words].</param>
        /// <returns>System.String.</returns>
        private string GetResourceForTimeSpan(TimeUnit unit, int count, bool toWords = false)
        {
            var resourceKey = ResourceKeys.TimeSpanHumanize.GetResourceKey(unit, count);
            return count == 1 ? Format(resourceKey + (toWords ? "_Words" : "")) : Format(resourceKey, count, toWords);
        }

        /// <summary>
        /// Formats the specified resource key.
        /// </summary>
        /// <param name="resourceKey">The resource key.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentException">If the resource not exists on the specified culture.</exception>
        protected virtual string Format(string resourceKey)
        {
            var resourceString = Resources.GetResource(GetResourceKey(resourceKey), _culture);

            if (string.IsNullOrEmpty(resourceString))
                throw new ArgumentException($"The resource object with key '{resourceKey}' was not found", nameof(resourceKey));

            return resourceString;
        }

        /// <summary>
        /// Formats the specified resource key.
        /// </summary>
        /// <param name="resourceKey">The resource key.</param>
        /// <param name="number">The number.</param>
        /// <param name="toWords">if set to <c>true</c> [to words].</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentException">If the resource not exists on the specified culture.</exception>
        protected virtual string Format(string resourceKey, int number, bool toWords = false)
        {
            var resourceString = Resources.GetResource(GetResourceKey(resourceKey, number), _culture);

            if (string.IsNullOrEmpty(resourceString))
                throw new ArgumentException($"The resource object with key '{resourceKey}' was not found", nameof(resourceKey));

            return toWords
                ? resourceString.FormatWith(number.ToWords())
                : resourceString.FormatWith(number);
        }

        /// <summary>
        /// Override this method if your locale has complex rules around multiple units; e.g. Arabic, Russian
        /// </summary>
        /// <param name="resourceKey">The resource key that's being in formatting</param>
        /// <param name="number">The number of the units being used in formatting</param>
        /// <returns>System.String.</returns>
        protected virtual string GetResourceKey(string resourceKey, int number)
        {
            return resourceKey;
        }

        /// <summary>
        /// Gets the resource key.
        /// </summary>
        /// <param name="resourceKey">The resource key.</param>
        /// <returns>System.String.</returns>
        protected virtual string GetResourceKey(string resourceKey)
        {
            return resourceKey;
        }
    }
}
