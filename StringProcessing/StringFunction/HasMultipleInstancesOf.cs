// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="HasMultipleInstancesOf.cs" company="Zeroit Dev Technologies">
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

        //string myStr1 = "Hello.World.txt";
        //string myStr2 = "Hello World";

        //bool hasMultPeriods = myStr1.HasMultipleInstancesOf('.'); //returns true
        //bool hasMultSpaces = myStr2.HasMultipleInstancesOf(' '); //returns false

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Determines whether a string has multiple occurrences of a particular character.
        /// May be helpful when parsing file names, or ensuring a particular string has already contains a given character.
        /// This may be extended to use strings, rather than a char.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="charToFind">The character to find.</param>
        /// <returns><c>true</c> if [has multiple instances of] [the specified character to find]; otherwise, <c>false</c>.</returns>
        public static bool HasMultipleInstancesOf(this string input, char charToFind)
        {

            if ((string.IsNullOrEmpty(input)) || (input.Length == 0) || (input.IndexOf(charToFind) == 0))
                return false;

            if (input.IndexOf(charToFind) != input.LastIndexOf(charToFind))
                return true;

            return false;
        }


    }
}
