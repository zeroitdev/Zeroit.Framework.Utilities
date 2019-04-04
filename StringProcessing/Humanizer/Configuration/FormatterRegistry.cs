// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="FormatterRegistry.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.Formatters;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerConfiguration
{
    /// <summary>
    /// Class FormatterRegistry.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerConfiguration.LocaliserRegistry{Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.Formatters.IFormatter}" />
    internal class FormatterRegistry : LocaliserRegistry<IFormatter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormatterRegistry"/> class.
        /// </summary>
        public FormatterRegistry() : base(new DefaultFormatter("en-US"))
        {
            Register("ar", new ArabicFormatter());
            Register("he", new HebrewFormatter());
            Register("ro", new RomanianFormatter());
            Register("ru", new RussianFormatter());
            Register("sl", new SlovenianFormatter());
            Register("hr", new CroatianFormatter());
            Register("sr", new SerbianFormatter("sr"));
            Register("sr-Latn", new SerbianFormatter("sr-Latn"));
            Register("uk", new UkrainianFormatter());
            Register("fr", new FrenchFormatter("fr"));
            Register("fr-BE", new FrenchFormatter("fr-BE"));
            RegisterCzechSlovakPolishFormatter("cs");
            RegisterCzechSlovakPolishFormatter("pl");
            RegisterCzechSlovakPolishFormatter("sk");
            RegisterDefaultFormatter("bg");
            RegisterDefaultFormatter("pt");
            RegisterDefaultFormatter("sv");
            RegisterDefaultFormatter("tr");
            RegisterDefaultFormatter("vi");
            RegisterDefaultFormatter("en-US");
            RegisterDefaultFormatter("af");
            RegisterDefaultFormatter("da");
            RegisterDefaultFormatter("de");
            RegisterDefaultFormatter("el");
            RegisterDefaultFormatter("es");
            RegisterDefaultFormatter("fa");
            RegisterDefaultFormatter("fi-FI");
            RegisterDefaultFormatter("hu");
            RegisterDefaultFormatter("id");
            RegisterDefaultFormatter("ja");
            RegisterDefaultFormatter("nb");
            RegisterDefaultFormatter("nb-NO");
            RegisterDefaultFormatter("nl");
            RegisterDefaultFormatter("bn-BD");
            RegisterDefaultFormatter("it");
            RegisterDefaultFormatter("uz-Latn-UZ");
            RegisterDefaultFormatter("uz-Cyrl-UZ");
            RegisterDefaultFormatter("zh-CN");
            RegisterDefaultFormatter("zh-Hans");
            RegisterDefaultFormatter("zh-Hant");
        }

        /// <summary>
        /// Registers the default formatter.
        /// </summary>
        /// <param name="localeCode">The locale code.</param>
        private void RegisterDefaultFormatter(string localeCode)
        {
            Register(localeCode, new DefaultFormatter(localeCode));
        }

        /// <summary>
        /// Registers the czech slovak polish formatter.
        /// </summary>
        /// <param name="localeCode">The locale code.</param>
        private void RegisterCzechSlovakPolishFormatter(string localeCode)
        {
            Register(localeCode, new CzechSlovakPolishFormatter(localeCode));
        }
    }
}
