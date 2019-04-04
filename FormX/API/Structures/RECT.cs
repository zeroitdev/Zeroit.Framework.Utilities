// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="RECT.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.InteropServices;
using System.Drawing;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Struct RECT
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        /// <summary>
        /// The left
        /// </summary>
        public int Left;
        /// <summary>
        /// The top
        /// </summary>
        public int Top;
        /// <summary>
        /// The right
        /// </summary>
        public int Right;
        /// <summary>
        /// The bottom
        /// </summary>
        public int Bottom;

        /// <summary>
        /// Initializes a new instance of the <see cref="RECT"/> struct.
        /// </summary>
        /// <param name="rect">The rect.</param>
        public RECT(Rectangle rect)
        {
            this.Left = rect.Left;
            this.Top = rect.Top;
            this.Right = rect.Right;
            this.Bottom = rect.Bottom;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RECT"/> struct.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="right">The right.</param>
        /// <param name="bottom">The bottom.</param>
        public RECT(int left, int top, int right, int bottom)
        {
            this.Left = left;
            this.Top = top;
            this.Right = right;
            this.Bottom = bottom;
        }

        /// <summary>
        /// To the rectangle.
        /// </summary>
        /// <returns>Rectangle.</returns>
        public Rectangle ToRectangle()
        {
            return new Rectangle(this.Left, this.Top, this.Right - this.Left, this.Bottom - this.Top);
        }

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height
        {
            get { return (this.Bottom - this.Top); }
        }

        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width
        {
            get { return (this.Right - this.Left); }
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <value>The size.</value>
        public Size Size
        {
            get { return new Size(this.Width, this.Height); }
        }
    }
}
