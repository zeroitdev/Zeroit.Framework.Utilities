// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ToDecimal.cs" company="Zeroit Dev Technologies">
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

        //string number = "1.2";
        //decimal converted = number.Decimal();

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Convert string to decimal.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Decimal.</returns>
        public static decimal ToDecimal(this string value)
        {
            decimal number;

            Decimal.TryParse(value, out number);

            return number;
        }

    }
}
