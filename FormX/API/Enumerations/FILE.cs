// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="FILE.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Enum FILE
    /// </summary>
    public enum FILE : uint
    {
        /// <summary>
        /// The begin
        /// </summary>
        BEGIN = 0,
        /// <summary>
        /// The current
        /// </summary>
        CURRENT = 1,
        /// <summary>
        /// The end
        /// </summary>
        END = 2,
        /// <summary>
        /// The move failed
        /// </summary>
        MOVE_FAILED = 0xFFFFFFFF,
    }
}
