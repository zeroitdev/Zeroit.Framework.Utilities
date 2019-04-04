// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="OnNoMatch.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Dictating what should be done when a match is not found - currently used only for DehumanizeTo
    /// </summary>
    public enum OnNoMatch
    {
        /// <summary>
        /// This is the default behavior which throws a NoMatchFoundException
        /// </summary>
        ThrowsException,

        /// <summary>
        /// If set to ReturnsNull the method returns null instead of throwing an exception
        /// </summary>
        ReturnsNull
    }
}