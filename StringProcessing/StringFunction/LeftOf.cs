// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="LeftOf.cs" company="Zeroit Dev Technologies">
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

        ///// <summary>
        /////A test for LeftOf
        /////</summary>
        //[TestMethod()]
        //public void LeftOfTest()
        //{
        //    string s = "7011(7011)";
        //    char c = '(';
        //    string expected = "7011";
        //    string actual;
        //    actual = StringExtensions.LeftOf(s, c);
        //    Assert.AreEqual(expected, actual);
        //    actual = StringExtensions.LeftOf(actual, c);    // actual is now 7011
        //    Assert.AreEqual(expected, actual);
        //}

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Returns the first part of the strings, up until the character c. If c is not found in the
        /// string the whole string is returned.
        /// </summary>
        /// <param name="s">String to truncate</param>
        /// <param name="c">Character to stop at.</param>
        /// <returns>Truncated string</returns>
        public static string LeftOf(this string s, char c)
        {
            int ndx = s.IndexOf(c);
            if (ndx >= 0)
            {
                return s.Substring(0, ndx);
            }

            return s;
        }

    }
}
