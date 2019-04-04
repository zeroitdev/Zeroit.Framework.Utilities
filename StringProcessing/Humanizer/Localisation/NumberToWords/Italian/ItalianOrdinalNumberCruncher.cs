// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ItalianOrdinalNumberCruncher.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Zeroit.Framework.Utilities.StringProcessing.Humanizer;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.Italian
{
    /// <summary>
    /// Class ItalianOrdinalNumberCruncher.
    /// </summary>
    class ItalianOrdinalNumberCruncher
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItalianOrdinalNumberCruncher"/> class.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="gender">The gender.</param>
        public ItalianOrdinalNumberCruncher(int number, GrammaticalGender gender)
        {
            _fullNumber = number;
            _gender = gender;
            _genderSuffix = (gender == GrammaticalGender.Feminine ? "a" : "o");
        }

        /// <summary>
        /// Converts this instance.
        /// </summary>
        /// <returns>System.String.</returns>
        public string Convert()
        {
            // it's easier to treat zero as a completely distinct case
            if (_fullNumber == 0)
                return "zero";

            if (_fullNumber <= 9)
            {
                // units ordinals, 1 to 9, are totally different than the rest: treat them as a distinct case
                return _unitsUnder10NumberToText[_fullNumber] + _genderSuffix;
            }

            var cardinalCruncher = new ItalianCardinalNumberCruncher(_fullNumber, _gender);

            var words = cardinalCruncher.Convert();

            var tensAndUnits = _fullNumber % 100;

            if (tensAndUnits == 10)
            {
                // for numbers ending in 10, cardinal and ordinal endings are different, suffix doesn't work
                words = words.Remove(words.Length - _lengthOf10AsCardinal) + "decim" + _genderSuffix;
            }
            else
            {
                // truncate last vowel
                words = words.Remove(words.Length - 1);

                var units = _fullNumber % 10;

                // reintroduce *unaccented* last vowel in some corner cases
                if (units == 3)
                    words += 'e';
                else if (units == 6)
                    words += 'i';

                var lowestThreeDigits = _fullNumber % 1000;
                var lowestSixDigits = _fullNumber % 1000000;
                var lowestNineDigits = _fullNumber % 1000000000;

                if (lowestNineDigits == 0)
                {
                    // if exact billions, cardinal number words are joined
                    words = words.Replace(" miliard", "miliard");

                    // if 1 billion, numeral prefix is removed completely
                    if (_fullNumber == 1000000000)
                    {
                        words = words.Replace("un", string.Empty);
                    }
                }
                else if (lowestSixDigits == 0)
                {
                    // if exact millions, cardinal number words are joined
                    words = words.Replace(" milion", "milion");

                    // if 1 million, numeral prefix is removed completely
                    if (_fullNumber == 1000000)
                    {
                        words = words.Replace("un", string.Empty);
                    }
                }
                else if (lowestThreeDigits == 0 && _fullNumber > 1000)
                {
                    // if exact thousands, double the final 'l', apart from 1000 already having that
                    words += 'l';
                }

                // append common ordinal suffix
                words += "esim" + _genderSuffix;
            }

            return words;
        }

        /// <summary>
        /// The full number
        /// </summary>
        protected readonly int _fullNumber;
        /// <summary>
        /// The gender
        /// </summary>
        protected readonly GrammaticalGender _gender;
        /// <summary>
        /// The gender suffix
        /// </summary>
        private readonly string _genderSuffix;

        /// <summary>
        /// Lookup table converting units number to text. Index 1 for 1, index 2 for 2, up to index 9.
        /// </summary>
        protected static string[] _unitsUnder10NumberToText = new string[]
        {
            string.Empty,
            "prim",
            "second",
            "terz",
            "quart",
            "quint",
            "sest",
            "settim",
            "ottav",
            "non"
        };

        /// <summary>
        /// The length of10 as cardinal
        /// </summary>
        protected static int _lengthOf10AsCardinal = "dieci".Length;
    }
}