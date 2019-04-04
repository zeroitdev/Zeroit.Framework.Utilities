// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Tooltip.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.GraphicsExtension
{

    /// <summary>
    /// A class for rendering Tooltip
    /// </summary>
    public static class ToolTip
    {
        public static Font TitleFont = new Font("Segoe UI", 8F, FontStyle.Bold);
        public static Font TextFont = new Font("Segoe UI", 8F, FontStyle.Regular);
        
        #region Enumerations
        /// <summary>
        /// Describing the content of a tooltip information.
        /// Tooltip information has 3 component, title, text, and image.
        /// </summary>
        public enum Content
        {
            TitleOnly,
            TitleAndText,
            TitleAndImage,
            All,
            ImageOnly,
            ImageAndText,
            TextOnly,
            Empty
        }
        #endregion
        /// <summary>
        /// A brush for drawing a string in tooltip.
        /// </summary>
        /// <returns>Brush.</returns>
        public static Brush TextBrush
        {
            get
            {
                return new SolidBrush(Color.FromArgb(118, 118, 118));
            }
        }
        /// <summary>
        /// A pen for drawing line separator in tooltip.
        /// </summary>
        /// <returns>Pen.</returns>
        public static Pen SeparatorPen
        {
            get
            {
                return new Pen(Color.FromArgb(158, 187, 221));
            }
        }
        /// <summary>
        /// Get the content of the tooltip information.
        /// </summary>
        /// <param name="title">Tooltip title.</param>
        /// <param name="text">Tooltip text.</param>
        /// <param name="image">Tooltip image.</param>
        /// <returns><seealso cref="Content"/></returns>
        public static Content GetContent(string title, string text, Image image)
        {
            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(text) && image != null)
            {
                return Content.All;
            }
            else
            {
                if (!string.IsNullOrEmpty(title))
                {
                    if (image != null)
                    {
                        return Content.TitleAndImage;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(text))
                        {
                            return Content.TitleAndText;
                        }
                        else
                        {
                            return Content.TitleOnly;
                        }
                    }
                }
                else
                {
                    if (image != null)
                    {
                        if (!string.IsNullOrEmpty(text))
                        {
                            return Content.ImageAndText;
                        }
                        else
                        {
                            return Content.ImageOnly;
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(text))
                        {
                            return Content.TextOnly;
                        }
                    }
                }
            }
            return Content.Empty;
        }
        /// <summary>
        /// Determine if a tooltip information isnot empty.
        /// </summary>
        /// <param name="title">Tooltip title.</param>
        /// <param name="text">Tooltip text.</param>
        /// <param name="img">Tooltip image.</param>
        /// <returns>Boolean.</returns>
        public static bool ContainsToolTip(string title, string text, Image img)
        {
            return (!string.IsNullOrEmpty(title)) || (!string.IsNullOrEmpty(text)) || (img != null);
        }
        /// <summary>
        /// Measure the size of a tooltip based on its contents.
        /// </summary>
        /// <param name="title">Tooltip title.</param>
        /// <param name="text">Tooltip text.</param>
        /// <param name="img">Tooltip image.</param>
        /// <returns>Size.</returns>
        public static Size MeasureSize(string title, string text, Image img)
        {
            Size result = new Size();
            int lText = 0;
            Size tSize = new Size(0, 0);
            int y = 0;
            switch (GetContent(title, text, img))
            {
                case Content.All:
                    tSize = TextRenderer.MeasureText(title, TitleFont);
                    result.Width = tSize.Width + 8;
                    result.Height = tSize.Height + 16 + img.Height;
                    y = tSize.Height + 12;
                    lText = img.Width + 8;
                    tSize = TextRenderer.MeasureText(text, TextFont);
                    if (result.Height < y + tSize.Height + 4)
                    {
                        result.Height = y + tSize.Height + 4;
                    }
                    if (result.Width < lText + tSize.Width + 4)
                    {
                        result.Width = lText + tSize.Width + 4;
                    }
                    break;
                case Content.TitleAndImage:
                    result.Height = img.Height + 8;
                    tSize = TextRenderer.MeasureText(title, TitleFont);
                    if (result.Height < tSize.Height + 8)
                    {
                        result.Height = tSize.Height + 8;
                    }
                    result.Width = 12 + img.Width + tSize.Width;
                    break;
                case Content.TitleAndText:
                    tSize = TextRenderer.MeasureText(title, TitleFont);
                    result.Height = tSize.Height + 12;
                    result.Width = tSize.Width + 8;
                    y = tSize.Height + 12;
                    tSize = TextRenderer.MeasureText(text, TextFont);
                    if (result.Width < tSize.Width + 8)
                    {
                        result.Width = tSize.Width + 8;
                    }
                    result.Height = y + tSize.Height + 4;
                    break;
                case Content.TitleOnly:
                    tSize = TextRenderer.MeasureText(title, TitleFont);
                    result.Height = tSize.Height + 8;
                    result.Width = tSize.Width + 8;
                    break;
                case Content.ImageAndText:
                    result.Height = img.Height + 8;
                    tSize = TextRenderer.MeasureText(text, TextFont);
                    if (result.Height < tSize.Height + 8)
                    {
                        result.Height = tSize.Height + 8;
                    }
                    result.Width = 12 + img.Width + tSize.Width;
                    break;
                case Content.ImageOnly:
                    result.Width = img.Width + 8;
                    result.Height = img.Height + 8;
                    break;
                case Content.TextOnly:
                    tSize = TextRenderer.MeasureText(text, TextFont);
                    result.Height = tSize.Height + 8;
                    result.Width = tSize.Width + 8;
                    break;
            }
            return result;
        }
        
        /// <summary>
        /// Draw tooltip information on a tooltip window.
        /// </summary>
        /// <param name="title">Tooltip title.</param>
        /// <param name="text">Tooltip text.</param>
        /// <param name="img">Tooltip image.</param>
        /// <param name="g">Graphics object used to paint.</param>
        /// <param name="rect">Bounding rectangle where tooltip information to be drawn.</param>
        public static void DrawToolTip(string title, string text, Image img, System.Drawing.Graphics g, Rectangle rect)
        {
            SizeF tSize = new SizeF();
            int y = 0;
            switch (GetContent(title, text, img))
            {
                case Content.All:
                    g.DrawString(title, TitleFont, TextBrush, rect.X + 4, rect.Y + 4);
                    tSize = g.MeasureString(title, TitleFont);
                    y = (int)(8 + tSize.Height);
                    g.DrawLine(SeparatorPen, rect.X + 4, y, rect.Right - 4, y);
                    g.DrawLine(new Pen(Color.FromArgb(255, 255, 255)), rect.X + 4, y + 1, rect.Right - 4, y + 1);
                    y = y + 4;
                    g.DrawImage(img, rect.X + 4, y, img.Width, img.Height);
                    g.DrawString(text, TextFont, TextBrush, rect.X + img.Width + 8, y);
                    break;
                case Content.TitleAndImage:
                    g.DrawImage(img, rect.X + 4, rect.Y + 4, img.Width, img.Height);
                    g.DrawString(title, TitleFont, TextBrush, rect.X + 8 + img.Width, rect.Y + 4);
                    break;
                case Content.TitleAndText:
                    g.DrawString(title, TitleFont, TextBrush, rect.X + 4, rect.Y + 4);
                    tSize = g.MeasureString(title, TitleFont);
                    y = (int)(8 + tSize.Height);
                    g.DrawLine(SeparatorPen, rect.X + 4, y, rect.Right - 4, y);
                    g.DrawLine(new Pen(Color.FromArgb(255, 255, 255)), rect.X + 4, y + 1, rect.Right - 4, y + 1);
                    y = y + 4;
                    g.DrawString(text, TextFont, TextBrush, rect.X + 4, y);
                    break;
                case Content.TitleOnly:
                    g.DrawString(title, TitleFont, TextBrush, rect.X + 4, rect.Y + 4);
                    break;
                case Content.ImageAndText:
                    g.DrawImage(img, rect.X + 4, rect.Y + 4, img.Width, img.Height);
                    g.DrawString(text, TextFont, TextBrush, rect.X + 8 + img.Width, rect.Y + 4);
                    break;
                case Content.ImageOnly:
                    g.DrawImage(img, rect.X + 4, rect.Y + 4, img.Width, img.Height);
                    break;
                case Content.TextOnly:
                    g.DrawString(text, TextFont, TextBrush, rect.X + 4, rect.Y + 4);
                    break;
            }
        }

    }
}
