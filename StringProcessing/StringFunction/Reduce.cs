// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Reduce.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//



        //---------------------------------Implementation-----------------------------//


        /// <summary>
        /// Reduce string to shorter preview which is optionally ended by some string (...).
        /// </summary>
        /// <param name="s">string to reduce</param>
        /// <param name="count">Length of returned string including endings.</param>
        /// <param name="endings">optional edings of reduced text</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.Exception">Failed to reduce to less then endings length.</exception>
        /// <example>
        /// string description = "This is very long description of something";
        /// string preview = description.Reduce(20,"...");
        /// produce -&gt; "This is very long..."
        /// </example>
        public static string Reduce(this string s, int count, string endings)
        {
            if (count < endings.Length)
                throw new Exception("Failed to reduce to less then endings length.");
            int sLength = s.Length;
            int len = sLength;
            if (endings != null)
                len += endings.Length;
            if (count > sLength)
                return s; //it's too short to reduce
            s = s.Substring(0, sLength - len + count);
            if (endings != null)
                s += endings;
            return s;
        }


    }
}
