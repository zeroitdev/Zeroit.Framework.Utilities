// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="DefaultCollectionFormatter.cs" company="Zeroit Dev Technologies">
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
using System.Linq;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.CollectionFormatters
{
    /// <summary>
    /// Class DefaultCollectionFormatter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.CollectionFormatters.ICollectionFormatter" />
    class DefaultCollectionFormatter : ICollectionFormatter
    {
        /// <summary>
        /// The default separator
        /// </summary>
        protected string DefaultSeparator = "";

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultCollectionFormatter"/> class.
        /// </summary>
        /// <param name="defaultSeparator">The default separator.</param>
        public DefaultCollectionFormatter(string defaultSeparator)
        {
            DefaultSeparator = defaultSeparator;
        }

        /// <summary>
        /// Formats the collection for display, calling ToString() on each object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns>System.String.</returns>
        public virtual string Humanize<T>(IEnumerable<T> collection)
        {
            return Humanize(collection, o => o?.ToString(), DefaultSeparator);
        }

        /// <summary>
        /// Formats the collection for display, calling <paramref name="objectFormatter" /> on each element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="objectFormatter">The object formatter.</param>
        /// <returns>System.String.</returns>
        public virtual string Humanize<T>(IEnumerable<T> collection, Func<T, string> objectFormatter)
        {
            return Humanize(collection, objectFormatter, DefaultSeparator);
        }

        /// <summary>
        /// Formats the collection for display, calling <paramref name="objectFormatter" /> on each element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="objectFormatter">The object formatter.</param>
        /// <returns>System.String.</returns>
        public string Humanize<T>(IEnumerable<T> collection, Func<T, object> objectFormatter)
        {
            return Humanize(collection, objectFormatter, DefaultSeparator);
        }

        /// <summary>
        /// Formats the collection for display, calling ToString() on each object
        /// and using <paramref name="separator" /> before the final item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>System.String.</returns>
        public virtual string Humanize<T>(IEnumerable<T> collection, string separator)
        {
            return Humanize(collection, o => o?.ToString(), separator);
        }

        /// <summary>
        /// Formats the collection for display, calling <paramref name="objectFormatter" /> on each element.
        /// and using <paramref name="separator" /> before the final item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="objectFormatter">The object formatter.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentNullException">
        /// collection
        /// or
        /// objectFormatter
        /// </exception>
        public virtual string Humanize<T>(IEnumerable<T> collection, Func<T, string> objectFormatter, string separator)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (objectFormatter == null) throw new ArgumentNullException(nameof(objectFormatter));

            return HumanizeDisplayStrings(
                collection.Select(objectFormatter),
                separator);
        }

        /// <summary>
        /// Formats the collection for display, calling <paramref name="objectFormatter" /> on each element.
        /// and using <paramref name="separator" /> before the final item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="objectFormatter">The object formatter.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentNullException">
        /// collection
        /// or
        /// objectFormatter
        /// </exception>
        public string Humanize<T>(IEnumerable<T> collection, Func<T, object> objectFormatter, string separator)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (objectFormatter == null) throw new ArgumentNullException(nameof(objectFormatter));

            return HumanizeDisplayStrings(
                collection.Select(objectFormatter).Select(o => o?.ToString()),
                separator);
        }

        /// <summary>
        /// Humanizes the display strings.
        /// </summary>
        /// <param name="strings">The strings.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>System.String.</returns>
        private string HumanizeDisplayStrings(IEnumerable<string> strings, string separator)
        {
            var itemsArray = strings
                .Select(item => item == null ? string.Empty : item.Trim())
                .Where(item => !string.IsNullOrWhiteSpace(item))
                .ToArray();

            var count = itemsArray.Length;

            if (count == 0)
                return "";

            if (count == 1)
                return itemsArray[0];

            var itemsBeforeLast = itemsArray.Take(count - 1);
            var lastItem = itemsArray.Skip(count - 1).First();

            return string.Format(GetConjunctionFormatString(count),
                string.Join(", ", itemsBeforeLast),
                separator,
                lastItem);
        }

        /// <summary>
        /// Gets the conjunction format string.
        /// </summary>
        /// <param name="itemCount">The item count.</param>
        /// <returns>System.String.</returns>
        protected virtual string GetConjunctionFormatString(int itemCount) => "{0} {1} {2}";
    }
}
