// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ToSafeParseToDate.cs" company="Zeroit Dev Technologies">
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
namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //e.g 1: with default format

        //string StartSearchDate = "30112015"; //30th Nov 2015 

        //var startSearchDate = StartSearchDate.ToSafeParseExact();


        //e.g 2: with explicitly passing date format

        //string StartSearchDate = "11302015"; //30th Nov 2015 
        //var startSearchDate = StartSearchDate.ToSafeParseExact(), "MM/dd/yyyy");

        //---------------------------------Implementation-----------------------------//

        ///// <summary>
        ///// Parse Exact with using your date format 
        ///// </summary>
        ///// <param name="date">string</param>
        ///// <param name="dateFormat">"dd/MM/yyyy" Or "dd/MM/yy" etc.</param>
        ///// <returns>DateTime</returns>
        //public static DateTime ToSafeParseExact(this string date, string dateFormat = "dd/MM/yyyy")
        //{
        //    date = date.ToNonNullString();
        //    return string.IsNullOrWhiteSpace(date) ? default(DateTime) : DateTime.ParseExact(date, dateFormat, CultureInfo.InvariantCulture);
        //}

    }
}
