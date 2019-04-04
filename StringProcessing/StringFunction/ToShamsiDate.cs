// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ToShamsiDate.cs" company="Zeroit Dev Technologies">
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


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //string strShamsiDate1 = DateTime.Now.ToShamsiDateYMD();
        //string strShamsiDate2 = DateTime.Now.ToShamsiDateDMY();
        //string strShamsiDate3 = DateTime.Now.ToShamsiDateString();

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Convert DateTime to Shamsi Date (YYYY/MM/DD)
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>System.String.</returns>
        public static string ToShamsiDateYMD(this DateTime date)
        {
            System.Globalization.PersianCalendar PC = new System.Globalization.PersianCalendar();
            int intYear = PC.GetYear(date);
            int intMonth = PC.GetMonth(date);
            int intDay = PC.GetDayOfMonth(date);
            return (intYear.ToString() + "/" + intMonth.ToString() + "/" + intDay.ToString());
        }
        /// <summary>
        /// Convert DateTime to Shamsi Date (DD/MM/YYYY)
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>System.String.</returns>
        public static string ToShamsiDateDMY(this DateTime date)
        {
            System.Globalization.PersianCalendar PC = new System.Globalization.PersianCalendar();
            int intYear = PC.GetYear(date);
            int intMonth = PC.GetMonth(date);
            int intDay = PC.GetDayOfMonth(date);
            return (intDay.ToString() + "/" + intMonth.ToString() + "/" + intYear.ToString());
        }
        /// <summary>
        /// Convert DateTime to Shamsi String
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>System.String.</returns>
        public static string ToShamsiDateString(this DateTime date)
        {
            System.Globalization.PersianCalendar PC = new System.Globalization.PersianCalendar();
            int intYear = PC.GetYear(date);
            int intMonth = PC.GetMonth(date);
            int intDayOfMonth = PC.GetDayOfMonth(date);
            DayOfWeek enDayOfWeek = PC.GetDayOfWeek(date);
            string strMonthName, strDayName;
            switch (intMonth)
            {
                case 1:
                    strMonthName = "فروردین";
                    break;
                case 2:
                    strMonthName = "اردیبهشت";
                    break;
                case 3:
                    strMonthName = "خرداد";
                    break;
                case 4:
                    strMonthName = "تیر";
                    break;
                case 5:
                    strMonthName = "مرداد";
                    break;
                case 6:
                    strMonthName = "شهریور";
                    break;
                case 7:
                    strMonthName = "مهر";
                    break;
                case 8:
                    strMonthName = "آبان";
                    break;
                case 9:
                    strMonthName = "آذر";
                    break;
                case 10:
                    strMonthName = "دی";
                    break;
                case 11:
                    strMonthName = "بهمن";
                    break;
                case 12:
                    strMonthName = "اسفند";
                    break;
                default:
                    strMonthName = "";
                    break;
            }

            switch (enDayOfWeek)
            {
                case DayOfWeek.Friday:
                    strDayName = "جمعه";
                    break;
                case DayOfWeek.Monday:
                    strDayName = "دوشنبه";
                    break;
                case DayOfWeek.Saturday:
                    strDayName = "شنبه";
                    break;
                case DayOfWeek.Sunday:
                    strDayName = "یکشنبه";
                    break;
                case DayOfWeek.Thursday:
                    strDayName = "پنجشنبه";
                    break;
                case DayOfWeek.Tuesday:
                    strDayName = "سه شنبه";
                    break;
                case DayOfWeek.Wednesday:
                    strDayName = "چهارشنبه";
                    break;
                default:
                    strDayName = "";
                    break;
            }

            return (string.Format("{0} {1} {2} {3}", strDayName, intDayOfMonth, strMonthName, intYear));
        }

    }
}
