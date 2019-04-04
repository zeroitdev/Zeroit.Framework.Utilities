// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="PixelBufferRenderInfo.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Drawing2D
{
    /// <summary>
    /// Class PixelBufferRenderInfo.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class PixelBufferRenderInfo:IDisposable
    {
        /// <summary>
        /// The HDC
        /// </summary>
        private IntPtr _hdc;
        /// <summary>
        /// The GFX
        /// </summary>
        private Graphics _gfx;

        /// <summary>
        /// Initializes a new instance of the <see cref="PixelBufferRenderInfo"/> class.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        public PixelBufferRenderInfo(IntPtr hdc)
        {
            _hdc = hdc;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PixelBufferRenderInfo"/> class.
        /// </summary>
        /// <param name="gfx">The GFX.</param>
        public PixelBufferRenderInfo(Graphics gfx)
        {
            _gfx = gfx;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PixelBufferRenderInfo"/> class.
        /// </summary>
        /// <param name="gfx">The GFX.</param>
        /// <param name="hdc">The HDC.</param>
        public PixelBufferRenderInfo(Graphics gfx, IntPtr hdc)
        {
            _gfx = gfx;
            _hdc = hdc;
        }

        /// <summary>
        /// Gets the HDC.
        /// </summary>
        /// <value>The HDC.</value>
        public IntPtr Hdc
        {
            get
            {
                return _hdc;
            }
        }
        /// <summary>
        /// Gets the graphics.
        /// </summary>
        /// <value>The graphics.</value>
        public Graphics Graphics
        {
            get
            {
                return _gfx;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _hdc = IntPtr.Zero;
        }
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposeGraphics"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        public void Dispose(bool disposeGraphics)
        {
            this.Dispose();
            if (disposeGraphics && _gfx != null)
            {
                _gfx.Dispose();
            }
        }
    }
}
