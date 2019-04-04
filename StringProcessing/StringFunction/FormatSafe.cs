// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="FormatSafe.cs" company="Zeroit Dev Technologies">
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

        //var message = "Hello, {0}!";
        //var formattedMessage = message.FormatSafe("World");
        //// formattedMessage now "Hello, World!".

        //// Error Example:
        //var message = "Hello, {1}!";
        //var formattedMessage = message.FormatSafe("World");
        //// formattedMessage now contains "Hello, {1}! (Invalid format or args!)".

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Formats the string safely, without throwing any exceptions.
        /// </summary>
        /// <param name="format">The format source string to apply the given arguments to.</param>
        /// <param name="args">Arguments to apply to the format source string.</param>
        /// <returns>The formatted string. Null if the format source string was null.</returns>
        /// <remarks>Basic Example:
        /// <example><![CDATA[
        /// var message = "Hello, {0}!";
        /// var formattedMessage = message.FormatSafe("World");
        /// // formattedMessage now contains the string "Hello, World!".
        /// ]]></example>
        /// Error Example:
        /// <example><![CDATA[
        /// var message = "Hello, {1}!";
        /// var formattedMessage = message.FormatSafe("World");
        /// // formattedMessage now contains the string "Hello, {0}! (Invalid format or args!)".
        /// ]]></example></remarks>
        public static string FormatSafe(this string format, params object[] args)
        {
            const string badFormat = " (Invalid format or args!)";

            if (format != null)
            {
                try { return String.Format(format, args); }
                catch { return format + badFormat; }
            }
            return null;
        }

    }
}
