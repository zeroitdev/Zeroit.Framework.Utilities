// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="ToUpperCase.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Class ToUpperCase.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.Humanizer.IStringTransformer" />
    class ToUpperCase : IStringTransformer
    {
        /// <summary>
        /// Transform the input
        /// </summary>
        /// <param name="input">String to be transformed</param>
        /// <returns>System.String.</returns>
        public string Transform(string input)
        {
            return input.ToUpper();
        }
    }
}