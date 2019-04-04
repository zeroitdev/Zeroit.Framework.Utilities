// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="ITruncator.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Can truncate a string.
    /// </summary>
    public interface ITruncator
    {
        /// <summary>
        /// Truncate a string
        /// </summary>
        /// <param name="value">The string to truncate</param>
        /// <param name="length">The length to truncate to</param>
        /// <param name="truncationString">The string used to truncate with</param>
        /// <param name="truncateFrom">The enum value used to determine from where to truncate the string</param>
        /// <returns>The truncated string</returns>
        string Truncate(string value, int length, string truncationString, TruncateFrom truncateFrom = TruncateFrom.Right);
    }
}
