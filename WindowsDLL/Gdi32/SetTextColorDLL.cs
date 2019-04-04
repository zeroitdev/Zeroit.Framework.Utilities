// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="SetTextColorDLL.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsDLL.Gdi32
{
    /// <summary>
    /// Class SetTextColorDLL.
    /// </summary>
    public static class SetTextColorDLL
    {
        /// <summary>
        /// Sets the color of the text.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <param name="crColor">Color of the cr.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("gdi32.dll")]
        public static extern int SetTextColor(IntPtr hdc, int crColor);
    }

}
