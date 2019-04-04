// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="PrepositionsExtensions.cs" company="Zeroit Dev Technologies">
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
namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// <see cref="DateTime" /> extensions related to spatial or temporal relations
    /// </summary>
    public static class PrepositionsExtensions
    {
        /// <summary>
        /// Returns a new <see cref="DateTime" /> with the specifed hour and, optionally
        /// provided minutes, seconds, and milliseconds.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="hour">The hour.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="second">The second.</param>
        /// <param name="millisecond">The millisecond.</param>
        /// <returns>DateTime.</returns>
        public static DateTime At(this DateTime date, int hour, int min = 0, int second = 0, int millisecond = 0)
        {
            return new DateTime(date.Year, date.Month, date.Day, hour, min, second, millisecond);
        }

        /// <summary>
        /// Returns a new instance of DateTime based on the provided date where the time is set to midnight
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>DateTime.</returns>
        public static DateTime AtMidnight(this DateTime date)
        {
            return date.At(0);
        }

        /// <summary>
        /// Returns a new instance of DateTime based on the provided date where the time is set to noon
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>DateTime.</returns>
        public static DateTime AtNoon(this DateTime date)
        {
            return date.At(12);
        }

        /// <summary>
        /// Returns a new instance of DateTime based on the provided date where the year is set to the provided year
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="year">The year.</param>
        /// <returns>DateTime.</returns>
        public static DateTime In(this DateTime date, int year)
        {
            return new DateTime(year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond);
        }
    }
}
