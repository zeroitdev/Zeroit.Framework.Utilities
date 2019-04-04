// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="EnumDehumanizeExtensions.cs" company="Zeroit Dev Technologies">
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
using System.Linq;

namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Contains extension methods for dehumanizing Enum string values.
    /// </summary>
    public static class EnumDehumanizeExtensions
    {
        /// <summary>
        /// Dehumanizes a string into the Enum it was originally Humanized from!
        /// </summary>
        /// <typeparam name="TTargetEnum">The target enum</typeparam>
        /// <param name="input">The string to be converted</param>
        /// <returns>TTargetEnum.</returns>
        /// <exception cref="ArgumentException">If TTargetEnum is not an enum</exception>
        /// <exception cref="NoMatchFoundException">Couldn't find any enum member that matches the string</exception>
        public static TTargetEnum DehumanizeTo<TTargetEnum>(this string input)
            where TTargetEnum : struct, IComparable, IFormattable
        {
            return (TTargetEnum)DehumanizeToPrivate(input, typeof(TTargetEnum), OnNoMatch.ThrowsException);
        }

        /// <summary>
        /// Dehumanizes a string into the Enum it was originally Humanized from!
        /// </summary>
        /// <param name="input">The string to be converted</param>
        /// <param name="targetEnum">The target enum</param>
        /// <param name="onNoMatch">What to do when input is not matched to the enum.</param>
        /// <returns>Enum.</returns>
        /// <exception cref="NoMatchFoundException">Couldn't find any enum member that matches the string</exception>
        /// <exception cref="ArgumentException">If targetEnum is not an enum</exception>
        public static Enum DehumanizeTo(this string input, Type targetEnum, OnNoMatch onNoMatch = OnNoMatch.ThrowsException)
        {
            return (Enum)DehumanizeToPrivate(input, targetEnum, onNoMatch);
        }

        /// <summary>
        /// Dehumanizes to private.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="targetEnum">The target enum.</param>
        /// <param name="onNoMatch">The on no match.</param>
        /// <returns>System.Object.</returns>
        /// <exception cref="NoMatchFoundException">Couldn't find any enum member that matches the string " + input</exception>
        private static object DehumanizeToPrivate(string input, Type targetEnum, OnNoMatch onNoMatch)
        {
            var match = Enum.GetValues(targetEnum).Cast<Enum>().FirstOrDefault(value => string.Equals(value.Humanize(), input, StringComparison.OrdinalIgnoreCase));

            if (match == null && onNoMatch == OnNoMatch.ThrowsException)
                throw new NoMatchFoundException("Couldn't find any enum member that matches the string " + input);

            return match;
        }
    }
}