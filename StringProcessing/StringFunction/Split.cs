// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Split.cs" company="Zeroit Dev Technologies">
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

        //string[] A = "Ahmer-Sohail-Shamsi".Split(6, 6);
        //MessageBox.Show(A[0]);
        //MessageBox.Show(A[1]);
        //MessageBox.Show(A[2]);


        //OUTPUT:

        //Sohail
        //Ahmer-
        //-Shamsi


        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Extension method to split string by number of characters.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="startindex">The zero-based position to split the specified string.</param>
        /// <param name="length">The number of characters to split</param>
        /// <returns>System.String[].</returns>
        public static string[] Split(this string str, int startindex, int length)
        {
            string[] strrtn = new string[3];
            if (startindex == 0)
                strrtn = new string[] { str.Substring(startindex, length), str.Remove(startindex, length) };
            else if (startindex > 0)
                strrtn = new string[] { str.Substring(startindex, length), str.Substring(0, startindex), str.Remove(0, length + startindex) };
            return strrtn;
        }

    }
}
