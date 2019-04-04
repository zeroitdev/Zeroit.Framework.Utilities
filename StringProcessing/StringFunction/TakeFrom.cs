// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="TakeFrom.cs" company="Zeroit Dev Technologies">
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

        //Console.WriteLine(s.TakeFrom("d"));   // "de"

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Returns the contents of a string starting with the location of the searchFor
        /// </summary>
        /// <param name="s">The string to search.</param>
        /// <param name="searchFor">The string to search for.</param>
        /// <returns>System.String.</returns>
        public static string TakeFrom(this string s, string searchFor)
        {
            if (s.Contains(searchFor))
            {
                int length = Math.Max(s.Length, 0);

                int index = s.IndexOf(searchFor);

                return s.Substring(index, length - index);
            }

            return s;
        }

    }
}
