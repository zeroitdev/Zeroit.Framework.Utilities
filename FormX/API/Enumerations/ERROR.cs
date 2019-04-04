// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ERROR.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Enum ERROR
    /// </summary>
    public enum ERROR
    {
        /// <summary>
        /// The none
        /// </summary>
        NONE = 0x0,
        /// <summary>
        /// The baddb
        /// </summary>
        BADDB = 0x1,
        /// <summary>
        /// The badkey
        /// </summary>
        BADKEY = 0x2,
        /// <summary>
        /// The cantopen
        /// </summary>
        CANTOPEN = 0x3,
        /// <summary>
        /// The cantread
        /// </summary>
        CANTREAD = 0x4,
        /// <summary>
        /// The cantwrite
        /// </summary>
        CANTWRITE = 0x5,
        /// <summary>
        /// The outofmemory
        /// </summary>
        OUTOFMEMORY = 0x6,
        /// <summary>
        /// The arena trashed
        /// </summary>
        ARENA_TRASHED = 0x7,
        /// <summary>
        /// The access denied
        /// </summary>
        ACCESS_DENIED = 0x8,
        /// <summary>
        /// The invalid parameters
        /// </summary>
        INVALID_PARAMETERS = 0x57,
        /// <summary>
        /// The more data
        /// </summary>
        MORE_DATA = 0xEA,
        /// <summary>
        /// The no more items
        /// </summary>
        NO_MORE_ITEMS = 0x103,
    }
}
