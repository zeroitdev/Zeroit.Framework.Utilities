// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Brushes.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
