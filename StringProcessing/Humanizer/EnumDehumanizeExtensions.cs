// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="EnumDehumanizeExtensions.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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