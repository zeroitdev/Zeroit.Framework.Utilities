// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="PhoneNumber.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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



        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Checks to be sure a phone number contains 10 digits as per American phone numbers.
        /// If 'IsRequired' is true, then an empty string will return False.
        /// If 'IsRequired' is false, then an empty string will return True.
        /// </summary>
        /// <param name="phone">The phone.</param>
        /// <param name="IsRequired">if set to <c>true</c> [is required].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ValidatePhoneNumber(this string phone, bool IsRequired)
        {
            if (string.IsNullOrEmpty(phone) & !IsRequired)
                return true;

            if (string.IsNullOrEmpty(phone) & IsRequired)
                return false;

            var cleaned = phone.RemoveNonNumeric();
            if (IsRequired)
            {
                if (cleaned.Length == 10)
                    return true;
                else
                    return false;
            }
            else
            {
                if (cleaned.Length == 0)
                    return true;
                else if (cleaned.Length > 0 & cleaned.Length < 10)
                    return false;
                else if (cleaned.Length == 10)
                    return true;
                else
                    return false; // should never get here
            }
        }

        /// <summary>
        /// Removes all non numeric characters from a string
        /// </summary>
        /// <param name="phone">The phone.</param>
        /// <returns>System.String.</returns>
        public static string RemoveNonNumeric(this string phone)
        {
            return Regex.Replace(phone, @"[^0-9]+", "");
        }

        /// <summary>
        /// Allows phone number of the format: NPA = [2-9][0-8][0-9] Nxx = [2-9]      [0-9][0-9] Station = [0-9][0-9][0-9][0-9]
        /// </summary>
        /// <param name="strPhone">The string phone.</param>
        /// <returns><c>true</c> if [is valid usa phone number] [the specified string phone]; otherwise, <c>false</c>.</returns>
        public static bool IsValidUSAPhoneNumber(string strPhone)
        {
            string regExPattern = @"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$";
            return MatchStringFromRegex(strPhone, regExPattern);
        }


        // Function which is used in IsValidUSPhoneNumber function
        /// <summary>
        /// Matches the string from regex.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="regexstr">The regexstr.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private static bool MatchStringFromRegex(string str, string regexstr)
        {
            str = str.Trim();
            System.Text.RegularExpressions.Regex pattern = new System.Text.RegularExpressions.Regex(regexstr);
            return pattern.IsMatch(str);
        }


        

    }
}
