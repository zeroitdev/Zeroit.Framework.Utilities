// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="CenterText.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing
{
    /// <summary>
    /// A class collection for text manipulation
    /// </summary>
    public static partial class Text
    {
        /// <summary>
        /// Center String
        /// </summary>
        /// <param name="G">Set Graphics</param>
        /// <param name="T">Set string</param>
        /// <param name="F">Set Font</param>
        /// <param name="C">Set color</param>
        /// <param name="R">Set rectangle</param>
        public static void CenterString(this System.Drawing.Graphics G, string T, Font F, Color C, Rectangle R)
        {
            SizeF TS = G.MeasureString(T, F);

            using (SolidBrush B = new SolidBrush(C))
            {
                G.DrawString(T, F, B, new Point((int)(R.Width / 2 - (TS.Width / 2)), (int)(R.Height / 2 - (TS.Height / 2))));
            }
        }

        /// <summary>
        /// Center String
        /// </summary>
        /// <param name="G">Set Graphics</param>
        /// <param name="text">Set text</param>
        /// <param name="font">Set font</param>
        /// <param name="brush">Set brush</param>
        /// <param name="rect">Set rectangle</param>
        /// <param name="shadow">Set shadow</param>
        /// <param name="yOffset">Set offset</param>
        public static void CenterStringTab(this System.Drawing.Graphics G, string text, Font font, Brush brush, Rectangle rect, bool shadow = false, int yOffset = 0)
        {
            SizeF textSize = G.MeasureString(text, font);
            int textX = (int)(rect.X + (rect.Width / 2) - (textSize.Width / 2));
            int textY = (int)(rect.Y + (rect.Height / 2) - (textSize.Height / 2) + yOffset);

            if (shadow)
                G.DrawString(text, font, new SolidBrush(Color.Black), textX + 1, textY + 1);
            G.DrawString(text, font, brush, textX, textY + 1);

        }


    }

}
