// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Replace.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //String newString = "AbC".Replace("b", "B", StringComparison.OrdinalIgnoreCase);

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Case-insensitive replace method.
        /// </summary>
        /// <param name="originalString">The original string.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        /// <param name="comparisonType">Type of the comparison.</param>
        /// <returns>String.</returns>
        public static String Replace(this String originalString, String oldValue, String newValue, StringComparison comparisonType)
        {
            Int32 startIndex = 0;

            while (true)
            {
                startIndex = originalString.IndexOf(oldValue, startIndex, comparisonType);

                if (startIndex < 0)
                {
                    break;
                }

                originalString = String.Concat(originalString.Substring(0, startIndex), newValue, originalString.Substring(startIndex + oldValue.Length));

                startIndex += newValue.Length;
            }

            return (originalString);
        }

    }
}
