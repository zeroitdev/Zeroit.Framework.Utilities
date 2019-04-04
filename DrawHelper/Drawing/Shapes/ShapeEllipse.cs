// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="ShapeEllipse.cs" company="Zeroit Dev Technologies">
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
    /// Class ShapeEllipse.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.ShapeRectangle" />
    public class ShapeEllipse : ShapeRectangle
	{

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEllipse"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public ShapeEllipse(float left, float top, float width, float height)
			: base(new RectangleF(left, top, width, height), 0) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEllipse"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="rotation">The rotation.</param>
        public ShapeEllipse(float left, float top, float width, float height, float rotation)
			: base(new RectangleF(left, top, width, height), rotation) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEllipse"/> class.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        public ShapeEllipse(RectangleF bounds)
			: base(bounds, 0) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEllipse"/> class.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        /// <param name="rotation">The rotation.</param>
        public ShapeEllipse(RectangleF bounds, float rotation)
			: base(bounds, rotation) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEllipse"/> class.
        /// </summary>
        /// <param name="firstCorner">The first corner.</param>
        /// <param name="secondCorner">The second corner.</param>
        public ShapeEllipse(PointF firstCorner, PointF secondCorner)
			: base(firstCorner, secondCorner, 0) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEllipse"/> class.
        /// </summary>
        /// <param name="firstCorner">The first corner.</param>
        /// <param name="secondCorner">The second corner.</param>
        /// <param name="rotation">The rotation.</param>
        public ShapeEllipse(PointF firstCorner, PointF secondCorner, float rotation)
			: base(firstCorner, secondCorner, rotation) { }


        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEllipse"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="pen">The pen.</param>
        public ShapeEllipse(float left, float top, float width, float height, Pen pen)
			: base(new RectangleF(left, top, width, height), 0, pen) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEllipse"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="pen">The pen.</param>
        public ShapeEllipse(float left, float top, float width, float height, float rotation, Pen pen)
			: base(new RectangleF(left, top, width, height), rotation, pen) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEllipse"/> class.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        /// <param name="pen">The pen.</param>
        public ShapeEllipse(RectangleF bounds, Pen pen)
			: base(bounds, 0, pen) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEllipse"/> class.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="pen">The pen.</param>
        public ShapeEllipse(RectangleF bounds, float rotation, Pen pen)
			: base(bounds, rotation, pen) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEllipse"/> class.
        /// </summary>
        /// <param name="firstCorner">The first corner.</param>
        /// <param name="secondCorner">The second corner.</param>
        /// <param name="pen">The pen.</param>
        public ShapeEllipse(PointF firstCorner, PointF secondCorner, Pen pen)
			: base(firstCorner, secondCorner, 0, pen) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEllipse"/> class.
        /// </summary>
        /// <param name="firstCorner">The first corner.</param>
        /// <param name="secondCorner">The second corner.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="pen">The pen.</param>
        public ShapeEllipse(PointF firstCorner, PointF secondCorner, float rotation, Pen pen)
			: base(firstCorner, secondCorner, rotation, pen) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEllipse"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="brush">The brush.</param>
        public ShapeEllipse(float left, float top, float width, float height, Brush brush)
			: base(new RectangleF(left, top, width, height), 0, brush) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEllipse"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="brush">The brush.</param>
        public ShapeEllipse(float left, float top, float width, float height, float rotation, Brush brush)
			: base(new RectangleF(left, top, width, height), rotation, brush) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEllipse"/> class.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        /// <param name="brush">The brush.</param>
        public ShapeEllipse(RectangleF bounds, Brush brush)
			: base(bounds, 0, brush) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEllipse"/> class.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="brush">The brush.</param>
        public ShapeEllipse(RectangleF bounds, float rotation, Brush brush)
			: base(bounds, rotation, brush) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEllipse"/> class.
        /// </summary>
        /// <param name="firstCorner">The first corner.</param>
        /// <param name="secondCorner">The second corner.</param>
        /// <param name="brush">The brush.</param>
        public ShapeEllipse(PointF firstCorner, PointF secondCorner, Brush brush)
			: base(firstCorner, secondCorner, 0, brush) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEllipse"/> class.
        /// </summary>
        /// <param name="firstCorner">The first corner.</param>
        /// <param name="secondCorner">The second corner.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="brush">The brush.</param>
        public ShapeEllipse(PointF firstCorner, PointF secondCorner, float rotation, Brush brush)
			: base(firstCorner, secondCorner, rotation, brush) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEllipse"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        public ShapeEllipse(float left, float top, float width, float height, Pen pen, Brush brush)
			: base(new RectangleF(left, top, width, height), 0, pen, brush) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEllipse"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        public ShapeEllipse(float left, float top, float width, float height, float rotation, Pen pen, Brush brush)
			: base(new RectangleF(left, top, width, height), 0, pen, brush) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEllipse"/> class.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        public ShapeEllipse(RectangleF bounds, Pen pen, Brush brush)
			: base(bounds, 0, pen, brush) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEllipse"/> class.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        public ShapeEllipse(RectangleF bounds, float rotation, Pen pen, Brush brush)
			: base(bounds, rotation, pen, brush) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEllipse"/> class.
        /// </summary>
        /// <param name="firstCorner">The first corner.</param>
        /// <param name="secondCorner">The second corner.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        public ShapeEllipse(PointF firstCorner, PointF secondCorner, Pen pen, Brush brush)
			: base(firstCorner, secondCorner, 0, pen, brush) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEllipse"/> class.
        /// </summary>
        /// <param name="firstCorner">The first corner.</param>
        /// <param name="secondCorner">The second corner.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        public ShapeEllipse(PointF firstCorner, PointF secondCorner, float rotation, Pen pen, Brush brush)
			: base(firstCorner, secondCorner, rotation, pen, brush) { }

        #endregion

        #region Overrides

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
            return "{Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.ShapeEllipse}";
        }

        /// <summary>
        /// Updates the path.
        /// </summary>
        protected override void UpdatePath()
		{
			InternalPath = new GraphicsPath(FillMode.Winding);
			InternalPath.AddEllipse(this.Bounds);

			Matrix mtx = new Matrix();
			mtx.RotateAt(this.Rotation, this.Location);
			InternalPath.Transform(mtx);
		}

		#endregion

	}
}