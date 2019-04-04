// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 12-31-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-31-2018
// ***********************************************************************
// <copyright file="Date.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities
{

    /// <summary>
    /// Class Dates.
    /// </summary>
    public static class Dates
    {

        /// <summary>
        /// Common DateTime Methods.
        /// </summary>

        public enum Quarter
        {
            /// <summary>
            /// The first
            /// </summary>
            First = 1,
            /// <summary>
            /// The second
            /// </summary>
            Second = 2,
            /// <summary>
            /// The third
            /// </summary>
            Third = 3,
            /// <summary>
            /// The fourth
            /// </summary>
            Fourth = 4
        }

        /// <summary>
        /// Enum Month
        /// </summary>
        public enum Month
        {
            /// <summary>
            /// The january
            /// </summary>
            January = 1,
            /// <summary>
            /// The february
            /// </summary>
            February = 2,
            /// <summary>
            /// The march
            /// </summary>
            March = 3,
            /// <summary>
            /// The april
            /// </summary>
            April = 4,
            /// <summary>
            /// The may
            /// </summary>
            May = 5,
            /// <summary>
            /// The june
            /// </summary>
            June = 6,
            /// <summary>
            /// The july
            /// </summary>
            July = 7,
            /// <summary>
            /// The august
            /// </summary>
            August = 8,
            /// <summary>
            /// The september
            /// </summary>
            September = 9,
            /// <summary>
            /// The october
            /// </summary>
            October = 10,
            /// <summary>
            /// The november
            /// </summary>
            November = 11,
            /// <summary>
            /// The december
            /// </summary>
            December = 12
        }

        #region Quarters

        /// <summary>
        /// Gets the start of quarter.
        /// </summary>
        /// <param name="Year">The year.</param>
        /// <param name="Qtr">The QTR.</param>
        /// <returns>DateTime.</returns>
        public static DateTime GetStartOfQuarter(int Year, Quarter Qtr)
        {
            if (Qtr == Quarter.First)    // 1st Quarter = January 1 to March 31
                return new DateTime(Year, 1, 1, 0, 0, 0, 0);
            else if (Qtr == Quarter.Second) // 2nd Quarter = April 1 to June 30
                return new DateTime(Year, 4, 1, 0, 0, 0, 0);
            else if (Qtr == Quarter.Third) // 3rd Quarter = July 1 to September 30
                return new DateTime(Year, 7, 1, 0, 0, 0, 0);
            else // 4th Quarter = October 1 to December 31
                return new DateTime(Year, 10, 1, 0, 0, 0, 0);
        }

        /// <summary>
        /// Gets the end of quarter.
        /// </summary>
        /// <param name="Year">The year.</param>
        /// <param name="Qtr">The QTR.</param>
        /// <returns>DateTime.</returns>
        public static DateTime GetEndOfQuarter(int Year, Quarter Qtr)
        {
            if (Qtr == Quarter.First)    // 1st Quarter = January 1 to March 31
                return new DateTime(Year, 3,
                       DateTime.DaysInMonth(Year, 3), 23, 59, 59, 999);
            else if (Qtr == Quarter.Second) // 2nd Quarter = April 1 to June 30
                return new DateTime(Year, 6,
                       DateTime.DaysInMonth(Year, 6), 23, 59, 59, 999);
            else if (Qtr == Quarter.Third) // 3rd Quarter = July 1 to September 30
                return new DateTime(Year, 9,
                       DateTime.DaysInMonth(Year, 9), 23, 59, 59, 999);
            else // 4th Quarter = October 1 to December 31
                return new DateTime(Year, 12,
                       DateTime.DaysInMonth(Year, 12), 23, 59, 59, 999);
        }

        /// <summary>
        /// Gets the quarter.
        /// </summary>
        /// <param name="Month">The month.</param>
        /// <returns>Quarter.</returns>
        public static Quarter GetQuarter(Month Month)
        {
            if (Month <= Month.March)
                // 1st Quarter = January 1 to March 31
                return Quarter.First;
            else if ((Month >= Month.April) && (Month <= Month.June))
                // 2nd Quarter = April 1 to June 30
                return Quarter.Second;
            else if ((Month >= Month.July) && (Month <= Month.September))
                // 3rd Quarter = July 1 to September 30
                return Quarter.Third;
            else // 4th Quarter = October 1 to December 31
                return Quarter.Fourth;
        }

        /// <summary>
        /// Gets the end of last quarter.
        /// </summary>
        /// <returns>DateTime.</returns>
        public static DateTime GetEndOfLastQuarter()
        {
            if ((Month)DateTime.Now.Month <= Month.March)
                //go to last quarter of previous year
                return GetEndOfQuarter(DateTime.Now.Year - 1, Quarter.Fourth);
            else //return last quarter of current year
                return GetEndOfQuarter(DateTime.Now.Year,
                  GetQuarter((Month)DateTime.Now.Month));
        }

        /// <summary>
        /// Gets the start of last quarter.
        /// </summary>
        /// <returns>DateTime.</returns>
        public static DateTime GetStartOfLastQuarter()
        {
            if ((Month)DateTime.Now.Month <= Month.March)
                //go to last quarter of previous year
                return GetStartOfQuarter(DateTime.Now.Year - 1, Quarter.Fourth);
            else //return last quarter of current year
                return GetStartOfQuarter(DateTime.Now.Year,
                  GetQuarter((Month)DateTime.Now.Month));
        }

        /// <summary>
        /// Gets the start of current quarter.
        /// </summary>
        /// <returns>DateTime.</returns>
        public static DateTime GetStartOfCurrentQuarter()
        {
            return GetStartOfQuarter(DateTime.Now.Year,
                   GetQuarter((Month)DateTime.Now.Month));
        }

        /// <summary>
        /// Gets the end of current quarter.
        /// </summary>
        /// <returns>DateTime.</returns>
        public static DateTime GetEndOfCurrentQuarter()
        {
            return GetEndOfQuarter(DateTime.Now.Year,
                   GetQuarter((Month)DateTime.Now.Month));
        }
        #endregion

        #region Weeks
        /// <summary>
        /// Gets the start of last week.
        /// </summary>
        /// <returns>DateTime.</returns>
        public static DateTime GetStartOfLastWeek()
        {
            int DaysToSubtract = (int)DateTime.Now.DayOfWeek + 7;
            DateTime dt =
              DateTime.Now.Subtract(System.TimeSpan.FromDays(DaysToSubtract));
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
        }

        /// <summary>
        /// Gets the end of last week.
        /// </summary>
        /// <returns>DateTime.</returns>
        public static DateTime GetEndOfLastWeek()
        {
            DateTime dt = GetStartOfLastWeek().AddDays(6);
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
        }

        /// <summary>
        /// Gets the start of current week.
        /// </summary>
        /// <returns>DateTime.</returns>
        public static DateTime GetStartOfCurrentWeek()
        {
            int DaysToSubtract = (int)DateTime.Now.DayOfWeek;
            DateTime dt =
              DateTime.Now.Subtract(System.TimeSpan.FromDays(DaysToSubtract));
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
        }

        /// <summary>
        /// Gets the end of current week.
        /// </summary>
        /// <returns>DateTime.</returns>
        public static DateTime GetEndOfCurrentWeek()
        {
            DateTime dt = GetStartOfCurrentWeek().AddDays(6);
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
        }
        #endregion

        #region Months

        /// <summary>
        /// Gets the start of month.
        /// </summary>
        /// <param name="Month">The month.</param>
        /// <param name="Year">The year.</param>
        /// <returns>DateTime.</returns>
        public static DateTime GetStartOfMonth(Month Month, int Year)
        {
            return new DateTime(Year, (int)Month, 1, 0, 0, 0, 0);
        }

        /// <summary>
        /// Gets the end of month.
        /// </summary>
        /// <param name="Month">The month.</param>
        /// <param name="Year">The year.</param>
        /// <returns>DateTime.</returns>
        public static DateTime GetEndOfMonth(Month Month, int Year)
        {
            return new DateTime(Year, (int)Month,
               DateTime.DaysInMonth(Year, (int)Month), 23, 59, 59, 999);
        }

        /// <summary>
        /// Gets the start of last month.
        /// </summary>
        /// <returns>DateTime.</returns>
        public static DateTime GetStartOfLastMonth()
        {
            if (DateTime.Now.Month == 1)
                return GetStartOfMonth((Month)12, DateTime.Now.Year - 1);
            else
                return GetStartOfMonth((Month)(DateTime.Now.Month - 1), DateTime.Now.Year);
        }

        /// <summary>
        /// Gets the end of last month.
        /// </summary>
        /// <returns>DateTime.</returns>
        public static DateTime GetEndOfLastMonth()
        {
            if (DateTime.Now.Month == 1)
                return GetEndOfMonth((Month)12, DateTime.Now.Year - 1);
            else
                return GetEndOfMonth((Month)(DateTime.Now.Month - 1), DateTime.Now.Year);
        }

        /// <summary>
        /// Gets the start of current month.
        /// </summary>
        /// <returns>DateTime.</returns>
        public static DateTime GetStartOfCurrentMonth()
        {
            return GetStartOfMonth((Month)(DateTime.Now.Month), DateTime.Now.Year);
        }

        /// <summary>
        /// Gets the end of current month.
        /// </summary>
        /// <returns>DateTime.</returns>
        public static DateTime GetEndOfCurrentMonth()
        {
            return GetEndOfMonth((Month)(DateTime.Now.Month), DateTime.Now.Year);
        }
        #endregion

        #region Years
        /// <summary>
        /// Gets the start of year.
        /// </summary>
        /// <param name="Year">The year.</param>
        /// <returns>DateTime.</returns>
        public static DateTime GetStartOfYear(int Year)
        {
            return new DateTime(Year, 1, 1, 0, 0, 0, 0);
        }

        /// <summary>
        /// Gets the end of year.
        /// </summary>
        /// <param name="Year">The year.</param>
        /// <returns>DateTime.</returns>
        public static DateTime GetEndOfYear(int Year)
        {
            return new DateTime(Year, 12,
              DateTime.DaysInMonth(Year, 12), 23, 59, 59, 999);
        }

        /// <summary>
        /// Gets the start of last year.
        /// </summary>
        /// <returns>DateTime.</returns>
        public static DateTime GetStartOfLastYear()
        {
            return GetStartOfYear(DateTime.Now.Year - 1);
        }

        /// <summary>
        /// Gets the end of last year.
        /// </summary>
        /// <returns>DateTime.</returns>
        public static DateTime GetEndOfLastYear()
        {
            return GetEndOfYear(DateTime.Now.Year - 1);
        }

        /// <summary>
        /// Gets the start of current year.
        /// </summary>
        /// <returns>DateTime.</returns>
        public static DateTime GetStartOfCurrentYear()
        {
            return GetStartOfYear(DateTime.Now.Year);
        }

        /// <summary>
        /// Gets the end of current year.
        /// </summary>
        /// <returns>DateTime.</returns>
        public static DateTime GetEndOfCurrentYear()
        {
            return GetEndOfYear(DateTime.Now.Year);
        }
        #endregion

        #region Days
        /// <summary>
        /// Gets the start of day.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>DateTime.</returns>
        public static DateTime GetStartOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        }

        /// <summary>
        /// Gets the end of day.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>DateTime.</returns>
        public static DateTime GetEndOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month,
                                 date.Day, 23, 59, 59, 999);
        }
        #endregion
    }

}
