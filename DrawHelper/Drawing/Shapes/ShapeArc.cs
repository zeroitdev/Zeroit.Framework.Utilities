// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="ShapeArc.cs" company="Zeroit Dev Technologies">
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
    /// Arc shape
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.ShapeLine" />
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.IRectangle" />
	public class ShapeArc  :ShapeLine,IRectangle
    {

        /// <summary>
        /// The left
        /// </summary>
        private float _left, _top, _width, _height, _startAngle, _sweepAngle;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeArc"/> class.
        /// </summary>
        internal ShapeArc()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeArc"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="startAngle">The start angle.</param>
        /// <param name="sweepAngle">The sweep angle.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="pen">The pen.</param>
        public ShapeArc(float left, float top, float width, float height, float startAngle, float sweepAngle, float rotation, Pen pen)
        {
            _left = left;
            _top = top;
            _width = width;
            _height = height;
            _startAngle = startAngle;
            _sweepAngle = sweepAngle;

            this.Rotation = rotation;
            this.Pen = pen;

            UpdatePath();
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Updates the path.
        /// </summary>
        protected override void UpdatePath()
        {
            InternalPath = new GraphicsPath();
            InternalPath.AddArc(_left, _top, _width, _height, _startAngle, _sweepAngle);

            Matrix mtx = new Matrix();
            mtx.RotateAt(this.Rotation, InternalRotationBasePoint);
            InternalPath.Transform(mtx);
        }

        /// <summary>
        /// Gets or sets the start point.
        /// </summary>
        /// <value>The start point.</value>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public override PointF StartPoint
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        /// <summary>
        /// Gets or sets the end point.
        /// </summary>
        /// <value>The end point.</value>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public override PointF EndPoint
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        public override PointF Location
        {
            get
            {
                return new PointF(_left,_top);
            }
            set
            {
                _left = value.X;
                _top = value.Y;
            }
        }
        /// <summary>
        /// Gets the bounds.
        /// </summary>
        /// <value>The bounds.</value>
        public override RectangleF Bounds
        {
            get
            {
                return new RectangleF(_left, _top, _width, _height);
            }
        }

        #endregion

        #region IRectangle Members

        /// <summary>
        /// Left position of this Shape
        /// </summary>
        /// <value>The left.</value>
        public float Left
        {
            get
            {
                return _left;
            }
            set
            {
                _left = value;
                UpdatePath();
            }
        }

        /// <summary>
        /// Top position of this Shape
        /// </summary>
        /// <value>The top.</value>
        public float Top
        {
            get
            {
                return _top;
            }
            set
            {
                _top = value;
                UpdatePath();
            }
        }

        /// <summary>
        /// Width of this Shape
        /// </summary>
        /// <value>The width.</value>
        public float Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                UpdatePath();
            }
        }

        /// <summary>
        /// Height of this Shape
        /// </summary>
        /// <value>The height.</value>
        public float Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                UpdatePath();
            }
        }

        #endregion

        #region Virtual Members

        /// <summary>
        /// Start Angle for the Arc Shape
        /// </summary>
        /// <value>The start angle.</value>
        public virtual float StartAngle
        {
            get
            {
                return _startAngle;
            }
            set
            {
                _startAngle = value;
                UpdatePath();
            }
        }

        /// <summary>
        /// Sweep Angle for the Arc Shape
        /// </summary>
        /// <value>The sweep angle.</value>
        public virtual float SweepAngle
        {
            get
            {
                return _sweepAngle;
            }
            set
            {
                _sweepAngle = value;
                UpdatePath();
            }
        }

        #endregion
    }
}