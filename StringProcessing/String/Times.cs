// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Times.cs" company="Zeroit Dev Technologies">
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

        /// <summary>
        /// Fills the pattern.
        /// </summary>
        /// <param name="Pattern">The pattern.</param>
        /// <param name="Times">The times.</param>
        /// <returns>System.String.</returns>
        public static string FillPattern(string Pattern, int Times)
        {
            string Str = string.Empty;
            for (int i = 0; i < Times; i++)
                Str += Pattern;
            return Str;
        }
    }		
}
