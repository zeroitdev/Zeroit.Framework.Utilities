// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ToSentenceCase.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Class ToSentenceCase.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.Humanizer.IStringTransformer" />
    class ToSentenceCase : IStringTransformer
    {
        /// <summary>
        /// Transform the input
        /// </summary>
        /// <param name="input">String to be transformed</param>
        /// <returns>System.String.</returns>
        public string Transform(string input)
        {
            if (input.Length >= 1)
                return string.Concat(input.Substring(0, 1).ToUpper(), input.Substring(1));

            return input.ToUpper();
        }
    }
}