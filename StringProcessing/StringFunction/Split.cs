// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Split.cs" company="Zeroit Dev Technologies">
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
