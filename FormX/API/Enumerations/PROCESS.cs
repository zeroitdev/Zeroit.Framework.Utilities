// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="PROCESS.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Enum PROCESS
    /// </summary>
    public enum PROCESS
    {
        /// <summary>
        /// The terminate
        /// </summary>
        TERMINATE = 0x001,
        /// <summary>
        /// The vm read
        /// </summary>
        VM_READ = 0x016,
        /// <summary>
        /// The set information
        /// </summary>
        SET_INFORMATION = 0x200,
        /// <summary>
        /// The query information
        /// </summary>
        QUERY_INFORMATION = 0x400,
    }
}
