// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-22-2018
// ***********************************************************************
// <copyright file="InflectorExtensions.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary>
//The Inflector class was cloned from Inflector (https://github.com/srkirkland/Inflector)
//</summary>
// ***********************************************************************




using System.Text.RegularExpressions;
using Zeroit.Framework.Utilities.StringProcessing.HumanizerInflections;

namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Inflector extensions
    /// </summary>
    public static class InflectorExtensions
    {
        /// <summary>
        /// Pluralizes the provided input considering irregular words
        /// </summary>
        /// <param name="word">Word to be pluralized</param>
        /// <param name="inputIsKnownToBeSingular">Normally you call Pluralize on singular words; but if you're unsure call it with false</param>
        /// <returns>System.String.</returns>
        public static string Pluralize(this string word, bool inputIsKnownToBeSingular = true)
        {
            return Vocabularies.Default.Pluralize(word, inputIsKnownToBeSingular);
        }

        /// <summary>
        /// Singularizes the provided input considering irregular words
        /// </summary>
        /// <param name="word">Word to be singularized</param>
        /// <param name="inputIsKnownToBePlural">Normally you call Singularize on plural words; but if you're unsure call it with false</param>
        /// <returns>System.String.</returns>
        public static string Singularize(this string word, bool inputIsKnownToBePlural = true)
        {
            return Vocabularies.Default.Singularize(word, inputIsKnownToBePlural);
        }

        /// <summary>
        /// Humanizes the input with Title casing
        /// </summary>
        /// <param name="input">The string to be titleized</param>
        /// <returns>System.String.</returns>
        public static string Titleize(this string input)
        {
            return input.Humanize(LetterCasing.Title);
        }

        /// <summary>
        /// By default, pascalize converts strings to UpperCamelCase also removing underscores
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        public static string Pascalize(this string input)
        {
            return Regex.Replace(input, "(?:^|_)(.)", match => match.Groups[1].Value.ToUpper());
        }

        /// <summary>
        /// Same as Pascalize except that the first character is lower case
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        public static string Camelize(this string input)
        {
            var word = Pascalize(input);
            return word.Length > 0 ? word.Substring(0, 1).ToLower() + word.Substring(1) : word;
        }

        /// <summary>
        /// Separates the input words with underscore
        /// </summary>
        /// <param name="input">The string to be underscored</param>
        /// <returns>System.String.</returns>
        public static string Underscore(this string input)
        {
            return Regex.Replace(
                Regex.Replace(
                    Regex.Replace(input, @"([\p{Lu}]+)([\p{Lu}][\p{Ll}])", "$1_$2"), @"([\p{Ll}\d])([\p{Lu}])", "$1_$2"), @"[-\s]", "_").ToLower();
        }

        /// <summary>
        /// Replaces underscores with dashes in the string
        /// </summary>
        /// <param name="underscoredWord">The underscored word.</param>
        /// <returns>System.String.</returns>
        public static string Dasherize(this string underscoredWord)
        {
            return underscoredWord.Replace('_', '-');
        }

        /// <summary>
        /// Replaces underscores with hyphens in the string
        /// </summary>
        /// <param name="underscoredWord">The underscored word.</param>
        /// <returns>System.String.</returns>
        public static string Hyphenate(this string underscoredWord)
        {
            return Dasherize(underscoredWord);
        }

        /// <summary>
        /// Separates the input words with hyphens and all the words are converted to lowercase
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        public static string Kebaberize(this string input)
        {
            return Underscore(input).Dasherize();
        }
    }
}
