// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="ICollectionFormatter.cs" company="Zeroit Dev Technologies">
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
