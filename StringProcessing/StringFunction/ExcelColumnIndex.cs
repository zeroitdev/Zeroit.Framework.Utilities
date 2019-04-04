// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ExcelColumnIndex.cs" company="Zeroit Dev Technologies">
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

        //int bIndex = "B".ExcelColumnIndex();

        //int amIndex = "AM".ExcelColumnIndex();

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Returns the excel column index from a column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.Int32.</returns>
        public static int ExcelColumnIndex(this string columnName)
        {
            int number = 0;
            int pow = 1;

            for (int i = columnName.Length - 1; i >= 0; i--)
            {
                number += (columnName[i] - 'A' + 1) * pow;
                pow *= 26;
            }

            return number;
        }

    }
}
