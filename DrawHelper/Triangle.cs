// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Triangle.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing
{
    /// <summary>
    /// A class collection for rendering Triangle
    /// </summary>
    public static partial class DrawRenderer
    {
        /// <summary>
        /// Direction
        /// </summary>
        public enum Direction : byte
        {
            /// <summary>
            /// Up
            /// </summary>
            Up = 0,
            /// <summary>
            /// Down
            /// </summary>
            Down = 1,
            /// <summary>
            /// The left
            /// </summary>
            Left = 2,
            /// <summary>
            /// The right
            /// </summary>
            Right = 3
        }

        /// <summary>
        /// Draw Triangle
        /// </summary>
        /// <param name="G">Set Graphics</param>
        /// <param name="Rect">Set Rectangle</param>
        /// <param name="D">Set Direction</param>
        /// <param name="C">Set Color</param>
        public static void DrawTriangle(this System.Drawing.Graphics G, Rectangle Rect, Direction D, Color C)
        {
            int halfWidth = Rect.Width / 2;
            int halfHeight = Rect.Height / 2;
            Point p0 = Point.Empty;
            Point p1 = Point.Empty;
            Point p2 = Point.Empty;

            switch (D)
            {
                case Direction.Up:
                    p0 = new Point(Rect.Left + halfWidth, Rect.Top);
                    p1 = new Point(Rect.Left, Rect.Bottom);
                    p2 = new Point(Rect.Right, Rect.Bottom);

                    break;
                case Direction.Down:
                    p0 = new Point(Rect.Left + halfWidth, Rect.Bottom);
                    p1 = new Point(Rect.Left, Rect.Top);
                    p2 = new Point(Rect.Right, Rect.Top);

                    break;
                case Direction.Left:
                    p0 = new Point(Rect.Left, Rect.Top + halfHeight);
                    p1 = new Point(Rect.Right, Rect.Top);
                    p2 = new Point(Rect.Right, Rect.Bottom);

                    break;
                case Direction.Right:
                    p0 = new Point(Rect.Right, Rect.Top + halfHeight);
                    p1 = new Point(Rect.Left, Rect.Bottom);
                    p2 = new Point(Rect.Left, Rect.Top);

                    break;
            }

            using (SolidBrush B = new SolidBrush(C))
            {
                G.FillPolygon(B, new Point[] {
                    p0,
                    p1,
                    p2
                });
            }

        }

    }
}
