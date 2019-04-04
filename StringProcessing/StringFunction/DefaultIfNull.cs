// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DefaultIfNull.cs" company="Zeroit Dev Technologies">
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
        //str.DefaultIfNull("I'm nil") // return "I'm nil"

        //string str1 = "Hello!";
        //str1.DefaultIfNull("I'm nil") // return "Hello!"

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Return default value if string is null.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>System.String.</returns>
        public static string DefaultIfNull(this string str, string defaultValue)
        {
            return str ?? defaultValue;
        }

    }
}
