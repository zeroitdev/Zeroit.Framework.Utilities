// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="StringToTimeSpan.cs" company="Zeroit Dev Technologies">
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
