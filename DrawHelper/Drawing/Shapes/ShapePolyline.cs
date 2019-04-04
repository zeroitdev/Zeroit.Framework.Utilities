// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="ShapePolyline.cs" company="Zeroit Dev Technologies">
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
    /// Class ShapePolyline.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.ShapeLine" />
    public class ShapePolyline :ShapeLine
	{

        /// <summary>
        /// The points
        /// </summary>
        private PointF[] _points;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapePolyline"/> class.
        /// </summary>
        internal ShapePolyline()
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapePolyline"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        public ShapePolyline(PointF[] points)
			: this(points, 0, null) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapePolyline"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <param name="rotation">The rotation.</param>
        public ShapePolyline(PointF[] points, float rotation)
			: this(points, rotation, null) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapePolyline"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <param name="pen">The pen.</param>
        public ShapePolyline(PointF[] points, Pen pen)
			: this(points, 0, pen) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapePolyline"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="pen">The pen.</param>
        public ShapePolyline(PointF[] points, float rotation, Pen pen)
		{
			_points = points;

			this.Rotation = rotation;
			this.Pen = pen;

			this.UpdatePath();
		}

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
				float minX = float.MaxValue;
				float minY = minX;
				float maxX = float.MinValue;
				float maxY = maxX;

				for (int i = 0; i < _points.Length; i++)
				{
					PointF current = _points[i];
					minX = Math.Min(minX, current.X);
					minY = Math.Min(minY, current.Y);
					maxX = Math.Max(maxX, current.X);
					maxY = Math.Max(maxY, current.Y);
				}

				return new RectangleF(minX, minY, maxX - minX, maxY - minY);
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
                return _points[0];
            }
            set
            {
                _points[0] = value;
                UpdatePath();
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
                return _points[_points.Length-1];
            }
            set
            {
                _points[_points.Length - 1] = value;
                UpdatePath();
            }
        }

        /// <summary>
        /// Translates the specified dx.
        /// </summary>
        /// <param name="dx">The dx.</param>
        /// <param name="dy">The dy.</param>
        public override void Translate(float dx, float dy)
		{
			for (int i = 0; i < _points.Length; i++)
			{
				_points[i].X += dx;
				_points[i].Y += dy;
			}
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
            return "{Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.ShapePolyline}";
        }

        /// <summary>
        /// Updates the path.
        /// </summary>
        protected override void UpdatePath()
		{
            if (_points==null || _points.Length == 0) return;

			InternalPath = new GraphicsPath();
			InternalPath.AddLines(_points);

			Matrix mtx = new Matrix();
			mtx.RotateAt(this.Rotation, InternalRotationBasePoint);
			InternalPath.Transform(mtx);
		}

        #endregion

        /// <summary>
        /// Gets or sets the points.
        /// </summary>
        /// <value>The points.</value>
        public virtual PointF[] Points
		{
			get
			{
				return _points;
			}
			set
			{
				_points = value;
			}
		}

	}
}