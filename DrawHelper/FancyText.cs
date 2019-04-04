// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 12-31-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-31-2018
// ***********************************************************************
// <copyright file="FancyText.cs" company="Zeroit Dev Technologies">
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
