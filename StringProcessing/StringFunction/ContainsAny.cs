// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ContainsAny.cs" company="Zeroit Dev Technologies">
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

        //char[] invalidFileNameCharacters = Path.GetInvalidFileNameChars();

        //    if (newFileName.ContainsAny(invalidFileNameCharacters))
        //{
        //    MessageBox.Show("File name contains invalid characters.");
        //}

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Determines whether the specified characters contains any.
        /// </summary>
        /// <param name="theString">The string.</param>
        /// <param name="characters">The characters.</param>
        /// <returns><c>true</c> if the specified characters contains any; otherwise, <c>false</c>.</returns>
        public static bool ContainsAny(this string theString, char[] characters)
        {
            foreach (char character in characters)
            {
                if (theString.Contains(character.ToString()))
                {
                    return true;
                }
            }
            return false;
        }


        //---------------------------------Implementation-----------------------------//

        //string value = "Kevin from Taiwan.";
        //string[] values = new string[] { "Kevin", "Sunny" };
        //    if(value.ContainsAny(values))
        //{
        //    Console.WriteLine("Hi!");
        //}

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Checks if a given string contains any of the string array.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="values">The values.</param>
        /// <returns><c>true</c> if the specified values contains any; otherwise, <c>false</c>.</returns>
        public static bool ContainsAny(
            this string value,
            params string[] values)
        {
            foreach (string one in values)
            {
                if (value.Contains(one))
                {
                    return true;
                }
            }
            return false;
        }

        //---------------------------------Implementation-----------------------------//

        //string testString = "Hello world.  This is a test";

        //bool result = testString.ContainsAny("Hello", "test");

        //---------------------------------Implementation-----------------------------//


        /// <summary>
        /// Checks if a given string contains any of the string array.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="values">The values.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool IncludesAny(this string str, params string[] values)
        {
            if (!string.IsNullOrEmpty(str) || values.Length == 0)
            {
                foreach (string value in values)
                {
                    if (str.Contains(value))
                        return true;
                }
            }

            return false;
        }

    }
}
