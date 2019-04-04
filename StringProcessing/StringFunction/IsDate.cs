// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="IsDate.cs" company="Zeroit Dev Technologies">
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

        //string nonDate = "Foo";
        //string someDate = "Jan 1 2010";

        //bool isDate = nonDate.IsDate(); //false
        //isDate = someDate.IsDate(); //true

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Determines whether the specified input is date.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns><c>true</c> if the specified input is date; otherwise, <c>false</c>.</returns>
        public static bool IsDate(this string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                DateTime dt;
                return (DateTime.TryParse(input, out dt));
            }
            else
            {
                return false;
            }
        }


        //---------------------------------Implementation-----------------------------//

        //Assert.IsTrue("23 March 2003".IsDate());
        //Assert.IsTrue("1 August -2003".IsDate());
        //Assert.IsTrue("2013-1-25".IsDate());
        //Assert.IsTrue("May 30, 2009".IsDate());

        //Assert.IsFalse("23 JulyAugust 2003".IsDate());
        //Assert.IsFalse("38 August 2003".IsDate());
        //Assert.IsFalse("2013-13-25".IsDate());
        //Assert.IsFalse("2013-10-92".IsDate());
        //Assert.IsFalse("-2013-1-3".IsDate());
        //Assert.IsFalse("May 32, 2009".IsDate());

        //Assert.IsFalse("One flew over the Cookoo's nest".IsDate());
        //Assert.IsFalse("".IsDate());
        //Assert.IsFalse(string.Empty.IsDate());
        //Assert.IsFalse(((string)null).IsDate());

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Determines if specified string is DateTime. Its an improvement on Phil Campbell's version.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="extended">The extended.</param>
        /// <returns><c>true</c> if the specified extended is date; otherwise, <c>false</c>.</returns>
        public static bool IsDate(this string input, params object[] extended)
        {
            DateTime dt;
            return (DateTime.TryParse(input, out dt));
        }

    }
}
