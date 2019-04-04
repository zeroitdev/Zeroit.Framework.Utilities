// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Reverse.cs" company="Zeroit Dev Technologies">
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

        //string s = "Test";
        //string r = s.Reverse(); // "tseT"

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Reverse a string.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="doConversion">if set to <c>true</c> [do conversion].</param>
        /// <returns>System.String.</returns>
        public static string Reverse(this string input, bool doConversion)
        {
            char[] c = input.ToCharArray();
            Array.Reverse(c);
            return new string(c);
        }

        //---------------------------------Implementation-----------------------------//

        //string number = "123456789".ReverseString(); //987654321

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Reverses the string.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="doConversion">if set to <c>true</c> [do conversion].</param>
        /// <returns>System.String.</returns>
        public static string ReverseString(this string s, bool doConversion)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }


        

    }
}
