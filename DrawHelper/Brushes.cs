// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Brushes.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;
using System;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing
{

    /// <summary>
    /// Class BrushUtils.
    /// </summary>
    public static class BrushUtils
    {
        //Special Thanks to Mephobia's for NoiseBrush Functions...
        /// <summary>
        /// Noises the brush.
        /// </summary>
        /// <param name="textureBrush">The texture brush.</param>
        /// <param name="colors">The colors.</param>
        /// <returns>TextureBrush.</returns>
        public static TextureBrush NoiseBrush(this TextureBrush textureBrush, Color[] colors)
        {
            System.Drawing.Bitmap b = new System.Drawing.Bitmap(128, 128);
            Random r = new Random(128);
            for (int x = 0; x <= b.Width - 1; x++)
            {
                for (int y = 0; y <= b.Height - 1; y++)
                {
                    b.SetPixel(x, y, colors[r.Next(colors.Length)]);
                }
            }
            TextureBrush T = new TextureBrush(b);
            b.Dispose();
            return T;
        }

        /// <summary>
        /// Gradients the specified c1.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="c1">The c1.</param>
        /// <param name="c2">The c2.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public static void Gradient(this System.Drawing.Graphics g, Color c1, Color c2, int x, int y, int width, int height)
        {
            Rectangle R = new Rectangle(x, y, width, height);
            using (LinearGradientBrush T = new LinearGradientBrush(R, c1, c2, LinearGradientMode.Vertical))
            {
                g.FillRectangle(T, R);
            }
        }

        /// <summary>
        /// Gradients the specified c1.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="c1">The c1.</param>
        /// <param name="c2">The c2.</param>
        /// <param name="r">The r.</param>
        public static void Gradient(this System.Drawing.Graphics g, Color c1, Color c2, Rectangle r)
        {
            using (LinearGradientBrush T = new LinearGradientBrush(r, c1, c2, LinearGradientMode.Vertical))
            {
                g.FillRectangle(T, r);
            }
        }

    }

}
