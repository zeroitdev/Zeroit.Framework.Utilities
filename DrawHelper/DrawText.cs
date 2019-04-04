// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DrawText.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing
{

    /// <summary>
    /// Class Text.
    /// </summary>
    public static partial class Text
    {

        #region Private Fields

        /// <summary>
        /// The draw text point
        /// </summary>
        private static Point DrawTextPoint;

        /// <summary>
        /// The draw text size
        /// </summary>
        private static Size DrawTextSize;

        /// <summary>
        /// Any bottom
        /// </summary>
        private static readonly System.Drawing.ContentAlignment anyBottom = (System.Drawing.ContentAlignment)1792;

        /// <summary>
        /// Any center
        /// </summary>
        private static readonly System.Drawing.ContentAlignment anyCenter = (System.Drawing.ContentAlignment)546;

        /// <summary>
        /// Any middle
        /// </summary>
        private static readonly System.Drawing.ContentAlignment anyMiddle = (System.Drawing.ContentAlignment)112;

        /// <summary>
        /// Any right
        /// </summary>
        private static readonly System.Drawing.ContentAlignment anyRight = (System.Drawing.ContentAlignment)1092;


        #endregion

        #region Draw Text



        /// <summary>
        /// Draw Text
        /// </summary>
        /// <param name="graphics">Set Graphics</param>
        /// <param name="Text">Set Text or string</param>
        /// <param name="Font">Set Font</param>
        /// <param name="b1">Set Brush</param>
        /// <param name="rectangle">Set Rectangle</param>
        /// <param name="a">Set Horizontal Alignment</param>
        /// <param name="x">Set X</param>
        /// <param name="y">Set Y</param>
        /// <param name="Header">Set Header value</param>
        public static void DrawText(this System.Drawing.Graphics graphics, string Text, Font Font, Brush b1,Rectangle rectangle, HorizontalAlignment a, int x, int y, int Header)
        {
            DrawText(graphics,b1, Text,Font,rectangle, a, x, y, Header);
        }

        /// <summary>
        /// Draws the text.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="b1">The b1.</param>
        /// <param name="Text">The text.</param>
        /// <param name="Font">The font.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="a">a.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="Header">The header.</param>
        public static void DrawText(
            this System.Drawing.Graphics graphics,
            Brush b1, 
            string Text,
            Font Font, 
            Rectangle rectangle, 
            HorizontalAlignment a, 
            int x, 
            int y, 
            int Header)
        {
            //Graphics G = CreateGraphics();
            //G.SmoothingMode = SmoothingMode.HighQuality;

            if (Text.Length == 0)
                return;

            DrawTextSize = Measure(Text,Font,rectangle);
            DrawTextPoint = new Point(rectangle.Width / 2 - DrawTextSize.Width / 2, Header / 2 - DrawTextSize.Height / 2);

            switch (a)
            {
                case HorizontalAlignment.Left:
                    graphics.DrawString(Text, Font, b1, x, DrawTextPoint.Y + y);
                    break;
                case HorizontalAlignment.Center:
                    graphics.DrawString(Text, Font, b1, DrawTextPoint.X + x, DrawTextPoint.Y + y);
                    break;
                case HorizontalAlignment.Right:
                    graphics.DrawString(Text, Font, b1, rectangle.Width - DrawTextSize.Width - x, DrawTextPoint.Y + y);
                    break;
            }
        }

        /// <summary>
        /// Draw Text
        /// </summary>
        /// <param name="graphics">Set Graphics</param>
        /// <param name="b1">Set Brush</param>
        /// <param name="p1">Set Pen</param>
        /// <param name="Text">Set Text</param>
        /// <param name="Font">Set Font</param>
        public static void DrawText(
            this System.Drawing.Graphics graphics,
            Brush b1, 
            Point p1, 
            string Text, 
            Font Font)
        {
            
            if (Text.Length == 0)
                return;
            graphics.DrawString(Text, Font, b1, p1);
        }

        /// <summary>
        /// Draw Text
        /// </summary>
        /// <param name="graphics">Set Graphics</param>
        /// <param name="b1">Set Brush</param>
        /// <param name="x">Set X</param>
        /// <param name="y">Set Y</param>
        /// <param name="Text">Set Text</param>
        /// <param name="Font">Set Font</param>
        public static void DrawText(this System.Drawing.Graphics graphics,Brush b1, int x, int y, string Text, Font Font)
        {
            
            if (Text.Length == 0)
                return;
            graphics.DrawString(Text, Font, b1, x, y);
        }

        /// <summary>
        /// Draws the shadowed text.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="Text">The text.</param>
        /// <param name="Font">The font.</param>
        /// <param name="Color">The color.</param>
        /// <param name="XOffset">The x offset.</param>
        /// <param name="YOffset">The y offset.</param>
        /// <param name="StringFormat">The string format.</param>
        public static void DrawShadowedText(this System.Drawing.Graphics G, string Text, Font Font, Brush Color, int XOffset, int YOffset, StringFormat StringFormat)
        {
            
            G.DrawString(Text, Font, Color, XOffset, YOffset, StringFormat);

            G.DrawString(Text, Font, Color, 0, 0, StringFormat);
        }

        /// <summary>
        /// Draws the shadowed text.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="Text">The text.</param>
        /// <param name="Font">The font.</param>
        /// <param name="Brush">The brush.</param>
        /// <param name="Position">The position.</param>
        /// <param name="ShadowColor">Color of the shadow.</param>
        public static void DrawShadowedText(this System.Drawing.Graphics G, string Text, Font Font, Brush Brush, Point Position, Color ShadowColor)
        {
            G.DrawString(Text, Font, new SolidBrush(ShadowColor), new Point(Position.X + 1, Position.Y + 1));
            G.DrawString(Text, Font, Brush, Position);
        }



        /// <summary>
        /// Render Drop shadow on text
        /// </summary>
        /// <param name="graphics">Graphics class usage</param>
        /// <param name="text">Text to display</param>
        /// <param name="font">Font to use</param>
        /// <param name="foreground">Foreground color</param>
        /// <param name="shadow">Color of the shadow</param>
        /// <param name="shadowAlpha">Depth of the shadow</param>
        /// <param name="location">Location of the shadow</param>
        public static void DrawShadowedText(
            System.Drawing.Graphics graphics, string text, Font font, Color foreground, Color shadow,
            int shadowAlpha, PointF location)
        {
            const int DISTANCE = 2;
            for (int offset = 1; 0 <= offset; offset--)
            {
                Color color = ((offset < 1) ?
                    foreground : Color.FromArgb(shadowAlpha, shadow));
                using (var brush = new SolidBrush(color))
                {
                    var point = new PointF()
                    {
                        X = location.X + (offset * DISTANCE),
                        Y = location.Y + (offset * DISTANCE)
                    };
                    graphics.DrawString(text, font, brush, point);

                }


            }
        }

        /// <summary>
        /// Render Drop shadow on text (Updated)
        /// </summary>
        /// <param name="graphics">Graphics class usage</param>
        /// <param name="text">Text to display</param>
        /// <param name="font">Font to use</param>
        /// <param name="foreground">Foreground color</param>
        /// <param name="shadow">Color of the shadow</param>
        /// <param name="shadowAlpha">Depth of the shadow</param>
        /// <param name="location">Location of the shadow</param>
        public static void DrawShadowedTextUpdate(
            this System.Drawing.Graphics graphics, string text, Font font, Color foreground, Color shadow,
            int shadowAlpha, PointF location)
        {
            const int DISTANCE = 2;
            for (int offset = 1; 0 <= offset; offset--)
            {
                Color color = ((offset < 1) ?
                    foreground : Color.FromArgb(shadowAlpha, shadow));
                using (var brush = new SolidBrush(color))
                {
                    var point = new PointF()
                    {
                        X = location.X + (offset * DISTANCE),
                        Y = location.Y + (offset * DISTANCE)
                    };

                    //graphics.DrawString(text, font, brush, point);

                    if (offset > 0)
                    {
                        using (var blurBrush = new SolidBrush(Color.FromArgb((shadowAlpha / 2), color)))
                        {
                            graphics.DrawString(text, font, blurBrush, (point.X + 1), point.Y);
                            graphics.DrawString(text, font, blurBrush, (point.X - 1), point.Y);
                        }
                    }
                }


            }
        }

        /// <summary>
        /// Render drop shadow on text using path.
        /// </summary>
        /// <param name="graphics">Graphics class to use</param>
        /// <param name="pathShadow">Shadow path</param>
        public static void DrawShadowedText(
            this System.Drawing.Graphics graphics, GraphicsPath pathShadow)
        {
            using (PathGradientBrush brush = new PathGradientBrush(pathShadow))
            {
                ColorBlend blend = new ColorBlend();
                blend.Colors = new Color[] { Color.Transparent, Color.Black };
                blend.Positions = new float[] { 0.0f, 1.0f };
                brush.InterpolationColors = blend;
                graphics.FillPath(brush, pathShadow);
            }
        }

        /// <summary>
        /// Enum DimensionToIncrease
        /// </summary>
        public enum DimensionToIncrease
        {
            /// <summary>
            /// The width
            /// </summary>
            Width,
            /// <summary>
            /// The height
            /// </summary>
            Height,
            /// <summary>
            /// The both
            /// </summary>
            Both
        }

        /// <summary>
        /// Increases the size of control text changed.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="Text">The text.</param>
        /// <param name="Font">The font.</param>
        /// <param name="Dimension">The dimension.</param>
        /// <param name="size">The size.</param>
        /// <exception cref="ArgumentOutOfRangeException">Dimension - null</exception>
        public static void IncreaseSizeOFControlTextChanged(Control control,string Text, Font Font, DimensionToIncrease Dimension, int size)
        {
            switch (Dimension)
            {
                case DimensionToIncrease.Width:
                    control.Width = TextRenderer.MeasureText(Text, Font).Width + size;
                    break;
                case DimensionToIncrease.Height:
                    control.Height = TextRenderer.MeasureText(Text, Font).Height + size;
                    break;
                case DimensionToIncrease.Both:
                    control.Width = TextRenderer.MeasureText(Text, Font).Width + size;
                    control.Height = TextRenderer.MeasureText(Text, Font).Width + size;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(Dimension), Dimension, null);
            }
            

        }

        /// <summary>
        /// Creates the string format.
        /// </summary>
        /// <param name="ctl">The control.</param>
        /// <param name="textAlign">The text align.</param>
        /// <param name="showEllipsis">if set to <c>true</c> [show ellipsis].</param>
        /// <returns>StringFormat.</returns>
        public static StringFormat CreateStringFormat(Control ctl, ContentAlignment textAlign, bool showEllipsis)
        {
            StringFormat stringFormat = StringFormatForAlignment(textAlign);
            if (ctl.RightToLeft == RightToLeft.Yes)
            {
                stringFormat.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
            }
            if (showEllipsis)
            {
                stringFormat.Trimming = StringTrimming.EllipsisCharacter;
                stringFormat.FormatFlags |= StringFormatFlags.LineLimit;
            }
            if (ctl.AutoSize)
            {
                stringFormat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
            }
            return stringFormat;
        }

        /// <summary>
        /// Strings the format for alignment.
        /// </summary>
        /// <param name="align">The align.</param>
        /// <returns>StringFormat.</returns>
        public static StringFormat StringFormatForAlignment(System.Drawing.ContentAlignment align)
        {
            return new StringFormat
            {
                Alignment = TranslateAlignment(align),
                LineAlignment = TranslateLineAlignment(align)
            };
        }

        /// <summary>
        /// Translates the line alignment for GDI.
        /// </summary>
        /// <param name="align">The align.</param>
        /// <returns>TextFormatFlags.</returns>
        public static TextFormatFlags TranslateLineAlignmentForGDI(System.Drawing.ContentAlignment align)
        {
            TextFormatFlags result;
            // disable once BitwiseOperatorOnEnumWithoutFlags
            if ((align & anyRight) != (System.Drawing.ContentAlignment)0)
            {
                result = TextFormatFlags.Right;
            }
            else
            {
                // disable once BitwiseOperatorOnEnumWithoutFlags
                if ((align & anyCenter) != (System.Drawing.ContentAlignment)0)
                {
                    result = TextFormatFlags.HorizontalCenter;
                }
                else
                {
                    result = TextFormatFlags.Default;
                }
            }
            return result;
        }

        /// <summary>
        /// Translates the alignment.
        /// </summary>
        /// <param name="align">The align.</param>
        /// <returns>StringAlignment.</returns>
        internal static StringAlignment TranslateAlignment(System.Drawing.ContentAlignment align)
        {
            StringAlignment result;
            // disable once BitwiseOperatorOnEnumWithoutFlags
            if ((align & anyRight) != (System.Drawing.ContentAlignment)0)
            {
                result = StringAlignment.Far;
            }
            else
            {
                // disable once BitwiseOperatorOnEnumWithoutFlags
                if ((align & anyCenter) != (System.Drawing.ContentAlignment)0)
                {
                    result = StringAlignment.Center;
                }
                else
                {
                    result = StringAlignment.Near;
                }
            }
            return result;
        }

        /// <summary>
        /// Translates the line alignment.
        /// </summary>
        /// <param name="align">The align.</param>
        /// <returns>StringAlignment.</returns>
        internal static StringAlignment TranslateLineAlignment(System.Drawing.ContentAlignment align)
        {
            StringAlignment result;
            if ((align & anyBottom) != (System.Drawing.ContentAlignment)0)
            {
                result = StringAlignment.Far;
            }
            else
            {
                if ((align & anyMiddle) != (System.Drawing.ContentAlignment)0)
                {
                    result = StringAlignment.Center;
                }
                else
                {
                    result = StringAlignment.Near;
                }
            }
            return result;
        }


        #endregion

        #region Measure Text

        /// <summary>
        /// The measure bitmap
        /// </summary>
        private static System.Drawing.Bitmap MeasureBitmap;

        /// <summary>
        /// The measure graphics
        /// </summary>
        private static System.Drawing.Graphics MeasureGraphics;

        /// <summary>
        /// Measures the specified text.
        /// </summary>
        /// <param name="Text">The text.</param>
        /// <param name="Font">The font.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns>Size.</returns>
        private static  Size Measure(string Text,Font Font, Rectangle rectangle)
        {
            lock (MeasureGraphics)
            {
                return MeasureGraphics.MeasureString(Text, Font, rectangle.Width).ToSize();
            }
        }

        /// <summary>
        /// Measures the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="text">The text.</param>
        /// <param name="Font">The font.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns>Size.</returns>
        private static Size Measure(System.Drawing.Graphics graphics, string text, Font Font, Rectangle rectangle)
        {
            MeasureGraphics = graphics;
            lock (MeasureGraphics)
            {
                return MeasureGraphics.MeasureString(text, Font, rectangle.Width).ToSize();
            }
        }

        #endregion


    }
}
