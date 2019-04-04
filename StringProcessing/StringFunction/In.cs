// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="In.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //if (product.Category.In("Electronics", "Computers")
        //{
        //// do something
        //}

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Returns true if this string is any of the provided strings.
        /// Equivalent to IN operator in SQL.
        /// It eliminates the need to write something like 'if (foo == "foo1" || foo == "foo2" || foo == "foo3")'.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="values">The values.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool IN(this string s, params string[] values)
        {
            return values.Any(x => x.Equals(s));
        }

    }
}
