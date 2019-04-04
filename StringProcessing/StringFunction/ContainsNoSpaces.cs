// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ContainsNoSpaces.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Text.RegularExpressions;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //if (!textBoxUserIdNew.Text.Trim().ContainsNoSpaces())

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Checks if a string contains no spaces.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns><c>true</c> if [contains no spaces] [the specified s]; otherwise, <c>false</c>.</returns>
        public static bool ContainsNoSpaces(this string s)
        {
            var regex = new Regex(@"^[a-zA-Z0-9]+$");
            return regex.IsMatch(s);
        }

    }
}
