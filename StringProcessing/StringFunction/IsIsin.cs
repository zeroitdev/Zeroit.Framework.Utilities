// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="IsIsin.cs" company="Zeroit Dev Technologies">
//    This program contains Utilities for all C# programming activities.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Text.RegularExpressions;

namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //string s = "US0378331005";
        //Debug.Assert(s.IsIsin());

        //s = "AU0000XVGZA3";
        //Debug.Assert(s.IsIsin());

        //s = "GB0002634946";
        //Debug.Assert(s.IsIsin());

        //s = null;
        //Debug.Assert(!s.IsIsin());

        //s = "";
        //Debug.Assert(!s.IsIsin());

        //s = "us0378331005"; // lowercase
        //Debug.Assert(!s.IsIsin());

        //s = "US0378331004"; // wrong digit
        //Debug.Assert(!s.IsIsin());

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// The pattern
        /// </summary>
        private static readonly Regex Pattern = new Regex("[A-Z]{2}([A-Z0-9]){10}", RegexOptions.Compiled);

        /// <summary>
        /// Determines if a string is a valid ISIN (International Securities Identification Number) code
        /// True se a string passada for um ISIN válido
        /// </summary>
        /// <param name="isin">The isin.</param>
        /// <returns><c>true</c> if the specified isin is isin; otherwise, <c>false</c>.</returns>
        public static bool IsIsin(this string isin)
        {
            if (string.IsNullOrEmpty(isin))
            {
                return false;
            }
            if (!Pattern.IsMatch(isin))
            {
                return false;
            }

            var digits = new int[22];
            int index = 0;
            for (int i = 0; i < 11; i++)
            {
                char c = isin[i];
                if (c >= '0' && c <= '9')
                {
                    digits[index++] = c - '0';
                }
                else if (c >= 'A' && c <= 'Z')
                {
                    int n = c - 'A' + 10;
                    int tens = n / 10;
                    if (tens != 0)
                    {
                        digits[index++] = tens;
                    }
                    digits[index++] = n % 10;
                }
                else
                {
                    // Not a digit or upper-case letter.
                    return false;
                }
            }
            int sum = 0;
            for (int i = 0; i < index; i++)
            {
                int digit = digits[index - 1 - i];
                if (i % 2 == 0)
                {
                    digit *= 2;
                }
                sum += digit / 10;
                sum += digit % 10;
            }

            int checkDigit = isin[11] - '0';
            if (checkDigit < 0 || checkDigit > 9)
            {
                // Not a digit.
                return false;
            }
            int tensComplement = (sum % 10 == 0) ? 0 : ((sum / 10) + 1) * 10 - sum;
            return checkDigit == tensComplement;
        }

    }
}
