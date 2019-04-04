// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="CollectionHumanizeExtensions.cs" company="Zeroit Dev Technologies">
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
using Zeroit.Framework.Utilities.StringProcessing.HumanizerConfiguration;


namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Humanizes an IEnumerable into a human readable list
    /// </summary>
    public static class CollectionHumanizeExtensions
    {
        /// <summary>
        /// Formats the collection for display, calling ToString() on each object and
        /// using the default separator for the current culture.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns>System.String.</returns>
        public static string Humanize<T>(this IEnumerable<T> collection)
        {
            return Configurator.CollectionFormatter.Humanize(collection);
        }

        /// <summary>
        /// Formats the collection for display, calling <paramref name="displayFormatter" /> on each element
        /// and using the default separator for the current culture.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="displayFormatter">The display formatter.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentNullException">displayFormatter</exception>
        public static string Humanize<T>(this IEnumerable<T> collection, Func<T, string> displayFormatter)
        {
            if (displayFormatter == null)
                throw new ArgumentNullException(nameof(displayFormatter));

            return Configurator.CollectionFormatter.Humanize(collection, displayFormatter);
        }

        /// <summary>
        /// Formats the collection for display, calling <paramref name="displayFormatter" /> on each element
        /// and using the default separator for the current culture.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="displayFormatter">The display formatter.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentNullException">displayFormatter</exception>
        public static string Humanize<T>(this IEnumerable<T> collection, Func<T, object> displayFormatter)
        {
            if (displayFormatter == null)
                throw new ArgumentNullException(nameof(displayFormatter));

            return Configurator.CollectionFormatter.Humanize(collection, displayFormatter);
        }

        /// <summary>
        /// Formats the collection for display, calling ToString() on each object
        /// and using the provided separator.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>System.String.</returns>
        public static string Humanize<T>(this IEnumerable<T> collection, string separator)
        {

            return Configurator.CollectionFormatter.Humanize(collection, separator);
        }

        /// <summary>
        /// Formats the collection for display, calling <paramref name="displayFormatter" /> on each element
        /// and using the provided separator.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="displayFormatter">The display formatter.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentNullException">displayFormatter</exception>
        public static string Humanize<T>(this IEnumerable<T> collection, Func<T, string> displayFormatter, string separator)
        {
            if (displayFormatter == null)
                throw new ArgumentNullException(nameof(displayFormatter));

            return Configurator.CollectionFormatter.Humanize(collection, displayFormatter, separator);
        }

        /// <summary>
        /// Formats the collection for display, calling <paramref name="displayFormatter" /> on each element
        /// and using the provided separator.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="displayFormatter">The display formatter.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentNullException">displayFormatter</exception>
        public static string Humanize<T>(this IEnumerable<T> collection, Func<T, object> displayFormatter, string separator)
        {
            if (displayFormatter == null)
                throw new ArgumentNullException(nameof(displayFormatter));

            return Configurator.CollectionFormatter.Humanize(collection, displayFormatter, separator);
        }
    }
}
