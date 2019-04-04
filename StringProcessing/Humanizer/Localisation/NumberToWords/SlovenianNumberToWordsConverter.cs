// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="SlovenianNumberToWordsConverter.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords
{
    /// <summary>
    /// Class SlovenianNumberToWordsConverter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.GenderlessNumberToWordsConverter" />
    internal class SlovenianNumberToWordsConverter : GenderlessNumberToWordsConverter
    {
        /// <summary>
        /// The units map
        /// </summary>
        private static readonly string[] UnitsMap = {"nič", "ena", "dva", "tri", "štiri", "pet", "šest", "sedem", "osem", "devet", "deset", "enajst", "dvanajst", "trinajst", "štirinajst", "petnajst", "šestnajst", "sedemnajst", "osemnajst", "devetnajst"};
        /// <summary>
        /// The tens map
        /// </summary>
        private static readonly string[] TensMap = {"nič", "deset", "dvajset", "trideset", "štirideset", "petdeset", "šestdeset", "sedemdeset", "osemdeset", "devetdeset"};

        /// <summary>
        /// The culture
        /// </summary>
        private readonly CultureInfo _culture;

        /// <summary>
        /// Initializes a new instance of the <see cref="SlovenianNumberToWordsConverter"/> class.
        /// </summary>
        /// <param name="culture">The culture.</param>
        public SlovenianNumberToWordsConverter(CultureInfo culture)
        {
            _culture = culture;
        }

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
            return "nič";

         if (number < 0)
            return string.Format("minus {0}", Convert(-number));

         var parts = new List<string>();

         var billions = number / 1000000000;
         if (billions > 0)
         {
            parts.Add(Part("milijarda", "dve milijardi", "{0} milijarde", "{0} milijard", billions));
            number %= 1000000000;
            if (number > 0)
               parts.Add(" ");
         }

         var millions = number / 1000000;
         if (millions > 0)
         {
            parts.Add(Part("milijon", "dva milijona", "{0} milijone", "{0} milijonov", millions));
            number %= 1000000;
            if (number > 0)
               parts.Add(" ");
         }

         var thousands = number / 1000;
         if (thousands > 0)
         {
            parts.Add(Part("tisoč", "dva tisoč", "{0} tisoč", "{0} tisoč", thousands));
            number %= 1000;
            if (number > 0)
               parts.Add(" ");
         }

         var hundreds = number / 100;
         if (hundreds > 0)
         {
            parts.Add(Part("sto", "dvesto", "{0}sto", "{0}sto", hundreds));
            number %= 100;
            if (number > 0)
               parts.Add(" ");
         }

         if (number > 0)
         {
            if (number < 20)
            {
               if (number > 1)
                  parts.Add(UnitsMap[number]);
               else
                  parts.Add("ena");
            }
            else
            {
               var units = number % 10;
               if (units > 0)
                  parts.Add(string.Format("{0}in", UnitsMap[units]));

               parts.Add(TensMap[number / 10]);
            }
         }

         return string.Join("", parts);
      }

        /// <summary>
        /// Converts the number to ordinal string
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.String.</returns>
        public override string ConvertToOrdinal(int number)
        {
            return number.ToString(_culture);
        }

        /// <summary>
        /// Parts the specified singular.
        /// </summary>
        /// <param name="singular">The singular.</param>
        /// <param name="dual">The dual.</param>
        /// <param name="trialQuadral">The trial quadral.</param>
        /// <param name="plural">The plural.</param>
        /// <param name="number">The number.</param>
        /// <returns>System.String.</returns>
        private string Part(string singular, string dual, string trialQuadral, string plural, int number)
      {
         if (number == 1)
            return singular;

         if (number == 2)
            return dual;

         if (number == 3 || number == 4)
            return string.Format(trialQuadral, Convert(number));

         return string.Format(plural, Convert(number));
      }
    }
}