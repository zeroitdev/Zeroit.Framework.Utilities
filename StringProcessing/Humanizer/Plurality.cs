// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="Plurality.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Provides hint for Humanizer as to whether a word is singular, plural or with unknown plurality
    /// </summary>
    public enum Plurality
    {
        /// <summary>
        /// The word is singular
        /// </summary>
        Singular,
        /// <summary>
        /// The word is plural
        /// </summary>
        Plural,
        /// <summary>
        /// I am unsure of the plurality
        /// </summary>
        CouldBeEither
    }
}