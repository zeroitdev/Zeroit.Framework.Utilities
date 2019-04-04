// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="FixedLengthTruncator.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Truncate a string to a fixed length
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.Humanizer.ITruncator" />
    class FixedLengthTruncator : ITruncator
    {
        /// <summary>
        /// Truncate a string
        /// </summary>
        /// <param name="value">The string to truncate</param>
        /// <param name="length">The length to truncate to</param>
        /// <param name="truncationString">The string used to truncate with</param>
        /// <param name="truncateFrom">The enum value used to determine from where to truncate the string</param>
        /// <returns>The truncated string</returns>
        public string Truncate(string value, int length, string truncationString, TruncateFrom truncateFrom = TruncateFrom.Right)
        {
            if (value == null)
                return null;

            if (value.Length == 0)
                return value;

            if (truncationString == null || truncationString.Length > length)
                return truncateFrom == TruncateFrom.Right
                    ? value.Substring(0, length)
                    : value.Substring(value.Length - length);
            

            if (truncateFrom == TruncateFrom.Left)
                return value.Length > length
                    ? truncationString + value.Substring(value.Length - length + truncationString.Length)
                    : value;

            return value.Length > length
                ? value.Substring(0, length - truncationString.Length) + truncationString
                : value;
        }
    }
}