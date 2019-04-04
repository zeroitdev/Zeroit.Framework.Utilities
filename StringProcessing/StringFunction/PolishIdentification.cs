// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="PolishIdentification.cs" company="Zeroit Dev Technologies">
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
namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //string nip = "1234567890";
        //string regon = "123456789";
        //string pesel = "12345678901";

        //Console.WriteLine(nip.IsValidNIP()? "NIP is valid" : "NIP is not valid");
        //Console.WriteLine(regon.IsValidREGON()? "REGON is valid" : "REGON is not valid");
        //Console.WriteLine(pesel.IsValidPESEL()? "PESEL is valid" : "PESEL is not valid");

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Determines whether [is valid nip] [the specified input].
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns><c>true</c> if [is valid nip] [the specified input]; otherwise, <c>false</c>.</returns>
        public static bool IsValidNIP(this string input)
        {
            int[] weights = { 6, 5, 7, 2, 3, 4, 5, 6, 7 };
            bool result = false;
            if (input.Length == 10)
            {
                int controlSum = CalculateControlSum(input, weights);
                int controlNum = controlSum % 11;
                if (controlNum == 10)
                {
                    controlNum = 0;
                }
                int lastDigit = int.Parse(input[input.Length - 1].ToString());
                result = controlNum == lastDigit;
            }
            return result;
        }

        /// <summary>
        /// Determines whether [is valid regon] [the specified input].
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns><c>true</c> if [is valid regon] [the specified input]; otherwise, <c>false</c>.</returns>
        public static bool IsValidREGON(this string input)
        {
            int controlSum;
            if (input.Length == 7 || input.Length == 9)
            {
                int[] weights = { 8, 9, 2, 3, 4, 5, 6, 7 };
                int offset = 9 - input.Length;
                controlSum = CalculateControlSum(input, weights, offset);
            }
            else if (input.Length == 14)
            {
                int[] weights = { 2, 4, 8, 5, 0, 9, 7, 3, 6, 1, 2, 4, 8 };
                controlSum = CalculateControlSum(input, weights);
            }
            else
            {
                return false;
            }

            int controlNum = controlSum % 11;
            if (controlNum == 10)
            {
                controlNum = 0;
            }
            int lastDigit = int.Parse(input[input.Length - 1].ToString());

            return controlNum == lastDigit;
        }

        /// <summary>
        /// Determines whether [is valid pesel] [the specified input].
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns><c>true</c> if [is valid pesel] [the specified input]; otherwise, <c>false</c>.</returns>
        public static bool IsValidPESEL(this string input)
        {
            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            bool result = false;
            if (input.Length == 11)
            {
                int controlSum = CalculateControlSum(input, weights);
                int controlNum = controlSum % 10;
                controlNum = 10 - controlNum;
                if (controlNum == 10)
                {
                    controlNum = 0;
                }
                int lastDigit = int.Parse(input[input.Length - 1].ToString());
                result = controlNum == lastDigit;
            }
            return result;
        }

        /// <summary>
        /// Calculates the control sum.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="weights">The weights.</param>
        /// <param name="offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        private static int CalculateControlSum(string input, int[] weights, int offset = 0)
        {
            int controlSum = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                controlSum += weights[i + offset] * int.Parse(input[i].ToString());
            }
            return controlSum;
        }

    }
}
