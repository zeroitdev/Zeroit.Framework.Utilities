// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Smoothness.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.GraphicsExtension.BitmapUtils
{
    /// <summary>
    /// Class with extensions for Graphics objects
    /// </summary>
    public static partial class BitmapManipulation
    {

        #region Smoothness

        /// <summary>
        /// Draws an image with 20% smoothed corners (gradient to transparency)
        /// </summary>
        /// <param name="g">The Graphics object</param>
        /// <param name="image">The image to smoothen</param>
        /// <param name="destination">The destination rectangle of the image</param>
        public static void DrawImageSmooth(this System.Drawing.Graphics g, Image image, RectangleF destination)
        {
            g.DrawImageSmooth(image, new RectangleF(Point.Empty, image.Size), destination, (AnchorStyles)15, 0.2f);
        }

        /// <summary>
        /// Draws an image with smoothed corners (gradient to transparency)
        /// </summary>
        /// <param name="g">The Graphics object</param>
        /// <param name="image">The image to smoothen</param>
        /// <param name="destination">The destination rectangle of the image</param>
        /// <param name="smoothness">The smoothness in percent (0 = none to 1.0 = complete gradient)</param>
        public static void DrawImageSmooth(this System.Drawing.Graphics g, Image image, RectangleF destination, float smoothness)
        {
            g.DrawImageSmooth(image, new RectangleF(Point.Empty, image.Size), destination, (AnchorStyles)15, smoothness);
        }

        /// <summary>
        /// Draws an image with smoothed corners (gradient to transparency)
        /// </summary>
        /// <param name="g">The Graphics object</param>
        /// <param name="image">The image to smoothen</param>
        /// <param name="destination">The destination rectangle of the image</param>
        /// <param name="sides">The sides of the image to smoothen (bitflag enumeration)</param>
        /// <param name="smoothness">The smoothness in percent (0 = none to 1.0 = complete gradient)</param>
        public static void DrawImageSmooth(this System.Drawing.Graphics g, Image image, RectangleF destination, AnchorStyles sides, float smoothness)
        {
            g.DrawImageSmooth(image, new RectangleF(Point.Empty, image.Size), destination, sides, smoothness);
        }

        /// <summary>
        /// Draws an image with smoothed corners (gradient to transparency)
        /// </summary>
        /// <param name="g">The Graphics object</param>
        /// <param name="image">The image to smoothen</param>
        /// <param name="destination">The top-left point where the image should be placed</param>
        /// <param name="sides">The sides of the image to smoothen (bitflag enumeration)</param>
        /// <param name="smoothness">The smoothness in percent (0 = none to 1.0 = complete gradient)</param>
        public static void DrawImageSmooth(this System.Drawing.Graphics g, Image image, PointF destination, AnchorStyles sides, float smoothness)
        {
            g.DrawImageSmooth(image, new RectangleF(Point.Empty, image.Size), new RectangleF(destination, image.Size), sides, smoothness);
        }

        /// <summary>
        /// Draws an image with smoothed corners (gradient to transparency)
        /// </summary>
        /// <param name="g">The Graphics object</param>
        /// <param name="image">The image to smoothen</param>
        /// <param name="source">The source rectangle of the image (from where to take?)</param>
        /// <param name="destination">The destination rectangle of the image (where to place?)</param>
        /// <param name="sides">The sides of the image to smoothen (bitflag enumeration)</param>
        /// <param name="smoothness">The smoothness in percent (0 = none to 1.0 = complete gradient)</param>
        public static void DrawImageSmooth(this System.Drawing.Graphics g, Image image, RectangleF source, RectangleF destination, AnchorStyles sides, float smoothness)
        {
            var innerSource = source;
            var s = (int)(Math.Min(source.Width, source.Height) * Math.Min(0.5f, smoothness / 2f));
            var tmp = new Bitmap((int)source.Width, (int)source.Height);
            var gt = System.Drawing.Graphics.FromImage(tmp);

            var left = false;
            var right = false;
            var top = false;
            var bottom = false;

            if ((AnchorStyles.Top & sides) == AnchorStyles.Top)
            {
                top = true;
                innerSource.Y += s;
                innerSource.Height -= s;
            }

            if ((AnchorStyles.Bottom & sides) == AnchorStyles.Bottom)
            {
                bottom = true;
                innerSource.Height -= s;
            }

            if ((AnchorStyles.Left & sides) == AnchorStyles.Left)
            {
                left = true;
                innerSource.X += s;
                innerSource.Width -= s;
            }

            if ((AnchorStyles.Right & sides) == AnchorStyles.Right)
            {
                right = true;
                innerSource.Width -= s;
            }

            var innerRect = new Rectangle((int)(innerSource.X - source.X), (int)(innerSource.Y - source.Y), (int)innerSource.Width, (int)innerSource.Height);
            var topRect = top ? new RectangleF(source.X, source.Y, source.Width, s) : RectangleF.Empty;
            var leftRect = left ? new RectangleF(source.X, source.Y, s, source.Height) : RectangleF.Empty;
            var bottomRect = bottom ? new RectangleF(source.X, source.Bottom - s, source.Width, s) : RectangleF.Empty;
            var rightRect = right ? new RectangleF(source.Right - s, source.Y, s, source.Height) : RectangleF.Empty;

            //Draw Center
            gt.DrawImage(image, innerRect, innerSource, GraphicsUnit.Pixel);

            //Draw Top Left Corner
            if (topRect.IntersectsWith(leftRect))
            {
                var corner = topRect;
                corner.Intersect(leftRect);
                topRect.X += corner.Width;
                topRect.Width -= corner.Width;
                leftRect.Y += corner.Height;
                leftRect.Height -= corner.Height;
                DrawCorner(gt, image, source, corner, s, AnchorStyles.Top | AnchorStyles.Left);
            }

            //Draw Top Right Corner
            if (topRect.IntersectsWith(rightRect))
            {
                var corner = topRect;
                corner.Intersect(rightRect);
                topRect.Width -= corner.Width;
                rightRect.Y += corner.Height;
                rightRect.Height -= corner.Height;
                DrawCorner(gt, image, source, corner, s, AnchorStyles.Top | AnchorStyles.Right);
            }

            //Draw Bottom Left Corner
            if (bottomRect.IntersectsWith(leftRect))
            {
                var corner = bottomRect;
                corner.Intersect(leftRect);
                bottomRect.X += corner.Width;
                bottomRect.Width -= corner.Width;
                leftRect.Height -= corner.Height;
                DrawCorner(gt, image, source, corner, s, AnchorStyles.Bottom | AnchorStyles.Left);
            }

            //Draw Bottom Right Corner
            if (bottomRect.IntersectsWith(rightRect))
            {
                var corner = bottomRect;
                corner.Intersect(rightRect);
                bottomRect.Width -= corner.Width;
                rightRect.Height -= corner.Height;
                DrawCorner(gt, image, source, corner, s, AnchorStyles.Bottom | AnchorStyles.Right);
            }

            //Draw Left Side
            if (left)
                DrawSide(gt, image, source, leftRect, s, AnchorStyles.Left);

            //Draw Right Side
            if (right)
                DrawSide(gt, image, source, rightRect, s, AnchorStyles.Right);

            //Draw Top Side
            if (top)
                DrawSide(gt, image, source, topRect, s, AnchorStyles.Top);

            //Draw Bottom Side
            if (bottom)
                DrawSide(gt, image, source, bottomRect, s, AnchorStyles.Bottom);

            g.DrawImage(tmp, destination);
        }

        #region Helpers

        /// <summary>
        /// Draws the corner.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="image">The image.</param>
        /// <param name="destSource">The dest source.</param>
        /// <param name="src">The source.</param>
        /// <param name="smoothness">The smoothness.</param>
        /// <param name="corner">The corner.</param>
        static void DrawCorner(System.Drawing.Graphics g, Image image, RectangleF destSource, RectangleF src, float smoothness, AnchorStyles corner)
        {
            var dest = new RectangleF(src.X - destSource.X, src.Y - destSource.Y, src.Width, src.Height);
            var ia = new ImageAttributes();
            var cm = new ColorMatrix();
            var left = (AnchorStyles.Left & corner) == AnchorStyles.Left;
            var top = (AnchorStyles.Top & corner) == AnchorStyles.Top;
            var s = Math.Ceiling(smoothness);

            /* NEW CODE --- not working yet*/
            /*
            var b = new Bitmap((int)dest.Width, (int)dest.Height);
            var r = new Rectangle(0, 0, (int)src.Width, (int)src.Height);
            Graphics.FromImage(b).DrawImage(image, r, );
            var data = b.LockBits(r, ImageLockMode.ReadWrite, b.PixelFormat);
            var ptr = data.Scan0;
            var bytes = Math.Abs(data.Stride) * b.Height;
            var values = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(ptr, values, 0, bytes);
            var i = 3;

            for (var x = 0; x < b.Width; x++)
            {
                for (var y = 0; y < b.Height; y++)
                {
                    var xr = Math.Min((x + 1) / s, 1.0);
                    var yr = Math.Min((y + 1) / s, 1.0);
                    var sq = (float)Math.Max(1.0 - Math.Sqrt(xr * xr + yr * yr), 0.0);
                    values[i] = (byte)(255f * sq);
                    i += 4;
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(values, 0, ptr, bytes);
            b.UnlockBits(data);

            g.DrawImage(b, dest, src, GraphicsUnit.Pixel);
            */

            for (var x = 0; x < dest.Width; x++)
            {
                for (var y = 0; y < dest.Height; y++)
                {
                    var xr = Math.Min((x + 1) / s, 1.0);
                    var yr = Math.Min((y + 1) / s, 1.0);
                    var r = Math.Sqrt(xr * xr + yr * yr);

                    if (r > 1.0)
                        continue;

                    var d = new Rectangle((int)(left ? dest.Right - x - 1 : dest.Left + x), (int)(top ? dest.Bottom - y - 1 : dest.Top + y), 1, 1);
                    cm.Matrix33 = 1f - (float)r;
                    ia.SetColorMatrix(cm);
                    g.DrawImage(image, d, left ? src.Right - x - 1 : src.Left + x, top ? src.Bottom - y - 1 : src.Top + y, 1, 1, GraphicsUnit.Pixel, ia);
                }
            }
        }

        /// <summary>
        /// Draws the side.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="image">The image.</param>
        /// <param name="destSource">The dest source.</param>
        /// <param name="src">The source.</param>
        /// <param name="smoothness">The smoothness.</param>
        /// <param name="side">The side.</param>
        static void DrawSide(System.Drawing.Graphics g, Image image, RectangleF destSource, RectangleF src, float smoothness, AnchorStyles side)
        {
            var dest = new RectangleF(src.X - destSource.X, src.Y - destSource.Y, src.Width, src.Height);
            var ia = new ImageAttributes();
            var cm = new ColorMatrix();
            var rest = (float)Math.Ceiling(smoothness);
            var take = 1f;
            var inv = ((AnchorStyles.Bottom & side) == AnchorStyles.Bottom) || ((AnchorStyles.Right & side) == AnchorStyles.Right);
            var top = ((AnchorStyles.Bottom & side) == AnchorStyles.Bottom) || ((AnchorStyles.Top & side) == AnchorStyles.Top);

            while (rest > 0f)
            {
                take = Math.Min(1f, rest);
                rest -= take;
                var d = new Rectangle((int)Math.Floor(dest.X + (top ? 0f : rest)), (int)Math.Floor(dest.Y + (top ? rest : 0f)),
                                        (int)Math.Ceiling(top ? dest.Width : take), (int)Math.Ceiling(top ? take : dest.Height));
                cm.Matrix33 = inv ? 1f - Math.Max(0f, rest / smoothness) : Math.Max(0f, rest / smoothness);
                ia.SetColorMatrix(cm);
                g.DrawImage(image, d,
                    src.X + (top ? 0f : rest), src.Y + (top ? rest : 0f), top ? src.Width : 1f, top ? 1f : src.Height,
                    GraphicsUnit.Pixel, ia);
            }
        }

        #endregion

        #endregion
    }
}
