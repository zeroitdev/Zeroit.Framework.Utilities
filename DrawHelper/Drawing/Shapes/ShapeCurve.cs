// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="ShapeCurve.cs" company="Zeroit Dev Technologies">
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
    /// Class ShapeCurve.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.ShapePolyline" />
    public class ShapeCurve  :ShapePolyline
	{

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeCurve"/> class.
        /// </summary>
        internal ShapeCurve()
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeCurve"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        public ShapeCurve(PointF[] points)
			: base(points, 0, null) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeCurve"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <param name="rotation">The rotation.</param>
        public ShapeCurve(PointF[] points, float rotation)
			: base(points, rotation, null) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeCurve"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <param name="pen">The pen.</param>
        public ShapeCurve(PointF[] points, Pen pen)
			: base(points, 0, pen) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeCurve"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="pen">The pen.</param>
        public ShapeCurve(PointF[] points, float rotation, Pen pen)
			: base(points, rotation, pen) { }

        #endregion

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
            return "{Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.ShapeCurve}";
        }

        /// <summary>
        /// Updates the path.
        /// </summary>
        protected override void UpdatePath()
		{
            if (this.Points == null || this.Points.Length == 0) return;

			InternalPath = new GraphicsPath();
			InternalPath.AddCurve(this.Points);

			Matrix mtx = new Matrix();
			mtx.RotateAt(this.Rotation, InternalRotationBasePoint);
			InternalPath.Transform(mtx);
		}

	}
}