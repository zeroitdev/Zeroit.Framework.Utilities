// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="GraphPlotting.cs" company="Zeroit Dev Technologies">
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
using System;
using System.Drawing;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing
{
    /// <summary>
    /// Class DrawRenderer.
    /// </summary>
    public static partial class DrawRenderer
    {

        //protected const int roundMinBorderLength = 20;

        /// <summary>
        /// Draws the round rect.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="drawPen">The draw pen.</param>
        /// <param name="nLeft">The n left.</param>
        /// <param name="nTop">The n top.</param>
        /// <param name="nRight">The n right.</param>
        /// <param name="nBottom">The n bottom.</param>
        /// <param name="round">The round.</param>
        /// <param name="roundMaxRoundRadius">The round maximum round radius.</param>
        /// <param name="roundMinBorderLength">Length of the round minimum border.</param>
        public static void DrawRoundRect(this System.Drawing.Graphics G, Pen drawPen, int nLeft, int nTop, int nRight, int nBottom, int round, int roundMaxRoundRadius = 3, int roundMinBorderLength = 20)
        {
            if (round > roundMaxRoundRadius)
            {
                round = roundMaxRoundRadius;
            }
            else if (round < 0)
            {
                round = 0;
            }
            if (Math.Abs(nRight - nLeft) < roundMinBorderLength && Math.Abs(nBottom - nTop) < roundMinBorderLength)
            {
                round = 1;
            }

            Point Polygon1 = new Point(nLeft + round, nTop);
            Point Polygon2 = new Point(nRight - round + 1, nTop);

            Point Polygon3 = new Point(nLeft, nTop + round);
            Point Polygon4 = new Point(nRight + 1, nTop + round);

            Point Polygon5 = new Point(nLeft, nBottom - round);
            Point Polygon6 = new Point(nRight + 1, nBottom - round);

            Point Polygon7 = new Point(nLeft + round, nBottom + 1);
            Point Polygon8 = new Point(nRight - round, nBottom + 1);

            //四条主线(上下左右)
            G.DrawLine(drawPen, Polygon1.X, Polygon1.Y, Polygon2.X, Polygon2.Y);
            G.DrawLine(drawPen, Polygon7.X, Polygon7.Y, Polygon8.X, Polygon8.Y);
            G.DrawLine(drawPen, Polygon3.X, Polygon3.Y, Polygon5.X, Polygon5.Y);
            G.DrawLine(drawPen, Polygon4.X, Polygon4.Y, Polygon6.X, Polygon6.Y);

            //四个边角
            G.DrawLine(drawPen, Polygon1.X, Polygon1.Y, Polygon3.X, Polygon3.Y);
            G.DrawLine(drawPen, Polygon2.X, Polygon2.Y, Polygon4.X, Polygon4.Y);
            G.DrawLine(drawPen, Polygon5.X, Polygon5.Y, Polygon7.X, Polygon7.Y);
            G.DrawLine(drawPen, Polygon6.X, Polygon6.Y, Polygon8.X, Polygon8.Y);
        }

        /// <summary>
        /// Draws the round rect.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="drawPen">The draw pen.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="round">The round.</param>
        public static void DrawRoundRect(this System.Drawing.Graphics G, Pen drawPen, Rectangle rect, int round)
        {
            DrawRoundRect(G, drawPen, rect.Left, rect.Top, rect.Right, rect.Bottom, round);
        }

        /// <summary>
        /// Draws the round rect.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="drawPen">The draw pen.</param>
        /// <param name="rect">The rect.</param>
        public static void DrawRoundRect(this System.Drawing.Graphics G, Pen drawPen, Rectangle rect)
        {
            DrawRoundRect(G, drawPen, rect.Left, rect.Top, rect.Right, rect.Bottom, 2);
        }

        /// <summary>
        /// Fills the round rect.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="nLeft">The n left.</param>
        /// <param name="nTop">The n top.</param>
        /// <param name="nRight">The n right.</param>
        /// <param name="nBottom">The n bottom.</param>
        /// <param name="round">The round.</param>
        /// <param name="roundMaxRoundRadius">The round maximum round radius.</param>
        /// <param name="roundMinBorderLength">Length of the round minimum border.</param>
        public static void FillRoundRect(this System.Drawing.Graphics G, Brush brush, int nLeft, int nTop, int nRight, int nBottom, int round, int roundMaxRoundRadius = 3, int roundMinBorderLength = 20)
        {
            if (round > roundMaxRoundRadius)
            {
                round = roundMaxRoundRadius;
            }
            else if (round < 0)
            {
                round = 0;
            }
            if (Math.Abs(nRight - nLeft) < roundMinBorderLength && Math.Abs(nBottom - nTop) < roundMinBorderLength)
            {
                round = 1;
            }

            Point Polygon1 = new Point(nLeft + round, nTop);
            Point Polygon2 = new Point(nRight - round + 1, nTop);

            Point Polygon3 = new Point(nLeft, nTop + round);
            Point Polygon4 = new Point(nRight + 1, nTop + round);

            Point Polygon5 = new Point(nLeft, nBottom - round);
            Point Polygon6 = new Point(nRight + 1, nBottom - round);

            Point Polygon7 = new Point(nLeft + round, nBottom + 1);
            Point Polygon8 = new Point(nRight - round, nBottom + 1);

            G.FillPolygon(brush, new Point[]{   Polygon1,
                      Polygon3,
                      Polygon5,
                      Polygon7,
                      Polygon8,
                      Polygon6,
                      Polygon4,
                      Polygon2});
        }

        /// <summary>
        /// Fills the round rect.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="indentSize">Size of the indent.</param>
        /// <param name="round">The round.</param>
        public static void FillRoundRect(this System.Drawing.Graphics G, Brush brush, Rectangle rect, int indentSize, int round)
        {
            FillRoundRect(G, brush, rect.Left + indentSize, rect.Top + indentSize, rect.Right - indentSize + 1, rect.Bottom - indentSize + 1, round);
        }

        /// <summary>
        /// Fills the round rect.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="rect">The rect.</param>
        public static void FillRoundRect(this System.Drawing.Graphics G, Brush brush, Rectangle rect)
        {
            FillRoundRect(G, brush, rect, 0, 2);
        }

    }
}
