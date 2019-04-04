// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="LinqExtender.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

namespace Zeroit.Framework.Utilities.LinqExtender
{
    /// <summary>
    /// Class LinqExtender.
    /// </summary>
    public static class LinqExtender
    {
        /// <summary>
        /// Descendantses the specified descend by.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="DescendBy">The descend by.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public static IEnumerable<T> Descendants<T>(this IEnumerable<T> source,
            Func<T, IEnumerable<T>> DescendBy)
        {
            foreach (T value in source)
            {
                yield return value;

                foreach (T child in DescendBy(value).Descendants<T>(DescendBy))
                {
                    yield return child;
                }
            }
        }
    }
}
