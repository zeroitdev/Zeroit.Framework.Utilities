// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ContainsAll.cs" company="Zeroit Dev Technologies">
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

        //string value = "Kevin from Taiwan.";
        //string[] values = new string[] { "Kevin", "Taiwan" };
        //    if(value.ContainsAll(values))
        //{
        //    Console.WriteLine("Hi Kevin, we love Taiwan!");
        //}

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Check whether the specified string contains an array of strings for each.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="values">The values.</param>
        /// <returns><c>true</c> if the specified values contains all; otherwise, <c>false</c>.</returns>
        public static bool ContainsAll(
                this string value,
                params string[] values)
        {
                foreach (string one in values)
                {
                    if (!value.Contains(one))
                    {
                        return false;
                    }
                }
                return true;
        }

        /// <summary>
        /// Check whether the specified string contains an array of strings for each.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="values">The values.</param>
        /// <returns><c>true</c> if the specified values contains all; otherwise, <c>false</c>.</returns>

        public static bool IncludesAll(this String str, params String[] values)
        {
            if (!String.IsNullOrEmpty(str) || values.Length > 0)
            {
                foreach (String value in values)
                {
                    if (!str.Contains(value))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
