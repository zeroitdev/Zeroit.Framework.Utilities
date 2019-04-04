// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ToInt.cs" company="Zeroit Dev Technologies">
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

        //Console.WriteLine(s.ToInt(1));
        //s = "a3";
        //Console.WriteLine(s.ToInt(100));

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// It converts string to integer and assigns a default value if the conversion is not a success.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="defaultInt">The default int.</param>
        /// <returns>System.Int32.</returns>
        public static int ToInt(this string number, int defaultInt)
        {
            int resultNum = defaultInt;
            try
            {
                if (!string.IsNullOrEmpty(number))
                    resultNum = Convert.ToInt32(number);
            }
            catch
            {
            }
            return resultNum;
        }

        /// <summary>
        /// Convert string to int32 .
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Int32.</returns>
        public static int ToInt32(this string value)
        {
            int number;

            Int32.TryParse(value, out number);

            return number;
        }
    }
}
