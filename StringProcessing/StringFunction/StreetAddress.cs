// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="StreetAddress.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Text.RegularExpressions;


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
        /// Validates the street address. eg. "124 street"
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ValidateStreetAddress(this string input)
        {
            return Regex.Match(input, @"^[0-9]+\s+([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$").Success;
        }

    }
}
