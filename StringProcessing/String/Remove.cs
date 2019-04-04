// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Remove.cs" company="Zeroit Dev Technologies">
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
        /// Removes from left.
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <param name="Length">The length.</param>
        /// <returns>System.String.</returns>
        public static string RemoveFromLeft(string Source, int Length)
        {
            if (Length >= Source.Length)
                return string.Empty;
            return Source.Substring(Length, Source.Length - Length);
        }
        /// <summary>
        /// Removes from right.
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <param name="Length">The length.</param>
        /// <returns>System.String.</returns>
        public static string RemoveFromRight(string Source, int Length)
        {
            if (Length >= Source.Length)
                return string.Empty;
            return Source.Substring(0, Source.Length - Length);
        }

    }
}
