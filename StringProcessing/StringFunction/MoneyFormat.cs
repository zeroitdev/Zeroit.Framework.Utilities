// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="MoneyFormat.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //value in TextBox : 12345
        //textbox1.text.GetStrMoney() => 12,345

        //value in TextBox : 1234567.325
        //textbox1.text.GetStrMoney() => 1,234,567.325

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Convert integer or float money data to separated comma string that is simple to read .
        /// </summary>
        /// <param name="digit">The digit.</param>
        /// <returns>System.String.</returns>
        public static string MoneyFormat(this string digit)
        {
            string afterPoint = string.Empty;
            string strDigit = digit;
            int pos = digit.IndexOf('.');
            if (digit.IndexOf('.') != -1)
            {
                strDigit = digit.Substring(0, pos);
                afterPoint = digit.Substring(pos, digit.Length - pos);
            }

            int len = strDigit.Length;
            if (len <= 3)
                return digit;

            strDigit = strDigit.ReverseString();
            string result = string.Empty;
            for (int i = 0; i < len; i++)
            {
                result += strDigit[i];
                if ((i + 1) % 3 == 0 && i != len - 1)
                    result += ',';
            }

            if (string.IsNullOrEmpty(afterPoint))
                result = result.ReverseString();
            else result = result.ReverseString() + afterPoint;
            return result;
        }

        /// <summary>
        /// Reverses the string.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>System.String.</returns>
        public static string ReverseString(this string s)
        {
            char[] c = s.ToCharArray();
            string ts = string.Empty;

            for (int i = c.Length - 1; i >= 0; i--)
                ts += c[i].ToString();

            return ts;
        }

    }
}
