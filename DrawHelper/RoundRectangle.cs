// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="RoundRectangle.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing
{

    /// <summary>
    /// Class DrawRenderer.
    /// </summary>
    public static partial class DrawRenderer
    {
        /// <summary>
        /// The arc rectangle width
        /// </summary>
        private static int ArcRectangleWidth;
        /// <summary>
        /// The upper left corner
        /// </summary>
        private static int UpperLeftCorner;
        /// <summary>
        /// The upper right corner
        /// </summary>
        private static int UpperRightCorner;
        /// <summary>
        /// Down left corner
        /// </summary>
        private static int DownLeftCorner;
        /// <summary>
        /// Down right corner
        /// </summary>
        private static int DownRightCorner;

        /// <summary>
        /// The curve
        /// </summary>
        private static int curve/* = 3*/;


        /// <summary>
        /// Rounded Rectangle
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="Rectangle">Set Rectangle</param>
        /// <param name="Curve">Set Curve</param>
        /// <param name="UpperLeftCurve">Set Upper Left Curve</param>
        /// <param name="UpperRightCurve">Set Upper Right Curve</param>
        /// <param name="DownLeftCurve">Set Down Left Curve</param>
        /// <param name="DownRightCurve">Set Down Right Curve</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath RoundRect(this GraphicsPath extension, Rectangle Rectangle, int Curve, int UpperLeftCurve, int UpperRightCurve, int DownLeftCurve, int DownRightCurve)
        {
            //Curve = curve;
            GraphicsPath P = new GraphicsPath();
            ArcRectangleWidth = Curve * 2;

            UpperLeftCorner = UpperLeftCurve * 2;
            UpperRightCorner = UpperRightCurve * 2;
            DownLeftCorner = DownLeftCurve * 2;
            DownRightCorner = DownRightCurve * 2;

            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, UpperLeftCorner, UpperLeftCorner), -180, 90);
            P.AddArc(new Rectangle(Rectangle.Width - UpperRightCorner + Rectangle.X, Rectangle.Y, UpperRightCorner, UpperRightCorner), -90, 90);
            P.AddArc(new Rectangle(Rectangle.Width - DownRightCorner + Rectangle.X, Rectangle.Height - DownRightCorner + Rectangle.Y, DownRightCorner, DownRightCorner), 0, 90);
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - DownLeftCorner + Rectangle.Y, DownLeftCorner, DownLeftCorner), 90, 90);
            //P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));

            //P.AddLine(new Point(Rectangle.X, Rectangle.Height - UpperLeftCorner + Rectangle.Y), new Point(Rectangle.X, UpperLeftCorner + Rectangle.Y));

            P.CloseAllFigures();
            return P;
        }

        /// <summary>
        /// Rounded Rectangle
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="Rectangle">Set Rectangle</param>
        /// <param name="Curve">Set Curve</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath RoundRect(this GraphicsPath extension, Rectangle Rectangle, int Curve)
        {
            //Curve = curve;
            GraphicsPath P = new GraphicsPath();
            ArcRectangleWidth = Curve * 2;
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
            P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
            return P;
        }

        /// <summary>
        /// Rounded Rectangle
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="X">Set X</param>
        /// <param name="Y">Set X</param>
        /// <param name="Width">Set Width</param>
        /// <param name="Height">Set Height</param>
        /// <param name="Curve">Set Curve</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath RoundRect(this GraphicsPath extension, int X, int Y, int Width, int Height, int Curve)
        {
            //Curve = curve;
            Rectangle Rectangle = new Rectangle(X, Y, Width, Height);
            GraphicsPath P = new GraphicsPath();
            ArcRectangleWidth = Curve * 2;
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
            P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
            return P;
        }

        /// <summary>
        /// Rounded Rectangle
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="r">Set Rectangle</param>
        /// <param name="r1">Upper Left</param>
        /// <param name="r2">Upper Right</param>
        /// <param name="r3">Down Left</param>
        /// <param name="r4">Down Right</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath RoundRect(this GraphicsPath extension, RectangleF r, float r1, float r2, float r3, float r4)
        {
            float x = r.X;
            float y = r.Y;
            float w = r.Width;
            float h = r.Height;
            GraphicsPath rr5 = new GraphicsPath();
            rr5.AddBezier(x, y + r1, x, y, x + r1, y, x + r1, y);
            rr5.AddLine(x + r1, y, x + w - r2, y);
            rr5.AddBezier(x + w - r2, y, x + w, y, x + w, y + r2, x + w, y + r2);
            rr5.AddLine(x + w, y + r2, x + w, y + h - r3);
            rr5.AddBezier(x + w, y + h - r3, x + w, y + h, x + w - r3, y + h, x + w - r3, y + h);
            rr5.AddLine(x + w - r3, y + h, x + r4, y + h);
            rr5.AddBezier(x + r4, y + h, x, y + h, x, y + h - r4, x, y + h - r4);
            rr5.AddLine(x, y + h - r4, x, y + r1);
            return rr5;
        }


        /// <summary>
        /// Rounded Rectangle
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="X_cord">Set X coordinate</param>
        /// <param name="Y_cord">Set Y coordinate</param>
        /// <param name="Width">Set Width</param>
        /// <param name="Height">Set Height</param>
        /// <param name="r1">Upper Left</param>
        /// <param name="r2">Upper Right</param>
        /// <param name="r3">Down Left</param>
        /// <param name="r4">Down Right</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath RoundRect(this GraphicsPath extension, float X_cord, float Y_cord, float Width, float Height, float r1, float r2, float r3, float r4)
        {
            float x = X_cord;
            float y = X_cord;
            float w = Width;
            float h = Height;
            GraphicsPath rr5 = new GraphicsPath();
            rr5.AddBezier(x, y + r1, x, y, x + r1, y, x + r1, y);
            rr5.AddLine(x + r1, y, x + w - r2, y);
            rr5.AddBezier(x + w - r2, y, x + w, y, x + w, y + r2, x + w, y + r2);
            rr5.AddLine(x + w, y + r2, x + w, y + h - r3);
            rr5.AddBezier(x + w, y + h - r3, x + w, y + h, x + w - r3, y + h, x + w - r3, y + h);
            rr5.AddLine(x + w - r3, y + h, x + r4, y + h);
            rr5.AddBezier(x + r4, y + h, x, y + h, x, y + h - r4, x, y + h - r4);
            rr5.AddLine(x, y + h - r4, x, y + r1);
            return rr5;
        }


        /// <summary>
        /// Create Rounded Rectangle
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="x">Set X</param>
        /// <param name="y">Set Y</param>
        /// <param name="width">Set Width</param>
        /// <param name="height">Set Height</param>
        /// <param name="radius">Set Radius</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath CreateRoundRect(this GraphicsPath extension, float x, float y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(x + radius, y, x + width - (radius * 2), y);
            gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90);

            gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2));
            gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90);

            gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height);
            gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90);

            gp.AddLine(x, y + height - (radius * 2), x, y + radius);
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90);

            gp.CloseFigure();
            return gp;
        }

        /// <summary>
        /// Creates the round rect.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="radius">The radius.</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath CreateRoundRect(this GraphicsPath extension, Rectangle rect, float radius)
        {
            return CreateRoundRect(extension, rect.X, rect.Y, rect.Width, rect.Height, radius);
        }

        /// <summary>
        /// Create Upper Rounded Rectangle
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="x">Set X</param>
        /// <param name="y">Set X</param>
        /// <param name="width">Set Width</param>
        /// <param name="height">Set Height</param>
        /// <param name="radius">Set Radius</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath CreateUpRoundRect(this GraphicsPath extension, float x, float y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();

            gp.AddLine(x + radius, y, x + width - (radius * 2), y);
            gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90);

            gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2) + 1);
            gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, 2, 0, 90);

            gp.AddLine(x + width, y + height, x + radius, y + height);
            gp.AddArc(x, y + height - (radius * 2) + 1, radius * 2, 1, 90, 90);

            gp.AddLine(x, y + height, x, y + radius);
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90);

            gp.CloseFigure();
            return gp;
        }

        /// <summary>
        /// Create Left Rounded Rectangle
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="x">Set X</param>
        /// <param name="y">Set Y</param>
        /// <param name="width">Set Width</param>
        /// <param name="height">Set Height</param>
        /// <param name="radius">Set Radius</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath CreateLeftRoundRect(this GraphicsPath extension, float x, float y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(x + radius, y, x + width - (radius * 2), y);
            gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90);

            gp.AddLine(x + width, y + 0, x + width, y + height);
            gp.AddArc(x + width - (radius * 2), y + height - (1), radius * 2, 1, 0, 90);

            gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height);
            gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90);

            gp.AddLine(x, y + height - (radius * 2), x, y + radius);
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90);

            gp.CloseFigure();
            return gp;
        }

        /// <summary>
        /// Creates the top corner round rect.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="radius">The radius.</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath CreateTopCornerRoundRect(this GraphicsPath extension, float x, float y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(x + radius, y, x + width - (radius * 2), y);
            gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90);
            gp.AddLine(x + width, y + radius, x + width, y + height);
            gp.AddLine(x + width, y + height, x, y + height);
            gp.AddLine(x, y + height, x, y + radius);
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90);
            gp.CloseFigure();
            return gp;
        }

        /// <summary>
        /// Creates the top corner round rect.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="radius">The radius.</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath CreateTopCornerRoundRect(this GraphicsPath extension, Rectangle rect, float radius)
        {
            return CreateTopCornerRoundRect(extension, rect.X, rect.Y, rect.Width, rect.Height, radius);
        }

        /// <summary>
        /// Creates the top corner round rect without bottom.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="radius">The radius.</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath CreateTopCornerRoundRectWithoutBottom(this GraphicsPath extension, float x, float y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(x + radius, y, x + width - (radius * 2), y);
            gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90);
            gp.AddLine(x + width, y + radius, x + width, y + height);
            gp.AddLine(x, y + height, x, y + radius);
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90);
            gp.CloseFigure();
            return gp;
        }

        /// <summary>
        /// Creates the top corner round rect without bottom.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="radius">The radius.</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath CreateTopCornerRoundRectWithoutBottom(this GraphicsPath extension, Rectangle rect, float radius)
        {
            return CreateTopCornerRoundRect(extension, rect.X, rect.Y, rect.Width, rect.Height, radius);
        }

        /// <summary>
        /// Fill Rounded Rectangle
        /// </summary>
        /// <param name="G">Set Graphics</param>
        /// <param name="R">Set Rectangle</param>
        /// <param name="Curve">Set Curve</param>
        /// <param name="C">Set Color</param>
        public static void FillRoundRect(this System.Drawing.Graphics G, Rectangle R, int Curve, Color C)
        {
            using (SolidBrush B = new SolidBrush(C))
            {
                G.FillPie(B, R.X, R.Y, Curve, Curve, 180, 90);
                G.FillPie(B, R.X + R.Width - Curve, R.Y, Curve, Curve, 270, 90);
                G.FillPie(B, R.X, R.Y + R.Height - Curve, Curve, Curve, 90, 90);
                G.FillPie(B, R.X + R.Width - Curve, R.Y + R.Height - Curve, Curve, Curve, 0, 90);
                G.FillRectangle(B, Convert.ToInt32(R.X + Curve / 2), R.Y, R.Width - Curve, Convert.ToInt32(Curve / 2));
                G.FillRectangle(B, R.X, Convert.ToInt32(R.Y + Curve / 2), R.Width, R.Height - Curve);
                G.FillRectangle(B, Convert.ToInt32(R.X + Curve / 2), Convert.ToInt32(R.Y + R.Height - Curve / 2), R.Width - Curve, Convert.ToInt32(Curve / 2));
            }

        }

        /// <summary>
        /// Draw Rounded Rectangle
        /// </summary>
        /// <param name="G">Set Graphics</param>
        /// <param name="R">Set Rectangle</param>
        /// <param name="Curve">Set Curve</param>
        /// <param name="C">Set Color</param>
        public static void DrawRoundRect(this System.Drawing.Graphics G, Rectangle R, int Curve, Color C)
        {
            using (Pen P = new Pen(C))
            {
                G.DrawArc(P, R.X, R.Y, Curve, Curve, 180, 90);
                G.DrawLine(P, Convert.ToInt32(R.X + Curve / 2), R.Y, Convert.ToInt32(R.X + R.Width - Curve / 2), R.Y);
                G.DrawArc(P, R.X + R.Width - Curve, R.Y, Curve, Curve, 270, 90);
                G.DrawLine(P, R.X, Convert.ToInt32(R.Y + Curve / 2), R.X, Convert.ToInt32(R.Y + R.Height - Curve / 2));
                G.DrawLine(P, Convert.ToInt32(R.X + R.Width), Convert.ToInt32(R.Y + Curve / 2), Convert.ToInt32(R.X + R.Width), Convert.ToInt32(R.Y + R.Height - Curve / 2));
                G.DrawLine(P, Convert.ToInt32(R.X + Curve / 2), Convert.ToInt32(R.Y + R.Height), Convert.ToInt32(R.X + R.Width - Curve / 2), Convert.ToInt32(R.Y + R.Height));
                G.DrawArc(P, R.X, R.Y + R.Height - Curve, Curve, Curve, 90, 90);
                G.DrawArc(P, R.X + R.Width - Curve, R.Y + R.Height - Curve, Curve, Curve, 0, 90);
            }

        }

        /// <summary>
        /// Full Rectangle
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="S">Set Size</param>
        /// <param name="Subtract">Subract</param>
        /// <returns>Rectangle.</returns>
        public static Rectangle FullRectangle(this Rectangle extension, Size S, bool Subtract)
        {
            if (Subtract)
            {
                return new Rectangle(0, 0, S.Width - 1, S.Height - 1);
            }
            else
            {
                return new Rectangle(0, 0, S.Width, S.Height);
            }
        }

        /// <summary>
        /// Full Rectangle
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="S">Set Size</param>
        /// <param name="Subtract">Subtract</param>
        /// <param name="valueToSubtract">Set Value to Subtract</param>
        /// <returns>Rectangle.</returns>
        public static Rectangle FullRectangle(this Rectangle extension, Size S, bool Subtract, int valueToSubtract = 1)
        {
            if (Subtract)
            {
                return new Rectangle(0, 0, S.Width - valueToSubtract, S.Height - valueToSubtract);
            }
            else
            {
                return new Rectangle(0, 0, S.Width, S.Height);
            }
        }

        /// <summary>
        /// Smallers the rectangle.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="value">The value.</param>
        /// <returns>Rectangle.</returns>
        public static Rectangle SmallerRectangle(this Rectangle extension, Rectangle rect, int value)
        {
            return new Rectangle(rect.X + value, rect.Y + value, rect.Width - (value * 2), rect.Height - (value * 2));
        }

        /// <summary>
        /// Centers the specified rect.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="parentRect">The parent rect.</param>
        /// <returns>Rectangle.</returns>
        public static Rectangle Center(this Rectangle extension, Rectangle rect, Rectangle parentRect)
        {
            Point center = parentRect.Center();

            var w = rect.Width;
            var h = rect.Height;

            return Rectangle.FromLTRB(center.X - (w / 2), center.Y - (h / 2), center.X + (w / 2), center.Y + (h / 2));
        }

        /// <summary>
        /// Centers the specified rect.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <returns>Point.</returns>
        public static Point Center(this Rectangle rect)
        {
            var center = new Point
            {
                X = rect.X + rect.Size.Width / 2,
                Y = rect.Y + rect.Size.Height / 2
            };
            return center;
        }

        /// <summary>
        /// Roundeds the rect.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="radius">The radius.</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath RoundedRect(this GraphicsPath extension, int width, int height, int radius)
        {
            RectangleF baseRect = new RectangleF(0, 0, width, height);
            return RoundedRect(extension, baseRect, radius);
        }

        /// <summary>
        /// 获取一个圆角矩形
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="baseRect">The base rect.</param>
        /// <param name="radius">角度</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath RoundedRect(this GraphicsPath extension, RectangleF baseRect, int radius)
        {
            //RectangleF baseRect = new RectangleF(0, 0, width, height);
            float diameter = radius * 2.0f;
            SizeF sizeF = new SizeF(diameter, diameter);
            RectangleF arc = new RectangleF(baseRect.Location, sizeF);
            GraphicsPath path = new GraphicsPath();

            // top left arc 
            path.AddArc(arc, 180, 90);

            // top right arc 
            arc.X = baseRect.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc 
            arc.Y = baseRect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc
            arc.X = baseRect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        /// <summary>
        /// Enum RectangleEdgeFilter
        /// </summary>
        public enum RectangleEdgeFilter
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,
            /// <summary>
            /// The top left
            /// </summary>
            TopLeft = 1,
            /// <summary>
            /// The top right
            /// </summary>
            TopRight = 2,
            /// <summary>
            /// The bottom left
            /// </summary>
            BottomLeft = 4,
            /// <summary>
            /// The bottom right
            /// </summary>
            BottomRight = 8,
            /// <summary>
            /// All
            /// </summary>
            All = TopLeft | TopRight | BottomLeft | BottomRight
        }

        /// <summary>
        /// Generates the rounded rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath GenerateRoundedRectangle(
                this System.Drawing.Graphics graphics,
                RectangleF rectangle,
                float radius,
                RectangleEdgeFilter filter)
        {
            float diameter;
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0.0F || filter == RectangleEdgeFilter.None)
            {
                path.AddRectangle(rectangle);
                path.CloseFigure();
                return path;
            }
            else
            {
                if (radius >= (Math.Min(rectangle.Width, rectangle.Height)) / 2.0)
                    return graphics.GenerateCapsule(rectangle);
                diameter = radius * 2.0F;
                SizeF sizeF = new SizeF(diameter, diameter);
                RectangleF arc = new RectangleF(rectangle.Location, sizeF);
                if ((RectangleEdgeFilter.TopLeft & filter) == RectangleEdgeFilter.TopLeft)
                    path.AddArc(arc, 180, 90);
                else
                {
                    path.AddLine(arc.X, arc.Y + arc.Height, arc.X, arc.Y);
                    path.AddLine(arc.X, arc.Y, arc.X + arc.Width, arc.Y);
                }
                arc.X = rectangle.Right - diameter;
                if ((RectangleEdgeFilter.TopRight & filter) == RectangleEdgeFilter.TopRight)
                    path.AddArc(arc, 270, 90);
                else
                {
                    path.AddLine(arc.X, arc.Y, arc.X + arc.Width, arc.Y);
                    path.AddLine(arc.X + arc.Width, arc.Y + arc.Height, arc.X + arc.Width, arc.Y);
                }
                arc.Y = rectangle.Bottom - diameter;
                if ((RectangleEdgeFilter.BottomRight & filter) == RectangleEdgeFilter.BottomRight)
                    path.AddArc(arc, 0, 90);
                else
                {
                    path.AddLine(arc.X + arc.Width, arc.Y, arc.X + arc.Width, arc.Y + arc.Height);
                    path.AddLine(arc.X, arc.Y + arc.Height, arc.X + arc.Width, arc.Y + arc.Height);
                }
                arc.X = rectangle.Left;
                if ((RectangleEdgeFilter.BottomLeft & filter) == RectangleEdgeFilter.BottomLeft)
                    path.AddArc(arc, 90, 90);
                else
                {
                    path.AddLine(arc.X + arc.Width, arc.Y + arc.Height, arc.X, arc.Y + arc.Height);
                    path.AddLine(arc.X, arc.Y + arc.Height, arc.X, arc.Y);
                }
                path.CloseFigure();
            }
            return path;
        }

        /// <summary>
        /// Generates the capsule.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath GenerateCapsule(
                this System.Drawing.Graphics graphics,
                RectangleF rectangle)
        {
            float diameter;
            RectangleF arc;
            GraphicsPath path = new GraphicsPath();
            try
            {
                if (rectangle.Width > rectangle.Height)
                {
                    diameter = rectangle.Height;
                    SizeF sizeF = new SizeF(diameter, diameter);
                    arc = new RectangleF(rectangle.Location, sizeF);
                    path.AddArc(arc, 90, 180);
                    arc.X = rectangle.Right - diameter;
                    path.AddArc(arc, 270, 180);
                }
                else if (rectangle.Width < rectangle.Height)
                {
                    diameter = rectangle.Width;
                    SizeF sizeF = new SizeF(diameter, diameter);
                    arc = new RectangleF(rectangle.Location, sizeF);
                    path.AddArc(arc, 180, 180);
                    arc.Y = rectangle.Bottom - diameter;
                    path.AddArc(arc, 0, 180);
                }
                else path.AddEllipse(rectangle);
            }
            catch { path.AddEllipse(rectangle); }
            finally { path.CloseFigure(); }
            return path;
        }

        /// <summary>
        /// Draws the rounded rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="filter">The filter.</param>
        public static void DrawRoundedRectangle(
                this System.Drawing.Graphics graphics,
                Pen pen,
                float x,
                float y,
                float width,
                float height,
                float radius,
                RectangleEdgeFilter filter)
        {
            RectangleF rectangle = new RectangleF(x, y, width, height);
            GraphicsPath path = graphics.GenerateRoundedRectangle(rectangle, radius, filter);
            SmoothingMode old = graphics.SmoothingMode;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.DrawPath(pen, path);
            graphics.SmoothingMode = old;
        }

        /// <summary>
        /// Draws the rounded rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="radius">The radius.</param>
        public static void DrawRoundedRectangle(
                this System.Drawing.Graphics graphics,
                Pen pen,
                float x,
                float y,
                float width,
                float height,
                float radius)
        {
            graphics.DrawRoundedRectangle(
                    pen,
                    x,
                    y,
                    width,
                    height,
                    radius,
                    RectangleEdgeFilter.All);
        }

        /// <summary>
        /// Draws the rounded rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="radius">The radius.</param>
        public static void DrawRoundedRectangle(
                this System.Drawing.Graphics graphics,
                Pen pen,
                int x,
                int y,
                int width,
                int height,
                int radius)
        {
            graphics.DrawRoundedRectangle(
                    pen,
                    Convert.ToSingle(x),
                    Convert.ToSingle(y),
                    Convert.ToSingle(width),
                    Convert.ToSingle(height),
                    Convert.ToSingle(radius));
        }

        /// <summary>
        /// Draws the rounded rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="filter">The filter.</param>
        public static void DrawRoundedRectangle(
            this System.Drawing.Graphics graphics,
            Pen pen,
            Rectangle rectangle,
            int radius,
            RectangleEdgeFilter filter)
        {
            graphics.DrawRoundedRectangle(
                pen,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                filter);
        }

        /// <summary>
        /// Draws the rounded rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="radius">The radius.</param>
        public static void DrawRoundedRectangle(
            this System.Drawing.Graphics graphics,
            Pen pen,
            Rectangle rectangle,
            int radius)
        {
            graphics.DrawRoundedRectangle(
                pen,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                RectangleEdgeFilter.All);
        }

        /// <summary>
        /// Draws the rounded rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="filter">The filter.</param>
        public static void DrawRoundedRectangle(
            this System.Drawing.Graphics graphics,
            Pen pen,
            RectangleF rectangle,
            int radius,
            RectangleEdgeFilter filter)
        {
            graphics.DrawRoundedRectangle(
                pen,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                filter);
        }

        /// <summary>
        /// Draws the rounded rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="radius">The radius.</param>
        public static void DrawRoundedRectangle(
            this System.Drawing.Graphics graphics,
            Pen pen,
            RectangleF rectangle,
            int radius)
        {
            graphics.DrawRoundedRectangle(
                pen,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                RectangleEdgeFilter.All);
        }

        /// <summary>
        /// Fills the rounded rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="filter">The filter.</param>
        public static void FillRoundedRectangle(
                this System.Drawing.Graphics graphics,
                Brush brush,
                float x,
                float y,
                float width,
                float height,
                float radius,
                RectangleEdgeFilter filter)
        {
            RectangleF rectangle = new RectangleF(x, y, width, height);
            GraphicsPath path = graphics.GenerateRoundedRectangle(rectangle, radius, filter);
            SmoothingMode old = graphics.SmoothingMode;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.FillPath(brush, path);
            graphics.SmoothingMode = old;
        }

        /// <summary>
        /// Fills the rounded rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="radius">The radius.</param>
        public static void FillRoundedRectangle(
                this System.Drawing.Graphics graphics,
                Brush brush,
                float x,
                float y,
                float width,
                float height,
                float radius)
        {
            graphics.FillRoundedRectangle(
                    brush,
                    x,
                    y,
                    width,
                    height,
                    radius,
                    RectangleEdgeFilter.All);
        }

        /// <summary>
        /// Fills the rounded rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="radius">The radius.</param>
        public static void FillRoundedRectangle(
                this System.Drawing.Graphics graphics,
                Brush brush,
                int x,
                int y,
                int width,
                int height,
                int radius)
        {
            graphics.FillRoundedRectangle(
                    brush,
                    Convert.ToSingle(x),
                    Convert.ToSingle(y),
                    Convert.ToSingle(width),
                    Convert.ToSingle(height),
                    Convert.ToSingle(radius));
        }

        /// <summary>
        /// Fills the rounded rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="filter">The filter.</param>
        public static void FillRoundedRectangle(
            this System.Drawing.Graphics graphics,
            Brush brush,
            Rectangle rectangle,
            int radius,
            RectangleEdgeFilter filter)
        {
            graphics.FillRoundedRectangle(
                brush,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                filter);
        }

        /// <summary>
        /// Fills the rounded rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="radius">The radius.</param>
        public static void FillRoundedRectangle(
            this System.Drawing.Graphics graphics,
            Brush brush,
            Rectangle rectangle,
            int radius)
        {
            graphics.FillRoundedRectangle(
                brush,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                RectangleEdgeFilter.All);
        }

        /// <summary>
        /// Fills the rounded rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="filter">The filter.</param>
        public static void FillRoundedRectangle(
            this System.Drawing.Graphics graphics,
            Brush brush,
            RectangleF rectangle,
            int radius,
            RectangleEdgeFilter filter)
        {
            graphics.FillRoundedRectangle(
                brush,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                filter);
        }

        /// <summary>
        /// Fills the rounded rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="radius">The radius.</param>
        public static void FillRoundedRectangle(
            this System.Drawing.Graphics graphics,
            Brush brush,
            RectangleF rectangle,
            int radius)
        {
            graphics.FillRoundedRectangle(
                brush,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                RectangleEdgeFilter.All);
        }

        /// <summary>
        /// Draws a rectangle with round corners.
        /// </summary>
        /// <param name="g">The current Graphics object.</param>
        /// <param name="pen">The Pen object which draws the border with a certain color and width.</param>
        /// <param name="rectangle">The rectangle which defines the area to be drawn.</param>
        /// <param name="radius">The radius of the different corners starting with the upper left corner.</param>
        public static void DrawRoundRectangle(this System.Drawing.Graphics g, Pen pen, RectangleF rectangle, params float[] radius)
        {
            g.DrawRoundRectangle(pen, rectangle.Location, rectangle.Size, radius);
        }

        //Code taken and adapted from StackOverflow (https://stackoverflow.com/a/13653167).
        //All credits go to Marino Šimić (https://stackoverflow.com/users/610204/marino-%c5%a0imi%c4%87).
        /// <summary>
        /// Draws the rounded rectangle.
        /// </summary>
        /// <param name="gfx">The GFX.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="cornerRadius">The corner radius.</param>
        /// <param name="drawPen">The draw pen.</param>
        /// <param name="fillColor">Color of the fill.</param>
        public static void DrawRoundedRectangle(this System.Drawing.Graphics gfx, Rectangle bounds, int cornerRadius, Pen drawPen, Color fillColor)
        {
            int strokeOffset = Convert.ToInt32(System.Math.Ceiling(drawPen.Width));
            bounds = Rectangle.Inflate(bounds, -strokeOffset, -strokeOffset);

            var gfxPath = new GraphicsPath();
            if (cornerRadius > 0)
            {
                gfxPath.AddArc(bounds.X, bounds.Y, cornerRadius, cornerRadius, 180, 90);
                gfxPath.AddArc(bounds.X + bounds.Width - cornerRadius, bounds.Y, cornerRadius, cornerRadius, 270, 90);
                gfxPath.AddArc(bounds.X + bounds.Width - cornerRadius, bounds.Y + bounds.Height - cornerRadius, cornerRadius,
                    cornerRadius, 0, 90);
                gfxPath.AddArc(bounds.X, bounds.Y + bounds.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            }
            else
            {
                gfxPath.AddRectangle(bounds);
            }
            gfxPath.CloseAllFigures();
            using (SolidBrush brush = new SolidBrush(fillColor))
            {
                gfx.FillPath(brush, gfxPath);
                if (drawPen != Pens.Transparent)
                {
                    var pen = new Pen(drawPen.Color);
                    pen.EndCap = pen.StartCap = LineCap.Round;
                    gfx.DrawPath(pen, gfxPath);
                    pen.Dispose();
                }
            }
            gfxPath.Dispose();
        }


        /// <summary>
        /// Draws a rectangle with round corners.
        /// </summary>
        /// <param name="g">The current Graphics object.</param>
        /// <param name="pen">The Pen object which draws the border with a certain color and width.</param>
        /// <param name="rectangle">The rectangle which defines the area to be drawn.</param>
        /// <param name="radius">The radius of the different corners starting with the upper left corner.</param>
        public static void DrawRoundRectangle(this System.Drawing.Graphics g, Pen pen, Rectangle rectangle, params float[] radius)
        {
            g.DrawRoundRectangle(pen, (RectangleF)rectangle, radius);
        }

        /// <summary>
        /// Draws a rectangle with round corners.
        /// </summary>
        /// <param name="g">The current Graphics object.</param>
        /// <param name="pen">The Pen object which draws the border with a certain color and width.</param>
        /// <param name="point">The coordinates of the upper left corner.</param>
        /// <param name="size">The dimension of the rectangle.</param>
        /// <param name="radius">The radius of the different corners starting with the upper left corner.</param>
        public static void DrawRoundRectangle(this System.Drawing.Graphics g, Pen pen, PointF point, SizeF size, params float[] radius)
        {
            var gp = new GraphicsPath().AddRoundRectangle(point, size, radius);
            g.DrawPath(pen, gp);
        }

        /// <summary>
        /// Adds a rectangle with round corners to the current GraphicsPath.
        /// </summary>
        /// <param name="gp">The current GraphicsPath object.</param>
        /// <param name="rectangle">The rectangle which defines the area to be added.</param>
        /// <param name="radius">The radius of the different corners starting with the upper left corner.</param>
        /// <returns>The current GraphicsPath object.</returns>
        public static GraphicsPath AddRoundRectangle(this GraphicsPath gp, Rectangle rectangle, params float[] radius)
        {
            return gp.AddRoundRectangle((RectangleF)rectangle, radius);
        }

        /// <summary>
        /// Adds a rectangle with round corners to the current GraphicsPath.
        /// </summary>
        /// <param name="gp">The current GraphicsPath object.</param>
        /// <param name="rectangle">The rectangle which defines the area to be added.</param>
        /// <param name="radius">The radius of the different corners starting with the upper left corner.</param>
        /// <returns>The current GraphicsPath object.</returns>
        public static GraphicsPath AddRoundRectangle(this GraphicsPath gp, RectangleF rectangle, params float[] radius)
        {
            return gp.AddRoundRectangle(rectangle.Location, rectangle.Size, radius);
        }

        /// <summary>
        /// Adds a rectangle with round corners to the current GraphicsPath.
        /// </summary>
        /// <param name="gp">The current GraphicsPath object.</param>
        /// <param name="point">The coordinates of the upper left corner.</param>
        /// <param name="size">The dimension of the rectangle.</param>
        /// <param name="radius">The radius of the different corners starting with the upper left corner.</param>
        /// <returns>The current GraphicsPath object.</returns>
        public static GraphicsPath AddRoundRectangle(this GraphicsPath gp, PointF point, SizeF size, params float[] radius)
        {
            var r = new float[4];
            var d = new float[4];
            var bottom = point.Y + size.Height;
            var right = point.X + size.Width;

            for (int i = 0; i < r.Length; i++)
            {
                r[i] = radius.Length > 0 ? radius[i % radius.Length] : 0f;
                d[i] = 2f * r[i];
            }

            if (r[0] > 0f)
                gp.AddArc(new RectangleF(point.X, point.Y, d[0], d[0]), 180, 90);

            gp.AddLine(new PointF(point.X + r[0], point.Y), new PointF(right - r[1], point.Y));

            if (r[1] > 0f)
                gp.AddArc(new RectangleF(right - d[1], point.Y, d[1], d[1]), 270, 90);

            gp.AddLine(new PointF(right, point.Y + r[1]), new PointF(right, bottom - r[2]));

            if (r[2] > 0f)
                gp.AddArc(new RectangleF(right - d[2], bottom - d[2], d[2], d[2]), 0, 90);

            gp.AddLine(new PointF(right - r[2], bottom), new PointF(point.X + r[3], bottom));

            if (r[3] > 0f)
                gp.AddArc(new RectangleF(point.X, bottom - d[3], d[3], d[3]), 90, 90);

            gp.AddLine(new PointF(point.X, bottom - r[3]), new PointF(point.X, point.Y + r[0]));
            gp.CloseFigure();
            return gp;
        }

        /// <summary>
        /// Fills a rectangle with round corners.
        /// </summary>
        /// <param name="g">The current Graphics object.</param>
        /// <param name="brush">The Brush object which fills the rectangle with colors.</param>
        /// <param name="rectangle">The rectangle which defines the area to be filled.</param>
        /// <param name="radius">The radius of the different corners starting with the upper left corner.</param>
        public static void FillRoundRectangle(this System.Drawing.Graphics g, Brush brush, Rectangle rectangle, params float[] radius)
        {
            g.FillRoundRectangle(brush, (RectangleF)rectangle, radius);
        }

        /// <summary>
        /// Fills a rectangle with round corners.
        /// </summary>
        /// <param name="g">The current Graphics object.</param>
        /// <param name="brush">The Brush object which fills the rectangle with colors.</param>
        /// <param name="rectangle">The rectangle which defines the area to be filled.</param>
        /// <param name="radius">The radius of the different corners starting with the upper left corner.</param>
        public static void FillRoundRectangle(this System.Drawing.Graphics g, Brush brush, RectangleF rectangle, params float[] radius)
        {
            g.FillRoundRectangle(brush, rectangle.Location, rectangle.Size, radius);
        }

        /// <summary>
        /// Fills a rectangle with round corners.
        /// </summary>
        /// <param name="g">The current Graphics object.</param>
        /// <param name="brush">The Brush object which fills the rectangle with colors.</param>
        /// <param name="point">The coordinates of the upper left corner.</param>
        /// <param name="size">The dimension of the rectangle.</param>
        /// <param name="radius">The radius of the different corners starting with the upper left corner.</param>
        public static void FillRoundRectangle(this System.Drawing.Graphics g, Brush brush, PointF point, SizeF size, params float[] radius)
        {
            var gp = new GraphicsPath().AddRoundRectangle(point, size, radius);
            g.FillPath(brush, gp);
        }

        /// <summary>
        /// Create rectangle to shrink
        /// </summary>
        /// <param name="input">Set rectangle</param>
        /// <param name="size">Set shrink size</param>
        /// <returns>Rectangle.</returns>
        public static Rectangle RectangleShrink(this Rectangle input, int size)
        {
            int width = input.Width - size * 2;
            int height = input.Height - size * 2;
            if (width < 1)
                width = 1;
            if (height < 1)
                height = 1;
            return new Rectangle(input.Left + size, input.Top + size, width, height);

        }

        /// <summary>
        /// Creates the circle.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="radius">The radius.</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath CreateCircle(this GraphicsPath extension, float x, float y, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(x, y, radius * 2, radius * 2);
            return gp;
        }

    }
}
