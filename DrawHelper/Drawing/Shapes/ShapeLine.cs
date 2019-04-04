// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="ShapeLine.cs" company="Zeroit Dev Technologies">
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
    /// Class ShapeLine.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.Shape" />
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.IDrawable" />
    public class ShapeLine :Shape,IDrawable
	{
        /// <summary>
        /// The x1
        /// </summary>
        private float _x1, _y1, _x2, _y2;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeLine"/> class.
        /// </summary>
        internal ShapeLine()
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeLine"/> class.
        /// </summary>
        /// <param name="xStartPoint">The x start point.</param>
        /// <param name="yStartPoint">The y start point.</param>
        /// <param name="xEndPoint">The x end point.</param>
        /// <param name="yEndPoint">The y end point.</param>
        public ShapeLine(float xStartPoint, float yStartPoint, float xEndPoint, float yEndPoint)
			: this(xStartPoint, yStartPoint, xEndPoint, yEndPoint,0 , null) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeLine"/> class.
        /// </summary>
        /// <param name="xStartPoint">The x start point.</param>
        /// <param name="yStartPoint">The y start point.</param>
        /// <param name="xEndPoint">The x end point.</param>
        /// <param name="yEndPoint">The y end point.</param>
        /// <param name="pen">The pen.</param>
        public ShapeLine(float xStartPoint, float yStartPoint, float xEndPoint, float yEndPoint, Pen pen)
			: this(xStartPoint, yStartPoint, xEndPoint, yEndPoint, 0, pen) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeLine"/> class.
        /// </summary>
        /// <param name="xStartPoint">The x start point.</param>
        /// <param name="yStartPoint">The y start point.</param>
        /// <param name="xEndPoint">The x end point.</param>
        /// <param name="yEndPoint">The y end point.</param>
        /// <param name="rotation">The rotation.</param>
        public ShapeLine(float xStartPoint, float yStartPoint, float xEndPoint, float yEndPoint,float rotation)
			: this(xStartPoint, yStartPoint, xEndPoint, yEndPoint,0, null) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeLine"/> class.
        /// </summary>
        /// <param name="xStartPoint">The x start point.</param>
        /// <param name="yStartPoint">The y start point.</param>
        /// <param name="xEndPoint">The x end point.</param>
        /// <param name="yEndPoint">The y end point.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="pen">The pen.</param>
        public ShapeLine(float xStartPoint, float yStartPoint, float xEndPoint, float yEndPoint,float rotation, Pen pen)
		{
			_x1 = xStartPoint;
			_y1 = yStartPoint;
			_x2 = xEndPoint;
			_y2 = yEndPoint;

			this.Rotation = rotation;
			this.Pen = pen;

			this.UpdatePath();
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeLine"/> class.
        /// </summary>
        /// <param name="startPoint">The start point.</param>
        /// <param name="endPoint">The end point.</param>
        public ShapeLine(PointF startPoint, PointF endPoint)
			:this(startPoint.X,startPoint.Y,endPoint.X,endPoint.Y,0,Pens.Black) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeLine"/> class.
        /// </summary>
        /// <param name="startPoint">The start point.</param>
        /// <param name="endPoint">The end point.</param>
        /// <param name="pen">The pen.</param>
        public ShapeLine(PointF startPoint, PointF endPoint, Pen pen)
			: this(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y,0, pen) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeLine"/> class.
        /// </summary>
        /// <param name="startPoint">The start point.</param>
        /// <param name="endPoint">The end point.</param>
        /// <param name="rotation">The rotation.</param>
        public ShapeLine(PointF startPoint, PointF endPoint,float rotation)
			: this(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y,rotation, null) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeLine"/> class.
        /// </summary>
        /// <param name="startPoint">The start point.</param>
        /// <param name="endPoint">The end point.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="pen">The pen.</param>
        public ShapeLine(PointF startPoint, PointF endPoint,float rotation, Pen pen)
			: this(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y,rotation, pen) { }

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
				return GetBounds();
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
				RectangleF bounds = this.Bounds;
				float x = (bounds.Left + bounds.Right) / 2;
				float y = (bounds.Top + bounds.Bottom) / 2;
				return new PointF(x, y);
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
				return Bounds.Location;
			}
			set
			{
				PointF oldLocation = this.Location;
				float dx = value.X - oldLocation.X;
				float dy = value.Y - oldLocation.Y;
				Translate(dx, dy);
			}
		}

        /// <summary>
        /// Paints the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="smoothingMode">The smoothing mode.</param>
        public override void Paint(Graphics graphics, SmoothingMode smoothingMode)
		{
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
			_x1 += dx;
			_x2 += dx;
			_y1 += dy;
			_y2 += dy;
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
            return "{Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.ShapeLine}";
        }

        /// <summary>
        /// Updates the path.
        /// </summary>
        protected override void UpdatePath()
		{
			InternalPath = new GraphicsPath();
			InternalPath.AddLine(_x1, _y1, _x2, _y2);

			Matrix mtx = new Matrix();
			mtx.RotateAt(this.Rotation, new PointF(_x1,_y1));
			InternalPath.Transform(mtx);
		}

        #endregion

        #region Private Members

        /// <summary>
        /// Gets the bounds.
        /// </summary>
        /// <returns>RectangleF.</returns>
        private RectangleF GetBounds()
		{
			float left = Math.Min(_x1, _x2);
			float top = Math.Min(_y1, _y2);
			float width = Math.Abs(_x1 - _x2);
			float height = Math.Abs(_y1 - _y2);

			return new RectangleF(left, top, width, height);
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

			graphics.DrawPath(this.Pen, InternalPath);

			graphics.SmoothingMode = sMode;
		}

        #endregion

        #region Virtuals

        /// <summary>
        /// Gets or sets the start point.
        /// </summary>
        /// <value>The start point.</value>
        public virtual PointF StartPoint
		{
			get
			{
				return new PointF(_x1, _y1);
			}
			set
			{
				_x1 = value.X;
				_y1 = value.Y;
				UpdatePath();
			}
		}
        /// <summary>
        /// Gets or sets the end point.
        /// </summary>
        /// <value>The end point.</value>
        public virtual PointF EndPoint
		{
			get
			{
				return new PointF(_x2, _y2);
			}
			set
			{
				_x2 = value.X;
				_y2 = value.Y;
				UpdatePath();
			}
		}

		#endregion

    }
}