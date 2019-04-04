// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="BrazilianPortugueseNumberToWordsConverter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using Zeroit.Framework.Utilities.StringProcessing.Humanizer;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords
{
    /// <summary>
    /// Class BrazilianPortugueseNumberToWordsConverter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.GenderedNumberToWordsConverter" />
    internal class BrazilianPortugueseNumberToWordsConverter : GenderedNumberToWordsConverter
    {
        /// <summary>
        /// The portuguese units map
        /// </summary>
        private static readonly string[] PortugueseUnitsMap = { "zero", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove", "dez", "onze", "doze", "treze", "quatorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove" };
        /// <summary>
        /// The portuguese tens map
        /// </summary>
        private static readonly string[] PortugueseTensMap = { "zero", "dez", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };
        /// <summary>
        /// The portuguese hundreds map
        /// </summary>
        private static readonly string[] PortugueseHundredsMap = { "zero", "cento", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos" };

        /// <summary>
        /// The portuguese ordinal units map
        /// </summary>
        private static readonly string[] PortugueseOrdinalUnitsMap = { "zero", "primeiro", "segundo", "terceiro", "quarto", "quinto", "sexto", "sétimo", "oitavo", "nono" };
        /// <summary>
        /// The portuguese ordinal tens map
        /// </summary>
        private static readonly string[] PortugueseOrdinalTensMap = { "zero", "décimo", "vigésimo", "trigésimo", "quadragésimo", "quinquagésimo", "sexagésimo", "septuagésimo", "octogésimo", "nonagésimo" };
        /// <summary>
        /// The portuguese ordinal hundreds map
        /// </summary>
        private static readonly string[] PortugueseOrdinalHundredsMap = { "zero", "centésimo", "ducentésimo", "trecentésimo", "quadringentésimo", "quingentésimo", "sexcentésimo", "septingentésimo", "octingentésimo", "noningentésimo" };

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

            if (number == 0)
                return "zero";

            if (number < 0)
                return string.Format("menos {0}", Convert(Math.Abs(number), gender));

            var parts = new List<string>();

            if ((number / 1000000000) > 0)
            {
                // gender is not applied for billions
                parts.Add(number / 1000000000 >= 2
                    ? string.Format("{0} bilhões", Convert(number / 1000000000, GrammaticalGender.Masculine))
                    : string.Format("{0} bilhão", Convert(number / 1000000000, GrammaticalGender.Masculine)));

                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                // gender is not applied for millions
                parts.Add(number / 1000000 >= 2
                    ? string.Format("{0} milhões", Convert(number / 1000000, GrammaticalGender.Masculine))
                    : string.Format("{0} milhão", Convert(number / 1000000, GrammaticalGender.Masculine)));

                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                // gender is not applied for thousands
                parts.Add(number / 1000 == 1 ? "mil" : string.Format("{0} mil", Convert(number / 1000, GrammaticalGender.Masculine)));
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                if (number == 100)
                    parts.Add(parts.Count > 0 ? "e cem" : "cem");
                else
                    // Gender is applied to hundreds starting from 200
                    parts.Add(ApplyGender(PortugueseHundredsMap[(number / 100)], gender));

                number %= 100;
            }

            if (number > 0)
            {
                if (parts.Count != 0)
                    parts.Add("e");

                if (number < 20)
                    parts.Add(ApplyGender(PortugueseUnitsMap[number], gender));
                else
                {
                    var lastPart = PortugueseTensMap[number / 10];
                    if ((number % 10) > 0)
                        lastPart += string.Format(" e {0}", ApplyGender(PortugueseUnitsMap[number % 10], gender));

                    parts.Add(lastPart);
                }
            }

            return string.Join(" ", parts.ToArray());
        }

        /// <summary>
        /// Converts the number to ordinal string using the provided grammatical gender
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>System.String.</returns>
        public override string ConvertToOrdinal(int number, GrammaticalGender gender)
        {
            // N/A in Portuguese ordinal
            if (number == 0)
                return "zero";

            var parts = new List<string>();

            if ((number / 1000000000) > 0)
            {
                parts.Add(number / 1000000000 == 1
                    ? ApplyOrdinalGender("bilionésimo", gender)
                    : string.Format("{0} " + ApplyOrdinalGender("bilionésimo", gender), ConvertToOrdinal(number / 1000000000, gender)));

                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                parts.Add(number / 1000000 == 1
                    ? ApplyOrdinalGender("milionésimo", gender)
                    : string.Format("{0}" + ApplyOrdinalGender("milionésimo", gender), ConvertToOrdinal(number / 1000000000, gender)));

                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                parts.Add(number / 1000 == 1
                    ? ApplyOrdinalGender("milésimo", gender)
                    : string.Format("{0} " + ApplyOrdinalGender("milésimo", gender), ConvertToOrdinal(number / 1000, gender)));

                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                parts.Add(ApplyOrdinalGender(PortugueseOrdinalHundredsMap[number / 100], gender));
                number %= 100;
            }

            if ((number / 10) > 0)
            {
                parts.Add(ApplyOrdinalGender(PortugueseOrdinalTensMap[number / 10], gender));
                number %= 10;
            }

            if (number > 0)
                parts.Add(ApplyOrdinalGender(PortugueseOrdinalUnitsMap[number], gender));

            return string.Join(" ", parts.ToArray());
        }

        /// <summary>
        /// Applies the gender.
        /// </summary>
        /// <param name="toWords">To words.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>System.String.</returns>
        private static string ApplyGender(string toWords, GrammaticalGender gender)
        {
            if (gender != GrammaticalGender.Feminine) 
                return toWords;

            if (toWords.EndsWith("os"))
                return toWords.Substring(0, toWords.Length - 2) + "as";

            if (toWords.EndsWith("um"))
                return toWords.Substring(0, toWords.Length - 2) + "uma";

            if (toWords.EndsWith("dois"))
                return toWords.Substring(0, toWords.Length - 4) + "duas";

            return toWords;
        }

        /// <summary>
        /// Applies the ordinal gender.
        /// </summary>
        /// <param name="toWords">To words.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>System.String.</returns>
        private static string ApplyOrdinalGender(string toWords, GrammaticalGender gender)
        {
            if (gender == GrammaticalGender.Feminine)
                return toWords.TrimEnd('o') + 'a';

            return toWords;
        }
    }
}
