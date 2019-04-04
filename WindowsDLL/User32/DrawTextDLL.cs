// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-25-2018
// ***********************************************************************
// <copyright file="DrawTextDLL.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Runtime.InteropServices;
using System.Drawing;


namespace Zeroit.Framework.Utilities.WindowsDLL.User32
{
    /// <summary>
    /// Class DrawTextDLL.
    /// </summary>
    public static class DrawTextDLL
    {
        /// <summary>
        /// Struct Rect
        /// </summary>
        public struct Rect
        {
            /// <summary>
            /// The left
            /// </summary>
            public int Left, Top, Right, Bottom;
            /// <summary>
            /// Initializes a new instance of the <see cref="Rect"/> struct.
            /// </summary>
            /// <param name="r">The r.</param>
            public Rect(Rectangle r)
            {
                this.Left = r.Left;
                this.Top = r.Top;
                this.Bottom = r.Bottom;
                this.Right = r.Right;
            }
        }
        /// <summary>
        /// Draws the text.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <param name="lpString">The lp string.</param>
        /// <param name="nCount">The n count.</param>
        /// <param name="lpRect">The lp rect.</param>
        /// <param name="uFormat">The u format.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll")]
        public static extern int DrawText(IntPtr hDC, string lpString, int nCount, ref Rect lpRect, uint uFormat);

        /// <summary>
        /// Enum FormatType
        /// </summary>
        [Flags]
        public enum FormatType : uint
        {
            /// <summary>
            /// The dt center
            /// </summary>
            DT_CENTER = 0x1,
            /// <summary>
            /// The dt vcenter
            /// </summary>
            DT_VCENTER = 0x4,
            /// <summary>
            /// The dt singleline
            /// </summary>
            DT_SINGLELINE = 0x20
        }
    }
}
