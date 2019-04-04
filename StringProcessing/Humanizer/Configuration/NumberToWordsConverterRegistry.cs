// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="NumberToWordsConverterRegistry.cs" company="Zeroit Dev Technologies">
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
