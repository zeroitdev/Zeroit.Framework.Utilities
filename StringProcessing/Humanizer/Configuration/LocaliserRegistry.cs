﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="LocaliserRegistry.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerConfiguration
{
    /// <summary>
    /// A registry of localised system components with their associated locales
    /// </summary>
    /// <typeparam name="TLocaliser">The type of the t localiser.</typeparam>
    public class LocaliserRegistry<TLocaliser>
        where TLocaliser : class
    {
        /// <summary>
        /// The localisers
        /// </summary>
        private readonly IDictionary<string, Func<CultureInfo, TLocaliser>> _localisers = new Dictionary<string, Func<CultureInfo, TLocaliser>>();
        /// <summary>
        /// The default localiser
        /// </summary>
        private readonly Func<CultureInfo, TLocaliser> _defaultLocaliser;

        /// <summary>
        /// Creates a localiser registry with the default localiser set to the provided value
        /// </summary>
        /// <param name="defaultLocaliser">The default localiser.</param>
        public LocaliserRegistry(TLocaliser defaultLocaliser)
        {
            _defaultLocaliser = (culture) => defaultLocaliser;
        }

        /// <summary>
        /// Creates a localiser registry with the default localiser factory set to the provided value
        /// </summary>
        /// <param name="defaultLocaliser">The default localiser.</param>
        public LocaliserRegistry(Func<CultureInfo, TLocaliser> defaultLocaliser)
        {
            _defaultLocaliser = defaultLocaliser;
        }

        /// <summary>
        /// Gets the localiser for the current thread's UI culture
        /// </summary>
        /// <returns>TLocaliser.</returns>
        public TLocaliser ResolveForUiCulture()
        {
            return ResolveForCulture(null);
        }

        /// <summary>
        /// Gets the localiser for the specified culture
        /// </summary>
        /// <param name="culture">The culture to retrieve localiser for. If not specified, current thread's UI culture is used.</param>
        /// <returns>TLocaliser.</returns>
        public TLocaliser ResolveForCulture(CultureInfo culture)
        {
            return FindLocaliser(culture ?? CultureInfo.CurrentUICulture)(culture);
        }

        /// <summary>
        /// Registers the localiser for the culture provided
        /// </summary>
        /// <param name="localeCode">The locale code.</param>
        /// <param name="localiser">The localiser.</param>
        public void Register(string localeCode, TLocaliser localiser)
        {
            _localisers[localeCode] = (culture) => localiser;
        }

        /// <summary>
        /// Registers the localiser factory for the culture provided
        /// </summary>
        /// <param name="localeCode">The locale code.</param>
        /// <param name="localiser">The localiser.</param>
        public void Register(string localeCode, Func<CultureInfo, TLocaliser> localiser)
        {
            _localisers[localeCode] = localiser;
        }

        /// <summary>
        /// Finds the localiser.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>Func&lt;CultureInfo, TLocaliser&gt;.</returns>
        Func<CultureInfo, TLocaliser> FindLocaliser(CultureInfo culture)
        {
            for (var c = culture; !string.IsNullOrEmpty(c?.Name); c = c.Parent)
            {
                if (_localisers.TryGetValue(c.Name, out var localiser))
                    return localiser;
            }

            return _defaultLocaliser;
        }
    }
}
