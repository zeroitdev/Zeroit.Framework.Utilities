// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="REG.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Enum REG
    /// </summary>
    public enum REG
    {
        /// <summary>
        /// The option non volatile
        /// </summary>
        OPTION_NON_VOLATILE = 0x0,
        /// <summary>
        /// The error ok
        /// </summary>
        ERR_OK = 0x0,
        /// <summary>
        /// The error not exist
        /// </summary>
        ERR_NOT_EXIST = 0x1,
        /// <summary>
        /// The error not string
        /// </summary>
        ERR_NOT_STRING = 0x2,
        /// <summary>
        /// The error not dword
        /// </summary>
        ERR_NOT_DWORD = 0x4,
    }
}
