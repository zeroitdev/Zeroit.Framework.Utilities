// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-22-2018
// ***********************************************************************
// <copyright file="PixelBufferManagedGraphics.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Drawing;
using User32 = Zeroit.Framework.Utilities.Win32.NativeUser32Api;
using Gdi32 = Zeroit.Framework.Utilities.Win32.NativeGdi32Api;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Drawing2D
{
    /// <summary>
    /// Class PixelBufferManagedGraphics.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Drawing2D.PixelBufferGraphics" />
    public class PixelBufferManagedGraphics:PixelBufferGraphics
    {
        /// <summary>
        /// The BMP
        /// </summary>
        private Bitmap _bmp;
        /// <summary>
        /// The GFX
        /// </summary>
        private Graphics _gfx;
        //private IntPtr _memDC;

        /// <summary>
        /// Initializes a new instance of the <see cref="PixelBufferManagedGraphics"/> class.
        /// </summary>
        /// <param name="pixelBuffer">The pixel buffer.</param>
        public PixelBufferManagedGraphics(PixelBuffer pixelBuffer)
            : base(pixelBuffer)
        {
            _bmp = new Bitmap(pixelBuffer.Width, pixelBuffer.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            _gfx = Graphics.FromImage(_bmp);

            pixelBuffer.Renderer.RenderBegin += new PixelBufferRenderDelegate(Renderer_RenderBegin);
        }

        #region Events

        /// <summary>
        /// Renderers the render begin.
        /// </summary>
        /// <param name="renderInfo">The render information.</param>
        void Renderer_RenderBegin(PixelBufferRenderInfo renderInfo)
        {
            pixelBuffer.CopyBitmap(_bmp);
        }

        #endregion

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public override void Dispose()
        {
            if (_gfx != null) _gfx.Dispose();
            //if (_memDC != IntPtr.Zero) Gdi32.DeleteDC(_memDC);
            if (_bmp != null) _bmp.Dispose();
        }

        /// <summary>
        /// Clears the graphics.
        /// </summary>
        internal override void ClearGraphics()
        {
            _gfx.Clear(Color.Transparent);
        }

        #region Graphics Functions

        /// <summary>
        /// Blends the rectangle.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="color">The color.</param>
        public override void BlendRectangle(int x1, int y1, int x2, int y2, Color color)
        {
            this.FillRectangle(x1, y1, x2, y2, color);
        }
        /// <summary>
        /// Blends the rectangle.
        /// </summary>
        /// <param name="pt1">The PT1.</param>
        /// <param name="pt2">The PT2.</param>
        /// <param name="color">The color.</param>
        public override void BlendRectangle(Point pt1, Point pt2, Color color)
        {
            this.FillRectangle(pt1.X, pt1.Y, pt2.X, pt2.Y, color);
        }
        /// <summary>
        /// Draws the line.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="color">The color.</param>
        public override void DrawLine(int x1, int y1, int x2, int y2, Color color)
        {
            _gfx.DrawLine(new Pen(color), x1, y1, x2, y2);
            pixelBuffer.CopyBitmap(_bmp);
        }
        /// <summary>
        /// Draws the line.
        /// </summary>
        /// <param name="pt1">The PT1.</param>
        /// <param name="pt2">The PT2.</param>
        /// <param name="color">The color.</param>
        public override void DrawLine(Point pt1, Point pt2, Color color)
        {
            this.DrawLine(pt1.X, pt1.Y, pt2.X, pt2.Y, color);
        }
        /// <summary>
        /// Fills the rectangle.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="color">The color.</param>
        public override void FillRectangle(int x1, int y1, int x2, int y2, Color color)
        {
            _gfx.FillRectangle(new SolidBrush(color), x1, y1, x2 - x1, y2 - y1);
            //pixelBuffer.CopyBitmap(_bmp);
        }
        /// <summary>
        /// Fills the rectangle.
        /// </summary>
        /// <param name="pt1">The PT1.</param>
        /// <param name="pt2">The PT2.</param>
        /// <param name="color">The color.</param>
        public override void FillRectangle(Point pt1, Point pt2, Color color)
        {
            this.FillRectangle(pt1.X, pt1.Y, pt2.X, pt2.Y, color);
        }
        /// <summary>
        /// Fills the ellipse.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="color">The color.</param>
        public override void FillEllipse(int x1, int y1, int x2, int y2, Color color)
        {
            //_gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            _gfx.FillEllipse(new SolidBrush(color), x1, y1, x2-x1, y2-y1 );
        }
        /// <summary>
        /// Fills the ellipse.
        /// </summary>
        /// <param name="pt1">The PT1.</param>
        /// <param name="pt2">The PT2.</param>
        /// <param name="color">The color.</param>
        public override void FillEllipse(Point pt1, Point pt2, Color color)
        {
            this.FillEllipse(pt1.X, pt1.Y, pt2.X, pt2.Y, color);
        }

        #endregion
    }
}
