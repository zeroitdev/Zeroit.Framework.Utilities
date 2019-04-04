// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="DutchNumberToWordsConverter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords
{
    /// <summary>
    /// Dutch spelling of numbers is not really officially regulated.
    /// There are a few different rules that can be applied.
    /// Used the rules as stated here.
    /// http://www.beterspellen.nl/website/?pag=110
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.GenderlessNumberToWordsConverter" />
    internal class DutchNumberToWordsConverter : GenderlessNumberToWordsConverter
    {
        /// <summary>
        /// The units map
        /// </summary>
        private static readonly string[] UnitsMap = { "nul", "een", "twee", "drie", "vier", "vijf", "zes", "zeven", "acht", "negen", "tien", "elf", "twaalf", "dertien", "veertien", "vijftien", "zestien", "zeventien", "achttien", "negentien" };
        /// <summary>
        /// The tens map
        /// </summary>
        private static readonly string[] TensMap = { "nul", "tien", "twintig", "dertig", "veertig", "vijftig", "zestig", "zeventig", "tachtig", "negentig" };

        /// <summary>
        /// Class Fact.
        /// </summary>
        class Fact
        {
            /// <summary>
            /// Gets or sets the value.
            /// </summary>
            /// <value>The value.</value>
            public int Value { get; set; }
            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            /// <value>The name.</value>
            public string Name { get; set; }
            /// <summary>
            /// Gets or sets the prefix.
            /// </summary>
            /// <value>The prefix.</value>
            public string Prefix { get; set; }
            /// <summary>
            /// Gets or sets the postfix.
            /// </summary>
            /// <value>The postfix.</value>
            public string Postfix { get; set; }
            /// <summary>
            /// Gets or sets a value indicating whether [display one unit].
            /// </summary>
            /// <value><c>true</c> if [display one unit]; otherwise, <c>false</c>.</value>
            public bool DisplayOneUnit { get; set; }
        }

        /// <summary>
        /// The hunderds
        /// </summary>
        private static readonly Fact[] Hunderds =
        {
            new Fact {Value = 1000000000, Name = "miljard", Prefix = " ", Postfix = " ", DisplayOneUnit = true},
            new Fact {Value = 1000000,    Name = "miljoen", Prefix = " ", Postfix = " ", DisplayOneUnit = true},
            new Fact {Value = 1000,       Name = "duizend", Prefix = "",  Postfix = " ", DisplayOneUnit = false},
            new Fact {Value = 100,        Name = "honderd", Prefix = "",  Postfix = "",  DisplayOneUnit = false}
        };

        /// <summary>
        /// Converts the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override string Convert(long input)
        {
            if (input > Int32.MaxValue || input < Int32.MinValue)
            {
                throw new NotImplementedException();
            }
            var number = (int)input;

            if (number == 0)
                return UnitsMap[0];

            if (number < 0)
                return string.Format("min {0}", Convert(-number));

            var word = "";

            foreach (var m in Hunderds)
            {
                var divided = number / m.Value;

                if (divided <= 0) 
                    continue;

                if (divided == 1 && !m.DisplayOneUnit)
                    word += m.Name;
                else
                    word += Convert(divided) + m.Prefix + m.Name;

                number %= m.Value;
                if (number > 0)
                    word += m.Postfix;
            }

            if (number > 0)
            {
                if (number < 20)
                    word += UnitsMap[number];
                else
                {
                    var tens = TensMap[number / 10];
                    var unit = number % 10;
                    if (unit > 0)
                    {
                        var units = UnitsMap[unit];
                        var trema = units.EndsWith("e");
                        word += units + (trema ? "ën" : "en") + tens;
                    }
                    else
                        word += tens;
                }
            }

            return word;
        }

        /// <summary>
        /// The ordinal exceptions
        /// </summary>
        private static readonly Dictionary<string, string> OrdinalExceptions = new Dictionary<string, string>
        {
            {"een", "eerste"},
            {"drie", "derde"},
            {"miljoen", "miljoenste"},
        };

        /// <summary>
        /// The ending character for ste
        /// </summary>
        private static readonly char[] EndingCharForSte = {'t', 'g', 'd'};

        /// <summary>
        /// Converts the number to ordinal string
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.String.</returns>
        public override string ConvertToOrdinal(int number)
        {
            var word = Convert(number);

            foreach (var kv in OrdinalExceptions.Where(kv => word.EndsWith(kv.Key)))
            {
                // replace word with exception
                return word.Substring(0, word.Length - kv.Key.Length) + kv.Value;
            }

            // achtste
            // twintigste, dertigste, veertigste, ...
            // honderdste, duizendste, ...
            if (word.LastIndexOfAny(EndingCharForSte) == (word.Length - 1))
                return word + "ste";

            return word + "de";
        }
    }
}