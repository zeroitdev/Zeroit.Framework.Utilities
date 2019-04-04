// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="IsNullOrEmptyOrWhiteSpace.cs" company="Zeroit Dev Technologies">
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

        //Assert.IsTrue(IsNullOrEmptyOrWhiteSpace(null));
        //Assert.IsTrue(IsNullOrEmptyOrWhiteSpace(string.Empty));
        //Assert.IsTrue(IsNullOrEmptyOrWhiteSpace("   "));
        //Assert.IsFalse(IsNullOrEmptyOrWhiteSpace("TestValue"));

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// It returns true if string is null or empty or just a white space otherwise it returns false.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns><c>true</c> if [is null or empty or white space] [the specified input]; otherwise, <c>false</c>.</returns>
        public static bool IsNullOrEmptyOrWhiteSpace(this string input)
        {
            return string.IsNullOrEmpty(input) || input.Trim() == string.Empty;
        }


        //---------------------------------Implementation-----------------------------//
        //var myReallyNiceString = GetThisStringFromACoolMethod();

        //    if(myReallyNiceString.IsNullOrEmpty()){
        //    DoSomeThingFancyStuff();
        //}


        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// This extension increase the readability of your code.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns><c>true</c> if [is null or empty] [the specified source]; otherwise, <c>false</c>.</returns>
        public static bool IsNullOrEmpty(this String source)
        {

            return String.IsNullOrEmpty(source);

        }

        //---------------------------------Implementation-----------------------------//

        //"".IsNullOrEmptyThenValue("mohsen") = "mohsen"
        //"ali".IsNullOrEmptyThenValue("mohsen") = "ali"

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Determines whether is null or empty then provide value.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string IsNullOrEmptyThenValue(this string str, string value)
        {
            if (string.IsNullOrEmpty(str))
                return value;
            else
                return str;
        }


        //---------------------------------Implementation-----------------------------//

        //string myString = null;
        //string aSaferString = myString.IsNull(string.Empty);

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// If the string is null, converts it to the default string specified. Essentially the same as the SQL IsNull()
        /// function.
        /// </summary>
        /// <param name="inString">The in string.</param>
        /// <param name="defaultString">The default string.</param>
        /// <returns>System.String.</returns>
        public static string IsNull(this string inString, string defaultString)
        {
            if (inString == null)
                return defaultString;
            else return inString;
        }
        

    }
}
