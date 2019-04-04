// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="HebrewNumberToWordsConverter.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.Globalization;
using Zeroit.Framework.Utilities.StringProcessing.Humanizer;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords
{
    /// <summary>
    /// Class HebrewNumberToWordsConverter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.GenderedNumberToWordsConverter" />
    internal class HebrewNumberToWordsConverter : GenderedNumberToWordsConverter
    {
        /// <summary>
        /// The units feminine
        /// </summary>
        private static readonly string[] UnitsFeminine = { "אפס", "אחת", "שתיים", "שלוש", "ארבע", "חמש", "שש", "שבע", "שמונה", "תשע", "עשר" };
        /// <summary>
        /// The units masculine
        /// </summary>
        private static readonly string[] UnitsMasculine = { "אפס", "אחד", "שניים", "שלושה", "ארבעה", "חמישה", "שישה", "שבעה", "שמונה", "תשעה", "עשרה" };
        /// <summary>
        /// The tens unit
        /// </summary>
        private static readonly string[] TensUnit = { "עשר", "עשרים", "שלושים", "ארבעים", "חמישים", "שישים", "שבעים", "שמונים", "תשעים" };

        /// <summary>
        /// The culture
        /// </summary>
        private readonly CultureInfo _culture;

        /// <summary>
        /// Class DescriptionAttribute.
        /// </summary>
        /// <seealso cref="System.Attribute" />
        private class DescriptionAttribute : Attribute
        {
            /// <summary>
            /// Gets or sets the description.
            /// </summary>
            /// <value>The description.</value>
            public string Description { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="DescriptionAttribute"/> class.
            /// </summary>
            /// <param name="description">The description.</param>
            public DescriptionAttribute(string description)
            {
                Description = description;
            }
        }

        /// <summary>
        /// Enum Group
        /// </summary>
        private enum Group
        {
            /// <summary>
            /// The hundreds
            /// </summary>
            Hundreds = 100,
            /// <summary>
            /// The thousands
            /// </summary>
            Thousands = 1000,
            /// <summary>
            /// The millions
            /// </summary>
            [Description("מיליון")]
            Millions  = 1000000,
            /// <summary>
            /// The billions
            /// </summary>
            [Description("מיליארד")]
            Billions  = 1000000000
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HebrewNumberToWordsConverter"/> class.
        /// </summary>
        /// <param name="culture">The culture.</param>
        public HebrewNumberToWordsConverter(CultureInfo culture)
            : base(GrammaticalGender.Feminine)
        {
            _culture = culture;
        }

        /// <summary>
        /// Converts the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override string Convert(long input, GrammaticalGender gender)
        {
            if (input > Int32.MaxValue || input < Int32.MinValue)
            {
                throw new NotImplementedException();
            }
            var number = (int)input;

            if (number < 0)
                return string.Format("מינוס {0}", Convert(-number, gender));

            if (number == 0)
                return UnitsFeminine[0];

            var parts = new List<string>();
            if (number >= (int)Group.Billions)
            {
                ToBigNumber(number, Group.Billions, parts);
                number %= (int)Group.Billions;
            }

            if (number >= (int)Group.Millions)
            {
                ToBigNumber(number, Group.Millions, parts);
                number %= (int)Group.Millions;
            }

            if (number >= (int)Group.Thousands)
            {
                ToThousands(number, parts);
                number %= (int)Group.Thousands;
            }

            if (number >= (int)Group.Hundreds)
            {
                ToHundreds(number, parts);
                number %= (int)Group.Hundreds;
            }

            if (number > 0)
            {
                var appendAnd = parts.Count != 0;

                if (number <= 10)
                {
                    var unit = gender == GrammaticalGender.Masculine ? UnitsMasculine[number] : UnitsFeminine[number];
                    if (appendAnd)
                        unit = "ו" + unit;
                    parts.Add(unit);
                }
                else if (number < 20)
                {
                    var unit = Convert(number % 10, gender);
                    unit = unit.Replace("יי", "י");
                    unit = string.Format("{0} {1}", unit, gender == GrammaticalGender.Masculine ? "עשר" : "עשרה");
                    if (appendAnd)
                        unit = "ו" + unit;
                    parts.Add(unit);
                }
                else
                {
                    var tenUnit = TensUnit[number / 10 - 1];
                    if (number % 10 == 0)
                        parts.Add(tenUnit);
                    else
                    {
                        var unit = Convert(number % 10, gender);
                        parts.Add(string.Format("{0} ו{1}", tenUnit, unit));
                    }
                }
            }

            return string.Join(" ", parts);
        }

        /// <summary>
        /// Converts the number to ordinal string using the provided grammatical gender
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>System.String.</returns>
        public override string ConvertToOrdinal(int number, GrammaticalGender gender)
        {
            return number.ToString(_culture);
        }

        /// <summary>
        /// To the big number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="group">The group.</param>
        /// <param name="parts">The parts.</param>
        private void ToBigNumber(int number, Group group, List<string> parts)
        {
            // Big numbers (million and above) always use the masculine form
            // See https://www.safa-ivrit.org/dikduk/numbers.php

            var digits = number / (int)@group;
            if (digits == 2)
                parts.Add("שני");
            else if (digits > 2)
                parts.Add(Convert(digits, GrammaticalGender.Masculine));
            parts.Add(@group.Humanize());
        }

        /// <summary>
        /// To the thousands.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="parts">The parts.</param>
        private void ToThousands(int number, List<string> parts)
        {
            var thousands = number / (int)Group.Thousands;

            if (thousands == 1)
                parts.Add("אלף");
            else if (thousands == 2)
                parts.Add("אלפיים");
            else if (thousands <= 10)
                parts.Add(UnitsFeminine[thousands] + "ת" + " אלפים");
            else
                parts.Add(Convert(thousands) + " אלף");
        }

        /// <summary>
        /// To the hundreds.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="parts">The parts.</param>
        private static void ToHundreds(int number, List<string> parts)
        {
            // For hundreds, Hebrew is using the feminine form
            // See https://www.safa-ivrit.org/dikduk/numbers.php

            var hundreds = number / (int)Group.Hundreds;

            if (hundreds == 1)
                parts.Add("מאה");
            else if (hundreds == 2)
                parts.Add("מאתיים");
            else
                parts.Add(UnitsFeminine[hundreds] + " מאות");
        }
    }
}