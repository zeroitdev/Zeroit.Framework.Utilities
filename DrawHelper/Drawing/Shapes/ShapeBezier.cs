// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="ShapeBezier.cs" company="Zeroit Dev Technologies">
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
    /// Class ShapeBezier.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.ShapeLine" />
    public class ShapeBezier  :ShapeLine
	{
        /// <summary>
        /// The x start
        /// </summary>
        private float _xStart, _yStart, _xFirstControl, _yFirstControl, _xSecondControl, _ySecondControl, _xEnd, _yEnd;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeBezier"/> class.
        /// </summary>
        /// <param name="xStartPoint">The x start point.</param>
        /// <param name="yStartPoint">The y start point.</param>
        /// <param name="xFirstControlPoint">The x first control point.</param>
        /// <param name="yFirstControlPoint">The y first control point.</param>
        /// <param name="xSecondControlPoint">The x second control point.</param>
        /// <param name="ySecondControlPoint">The y second control point.</param>
        /// <param name="xEndPoint">The x end point.</param>
        /// <param name="yEndPoint">The y end point.</param>
        public ShapeBezier(float xStartPoint, float yStartPoint, float xFirstControlPoint, float yFirstControlPoint, float xSecondControlPoint, float ySecondControlPoint, float xEndPoint, float yEndPoint)
			: this(xStartPoint, yStartPoint, xFirstControlPoint, yFirstControlPoint, xSecondControlPoint, ySecondControlPoint, xEndPoint, yEndPoint, 0, null) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeBezier"/> class.
        /// </summary>
        /// <param name="xStartPoint">The x start point.</param>
        /// <param name="yStartPoint">The y start point.</param>
        /// <param name="xFirstControlPoint">The x first control point.</param>
        /// <param name="yFirstControlPoint">The y first control point.</param>
        /// <param name="xSecondControlPoint">The x second control point.</param>
        /// <param name="ySecondControlPoint">The y second control point.</param>
        /// <param name="xEndPoint">The x end point.</param>
        /// <param name="yEndPoint">The y end point.</param>
        /// <param name="rotation">The rotation.</param>
        public ShapeBezier(float xStartPoint, float yStartPoint, float xFirstControlPoint, float yFirstControlPoint, float xSecondControlPoint, float ySecondControlPoint, float xEndPoint, float yEndPoint, float rotation)
			: this(xStartPoint, yStartPoint, xFirstControlPoint, yFirstControlPoint, xSecondControlPoint, ySecondControlPoint, xEndPoint, yEndPoint, 0, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeBezier"/> class.
        /// </summary>
        /// <param name="startPoint">The start point.</param>
        /// <param name="firstControlPoint">The first control point.</param>
        /// <param name="secondControlPoint">The second control point.</param>
        /// <param name="endPoint">The end point.</param>
        public ShapeBezier(PointF startPoint, PointF firstControlPoint, PointF secondControlPoint, PointF endPoint)
			: this(startPoint.X, startPoint.Y, firstControlPoint.X, firstControlPoint.Y, secondControlPoint.X, secondControlPoint.Y, endPoint.X, endPoint.Y, 0, null) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeBezier"/> class.
        /// </summary>
        /// <param name="startPoint">The start point.</param>
        /// <param name="firstControlPoint">The first control point.</param>
        /// <param name="secondControlPoint">The second control point.</param>
        /// <param name="endPoint">The end point.</param>
        /// <param name="rotation">The rotation.</param>
        public ShapeBezier(PointF startPoint, PointF firstControlPoint, PointF secondControlPoint, PointF endPoint,float rotation)
			: this(startPoint.X, startPoint.Y, firstControlPoint.X, firstControlPoint.Y, secondControlPoint.X, secondControlPoint.Y, endPoint.X, endPoint.Y, rotation, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeBezier"/> class.
        /// </summary>
        /// <param name="xStartPoint">The x start point.</param>
        /// <param name="yStartPoint">The y start point.</param>
        /// <param name="xFirstControlPoint">The x first control point.</param>
        /// <param name="yFirstControlPoint">The y first control point.</param>
        /// <param name="xSecondControlPoint">The x second control point.</param>
        /// <param name="ySecondControlPoint">The y second control point.</param>
        /// <param name="xEndPoint">The x end point.</param>
        /// <param name="yEndPoint">The y end point.</param>
        /// <param name="pen">The pen.</param>
        public ShapeBezier(float xStartPoint, float yStartPoint, float xFirstControlPoint, float yFirstControlPoint, float xSecondControlPoint, float ySecondControlPoint, float xEndPoint, float yEndPoint, Pen pen)
			: this(xStartPoint, yStartPoint, xFirstControlPoint, yFirstControlPoint, xSecondControlPoint, ySecondControlPoint, xEndPoint, yEndPoint, 0,pen) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeBezier"/> class.
        /// </summary>
        /// <param name="xStartPoint">The x start point.</param>
        /// <param name="yStartPoint">The y start point.</param>
        /// <param name="xFirstControlPoint">The x first control point.</param>
        /// <param name="yFirstControlPoint">The y first control point.</param>
        /// <param name="xSecondControlPoint">The x second control point.</param>
        /// <param name="ySecondControlPoint">The y second control point.</param>
        /// <param name="xEndPoint">The x end point.</param>
        /// <param name="yEndPoint">The y end point.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="pen">The pen.</param>
        public ShapeBezier(float xStartPoint, float yStartPoint, float xFirstControlPoint, float yFirstControlPoint, float xSecondControlPoint, float ySecondControlPoint, float xEndPoint, float yEndPoint, float rotation, Pen pen)
		{
			_xStart = xStartPoint;
			_yStart = yStartPoint;
			_xFirstControl = xFirstControlPoint;
			_yFirstControl = yFirstControlPoint;
			_xSecondControl = xSecondControlPoint;
			_ySecondControl = ySecondControlPoint;
			_xEnd = xEndPoint;
			_yEnd = yEndPoint;

			this.Rotation = rotation;
			this.Pen = pen;

			this.UpdatePath();
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeBezier"/> class.
        /// </summary>
        /// <param name="startPoint">The start point.</param>
        /// <param name="firstControlPoint">The first control point.</param>
        /// <param name="secondControlPoint">The second control point.</param>
        /// <param name="endPoint">The end point.</param>
        /// <param name="pen">The pen.</param>
        public ShapeBezier(PointF startPoint, PointF firstControlPoint, PointF secondControlPoint, PointF endPoint,Pen pen)
			: this(startPoint.X, startPoint.Y, firstControlPoint.X, firstControlPoint.Y, secondControlPoint.X, secondControlPoint.Y, endPoint.X, endPoint.Y, 0,pen) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeBezier"/> class.
        /// </summary>
        /// <param name="startPoint">The start point.</param>
        /// <param name="firstControlPoint">The first control point.</param>
        /// <param name="secondControlPoint">The second control point.</param>
        /// <param name="endPoint">The end point.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="pen">The pen.</param>
        public ShapeBezier(PointF startPoint, PointF firstControlPoint, PointF secondControlPoint, PointF endPoint, float rotation,Pen pen)
			: this(startPoint.X, startPoint.Y, firstControlPoint.X, firstControlPoint.Y, secondControlPoint.X, secondControlPoint.Y, endPoint.X, endPoint.Y, rotation,pen) { }

        #endregion

        #region Overrides

        /// <summary>
        /// Gets the bounds.
        /// </summary>
        /// <value>The bounds.</value>
        public override RectangleF Bounds
		{
			get
			{
				float left = Math.Min(Math.Min(_xStart, _xEnd), Math.Min(_xFirstControl, _xSecondControl));
				float top = Math.Min(Math.Min(_yStart, _yEnd), Math.Min(_yFirstControl, _ySecondControl));
				float right = Math.Max(Math.Max(_xStart, _xEnd), Math.Max(_xFirstControl, _xSecondControl));
				float bottom = Math.Max(Math.Max(_yStart, _yEnd), Math.Max(_yFirstControl, _ySecondControl));

				return new RectangleF(left, top, right - left, bottom - top);
			}
		}
        /// <summary>
        /// Gets or sets the start point.
        /// </summary>
        /// <value>The start point.</value>
        public override PointF StartPoint
		{
			get
			{
				return new PointF(_xStart,_yStart);
			}
			set
			{
				_xStart = value.X;
				_yStart = value.Y;
			}
		}
        /// <summary>
        /// Gets or sets the end point.
        /// </summary>
        /// <value>The end point.</value>
        public override PointF EndPoint
		{
			get
			{
				return new PointF(_xEnd,_yEnd);
			}
			set
			{
				_xEnd = value.X;
				_yEnd = value.Y;
			}
		}

        /// <summary>
        /// Translates the specified dx.
        /// </summary>
        /// <param name="dx">The dx.</param>
        /// <param name="dy">The dy.</param>
        public override void Translate(float dx, float dy)
		{
			_xStart += dx;
			_xFirstControl += dx;
			_xSecondControl += dx;
			_xEnd += dx;
			_yStart += dy;
			_yFirstControl += dy;
			_ySecondControl += dy;
			_yEnd += dy;
			UpdatePath();
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
            return "{Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.ShapeBezier}";
        }

        /// <summary>
        /// Updates the path.
        /// </summary>
        protected override void UpdatePath()
		{
			InternalPath = new GraphicsPath();
			InternalPath.AddBezier(_xStart, _yStart, _xFirstControl, _yFirstControl, _xSecondControl, _ySecondControl, _xEnd, _yEnd);

			Matrix mtx = new Matrix();
			mtx.RotateAt(this.Rotation, InternalRotationBasePoint);
			InternalPath.Transform(mtx);
		}

        #endregion

        #region Virtuals

        /// <summary>
        /// Gets or sets the first control point.
        /// </summary>
        /// <value>The first control point.</value>
        public virtual PointF FirstControlPoint
		{
			get
			{
				return new PointF(_xFirstControl, _yFirstControl);
			}
			set
			{
				_xFirstControl = value.X;
				_yFirstControl = value.Y;
				UpdatePath();
			}
		}
        /// <summary>
        /// Gets or sets the second control point.
        /// </summary>
        /// <value>The second control point.</value>
        public virtual PointF SecondControlPoint
		{
			get
			{
				return new PointF(_xSecondControl, _ySecondControl);
			}
			set
			{
				_xSecondControl = value.X;
				_ySecondControl = value.Y;
				UpdatePath();
			}
		}

		#endregion
	}
}

