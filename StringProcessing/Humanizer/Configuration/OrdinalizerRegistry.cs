// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="OrdinalizerRegistry.cs" company="Zeroit Dev Technologies">
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
