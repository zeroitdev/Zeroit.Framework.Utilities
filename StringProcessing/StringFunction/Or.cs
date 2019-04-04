// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Or.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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

        //string someResult = someString1.Or(someString2).Or("foo");

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Returns the first string with a non-empty non-null value.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="alternative">The alternative.</param>
        /// <returns>System.String.</returns>
        public static string Or(this string input, string alternative)
        {
            return (string.IsNullOrEmpty(input) == false) ? input : alternative;
        }

    }
}
