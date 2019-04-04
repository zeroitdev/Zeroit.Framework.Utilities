// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Keyboard.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Provides access to basic Keyboard API methods
    /// </summary>
    public static class Keyboard
    {
        /// <summary>
        /// Registers the hot key.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="fsModifiers">The fs modifiers.</param>
        /// <param name="vk">The vk.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hwnd, int id, int fsModifiers, int vk);

        /// <summary>
        /// Unregisters the hot key.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        /// <summary>
        /// Globals the add atom.
        /// </summary>
        /// <param name="lpString">The lp string.</param>
        /// <returns>System.Int16.</returns>
        [DllImport("kernel32", SetLastError = true)]
        public static extern short GlobalAddAtom(string lpString);

        /// <summary>
        /// Globals the delete atom.
        /// </summary>
        /// <param name="nAtom">The n atom.</param>
        /// <returns>System.Int16.</returns>
        [DllImport("kernel32", SetLastError = true)]
        public static extern short GlobalDeleteAtom(short nAtom);
    }
}
