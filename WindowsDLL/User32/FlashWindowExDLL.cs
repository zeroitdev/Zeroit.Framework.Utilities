// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-25-2018
// ***********************************************************************
// <copyright file="FlashWindowExDLL.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsDLL.User32
{
    /// <summary>
    /// Class FlashWindowExDLL.
    /// </summary>
    public static class FlashWindowExDLL
    {
        /// <summary>
        /// Struct FLASHWINFO
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            /// <summary>
            /// The cb size
            /// </summary>
            public UInt32 cbSize;
            /// <summary>
            /// The HWND
            /// </summary>
            public IntPtr hwnd;
            /// <summary>
            /// The dw flags
            /// </summary>
            public Int32 dwFlags;
            /// <summary>
            /// The u count
            /// </summary>
            public UInt32 uCount;
            /// <summary>
            /// The dw timeout
            /// </summary>
            public Int32 dwTimeout;
        }
        /// <summary>
        /// Enum FLASHWINFOFLAGS
        /// </summary>
        public enum FLASHWINFOFLAGS
        {
            /// <summary>
            /// The flashw stop
            /// </summary>
            FLASHW_STOP = 0,
            /// <summary>
            /// The flashw caption
            /// </summary>
            FLASHW_CAPTION = 0x00000001,
            /// <summary>
            /// The flashw tray
            /// </summary>
            FLASHW_TRAY = 0x00000002,
            /// <summary>
            /// The flashw all
            /// </summary>
            FLASHW_ALL = (FLASHW_CAPTION | FLASHW_TRAY),
            /// <summary>
            /// The flashw timer
            /// </summary>
            FLASHW_TIMER = 0x00000004,
            /// <summary>
            /// The flashw timernofg
            /// </summary>
            FLASHW_TIMERNOFG = 0x0000000C
        }
        /// <summary>
        /// Flashes the window ex.
        /// </summary>
        /// <param name="FlashInfo">The flash information.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll")]
        public static extern int FlashWindowEx(ref FLASHWINFO FlashInfo);



    }
}
