// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ROOT_KEY.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Enum ROOT_KEY
    /// </summary>
    public enum ROOT_KEY : uint
    {
        /// <summary>
        /// The hkey classes root
        /// </summary>
        HKEY_CLASSES_ROOT = 0x80000000,
        /// <summary>
        /// The hkey current user
        /// </summary>
        HKEY_CURRENT_USER = 0x80000001,
        /// <summary>
        /// The hkey local machine
        /// </summary>
        HKEY_LOCAL_MACHINE = 0x80000002,
        /// <summary>
        /// The hkey users
        /// </summary>
        HKEY_USERS = 0x80000003,
        /// <summary>
        /// The hkey performance data
        /// </summary>
        HKEY_PERFORMANCE_DATA = 0x80000004,
        /// <summary>
        /// The hkey current configuration
        /// </summary>
        HKEY_CURRENT_CONFIG = 0x80000005,
        /// <summary>
        /// The hkey dyn data
        /// </summary>
        HKEY_DYN_DATA = 0x80000006
    }
}
