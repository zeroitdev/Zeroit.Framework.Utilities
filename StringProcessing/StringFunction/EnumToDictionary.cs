// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="EnumToDictionary.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
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

        //var dictionary = typeof(UriFormat).EnumToDictionary();

        // Output returns
        //key => value
        //SafeUnescaped => 3
        //Unescaped => 2
        //UriEscaped => 1


        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Converts Enumeration type into a dictionary of names and values
        /// </summary>
        /// <param name="t">Enum type</param>
        /// <returns>IDictionary&lt;System.String, System.Int32&gt;.</returns>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="InvalidCastException">object is not an Enumeration</exception>
        public static IDictionary<string, int> EnumToDictionary(this Type t)
        {
            if (t == null) throw new NullReferenceException();
            if (!t.IsEnum) throw new InvalidCastException("object is not an Enumeration");

            string[] names = Enum.GetNames(t);
            Array values = Enum.GetValues(t);

            return (from i in Enumerable.Range(0, names.Length)
                    select new { Key = names[i], Value = (int)values.GetValue(i) })
                .ToDictionary(k => k.Key, k => k.Value);
        }

    }
}
