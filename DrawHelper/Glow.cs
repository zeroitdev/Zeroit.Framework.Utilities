// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Glow.cs" company="Zeroit Dev Technologies">
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
using Zeroit.Framework.Utilities.GraphicsExtension.Drawing;

namespace Zeroit.Framework.Utilities.GraphicsExtension.BitmapUtils
{
    /// <summary>
    /// Class with extensions for Graphics objects
    /// </summary>
    public static partial class BitmapManipulation
    {

        #region Glow

        /// <summary>
        /// Draws a glowing border around a given rectangle.
        /// </summary>
        /// <param name="g">The current Graphics object.</param>
        /// <param name="content">The rectangle that should contain the content.</param>
        /// <param name="glowColor">The color of the glow effect (will become 50 percent transparent).</param>
        /// <param name="size">The size of the glow effect.</param>
        /// <param name="radius">The optional radius for rounded corners.</param>
        public static void GlowRectangle(this System.Drawing.Graphics g, Rectangle content, Color glowColor, int size = 10, float radius = 0)
        {
            var rect = new Rectangle(content.Left - size, content.Top - size, content.Width +  2 * size, 2 * size + content.Height);
            var gp = new GraphicsPath();
            gp.AddRoundRectangle(rect, radius);
            var pgb = new PathGradientBrush(gp);
            pgb.CenterColor = glowColor;
            pgb.SurroundColors = new Color[] { Color.FromArgb(0, 0, 0, 0) };
            g.FillRectangle(pgb, rect);
        }

        /// <summary>
        /// Draws a glowing border around a given rectangle.
        /// </summary>
        /// <param name="g">The current Graphics object.</param>
        /// <param name="content">The rectangle that should contain the content.</param>
        /// <param name="glowColor">The color of the glow effect (will become 50 percent transparent).</param>
        /// <param name="size">The size of the glow effect.</param>
        /// <param name="radius">The optional radius for rounded corners.</param>
        public static void GlowCircle(this System.Drawing.Graphics g, Rectangle content, Color glowColor, int size = 10, float radius = 0)
        {
            var rect = new Rectangle(content.Left - size, content.Top - size, content.Width + 2 * size, 2 * size + content.Height);
            var gp = new GraphicsPath();
            gp.AddEllipse(rect);
            var pgb = new PathGradientBrush(gp);
            pgb.CenterColor = glowColor;
            pgb.SurroundColors = new Color[] { Color.FromArgb(0, 0, 0, 0) };
            g.FillEllipse(pgb, rect);
        }

        /// <summary>
        /// Draws a glowing border around a given rectangle.
        /// </summary>
        /// <param name="g">The current Graphics object.</param>
        /// <param name="gp">The gp.</param>
        /// <param name="content">The rectangle that should contain the content.</param>
        /// <param name="glowColor">The color of the glow effect (will become 50 percent transparent).</param>
        /// <param name="size">The size of the glow effect.</param>
        /// <param name="radius">The optional radius for rounded corners.</param>
        public static void GlowPath(this System.Drawing.Graphics g, GraphicsPath gp, Rectangle content, Color glowColor, int size = 10, float radius = 0)
        {
            var rect = new Rectangle(content.Left - size, content.Top - size, content.Width + 2 * size, 2 * size + content.Height);
            var pgb = new PathGradientBrush(gp);
            pgb.CenterColor = glowColor;
            pgb.SurroundColors = new Color[] { Color.FromArgb(0, 0, 0, 0) };
            g.FillPath(pgb, gp);
        }

        /// <summary>
        /// Glows the specified rectangle.
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        public static void Glow(Rectangle rectangle)
        {
            Bitmap captionbitmap = new Bitmap(300, 25);
            Image _imageCaption = (Image)captionbitmap;
            Graphics hGraph = Graphics.FromImage(_imageCaption);
            //Create a bitmap in a fixed ratio to the original drawing area.
            Bitmap bm = new Bitmap(300 / 5, 25 / 5);
            //Create a GraphicsPath object. 
            GraphicsPath pth = new GraphicsPath();
            //Add the string in the chosen style. 
            pth.AddString("Test", new FontFamily("Century Gothic"), (int)FontStyle.Bold, 14, new Point(10, 5), StringFormat.GenericTypographic);
            //Get the graphics object for the image. 
            Graphics g = Graphics.FromImage(bm);
            //Create a matrix that shrinks the drawing output by the fixed ratio. 
            Matrix mx = new Matrix(1.0f / 5, 0, 0, 1.0f / 5, -(1.0f / 5), -(1.0f / 5));
            //Choose an appropriate smoothing mode for the halo. 
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //Transform the graphics object so that the same half may be used for both halo and text output. 
            g.Transform = mx;
            //Using a suitable pen...
            Pen p = new Pen(Color.White, 5);
            //Draw around the outline of the path
            g.DrawPath(p, pth);
            //and then fill in for good measure. 
            g.FillPath(Brushes.White, pth);
            //We no longer need this graphics object
            g.Dispose();
            //this just shifts the effect a little bit so that the edge isn't cut off in the demonstration
            //hGraph.Transform = new Matrix(1, 0, 0, 1, 50, 50);
            //setup the smoothing mode for path drawing
            hGraph.SmoothingMode = SmoothingMode.AntiAlias;
            //and the interpolation mode for the expansion of the halo bitmap
            hGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //expand the halo making the edges nice and fuzzy. 
            hGraph.DrawImage(bm, new Rectangle(0, 0, (rectangle.Width - 50), 25), 0, 0, bm.Width, bm.Height, GraphicsUnit.Pixel);
            //Redraw the original text
            hGraph.FillPath(new SolidBrush(Color.Black), pth);
            //and you're done. 
            pth.Dispose();
        }


        #endregion

    }
}
