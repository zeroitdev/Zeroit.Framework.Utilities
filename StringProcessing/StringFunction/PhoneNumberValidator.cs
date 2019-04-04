// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="PhoneNumberValidator.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class PhoneNumberValidator.
    /// </summary>
    public class PhoneNumberValidator
    {
        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// Gets or sets the phone number digits.
        /// </summary>
        /// <value>The phone number digits.</value>
        public int PhoneNumberDigits { get; set; }
        /// <summary>
        /// Gets or sets the cached phone number.
        /// </summary>
        /// <value>The cached phone number.</value>
        public string CachedPhoneNumber { get; set; }

        //private Dictionary<int, string> VaildAreaCodes()
        //{
        //    return new Dictionary<int, string>
        //    {
        //        [3] = "0",
        //        [4] = "27"
        //    };
        //}

        /// <summary>
        /// The vaild area codes
        /// </summary>
        private Dictionary<int, string> VaildAreaCodes = new Dictionary<int, string>()
        {
            {3,"0" },
            {4,"27" }
        };

        /// <summary>
        /// Determines whether the specified value is integer.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if the specified value is integer; otherwise, <c>false</c>.</returns>
        private bool IsInteger(string value)
        {
            return int.TryParse(value, out int result);
        }

        /// <summary>
        /// Gets the consecutive chars in phone number string.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>System.String.</returns>
        private string GetConsecutiveCharsInPhoneNumberStr(string phoneNumber)
        {
            switch (PhoneNumberDigits)
            {
                case 0:
                case 10:
                    PhoneNumberDigits = 10;
                    return phoneNumber.Substring(phoneNumber.Length - 7);

                case 11:
                    return phoneNumber.Substring(phoneNumber.Length - 8);

                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Determines whether [is valid area code] [the specified phone number].
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="areaCode">The area code.</param>
        /// <returns><c>true</c> if [is valid area code] [the specified phone number]; otherwise, <c>false</c>.</returns>
        private bool IsValidAreaCode(ref string phoneNumber, string areaCode)
        {
            if (!IsInteger(areaCode))
            {
                ErrorMessage = "Area code characters of Phone Number value should only contain integers.";
                return false;
            }

            var areaCodeLength = areaCode.Length;
            var invalidAreaCodeMessage = "Phone Number value contains invalid area code.";
            switch (areaCodeLength)
            {
                case 2:
                    phoneNumber = string.Concat("0", phoneNumber);
                    return true;

                case 3:
                    if (!areaCode.StartsWith(VaildAreaCodes[3]))
                        ErrorMessage = invalidAreaCodeMessage;
                    return string.IsNullOrWhiteSpace(ErrorMessage) ? true : false;

                case 4:
                    if (areaCode.StartsWith(VaildAreaCodes[4]))
                    {
                        phoneNumber = string.Concat("0", phoneNumber.Remove(0, 2)); // replace first two charaters with zero
                        return true;
                    }
                    ErrorMessage = invalidAreaCodeMessage;
                    return false;

                default:
                    ErrorMessage = invalidAreaCodeMessage;
                    return false;
            }
        }


        /// <summary>
        /// Determines whether [is valid phone number] [the specified phone number].
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns><c>true</c> if [is valid phone number] [the specified phone number]; otherwise, <c>false</c>.</returns>
        public bool IsValidPhoneNumber(ref string phoneNumber)
        {
            CachedPhoneNumber = phoneNumber;

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                ErrorMessage = "Phone Number value should not be equivalent to null.";
                return false;
            }

            phoneNumber = Regex.Replace(phoneNumber, " {2,}", string.Empty); // remove all whitespaces
            phoneNumber = Regex.Replace(phoneNumber, "[^0-9]", string.Empty); // remove all non numeric characters

            var lastConsecutiveCharsInPhoneNumberStr = GetConsecutiveCharsInPhoneNumberStr(phoneNumber);

            if (string.IsNullOrWhiteSpace(lastConsecutiveCharsInPhoneNumberStr))
            {
                ErrorMessage = "Phone Number value not supported.";
                return false;
            }

            if (!IsInteger(lastConsecutiveCharsInPhoneNumberStr))
            {
                ErrorMessage = "Last consecutive characters of Phone Number value should only contain integers.";
                return false;
            }

            var phoneNumberAreaCode = phoneNumber.Replace(lastConsecutiveCharsInPhoneNumberStr, "");

            if (!IsValidAreaCode(ref phoneNumber, phoneNumberAreaCode))
            {
                return false;
            }

            if (phoneNumber.Length != PhoneNumberDigits)
            {
                ErrorMessage = string.Format("Phone Number value should contain {0} characters instead of {1} characters.", PhoneNumberDigits, phoneNumber.Length);
                return false;
            }

            return true;
        }
    }
}
