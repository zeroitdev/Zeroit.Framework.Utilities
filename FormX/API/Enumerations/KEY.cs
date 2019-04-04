// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="KEY.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Enum KEY
    /// </summary>
    public enum KEY
    {
        /// <summary>
        /// All access
        /// </summary>
        ALL_ACCESS = 0xF003F,
        /// <summary>
        /// The create link
        /// </summary>
        CREATE_LINK = 0x20,
        /// <summary>
        /// The create sub key
        /// </summary>
        CREATE_SUB_KEY = 0x4,
        /// <summary>
        /// The enumerate sub keys
        /// </summary>
        ENUMERATE_SUB_KEYS = 0x8,
        /// <summary>
        /// The execute
        /// </summary>
        EXECUTE = 0x20019,
        /// <summary>
        /// The notify
        /// </summary>
        NOTIFY = 0x10,
        /// <summary>
        /// The query value
        /// </summary>
        QUERY_VALUE = 0x1,
        /// <summary>
        /// The read
        /// </summary>
        READ = 0x20019,
        /// <summary>
        /// The set value
        /// </summary>
        SET_VALUE = 0x2,
        /// <summary>
        /// The write
        /// </summary>
        WRITE = 0x20006,
    }
}
