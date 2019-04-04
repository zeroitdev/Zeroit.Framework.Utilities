// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="IsUnicode.cs" company="Zeroit Dev Technologies">
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

        //bool isUnicode = "سید مهدی میری".IsUnicode();

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Determines whether the specified value is unicode.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if the specified value is unicode; otherwise, <c>false</c>.</returns>
        public static bool IsUnicode(this string value)
        {
            int asciiBytesCount = System.Text.Encoding.ASCII.GetByteCount(value);
            int unicodBytesCount = System.Text.Encoding.UTF8.GetByteCount(value);

            if (asciiBytesCount != unicodBytesCount)
            {
                return true;
            }
            return false;
        }

    }
}
