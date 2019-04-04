// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="StringExtensions.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Extension methods for String type.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Extension method to format string with passed arguments. Current thread's current culture is used
        /// </summary>
        /// <param name="format">string format</param>
        /// <param name="args">arguments</param>
        /// <returns>System.String.</returns>
        public static string FormatWith(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        /// <summary>
        /// Extension method to format string with passed arguments using specified format provider (i.e. CultureInfo)
        /// </summary>
        /// <param name="format">string format</param>
        /// <param name="provider">An object that supplies culture-specific formatting information</param>
        /// <param name="args">arguments</param>
        /// <returns>System.String.</returns>
        public static string FormatWith(this string format, IFormatProvider provider, params object[] args)
        {
            return string.Format(provider, format, args);
        }
    }
}
