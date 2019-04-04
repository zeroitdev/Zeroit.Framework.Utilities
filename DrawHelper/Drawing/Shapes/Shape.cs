// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Shape.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes
{
    /// <summary>
    /// Base class for all shapes
    /// </summary>
	public abstract class Shape  
	{

        /// <summary>
        /// The pen
        /// </summary>
        private Pen _pen;
        /// <summary>
        /// The brush
        /// </summary>
        private Brush _brush;
        /// <summary>
        /// The rotation
        /// </summary>
        private float _rotation;

        #region Protected

        /// <summary>
        /// The internal path
        /// </summary>
        protected GraphicsPath InternalPath;
        /// <summary>
        /// The internal rotation base point
        /// </summary>
        protected PointF InternalRotationBasePoint;

        #endregion

        #region Abstract

        /// <summary>
        /// Gets the bounds.
        /// </summary>
        /// <value>The bounds.</value>
        public abstract RectangleF Bounds { get;}
        /// <summary>
        /// Gets or sets the center.
        /// </summary>
        /// <value>The center.</value>
        public abstract PointF Center { get;set;}
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        public abstract PointF Location { get;set;}

        /// <summary>
        /// Gets the thumb.
        /// </summary>
        /// <param name="thumbSize">Size of the thumb.</param>
        /// <returns>Image.</returns>
        public abstract Image GetThumb(ShapeThumbSize thumbSize);
        /// <summary>
        /// Paints the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="smoothingMode">The smoothing mode.</param>
        public abstract void Paint(Graphics graphics, SmoothingMode smoothingMode);
        /// <summary>
        /// Rotates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="basePoint">The base point.</param>
        public abstract void Rotate(float value, PointF basePoint);
        /// <summary>
        /// Translates the specified dx.
        /// </summary>
        /// <param name="dx">The dx.</param>
        /// <param name="dy">The dy.</param>
        public abstract void Translate(float dx, float dy);

        /// <summary>
        /// Updates the path.
        /// </summary>
        protected abstract void UpdatePath();

        #endregion

        #region Virtual

        /// <summary>
        /// Return the GraphicsPath used for this shape
        /// </summary>
        /// <value>The path.</value>
        public virtual GraphicsPath Path 
		{
			get
			{
				return InternalPath;
			}
		}

        /// <summary>
        /// The Shape size
        /// </summary>
        /// <value>The size.</value>
		public virtual SizeF Size
		{
			get
			{
				return Bounds.Size;
			}
		}

        /// <summary>
        /// Pen used for this Shape
        /// </summary>
        /// <value>The pen.</value>
		public virtual Pen Pen
		{
			get
			{
				return _pen;
			}
			set
			{
				_pen = value;
			}
		}
        /// <summary>
        /// Brush used for filling this shape
        /// </summary>
        /// <value>The brush.</value>
		public virtual Brush Brush
		{
			get
			{
				return _brush;
			}
			set
			{
				_brush = value;
			}
		}

        /// <summary>
        /// Rotation applied to this shape
        /// </summary>
        /// <value>The rotation.</value>
		public virtual float Rotation 
		{
			get
			{
				return _rotation;
			}
			set
			{
				_rotation = value;
				UpdatePath();
			}
		}

        /// <summary>
        /// Draw the shape on the Graphics
        /// </summary>
        /// <param name="graphics">The graphics.</param>
		public virtual void Paint(Graphics graphics)
		{
			this.Paint(graphics, graphics.SmoothingMode);
		}

        /// <summary>
        /// Update the Shape
        /// </summary>
		public virtual void Update()
		{
			this.UpdatePath();
		}

        /// <summary>
        /// Rotate the shape
        /// </summary>
        /// <param name="value">Rotation degree</param>
		public virtual void Rotate(float value)
		{
			this.Rotate(value, this.Center);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return "{Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.Shape}";
        }

        #endregion

    }
}