// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="IStringTransformer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Can tranform a string
    /// </summary>
    public interface IStringTransformer
    {
        /// <summary>
        /// Transform the input
        /// </summary>
        /// <param name="input">String to be transformed</param>
        /// <returns>System.String.</returns>
        string Transform(string input);
    }
}