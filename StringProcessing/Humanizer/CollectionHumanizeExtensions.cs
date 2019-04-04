// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="CollectionHumanizeExtensions.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
