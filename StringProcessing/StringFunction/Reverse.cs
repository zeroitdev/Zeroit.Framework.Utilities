// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Reverse.cs" company="Zeroit Dev Technologies">
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

        //string s = "Test";
        //string r = s.Reverse(); // "tseT"

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Reverse a string.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="doConversion">if set to <c>true</c> [do conversion].</param>
        /// <returns>System.String.</returns>
        public static string Reverse(this string input, bool doConversion)
        {
            char[] c = input.ToCharArray();
            Array.Reverse(c);
            return new string(c);
        }

        //---------------------------------Implementation-----------------------------//

        //string number = "123456789".ReverseString(); //987654321

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Reverses the string.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="doConversion">if set to <c>true</c> [do conversion].</param>
        /// <returns>System.String.</returns>
        public static string ReverseString(this string s, bool doConversion)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }


        

    }
}
