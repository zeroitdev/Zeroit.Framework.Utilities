// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-25-2018
// ***********************************************************************
// <copyright file="DrawTextDLL.cs" company="Zeroit Dev Technologies">
//    This program contains Utilities for all C# programming activities.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
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
