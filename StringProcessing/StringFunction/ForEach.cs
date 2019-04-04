// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ForEach.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //string[] names = new string[] { "C#", "Java" };
        //names.ForEach(i => Console.WriteLine(i));

        //IEnumerable<int> namesLen = names.ForEach(i => i.Length);
        //namesLen.ForEach(i => Console.WriteLine(i));

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Shortcut for foreach and create new list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The array.</param>
        /// <param name="act">The act.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> array, Action<T> act)
        {
            foreach (var i in array)
                act(i);
            return array;
        }

        /// <summary>
        /// Shortcut for foreach and create new list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr">The arr.</param>
        /// <param name="act">The act.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public static IEnumerable<T> ForEach<T>(this IEnumerable arr, Action<T> act)
        {
            return arr.Cast<T>().ForEach<T>(act);
        }

        /// <summary>
        /// Shortcut for foreach and create new list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="RT">The type of the rt.</typeparam>
        /// <param name="array">The array.</param>
        /// <param name="func">The function.</param>
        /// <returns>IEnumerable&lt;RT&gt;.</returns>
        public static IEnumerable<RT> ForEach<T, RT>(this IEnumerable<T> array, Func<T, RT> func)
        {
            var list = new List<RT>();
            foreach (var i in array)
            {
                var obj = func(i);
                if (obj != null)
                    list.Add(obj);
            }
            return list;
        }

    }
}
