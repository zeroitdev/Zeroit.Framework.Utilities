// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="MOUSEHOOK.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Class MouseHookStruct.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class MouseHookStruct
    {
        /// <summary>
        /// The pt
        /// </summary>
        public POINT pt;
        /// <summary>
        /// The HWND
        /// </summary>
        public int hwnd;
        /// <summary>
        /// The w hit test code
        /// </summary>
        public int wHitTestCode;
        /// <summary>
        /// The dw extra information
        /// </summary>
        public int dwExtraInfo;
    }
}
