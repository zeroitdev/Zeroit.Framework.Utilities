// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="UcFirst.cs" company="Zeroit Dev Technologies">
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

        //"some string".UcFirst();

        //OR

        //string str = "a string";

        //str.UcFirst();

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Emulation of PHPs ucfirst().
        /// </summary>
        /// <param name="theString">The string.</param>
        /// <returns>System.String.</returns>
        public static string UcFirst(this string theString)
        {
            if (string.IsNullOrEmpty(theString))
            {
                return string.Empty;
            }

            char[] theChars = theString.ToCharArray();
            theChars[0] = char.ToUpper(theChars[0]);

            return new string(theChars);

        }
    }
}
