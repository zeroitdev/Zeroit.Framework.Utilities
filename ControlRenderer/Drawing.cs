// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Drawing.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;


namespace Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer
{
    /// <summary>
    /// A class manipulation for Drawing
    /// </summary>
    public static partial class Drawing
    {
        public static CultureInfo en_us_ci = new CultureInfo("en-US");
        
        #region Enumerations
        /// <summary>
        /// Color theme used for rendering objects.
        /// </summary>
        public enum ColorTheme
        {
            Blue = 0,
            BlackBlue = 1,
            Custom = 2
        }
        /// <summary>
        /// Enumeration used to determine contents of a given tooltip parameter.
        /// </summary>
        /// <remarks></remarks>
        public enum ToolTipContent
        {
            TitleOnly,
            TitleAndText,
            TitleAndImage,
            All,
            ImageOnly,
            ImageAndText,
            TextOnly,
            Empty
        }
        /// <summary>
        /// Enumeration used to determine starting point of glowing light.
        /// </summary>
        /// <remarks><seelaso cref="getGlowingPath"/></remarks>
        public enum LightingGlowPoint
        {
            TopLeft,
            TopCenter,
            TopRight,
            MiddleLeft,
            MiddleCenter,
            MiddleRight,
            BottomLeft,
            BottomCenter,
            BottomRight,
            Custom
        }
        /// <summary>
        /// Enumeration used to determine the shadow location.
        /// </summary>
        /// <remarks><seealso cref="getInnerShadowPath"/></remarks>
        public enum ShadowPoint
        {
            Top,
            TopLeft,
            TopRight,
            Left,
            Right,
            Bottom,
            BottomLeft,
            BottomRight
        }
        /// <summary>
        /// Enumeration used to determine the direction of a triangle.
        /// </summary>
        /// <remarks><seealso cref="DrawTriangle"/></remarks>
        public enum TriangleDirection
        {
            Up,
            Left,
            Right,
            Down,
            UpLeft,
            UpRight,
            DownLeft,
            DownRight
        }

        public enum GripMode
        {
            Left,
            Right
        }
        
        #endregion

        #region Drawing Path

        /// <summary>
        /// Create a rounded corner rectangle.
        /// </summary>
        /// <param name="rect">The rectangle to be rounded.</param>
        /// <param name="topLeft">Range of the top left corner from the rectangle to be rounded.</param>
        /// <param name="topRight">Range of the top right corner from the rectangle to be rounded.</param>
        /// <param name="bottomLeft">Range of the bottom left corner from the rectangle to be rounded.</param>
        /// <param name="bottomRight">Range of the bottom right corner from the rectangle to be rounded.</param>
        /// <returns>A GraphicsPath object that represent a rectangle that have its corners rounded.</returns>
        /// <remarks>The <c>range</c> must be greater than or equal with zero, and must be less then or equal with a half of its rectangle's width or height.
        /// If the <c>range</c> value less than zero, then its return the rect parameter.
        /// If rectangle width greater than its height, then maximum value of <c>range</c> is a half of rectangle height.
        /// There are optionally rounded on its four corner.</remarks>
        public static GraphicsPath RoundedRectangle(this GraphicsPath path, Rectangle rect, int topLeft = 0, int topRight = 0, int bottomLeft = 0, int bottomRight = 0)
        {
            GraphicsPath result = new GraphicsPath();
            if (rect.Width > 0 && rect.Height > 0)
            {
                int maxAllowed = 0;
                if (rect.Height < rect.Width)
                {
                    maxAllowed = Convert.ToInt32(Math.Floor(rect.Height / 2.0));
                }
                else
                {
                    maxAllowed = Convert.ToInt32(Math.Floor(rect.Width / 2.0));
                }
                PointF startPoint = new PointF();
                PointF endPoint = new PointF();
                if (topLeft > 0 && topLeft < maxAllowed)
                {
                    result.AddArc(rect.X, rect.Y, topLeft * 2, topLeft * 2, 180, 90);
                    startPoint = new PointF(rect.X + topLeft, rect.Y);
                    endPoint = new PointF(rect.X, rect.Y + topLeft);
                }
                else
                {
                    startPoint = new PointF(rect.X, rect.Y);
                    endPoint = new PointF(rect.X, rect.Y);
                }
                if (topRight > 0 && topRight < maxAllowed)
                {
                    result.AddLine(startPoint.X, startPoint.Y, rect.Right - (topRight + 1), rect.Y);
                    result.AddArc(rect.Right - ((topRight * 2) + 1), rect.Y, topRight * 2, topRight * 2, 270, 90);
                    startPoint = new Point(rect.Right - 1, rect.Y + topRight);
                }
                else
                {
                    result.AddLine(startPoint.X, startPoint.Y, rect.Right - 1, rect.Y);
                    startPoint = new Point(rect.Right - 1, rect.Y);
                }
                if (bottomRight > 0 && bottomRight < maxAllowed)
                {
                    result.AddLine(startPoint.X, startPoint.Y, startPoint.X, rect.Bottom - (bottomRight + 1));
                    result.AddArc(rect.Right - ((bottomRight * 2) + 1), rect.Bottom - ((bottomRight * 2) + 1), bottomRight * 2, bottomRight * 2, 0, 90);
                    startPoint = new Point(rect.Right - (bottomRight + 1), rect.Bottom - 1);
                }
                else
                {
                    result.AddLine(startPoint.X, startPoint.Y, startPoint.X, rect.Bottom - 1);
                    startPoint = new Point(rect.Right - 1, rect.Bottom - 1);
                }
                if (bottomLeft > 0 && bottomLeft < maxAllowed)
                {
                    result.AddLine(startPoint.X, startPoint.Y, rect.X + bottomLeft, startPoint.Y);
                    result.AddArc(rect.X, rect.Bottom - ((bottomLeft * 2) + 1), bottomLeft * 2, bottomLeft * 2, 90, 90);
                    startPoint = new Point(rect.X, rect.Bottom - (bottomLeft + 1));
                }
                else
                {
                    result.AddLine(startPoint.X, startPoint.Y, rect.X, startPoint.Y);
                    startPoint = new Point(rect.X, Convert.ToInt32(startPoint.Y));
                }
                result.AddLine(startPoint, endPoint);
                result.CloseFigure();
                return result;
            }
            // Return the rect param.
            result.AddRectangle(rect);
            return result;
        }
        
        /// <summary>
        /// Create a lighting glow path from a rectangle.
        /// </summary>
        /// <returns>A GraphicsPath object that represent a lighting glow.</returns>
        /// <param name="rect">The rectangle where lighting glow path to be created.</param>
        /// <param name="glowPoint">One of <see cref="LightingGlowPoint">LightingGlowPoint</see> enumeration value.  Determine where the light starts.</param>
        /// <param name="percentWidth">Percentage of rectangle's width used to create the path.</param>
        /// <param name="percentHeight">Percentage of rectangle's height used to create the path.</param>
        /// <param name="customX">X location where the light starts.  Used when glowPoint value is LightingGlowPoint.Custom.</param>
        /// <param name="customY">Y location where the light starts.  Used when glowPoint value is LightingGlowPoint.Custom.</param>
        public static GraphicsPath GetGlowingPath(this GraphicsPath path, Rectangle rect, LightingGlowPoint glowPoint = LightingGlowPoint.BottomCenter, int percentWidth = 100, int percentHeight = 100, int customX = 0, int customY = 0)
        {
            Rectangle arcRect = new Rectangle();
            GraphicsPath ePath = new GraphicsPath();
            switch (glowPoint)
            {
                case LightingGlowPoint.TopLeft:
                    arcRect = new Rectangle(rect.X - (int)(rect.Width * percentWidth / 100.0), rect.Y - (int)(rect.Height * percentHeight / 100.0), rect.Width * (int)(percentWidth * 2 / 100.0), rect.Height * (int)(percentHeight * 2 / 100.0));
                    ePath.AddLine(rect.X, rect.Y, Convert.ToInt32(rect.X + (rect.Width * percentWidth / 100.0)), rect.Y);
                    ePath.AddArc(arcRect, 0F, 90F);
                    ePath.AddLine(rect.X, rect.Y + Convert.ToInt32(rect.Height * percentHeight / 100.0), rect.X, rect.Y);
                    break;
                case LightingGlowPoint.TopCenter:
                    arcRect = new Rectangle((rect.X + (int)(rect.Width / 2.0)) - (int)(rect.Width * percentWidth / 200.0), rect.Y - (int)(rect.Height * percentHeight / 100.0), rect.Width * (int)(percentWidth / 100.0), rect.Height * (int)(percentHeight * 2 / 100.0));
                    ePath.AddLine(rect.X + Convert.ToInt32(rect.Width * (100 - percentWidth) / 200.0), rect.Y, rect.Right - Convert.ToInt32(rect.Width * (100 - percentWidth) / 200.0), rect.Y);
                    ePath.AddArc(arcRect, 0F, 180F);
                    break;
                case LightingGlowPoint.TopRight:
                    arcRect = new Rectangle(rect.Right - (int)(rect.Width * percentWidth / 100.0), rect.Y - (rect.Height * (int)(percentHeight / 100.0)), rect.Width * (int)(percentWidth * 2 / 100.0), rect.Height * (int)(percentHeight * 2 / 100.0));
                    ePath.AddLine(rect.Right - Convert.ToInt32(rect.Width * percentWidth / 100.0), rect.Y, rect.Right, rect.Y);
                    ePath.AddLine(rect.Right, rect.Y, rect.Right, rect.Y + Convert.ToInt32(rect.Height * percentHeight / 100.0));
                    ePath.AddArc(arcRect, 90F, 90F);
                    break;
                case LightingGlowPoint.MiddleLeft:
                    arcRect = new Rectangle(rect.X - (int)(rect.Width * percentWidth / 100.0), (rect.Y + (int)(rect.Height / 2.0)) - (int)(rect.Height * percentHeight / 200.0), rect.Width * (int)(percentWidth * 2 / 100.0), rect.Height * (int)(percentHeight / 100.0));
                    ePath.AddArc(arcRect, 270F, 180F);
                    ePath.AddLine(rect.X, rect.Bottom - Convert.ToInt32(rect.Height * (100 - percentHeight) / 200.0), rect.X, rect.Y + Convert.ToInt32(rect.Height * (100 - percentHeight) / 200.0));
                    break;
                case LightingGlowPoint.MiddleCenter:
                    arcRect = new Rectangle((rect.X + (int)(rect.Width / 2.0)) - (int)(rect.Width * percentWidth / 200.0), (rect.Y + (int)(rect.Height / 2.0)) - (rect.Height * (int)(percentHeight / 200.0)), rect.Width * (int)(percentWidth / 100.0), rect.Height * (int)(percentHeight / 100.0));
                    ePath.AddEllipse(arcRect);
                    break;
                case LightingGlowPoint.MiddleRight:
                    arcRect = new Rectangle(rect.Right - (int)(rect.Width * percentWidth / 100.0), (int)(rect.Y + (rect.Height / 2.0)) - (int)(rect.Height * percentHeight / 200.0), rect.Width * (int)(percentWidth * 2 / 100.0), rect.Height * (int)(percentHeight / 100.0));
                    ePath.AddLine(rect.Right, rect.Bottom - Convert.ToInt32(rect.Height * (100 - percentHeight) / 200.0), rect.Right, rect.Y + Convert.ToInt32(rect.Height * (100 - percentHeight) / 200.0));
                    ePath.AddArc(arcRect, 90F, 180F);
                    break;
                case LightingGlowPoint.BottomLeft:
                    arcRect = new Rectangle(rect.X - (int)(rect.Width * percentWidth / 100.0), rect.Bottom - (int)(rect.Height * percentHeight / 100.0), rect.Width * (int)(percentWidth * 2 / 100.0), rect.Height * (int)(percentHeight * 2 / 100.0));
                    ePath.AddArc(arcRect, 270F, 90F);
                    ePath.AddLine(Convert.ToInt32(rect.X + (rect.Width * percentWidth / 100.0)), rect.Bottom, rect.X, rect.Bottom);
                    ePath.AddLine(rect.X, rect.Bottom, rect.X, rect.Bottom - Convert.ToInt32(rect.Height * percentHeight / 100.0));
                    break;
                case LightingGlowPoint.BottomCenter:
                    arcRect = new Rectangle((rect.X + (int)(rect.Width / 2.0)) - (int)(rect.Width * percentWidth / 200.0), rect.Bottom - (int)(rect.Height * percentHeight / 100.0), rect.Width * (int)(percentWidth / 100.0), rect.Height * (int)(percentHeight * 2 / 100.0));
                    ePath.AddArc(arcRect, 180F, 180F);
                    ePath.AddLine(rect.X + Convert.ToInt32(rect.Width * (100 - percentWidth) / 200.0), rect.Bottom, rect.Right - Convert.ToInt32(rect.Width * (100 - percentWidth) / 200.0), rect.Bottom);
                    break;
                case LightingGlowPoint.BottomRight:
                    arcRect = new Rectangle(rect.Right - (int)(rect.Width * percentWidth / 100.0), rect.Bottom - (int)(rect.Height * percentHeight / 100.0), rect.Width * (int)(percentWidth * 2 / 100.0), rect.Height * (int)(percentHeight * 2 / 100.0));
                    ePath.AddArc(arcRect, 180F, 90F);
                    ePath.AddLine(rect.Right, rect.Bottom - Convert.ToInt32(rect.Height * percentHeight / 100.0), rect.Right, rect.Bottom);
                    ePath.AddLine(rect.Right, rect.Bottom, rect.Right - Convert.ToInt32(rect.Width * percentWidth / 100.0), rect.Bottom);
                    break;
                case LightingGlowPoint.Custom:
                    arcRect = new Rectangle((rect.X + customX) - (int)(rect.Width * percentWidth / 200.0), (int)(rect.Y + customY) - (int)(rect.Height * percentHeight / 200.0), rect.Width * (int)(percentWidth / 100.0), rect.Height * (int)(percentHeight / 100.0));
                    ePath.AddEllipse(arcRect);
                    break;
            }
            ePath.CloseFigure();
            return ePath;
        }
        
        /// <summary>
        /// Create a GraphicsPath object represent an inner shadow of a rectangle.
        /// </summary>
        /// <returns>A GraphicsPath object that represent an inner shadow.</returns>
        /// <param name="rect">The rectangle where shadow path to be created.</param>
        /// <param name="shadow">One of <see cref="ShadowPoint">ShadowPoint</see> enumeration value.  Determine the place of the shadow inside the rectangle.</param>
        /// <param name="verticalRange">Shadow height, calculated from top or bottom of the rectange.</param>
        /// <param name="horizontalRange">Shadow width, calculated from left or right of the rectangle.</param>
        /// <param name="topLeft">Rounded range of the rectangle's top left corner.</param>
        /// <param name="topRight">Rounded range of the rectangle's top right corner.</param>
        /// <param name="bottomLeft">Rounded range of the rectangle's bottom left corner.</param>
        /// <param name="bottomRight">Rounded range of the rectangle's bottom right corner.</param>
        /// <remarks><seealso cref="ShadowPoint"/></remarks>
        public static GraphicsPath GetInnerShadowPath(this GraphicsPath path, Rectangle rect, ShadowPoint shadow = ShadowPoint.Top, int verticalRange = 2, int horizontalRange = 2, int topLeft = 0, int topRight = 0, int bottomLeft = 0, int bottomRight = 0)
        {
            GraphicsPath result = new GraphicsPath();
            if (rect.Width > 0 && rect.Height > 0)
            {
                int maxAllowed = 0;
                if (rect.Height < rect.Width)
                {
                    maxAllowed = Convert.ToInt32(Math.Floor(rect.Height / 2.0));
                }
                else
                {
                    maxAllowed = Convert.ToInt32(Math.Floor(rect.Width / 2.0));
                }
                if (verticalRange < Math.Floor(rect.Height / 2.0) && horizontalRange < Math.Floor(rect.Width / 2.0))
                {
                    // Building shadow
                    switch (shadow)
                    {
                        case ShadowPoint.Top:
                        case ShadowPoint.TopLeft:
                        case ShadowPoint.TopRight:
                            {
                                // Shadow from top
                                PointF startPoint = new PointF();
                                PointF endPoint = new PointF();
                                if (topLeft > 0 && topLeft < maxAllowed)
                                {
                                    result.AddArc(rect.X, rect.Y, topLeft * 2, topLeft * 2, 180, 90);
                                    startPoint = new PointF(rect.X + topLeft, rect.Y);
                                    endPoint = new PointF(rect.X, rect.Y + topLeft);
                                }
                                else
                                {
                                    startPoint = new PointF(rect.X, rect.Y);
                                    endPoint = new PointF(rect.X, rect.Y);
                                }
                                if (topRight > 0 && topRight < maxAllowed)
                                {
                                    result.AddLine(startPoint.X, startPoint.Y, rect.Right - (topRight + 1), rect.Y);
                                    result.AddArc(rect.Right - ((topRight * 2) + 1), rect.Y, topRight * 2, topRight * 2, 270, 90);
                                    startPoint = new PointF(rect.Right - 1, rect.Y + topRight);
                                }
                                else
                                {
                                    result.AddLine(startPoint.X, startPoint.Y, rect.Right - 1, rect.Y);
                                    startPoint = new PointF(rect.Right - 1, rect.Y);
                                }
                                if (shadow == ShadowPoint.TopRight)
                                {
                                    if (bottomRight > 0 && bottomRight < maxAllowed)
                                    {
                                        result.AddLine(startPoint.X, startPoint.Y, startPoint.X, rect.Bottom - (bottomRight + 1));
                                        result.AddArc(rect.Right - ((bottomRight * 2) + 1), rect.Bottom - ((bottomRight * 2) + 1), bottomRight * 2, bottomRight * 2, 0, 90);
                                        startPoint = new PointF(rect.Right - (bottomRight + 1), rect.Bottom - 1);
                                    }
                                    else
                                    {
                                        result.AddLine(startPoint.X, startPoint.Y, startPoint.X, rect.Bottom - 1);
                                        startPoint = new PointF(startPoint.X, rect.Bottom - 1);
                                    }
                                    result.AddLine(startPoint.X, startPoint.Y, startPoint.X - horizontalRange, startPoint.Y);
                                    startPoint = new PointF(startPoint.X - horizontalRange, startPoint.Y);
                                    if (bottomRight > 0 && bottomRight < maxAllowed)
                                    {
                                        result.AddArc(startPoint.X - bottomRight, rect.Bottom - ((bottomRight * 2) + 1), bottomRight * 2, bottomRight * 2, 90, -90);
                                        startPoint = new PointF(startPoint.X + bottomRight, rect.Bottom - (bottomRight + 1));
                                    }
                                    if (topRight > 0 && topRight < maxAllowed)
                                    {
                                        result.AddLine(startPoint.X, startPoint.Y, startPoint.X, rect.Y + topRight + verticalRange);
                                        result.AddArc(rect.Right - (horizontalRange + (topRight * 2) + 1), rect.Y + verticalRange, topRight * 2, topRight * 2, 0, -90);
                                        startPoint = new PointF(rect.Right - (horizontalRange + topRight + 1), rect.Y + verticalRange);
                                    }
                                    else
                                    {
                                        result.AddLine(startPoint.X, startPoint.Y, startPoint.X, rect.Y + verticalRange);
                                        startPoint = new PointF(rect.Right - (horizontalRange + 1), rect.Y + verticalRange);
                                    }
                                }
                                else
                                {
                                    result.AddLine(startPoint.X, startPoint.Y, startPoint.X, startPoint.Y + verticalRange);
                                    startPoint = new PointF(startPoint.X, startPoint.Y + verticalRange);
                                    if (topRight > 0 && topRight < maxAllowed)
                                    {
                                        result.AddArc(rect.Right - ((topRight * 2) + 1), startPoint.Y - topRight, topRight * 2, topRight * 2, 0, -90);
                                        startPoint = new PointF(rect.Right - 1, startPoint.Y - topRight);
                                    }
                                }
                                if (shadow == ShadowPoint.TopLeft)
                                {
                                    if (topLeft > 0 && topLeft < maxAllowed)
                                    {
                                        result.AddLine(startPoint, new PointF(rect.X + horizontalRange + topLeft, startPoint.Y));
                                        result.AddArc(rect.X + horizontalRange, rect.Y + verticalRange, topLeft * 2, topLeft * 2, 270, -90);
                                        startPoint = new PointF(rect.X + horizontalRange, rect.Y + verticalRange + topLeft);
                                    }
                                    else
                                    {
                                        result.AddLine(startPoint, new PointF(rect.X + horizontalRange, startPoint.Y));
                                        startPoint = new PointF(rect.X + horizontalRange, rect.Y + verticalRange);
                                    }
                                    if (bottomLeft > 0 && bottomLeft < maxAllowed)
                                    {
                                        result.AddLine(startPoint, new PointF(startPoint.X, rect.Bottom - (bottomLeft + 1)));
                                        result.AddArc(rect.X + horizontalRange, rect.Bottom - ((bottomLeft * 2) + 1), bottomLeft * 2, bottomLeft * 2, 180, -90);
                                        result.AddLine(rect.X + horizontalRange + bottomLeft, rect.Bottom - 1, rect.X + bottomLeft, rect.Bottom - 1);
                                        result.AddArc(rect.X, rect.Bottom - ((bottomLeft * 2) - 1), bottomLeft * 2, bottomLeft * 2, 90, 90);
                                        startPoint = new PointF(rect.X, rect.Bottom - (bottomLeft + 1));
                                    }
                                    else
                                    {
                                        result.AddLine(startPoint, new PointF(startPoint.X, rect.Bottom - 1));
                                        result.AddLine(startPoint.X, rect.Bottom - 1, rect.X, rect.Bottom - 1);
                                        startPoint = new PointF(rect.X, rect.Bottom - 1);
                                    }
                                }
                                else
                                {
                                    if (topLeft > 0 && topLeft < maxAllowed)
                                    {
                                        result.AddLine(startPoint.X, startPoint.Y, rect.X + topLeft, startPoint.Y);
                                        result.AddArc(rect.X, startPoint.Y, topLeft * 2, topLeft * 2, 270, -90);
                                        startPoint = new PointF(rect.X, startPoint.Y + topLeft);
                                    }
                                    else
                                    {
                                        result.AddLine(startPoint.X, startPoint.Y, rect.X, startPoint.Y);
                                        startPoint = new PointF(rect.X, startPoint.Y);
                                    }
                                }
                                result.AddLine(startPoint, endPoint);
                                result.CloseFigure();
                                return result;
                            }
                        case ShadowPoint.Bottom:
                        case ShadowPoint.BottomLeft:
                        case ShadowPoint.BottomRight:
                            {
                                // Shadow from bottom
                                PointF startPoint = new PointF();
                                PointF endPoint = new PointF();
                                if (bottomLeft > 0 && bottomLeft < maxAllowed)
                                {
                                    result.AddArc(rect.X, rect.Bottom - ((bottomLeft * 2) + 1), bottomLeft * 2, bottomLeft * 2, 180, -90);
                                    startPoint = new PointF(rect.X + bottomLeft, rect.Bottom - 1);
                                    endPoint = new PointF(rect.X, rect.Bottom - (bottomLeft + 1));
                                }
                                else
                                {
                                    startPoint = new PointF(rect.X, rect.Bottom - 1);
                                    endPoint = new PointF(rect.X, rect.Bottom - 1);
                                }
                                if (bottomRight > 0 && bottomRight < maxAllowed)
                                {
                                    result.AddLine(startPoint, new PointF(rect.Right - (bottomRight + 1), rect.Bottom - 1));
                                    result.AddArc(rect.Right - ((bottomRight * 2) + 1), rect.Bottom - ((bottomRight * 2) + 1), bottomRight * 2, bottomRight * 2, 90, -90);
                                    startPoint = new PointF(rect.Right - 1, rect.Bottom - (bottomRight + 1));
                                }
                                else
                                {
                                    result.AddLine(startPoint, new PointF(rect.Right - 1, rect.Bottom - 1));
                                    startPoint = new PointF(rect.Right - 1, rect.Bottom - 1);
                                }
                                if (shadow == ShadowPoint.BottomRight)
                                {
                                    if (topRight > 0 && topRight < maxAllowed)
                                    {
                                        result.AddLine(startPoint, new PointF(startPoint.X, rect.Y + topRight + 1));
                                        result.AddArc(rect.Right - ((topRight * 2) + 1), rect.Y, topRight * 2, topRight * 2, 0, -90);
                                        startPoint = new PointF(rect.Right - (topRight + 1), rect.Y);
                                    }
                                    else
                                    {
                                        result.AddLine(startPoint, new PointF(rect.Right - 1, rect.Y));
                                        startPoint = new PointF(rect.Right - 1, rect.Y);
                                    }
                                    result.AddLine(startPoint, new PointF(startPoint.X - horizontalRange, rect.Y));
                                    startPoint = new PointF(startPoint.X - horizontalRange, rect.Y);
                                    if (topRight > 0 && topRight < maxAllowed)
                                    {
                                        result.AddArc(startPoint.X - topRight, rect.Y, topRight * 2, topRight * 2, 270, 90);
                                        startPoint = new PointF(startPoint.X + topRight, rect.Y + topRight);
                                    }
                                    if (bottomRight > 0 && bottomRight < maxAllowed)
                                    {
                                        result.AddLine(startPoint, new PointF(startPoint.X, rect.Bottom - (bottomRight + verticalRange + 1)));
                                        result.AddArc(rect.Right - (horizontalRange + (bottomRight * 2) + 1), rect.Bottom - (verticalRange + (bottomRight * 2) + 1), bottomRight * 2, bottomRight * 2, 0, 90);
                                        startPoint = new PointF(rect.Right - (horizontalRange + bottomRight + 1), rect.Bottom - (verticalRange + 1));
                                    }
                                    else
                                    {
                                        result.AddLine(startPoint, new PointF(startPoint.X, rect.Bottom - (verticalRange + 1)));
                                        startPoint = new PointF(startPoint.X, rect.Bottom - (verticalRange + 1));
                                    }
                                }
                                else
                                {
                                    result.AddLine(startPoint, new PointF(startPoint.X, startPoint.Y - verticalRange));
                                    startPoint = new PointF(startPoint.X, startPoint.Y - verticalRange);
                                    if (bottomRight > 0 && bottomRight < maxAllowed)
                                    {
                                        result.AddArc(rect.Right - ((bottomRight * 2) + 1), startPoint.Y - bottomRight, bottomRight * 2, bottomRight * 2, 0, 90);
                                        startPoint = new PointF(rect.Right - (bottomRight + 1), startPoint.Y + bottomRight);
                                    }
                                }
                                if (shadow == ShadowPoint.BottomLeft)
                                {
                                    if (bottomLeft > 0 && bottomLeft < maxAllowed)
                                    {
                                        result.AddLine(startPoint, new PointF(rect.X + horizontalRange + bottomLeft, startPoint.Y));
                                        result.AddArc(rect.X + horizontalRange, rect.Bottom - (verticalRange + (bottomLeft * 2) + 1), bottomLeft * 2, bottomLeft * 2, 90, 90);
                                        startPoint = new PointF(rect.X + horizontalRange, rect.Bottom - (verticalRange + bottomLeft + 1));
                                    }
                                    else
                                    {
                                        result.AddLine(startPoint, new PointF(rect.X + horizontalRange, startPoint.Y));
                                        startPoint = new PointF(rect.X + horizontalRange, rect.Bottom - (verticalRange + 1));
                                    }
                                    if (topLeft > 0 && topLeft < maxAllowed)
                                    {
                                        result.AddLine(startPoint, new PointF(startPoint.X, rect.Y + topLeft));
                                        result.AddArc(rect.X + horizontalRange, rect.Y, topLeft * 2, topLeft * 2, 180, 90);
                                        result.AddLine(rect.X + horizontalRange + topLeft, rect.Y, rect.X + topLeft, rect.Y);
                                        result.AddArc(rect.X, rect.Y, topLeft * 2, topLeft * 2, 270, -90);
                                        startPoint = new PointF(rect.X, rect.Y + topLeft);
                                    }
                                    else
                                    {
                                        result.AddLine(startPoint, new PointF(startPoint.X, rect.Y));
                                        result.AddLine(startPoint.X, rect.Y, rect.X, rect.Y);
                                        startPoint = new PointF(rect.X, rect.Y);
                                    }
                                }
                                else
                                {
                                    if (bottomLeft > 0 && bottomLeft < maxAllowed)
                                    {
                                        result.AddLine(startPoint, new PointF(rect.X + bottomLeft, startPoint.Y));
                                        result.AddArc(rect.X, rect.Bottom - (verticalRange + (bottomLeft * 2) + 1), bottomLeft * 2, bottomLeft * 2, 90, 90);
                                        startPoint = new PointF(rect.X, rect.Bottom - (verticalRange + bottomLeft + 1));
                                    }
                                    else
                                    {
                                        result.AddLine(startPoint, new PointF(rect.X, startPoint.Y));
                                        startPoint = new PointF(rect.X, startPoint.Y);
                                    }
                                }
                                result.AddLine(startPoint, endPoint);
                                result.CloseFigure();
                                return result;
                            }
                        case ShadowPoint.Left:
                            {
                                // Left only shadow
                                PointF startPoint = new PointF();
                                PointF endPoint = new PointF();
                                if (topLeft > 0 && topLeft < maxAllowed)
                                {
                                    endPoint = new PointF(rect.X, rect.Y + topLeft);
                                    result.AddArc(rect.X, rect.Y, topLeft * 2, topLeft * 2, 180, 90);
                                    result.AddLine(rect.X + topLeft, rect.Y, rect.X + horizontalRange + topLeft, rect.Y);
                                    result.AddArc(rect.X + horizontalRange, rect.Y, topLeft * 2, topLeft * 2, 270, -90);
                                    startPoint = new PointF(rect.X + horizontalRange, rect.Y + topLeft);
                                }
                                else
                                {
                                    endPoint = new PointF(rect.X, rect.Y);
                                    result.AddLine(rect.X, rect.Y, rect.X + horizontalRange, rect.Y);
                                    startPoint = new PointF(rect.X + horizontalRange, rect.Y);
                                }
                                if (bottomLeft > 0 && bottomLeft < maxAllowed)
                                {
                                    result.AddLine(startPoint, new PointF(rect.X + horizontalRange, rect.Bottom - (bottomLeft + 1)));
                                    result.AddArc(rect.X + horizontalRange, rect.Bottom - ((bottomLeft * 2) + 1), bottomLeft * 2, bottomLeft * 2, 180, -90);
                                    result.AddLine(rect.X + horizontalRange + bottomLeft, rect.Bottom - 1, rect.X + bottomLeft, rect.Bottom - 1);
                                    result.AddArc(rect.X, rect.Bottom - ((bottomLeft * 2) + 1), bottomLeft * 2, bottomLeft * 2, 90, -90);
                                    startPoint = new PointF(rect.X, rect.Bottom - (bottomLeft + 1));
                                }
                                else
                                {
                                    result.AddLine(startPoint, new PointF(rect.X + horizontalRange, rect.Bottom - 1));
                                    result.AddLine(rect.X + horizontalRange, rect.Bottom - 1, rect.X, rect.Bottom - 1);
                                    startPoint = new PointF(rect.X, rect.Bottom - 1);
                                }
                                result.AddLine(startPoint, endPoint);
                                result.CloseFigure();
                                return result;
                            }
                        case ShadowPoint.Right:
                            {
                                // Right only shadow
                                PointF startPoint = new PointF();
                                PointF endPoint = new PointF();
                                if (topRight > 0 && topRight < maxAllowed)
                                {
                                    endPoint = new PointF(rect.Right - (horizontalRange + 1), rect.Y + topLeft);
                                    result.AddArc(rect.Right - ((topRight * 2) + horizontalRange + 1), rect.Y, topRight * 2, topRight * 2, 0, -90);
                                    result.AddLine(rect.Right - (topRight + horizontalRange + 1), rect.Y, rect.Right - (topRight + 1), rect.Y);
                                    result.AddArc(rect.Right - ((topRight * 2) + 1), rect.Y, topRight * 2, topRight * 2, 270, 90);
                                    startPoint = new PointF(rect.Right - 1, rect.Y + topRight);
                                }
                                else
                                {
                                    endPoint = new PointF(rect.Right - (horizontalRange + 1), rect.Y);
                                    result.AddLine(endPoint, new PointF(rect.Right - 1, rect.Y));
                                    startPoint = new PointF(rect.Right - 1, rect.Y);
                                }
                                if (bottomRight > 0 && bottomRight < maxAllowed)
                                {
                                    result.AddLine(startPoint, new PointF(rect.Right - 1, rect.Bottom - (bottomRight + 1)));
                                    result.AddArc(rect.Right - ((bottomRight * 2) + 1), rect.Bottom - ((bottomRight * 2) + 1), bottomRight * 2, bottomRight * 2, 0, 90);
                                    result.AddLine(rect.Right - (bottomRight + 1), rect.Bottom - 1, rect.Right - (bottomRight + horizontalRange + 1), rect.Bottom - 1);
                                    result.AddArc(rect.Right - ((bottomRight * 2) + horizontalRange + 1), rect.Bottom - ((bottomRight * 2) + 1), bottomRight * 2, bottomRight * 2, 90, -90);
                                    startPoint = new PointF(rect.Right - (horizontalRange + 1), rect.Bottom - (bottomRight + 1));
                                }
                                else
                                {
                                    result.AddLine(startPoint, new PointF(rect.Right - 1, rect.Bottom - 1));
                                    result.AddLine(rect.Right - 1, rect.Bottom - 1, rect.Right - (horizontalRange + 1), rect.Bottom - 1);
                                    startPoint = new PointF(rect.Right - (horizontalRange + 1), rect.Bottom - 1);
                                }
                                result.AddLine(startPoint, endPoint);
                                result.CloseFigure();
                                return result;
                            }
                    }
                }
            }
            result.AddRectangle(rect);
            return result;
        }
        
        #endregion

        #region Triangle
        
        /// <summary>
        /// Draw a shadowed triangle specified by x and y location, overloaded.
        /// </summary>
        /// <param name="g">Graphics object where the triangle to be drawn.</param>
        /// <param name="x">X location of the triangle.</param>
        /// <param name="y">Y location of the triangle.</param>
        /// <param name="color">Color of the triangle.</param>
        /// <param name="shadowColor">Shadow color of the triangle.</param>
        /// <param name="direction"><see cref="TriangleDirection">TriangleDirection</see>, direction of the triangle.</param>
        /// <param name="size">Size of the triangle.</param>
        /// <remarks></remarks>
        public static void DrawTriangle(this System.Drawing.Graphics g, int x, int y, Color color, Color shadowColor, TriangleDirection direction = TriangleDirection.Down, int size = 6)
        {
            if (size > 0)
            {
                PointF[] points = new PointF[4];
                PointF[] shadowPoints = new PointF[4];
                int i = 0;
                switch (direction)
                {
                    case TriangleDirection.Up:
                        points[0] = new PointF(x, y + (size - 1));
                        points[1] = new PointF(x + size, y + (size - 1));
                        points[2] = new PointF(x + (int)(size / 2.0), y);
                        break;
                    case TriangleDirection.Down:
                        points[0] = new PointF(x, y);
                        points[1] = new PointF(x + size, y);
                        points[2] = new PointF(x + (int)(size / 2.0), y + (size - 1));
                        break;
                    case TriangleDirection.Left:
                        points[0] = new PointF(x + (size - 1), y);
                        points[1] = new PointF(x + (size - 1), y + size);
                        points[2] = new PointF(x, y + (int)(size / 2.0));
                        break;
                    case TriangleDirection.Right:
                        points[0] = new PointF(x, y);
                        points[1] = new PointF(x, y + size);
                        points[2] = new PointF(x + (size - 1), y + (int)(size / 2.0));
                        break;
                    case TriangleDirection.UpLeft:
                    case TriangleDirection.UpRight:
                        points[0] = new PointF(x, y);
                        points[1] = new PointF(x + size, y);
                        if (direction == TriangleDirection.UpLeft)
                        {
                            points[2] = new PointF(x, y + size);
                        }
                        else
                        {
                            points[2] = new PointF(x + size, y + size);
                        }
                        break;
                    case TriangleDirection.DownLeft:
                    case TriangleDirection.DownRight:
                        points[0] = new PointF(x, y + size);
                        points[1] = new PointF(x + size, y + size);
                        if (direction == TriangleDirection.DownLeft)
                        {
                            points[2] = new PointF(x, y);
                        }
                        else
                        {
                            points[2] = new PointF(x + size, y);
                        }
                        break;
                }
                points[3] = points[0];
                // Draw its shadow first
                if (direction == TriangleDirection.Down || direction == TriangleDirection.Up || direction == TriangleDirection.Left || direction == TriangleDirection.Right)
                {
                    i = 0;
                    while (i < 4)
                    {
                        shadowPoints[i] = new PointF(points[i].X, points[i].Y + 2);
                        i = i + 1;
                    }
                }
                else
                {
                    i = 0;
                    while (i < 4)
                    {
                        shadowPoints[i] = new PointF(points[i].X + 1, points[i].Y + 2);
                        i = i + 1;
                    }
                }
                g.FillPolygon(new SolidBrush(shadowColor), shadowPoints);
                g.FillPolygon(new SolidBrush(color), points);
            }
        }
        
        /// <summary>
        /// Draw a shadowed triangle specified by p point location, overloaded.
        /// </summary>
        /// <param name="g">Graphics object where the triangle to be drawn.</param>
        /// <param name="p">Point, location of the triangle.</param>
        /// <param name="color">Color of the triangle.</param>
        /// <param name="shadowColor">Shadow color of the triangle.</param>
        /// <param name="direction"><see cref="TriangleDirection">TriangleDirection</see>, direction of the triangle.</param>
        /// <param name="size">Size of the triangle.</param>
        /// <remarks></remarks>
        public static void DrawTriangle(this System.Drawing.Graphics g, Point p, Color color, Color shadowColor, TriangleDirection direction = TriangleDirection.Down, int size = 6)
        {
            DrawTriangle(g, p.X, p.Y, color, shadowColor, direction, size);
        }
        
        /// <summary>
        /// Draw a shadowed triangle in the center of a rectangle, overloaded.
        /// </summary>
        /// <param name="g">Graphics object where the triangle to be drawn.</param>
        /// <param name="rect">Rectangle where the triangle to be drawn.</param>
        /// <param name="color">Color of the triangle.</param>
        /// <param name="shadowColor">Shadow color of the triangle.</param>
        /// <param name="direction"><see cref="TriangleDirection">TriangleDirection</see>, direction of the triangle.</param>
        /// <param name="size">Size of the triangle.</param>
        /// <remarks></remarks>
        public static void DrawTriangle(this System.Drawing.Graphics g, Rectangle rect, Color color, Color shadowColor, TriangleDirection direction = TriangleDirection.Down, int size = 6)
        {
            int x = rect.X + (int)((rect.Width - size) / 2.0);
            int y = rect.Y + (int)((rect.Height - size) / 2.0);
            DrawTriangle(g, x, y, color, shadowColor, direction, size);
        }
        
        #endregion

        #region Imaging
        /// <summary>
        /// Get a resized bounding rectangle of an image specified by maxSize.
        /// </summary>
        /// <param name="img">Image to measure.</param>
        /// <param name="maxSize">Maximum width or height of the result.</param>
        /// <returns>A rectangle represent resized bounding of an image.</returns>
        /// <remarks>If image is nothing, a (0, 0, 0, 0) rectangle returned.</remarks>
        public static Rectangle GetImageRectangle(this Rectangle rectangle, Image img, int maxSize)
        {
            Rectangle iRect = new Rectangle(0, 0, 0, 0);
            if (img != null)
            {
                if (img.Width <= maxSize && img.Height <= maxSize)
                {
                    iRect.Width = img.Width;
                    iRect.Height = img.Height;
                }
                else
                {
                    if (img.Width == img.Height)
                    {
                        iRect.Width = maxSize;
                        iRect.Height = maxSize;
                    }
                    else
                    {
                        if (img.Width > img.Height)
                        {
                            iRect.Width = maxSize;
                            iRect.Height = img.Height * maxSize / img.Width;
                        }
                        else
                        {
                            iRect.Height = maxSize;
                            iRect.Width = img.Width * maxSize / img.Height;
                        }
                    }
                }
            }
            return iRect;
        }
        
        /// <summary>
        /// Get a resized bounding rectangle of an image specified by maxSize inside of a rectangle.
        /// </summary>
        /// <param name="img">Image to measure.</param>
        /// <param name="rect">Rectangle where the result to be placed.</param>
        /// <param name="maxSize">Maximum width or height of the result.</param>
        /// <returns>A rectangle represent resized bounding of an image.</returns>
        /// <remarks>If image is nothing, rect parameter returned.</remarks>
        public static Rectangle GetImageRectangle(this Rectangle rectangle, Image img, Rectangle rect, int maxSize)
        {
            if (img != null)
            {
                Rectangle iRect = new Rectangle();
                if (img.Width <= maxSize && img.Height <= maxSize)
                {
                    iRect.Width = img.Width;
                    iRect.Height = img.Height;
                }
                else
                {
                    if (img.Width == img.Height)
                    {
                        iRect.Width = maxSize;
                        iRect.Height = maxSize;
                    }
                    else
                    {
                        if (img.Width > img.Height)
                        {
                            iRect.Width = maxSize;
                            iRect.Height = img.Height * maxSize / img.Width;
                        }
                        else
                        {
                            iRect.Height = maxSize;
                            iRect.Width = img.Width * maxSize / img.Height;
                        }
                    }
                }
                iRect.X = rect.X + (int)((rect.Width - iRect.Width) / 2.0);
                iRect.Y = rect.Y + (int)((rect.Height - iRect.Height) / 2.0);
                return iRect;
            }
            return rect;
        }
        
        /// <summary>
        /// Get a resized bounding rectangle of an image specified by maximum width and maximum height inside of a rectangle.
        /// </summary>
        /// <param name="img">Image to measure.</param>
        /// <param name="rect">Rectangle where the result to be placed.</param>
        /// <param name="maxWidth">Maximum width of the result.</param>
        /// <param name="maxHeight">Maximum height of the result.</param>
        /// <returns>A rectangle represent resized bounding of an image.</returns>
        /// <remarks>If image is nothing, rect parameter returned.</remarks>
        public static Rectangle GetImageRectangle(this Rectangle rectangle, Image img, Rectangle rect, int maxWidth, int maxHeight)
        {
            if (img != null)
            {
                Rectangle iRect = new Rectangle();
                if (img.Width <= maxWidth && img.Height <= maxHeight)
                {
                    iRect.Width = img.Width;
                    iRect.Height = img.Height;
                }
                else
                {
                    if (img.Width == img.Height)
                    {
                        iRect.Width = (maxWidth > maxHeight) ? maxHeight : maxWidth;
                        iRect.Height = (maxWidth > maxHeight) ? maxHeight : maxWidth;
                    }
                    else
                    {
                        if (img.Width / (double)img.Height > maxWidth / (double)maxHeight)
                        {
                            iRect.Width = maxWidth;
                            iRect.Height = img.Height * maxWidth / img.Width;
                        }
                        else
                        {
                            iRect.Height = maxHeight;
                            iRect.Width = img.Width * maxHeight / img.Height;
                        }
                    }
                }
                iRect.X = rect.X + (int)((rect.Width - iRect.Width) / 2.0);
                iRect.Y = rect.Y + (int)((rect.Height - iRect.Height) / 2.0);
                return iRect;
            }
            return rect;
        }
        
        /// <summary>
        /// Resize an image to fit maximum value.
        /// </summary>
        /// <param name="image">Image to measure.</param>
        /// <param name="max">Maximum width or height of the result.</param>
        /// <returns>A size represent resized image size.</returns>
        /// <remarks>If image is nothing, a (0, 0) size returned.</remarks>
        public static Size ScaleImage(this Size size, Image image, int max)
        {
            Size result = new Size(0, 0);
            if (image != null)
            {
                if (image.Width == image.Height)
                {
                    result = new Size(max, max);
                }
                else
                {
                    if (image.Width > image.Height)
                    {
                        result = new Size(max, max * (int)(image.Height / (double)image.Width));
                    }
                    else
                    {
                        result = new Size(max * (int)(image.Width / (double)image.Height), max);
                    }
                }
            }
            return result;
        }
        
        /// <summary>
        /// Draw a grayscaled image from an image inside a rectangle.
        /// </summary>
        /// <param name="image">Image to be drawn.</param>
        /// <param name="rect">Rectangle where a grayscaled image to be drawn.</param>
        /// <param name="g">Graphics object where the grayscaled image to be drawn.</param>
        public static void GrayscaledImage(this System.Drawing.Graphics g, Image image, Rectangle rect)
        {
            if (image != null)
            {
                System.Drawing.Imaging.ColorMatrix grayMatrix = null;
                int i = 0;
                int j = 0;
                System.Drawing.Imaging.ImageAttributes imgAttr = null;
                grayMatrix = new System.Drawing.Imaging.ColorMatrix();
                i = 0;
                while (i < 5)
                {
                    j = 0;
                    while (j < 5)
                    {
                        grayMatrix[i, j] = 0.0F;
                        j = j + 1;
                    }
                    i = i + 1;
                }
                grayMatrix[0, 0] = 0.299F;
                grayMatrix[0, 1] = 0.299F;
                grayMatrix[0, 2] = 0.299F;
                grayMatrix[1, 0] = 0.587F;
                grayMatrix[1, 1] = 0.587F;
                grayMatrix[1, 2] = 0.587F;
                grayMatrix[2, 0] = 0.114F;
                grayMatrix[2, 1] = 0.114F;
                grayMatrix[2, 2] = 0.114F;
                grayMatrix[3, 3] = 1.0F;
                grayMatrix[4, 4] = 1.0F;
                imgAttr = new System.Drawing.Imaging.ImageAttributes();
                imgAttr.SetColorMatrix(grayMatrix);
                g.DrawImage(image, rect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imgAttr);
            }
        }
        #endregion

        #region Miscellaneous
        /// <summary>
        /// Get a color structure from an AHSB value
        /// </summary>
        /// <param name="a">Alpha value from the color.</param>
        /// <param name="h">Hue value from the color.</param>
        /// <param name="s">Saturation value from the color.</param>
        /// <param name="b">Brightness value from the color.</param>
        /// <returns>A color structure represent AHSB value.</returns>
        public static Color ColorFromAHSB(int a, float h, float s, float b)
        {
            // http://130.113.54.154/~monger/hsl-rgb.html
            if (h < 0.0F || h > 360.0F || s < 0.0F || s > 1.0F || b < 0.0F || b > 1.0F)
            {
                return Color.Black;
            }
            if (s == 0.0F)
            {
                return Color.FromArgb(a, Convert.ToInt32(255 * b), Convert.ToInt32(255 * b), Convert.ToInt32(255 * b));
            }
            float temp1 = 0F;
            float temp2 = 0F;
            float hConv = h / 360;
            float[] tmps = new float[3];
            int i = 0;
            if (b < 0.5F)
            {
                temp2 = b * (1 + s);
            }
            else
            {
                temp2 = (b + s) - (b * s);
            }
            temp1 = (2 * b) - temp2;
            tmps[0] = hConv + (float)(1 / 3.0);
            tmps[1] = hConv;
            tmps[2] = hConv - (float)(1 / 3.0);
            i = 0;
            while (i < 3)
            {
                if (tmps[i] < 0)
                {
                    tmps[i] = tmps[i] + 1.0F;
                }
                if (tmps[i] > 1)
                {
                    tmps[i] = tmps[i] - 1.0F;
                }
                if (6.0F * tmps[i] < 1)
                {
                    tmps[i] = temp1 + (temp2 - temp1) * 6.0F * tmps[i];
                }
                else if (2.0F * tmps[i] < 1)
                {
                    tmps[i] = temp2;
                }
                else if (3.0F * tmps[i] < 2)
                {
                    tmps[i] = temp1 + (temp2 - temp1) * ((2.0F / 3.0F) - tmps[i]) * 6.0F;
                }
                i = i + 1;
            }
            return Color.FromArgb(a, Convert.ToInt32(255 * tmps[0]), Convert.ToInt32(255 * tmps[1]), Convert.ToInt32(255 * tmps[2]));
        }

        public static ColorBlend SizingGripBlend
        {
            get
            {
                ColorBlend aBlend = null;
                Color[] colors = new Color[2];
                float[] pos = new float[2];
                aBlend = new ColorBlend();
                colors[0] = Color.White;
                colors[1] = Color.FromArgb(223, 233, 239);
                pos[0] = 0F;
                pos[1] = 1F;
                aBlend.Colors = colors;
                aBlend.Positions = pos;
                return aBlend;
            }
        }

        public static Pen GripBorderPen
        {
            get
            {
                return new Pen(Color.FromArgb(221, 231, 238));
            }
        }

        public static Brush GripDotBrush
        {
            get
            {
                return new SolidBrush(Color.FromArgb(82, 116, 167));
            }
        }

        public static void DrawGrip(this System.Drawing.Graphics g, Point p, GripMode mode = GripMode.Right)
        {
            if (mode == GripMode.Right)
            {
                DrawRightBottomGrid(g, p.X, p.Y);
            }
            else
            {
                DrawLeftBottomGrid(g, p.X, p.Y);
            }
        }

        public static void DrawGrip(this System.Drawing.Graphics g, int x, int y, GripMode mode = GripMode.Right)
        {
            if (mode == GripMode.Right)
            {
                DrawRightBottomGrid(g, x, y);
            }
            else
            {
                DrawLeftBottomGrid(g, x, y);
            }
        }

        public static void DrawVGrip(this System.Drawing.Graphics g, Rectangle rect)
        {
            Rectangle aRect = new Rectangle(rect.X + (int)((rect.Width - 20) / 2.0), rect.Y + 1, 20, 7);
            DrawBottomGrid(g, aRect.X, aRect.Y);
        }

        public static void DrawRightBottomGrid(this System.Drawing.Graphics g, int x, int y)
        {
            Rectangle rectDot = new Rectangle(0, 0, 2, 2);
            rectDot.X = x + 5;
            rectDot.Y = y + 4;
            g.FillEllipse(Brushes.White, rectDot);
            rectDot.X = rectDot.X + 1;
            rectDot.Y = rectDot.Y - 1;
            g.FillEllipse(GripDotBrush, rectDot);
            rectDot.X = x + 5;
            rectDot.Y = y + 7;
            g.FillEllipse(Brushes.White, rectDot);
            rectDot.X = rectDot.X + 1;
            rectDot.Y = rectDot.Y - 1;
            g.FillEllipse(GripDotBrush, rectDot);
            rectDot.X = x + 1;
            rectDot.Y = y + 7;
            g.FillEllipse(Brushes.White, rectDot);
            rectDot.X = rectDot.X + 1;
            rectDot.Y = rectDot.Y - 1;
            g.FillEllipse(GripDotBrush, rectDot);
        }

        public static void DrawLeftBottomGrid(this System.Drawing.Graphics g, int x, int y)
        {
            Rectangle rectDot = new Rectangle(0, 0, 2, 2);
            rectDot.X = x + 1;
            rectDot.Y = y + 4;
            g.FillEllipse(Brushes.White, rectDot);
            rectDot.X = rectDot.X + 1;
            rectDot.Y = rectDot.Y - 1;
            g.FillEllipse(GripDotBrush, rectDot);
            rectDot.X = x + 5;
            rectDot.Y = y + 7;
            g.FillEllipse(Brushes.White, rectDot);
            rectDot.X = rectDot.X + 1;
            rectDot.Y = rectDot.Y - 1;
            g.FillEllipse(GripDotBrush, rectDot);
            rectDot.X = x + 1;
            rectDot.Y = y + 7;
            g.FillEllipse(Brushes.White, rectDot);
            rectDot.X = rectDot.X + 1;
            rectDot.Y = rectDot.Y - 1;
            g.FillEllipse(GripDotBrush, rectDot);
        }

        public static void DrawBottomGrid(this System.Drawing.Graphics g, int x, int y)
        {
            Rectangle rectDot = new Rectangle(0, 0, 2, 2);
            int i = 0;
            rectDot.X = x + 3;
            rectDot.Y = y + 3;
            i = 0;
            while (i < 4)
            {
                g.FillEllipse(Brushes.White, rectDot);
                rectDot.X = rectDot.X - 1;
                rectDot.Y = rectDot.Y - 1;
                g.FillEllipse(GripDotBrush, rectDot);
                rectDot.X = rectDot.X + 6;
                rectDot.Y = rectDot.Y + 1;
                i = i + 1;
            }
        }
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property NormalTextBrush(Optional ByVal theme As ColorTheme = ColorTheme.Blue) As SolidBrush
        public static SolidBrush NormalTextBrush(this SolidBrush brush, Color customColor, ColorTheme theme = ColorTheme.Blue)
        {
            switch (theme)
            {
                case ColorTheme.Blue:
                    return new SolidBrush(Color.Black);
                case ColorTheme.BlackBlue:
                    return new SolidBrush(Color.FromArgb(255, 255, 255));
                case ColorTheme.Custom:
                    return new SolidBrush(customColor);
                default:
                    return new SolidBrush(Color.Black);
            }
            
        }
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property DisabledTextBrush(Optional ByVal theme As ColorTheme = ColorTheme.Blue) As SolidBrush
        public static SolidBrush DisabledTextBrush(this SolidBrush brush, Color customColor, ColorTheme theme = ColorTheme.Blue)
        {
            switch (theme)
            {
                case ColorTheme.Blue:
                case ColorTheme.BlackBlue:
                    return new SolidBrush(Color.FromArgb(118, 118, 118));
                case ColorTheme.Custom:
                    return new SolidBrush(customColor);
                default:
                    return null;
            }
        }

        public static bool CompareColor(this bool compare, Color clr1, Color clr2)
        {
            return clr1.A == clr2.A && clr1.R == clr2.R && clr1.G == clr2.G && clr1.B == clr2.B;
        }
        
        #endregion

    }
}
