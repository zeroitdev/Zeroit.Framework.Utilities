// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="OrdinalizeExtensions.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Globalization;
using Zeroit.Framework.Utilities.StringProcessing.HumanizerConfiguration;

namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Ordinalize extensions
    /// </summary>
    public static class OrdinalizeExtensions
    {
        /// <summary>
        /// Turns a number into an ordinal string used to denote the position in an ordered sequence such as 1st, 2nd, 3rd, 4th.
        /// </summary>
        /// <param name="numberString">The number, in string, to be ordinalized</param>
        /// <returns>System.String.</returns>
        public static string Ordinalize(this string numberString)
        {
            return Configurator.Ordinalizer.Convert(int.Parse(numberString), numberString);
        }

        /// <summary>
        /// Turns a number into an ordinal string used to denote the position in an ordered sequence such as 1st, 2nd, 3rd, 4th.
        /// Gender for Brazilian Portuguese locale
        /// "1".Ordinalize(GrammaticalGender.Masculine) -&gt; "1º"
        /// "1".Ordinalize(GrammaticalGender.Feminine) -&gt; "1ª"
        /// </summary>
        /// <param name="numberString">The number, in string, to be ordinalized</param>
        /// <param name="gender">The grammatical gender to use for output words</param>
        /// <returns>System.String.</returns>
        public static string Ordinalize(this string numberString, GrammaticalGender gender)
        {
            return Configurator.Ordinalizer.Convert(int.Parse(numberString), numberString, gender);
        }

        /// <summary>
        /// Turns a number into an ordinal number used to denote the position in an ordered sequence such as 1st, 2nd, 3rd, 4th.
        /// </summary>
        /// <param name="number">The number to be ordinalized</param>
        /// <returns>System.String.</returns>
        public static string Ordinalize(this int number)
        {
            return Configurator.Ordinalizer.Convert(number, number.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Turns a number into an ordinal number used to denote the position in an ordered sequence such as 1st, 2nd, 3rd, 4th.
        /// Gender for Brazilian Portuguese locale
        /// 1.Ordinalize(GrammaticalGender.Masculine) -&gt; "1º"
        /// 1.Ordinalize(GrammaticalGender.Feminine) -&gt; "1ª"
        /// </summary>
        /// <param name="number">The number to be ordinalized</param>
        /// <param name="gender">The grammatical gender to use for output words</param>
        /// <returns>System.String.</returns>
        public static string Ordinalize(this int number, GrammaticalGender gender)
        {
            return Configurator.Ordinalizer.Convert(number, number.ToString(CultureInfo.InvariantCulture), gender);
        }
    }
}