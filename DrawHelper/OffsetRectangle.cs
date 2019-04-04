// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="OffsetRectangle.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing
{

    /// <summary>
    /// Class DrawRenderer.
    /// </summary>
    public static partial class DrawRenderer
    {

        /// <summary>
        /// Fills the offset rectangle.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="r">The r.</param>
        /// <param name="color">The color.</param>
        /// <param name="thin">The thin.</param>
        /// <param name="offsetSize">Size of the offset.</param>
        public static void FillOffsetRectangle(this System.Drawing.Graphics G, Rectangle r, List<List<Color>> color, float thin, int offsetSize = 5)
        {

            foreach (List<Color> colors in color)
            {
                foreach (Color colorr in colors)
                {
                    for (int i = 0; i < colors.Count; i++)
                    {

                        G.FillRectangle(new SolidBrush(colors[i]), new RectangleF(r.X /*+ offsetSize*/ + (colors.Count + thin * (i)), r.Y /*+ offsetSize*/ + (colors.Count + thin * i), r.Width - (offsetSize * 2) - (colors.Count + thin * (i * 2)), r.Height - (offsetSize * 2) - (colors.Count + thin * (i * 2))));

                    }
                }

            }

        }

        /// <summary>
        /// Draws the offset rectangle.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="r">The r.</param>
        /// <param name="color">The color.</param>
        /// <param name="borderWidth">Width of the border.</param>
        /// <param name="thin">The thin.</param>
        /// <param name="offsetSize">Size of the offset.</param>
        public static void DrawOffsetRectangle(this System.Drawing.Graphics G, Rectangle r, List<List<Color>> color, float borderWidth, float thin, int offsetSize = 5)
        {

            foreach (List<Color> colors in color)
            {
                foreach (Color colorr in colors)
                {
                    for (int i = 0; i < colors.Count; i++)
                    {

                        G.DrawRectangle(new Pen(colors[i], borderWidth), r.X /*+ offsetSize*/ + (colors.Count + thin * (i)), r.Y /*+ offsetSize*/ + (colors.Count + thin * i), r.Width - (offsetSize * 2) - (colors.Count + thin * (i * 2)), r.Height - (offsetSize * 2) - (colors.Count + thin * (i * 2)));

                    }
                }

            }
        }

        /// <summary>
        /// Fills the offset ellipse.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="r">The r.</param>
        /// <param name="color">The color.</param>
        /// <param name="thin">The thin.</param>
        /// <param name="offsetSize">Size of the offset.</param>
        public static void FillOffsetEllipse(this System.Drawing.Graphics G, Rectangle r, List<List<Color>> color, float thin, int offsetSize = 5)
        {

            foreach (List<Color> colors in color)
            {
                foreach (Color colorr in colors)
                {
                    for (int i = 0; i < colors.Count; i++)
                    {

                        G.FillEllipse(new SolidBrush(colors[i]), new RectangleF(r.X /*+ offsetSize*/ + (colors.Count + thin * (i)), r.Y /*+ offsetSize*/ + (colors.Count + thin * i), r.Width - (offsetSize * 2) - (colors.Count + thin * (i * 2)), r.Height - (offsetSize * 2) - (colors.Count + thin * (i * 2))));

                    }
                }

            }
        }

        /// <summary>
        /// Draws the offset ellipse.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="r">The r.</param>
        /// <param name="color">The color.</param>
        /// <param name="borderWidth">Width of the border.</param>
        /// <param name="thin">The thin.</param>
        /// <param name="offsetSize">Size of the offset.</param>
        public static void DrawOffsetEllipse(this System.Drawing.Graphics G, Rectangle r, List<List<Color>> color, float borderWidth, float thin, int offsetSize = 5)
        {

            foreach (List<Color> colors in color)
            {
                foreach (Color colorr in colors)
                {
                    for (int i = 0; i < colors.Count; i++)
                    {

                        G.DrawEllipse(new Pen(colors[i], borderWidth), r.X /*+ offsetSize*/ + (colors.Count + thin * (i)), r.Y /*+ offsetSize*/ + (colors.Count + thin * i), r.Width - (offsetSize * 2) - (colors.Count + thin * (i * 2)), r.Height - (offsetSize * 2) - (colors.Count + thin * (i * 2)));

                    }
                }

            }

        }

        /// <summary>
        /// Fills the offset rectangle random.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="r">The r.</param>
        /// <param name="color">The color.</param>
        /// <param name="thin">The thin.</param>
        /// <param name="offsetSize">Size of the offset.</param>
        public static void FillOffsetRectangleRandom(System.Drawing.Graphics G, Rectangle r, List<List<Color>> color, float thin, int offsetSize = 5)
        {

            foreach (List<Color> colors in color)
            {
                foreach (Color colorr in colors)
                {
                    for (int i = 0; i < colors.Count; i++)
                    {

                        Random random = new Random();
                        random.Next(0, colors.Count - 1);
                        G.FillRectangle(new SolidBrush(colors[random.Next(i, colors.Count - 1)]), new RectangleF(r.X /*+ offsetSize*/ + (colors.Count + thin * (i)), r.Y /*+ offsetSize*/ + (colors.Count + thin * i), r.Width - (offsetSize * 2) - (colors.Count + thin * (i * 2)), r.Height - (offsetSize * 2) - (colors.Count + thin * (i * 2))));

                    }
                }

            }
        }

        /// <summary>
        /// Draws the offset rectangle random.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="r">The r.</param>
        /// <param name="color">The color.</param>
        /// <param name="borderWidth">Width of the border.</param>
        /// <param name="thin">The thin.</param>
        /// <param name="offsetSize">Size of the offset.</param>
        public static void DrawOffsetRectangleRandom(this System.Drawing.Graphics G, Rectangle r, List<List<Color>> color, float borderWidth, float thin, int offsetSize = 5)
        {

            foreach (List<Color> colors in color)
            {
                foreach (Color colorr in colors)
                {
                    for (int i = 0; i < colors.Count; i++)
                    {
                        Random random = new Random();
                        random.Next(0, colors.Count - 1);

                        G.DrawRectangle(new Pen(colors[random.Next(i, colors.Count - 1)], borderWidth), r.X /*+ offsetSize*/ + (colors.Count + thin * (i)), r.Y /*+ offsetSize*/ + (colors.Count + thin * i), r.Width - (offsetSize * 2) - (colors.Count + thin * (i * 2)), r.Height - (offsetSize * 2) - (colors.Count + thin * (i * 2)));

                    }
                }

            }
        }

        /// <summary>
        /// Fills the offset ellipse random.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="r">The r.</param>
        /// <param name="color">The color.</param>
        /// <param name="thin">The thin.</param>
        /// <param name="offsetSize">Size of the offset.</param>
        public static void FillOffsetEllipseRandom(System.Drawing.Graphics G, Rectangle r, List<List<Color>> color, float thin, int offsetSize = 5)
        {

            foreach (List<Color> colors in color)
            {
                foreach (Color colorr in colors)
                {
                    for (int i = 0; i < colors.Count; i++)
                    {

                        Random random = new Random();
                        random.Next(0, colors.Count - 1);
                        G.FillEllipse(new SolidBrush(colors[random.Next(i, colors.Count - 1)]), new RectangleF(r.X /*+ offsetSize*/ + (colors.Count + thin * (i)), r.Y /*+ offsetSize*/ + (colors.Count + thin * i), r.Width - (offsetSize * 2) - (colors.Count + thin * (i * 2)), r.Height - (offsetSize * 2) - (colors.Count + thin * (i * 2))));

                    }
                }

            }
        }

        /// <summary>
        /// Draws the offset ellipse random.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="r">The r.</param>
        /// <param name="color">The color.</param>
        /// <param name="borderWidth">Width of the border.</param>
        /// <param name="thin">The thin.</param>
        /// <param name="offsetSize">Size of the offset.</param>
        public static void DrawOffsetEllipseRandom(this System.Drawing.Graphics G, Rectangle r, List<List<Color>> color, float borderWidth, float thin, int offsetSize = 5)
        {

            foreach (List<Color> colors in color)
            {
                foreach (Color colorr in colors)
                {
                    for (int i = 0; i < colors.Count; i++)
                    {
                        Random random = new Random();
                        random.Next(0, colors.Count - 1);

                        G.DrawEllipse(new Pen(colors[random.Next(i, colors.Count - 1)], borderWidth), r.X /*+ offsetSize*/ + (colors.Count + thin * (i)), r.Y /*+ offsetSize*/ + (colors.Count + thin * i), r.Width - (offsetSize * 2) - (colors.Count + thin * (i * 2)), r.Height - (offsetSize * 2) - (colors.Count + thin * (i * 2)));

                    }
                }

            }
        }


        /// <summary>
        /// Offsets the rect original code.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="r">The r.</param>
        /// <param name="color">The color.</param>
        /// <param name="thin">The thin.</param>
        /// <param name="offsetSize">Size of the offset.</param>
        private static void OffsetRectOriginalCode(System.Drawing.Graphics G, Rectangle r, List<List<Color>> color, float thin, int offsetSize = 5)
        {

            foreach (List<Color> colors in color)
            {
                foreach (Color colorr in colors)
                {
                    for (int i = 0; i < colors.Count; i++)
                    {

                        G.FillRectangle(new SolidBrush(colors[i]), new RectangleF(r.X + offsetSize + (colors.Count * i), r.Y + offsetSize + (colors.Count * i), r.Width - (offsetSize * 2) - (colors.Count * (i * 2)), r.Height - (offsetSize * 2) - (colors.Count * (i * 2))));

                    }
                }

            }
        }

        /// <summary>
        /// Offsets the rectangle.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="r">The r.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="NumberOfOfssets">The number of ofssets.</param>
        /// <param name="offsetSize">Size of the offset.</param>
        private static void OffsetRectangle(this System.Drawing.Graphics G, Rectangle r, Brush brush, int NumberOfOfssets, int offsetSize)
        {
            switch (NumberOfOfssets)
            {
                case 0:
                    G.FillRectangle(brush, new Rectangle(r.X, r.Y, r.Width, r.Height));
                    G.DrawRectangle(Pens.Black, new Rectangle(r.X, r.Y, r.Width, r.Height));

                    break;
                case 1:
                    G.FillRectangle(brush, new Rectangle(r.X + offsetSize, r.Y + offsetSize, r.Width - (offsetSize * 2), r.Height - (offsetSize * 2)));
                    G.DrawRectangle(Pens.Black, new Rectangle(r.X + offsetSize, r.Y + offsetSize, r.Width - (offsetSize * 2), r.Height - (offsetSize * 2)));

                    break;
                case 2:
                    G.FillRectangle(brush, new Rectangle(r.X + offsetSize, r.Y + offsetSize, r.Width - (offsetSize * 2), r.Height - (offsetSize * 2)));
                    G.FillRectangle(brush, new Rectangle(r.X + offsetSize + NumberOfOfssets, r.Y + offsetSize + NumberOfOfssets, r.Width - (offsetSize * 2) - NumberOfOfssets * 2, r.Height - (offsetSize * 2) - NumberOfOfssets * 2));

                    G.DrawRectangle(Pens.Black, new Rectangle(r.X + offsetSize, r.Y + offsetSize, r.Width - (offsetSize * 2), r.Height - (offsetSize * 2)));
                    G.DrawRectangle(Pens.Black, new Rectangle(r.X + offsetSize + NumberOfOfssets, r.Y + offsetSize + NumberOfOfssets, r.Width - (offsetSize * 2) - NumberOfOfssets * 2, r.Height - (offsetSize * 2) - NumberOfOfssets * 2));


                    break;
                case 3:
                    G.FillRectangle(brush, new Rectangle(r.X + offsetSize, r.Y + offsetSize, r.Width - (offsetSize * 2), r.Height - (offsetSize * 2)));
                    G.FillRectangle(brush, new Rectangle(r.X + offsetSize + NumberOfOfssets, r.Y + offsetSize + NumberOfOfssets, r.Width - (offsetSize * 2) - NumberOfOfssets * 2, r.Height - (offsetSize * 2) - NumberOfOfssets * 2));
                    G.FillRectangle(brush, new Rectangle(r.X + offsetSize + (NumberOfOfssets * 2), r.Y + offsetSize + (NumberOfOfssets * 2), r.Width - (offsetSize * 2) - (NumberOfOfssets * 4), r.Height - (offsetSize * 2) - (NumberOfOfssets * 4)));

                    G.DrawRectangle(Pens.Black, new Rectangle(r.X + offsetSize, r.Y + offsetSize, r.Width - (offsetSize * 2), r.Height - (offsetSize * 2)));
                    G.DrawRectangle(Pens.Black, new Rectangle(r.X + offsetSize + NumberOfOfssets, r.Y + offsetSize + NumberOfOfssets, r.Width - (offsetSize * 2) - NumberOfOfssets * 2, r.Height - (offsetSize * 2) - NumberOfOfssets * 2));
                    G.DrawRectangle(Pens.Black, new Rectangle(r.X + offsetSize + (NumberOfOfssets * 2), r.Y + offsetSize + (NumberOfOfssets * 2), r.Width - (offsetSize * 2) - (NumberOfOfssets * 4), r.Height - (offsetSize * 2) - (NumberOfOfssets * 4)));


                    break;
                case 4:
                    G.FillRectangle(brush, new Rectangle(r.X + offsetSize, r.Y + offsetSize, r.Width - (offsetSize * 2), r.Height - (offsetSize * 2)));
                    G.FillRectangle(brush, new Rectangle(r.X + offsetSize + NumberOfOfssets, r.Y + offsetSize + NumberOfOfssets, r.Width - (offsetSize * 2) - NumberOfOfssets * 2, r.Height - (offsetSize * 2) - NumberOfOfssets * 2));
                    G.FillRectangle(brush, new Rectangle(r.X + offsetSize + (NumberOfOfssets * 2), r.Y + offsetSize + (NumberOfOfssets * 2), r.Width - (offsetSize * 2) - (NumberOfOfssets * 4), r.Height - (offsetSize * 2) - (NumberOfOfssets * 4)));
                    G.FillRectangle(brush, new Rectangle(r.X + offsetSize + (NumberOfOfssets * 3), r.Y + offsetSize + (NumberOfOfssets * 3), r.Width - (offsetSize * 2) - (NumberOfOfssets * 6), r.Height - (offsetSize * 2) - (NumberOfOfssets * 6)));

                    G.DrawRectangle(Pens.Black, new Rectangle(r.X + offsetSize, r.Y + offsetSize, r.Width - (offsetSize * 2), r.Height - (offsetSize * 2)));
                    G.DrawRectangle(Pens.Black, new Rectangle(r.X + offsetSize + NumberOfOfssets, r.Y + offsetSize + NumberOfOfssets, r.Width - (offsetSize * 2) - NumberOfOfssets * 2, r.Height - (offsetSize * 2) - NumberOfOfssets * 2));
                    G.DrawRectangle(Pens.Black, new Rectangle(r.X + offsetSize + (NumberOfOfssets * 2), r.Y + offsetSize + (NumberOfOfssets * 2), r.Width - (offsetSize * 2) - (NumberOfOfssets * 4), r.Height - (offsetSize * 2) - (NumberOfOfssets * 4)));
                    G.DrawRectangle(Pens.Black, new Rectangle(r.X + offsetSize + (NumberOfOfssets * 3), r.Y + offsetSize + (NumberOfOfssets * 3), r.Width - (offsetSize * 2) - (NumberOfOfssets * 6), r.Height - (offsetSize * 2) - (NumberOfOfssets * 6)));


                    break;
                case 5:
                    G.FillRectangle(brush, new Rectangle(r.X + offsetSize, r.Y + offsetSize, r.Width - (offsetSize * 2), r.Height - (offsetSize * 2)));
                    G.FillRectangle(brush, new Rectangle(r.X + offsetSize + NumberOfOfssets, r.Y + offsetSize + NumberOfOfssets, r.Width - (offsetSize * 2) - NumberOfOfssets * 2, r.Height - (offsetSize * 2) - NumberOfOfssets * 2));
                    G.FillRectangle(brush, new Rectangle(r.X + offsetSize + (NumberOfOfssets * 2), r.Y + offsetSize + (NumberOfOfssets * 2), r.Width - (offsetSize * 2) - (NumberOfOfssets * 4), r.Height - (offsetSize * 2) - (NumberOfOfssets * 4)));
                    G.FillRectangle(brush, new Rectangle(r.X + offsetSize + (NumberOfOfssets * 3), r.Y + offsetSize + (NumberOfOfssets * 3), r.Width - (offsetSize * 2) - (NumberOfOfssets * 6), r.Height - (offsetSize * 2) - (NumberOfOfssets * 6)));
                    G.FillRectangle(brush, new Rectangle(r.X + offsetSize + (NumberOfOfssets * 4), r.Y + offsetSize + (NumberOfOfssets * 4), r.Width - (offsetSize * 2) - (NumberOfOfssets * 8), r.Height - (offsetSize * 2) - (NumberOfOfssets * 8)));


                    G.DrawRectangle(Pens.Black, new Rectangle(r.X + offsetSize, r.Y + offsetSize, r.Width - (offsetSize * 2), r.Height - (offsetSize * 2)));
                    G.DrawRectangle(Pens.Black, new Rectangle(r.X + offsetSize + NumberOfOfssets, r.Y + offsetSize + NumberOfOfssets, r.Width - (offsetSize * 2) - NumberOfOfssets * 2, r.Height - (offsetSize * 2) - NumberOfOfssets * 2));
                    G.DrawRectangle(Pens.Black, new Rectangle(r.X + offsetSize + (NumberOfOfssets * 2), r.Y + offsetSize + (NumberOfOfssets * 2), r.Width - (offsetSize * 2) - (NumberOfOfssets * 4), r.Height - (offsetSize * 2) - (NumberOfOfssets * 4)));
                    G.DrawRectangle(Pens.Black, new Rectangle(r.X + offsetSize + (NumberOfOfssets * 3), r.Y + offsetSize + (NumberOfOfssets * 3), r.Width - (offsetSize * 2) - (NumberOfOfssets * 6), r.Height - (offsetSize * 2) - (NumberOfOfssets * 6)));
                    G.DrawRectangle(Pens.Black, new Rectangle(r.X + offsetSize + (NumberOfOfssets * 4), r.Y + offsetSize + (NumberOfOfssets * 4), r.Width - (offsetSize * 2) - (NumberOfOfssets * 8), r.Height - (offsetSize * 2) - (NumberOfOfssets * 8)));

                    break;

                default:
                    break;

            }


        }

        /// <summary>
        /// Offsets the rect old working code.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="r">The r.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="NumberOfOfssets">The number of ofssets.</param>
        /// <param name="offsetSize">Size of the offset.</param>
        private static void OffsetRectOldWorkingCode(System.Drawing.Graphics G, Rectangle r, Brush brush, int NumberOfOfssets, int offsetSize)
        {
            switch (NumberOfOfssets)
            {
                case 0:
                    G.FillRectangle(brush, new Rectangle(r.X, r.Y, r.Width, r.Height));

                    G.DrawRectangle(Pens.Black, new Rectangle(r.X, r.Y, r.Width, r.Height));

                    break;
                case 1:
                    G.FillRectangle(brush, new Rectangle(r.X + offsetSize, r.Y + offsetSize, r.Width - (offsetSize * 2), r.Height - (offsetSize * 2)));

                    G.DrawRectangle(Pens.Black, new Rectangle(r.X + offsetSize, r.Y + offsetSize, r.Width - (offsetSize * 2), r.Height - (offsetSize * 2)));

                    break;
                case 2:
                    G.FillRectangle(brush, new Rectangle(r.X + offsetSize, r.Y + offsetSize, r.Width - (offsetSize * 2), r.Height - (offsetSize * 2)));
                    G.FillRectangle(brush, new Rectangle(r.X + offsetSize + NumberOfOfssets, r.Y + offsetSize + NumberOfOfssets, r.Width - (offsetSize * 2) - NumberOfOfssets * 2, r.Height - (offsetSize * 2) - NumberOfOfssets * 2));

                    G.DrawRectangle(Pens.Black, new Rectangle(r.X + offsetSize, r.Y + offsetSize, r.Width - (offsetSize * 2), r.Height - (offsetSize * 2)));
                    G.DrawRectangle(Pens.Black, new Rectangle(r.X + offsetSize + NumberOfOfssets, r.Y + offsetSize + NumberOfOfssets, r.Width - (offsetSize * 2) - NumberOfOfssets * 2, r.Height - (offsetSize * 2) - NumberOfOfssets * 2));

                    break;
                case 3:
                    G.FillRectangle(brush, new Rectangle(r.X + offsetSize, r.Y + offsetSize, r.Width - (offsetSize * 2), r.Height - (offsetSize * 2)));
                    G.FillRectangle(brush, new Rectangle(r.X + offsetSize + NumberOfOfssets, r.Y + offsetSize + NumberOfOfssets, r.Width - (offsetSize * 2) - NumberOfOfssets * 2, r.Height - (offsetSize * 2) - NumberOfOfssets * 2));
                    G.FillRectangle(brush, new Rectangle(r.X + offsetSize + (NumberOfOfssets * 2), r.Y + offsetSize + (NumberOfOfssets * 2), r.Width - (offsetSize * 2) - (NumberOfOfssets * 4), r.Height - (offsetSize * 2) - (NumberOfOfssets * 4)));

                    G.DrawRectangle(Pens.Black, new Rectangle(r.X + offsetSize, r.Y + offsetSize, r.Width - (offsetSize * 2), r.Height - (offsetSize * 2)));
                    G.DrawRectangle(Pens.Black, new Rectangle(r.X + offsetSize + NumberOfOfssets, r.Y + offsetSize + NumberOfOfssets, r.Width - (offsetSize * 2) - NumberOfOfssets * 2, r.Height - (offsetSize * 2) - NumberOfOfssets * 2));
                    G.DrawRectangle(Pens.Black, new Rectangle(r.X + offsetSize + (NumberOfOfssets * 2), r.Y + offsetSize + (NumberOfOfssets * 2), r.Width - (offsetSize * 2) - (NumberOfOfssets * 4), r.Height - (offsetSize * 2) - (NumberOfOfssets * 4)));

                    break;
                case 4:
                    G.FillRectangle(brush, new Rectangle(r.X + offsetSize, r.Y + offsetSize, r.Width - (offsetSize * 2), r.Height - (offsetSize * 2)));
                    G.FillRectangle(brush, new Rectangle(r.X + offsetSize + NumberOfOfssets, r.Y + offsetSize + NumberOfOfssets, r.Width - (offsetSize * 2) - NumberOfOfssets * 2, r.Height - (offsetSize * 2) - NumberOfOfssets * 2));
                    G.FillRectangle(brush, new Rectangle(r.X + offsetSize + (NumberOfOfssets * 2), r.Y + offsetSize + (NumberOfOfssets * 2), r.Width - (offsetSize * 2) - (NumberOfOfssets * 4), r.Height - (offsetSize * 2) - (NumberOfOfssets * 4)));
                    G.FillRectangle(brush, new Rectangle(r.X + offsetSize + (NumberOfOfssets * 3), r.Y + offsetSize + (NumberOfOfssets * 3), r.Width - (offsetSize * 2) - (NumberOfOfssets * 6), r.Height - (offsetSize * 2) - (NumberOfOfssets * 6)));

                    G.DrawRectangle(Pens.Black, new Rectangle(r.X + offsetSize, r.Y + offsetSize, r.Width - (offsetSize * 2), r.Height - (offsetSize * 2)));
                    G.DrawRectangle(Pens.Black, new Rectangle(r.X + offsetSize + NumberOfOfssets, r.Y + offsetSize + NumberOfOfssets, r.Width - (offsetSize * 2) - NumberOfOfssets * 2, r.Height - (offsetSize * 2) - NumberOfOfssets * 2));
                    G.DrawRectangle(Pens.Black, new Rectangle(r.X + offsetSize + (NumberOfOfssets * 2), r.Y + offsetSize + (NumberOfOfssets * 2), r.Width - (offsetSize * 2) - (NumberOfOfssets * 4), r.Height - (offsetSize * 2) - (NumberOfOfssets * 4)));
                    G.DrawRectangle(Pens.Black, new Rectangle(r.X + offsetSize + (NumberOfOfssets * 3), r.Y + offsetSize + (NumberOfOfssets * 3), r.Width - (offsetSize * 2) - (NumberOfOfssets * 6), r.Height - (offsetSize * 2) - (NumberOfOfssets * 6)));

                    break;
                case 5:
                    G.FillRectangle(brush, new Rectangle(r.X + offsetSize, r.Y + offsetSize, r.Width - (offsetSize * 2), r.Height - (offsetSize * 2)));
                    G.FillRectangle(brush, new Rectangle(r.X + offsetSize + NumberOfOfssets, r.Y + offsetSize + NumberOfOfssets, r.Width - (offsetSize * 2) - NumberOfOfssets * 2, r.Height - (offsetSize * 2) - NumberOfOfssets * 2));
                    G.FillRectangle(brush, new Rectangle(r.X + offsetSize + (NumberOfOfssets * 2), r.Y + offsetSize + (NumberOfOfssets * 2), r.Width - (offsetSize * 2) - (NumberOfOfssets * 4), r.Height - (offsetSize * 2) - (NumberOfOfssets * 4)));
                    G.FillRectangle(brush, new Rectangle(r.X + offsetSize + (NumberOfOfssets * 3), r.Y + offsetSize + (NumberOfOfssets * 3), r.Width - (offsetSize * 2) - (NumberOfOfssets * 6), r.Height - (offsetSize * 2) - (NumberOfOfssets * 6)));
                    G.FillRectangle(brush, new Rectangle(r.X + offsetSize + (NumberOfOfssets * 4), r.Y + offsetSize + (NumberOfOfssets * 4), r.Width - (offsetSize * 2) - (NumberOfOfssets * 8), r.Height - (offsetSize * 2) - (NumberOfOfssets * 8)));

                    G.DrawRectangle(Pens.Black, new Rectangle(r.X + offsetSize, r.Y + offsetSize, r.Width - (offsetSize * 2), r.Height - (offsetSize * 2)));
                    G.DrawRectangle(Pens.Black, new Rectangle(r.X + offsetSize + NumberOfOfssets, r.Y + offsetSize + NumberOfOfssets, r.Width - (offsetSize * 2) - NumberOfOfssets * 2, r.Height - (offsetSize * 2) - NumberOfOfssets * 2));
                    G.DrawRectangle(Pens.Black, new Rectangle(r.X + offsetSize + (NumberOfOfssets * 2), r.Y + offsetSize + (NumberOfOfssets * 2), r.Width - (offsetSize * 2) - (NumberOfOfssets * 4), r.Height - (offsetSize * 2) - (NumberOfOfssets * 4)));
                    G.DrawRectangle(Pens.Black, new Rectangle(r.X + offsetSize + (NumberOfOfssets * 3), r.Y + offsetSize + (NumberOfOfssets * 3), r.Width - (offsetSize * 2) - (NumberOfOfssets * 6), r.Height - (offsetSize * 2) - (NumberOfOfssets * 6)));
                    G.DrawRectangle(Pens.Black, new Rectangle(r.X + offsetSize + (NumberOfOfssets * 4), r.Y + offsetSize + (NumberOfOfssets * 4), r.Width - (offsetSize * 2) - (NumberOfOfssets * 8), r.Height - (offsetSize * 2) - (NumberOfOfssets * 8)));

                    break;

                default:
                    break;

            }


        }



    }
}
