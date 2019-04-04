// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ShapePie.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes
{

    /// <summary>
    /// Class ShapePie.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.ShapeArc" />
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.IFillable" />
    public class ShapePie  :ShapeArc,IFillable
	{

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapePie"/> class.
        /// </summary>
        internal ShapePie()
		{

		}
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapePie"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="startAngle">The start angle.</param>
        /// <param name="sweepAngle">The sweep angle.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="pen">The pen.</param>
        public ShapePie(float left, float top, float width, float height, float startAngle, float sweepAngle, float rotation, Pen pen)
            : base(left, top, width, height, startAngle, sweepAngle, rotation, pen) { }

        /// <summary>
        /// Updates the path.
        /// </summary>
        protected override void UpdatePath()
        {
            InternalPath = new GraphicsPath();
            InternalPath.AddPie(this.Left, this.Top, this.Width, this.Height, this.StartAngle, this.SweepAngle);

            Matrix mtx = new Matrix();
            mtx.RotateAt(this.Rotation, InternalRotationBasePoint);
            InternalPath.Transform(mtx);
        }

        #region IFillable Members


        /// <summary>
        /// Fills the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        public void Fill(Graphics graphics)
        {
            graphics.FillPath(this.Brush, InternalPath);
        }

        #endregion
    }
}