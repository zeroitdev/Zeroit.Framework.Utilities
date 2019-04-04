// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="SecondsToString.cs" company="Zeroit Dev Technologies">
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

        //int seconds = 7863;

        //string display = seconds.SecondsToString(); // 2 hours 11 mins

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Converts the seconds to an hour \ min display string.
        /// </summary>
        /// <param name="totalSeconds">The \total seconds.</param>
        /// <returns>A string in the format x hours y mins.</returns>
        public static string SecondsToString(this int totalSeconds)
        {
            var s = TimeSpan.FromSeconds(totalSeconds);

            return string.Format("{0} hours {1} mins", (int)s.TotalHours, s.Minutes);
        }

    }
}
