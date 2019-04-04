// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="ShapeRectangle.cs" company="Zeroit Dev Technologies">
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
    /// Class ShapeRectangle.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.Shape" />
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.IDrawable" />
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.IFillable" />
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.IRectangle" />
    public class ShapeRectangle : Shape,IDrawable,IFillable,IRectangle
	{
        /// <summary>
        /// The bounds
        /// </summary>
        private RectangleF _bounds;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeRectangle"/> class.
        /// </summary>
        internal ShapeRectangle()
		{
			this.Rotation = 0;
			this.Pen = Pens.Transparent;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeRectangle"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public ShapeRectangle(float left, float top, float width, float height)
			: this(new RectangleF(left, top, width, height), 0) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeRectangle"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="rotation">The rotation.</param>
        public ShapeRectangle(float left, float top, float width, float height, float rotation)
			: this(new RectangleF(left, top, width, height), rotation) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeRectangle"/> class.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        public ShapeRectangle(RectangleF bounds)
			: this(bounds, 0) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeRectangle"/> class.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        /// <param name="rotation">The rotation.</param>
        public ShapeRectangle(RectangleF bounds, float rotation)
		{
			_bounds = bounds;
			this.Rotation = rotation;
			UpdatePath();
            this.Pen = Pens.Transparent;
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeRectangle"/> class.
        /// </summary>
        /// <param name="firstCorner">The first corner.</param>
        /// <param name="secondCorner">The second corner.</param>
        public ShapeRectangle(PointF firstCorner, PointF secondCorner)
			: this(firstCorner, secondCorner, 0) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeRectangle"/> class.
        /// </summary>
        /// <param name="firstCorner">The first corner.</param>
        /// <param name="secondCorner">The second corner.</param>
        /// <param name="rotation">The rotation.</param>
        public ShapeRectangle(PointF firstCorner, PointF secondCorner, float rotation)
		{
			float left = Math.Min(firstCorner.X, secondCorner.X);
			float top = Math.Min(firstCorner.X, secondCorner.X);
			float width = Math.Abs(firstCorner.X - secondCorner.X);
			float height = Math.Abs(firstCorner.Y - secondCorner.Y);

			_bounds = new RectangleF(left, top, width, height);
			this.Rotation = rotation;
			UpdatePath();
            this.Pen = Pens.Transparent;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeRectangle"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="pen">The pen.</param>
        public ShapeRectangle(float left, float top, float width, float height, Pen pen)
			: this(new RectangleF(left, top, width, height), 0, pen) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeRectangle"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="pen">The pen.</param>
        public ShapeRectangle(float left, float top, float width, float height, float rotation, Pen pen)
			: this(new RectangleF(left, top, width, height), rotation, pen) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeRectangle"/> class.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        /// <param name="pen">The pen.</param>
        public ShapeRectangle(RectangleF bounds, Pen pen)
			: this(bounds, 0, pen) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeRectangle"/> class.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="pen">The pen.</param>
        public ShapeRectangle(RectangleF bounds, float rotation, Pen pen)
			: this(bounds, rotation)
		{
			this.Pen = pen;
            this.Brush = Brushes.Transparent;
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeRectangle"/> class.
        /// </summary>
        /// <param name="firstCorner">The first corner.</param>
        /// <param name="secondCorner">The second corner.</param>
        /// <param name="pen">The pen.</param>
        public ShapeRectangle(PointF firstCorner, PointF secondCorner, Pen pen)
			: this(firstCorner, secondCorner, 0, pen) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeRectangle"/> class.
        /// </summary>
        /// <param name="firstCorner">The first corner.</param>
        /// <param name="secondCorner">The second corner.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="pen">The pen.</param>
        public ShapeRectangle(PointF firstCorner, PointF secondCorner, float rotation, Pen pen)
			: this(firstCorner, secondCorner, rotation)
		{
			this.Pen = pen;
            this.Brush = Brushes.Transparent;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeRectangle"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="brush">The brush.</param>
        public ShapeRectangle(float left, float top, float width, float height, Brush brush)
			: this(new RectangleF(left, top, width, height), 0, brush) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeRectangle"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="brush">The brush.</param>
        public ShapeRectangle(float left, float top, float width, float height, float rotation, Brush brush)
			: this(new RectangleF(left, top, width, height), rotation, brush) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeRectangle"/> class.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        /// <param name="brush">The brush.</param>
        public ShapeRectangle(RectangleF bounds, Brush brush)
			: this(bounds, 0, brush) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeRectangle"/> class.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="brush">The brush.</param>
        public ShapeRectangle(RectangleF bounds, float rotation, Brush brush)
			: this(bounds, rotation)
		{
            this.Pen = Pens.Transparent;
			this.Brush = brush;
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeRectangle"/> class.
        /// </summary>
        /// <param name="firstCorner">The first corner.</param>
        /// <param name="secondCorner">The second corner.</param>
        /// <param name="brush">The brush.</param>
        public ShapeRectangle(PointF firstCorner, PointF secondCorner, Brush brush)
			: this(firstCorner, secondCorner, 0, brush) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeRectangle"/> class.
        /// </summary>
        /// <param name="firstCorner">The first corner.</param>
        /// <param name="secondCorner">The second corner.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="brush">The brush.</param>
        public ShapeRectangle(PointF firstCorner, PointF secondCorner, float rotation, Brush brush)
			: this(firstCorner, secondCorner, rotation)
		{
            this.Pen = Pens.Transparent;
			this.Brush = brush;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeRectangle"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        public ShapeRectangle(float left, float top, float width, float height, Pen pen, Brush brush)
			: this(new RectangleF(left, top, width, height), 0, pen, brush) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeRectangle"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        public ShapeRectangle(float left, float top, float width, float height, float rotation, Pen pen, Brush brush)
			: this(new RectangleF(left, top, width, height), 0, pen, brush) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeRectangle"/> class.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        public ShapeRectangle(RectangleF bounds, Pen pen, Brush brush)
			: this(bounds, 0, pen, brush) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeRectangle"/> class.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        public ShapeRectangle(RectangleF bounds, float rotation, Pen pen, Brush brush)
			: this(bounds, rotation)
		{
			this.Pen = pen;
			this.Brush = brush;
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeRectangle"/> class.
        /// </summary>
        /// <param name="firstCorner">The first corner.</param>
        /// <param name="secondCorner">The second corner.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        public ShapeRectangle(PointF firstCorner, PointF secondCorner, Pen pen, Brush brush)
			: this(firstCorner, secondCorner, 0, pen, brush) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeRectangle"/> class.
        /// </summary>
        /// <param name="firstCorner">The first corner.</param>
        /// <param name="secondCorner">The second corner.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        public ShapeRectangle(PointF firstCorner, PointF secondCorner, float rotation, Pen pen, Brush brush)
			: this(firstCorner, secondCorner, rotation)
		{
			this.Pen = pen;
			this.Brush = brush;
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
				return _bounds;
			}
		}
        /// <summary>
        /// Gets or sets the center.
        /// </summary>
        /// <value>The center.</value>
        public override PointF Center
		{
			get
			{
				return new PointF
					(
						(_bounds.Left + _bounds.Right) / 2,
						(_bounds.Top + _bounds.Bottom) / 2
					);
			}
			set
			{
				PointF oldCenter = this.Center;
				float dx = value.X - oldCenter.X;
				float dy = value.Y - oldCenter.Y;
				Translate(dx, dy);
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
				return _bounds.Location;
			}
			set
			{
				_bounds.Location = value;
				UpdatePath();
			}
		}

        /// <summary>
        /// Paints the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="smoothingMode">The smoothing mode.</param>
        public override void Paint(Graphics graphics, SmoothingMode smoothingMode)
		{
			this.Fill(graphics);
			this.Draw(graphics, smoothingMode);
		}
        /// <summary>
        /// Rotates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="basePoint">The base point.</param>
        public override void Rotate(float value, PointF basePoint)
		{
			this.Rotation = value;
			InternalRotationBasePoint = basePoint;
			UpdatePath();
		}
        /// <summary>
        /// Translates the specified dx.
        /// </summary>
        /// <param name="dx">The dx.</param>
        /// <param name="dy">The dy.</param>
        public override void Translate(float dx, float dy)
		{
			_bounds.X += dx;
			_bounds.Y += dy;
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
            return "{Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.ShapeRectangle}";
        }

        /// <summary>
        /// Updates the path.
        /// </summary>
        protected override void UpdatePath()
		{
			InternalPath = new GraphicsPath(FillMode.Winding);
			InternalPath.AddRectangle(_bounds);

			Matrix mtx = new Matrix();
			mtx.RotateAt(this.Rotation, InternalRotationBasePoint);
			InternalPath.Transform(mtx);
		}

        #endregion

        #region IDrawable Members

        /// <summary>
        /// Draws the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        public void Draw(Graphics graphics)
        {
            this.Draw(graphics, graphics.SmoothingMode);
        }
        /// <summary>
        /// Draws the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="smoothingMode">The smoothing mode.</param>
        public void Draw(Graphics graphics, SmoothingMode smoothingMode)
        {
            SmoothingMode sMode = graphics.SmoothingMode;
            graphics.SmoothingMode = smoothingMode;

            //if (this.Brush != null)
            //    graphics.FillPath(this.Brush, InternalPath);

            graphics.DrawPath(this.Pen, InternalPath);

            graphics.SmoothingMode = sMode;
        }

        #endregion

        #region IFillable Members

        /// <summary>
        /// Fills the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        public void Fill(Graphics graphics)
        {
            if(this.Brush != null)
                graphics.FillPath(this.Brush, InternalPath);
        }

        #endregion

        #region IRectangle Members - Virtuals

        /// <summary>
        /// Gets or sets the left.
        /// </summary>
        /// <value>The left.</value>
        public virtual float Left
        {
            get
            {
                return _bounds.Left;
            }
            set
            {
                _bounds.X = value;
                UpdatePath();
            }
        }
        /// <summary>
        /// Gets or sets the top.
        /// </summary>
        /// <value>The top.</value>
        public virtual float Top
        {
            get
            {
                return _bounds.Top;
            }
            set
            {
                _bounds.Y = value;
                UpdatePath();
            }
        }
        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public virtual float Width
        {
            get
            {
                return _bounds.Width;
            }
            set
            {
                _bounds.Width = value;
                UpdatePath();
            }
        }
        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public virtual float Height
        {
            get
            {
                return _bounds.Height;
            }
            set
            {
                _bounds.Height = value;
                UpdatePath();
            }
        }

        #endregion
    }
}