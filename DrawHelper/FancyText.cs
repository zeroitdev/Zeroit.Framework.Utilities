// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 12-31-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-31-2018
// ***********************************************************************
// <copyright file="FancyText.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing
{
    /// <summary>
    /// A class collection for text manipulation
    /// </summary>
    public static partial class Text
    {
        /// <summary>
        /// Make fancy blurred text image used in Snaptune One UI.
        /// </summary>
        /// <param name="strText">text to make fancy, multiple line is OK</param>
        /// <param name="fnt">font to use</param>
        /// <param name="clrFore">foreground color of text</param>
        /// <param name="clrBack">background color of text</param>
        /// <returns>fancy image of text (transparent background)</returns>
        /// <owner>Zeroit Dev</owner>  <reviewed>00/00/00</reviewed>
        private static Image FancyText(string strText, Font fnt, Color clrFore, Color clrBack, int blurAmount = 6)
        {
            Bitmap bmpOut = null; // bitmap we are creating and will return from this function.

            Graphics g = Graphics.FromHwnd(IntPtr.Zero);

            SizeF sz = g.MeasureString(strText, fnt);
            using (Bitmap bmp = new Bitmap((int)sz.Width, (int)sz.Height))
            using (Graphics gBmp = Graphics.FromImage(bmp))
            using (SolidBrush brBack = new SolidBrush(Color.FromArgb(16, clrBack.R, clrBack.G, clrBack.B)))
            using (SolidBrush brFore = new SolidBrush(clrFore))
            {
                gBmp.SmoothingMode = SmoothingMode.HighQuality;
                gBmp.InterpolationMode = InterpolationMode.HighQualityBilinear;
                gBmp.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                gBmp.DrawString(strText, fnt, brBack, 0, 0);

                // make bitmap we will return.
                bmpOut = new Bitmap(bmp.Width + blurAmount, bmp.Height + blurAmount);
                using (Graphics gBmpOut = Graphics.FromImage(bmpOut))
                {
                    gBmpOut.SmoothingMode = SmoothingMode.HighQuality;
                    gBmpOut.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    gBmpOut.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                    // smear image of background of text about to make blurred background "halo"
                    for (int x = 0; x <= blurAmount; x++)
                    for (int y = 0; y <= blurAmount; y++)
                        gBmpOut.DrawImageUnscaled(bmp, x, y);

                    // draw actual text
                    gBmpOut.DrawString(strText, fnt, brFore, blurAmount / 2, blurAmount / 2);
                }
            }

            return bmpOut;
        }


        /// <summary>
        /// Draws the fancy text.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <param name="Text">The text.</param>
        /// <param name="Font">The font.</param>
        /// <param name="ForeColor">Color of the fore.</param>
        /// <param name="BackColor">Color of the back.</param>
        /// <param name="Width">The width.</param>
        /// <param name="Height">The height.</param>
        /// <param name="blur">The blur.</param>
        public static void DrawFancyText(this Graphics e, string Text, Font Font, Color ForeColor, Color BackColor, int Width, int Height, int blur)
        {
            Bitmap fancyText = (Bitmap) FancyText(Text, Font, ForeColor, BackColor, blur);

            e.DrawImageUnscaled(fancyText, Width, Height);

        }
    }

}
