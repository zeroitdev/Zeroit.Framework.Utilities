// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="IsNullThenEmpty.cs" company="Zeroit Dev Technologies">
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

        //string theUserData = someTextBox.Text.IsNullThenEmpty();

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// If the string is NULL, converts it to string.empty. Helpful when trying to avoid null conditions.
        /// </summary>
        /// <param name="inString">The in string.</param>
        /// <returns>System.String.</returns>
        public static string IsNullThenEmpty(this string inString)
        {
            if (inString == null)
                return string.Empty;
            else
                return inString;
        }

    }
}
