// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Slice.cs" company="Zeroit Dev Technologies">
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

        //string result = "0123456789".Slice(4, 8); // Returns "45678"
        //string result = result.Slice(2, 3); // Returns "67"

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Extracts a section of the string given a start and end index within the string.
        /// </summary>
        /// <param name="value">The given string</param>
        /// <param name="start">The start index to slice from.</param>
        /// <param name="end">The end index to slice to.</param>
        /// <returns>The section of string sliced.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// start - start cannot be less than zero
        /// or
        /// end
        /// or
        /// start - start may not be greater than end
        /// </exception>
        public static string Slice(this string value, int start, int end)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            int upperBound = value.Length - 1;

            //
            // Check the arguments
            //
            if (start < 0)
            {
                throw new ArgumentOutOfRangeException("start", "start cannot be less than zero");
            }

            if (end > upperBound)
            {
                throw new ArgumentOutOfRangeException("end", string.Format("end cannot be greater than {0}", upperBound));
            }

            if (start > end)
            {
                throw new ArgumentOutOfRangeException("start", "start may not be greater than end");
            }

            return value.Substring(start, (end - start + 1));
        }

    }
}
