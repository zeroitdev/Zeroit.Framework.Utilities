// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Slice.cs" company="Zeroit Dev Technologies">
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
using System;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {

        //---------------------------------Implementation-----------------------------//

        //string result = "0123456789".Slice(4, 8); // Returns "45678"
        //string result = result.Slice(2, 3); // Returns "67"

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Extracts a section of the string given a start and end index within the string.
        /// </summary>
        /// <param name="value">The given string</param>
        /// <param name="start">The start index to slice from.</param>
        /// <param name="end">The end index to slice to.</param>
        /// <returns>The section of string sliced.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// start - start cannot be less than zero
        /// or
        /// end
        /// or
        /// start - start may not be greater than end
        /// </exception>
        public static string Slice(this string value, int start, int end)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            int upperBound = value.Length - 1;

            //
            // Check the arguments
            //
            if (start < 0)
            {
                throw new ArgumentOutOfRangeException("start", "start cannot be less than zero");
            }

            if (end > upperBound)
            {
                throw new ArgumentOutOfRangeException("end", string.Format("end cannot be greater than {0}", upperBound));
            }

            if (start > end)
            {
                throw new ArgumentOutOfRangeException("start", "start may not be greater than end");
            }

            return value.Substring(start, (end - start + 1));
        }

    }
}
