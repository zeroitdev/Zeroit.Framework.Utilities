// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="ToLowerCase.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Globalization;

namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Class ToLowerCase.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.Humanizer.IStringTransformer" />
    class ToLowerCase : IStringTransformer
    {
        /// <summary>
        /// Transform the input
        /// </summary>
        /// <param name="input">String to be transformed</param>
        /// <returns>System.String.</returns>
        public string Transform(string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToLower(input);
        }
    }
}