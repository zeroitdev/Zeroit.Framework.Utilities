// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ReversedDateTime.cs" company="Zeroit Dev Technologies">
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

        //string reversed = DateTime.Now.ToReversedDateTime();

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Takes a DateTime object and reverses it to an SQL type string (yyyy-mm-dd hh:MM:ss).
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string ToReversedDateTime(this DateTime value)
        {
            return string.Format("{0:u}", value);
        }

    }
}
