// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="StringToTimeSpan.cs" company="Zeroit Dev Technologies">
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

        //string s = "22:03:34";

        //// Returns a TimeSpan object with 22 Hours, 3 Minutes and 34 Seconds
        //TimeSpan ts = s.StringToTimeSpan();

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Converts a string time to a timespan.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <returns>A timespan object.</returns>
        public static TimeSpan StringToTimeSpan(this string time)
        {
            TimeSpan timespan;
            var result = TimeSpan.TryParse(time, out timespan);
            return result ? timespan : new TimeSpan(0, 0, 0);
        }

    }
}
