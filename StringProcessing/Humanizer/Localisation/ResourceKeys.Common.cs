// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="ResourceKeys.Common.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation
{
    /// <summary>
    /// Class ResourceKeys.
    /// </summary>
    public partial class ResourceKeys
    {
        /// <summary>
        /// The single
        /// </summary>
        private const string Single = "Single";
        /// <summary>
        /// The multiple
        /// </summary>
        private const string Multiple = "Multiple";

        /// <summary>
        /// Validates the range.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <exception cref="ArgumentOutOfRangeException">count</exception>
        private static void ValidateRange(int count)
        {
            if (count < 0) 
                throw new ArgumentOutOfRangeException(nameof(count));
        }
    }
}
