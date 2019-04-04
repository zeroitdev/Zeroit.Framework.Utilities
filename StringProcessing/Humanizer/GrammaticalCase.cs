// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="GrammaticalCase.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Options for specifying the desired grammatical case for the output words
    /// </summary>
    public enum GrammaticalCase
    {
        /// <summary>
        /// Indicates the subject of a finite verb
        /// </summary>
        Nominative,
        /// <summary>
        /// Indicates the possessor of another noun
        /// </summary>
        Genitive,
        /// <summary>
        /// Indicates the indirect object of a verb
        /// </summary>
        Dative,
        /// <summary>
        /// Indicates the direct object of a verb
        /// </summary>
        Accusative,
        /// <summary>
        /// Indicates an object used in performing an action
        /// </summary>
        Instrumental,
        /// <summary>
        /// Indicates the object of a preposition
        /// </summary>
        Prepositional,
    }
}