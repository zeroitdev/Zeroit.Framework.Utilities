// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="FILE_ATTRIBUTE.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Enum FILE_ATTRIBUTE
    /// </summary>
    public enum FILE_ATTRIBUTE
    {
        /// <summary>
        /// The readonly
        /// </summary>
        READONLY = 0x00000001,
        /// <summary>
        /// The hidden
        /// </summary>
        HIDDEN = 0x00000002,
        /// <summary>
        /// The system
        /// </summary>
        SYSTEM = 0x00000004,
        /// <summary>
        /// The archive
        /// </summary>
        ARCHIVE = 0x00000020,
        /// <summary>
        /// The encrypted
        /// </summary>
        ENCRYPTED = 0x00000040,
        /// <summary>
        /// The normal
        /// </summary>
        NORMAL = 0x00000080,
        /// <summary>
        /// The temporary
        /// </summary>
        TEMPORARY = 0x00000100,
        /// <summary>
        /// The sparse file
        /// </summary>
        SPARSE_FILE = 0x00000200,
        /// <summary>
        /// The reparse point
        /// </summary>
        REPARSE_POINT = 0x00000400,
        /// <summary>
        /// The compressed
        /// </summary>
        COMPRESSED = 0x00000800,
        /// <summary>
        /// The offline
        /// </summary>
        OFFLINE = 0x00001000,
        /// <summary>
        /// The directory
        /// </summary>
        DIRECTORY = 0x00000010,
    }
}
