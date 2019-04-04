// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DoesNotEndWith.cs" company="Zeroit Dev Technologies">
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

        //Assert.IsTrue("Test".DoesNotEndWith('?'));

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// It returns true if string does not end with the character otherwise returns false.
        /// If you pass null or empty string, false will be returned.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="pattern">The pattern.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool DoesNotEndWith(this string input, string pattern)
        {
            return string.IsNullOrEmpty(pattern) ||
                   input.IsNullOrEmptyOrWhiteSpace() ||
                   !input.EndsWith(pattern, StringComparison.CurrentCulture);
        }
    }
}
