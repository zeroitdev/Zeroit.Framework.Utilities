// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="SplitTo.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //const string str = "1,2,3,4,5,6,7";
        //var col = str.SplitTo<int>(',');

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Returns an enumerable collection of the specified type containing the substrings in this instance that are delimited by elements of a specified Char array
        /// </summary>
        /// <typeparam name="T">The type of the elemnt to return in the collection, this type must implement IConvertible.</typeparam>
        /// <param name="str">The string.</param>
        /// <param name="separator">An array of Unicode characters that delimit the substrings in this instance, an empty array containing no delimiters, or null.</param>
        /// <returns>An enumerable collection whose elements contain the substrings in this instance that are delimited by one or more characters in separator.</returns>
        public static IEnumerable<T> SplitTo<T>(this string str, params char[] separator) where T : IConvertible
        {
            foreach (var s in str.Split(separator, StringSplitOptions.None))
                yield return (T)Convert.ChangeType(s, typeof(T));
        }

    }
}
