// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DoesNotStartWith.cs" company="Zeroit Dev Technologies">
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

        //Assert.IsTrue("Test".DoesNotStartWith('?'));

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// It returns true if string does not start with the character otherwise returns false if you pass null or empty string, false will be returned.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="pattern">The pattern.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool DoesNotStartWith(this string input, string pattern)
        {
            return string.IsNullOrEmpty(pattern) ||
                   input.IsNullOrEmptyOrWhiteSpace() ||
                   !input.StartsWith(pattern, StringComparison.CurrentCulture);
        }

    }
}
