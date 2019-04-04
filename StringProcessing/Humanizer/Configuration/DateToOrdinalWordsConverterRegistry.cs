// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="DateToOrdinalWordsConverterRegistry.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.DateToOrdinalWords;
namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerConfiguration
{
    /// <summary>
    /// Class DateToOrdinalWordsConverterRegistry.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerConfiguration.LocaliserRegistry{Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.DateToOrdinalWords.IDateToOrdinalWordConverter}" />
    internal class DateToOrdinalWordsConverterRegistry : LocaliserRegistry<IDateToOrdinalWordConverter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateToOrdinalWordsConverterRegistry"/> class.
        /// </summary>
        public DateToOrdinalWordsConverterRegistry() : base(new DefaultDateToOrdinalWordConverter())
        {
            Register("en-UK", new DefaultDateToOrdinalWordConverter());
            Register("de", new DefaultDateToOrdinalWordConverter());
            Register("en-US", new UsDateToOrdinalWordsConverter());
        }
    }
}
