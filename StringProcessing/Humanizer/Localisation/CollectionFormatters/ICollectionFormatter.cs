// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="ICollectionFormatter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.CollectionFormatters
{
    /// <summary>
    /// An interface you should implement to localize Humanize for collections
    /// </summary>
    public interface ICollectionFormatter
    {
        /// <summary>
        /// Formats the collection for display, calling ToString() on each object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns>System.String.</returns>
        string Humanize<T>(IEnumerable<T> collection);

        /// <summary>
        /// Formats the collection for display, calling <paramref name="objectFormatter" /> on each element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="objectFormatter">The object formatter.</param>
        /// <returns>System.String.</returns>
        string Humanize<T>(IEnumerable<T> collection, Func<T, string> objectFormatter);

        /// <summary>
        /// Formats the collection for display, calling <paramref name="objectFormatter" /> on each element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="objectFormatter">The object formatter.</param>
        /// <returns>System.String.</returns>
        string Humanize<T>(IEnumerable<T> collection, Func<T, object> objectFormatter);

        /// <summary>
        /// Formats the collection for display, calling ToString() on each object
        /// and using <paramref name="separator" /> before the final item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>System.String.</returns>
        string Humanize<T>(IEnumerable<T> collection, string separator);

        /// <summary>
        /// Formats the collection for display, calling <paramref name="objectFormatter" /> on each element.
        /// and using <paramref name="separator" /> before the final item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="objectFormatter">The object formatter.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>System.String.</returns>
        string Humanize<T>(IEnumerable<T> collection, Func<T, string> objectFormatter, string separator);

        /// <summary>
        /// Formats the collection for display, calling <paramref name="objectFormatter" /> on each element.
        /// and using <paramref name="separator" /> before the final item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="objectFormatter">The object formatter.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>System.String.</returns>
        string Humanize<T>(IEnumerable<T> collection, Func<T, object> objectFormatter, string separator);
    }
}
