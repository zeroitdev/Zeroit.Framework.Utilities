// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="VALUE_TYPE.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Enum VALUE_TYPE
    /// </summary>
    public enum VALUE_TYPE : uint
    {
        /// <summary>
        /// The reg none
        /// </summary>
        REG_NONE,
        /// <summary>
        /// The reg sz
        /// </summary>
        REG_SZ = 1,
        /// <summary>
        /// The reg expand sz
        /// </summary>
        REG_EXPAND_SZ = 2,
        /// <summary>
        /// The reg binary
        /// </summary>
        REG_BINARY = 3,
        /// <summary>
        /// The reg dword
        /// </summary>
        REG_DWORD = 4,
        /// <summary>
        /// The reg dword little endian
        /// </summary>
        REG_DWORD_LITTLE_ENDIAN = 4,
        /// <summary>
        /// The reg dword big endian
        /// </summary>
        REG_DWORD_BIG_ENDIAN = 5,
        /// <summary>
        /// The reg link
        /// </summary>
        REG_LINK = 6,
        /// <summary>
        /// The reg multi sz
        /// </summary>
        REG_MULTI_SZ = 7,
        /// <summary>
        /// The reg resource list
        /// </summary>
        REG_RESOURCE_LIST = 8,
        /// <summary>
        /// The reg full resource descriptor
        /// </summary>
        REG_FULL_RESOURCE_DESCRIPTOR = 9,
        /// <summary>
        /// The reg resource requirements list
        /// </summary>
        REG_RESOURCE_REQUIREMENTS_LIST = 10,
        /// <summary>
        /// The reg qword little endian
        /// </summary>
        REG_QWORD_LITTLE_ENDIAN = 11
    }
}
