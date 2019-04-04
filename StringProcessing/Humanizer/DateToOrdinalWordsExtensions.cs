// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DateToOrdinalWordsExtensions.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Zeroit.Framework.Utilities.StringProcessing.HumanizerConfiguration;

namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Humanizes DateTime into human readable sentence
    /// </summary>
    public static class DateToOrdinalWordsExtensions
    {
        /// <summary>
        /// Turns the provided date into ordinal words
        /// </summary>
        /// <param name="input">The date to be made into ordinal words</param>
        /// <returns>The date in ordinal words</returns>
        public static string ToOrdinalWords(this DateTime input)
        {
            return Configurator.DateToOrdinalWordsConverter.Convert(input);
        }
        /// <summary>
        /// Turns the provided date into ordinal words
        /// </summary>
        /// <param name="input">The date to be made into ordinal words</param>
        /// <param name="grammaticalCase">The grammatical case to use for output words</param>
        /// <returns>The date in ordinal words</returns>
        public static string ToOrdinalWords(this DateTime input, Zeroit.Framework.Utilities.StringProcessing.Humanizer.GrammaticalCase grammaticalCase)
        {
            return Configurator.DateToOrdinalWordsConverter.Convert(input, grammaticalCase);
        }
    }
}