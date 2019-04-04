// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="IsNumeric.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

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
        /// Determines whether the specified do conversion is numeric.
        /// </summary>
        /// <param name="theValue">The value.</param>
        /// <param name="doConversion">if set to <c>true</c> [do conversion].</param>
        /// <returns><c>true</c> if the specified do conversion is numeric; otherwise, <c>false</c>.</returns>
        public static bool IsNumeric(this string theValue, bool doConversion = true)
        {
            long retNum;
            return long.TryParse(theValue, System.Globalization.NumberStyles.Integer, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
        }

        /// <summary>
        /// Determines whether the specified i is numeric.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="i">The i.</param>
        /// <returns><c>true</c> if the specified i is numeric; otherwise, <c>false</c>.</returns>
        public static bool IsNumeric(this string value, int i=0)
        {
            Regex regex = new Regex(@"[0-9]");
            return regex.IsMatch(value);
        }


        /// <summary>
        /// True, if the string can be parse as Double respective Int32
        /// Spaces are not considred.
        /// </summary>
        /// <param name="s">input string</param>
        /// <param name="floatpoint">true, if Double is considered,
        /// otherwhise Int32 is considered.</param>
        /// <returns>true, if the string contains only digits or float-point</returns>
        public static bool IsNumber(this string s, bool floatpoint)
        {
            int i;
            double d;
            string withoutWhiteSpace = s.RemoveSpaces();
            if (floatpoint)
                return double.TryParse(withoutWhiteSpace, NumberStyles.Any,
                    Thread.CurrentThread.CurrentUICulture, out d);
            else
                return int.TryParse(withoutWhiteSpace, out i);
        }

        /// <summary>
        /// True, if the string contains only digits or float-point.
        /// Spaces are not considred.
        /// </summary>
        /// <param name="s">input string</param>
        /// <param name="floatpoint">true, if float-point is considered</param>
        /// <returns>true, if the string contains only digits or float-point</returns>
        public static bool IsNumberOnly(this string s, bool floatpoint)
        {
            s = s.Trim();
            if (s.Length == 0)
                return false;
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                {
                    if (floatpoint && (c == '.' || c == ','))
                        continue;
                    return false;
                }
            }
            return true;
        }


    }
}
