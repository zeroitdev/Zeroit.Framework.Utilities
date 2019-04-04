// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="ShadowUtils.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using static System.Math;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing
{
    /// <summary>
    /// Class ShadowUtils.
    /// </summary>
    public static class ShadowUtils
    {

        /// <summary>
        /// The channels
        /// </summary>
        const int CHANNELS = 4;

        /// <summary>
        /// Interface IShadowController
        /// </summary>
        public interface IShadowController
        {
            /// <summary>
            /// Shoulds the show shadow.
            /// </summary>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            bool ShouldShowShadow();
        }

        /// <summary>
        /// Enum RenderSide
        /// </summary>
        enum RenderSide
        {
            /// <summary>
            /// The top
            /// </summary>
            Top,
            /// <summary>
            /// The bottom
            /// </summary>
            Bottom,
            /// <summary>
            /// The left
            /// </summary>
            Left,
            /// <summary>
            /// The right
            /// </summary>
            Right
        }

        /// <summary>
        /// The visible top
        /// </summary>
        static RenderSide[] VisibleTop = { RenderSide.Bottom/*, RenderSide.Top*/ };
        /// <summary>
        /// The visible bottom
        /// </summary>
        static RenderSide[] VisibleBottom = { RenderSide.Top/*, RenderSide.Bottom*/ };
        /// <summary>
        /// The visible left
        /// </summary>
        static RenderSide[] VisibleLeft = { RenderSide.Right };
        /// <summary>
        /// The visible right
        /// </summary>
        static RenderSide[] VisibleRight = { RenderSide.Left };

        /// <summary>
        /// Determines whether the specified side is visible.
        /// </summary>
        /// <param name="side">The side.</param>
        /// <param name="st">The st.</param>
        /// <returns><c>true</c> if the specified side is visible; otherwise, <c>false</c>.</returns>
        static bool IsVisible(RenderSide side, DockStyle st)
        {
            switch (st) {
                case DockStyle.Top:
                    return VisibleTop.Contains(side);
                case DockStyle.Bottom:
                    return VisibleBottom.Contains(side);
                case DockStyle.Left:
                    return VisibleLeft.Contains(side);
                case DockStyle.Right:
                    return VisibleRight.Contains(side);
                case DockStyle.Fill:
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Draws the shadow.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="c">The c.</param>
        /// <param name="r">The r.</param>
        /// <param name="d">The d.</param>
        /// <param name="st">The st.</param>
        public static void DrawShadow(this System.Drawing.Graphics G, Color c, Rectangle r, int d, DockStyle st = DockStyle.None)
        {
            Color[] colors = GetColorVector(c, d).ToArray();

            if (IsVisible(RenderSide.Top, st))
                for (int i = 1; i < d; i++) {
                    //TOP
                    using (Pen pen = new Pen(colors[i], 1f))
                        G.DrawLine(pen, new Point(r.Left - Max(i - 1, 0), r.Top - i), new Point(r.Right + Max(i - 1, 0), r.Top - i));
                }

            if (IsVisible(RenderSide.Bottom, st))
                for (int i = 0; i < d; i++) {
                    //BOTTOM
                    using (Pen pen = new Pen(colors[i], 1f))
                        G.DrawLine(pen, new Point(r.Left - Max(i - 1, 0), r.Bottom + i), new Point(r.Right + i, r.Bottom + i));
                }
            if (IsVisible(RenderSide.Left, st))
                for (int i = 1; i < d; i++) {
                    //LEFT
                    using (Pen pen = new Pen(colors[i], 1f))
                        G.DrawLine(pen, new Point(r.Left - i, r.Top - i), new Point(r.Left - i, r.Bottom + i));
                }
            if (IsVisible(RenderSide.Right, st))
                for (int i = 0; i < d; i++) {
                    //RIGHT
                    using (Pen pen = new Pen(colors[i], 1f))
                        G.DrawLine(pen, new Point(r.Right + i, r.Top - i), new Point(r.Right + i, r.Bottom + Max(i - 1, 0)));
                }
        }

        /// <summary>
        /// Draws the shadow.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="GP">The gp.</param>
        /// <param name="d">The d.</param>
        /// <param name="pBackColor">Color of the p back.</param>
        public static void DrawShadow(this System.Drawing.Graphics G, GraphicsPath GP, int d, Color pBackColor)
        {
            Color[] colors = getColorVector(Color.Black, pBackColor, d).ToArray();
            for (int i = 0; i < d; i++)
            {
                G.TranslateTransform(1f, 0.75f);                // <== shadow vector!
                using (Pen pen = new Pen(colors[i], 1.75f))  // <== pen width (*)
                    G.DrawPath(pen, GP);
            }
            G.ResetTransform();
        }

        //Code taken and adapted from StackOverflow (https://stackoverflow.com/a/13653167).
        //All credits go to Marino Šimić (https://stackoverflow.com/users/610204/marino-%c5%a0imi%c4%87).
        /// <summary>
        /// Draws the outset shadow.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="shadowColor">Color of the shadow.</param>
        /// <param name="hShadow">The h shadow.</param>
        /// <param name="vShadow">The v shadow.</param>
        /// <param name="blur">The blur.</param>
        /// <param name="spread">The spread.</param>
        /// <param name="control">The control.</param>
        public static void DrawOutsetShadow(this System.Drawing.Graphics g, Color shadowColor, int hShadow, int vShadow, int blur, int spread, Control control)
        {
            var rOuter = Rectangle.Inflate(control.Bounds, blur / 2, blur / 2);
            var rInner = Rectangle.Inflate(control.Bounds, blur / 2, blur / 2);
            //rInner.Offset(hShadow, vShadow);
            rInner.Inflate(-blur, -blur);
            rOuter.Inflate(spread, spread);
            //rOuter.Offset(hShadow, vShadow);
            var originalOuter = rOuter;

            var img = new Bitmap(originalOuter.Width, originalOuter.Height, g);
            var g2 = System.Drawing.Graphics.FromImage(img);

            var currentBlur = 0;

            do {
                var transparency = (rOuter.Height - rInner.Height) / (double)(blur * 2 + spread * 2);
                var color = Color.FromArgb(((int)(200 * (transparency * transparency))), shadowColor);
                var rOutput = rInner;
                rOutput.Offset(-originalOuter.Left, -originalOuter.Top);
                g2.DrawRoundedRectangle(rOutput, 5, Pens.Transparent, color);
                rInner.Inflate(1, 1);
                currentBlur = (int)((double)blur * (1 - (transparency * transparency)));
            } while (rOuter.Contains(rInner));

            g2.Flush();
            g2.Dispose();

            g.DrawImage(img, originalOuter);

            img.Dispose();
        }

        /// <summary>
        /// Draws a shadow around a defined path.
        /// </summary>
        /// <param name="g">The current Graphics handle.</param>
        /// <param name="path">The path which should have a shadow.</param>
        /// <param name="color">The color of the shadow.</param>
        /// <param name="dx">The horizontal shift.</param>
        /// <param name="dy">The vertical shift.</param>
        /// <param name="blur">The blurness.</param>
        public static void DrawShadow(this System.Drawing.Graphics g, GraphicsPath path, Color color, float dx, float dy, float blur)
        {
            var bounds = path.GetBounds();
            var bpw = blur / (float)bounds.Width / 2f;
            var bph = blur / (float)bounds.Height / 2f;
            var tdx = -(float)bounds.Left - (float)bounds.Width / 2f;
            var tdy = -(float)bounds.Top - (float)bounds.Height / 2f;
            path.Transform(new Matrix(1f, 0f, 0f, 1f, tdx, tdy));
            Region original = new Region(path);
            path.Transform(new Matrix(1f + bpw, 0f, 0f, 1f + bph, dx, dy));
            Region transform = new Region(path);
            transform.Exclude(original);

            var gs = g.Save();
            g.TranslateTransform(-tdx, -tdy);

            if (blur <= 0f)
            {
                g.FillRegion(new SolidBrush(color), transform);
            }
            else
            {
                var lgb = new PathGradientBrush(path);
                lgb.CenterColor = color;
                lgb.SurroundColors = new Color[] { Color.Transparent };
                var colors = new Color[3];
                var positions = new float[3];

                for (var i = 0; i < 3; i++)
                {
                    colors[i] = Color.FromArgb(255 * (2 - i) / 2, color);
                    positions[i] = (2f - i) / 2f;
                }

                lgb.InterpolationColors.Colors = colors;
                lgb.InterpolationColors.Positions = positions;
                g.FillRegion(lgb, transform);
            }

            g.Restore(gs);
        }

        /// <summary>
        /// Draws a shadow around a rectangle.
        /// </summary>
        /// <param name="g">The current Graphics handle.</param>
        /// <param name="path">The path which should have a shadow.</param>
        /// <param name="color">The color of the shadow.</param>
        /// <param name="shift">The horizontal and vertical shift.</param>
        /// <param name="blur">The blurness.</param>
        public static void DrawShadow(this System.Drawing.Graphics g, GraphicsPath path, Color color, PointF shift, float blur)
        {
            g.DrawShadow(path, color, shift.X, shift.Y, blur);
        }

        /// <summary>
        /// Draws the shadow on circle.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="color">The color.</param>
        /// <param name="shadow">The shadow.</param>
        /// <returns>Graphics.</returns>
        public static Graphics DrawShadowOnCircle(this Graphics g, Rectangle rectangle, Color color, Color shadow)
        {

            //Color shadow = Color.FromArgb(255, 16, 16, 16);

            for (int i = 0; i < 8; i++)
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(80 - i * 10, shadow)))
                {
                    g.FillEllipse(brush, rectangle.X + i * 2,
                        rectangle.Y + i, rectangle.Width, rectangle.Height);
                }
            using (SolidBrush brush = new SolidBrush(color))
                g.FillEllipse(brush, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);

            // move to the right to use the same coordinates again for the drawn shape
            g.TranslateTransform(80, 0);

            for (int i = 0; i < 8; i++)
                using (Pen pen = new Pen(Color.FromArgb(80 - i * 10, shadow), 2.5f))
                {
                    g.DrawEllipse(pen, rectangle.X + i * 1.25f,
                        rectangle.Y + i, rectangle.Width, rectangle.Height);
                }
            using (Pen pen = new Pen(color))
                g.DrawEllipse(pen, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);

            return g;
        }

        /// <summary>
        /// Draws a shadow around a rectangle.
        /// </summary>
        /// <param name="g">The current Graphics handle.</param>
        /// <param name="origin">The rectangle which should have a shadow.</param>
        /// <param name="color">The color of the shadow.</param>
        /// <param name="dx">The horizontal shift.</param>
        /// <param name="dy">The vertical shift.</param>
        /// <param name="blur">The blurness.</param>
        public static void DrawRectangularShadow(this System.Drawing.Graphics g, RectangleF origin, Color color, float dx, float dy, float blur)
        {
            var gp = new GraphicsPath();
            gp.AddRectangle(origin);

            if (gp.PointCount > 0)
                g.DrawShadow(gp, color, dx, dy, blur);
        }

        /// <summary>
        /// Draws a shadow around a rectangle.
        /// </summary>
        /// <param name="g">The current Graphics handle.</param>
        /// <param name="origin">The rectangle which should have a shadow.</param>
        /// <param name="color">The color of the shadow.</param>
        /// <param name="shift">The horizontal and vertical shift.</param>
        /// <param name="blur">The blurness.</param>
        public static void DrawRectangularShadow(this System.Drawing.Graphics g, RectangleF origin, Color color, PointF shift, float blur)
        {
            g.DrawRectangularShadow(origin, color, shift.X, shift.Y, blur);
        }

        /// <summary>
        /// Draws a shadow around a rectangle.
        /// </summary>
        /// <param name="g">The current Graphics handle.</param>
        /// <param name="origin">The rectangle which should have a shadow.</param>
        /// <param name="color">The color of the shadow.</param>
        /// <param name="dx">The horizontal shift.</param>
        /// <param name="dy">The vertical shift.</param>
        /// <param name="blur">The blurness.</param>
        public static void DrawCircularShadow(this System.Drawing.Graphics g, RectangleF origin, Color color, float dx, float dy, float blur)
        {
            var gp = new GraphicsPath();
            gp.AddEllipse(origin);

            if (gp.PointCount > 0)
                g.DrawShadow(gp, color, dx, dy, blur);
        }

        /// <summary>
        /// Draws a shadow around a rectangle.
        /// </summary>
        /// <param name="g">The current Graphics handle.</param>
        /// <param name="origin">The rectangle which should have a shadow.</param>
        /// <param name="color">The color of the shadow.</param>
        /// <param name="shift">The horizontal and vertical shift.</param>
        /// <param name="blur">The blurness.</param>
        public static void DrawCircularShadow(this System.Drawing.Graphics g, RectangleF origin, Color color, PointF shift, float blur)
        {
            g.DrawCircularShadow(origin, color, shift.X, shift.Y, blur);
        }

        /// <summary>
        /// Draws a shadow around a rectangle.
        /// </summary>
        /// <param name="g">The current Graphics handle.</param>
        /// <param name="origin">The rectangle which should have a shadow.</param>
        /// <param name="startAngle">The start angle.</param>
        /// <param name="sweepAngle">The sweep angle.</param>
        /// <param name="color">The color of the shadow.</param>
        /// <param name="dx">The horizontal shift.</param>
        /// <param name="dy">The vertical shift.</param>
        /// <param name="blur">The blurness.</param>
        public static void DrawPieShadow(this System.Drawing.Graphics g, Rectangle origin, float startAngle, float sweepAngle, Color color, float dx, float dy, float blur)
        {
            var gp = new GraphicsPath();
            gp.AddPie(origin, startAngle, sweepAngle);

            if (gp.PointCount > 0)
                g.DrawShadow(gp, color, dx, dy, blur);
        }

        /// <summary>
        /// Draws a shadow around a rectangle.
        /// </summary>
        /// <param name="g">The current Graphics handle.</param>
        /// <param name="origin">The rectangle which should have a shadow.</param>
        /// <param name="startAngle">The start angle.</param>
        /// <param name="sweepAngle">The sweep angle.</param>
        /// <param name="color">The color of the shadow.</param>
        /// <param name="shift">The horizontal and vertical shift.</param>
        /// <param name="blur">The blurness.</param>
        public static void DrawPieShadow(this System.Drawing.Graphics g, Rectangle origin, float startAngle, float sweepAngle, Color color, PointF shift, float blur)
        {
            g.DrawPieShadow(origin, startAngle, sweepAngle, color, shift.X, shift.Y, blur);
        }

        /// <summary>
        /// Creates the drop shadow.
        /// </summary>
        /// <param name="ctrl">The control.</param>
        public static void CreateDropShadow(this Control ctrl)
        {
            if (ctrl.Parent != null) {
                ctrl.Parent.Paint += (s, e) => {
                    if (ctrl.Parent != null && ctrl.Visible && (!(ctrl is IShadowController) || ((IShadowController)ctrl).ShouldShowShadow()))
                        DrawShadow(e.Graphics, Color.Black, ctrl.Bounds, 7, ctrl.Dock);
                };
            }
        }

        /// <summary>
        /// Creates the out set shadow.
        /// </summary>
        /// <param name="ctrl">The control.</param>
        /// <param name="hShadow">The h shadow.</param>
        /// <param name="vShadow">The v shadow.</param>
        /// <param name="blur">The blur.</param>
        /// <param name="spread">The spread.</param>
        public static void CreateOutSetShadow(this Control ctrl, int hShadow, int vShadow, int blur, int spread )
        {
            if (ctrl.Parent != null)
            {
                ctrl.Parent.Paint += (s, e) =>
                {
                    if (ctrl.Parent != null && ctrl.Visible &&
                        (!(ctrl is IShadowController) || ((IShadowController) ctrl).ShouldShowShadow()))
                        e.Graphics.DrawOutsetShadow(Color.Black, hShadow, vShadow, blur, spread, ctrl);
                        
                };
            }
        }

        /// <summary>
        /// Creates the shadow.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="opacity">The opacity.</param>
        /// <returns>Bitmap.</returns>
        public static Bitmap CreateShadow(this Bitmap bitmap, int radius, float opacity)
        {
            // Alpha mask with opacity
            var matrix = new ColorMatrix(new float[][] {
            new float[] {  0F,  0F,  0F, 0F,      0F },
            new float[] {  0F,  0F,  0F, 0F,      0F },
            new float[] {  0F,  0F,  0F, 0F,      0F },
            new float[] { -1F, -1F, -1F, opacity, 0F },
            new float[] {  1F,  1F,  1F, 0F,      1F }
        });

            var imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            var shadow = new Bitmap(bitmap.Width + 4 * radius, bitmap.Height + 4 * radius);
            using (var graphics = Graphics.FromImage(shadow))
                graphics.DrawImage(bitmap, new Rectangle(2 * radius, 2 * radius, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, imageAttributes);

            // Gaussian blur
            var clone = shadow.Clone() as Bitmap;
            var shadowData = shadow.LockBits(new Rectangle(0, 0, shadow.Width, shadow.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            var cloneData = clone.LockBits(new Rectangle(0, 0, clone.Width, clone.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            var boxes = DetermineBoxes(radius, 3);
            BoxBlur(shadowData, cloneData, shadow.Width, shadow.Height, (boxes[0] - 1) / 2);
            BoxBlur(shadowData, cloneData, shadow.Width, shadow.Height, (boxes[1] - 1) / 2);
            BoxBlur(shadowData, cloneData, shadow.Width, shadow.Height, (boxes[2] - 1) / 2);

            shadow.UnlockBits(shadowData);
            clone.UnlockBits(cloneData);
            return shadow;
        }

        /// <summary>
        /// Gets the color vector.
        /// </summary>
        /// <param name="fc">The fc.</param>
        /// <param name="bc">The bc.</param>
        /// <param name="depth">The depth.</param>
        /// <returns>List&lt;Color&gt;.</returns>
        private static List<Color> getColorVector(Color fc, Color bc, int depth)
        {
            List<Color> cv = new List<Color>();
            float dRed = 1f * (bc.R - fc.R) / depth;
            float dGreen = 1f * (bc.G - fc.G) / depth;
            float dBlue = 1f * (bc.B - fc.B) / depth;
            for (int d = 1; d <= depth; d++)
                cv.Add(Color.FromArgb(60, (int)(fc.R + dRed * d),
                    (int)(fc.G + dGreen * d), (int)(fc.B + dBlue * d)));
            return cv;
        }

        //Code taken and adapted from https://stackoverflow.com/a/25741405
        //All credits go to TaW (https://stackoverflow.com/users/3152130/taw)
        /// <summary>
        /// Gets the color vector.
        /// </summary>
        /// <param name="fc">The fc.</param>
        /// <param name="depth">The depth.</param>
        /// <returns>List&lt;Color&gt;.</returns>
        static List<Color> GetColorVector(Color fc, int depth)
        {
            List<Color> cv = new List<Color>();
            int baseC = 65;
            float div = baseC / depth;
            for (int d = 1; d <= depth; d++)
            {
                cv.Add(Color.FromArgb(Max(0, baseC), fc));
                baseC -= (int)div;
            }
            return cv;
        }

        //Code taken and adapted from https://stackoverflow.com/a/25741405
        //All credits go to TaW (https://stackoverflow.com/users/3152130/taw)
        /// <summary>
        /// Gets the rect path.
        /// </summary>
        /// <param name="R">The r.</param>
        /// <returns>GraphicsPath.</returns>
        static GraphicsPath GetRectPath(Rectangle R)
        {
            byte[] fm = new byte[3];
            for (int b = 0; b < 3; b++) fm[b] = 1;
            List<Point> points = new List<Point>
            {
                new Point(R.Left, R.Bottom),
                new Point(R.Right, R.Bottom),
                new Point(R.Right, R.Top)
            };
            return new GraphicsPath(points.ToArray(), fm);
        }

        /// <summary>
        /// Boxes the blur.
        /// </summary>
        /// <param name="data1">The data1.</param>
        /// <param name="data2">The data2.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="radius">The radius.</param>
        private static unsafe void BoxBlur(BitmapData data1, BitmapData data2, int width, int height, int radius)
        {
            byte* p1 = (byte*)(void*)data1.Scan0;
            byte* p2 = (byte*)(void*)data2.Scan0;

            int radius2 = 2 * radius + 1;
            int[] sum = new int[CHANNELS];
            int[] FirstValue = new int[CHANNELS];
            int[] LastValue = new int[CHANNELS];

            // Horizontal
            int stride = data1.Stride;
            for (var row = 0; row < height; row++)
            {
                int start = row * stride;
                int left = start;
                int right = start + radius * CHANNELS;

                for (int channel = 0; channel < CHANNELS; channel++)
                {
                    FirstValue[channel] = p1[start + channel];
                    LastValue[channel] = p1[start + (width - 1) * CHANNELS + channel];
                    sum[channel] = (radius + 1) * FirstValue[channel];
                }
                for (var column = 0; column < radius; column++)
                    for (int channel = 0; channel < CHANNELS; channel++)
                        sum[channel] += p1[start + column * CHANNELS + channel];
                for (var column = 0; column <= radius; column++, right += CHANNELS, start += CHANNELS)
                    for (int channel = 0; channel < CHANNELS; channel++)
                    {
                        sum[channel] += p1[right + channel] - FirstValue[channel];
                        p2[start + channel] = (byte)(sum[channel] / radius2);
                    }
                for (var column = radius + 1; column < width - radius; column++, left += CHANNELS, right += CHANNELS, start += CHANNELS)
                    for (int channel = 0; channel < CHANNELS; channel++)
                    {
                        sum[channel] += p1[right + channel] - p1[left + channel];
                        p2[start + channel] = (byte)(sum[channel] / radius2);
                    }
                for (var column = width - radius; column < width; column++, left += CHANNELS, start += CHANNELS)
                    for (int channel = 0; channel < CHANNELS; channel++)
                    {
                        sum[channel] += LastValue[channel] - p1[left + channel];
                        p2[start + channel] = (byte)(sum[channel] / radius2);
                    }
            }

            // Vertical
            stride = data2.Stride;
            for (int column = 0; column < width; column++)
            {
                int start = column * CHANNELS;
                int top = start;
                int bottom = start + radius * stride;

                for (int channel = 0; channel < CHANNELS; channel++)
                {
                    FirstValue[channel] = p2[start + channel];
                    LastValue[channel] = p2[start + (height - 1) * stride + channel];
                    sum[channel] = (radius + 1) * FirstValue[channel];
                }
                for (int row = 0; row < radius; row++)
                    for (int channel = 0; channel < CHANNELS; channel++)
                        sum[channel] += p2[start + row * stride + channel];
                for (int row = 0; row <= radius; row++, bottom += stride, start += stride)
                    for (int channel = 0; channel < CHANNELS; channel++)
                    {
                        sum[channel] += p2[bottom + channel] - FirstValue[channel];
                        p1[start + channel] = (byte)(sum[channel] / radius2);
                    }
                for (int row = radius + 1; row < height - radius; row++, top += stride, bottom += stride, start += stride)
                    for (int channel = 0; channel < CHANNELS; channel++)
                    {
                        sum[channel] += p2[bottom + channel] - p2[top + channel];
                        p1[start + channel] = (byte)(sum[channel] / radius2);
                    }
                for (int row = height - radius; row < height; row++, top += stride, start += stride)
                    for (int channel = 0; channel < CHANNELS; channel++)
                    {
                        sum[channel] += LastValue[channel] - p2[top + channel];
                        p1[start + channel] = (byte)(sum[channel] / radius2);
                    }
            }
        }

        /// <summary>
        /// Determines the boxes.
        /// </summary>
        /// <param name="Sigma">The sigma.</param>
        /// <param name="BoxCount">The box count.</param>
        /// <returns>System.Int32[].</returns>
        private static int[] DetermineBoxes(double Sigma, int BoxCount)
        {
            double IdealWidth = Math.Sqrt((12 * Sigma * Sigma / BoxCount) + 1);
            int Lower = (int)Math.Floor(IdealWidth);
            if (Lower % 2 == 0)
                Lower--;
            int Upper = Lower + 2;

            double MedianWidth = (12 * Sigma * Sigma - BoxCount * Lower * Lower - 4 * BoxCount * Lower - 3 * BoxCount) / (-4 * Lower - 4);
            int Median = (int)Math.Round(MedianWidth);

            int[] BoxSizes = new int[BoxCount];
            for (int i = 0; i < BoxCount; i++)
                BoxSizes[i] = (i < Median) ? Lower : Upper;
            return BoxSizes;
        }


    }

}
