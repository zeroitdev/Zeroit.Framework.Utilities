// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="ShapePolygon.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes
{

    /// <summary>
    /// Class ShapePolygon.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.ShapePolyline" />
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.IFillable" />
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.IDrawable" />
    public class ShapePolygon : ShapePolyline, IFillable, IDrawable
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapePolygon"/> class.
        /// </summary>
        internal ShapePolygon()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapePolygon"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        public ShapePolygon(PointF[] points)
            : base(points, 0, null) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapePolygon"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <param name="rotation">The rotation.</param>
        public ShapePolygon(PointF[] points, float rotation)
            : base(points, rotation, null) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapePolygon"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <param name="pen">The pen.</param>
        public ShapePolygon(PointF[] points, Pen pen)
            : base(points, 0, pen) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapePolygon"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="pen">The pen.</param>
        public ShapePolygon(PointF[] points, float rotation, Pen pen)
            : base(points, rotation, pen) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapePolygon"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="brush">The brush.</param>
        public ShapePolygon(PointF[] points, float rotation, Brush brush)
            : this(points, rotation, null,brush) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapePolygon"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        public ShapePolygon(PointF[] points, float rotation, Pen pen, Brush brush)
            : base(points, rotation, pen)
        {
            this.Brush = brush;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Paints the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="smoothingMode">The smoothing mode.</param>
        public override void Paint(Graphics graphics, SmoothingMode smoothingMode)
        {
            this.Fill(graphics);
            this.Draw(graphics, smoothingMode);
        }
        /// <summary>
        /// Draw the shape on the Graphics
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        public override void Paint(Graphics graphics)
        {
            this.Paint(graphics, graphics.SmoothingMode);
        }

        /// <summary>
        /// Gets the thumb.
        /// </summary>
        /// <param name="thumbSize">Size of the thumb.</param>
        /// <returns>Image.</returns>
        /// <exception cref="Exception">The method or operation is not implemented.</exception>
        public override Image GetThumb(ShapeThumbSize thumbSize)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return "{Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.ShapePolygon}";
        }

        /// <summary>
        /// Updates the path.
        /// </summary>
        protected override void UpdatePath()
        {
            if (this.Points == null || this.Points.Length == 0) return;

            InternalPath = new GraphicsPath();
            InternalPath.AddPolygon(this.Points);

            Matrix mtx = new Matrix();
            mtx.RotateAt(this.Rotation, InternalRotationBasePoint);
            InternalPath.Transform(mtx);
        }

        #endregion

        #region IFillable Members

        /// <summary>
        /// Fills the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        public void Fill(Graphics graphics)
        {
            if(this.Brush != null)
                graphics.FillPath(this.Brush, InternalPath);
        }

        #endregion
    }
}