// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="IsPrime.cs" company="Zeroit Dev Technologies">
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

        //bool b = 7.IsPrime(); // true

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Returns true when a integer is a prime.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns><c>true</c> if the specified number is prime; otherwise, <c>false</c>.</returns>
        public static bool IsPrime(this int number)
        {
            if ((number % 2) == 0)
            {
                return number == 2;
            }
            int sqrt = (int)Math.Sqrt(number);
            for (int t = 3; t <= sqrt; t = t + 2)
            {
                if (number % t == 0)
                {
                    return false;
                }
            }
            return number != 1;
        }

    }
}
