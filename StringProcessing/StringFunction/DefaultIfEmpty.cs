// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DefaultIfEmpty.cs" company="Zeroit Dev Technologies">
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

        //string str = null;
        //str.DefaultIfEmpty("I'm nil") // return "I'm nil"

        //string str1 = string.Empty;
        //str1.DefaultIfEmpty("I'm Empty") // return "I'm Empty!"

        //string str1 = "     ";
        //str1.DefaultIfEmpty("I'm WhiteSpaces strnig!", true) // return "I'm WhiteSpaces strnig!"

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Returns default value if string is null or empty or white spaces string .
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="considerWhiteSpaceIsEmpty">if set to <c>true</c> [consider white space is empty].</param>
        /// <returns>System.String.</returns>
        public static string DefaultIfEmpty(this string str, string defaultValue, bool considerWhiteSpaceIsEmpty = false)
        {
            return (considerWhiteSpaceIsEmpty ? string.IsNullOrWhiteSpace(str) : string.IsNullOrEmpty(str)) ? defaultValue : str;
        }

    }
}
