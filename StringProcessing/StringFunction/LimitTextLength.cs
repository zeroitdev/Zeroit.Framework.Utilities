// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="LimitTextLength.cs" company="Zeroit Dev Technologies">
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

        //[TestMethod]
        //public void LimitTextLength_null()
        //{
        //    foreach (var n in Enumerable.Range(0, 10))
        //    {
        //        ((string)null).LimitTextLength(n).Should().BeEmpty();
        //    }
        //}

        //[TestMethod]
        //public void LimitTextLength_empty()
        //{
        //    foreach (var n in Enumerable.Range(0, 10))
        //    {
        //        string.Empty.LimitTextLength(n).Should().BeEmpty();
        //    }
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        //public void LimitTextLength_negative_length()
        //{
        //    "test".LimitTextLength(-1);
        //}

        //[TestMethod]
        //public void LimitTextLength_cut_off_yes_ellipsis_default()
        //{
        //    "abcdefg".LimitTextLength(6).Should().Be("abc...");
        //}

        //[TestMethod]
        //public void LimitTextLength_cut_off_yes_ellipsis_no()
        //{
        //    "abcdefg".LimitTextLength(6, false).Should().Be("abcdef");
        //}

        //[TestMethod]
        //public void LimitTextLength_cut_off_yes_ellipsis_yes()
        //{
        //    "abcdefg".LimitTextLength(6, true).Should().Be("abc...");
        //}

        //[TestMethod]
        //public void LimitTextLength_cut_off_edge()
        //{
        //    "abcdefg".LimitTextLength(7).Should().Be("abcdefg");
        //}

        //[TestMethod]
        //public void LimitTextLength_cut_off_no()
        //{
        //    "abcdefg".LimitTextLength(8).Should().Be("abcdefg");
        //}

        //[TestMethod]
        //public void LimitTextLength_almost_ellipsis_length()
        //{
        //    "abcdefg".LimitTextLength(4, true).Should().Be("a...");
        //}

        //[TestMethod]
        //public void LimitTextLength_exactly_ellipsis_length()
        //{
        //    "abcdefg".LimitTextLength(3, true).Should().Be("...");
        //}

        //[TestMethod]
        //public void LimitTextLength_shorter_than_ellipsis()
        //{
        //    "abcdefg".LimitTextLength(2, true).Should().Be("...");
        //}

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Limit the text length
        /// </summary>
        /// <param name="text">Text to limit</param>
        /// <param name="maxLength">Maximum allowed number of characters
        /// in the result</param>
        /// <param name="showEllipsis"><code>true</code>=Limit
        /// <paramref name="text" /> to first
        /// (<paramref name="maxLength" />-3) characters plus "...",
        /// <code>false</code>=Limit <paramref name="text" /> to first
        /// <paramref name="maxLength" /> characters</param>
        /// <returns>Content of <paramref name="text" />, but at most
        /// <paramref name="maxLength" /> characters</returns>
        /// <exception cref="ArgumentOutOfRangeException">maxLength - Value must not be negative</exception>
        /// <remarks>With <paramref name="showEllipsis" /> left to default
        /// value of <code>true</code> the result will be "..." even if
        /// you specify a maximum length less than or equal to 3.</remarks>
        public static string LimitTextLength(this string text, int maxLength, bool showEllipsis = true)
        {
            if (maxLength < 0) throw new ArgumentOutOfRangeException("maxLength", "Value must not be negative");
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;
            var n = text.Length;
            var ellipsis = showEllipsis ? "..." : string.Empty;
            var minLength = ellipsis.Length;
            maxLength = Math.Max(minLength, maxLength);
            return n > maxLength ? text.Substring(0, Math.Min(maxLength - minLength, n)) + ellipsis : text;
        }

    }
}
