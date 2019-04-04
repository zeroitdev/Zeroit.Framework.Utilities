// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="TrimDuplicates.cs" company="Zeroit Dev Technologies">
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
using System.Linq;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//



        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Enum TrimType
        /// </summary>
        public enum TrimType
        {
            /// <summary>
            /// The comma
            /// </summary>
            Comma,
            /// <summary>
            /// The pipe
            /// </summary>
            Pipe,
            /// <summary>
            /// The colon
            /// </summary>
            Colon
        }

        /// <summary>
        /// Trims or removes duplicate delimited characters and leave only one instance of that character.
        /// If you like to have a comma delimited value and you like to remove excess commas, this extension method is for you.
        /// Other characters are supported too, this includes pipe and colon.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="trimType">Type of the trim.</param>
        /// <returns>System.String.</returns>
        public static string TrimDuplicates(this string input, TrimType trimType)
        {
            string result = string.Empty;

            switch (trimType)
            {
                case TrimType.Comma:
                    result = input.TrimCharacter(',');
                    break;
                case TrimType.Pipe:
                    result = input.TrimCharacter('|');
                    break;
                case TrimType.Colon:
                    result = input.TrimCharacter(':');
                    break;
                default:
                    break;
            }

            return result;
        }

        /// <summary>
        /// Trims the character.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="character">The character.</param>
        /// <returns>System.String.</returns>
        private static string TrimCharacter(this string input, char character)
        {
            string result = string.Empty;

            result = string.Join(character.ToString(), input.Split(character)
                .Where(str => str != string.Empty)
                .ToArray());

            return result;
        }

    }
}
