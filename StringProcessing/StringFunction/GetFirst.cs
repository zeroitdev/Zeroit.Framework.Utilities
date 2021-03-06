﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="GetFirst.cs" company="Zeroit Dev Technologies">
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

        //string number = "123456789".GetFirst(5); //12345

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Get fist n charactor in string.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="tailLength">Length of the tail.</param>
        /// <returns>System.String.</returns>
        public static string GetFirst(this string source, int tailLength)
        {

            if (source == null || tailLength >= source.Length)
                return source;
            return source.Substring(source.Length - tailLength);
        }


        //---------------------------------Implementation-----------------------------//

        //string name = "mehrdad";
        //Response.Write("Name is : " + name);
        //Response.Write("<br />");
        //Response.Write("Frist Char : "+name.FristChar());

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Select Firs character in string.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        public static string FirstChar(this string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                if (input.Length >= 1)
                {
                    return input.Substring(0, 1);
                }
                else
                {
                    return input;
                }
            }
            else
            {
                return null;
            }

        }
    }
}
