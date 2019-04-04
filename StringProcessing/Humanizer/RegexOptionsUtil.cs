// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="RegexOptionsUtil.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Text.RegularExpressions;

namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Class RegexOptionsUtil.
    /// </summary>
    internal static class RegexOptionsUtil
    {
        /// <summary>
        /// Initializes static members of the <see cref="RegexOptionsUtil"/> class.
        /// </summary>
        static RegexOptionsUtil()
        {
            Compiled = Enum.TryParse("Compiled", out RegexOptions compiled) ? compiled : RegexOptions.None;
        }

        /// <summary>
        /// Gets the compiled.
        /// </summary>
        /// <value>The compiled.</value>
        public static RegexOptions Compiled { get; }
    }
}
