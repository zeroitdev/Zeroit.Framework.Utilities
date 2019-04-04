// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ControlShadow.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.BitmapUtils
{
    /// <summary>
    /// Class for drawing shadow
    /// </summary>
    public static class ControlShadow
    {

        #region Implementation
        /*                          Implementation
         *  private void button1_Click(object sender, EventArgs e)
            {
                using (Graphics G = this.CreateGraphics())
                    drawShadow(G, Color.Black, getRectPath(new Rectangle(111, 111, 222, 222)), 17);
            }
         * 
         */ 
        #endregion

        /// <summary>
        /// Draw Shadow
        /// </summary>
        /// <param name="G">Graphics class to use</param>
        /// <param name="c">Color of the shadow</param>
        /// <param name="GP">Graphics Path or Path of the shadow</param>
        /// <param name="d">Integer to represent index of a color.</param>
        /// <param name="control">Control to implement the shadow.</param>
        public static void DrawShadow(this System.Drawing.Graphics G, Color c, GraphicsPath GP, int d, Control control)
        {
            Color[] colors = getColorVector(c, control.BackColor, d).ToArray();
            for (int i = 0; i < d; i++)
            {
                G.TranslateTransform(1f, 0.75f);                // <== shadow vector!
                using (Pen pen = new Pen(colors[i], 1.75f))  // <== pen width (*)
                    G.DrawPath(pen, GP);
            }
            G.ResetTransform();
        }


        private static List<Color> getColorVector(Color fc, Color bc, int depth)
        {
            List<Color> cv = new List<Color>();
            float dRed = 1f * (bc.R - fc.R) / depth;
            float dGreen = 1f * (bc.G - fc.G) / depth;
            float dBlue = 1f * (bc.B - fc.B) / depth;
            for (int d = 1; d <= depth; d++)
                cv.Add(Color.FromArgb(255, (int)(fc.R + dRed * d),
                    (int)(fc.G + dGreen * d), (int)(fc.B + dBlue * d)));
            return cv;
        }

        static GraphicsPath getRectPath(Rectangle R)
        {
            byte[] fm = new byte[3];
            for (int b = 0; b < 3; b++) fm[b] = 1;
            List<Point> points = new List<Point>();
            points.Add(new Point(R.Left, R.Bottom));
            points.Add(new Point(R.Right, R.Bottom));
            points.Add(new Point(R.Right, R.Top));
            return new GraphicsPath(points.ToArray(), fm);
        }

        
    }
}
