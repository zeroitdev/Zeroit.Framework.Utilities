// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="NumberToWordsExtension.cs" company="Zeroit Dev Technologies">
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
using System.Globalization;
using Zeroit.Framework.Utilities.StringProcessing.HumanizerConfiguration;

namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Transform a number into words; e.g. 1 =&gt; one
    /// </summary>
    public static class NumberToWordsExtension
    {
        /// <summary>
        /// 3501.ToWords() -&gt; "three thousand five hundred and one"
        /// </summary>
        /// <param name="number">Number to be turned to words</param>
        /// <param name="culture">Culture to use. If null, current thread's UI culture is used.</param>
        /// <returns>System.String.</returns>
        public static string ToWords(this int number, CultureInfo culture = null)
        {
            return ((long)number).ToWords(culture);
        }

        /// <summary>
        /// For locales that support gender-specific forms
        /// </summary>
        /// <param name="number">Number to be turned to words</param>
        /// <param name="gender">The grammatical gender to use for output words</param>
        /// <param name="culture">Culture to use. If null, current thread's UI culture is used.</param>
        /// <returns>System.String.</returns>
        /// <example>
        /// Russian:
        /// <code>
        /// 1.ToWords(GrammaticalGender.Masculine) -&gt; "один"
        /// 1.ToWords(GrammaticalGender.Feminine) -&gt; "одна"
        /// </code>
        /// Hebrew:
        /// <code>
        /// 1.ToWords(GrammaticalGender.Masculine) -&gt; "אחד"
        /// 1.ToWords(GrammaticalGender.Feminine) -&gt; "אחת"
        /// </code></example>
        public static string ToWords(this int number, GrammaticalGender gender, CultureInfo culture = null)
        {
            return ((long)number).ToWords(gender, culture);
        }

        /// <summary>
        /// 3501.ToWords() -&gt; "three thousand five hundred and one"
        /// </summary>
        /// <param name="number">Number to be turned to words</param>
        /// <param name="culture">Culture to use. If null, current thread's UI culture is used.</param>
        /// <returns>System.String.</returns>
        public static string ToWords(this long number, CultureInfo culture = null)
        {
            return Configurator.GetNumberToWordsConverter(culture).Convert(number);
        }

        /// <summary>
        /// For locales that support gender-specific forms
        /// </summary>
        /// <param name="number">Number to be turned to words</param>
        /// <param name="gender">The grammatical gender to use for output words</param>
        /// <param name="culture">Culture to use. If null, current thread's UI culture is used.</param>
        /// <returns>System.String.</returns>
        /// <example>
        /// Russian:
        /// <code>
        /// 1.ToWords(GrammaticalGender.Masculine) -&gt; "один"
        /// 1.ToWords(GrammaticalGender.Feminine) -&gt; "одна"
        /// </code>
        /// Hebrew:
        /// <code>
        /// 1.ToWords(GrammaticalGender.Masculine) -&gt; "אחד"
        /// 1.ToWords(GrammaticalGender.Feminine) -&gt; "אחת"
        /// </code></example>
        public static string ToWords(this long number, GrammaticalGender gender, CultureInfo culture = null)
        {
            return Configurator.GetNumberToWordsConverter(culture).Convert(number, gender);
        }

        /// <summary>
        /// 1.ToOrdinalWords() -&gt; "first"
        /// </summary>
        /// <param name="number">Number to be turned to ordinal words</param>
        /// <param name="culture">Culture to use. If null, current thread's UI culture is used.</param>
        /// <returns>System.String.</returns>
        public static string ToOrdinalWords(this int number, CultureInfo culture = null)
        {
            return Configurator.GetNumberToWordsConverter(culture).ConvertToOrdinal(number);
        }

        /// <summary>
        /// for Brazilian Portuguese locale
        /// 1.ToOrdinalWords(GrammaticalGender.Masculine) -&gt; "primeiro"
        /// 1.ToOrdinalWords(GrammaticalGender.Feminine) -&gt; "primeira"
        /// </summary>
        /// <param name="number">Number to be turned to words</param>
        /// <param name="gender">The grammatical gender to use for output words</param>
        /// <param name="culture">Culture to use. If null, current thread's UI culture is used.</param>
        /// <returns>System.String.</returns>
        public static string ToOrdinalWords(this int number, GrammaticalGender gender, CultureInfo culture = null)
        {
            return Configurator.GetNumberToWordsConverter(culture).ConvertToOrdinal(number, gender);
        }
    }
}
