// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="WTA_OPTIONS.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Struct WTA_OPTIONS
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct WTA_OPTIONS
    {
        /// <summary>
        /// The flags
        /// </summary>
        public uint Flags;
        /// <summary>
        /// The mask
        /// </summary>
        public uint Mask;
    }
}
