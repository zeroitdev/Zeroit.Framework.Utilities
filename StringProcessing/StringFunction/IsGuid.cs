// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="IsGuid.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Text.RegularExpressions;

namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //string s = Guid.NewGuid().ToString();

        //Assert.IsTrue(s.IsGuid());

        //--------------------Method 2------------------//
        //string testValue = "{CA761232-ED42-11CE-BACD-00AA0057B223}";
        //bool isGuid = testValue.IsGuid();

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Determines whether the specified s is unique identifier.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns><c>true</c> if the specified s is unique identifier; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">s</exception>
        public static bool IsGuid(this string s)
        {
            if (s == null)
                throw new ArgumentNullException("s");

            Regex format = new Regex(
                "^[A-Fa-f0-9]{32}$|" +
                "^({|\\()?[A-Fa-f0-9]{8}-([A-Fa-f0-9]{4}-){3}[A-Fa-f0-9]{12}(}|\\))?$|" +
                "^({)?[0xA-Fa-f0-9]{3,10}(, {0,1}[0xA-Fa-f0-9]{3,6}){2}, {0,1}({)([0xA-Fa-f0-9]{3,4}, {0,1}){7}[0xA-Fa-f0-9]{3,4}(}})$");
            Match match = format.Match(s);

            return match.Success;
        }

        /// <summary>
        /// Validate if a String contains a GUID in groups of 8, 4, 4, 4, and 12 digits with hyphens between the groups.
        /// The entire GUID can optionally be enclosed in matching braces or parentheses.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="doConversion">if set to <c>true</c> [do conversion].</param>
        /// <returns><c>true</c> if the specified do conversion is unique identifier; otherwise, <c>false</c>.</returns>
        public static bool IsGuid(this string value, bool doConversion = true)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            const string pattern = @"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$";
            return Regex.IsMatch(value, pattern);
        }

    }
}
