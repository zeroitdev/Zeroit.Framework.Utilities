// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ToEnum.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Diagnostics;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//



        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Parse a string value to the given Enum.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="doConversion">if set to <c>true</c> [do conversion].</param>
        /// <returns>T.</returns>
        public static T ToEnum<T>(this string value, bool doConversion = true)
            where T : struct
        {
            Debug.Assert(!string.IsNullOrEmpty(value));
            return (T)Enum.Parse(typeof(T), value, true);
        }

    }
}
