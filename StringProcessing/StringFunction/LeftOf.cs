// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="LeftOf.cs" company="Zeroit Dev Technologies">
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
