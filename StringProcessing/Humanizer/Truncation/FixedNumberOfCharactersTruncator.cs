// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="FixedNumberOfCharactersTruncator.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;

namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Truncate a string to a fixed number of letters or digits
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.Humanizer.ITruncator" />
    class FixedNumberOfCharactersTruncator : ITruncator
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

            if (truncationString == null)
                truncationString = string.Empty;

            if (truncationString.Length > length)
                return truncateFrom == TruncateFrom.Right ? value.Substring(0, length) : value.Substring(value.Length - length);

            var alphaNumericalCharactersProcessed = 0;

            if (value.ToCharArray().Count(char.IsLetterOrDigit) <= length)
                return value;

            if (truncateFrom == TruncateFrom.Left)
            {
                for (var i = value.Length - 1; i > 0; i--)
                {
                    if (char.IsLetterOrDigit(value[i]))
                        alphaNumericalCharactersProcessed++;

                    if (alphaNumericalCharactersProcessed + truncationString.Length == length)
                        return truncationString + value.Substring(i);
                }         
            }

            for (var i = 0; i < value.Length - truncationString.Length; i++)
            {
                if (char.IsLetterOrDigit(value[i]))
                    alphaNumericalCharactersProcessed++;

                if (alphaNumericalCharactersProcessed + truncationString.Length == length)
                    return value.Substring(0, i + 1) + truncationString;
            }

            return value;
        }
    }
}