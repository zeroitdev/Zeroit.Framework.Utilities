// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DWM_BLURBEHIND.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Struct DWM_BLURBEHIND
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DWM_BLURBEHIND
    {
        /// <summary>
        /// The dw flags
        /// </summary>
        public int dwFlags;
        /// <summary>
        /// The f enable
        /// </summary>
        public int fEnable;
        /// <summary>
        /// The h RGN blur
        /// </summary>
        public IntPtr hRgnBlur;
        /// <summary>
        /// The f transition on maximized
        /// </summary>
        public int fTransitionOnMaximized;
    }
}
