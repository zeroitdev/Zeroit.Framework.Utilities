// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-25-2018
// ***********************************************************************
// <copyright file="SetBkColorDLL.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsDLL.Gdi32
{
    /// <summary>
    /// Class SetBkColorDLL.
    /// </summary>
    public static class SetBkColorDLL
    {
        /// <summary>
        /// Sets the color of the bk.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <param name="crColor">Color of the cr.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("gdi32.dll")]
        public static extern int SetBkColor(IntPtr hdc, int crColor);
    }
}
