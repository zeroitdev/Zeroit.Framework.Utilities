// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DrawCorners.cs" company="Zeroit Dev Technologies">
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
    /// A class collection for rendering control border
    /// </summary>
    public static partial class Corner
    {

        #region " DrawCorners "


        //private SolidBrush DrawCornersBrush;
        /// <summary>
        /// Draws the corners.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="DrawCornersBrush">The draw corners brush.</param>
        /// <param name="B">The b.</param>
        /// <param name="rounding">if set to <c>true</c> [rounding].</param>
        /// <param name="transparent">if set to <c>true</c> [transparent].</param>
        /// <param name="r">The r.</param>
        /// <param name="c1">The c1.</param>
        /// <param name="offset">The offset.</param>
        public static void DrawCorners(this System.Drawing.Graphics G, Brush DrawCornersBrush, System.Drawing.Bitmap B, bool rounding, bool transparent, Rectangle r, Color c1, int offset)
        {
            DrawCorners(G, DrawCornersBrush, B, true, true, c1, r.X, r.Y, r.Width, r.Height, offset);
        }

        /// <summary>
        /// Draws the corners.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="DrawCornersBrush">The draw corners brush.</param>
        /// <param name="B">The b.</param>
        /// <param name="rounding">if set to <c>true</c> [rounding].</param>
        /// <param name="transparent">if set to <c>true</c> [transparent].</param>
        /// <param name="c1">The c1.</param>
        /// <param name="r1">The r1.</param>
        /// <param name="offset">The offset.</param>
        public static void DrawCorners(this System.Drawing.Graphics G, Brush DrawCornersBrush, System.Drawing.Bitmap B, bool rounding, bool transparent, Color c1, Rectangle r1, int offset)
        {
            DrawCorners(G, DrawCornersBrush, B, true, true, c1, r1.X, r1.Y, r1.Width, r1.Height, offset);
        }

        /// <summary>
        /// Draws the corners.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="DrawCornersBrush">The draw corners brush.</param>
        /// <param name="B">The b.</param>
        /// <param name="rounding">if set to <c>true</c> [rounding].</param>
        /// <param name="transparent">if set to <c>true</c> [transparent].</param>
        /// <param name="c1">The c1.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="offset">The offset.</param>
        public static void DrawCorners(this System.Drawing.Graphics G, Brush DrawCornersBrush, System.Drawing.Bitmap B, bool rounding, bool transparent, Color c1, int x, int y, int width, int height, int offset)
        {
            DrawCorners(G, DrawCornersBrush, B, true, true, c1, x + offset, y + offset, width - (offset * 2), height - (offset * 2));
        }

        /// <summary>
        /// Draws the corners.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="DrawCornersBrush">The draw corners brush.</param>
        /// <param name="B">The b.</param>
        /// <param name="rounding">if set to <c>true</c> [rounding].</param>
        /// <param name="transparent">if set to <c>true</c> [transparent].</param>
        /// <param name="r">The r.</param>
        /// <param name="c1">The c1.</param>
        public static void DrawCorners(this System.Drawing.Graphics G, Brush DrawCornersBrush, System.Drawing.Bitmap B, bool rounding, bool transparent, Rectangle r, Color c1)
        {
            DrawCorners(G, DrawCornersBrush, B, true, true, c1, r.X, r.Y, r.Width, r.Height);
        }

        /// <summary>
        /// Draws the corners.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="DrawCornersBrush">The draw corners brush.</param>
        /// <param name="B">The b.</param>
        /// <param name="rounding">if set to <c>true</c> [rounding].</param>
        /// <param name="transparent">if set to <c>true</c> [transparent].</param>
        /// <param name="c1">The c1.</param>
        /// <param name="r1">The r1.</param>
        public static void DrawCorners(this System.Drawing.Graphics G, Brush DrawCornersBrush, System.Drawing.Bitmap B, bool rounding, bool transparent, Color c1, Rectangle r1)
        {
            DrawCorners(G, DrawCornersBrush, B,true,true,c1, r1.X, r1.Y, r1.Width, r1.Height);
        }

        /// <summary>
        /// Draws the corners.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="DrawCornersBrush">The draw corners brush.</param>
        /// <param name="B">The b.</param>
        /// <param name="rounding">if set to <c>true</c> [rounding].</param>
        /// <param name="transparent">if set to <c>true</c> [transparent].</param>
        /// <param name="c1">The c1.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public static void DrawCorners(this System.Drawing.Graphics G, Brush DrawCornersBrush, System.Drawing.Bitmap B, bool rounding, bool transparent, Color c1, int x, int y, int width, int height)
        {
            if (rounding)
                return;

            if (transparent)
            {
                B.SetPixel(x, y, c1);
                B.SetPixel(x + (width - 1), y, c1);
                B.SetPixel(x, y + (height - 1), c1);
                B.SetPixel(x + (width - 1), y + (height - 1), c1);
            }
            else
            {
                //DrawCornersBrush = new SolidBrush(c1);
                G.FillRectangle(DrawCornersBrush, x, y, 1, 1);
                G.FillRectangle(DrawCornersBrush, x + (width - 1), y, 1, 1);
                G.FillRectangle(DrawCornersBrush, x, y + (height - 1), 1, 1);
                G.FillRectangle(DrawCornersBrush, x + (width - 1), y + (height - 1), 1, 1);
            }
        }

        #endregion
        

    }
}
