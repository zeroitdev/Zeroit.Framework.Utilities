﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="StringHumanizeExtensions.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;
using System.Text.RegularExpressions;

namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Contains extension methods for humanizing string values.
    /// </summary>
    public static class StringHumanizeExtensions
    {
        /// <summary>
        /// The pascal case word parts regex
        /// </summary>
        private static readonly Regex PascalCaseWordPartsRegex;
        /// <summary>
        /// The freestanding spacing character regex
        /// </summary>
        private static readonly Regex FreestandingSpacingCharRegex;

        /// <summary>
        /// Initializes static members of the <see cref="StringHumanizeExtensions"/> class.
        /// </summary>
        static StringHumanizeExtensions()
        {
            PascalCaseWordPartsRegex = new Regex(@"[\p{Lu}]?[\p{Ll}]+|[0-9]+[\p{Ll}]*|[\p{Lu}]+(?=[\p{Lu}][\p{Ll}]|[0-9]|\b)|[\p{Lo}]+",
                RegexOptions.IgnorePatternWhitespace | RegexOptions.ExplicitCapture | RegexOptionsUtil.Compiled);
            FreestandingSpacingCharRegex = new Regex(@"\s[-_]|[-_]\s", RegexOptionsUtil.Compiled);
        }

        /// <summary>
        /// Froms the underscore dash separated words.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        static string FromUnderscoreDashSeparatedWords (string input)
        {
            return string.Join(" ", input.Split(new[] {'_', '-'}));
        }

        /// <summary>
        /// Froms the pascal case.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        static string FromPascalCase(string input)
        {
            var result = string.Join(" ", PascalCaseWordPartsRegex
                .Matches(input).Cast<Match>()
                .Select(match => match.Value.ToCharArray().All(char.IsUpper) &&
                    (match.Value.Length > 1 || (match.Index > 0 && input[match.Index - 1] == ' ') || match.Value == "I")
                    ? match.Value
                    : match.Value.ToLower()));

            return result.Length > 0 ? char.ToUpper(result[0]) +
                result.Substring(1, result.Length - 1) : result;
        }

        /// <summary>
        /// Humanizes the input string; e.g. Underscored_input_String_is_turned_INTO_sentence -&gt; 'Underscored input String is turned INTO sentence'
        /// </summary>
        /// <param name="input">The string to be humanized</param>
        /// <returns>System.String.</returns>
        public static string Humanize(this string input)
        {
            // if input is all capitals (e.g. an acronym) then return it without change
            if (input.ToCharArray().All(char.IsUpper))
                return input;

            // if input contains a dash or underscore which preceeds or follows a space (or both, e.g. free-standing)
            // remove the dash/underscore and run it through FromPascalCase
            if (FreestandingSpacingCharRegex.IsMatch(input))
                return FromPascalCase(FromUnderscoreDashSeparatedWords(input));

            if (input.Contains("_") || input.Contains("-"))
                return FromUnderscoreDashSeparatedWords(input);

            return FromPascalCase(input);
        }

        /// <summary>
        /// Humanized the input string based on the provided casing
        /// </summary>
        /// <param name="input">The string to be humanized</param>
        /// <param name="casing">The desired casing for the output</param>
        /// <returns>System.String.</returns>
        public static string Humanize(this string input, LetterCasing casing)
        {
            return input.Humanize().ApplyCase(casing);
        }
    }
}