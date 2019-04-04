// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="IPValidation.cs" company="Zeroit Dev Technologies">
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

        ////returns false
        //string s = "192.168.1.256";
        //bool b = s.IsValidIPAddress();
        ////returns true
        //string s = "192.168.1.254";
        //bool b = s.IsValidIPAddress();

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Validates whether a string is a valid IPv4 address.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns><c>true</c> if [is valid ip address] [the specified s]; otherwise, <c>false</c>.</returns>
        public static bool IsValidIPAddress(this string s)
        {
            return Regex.IsMatch(s,
                @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b");
        }

    }
}
