// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="IsNotNullOrEmpty.cs" company="Zeroit Dev Technologies">
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

        //string a = "demo";
        //string b = string.Empty;
        //string c = null;

        //Console.WriteLine(a.IsNotNullOrEmpty()); // true
        //Console.WriteLine(b.IsNotNullOrEmpty()); // false
        //Console.WriteLine(c.IsNotNullOrEmpty()); // false

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Determines whether [is not null or empty] [the specified input].
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns><c>true</c> if [is not null or empty] [the specified input]; otherwise, <c>false</c>.</returns>
        public static bool IsNotNullOrEmpty(this string input)
        {
            return !String.IsNullOrEmpty(input);
        }

        
    }
}
