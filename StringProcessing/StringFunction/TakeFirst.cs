// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="TakeFirst.cs" company="Zeroit Dev Technologies">
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

        //string someString = "Awesome";
        //string firstThree = "Awesome".TakeFirst(3);
        ////firstThree now is the string "Awe".

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Returns the first X characters from a string.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="num">The number.</param>
        /// <returns>System.String.</returns>
        public static string TakeFirst(this string s, int num)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            return (s.Length < num ? s : s.Substring(0, num));
        }
    }
}
