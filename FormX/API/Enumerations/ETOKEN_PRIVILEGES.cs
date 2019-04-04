// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ETOKEN_PRIVILEGES.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Enum ETOKEN_PRIVILEGES
    /// </summary>
    public enum ETOKEN_PRIVILEGES : uint
    {
        /// <summary>
        /// The assign primary
        /// </summary>
        ASSIGN_PRIMARY = 0x1,
        /// <summary>
        /// The token duplicate
        /// </summary>
        TOKEN_DUPLICATE = 0x2,
        /// <summary>
        /// The token impersonate
        /// </summary>
        TOKEN_IMPERSONATE = 0x4,
        /// <summary>
        /// The token query
        /// </summary>
        TOKEN_QUERY = 0x8,
        /// <summary>
        /// The token query source
        /// </summary>
        TOKEN_QUERY_SOURCE = 0x10,
        /// <summary>
        /// The token adjust privileges
        /// </summary>
        TOKEN_ADJUST_PRIVILEGES = 0x20,
        /// <summary>
        /// The token adjust groups
        /// </summary>
        TOKEN_ADJUST_GROUPS = 0x40,
        /// <summary>
        /// The token adjust default
        /// </summary>
        TOKEN_ADJUST_DEFAULT = 0x80,
        /// <summary>
        /// The token adjust sessionid
        /// </summary>
        TOKEN_ADJUST_SESSIONID = 0x100
    }
}
