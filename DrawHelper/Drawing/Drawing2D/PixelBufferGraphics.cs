// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="PixelBufferGraphics.cs" company="Zeroit Dev Technologies">
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
    /// Class PixelBufferGraphics.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class PixelBufferGraphics:IDisposable
    {
        /// <summary>
        /// The clip line
        /// </summary>
        private const int CLIP_LINE = 0;
        /// <summary>
        /// The clip line horizontal
        /// </summary>
        private const int CLIP_LINE_HORIZONTAL = 1;
        /// <summary>
        /// The clip line vertical
        /// </summary>
        private const int CLIP_LINE_VERTICAL = 2;
        /// <summary>
        /// The clip line diagonal
        /// </summary>
        private const int CLIP_LINE_DIAGONAL = 3;

        /// <summary>
        /// The pixel buffer
        /// </summary>
        protected PixelBuffer pixelBuffer;

        /// <summary>
        /// Initializes a new instance of the <see cref="PixelBufferGraphics"/> class.
        /// </summary>
        /// <param name="pixelBuffer">The pixel buffer.</param>
        public PixelBufferGraphics(PixelBuffer pixelBuffer)
        {
            this.pixelBuffer = pixelBuffer;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="PixelBufferGraphics"/> class.
        /// </summary>
        ~PixelBufferGraphics()
        {
            this.Dispose();
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            pixelBuffer = null;
        }

        /// <summary>
        /// Clears the graphics.
        /// </summary>
        internal virtual void ClearGraphics()
        {
        }

        #region Public Members

        /// <summary>
        /// Draws the line.
        /// </summary>
        /// <param name="pt1">The PT1.</param>
        /// <param name="pt2">The PT2.</param>
        /// <param name="color">The color.</param>
        public virtual void DrawLine(Point pt1, Point pt2, Color color)
        {
            this.InternalDrawLine(pt1.X, pt1.Y, pt2.X, pt2.Y, color.ToArgb());
        }
        /// <summary>
        /// Draws the line.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="color">The color.</param>
        public virtual void DrawLine(int x1, int y1, int x2, int y2, Color color)
        {
            this.InternalDrawLine(x1, y1, x2, y2, color.ToArgb());
        }

        /// <summary>
        /// Blends the rectangle.
        /// </summary>
        /// <param name="pt1">The PT1.</param>
        /// <param name="pt2">The PT2.</param>
        /// <param name="color">The color.</param>
        public virtual void BlendRectangle(Point pt1, Point pt2, Color color)
        {
            this.FillRectangle(pt1.X, pt1.Y, pt2.X, pt2.Y, color);
        }
        /// <summary>
        /// Blends the rectangle.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="color">The color.</param>
        public virtual void BlendRectangle(int x1, int y1, int x2, int y2, Color color)
        {
            int _x1 = x1;
            int _y1 = y1;
            int _x2 = x2;
            int _y2 = y2;

            if (_x1 > _x2)
            {
                _x1 = x2;
                _x2 = x1;
            }
            if (_y1 > _y2)
            {
                _y1 = y2;
                _y2 = y1;
            }

            pixelBuffer.BlendSubBuffer(color, _x1, _y1, _x2 - _x1, _y2 - _y1);
        }
        /// <summary>
        /// Fills the rectangle.
        /// </summary>
        /// <param name="pt1">The PT1.</param>
        /// <param name="pt2">The PT2.</param>
        /// <param name="color">The color.</param>
        public virtual void FillRectangle(Point pt1, Point pt2, Color color)
        {
            this.FillRectangle(pt1.X, pt1.Y, pt2.X, pt2.Y, color);
        }
        /// <summary>
        /// Fills the rectangle.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="color">The color.</param>
        public virtual void FillRectangle(int x1, int y1, int x2, int y2, Color color)
        {
            int _x1 = x1;
            int _y1 = y1;
            int _x2 = x2;
            int _y2 = y2;

            if (_x1 > _x2)
            {
                _x1 = x2;
                _x2 = x1;
            }
            if (_y1 > _y2)
            {
                _y1 = y2;
                _y2 = y1;
            }

            pixelBuffer.SetSubBuffer(color, _x1, _y1, _x2 - _x1, _y2 - _y1);
        }

        #endregion

        #region Stubs

        /// <summary>
        /// Draws the rectangle.
        /// </summary>
        /// <param name="pt1">The PT1.</param>
        /// <param name="pt2">The PT2.</param>
        /// <param name="color">The color.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void DrawRectangle(Point pt1, Point pt2, Color color)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Draws the rectangle.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="color">The color.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void DrawRectangle(int x1, int y1, int x2, int y2, Color color)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Draws the ellipse.
        /// </summary>
        /// <param name="pt1">The PT1.</param>
        /// <param name="pt2">The PT2.</param>
        /// <param name="color">The color.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void DrawEllipse(Point pt1, Point pt2, Color color)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Draws the ellipse.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="color">The color.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void DrawEllipse(int x1, int y1, int x2, int y2, Color color)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Draws the arc.
        /// </summary>
        /// <param name="pt1">The PT1.</param>
        /// <param name="pt2">The PT2.</param>
        /// <param name="pt3">The PT3.</param>
        /// <param name="color">The color.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void DrawArc(Point pt1, Point pt2, Point pt3, Color color)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Draws the arc.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="x3">The x3.</param>
        /// <param name="y3">The y3.</param>
        /// <param name="color">The color.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void DrawArc(int x1, int y1, int x2, int y2, int x3, int y3, Color color)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Draws the arc.
        /// </summary>
        /// <param name="pt1">The PT1.</param>
        /// <param name="pt2">The PT2.</param>
        /// <param name="startAngle">The start angle.</param>
        /// <param name="sweepAngle">The sweep angle.</param>
        /// <param name="color">The color.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void DrawArc(Point pt1, Point pt2, float startAngle, float sweepAngle, Color color)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Draws the arc.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="startAngle">The start angle.</param>
        /// <param name="sweepAngle">The sweep angle.</param>
        /// <param name="color">The color.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void DrawArc(int x1, int y1, int x2, int y2, float startAngle, float sweepAngle, Color color)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Draws the polyline.
        /// </summary>
        /// <param name="pts">The PTS.</param>
        /// <param name="color">The color.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void DrawPolyline(Point[] pts, Color color)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Draws the polyline.
        /// </summary>
        /// <param name="xPts">The x PTS.</param>
        /// <param name="yPts">The y PTS.</param>
        /// <param name="color">The color.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void DrawPolyline(int[] xPts, int[] yPts, Color color)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Draws the polygon.
        /// </summary>
        /// <param name="pts">The PTS.</param>
        /// <param name="color">The color.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void DrawPolygon(Point[] pts, Color color)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Draws the polygon.
        /// </summary>
        /// <param name="xPts">The x PTS.</param>
        /// <param name="yPts">The y PTS.</param>
        /// <param name="color">The color.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void DrawPolygon(int[] xPts, int[] yPts, Color color)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Draws the curve.
        /// </summary>
        /// <param name="pts">The PTS.</param>
        /// <param name="color">The color.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void DrawCurve(Point[] pts, Color color)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Draws the curve.
        /// </summary>
        /// <param name="xPts">The x PTS.</param>
        /// <param name="yPts">The y PTS.</param>
        /// <param name="color">The color.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void DrawCurve(int[] xPts, int[] yPts, Color color)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Draws the closed curve.
        /// </summary>
        /// <param name="pts">The PTS.</param>
        /// <param name="color">The color.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void DrawClosedCurve(Point[] pts, Color color)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Draws the closed curve.
        /// </summary>
        /// <param name="xPts">The x PTS.</param>
        /// <param name="yPts">The y PTS.</param>
        /// <param name="color">The color.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void DrawClosedCurve(int[] xPts, int[] yPts, Color color)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Draws the bezier curve.
        /// </summary>
        /// <param name="pt1">The PT1.</param>
        /// <param name="pt2">The PT2.</param>
        /// <param name="pt3">The PT3.</param>
        /// <param name="pt4">The PT4.</param>
        /// <param name="color">The color.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void DrawBezierCurve(Point pt1, Point pt2, Point pt3, Point pt4, Color color)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Draws the bezier curve.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="x3">The x3.</param>
        /// <param name="y3">The y3.</param>
        /// <param name="x4">The x4.</param>
        /// <param name="y4">The y4.</param>
        /// <param name="color">The color.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void DrawBezierCurve(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, Color color)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Draws the pie.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="x3">The x3.</param>
        /// <param name="y3">The y3.</param>
        /// <param name="color">The color.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void DrawPie(int x1, int y1, int x2, int y2, int x3, int y3, Color color)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Draws the pie.
        /// </summary>
        /// <param name="pt1">The PT1.</param>
        /// <param name="pt2">The PT2.</param>
        /// <param name="startAngle">The start angle.</param>
        /// <param name="sweepAngle">The sweep angle.</param>
        /// <param name="color">The color.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void DrawPie(Point pt1, Point pt2, float startAngle, float sweepAngle, Color color)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Fills the ellipse.
        /// </summary>
        /// <param name="pt1">The PT1.</param>
        /// <param name="pt2">The PT2.</param>
        /// <param name="color">The color.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void FillEllipse(Point pt1, Point pt2, Color color)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Fills the ellipse.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="color">The color.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void FillEllipse(int x1, int y1, int x2, int y2, Color color)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Fills the polygon.
        /// </summary>
        /// <param name="pts">The PTS.</param>
        /// <param name="color">The color.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void FillPolygon(Point[] pts, Color color)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Fills the polygon.
        /// </summary>
        /// <param name="xPts">The x PTS.</param>
        /// <param name="yPts">The y PTS.</param>
        /// <param name="color">The color.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void FillPolygon(int[] xPts, int[] yPts, Color color)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Fills the closed curve.
        /// </summary>
        /// <param name="pts">The PTS.</param>
        /// <param name="color">The color.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void FillClosedCurve(Point[] pts, Color color)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Fills the closed curve.
        /// </summary>
        /// <param name="xPts">The x PTS.</param>
        /// <param name="yPts">The y PTS.</param>
        /// <param name="color">The color.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void FillClosedCurve(int[] xPts, int[] yPts, Color color)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Fills the pie.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="x3">The x3.</param>
        /// <param name="y3">The y3.</param>
        /// <param name="color">The color.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void FillPie(int x1, int y1, int x2, int y2, int x3, int y3, Color color)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Fills the pie.
        /// </summary>
        /// <param name="pt1">The PT1.</param>
        /// <param name="pt2">The PT2.</param>
        /// <param name="startAngle">The start angle.</param>
        /// <param name="sweepAngle">The sweep angle.</param>
        /// <param name="color">The color.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void FillPie(Point pt1, Point pt2, float startAngle, float sweepAngle, Color color)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private Members

        #region Old Code

        //public void DrawLine(int x1, int y1, int x2, int y2, ColorHLS color)
        //{
        //    ColorHLS pixCol = color.Clone();
        //    PixelFillingDelegate pfd = delegate(int x, int y, int count, int total, bool setPixel)
        //    {

        //        if (setPixel)
        //            SetPixel(x, y, pixCol);

        //        return pixCol;
        //    };

        //    DrawLine(x1, y1, x2, y2, pfd);
        //}
        //public void DrawLine(int x1, int y1, int x2, int y2, ColorHLS color1, ColorHLS color2)
        //{
        //    bool created = false;
        //    ColorHLS color = new ColorHLS(color1);
        //    float[,] steps = new float[0, 0];
        //    ColorHLS[] colors = new ColorHLS[0];

        //    PixelFillingDelegate pfd = delegate(int x, int y, int count, int total, bool setPixel)
        //    {
        //        if (!created)
        //        {
        //            steps = ColorUtils.GetGradientColorSteps(color1, color2, total);
        //            created = true;
        //        }

        //        color.SetRGB(
        //            (byte)steps[count, 0],
        //            (byte)steps[count, 1],
        //            (byte)steps[count, 2]
        //            );

        //        if (setPixel)
        //            SetPixel(x, y, color);

        //        return color;
        //    };

        //    DrawLine(x1, y1, x2, y2, pfd);
        //}
        //public void DrawLine(int x1, int y1, int x2, int y2, PixelFillingDelegate pixFillingDelegate)
        //{
        //    int deltax, deltay;

        //    deltax = (x2 - x1);
        //    deltay = (y2 - y1);

        //    if (deltax == 0)
        //    {
        //        if (deltay == 0)
        //        {
        //            return;
        //        }
        //        DrawVerticalLine(x1, y1, deltay, pixFillingDelegate);
        //        return;
        //    }
        //    else if (deltay == 0)
        //    {
        //        DrawHorizontalLine(x1, y1, deltax, pixFillingDelegate);
        //        return;
        //    }

        //    /* Calcoliamo il deltax ed il deltay della linea, ovvero il numero di pixel presenti a livello
        //        orizzontale e verticale. Utilizziamo la funzione abs() poich� a noi interessa il loro 
        //        valore assoluto. */
        //    deltax = Math.Abs(x2 - x1);
        //    deltay = Math.Abs(y2 - y1);

        //    int i, numpixels,
        //        d, dinc1, dinc2,
        //        x, xinc1, xinc2,
        //        y, yinc1, yinc2;

        //    /* Adesso controlliamo se la linea � pi� "orizzontale" o "verticale", ed inizializziamo
        //       in maniera appropriate le variabili di comodo. */
        //    if (deltax >= deltay)
        //    {
        //        /* La linea risulta maggiormente schiacciata sull' ascissa */
        //        numpixels = deltax + 1;

        //        /* La nostra variabile decisionale, basata sulla x della linea */
        //        d = (2 * deltay) - deltax;

        //        /* Settiamo gli incrementi */
        //        dinc1 = deltay * 2;
        //        dinc2 = (deltay - deltax) * 2;
        //        xinc1 = xinc2 = 1;
        //        yinc1 = 0;
        //        yinc2 = 1;
        //    }
        //    else
        //    {
        //        /* La linea risulta maggiormente schiacciata sull' ordinata*/
        //        numpixels = deltay + 1;

        //        /* La nostra variabile decisionale, basata sulla y della linea */
        //        d = (2 * deltax) - deltay;

        //        /* Settiamo gli incrementi */
        //        dinc1 = deltax * 2;
        //        dinc2 = (deltax - deltay) * 2;
        //        xinc1 = 0;
        //        xinc2 = 1;
        //        yinc1 = yinc2 = 1;
        //    }

        //    /* Eseguiamo un controllo per settare il corretto 
        //        andamento della linea */
        //    if (x1 > x2)
        //    {
        //        xinc1 = -xinc1;
        //        xinc2 = -xinc2;
        //    }
        //    if (y1 > y2)
        //    {
        //        yinc1 = -yinc1;
        //        yinc2 = -yinc2;
        //    }

        //    /* Settiamo le coordinate iniziali  */
        //    x = x1;
        //    y = y1;

        //    /* Stampiamo la linea */
        //    for (i = 1; i < numpixels; i++)
        //    {
        //        //SetPixel(x, y, color);
        //        pixFillingDelegate(x, y, i - 1, numpixels - 1, true);

        //        /* Scegliamo l' incremento del "passo" a seconda dellla
        //            variabile decisionale */
        //        if (d < 0)
        //        {
        //            d = d + dinc1;
        //            x = x + xinc1;
        //            y = y + yinc1;
        //        }
        //        else
        //        {
        //            d = d + dinc2;
        //            x = x + xinc2;
        //            y = y + yinc2;
        //        }
        //    }
        //}

        #endregion

        /// <summary>
        /// Clips the line.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="clipLineType">Type of the clip line.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ClipLine(ref int x1, ref int y1, ref int x2, ref int y2, int clipLineType)
        {
            switch (clipLineType)
            {
                default:
                case CLIP_LINE:
                    // TODO: CLIP_LINE
                    return false;
                case CLIP_LINE_HORIZONTAL:
                    if (y1 < 0 || y1 >= pixelBuffer.Height) return false; // la linea � fuori dal clipBounds
                    if (x1 >= pixelBuffer.Width) return false; // x2 � di conseguenza > di _width
                    if (x2 < 0) return false; // x1 � di conseguenza < di -1
                    if (x1 < 0) x1 = 0;
                    if (x2 >= pixelBuffer.Width) x2 = pixelBuffer.Width - 1;
                    return true;
                case CLIP_LINE_VERTICAL:
                    if (x1 < 0 || x1 >= pixelBuffer.Width) return false; // la linea � fuori dal clipBounds
                    if (y1 >= pixelBuffer.Height) return false; // y2 � di conseguenza > di _height
                    if (y2 < 0) return false; // y1 � di conseguenza < di -1
                    if (y1 < 0) y1 = 0;
                    if (y2 >= pixelBuffer.Height) y2 = pixelBuffer.Height - 1;
                    return true;
                case CLIP_LINE_DIAGONAL:
                    // TODO: CLIP_LINE_DIAGONAL
                    return false;
            }
        }
        /// <summary>
        /// Gets the index of the pixel bytes.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <returns>System.Int32.</returns>
        private int GetPixelBytesIndex(int x, int y, int width)
        {
            return ((width * y) + x);
        }
        /// <summary>
        /// Internals the draw diagonal line.
        /// </summary>
        /// <param name="buff">The buff.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="delta">The delta.</param>
        /// <param name="rtl">if set to <c>true</c> [RTL].</param>
        /// <param name="color">The color.</param>
        private unsafe void InternalDrawDiagonalLine(int* buff, int x, int y, int delta, bool rtl, int color)
        {
            int start = GetPixelBytesIndex(x, y, pixelBuffer.Width);
            buff += start;

            int offset = rtl ? -1 : 1;

            for (int i = 0; i < delta; i++)
            {
                *buff = color;
                buff += (pixelBuffer.Width + offset);
            }
        }
        /// <summary>
        /// Internals the draw line.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="color">The color.</param>
        private unsafe void InternalDrawLine(int x1, int y1, int x2, int y2, int color)
        {
            int sX = x1;
            int sY = y1;
            int eX = x2;
            int eY = y2;

            if (y2 < y1)
            {
                sX = x2;
                sY = y2;
                eX = x1;
                eY = y1;
            }

            int dX = x2 - x1;
            int dY = y2 - y1;

            fixed (int* src = pixelBuffer.InternalBuffer)
            {
                if (dX == 0)
                {
                    if (!ClipLine(ref sX, ref sY, ref eX, ref eY, CLIP_LINE_VERTICAL)) return;
                    this.InternalDrawVerticalLine(src, sX, sY, sY + Math.Abs(dY), color);
                }
                else if (dY == 0)
                {
                    if (!ClipLine(ref sX, ref sY, ref eX, ref eY, CLIP_LINE_HORIZONTAL)) return;
                    this.InternalDrawHorizontalLine(src, sX, sY, sX + Math.Abs(dX), color);
                }
                else if (dX == dY)
                {
                    if (!ClipLine(ref sX, ref sY, ref eX, ref eY, CLIP_LINE_DIAGONAL)) return;
                    this.InternalDrawDiagonalLine(src, sX, sY, dY, (dX < 0), color);
                }
                else
                {
                    if (!ClipLine(ref sX, ref sY, ref eX, ref eY, CLIP_LINE)) return;
                    this.InternalDrawLine(src, sX, sY, eX, eY, color);
                }
            }

        }
        /// <summary>
        /// Internals the draw line.
        /// </summary>
        /// <param name="buff">The buff.</param>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="color">The color.</param>
        /// <exception cref="NotImplementedException"></exception>
        private unsafe void InternalDrawLine(int* buff, int x1, int y1, int x2, int y2, int color)
        {
            // TODO: DrawLine
            throw new NotImplementedException();
        }
        /// <summary>
        /// Internals the draw horizontal line.
        /// </summary>
        /// <param name="buff">The buff.</param>
        /// <param name="x1">The x1.</param>
        /// <param name="y">The y.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="color">The color.</param>
        private unsafe void InternalDrawHorizontalLine(int* buff, int x1, int y, int x2, int color)
        {
            //if (y < 0 || y >= _height) return;
            //if (x1 < 0) x1 = 0;
            //if (x2 >= _width) x2 = _width - 1;

            int len = x2 - x1 + 1;

            int start = this.GetPixelBytesIndex(x1, y, pixelBuffer.Width);
            buff += start;

            for (int i = 0; i < len; i++)
            {
                *((int*)buff) = color;
                buff++;
            }
        }
        /// <summary>
        /// Internals the draw vertical line.
        /// </summary>
        /// <param name="buff">The buff.</param>
        /// <param name="x">The x.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="color">The color.</param>
        private unsafe void InternalDrawVerticalLine(int* buff, int x, int y1, int y2, int color)
        {
            //if (x < 0 || x >= _width) return;
            //if (y1 < 0) y1 = 0;
            //if (y2 >= _height) y2 = _height - 1;

            int len = y2 - y1 + 1;

            int start = this.GetPixelBytesIndex(x, y1, pixelBuffer.Width);
            buff += start;

            for (int i = 0; i < len; i++)
            {
                *((int*)buff) = color;
                buff += pixelBuffer.Width;
            }
        }

        #endregion

    }
}
