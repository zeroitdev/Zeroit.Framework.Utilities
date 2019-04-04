// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Right.cs" company="Zeroit Dev Technologies">
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

        //string s = "abcde";

        //s = s.Right(3);   //s becomes "cde"

        //---------------------------------Implementation-----------------------------//


        /// <summary>
        /// Returns the last few characters of the string with a length
        /// specified by the given parameter. If the string's length is less than the
        /// given length the complete string is returned. If length is zero or
        /// less an empty string is returned
        /// </summary>
        /// <param name="s">the string to process</param>
        /// <param name="length">Number of characters to return</param>
        /// <param name="doConversion">if set to <c>true</c> [do conversion].</param>
        /// <returns>System.String.</returns>
        public static string Right(this string s, int length, bool doConversion = true)
        {
            length = Math.Max(length, 0);

            if (s.Length > length)
            {
                return s.Substring(s.Length - length, length);
            }
            else
            {
                return s;
            }
        }


        //---------------------------------Implementation-----------------------------//

        ///// <summary>
        /////A test for RightOf
        /////</summary>
        //[TestMethod()]
        //public void RightOfTest()
        //{
        //    string s = "XYZ,1234";
        //    char c = ',';
        //    string expected = "1234";
        //    string actual;
        //    actual = StringExtensions.RightOf(s, c);
        //    Assert.AreEqual(expected, actual);

        //    s = "XYZ,1234,ABC";
        //    c = ',';
        //    expected = "1234,ABC";
        //    actual = StringExtensions.RightOf(s, c);
        //    Assert.AreEqual(expected, actual);

        //    s = "XYZ";
        //    c = ',';
        //    expected = "XYZ";
        //    actual = StringExtensions.RightOf(s, c);
        //    Assert.AreEqual(expected, actual);

        //}

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Return the remainder of a string s after a separator c.
        /// </summary>
        /// <param name="s">String to search in.</param>
        /// <param name="c">Separator</param>
        /// <returns>The right part of the string after the character c, or the string itself when c isn't found.</returns>
        public static string RightOf(this string s, char c)
        {
            int ndx = s.IndexOf(c);
            if (ndx == -1)
                return s;
            return s.Substring(ndx + 1);
        }

    }
}
