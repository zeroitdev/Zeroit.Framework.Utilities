// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="CombineWith.cs" company="Zeroit Dev Technologies">
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

        //string firstName = "John";
        //string lastName = "Doe";
        //string fullName = firstName.CombineWith(lastName);

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Combine two (optionally empty) strings the way you expect.
        /// </summary>
        /// <param name="input">First string to combine</param>
        /// <param name="suffix">Second string to append to <paramref name="input" /></param>
        /// <param name="separator">The separator to insert between <paramref name="input" /> and <paramref name="suffix" /> (default=a single space)</param>
        /// <returns><c>"{input}{separator}{suffix}"</c> when both are not null/empty,
        /// <c>"{input}"</c> when <paramref name="suffix" /> is null/empty,
        /// <c>"{suffix}"</c> when <paramref name="input" /> is null/empty, or
        /// <c>string.Empty</c> when both are null/empty</returns>
        public static string CombineWith(this string input, string suffix, string separator = " ")
        {
            if (string.IsNullOrEmpty(input))
            {
                if (string.IsNullOrEmpty(suffix))
                {
                    return string.Empty;
                }
                else
                {
                    return suffix;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(suffix))
                {
                    return input;
                }
                else
                {
                    return string.Format("{0}{1}{2}", input, separator, suffix);
                }
            }
        }

    }
}
