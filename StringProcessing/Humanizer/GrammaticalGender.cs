// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="GrammaticalGender.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Options for specifying the desired grammatical gender for the output words
    /// </summary>
    public enum GrammaticalGender
    {
        /// <summary>
        /// Indicates masculine grammatical gender
        /// </summary>
        Masculine,
        /// <summary>
        /// Indicates feminine grammatical gender
        /// </summary>
        Feminine,
        /// <summary>
        /// Indicates neuter grammatical gender
        /// </summary>
        Neuter
    }
}