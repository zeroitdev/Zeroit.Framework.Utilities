// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-25-2018
// ***********************************************************************
// <copyright file="ShowWindowAsyncDLL.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsDLL.User32
{
    /// <summary>
    /// Class ShowWindowAsyncDLL.
    /// </summary>
    public static class ShowWindowAsyncDLL
    {
        /// <summary>
        /// Shows the window asynchronous.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="nCmdShow">The n command show.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        /// <summary>
        /// Enum ShowWindowConstants
        /// </summary>
        public enum ShowWindowConstants
        {
            /// <summary>
            /// The sw hide
            /// </summary>
            SW_HIDE = 0,
            /// <summary>
            /// The sw shownormal
            /// </summary>
            SW_SHOWNORMAL = 1,
            /// <summary>
            /// The sw normal
            /// </summary>
            SW_NORMAL = 1,
            /// <summary>
            /// The sw showminimized
            /// </summary>
            SW_SHOWMINIMIZED = 2,
            /// <summary>
            /// The sw showmaximized
            /// </summary>
            SW_SHOWMAXIMIZED = 3,
            /// <summary>
            /// The sw maximize
            /// </summary>
            SW_MAXIMIZE = 3,
            /// <summary>
            /// The sw shownoactivate
            /// </summary>
            SW_SHOWNOACTIVATE = 4,
            /// <summary>
            /// The sw show
            /// </summary>
            SW_SHOW = 5,
            /// <summary>
            /// The sw minimize
            /// </summary>
            SW_MINIMIZE = 6,
            /// <summary>
            /// The sw showminnoactive
            /// </summary>
            SW_SHOWMINNOACTIVE = 7,
            /// <summary>
            /// The sw showna
            /// </summary>
            SW_SHOWNA = 8,
            /// <summary>
            /// The sw restore
            /// </summary>
            SW_RESTORE = 9,
            /// <summary>
            /// The sw showdefault
            /// </summary>
            SW_SHOWDEFAULT = 10,
            /// <summary>
            /// The sw forceminimize
            /// </summary>
            SW_FORCEMINIMIZE = 11,
            /// <summary>
            /// The sw maximum
            /// </summary>
            SW_MAX = 11
        }
        
    }
}
