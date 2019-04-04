// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="NumberToWordsConverterRegistry.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerConfiguration
{
    /// <summary>
    /// Class NumberToWordsConverterRegistry.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerConfiguration.LocaliserRegistry{Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.NumberToWords.INumberToWordsConverter}" />
    internal class NumberToWordsConverterRegistry : LocaliserRegistry<INumberToWordsConverter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NumberToWordsConverterRegistry"/> class.
        /// </summary>
        public NumberToWordsConverterRegistry()
            : base((culture) => new DefaultNumberToWordsConverter(culture))
        {
            Register("af", new AfrikaansNumberToWordsConverter());
            Register("en", new EnglishNumberToWordsConverter());
            Register("ar", new ArabicNumberToWordsConverter());
            Register("fa", new FarsiNumberToWordsConverter());
            Register("es", new SpanishNumberToWordsConverter());
            Register("pl", (culture) => new PolishNumberToWordsConverter(culture));
            Register("pt-BR", new BrazilianPortugueseNumberToWordsConverter());
            Register("ro", new RomanianNumberToWordsConverter());
            Register("ru", new RussianNumberToWordsConverter());
            Register("fi", new FinnishNumberToWordsConverter());
            Register("fr-BE", new FrenchBelgianNumberToWordsConverter());
            Register("fr-CH", new FrenchSwissNumberToWordsConverter());
            Register("fr", new FrenchNumberToWordsConverter());
            Register("nl", new DutchNumberToWordsConverter());
            Register("he", (culture) => new HebrewNumberToWordsConverter(culture));
            Register("sl", (culture) => new SlovenianNumberToWordsConverter(culture));
            Register("de", new GermanNumberToWordsConverter());
            Register("bn-BD", new BanglaNumberToWordsConverter());
            Register("tr", new TurkishNumberToWordConverter());
            Register("it", new ItalianNumberToWordsConverter());
            Register("uk", new UkrainianNumberToWordsConverter());
            Register("uz-Latn-UZ", new UzbekLatnNumberToWordConverter());
            Register("uz-Cyrl-UZ", new UzbekCyrlNumberToWordConverter());
            Register("sr", (culture) => new SerbianCyrlNumberToWordsConverter(culture));
            Register("sr-Latn", (culture) => new SerbianNumberToWordsConverter(culture));
            Register("nb", new NorwegianBokmalNumberToWordsConverter());
            Register("zh-CN", new ChineseNumberToWordsConverter());
        }
    }
}
