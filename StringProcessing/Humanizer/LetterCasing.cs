// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="LetterCasing.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Options for specifying the desired letter casing for the output string
    /// </summary>
    public enum LetterCasing
    {
        /// <summary>
        /// SomeString -&gt; Some String
        /// </summary>
        Title,
        /// <summary>
        /// SomeString -&gt; SOME STRING
        /// </summary>
        AllCaps,
        /// <summary>
        /// SomeString -&gt; some string
        /// </summary>
        LowerCase,
        /// <summary>
        /// SomeString -&gt; Some string
        /// </summary>
        Sentence,
    }
}