// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="TrimDuplicates.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
