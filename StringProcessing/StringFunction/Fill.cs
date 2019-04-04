// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Fill.cs" company="Zeroit Dev Technologies">
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

        //int transactionsCount = GetTransactionsCount();
        //string message = "We had {0} transactions.".Fill(transactionsCount);

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Different way to use String.Format.
        /// </summary>
        /// <param name="original">The original.</param>
        /// <param name="values">The values.</param>
        /// <returns>System.String.</returns>
        public static string Fill(this string original, params object[] values)
        {
            return string.Format(original, values);
        }

    }
}
