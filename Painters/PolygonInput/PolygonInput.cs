// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="PolygonInput.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace Zeroit.Framework.Utilities.GraphicsExtension
{
    /// <summary>
    /// Class representing a polygon.
    /// </summary>
    [TypeConverter(typeof(Converter))]
    [EditorAttribute(typeof(PolygonInputEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public class PolygonInput
    {

        #region Enum

        /// <summary>
        /// Enum FillModes
        /// </summary>
        public enum FillModes
        {
            /// <summary>
            /// The fill
            /// </summary>
            Fill,
            /// <summary>
            /// The border
            /// </summary>
            Border,
            /// <summary>
            /// The both
            /// </summary>
            Both
        }

        /// <summary>
        /// Enum ShapeTypes
        /// </summary>
        public enum ShapeTypes
        {
            /// <summary>
            /// The polygon
            /// </summary>
            Polygon,
            /// <summary>
            /// The spline
            /// </summary>
            Spline
        }

        #endregion

        #region Private Fields

        /// <summary>
        /// The points
        /// </summary>
        private List<List<Point>> points = new List<List<Point>>()
        {
            new List<Point>()
            {
                new Point(0, 0),
                new Point(50, 50),
                new Point(100, 0),
                new Point(0, 0)

            }

        };

        /// <summary>
        /// The fill mode
        /// </summary>
        private FillModes fillMode = FillModes.Both;

        /// <summary>
        /// The shape type
        /// </summary>
        private ShapeTypes shapeType = ShapeTypes.Polygon;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the points.
        /// </summary>
        /// <value>The points.</value>
        public List<List<Point>> Points
        {
            get { return points; }
            set { points = value; }
        }

        /// <summary>
        /// Gets or sets the fill mode.
        /// </summary>
        /// <value>The fill mode.</value>
        public FillModes FillMode
        {
            get { return fillMode; }
            set { fillMode = value; }
        }

        /// <summary>
        /// Gets or sets the type of the shape.
        /// </summary>
        /// <value>The type of the shape.</value>
        public ShapeTypes ShapeType
        {
            get { return shapeType; }
            set { shapeType = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PolygonInput"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <param name="fillMode">The fill mode.</param>
        /// <param name="shapeType">Type of the shape.</param>
        public PolygonInput(List<List<Point>> points, FillModes fillMode, ShapeTypes shapeType)
        {
            this.points = points;
            this.fillMode = fillMode;
            this.shapeType = shapeType;
        }

        #endregion

        /// <summary>
        /// Draws the shape.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="FillShape">The fill shape.</param>
        /// <param name="DrawShape">The draw shape.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// FillModes - null
        /// or
        /// FillModes - null
        /// or
        /// ShapeTypes - null
        /// </exception>
        public void DrawShape(System.Drawing.Graphics G, Brush FillShape, Pen DrawShape)
        {
            foreach (List<Point> points in Points)
            {
                switch (ShapeType)
                {
                    case ShapeTypes.Polygon:
                        switch (FillMode)
                        {
                            case FillModes.Fill:
                                G.FillPolygon(FillShape, points.ToArray());
                                break;
                            case FillModes.Border:
                                G.DrawPolygon(DrawShape, points.ToArray());
                                break;
                            case FillModes.Both:
                                G.FillPolygon(FillShape, points.ToArray());
                                G.DrawPolygon(DrawShape, points.ToArray());
                                break;
                            default:
                                throw new ArgumentOutOfRangeException(nameof(FillModes), FillMode, null);
                        }
                        
                        break;
                    case ShapeTypes.Spline:
                        switch (FillMode)
                        {
                            case FillModes.Fill:
                                G.FillClosedCurve(FillShape, points.ToArray());
                                break;
                            case FillModes.Border:
                                G.DrawClosedCurve(DrawShape, points.ToArray());
                                break;
                            case FillModes.Both:
                                G.FillClosedCurve(FillShape, points.ToArray());
                                G.DrawClosedCurve(DrawShape, points.ToArray());
                                break;
                            default:
                                throw new ArgumentOutOfRangeException(nameof(FillModes), FillMode, null);
                        }
                        
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(ShapeTypes), ShapeType, null);
                }

                
            }
        }

        
    }

    
}
