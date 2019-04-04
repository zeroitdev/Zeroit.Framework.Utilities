// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="EqualsAny.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //string custName = "foo";
        //bool isMatch = (custName.EqualsAny("bar", "baz", "FOO")); //true

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Check that the given string is in a list of potential matches.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="args">The arguments.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool EqualsAny(this string str, params string[] args)
        {
            return args.Any(x =>
                StringComparer.InvariantCultureIgnoreCase.Equals(x, str));
        }

    }
}
