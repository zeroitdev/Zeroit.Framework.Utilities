// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="FirstAndLastDayOfMonth.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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

        //DateTime dateToday = DateTime.Now;

        //Console.WriteLine("First Day: {0}", dateToday.FirstDayOfMonth());
        //Console.WriteLine("Last Day: {0}", dateToday.LastDayOfMonth());

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// First the day of month.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>System.String.</returns>
        public static string FirstDayOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1).ToString("MM/dd/yyyy");
        }

        /// <summary>
        /// Last the day of month.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>System.String.</returns>
        public static string LastDayOfMonth(this DateTime date)
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1).AddDays(-1).ToString("MM/dd/yyyy");
        }

    }
}
