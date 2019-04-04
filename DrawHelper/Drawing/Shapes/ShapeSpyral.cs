// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="ShapeSpyral.cs" company="Zeroit Dev Technologies">
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
    /// Class ShapeSpyral.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.ShapeCurve" />
    public class ShapeSpyral  :ShapeCurve
	{
        /// <summary>
        /// The visible points
        /// </summary>
        private PointF[] _visiblePoints;
        /// <summary>
        /// The start point
        /// </summary>
        private PointF _startPoint;
        /// <summary>
        /// The frequency
        /// </summary>
        private float _frequency;
        /// <summary>
        /// The number steps
        /// </summary>
        private int _numSteps;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeSpyral"/> class.
        /// </summary>
        /// <param name="xStartPoint">The x start point.</param>
        /// <param name="yStartPoint">The y start point.</param>
        /// <param name="frequency">The frequency.</param>
        /// <param name="numSteps">The number steps.</param>
        public ShapeSpyral(float xStartPoint,float yStartPoint, float frequency, int numSteps)
            : this(new PointF(xStartPoint,yStartPoint), frequency, numSteps, 0, null) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeSpyral"/> class.
        /// </summary>
        /// <param name="xStartPoint">The x start point.</param>
        /// <param name="yStartPoint">The y start point.</param>
        /// <param name="frequency">The frequency.</param>
        /// <param name="numSteps">The number steps.</param>
        /// <param name="rotation">The rotation.</param>
        public ShapeSpyral(float xStartPoint, float yStartPoint, float frequency, int numSteps, float rotation)
            : this(new PointF(xStartPoint, yStartPoint), frequency, numSteps, rotation, null) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeSpyral"/> class.
        /// </summary>
        /// <param name="xStartPoint">The x start point.</param>
        /// <param name="yStartPoint">The y start point.</param>
        /// <param name="frequency">The frequency.</param>
        /// <param name="numSteps">The number steps.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="pen">The pen.</param>
        public ShapeSpyral(float xStartPoint, float yStartPoint, float frequency, int numSteps, float rotation, Pen pen)
            : this(new PointF(xStartPoint, yStartPoint), frequency, numSteps, rotation, pen) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeSpyral"/> class.
        /// </summary>
        /// <param name="startPoint">The start point.</param>
        /// <param name="frequency">The frequency.</param>
        /// <param name="numSteps">The number steps.</param>
        public ShapeSpyral(PointF startPoint, float frequency, int numSteps)
            : this(startPoint, frequency, numSteps, 0, null) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeSpyral"/> class.
        /// </summary>
        /// <param name="startPoint">The start point.</param>
        /// <param name="frequency">The frequency.</param>
        /// <param name="numSteps">The number steps.</param>
        /// <param name="rotation">The rotation.</param>
        public ShapeSpyral(PointF startPoint, float frequency, int numSteps, float rotation)
            : this(startPoint, frequency, numSteps, rotation, null) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeSpyral"/> class.
        /// </summary>
        /// <param name="startPoint">The start point.</param>
        /// <param name="frequency">The frequency.</param>
        /// <param name="numSteps">The number steps.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="pen">The pen.</param>
        public ShapeSpyral(PointF startPoint, float frequency, int numSteps, float rotation, Pen pen)
			:base()
		{
			_startPoint = startPoint;
			_frequency = frequency;
            if (_frequency < 1) _frequency = 1;
			_numSteps = numSteps;
            if (_numSteps < 1) _numSteps = 1;

			this.Rotation = rotation;
			this.Pen = pen;

            InternalRotationBasePoint = _startPoint;

			UpdatePath();
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Gets or sets the start point.
        /// </summary>
        /// <value>The start point.</value>
        public override PointF StartPoint
        {
            get
            {
                return _startPoint;
            }
            set
            {
                _startPoint = value;
                UpdatePath();
            }
        }
        /// <summary>
        /// Gets or sets the points.
        /// </summary>
        /// <value>The points.</value>
        public override PointF[] Points
        {
            get
            {
                return _visiblePoints;
            }
            set
            {
                // base.Points = value;
            }
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
            return "{Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.ShapeSpyral}";
        }

        /// <summary>
        /// Updates the path.
        /// </summary>
        protected override void UpdatePath()
		{
			if (_numSteps == 0) return;

            PointF[] pts = CalculatePoints();
			InternalPath = new GraphicsPath();
            InternalPath.AddCurve(pts, 0, pts.Length - 2, 0.85f);

            _visiblePoints = new PointF[pts.Length - 1];
            Array.Copy(pts, _visiblePoints, _visiblePoints.Length);

			Matrix mtx = new Matrix();
			mtx.RotateAt(this.Rotation, InternalRotationBasePoint);
			InternalPath.Transform(mtx);
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Calculates the points.
        /// </summary>
        /// <returns>PointF[].</returns>
        private PointF[] CalculatePoints()
		{
			int pointCount = (4 * _numSteps);
			PointF[] points = new PointF[pointCount];
			points[0]=_startPoint;
			PointF prevPoint = points[0];
			int lastQuadrant = 1;
			float step = _frequency / 4;

			for (int i = 1; i < pointCount; i++)
			{
				switch (lastQuadrant)
				{
					default:
					case 1:
						points[i] = new PointF(prevPoint.X - (i * step), prevPoint.Y + (i * step));
						break;
					case 2:
						points[i] = new PointF(prevPoint.X - (i * step), prevPoint.Y - (i * step));
						break;
					case 3:
						points[i] = new PointF(prevPoint.X + (i * step), prevPoint.Y - (i * step));
						break;
					case 4:
						points[i] = new PointF(prevPoint.X + (i * step), prevPoint.Y + (i * step));
						break;
				}

				prevPoint = points[i];

				lastQuadrant++;
				if (lastQuadrant > 4) lastQuadrant = 1;
			}

            //points[points.Length - 1] = new PointF(prevPoint.X-5, prevPoint.Y-10);// new PointF(prevPoint.X, prevPoint.Y - 20);

			return points;
        }

        #endregion

    }
}