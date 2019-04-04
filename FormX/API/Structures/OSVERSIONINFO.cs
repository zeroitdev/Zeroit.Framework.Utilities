// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="OSVERSIONINFO.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Struct OSVERSIONINFO
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct OSVERSIONINFO
    {
        /// <summary>
        /// The dw version information size
        /// </summary>
        internal int dwVersionInfoSize;
        /// <summary>
        /// The dw major version
        /// </summary>
        internal int dwMajorVersion;
        /// <summary>
        /// The dw minor version
        /// </summary>
        internal int dwMinorVersion;
        /// <summary>
        /// The dw build number
        /// </summary>
        internal int dwBuildNumber;
        /// <summary>
        /// The dw platform identifier
        /// </summary>
        internal int dwPlatformId;
        /// <summary>
        /// The sz CSD version
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 127)]
        internal byte[] szCSDVersion;
    }
}
