// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="GDIBitmap.cs" company="Zeroit Dev Technologies">
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
using Zeroit.Framework.Utilities.Win32;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing.GDI
{
    /// <summary>
    /// Class GDIBitmap.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.Drawing.GDI.GDIObject" />
    public class GDIBitmap:GDIObject
    {
        /// <summary>
        /// The h BMP
        /// </summary>
        private IntPtr _hBmp;
        /// <summary>
        /// The width
        /// </summary>
        private int _width;
        /// <summary>
        /// The height
        /// </summary>
        private int _height;

        /// <summary>
        /// The dest dc
        /// </summary>
        private IntPtr _destDC = IntPtr.Zero;

        /// <summary>
        /// Initializes a new instance of the <see cref="GDIBitmap"/> class.
        /// </summary>
        /// <param name="hBmp">The h BMP.</param>
        public GDIBitmap(IntPtr hBmp)
        {
            _hBmp = hBmp;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="GDIBitmap"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public GDIBitmap(string filename)
        {
            FreeImage img = new FreeImage(filename);
            IntPtr deskDC = NativeUser32Api.GetDC(new IntPtr(0));
            _destDC = NativeGdi32Api.CreateCompatibleDC(deskDC);
            IntPtr oldObj = NativeGdi32Api.SelectObject(_destDC, _hBmp);
            _hBmp = NativeGdi32Api.CreateCompatibleBitmap(_destDC, img.Width, img.Height);
            img.PaintToDevice(_destDC, 0, 0, img.Width, img.Height, 0, 0, 0, img.Height, 0);
            NativeGdi32Api.SelectObject(_destDC, oldObj);

            _width = img.Width;
            _height = img.Height;

            NativeGdi32Api.DeleteDC(deskDC);
            //NativeGdi32Api.DeleteDC(destDC);
            img.Dispose();
        }

        /// <summary>
        /// Gets the HDC.
        /// </summary>
        /// <value>The HDC.</value>
        public IntPtr Hdc
        {
            get
            {
                return _destDC;
            }
        }

        /// <summary>
        /// Gets the handle.
        /// </summary>
        /// <value>The handle.</value>
        public IntPtr Handle
        {
            get
            {
                return _hBmp;
            }
        }

        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width
        {
            get
            {
                return _width;
            }
        }

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height
        {
            get
            {
                return _height;
            }
        }

        //public void SetPixel(GDIColor color,int x,int y)
        //{
        //    NativeGdi32Api.SetPixel(_destDC, x, y, color.NativeColor);
        //}

        //public GDIColor GetPixel(int x, int y)
        //{
        //    int cl = NativeGdi32Api.GetPixel(_destDC,x,y);
        //    GDIColor color = new GDIColor(cl);
        //    return color;
        //}

        /// <summary>
        /// Destroys this instance.
        /// </summary>
        protected override void Destroy()
        {
            if (_hBmp != (IntPtr)0)
            {
                NativeGdi32Api.DeleteObject(_hBmp);
                NativeGdi32Api.DeleteDC(_destDC);
            }

            base.Destroy();
            _hBmp = (IntPtr)0;
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        protected override void Create()
        {
            base.Create();
        }
    }


}
