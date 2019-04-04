// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="ShapeClosedCurve.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes
{

    /// <summary>
    /// Class ShapeClosedCurve.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.ShapePolygon" />
    public class ShapeClosedCurve :ShapePolygon
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeClosedCurve"/> class.
        /// </summary>
        internal ShapeClosedCurve()
		{

		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeClosedCurve"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        public ShapeClosedCurve(PointF[] points)
            : this(points, 0, null, null) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeClosedCurve"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <param name="rotation">The rotation.</param>
        public ShapeClosedCurve(PointF[] points, float rotation)
            : this(points, rotation, null, null) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeClosedCurve"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <param name="pen">The pen.</param>
        public ShapeClosedCurve(PointF[] points, Pen pen)
            : base(points, 0, pen) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeClosedCurve"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="pen">The pen.</param>
        public ShapeClosedCurve(PointF[] points, float rotation, Pen pen)
            : base(points, rotation, pen) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeClosedCurve"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="brush">The brush.</param>
        public ShapeClosedCurve(PointF[] points, float rotation, Brush brush)
            : this(points, rotation, null,brush) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeClosedCurve"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        public ShapeClosedCurve(PointF[] points, float rotation, Pen pen, Brush brush)
            : base(points, rotation, pen)
        {
            this.Brush = brush;
        }

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
            return "{Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.ShapeClosedCurve}";
        }

        /// <summary>
        /// Updates the path.
        /// </summary>
        protected override void UpdatePath()
        {
            if (this.Points == null || this.Points.Length == 0) return;

            InternalPath = new GraphicsPath();
            InternalPath.AddClosedCurve(this.Points);

            Matrix mtx = new Matrix();
            mtx.RotateAt(this.Rotation, InternalRotationBasePoint);
            InternalPath.Transform(mtx);
        }

        #endregion      
	}
}