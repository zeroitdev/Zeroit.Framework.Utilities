// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="TOKEN_PRIVILEGES.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Struct TOKEN_PRIVILEGES
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TOKEN_PRIVILEGES
    {
        /// <summary>
        /// The privilege count
        /// </summary>
        public Int32 PrivilegeCount;
        /// <summary>
        /// The privileges
        /// </summary>
        public LUID_AND_ATTRIBUTES Privileges;
    }
}
