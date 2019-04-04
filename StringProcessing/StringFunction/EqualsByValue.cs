// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="EqualsByValue.cs" company="Zeroit Dev Technologies">
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

        //bool areEqual = a.EqualsByValue(b);

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Determines whether two String objects have the same value.
        /// Null and String.Empty are considered equal values.
        /// </summary>
        /// <param name="inString">The in string.</param>
        /// <param name="compared">The compared.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool EqualsByValue(this string inString, string compared)
        {
            if (string.IsNullOrEmpty(inString) && string.IsNullOrEmpty(compared))
                return true;

            // If we get here, then "compared" necessarily contains data and therefore, strings are not equal.
            if (inString == null)
                return false;

            // Turn down to standard equality check.
            return inString.Equals(compared);
        }

    }
}
