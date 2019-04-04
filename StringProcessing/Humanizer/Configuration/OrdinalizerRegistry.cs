// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="OrdinalizerRegistry.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.Ordinalizers;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerConfiguration
{
    /// <summary>
    /// Class OrdinalizerRegistry.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerConfiguration.LocaliserRegistry{Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.Ordinalizers.IOrdinalizer}" />
    internal class OrdinalizerRegistry : LocaliserRegistry<IOrdinalizer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrdinalizerRegistry"/> class.
        /// </summary>
        public OrdinalizerRegistry() : base(new DefaultOrdinalizer())
        {
            Register("de", new GermanOrdinalizer());
            Register("en", new EnglishOrdinalizer());
            Register("es", new SpanishOrdinalizer());
            Register("it", new ItalianOrdinalizer());
            Register("nl", new DutchOrdinalizer());
            Register("pt", new PortugueseOrdinalizer());
            Register("ro", new RomanianOrdinalizer());
            Register("ru", new RussianOrdinalizer());
            Register("tr", new TurkishOrdinalizer());
            Register("uk", new UkrainianOrdinalizer());
        }
    }
}
