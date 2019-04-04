// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="CasingExtensions.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// ApplyCase method to allow changing the case of a sentence easily
    /// </summary>
    public static class CasingExtensions
    {
        /// <summary>
        /// Changes the casing of the provided input
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="casing">The casing.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentOutOfRangeException">casing</exception>
        public static string ApplyCase(this string input, LetterCasing casing)
        {
            switch (casing)
            {
                case LetterCasing.Title:
                    return input.Transform(To.TitleCase);

                case LetterCasing.LowerCase:
                    return input.Transform(To.LowerCase);

                case LetterCasing.AllCaps:
                    return input.Transform(To.UpperCase);

                case LetterCasing.Sentence:
                    return input.Transform(To.SentenceCase);

                default:
                    throw new ArgumentOutOfRangeException(nameof(casing));
            }
        }
    }
}