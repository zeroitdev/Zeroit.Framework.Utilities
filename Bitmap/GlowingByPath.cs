// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="GlowingByPath.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.BitmapUtils
{
    /// <summary>
    /// Class for making glow by path
    /// </summary>
    public class GlowingByPath
    {

        /// <summary>
        /// Glow functionality
        /// </summary>
        /// <param name="graphics">Graphics class to use</param>
        /// <param name="path">Path of the glow</param>
        /// <param name="control">Sets the control to implement functionality</param>
        public static void Glow(System.Drawing.Graphics graphics, GraphicsPath path, Control control)
        {
            // inside OnPaint
            // overlay
            using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(control.Width, control.Height, PixelFormat.Format32bppArgb))
            {
                using (System.Drawing.Graphics gtemp = System.Drawing.Graphics.FromImage(bmp))
                {
                    // fake glowing
                    using (LinearGradientBrush brush = new LinearGradientBrush(control.ClientRectangle, Color.FromArgb(200, 255, 255, 255), Color.FromArgb(0, 0, 0, 0), LinearGradientMode.Vertical))
                    {
                        brush.SetBlendTriangularShape(0.5f, 1.0f);
                        gtemp.FillPath(brush, path);
                    }
                    // draw on screen
                    graphics.DrawImage(bmp, 0, 0);
                }
            }
        }

    }
}
