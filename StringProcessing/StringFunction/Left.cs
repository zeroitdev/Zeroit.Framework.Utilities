// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Left.cs" company="Zeroit Dev Technologies">
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

        //string s = "abcde";

        //s = s.Left(2);    //s becomes "ab"

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Returns the first few characters of the string with a length
        /// specified by the given parameter. If the string's length is less than the
        /// given length the complete string is returned. If length is zero or
        /// less an empty string is returned
        /// </summary>
        /// <param name="s">the string to process</param>
        /// <param name="length">Number of characters to return</param>
        /// <param name="doConversion">if set to <c>true</c> [do conversion].</param>
        /// <returns>System.String.</returns>
        public static string Left(this string s, int length, bool doConversion = true)
        {
            length = Math.Max(length, 0);

            if (s.Length > length)
            {
                return s.Substring(0, length);
            }
            else
            {
                return s;
            }
        }

    }
}
