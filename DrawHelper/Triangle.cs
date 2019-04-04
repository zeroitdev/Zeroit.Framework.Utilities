// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Triangle.cs" company="Zeroit Dev Technologies">
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
