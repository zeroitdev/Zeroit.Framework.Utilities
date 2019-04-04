// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="EqualsByValue.cs" company="Zeroit Dev Technologies">
//    This program contains Utilities for all C# programming activities.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
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
