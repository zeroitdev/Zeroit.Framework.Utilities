// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ImageToIcon.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.Utilities.BitmapUtils.Imaging
{
    /// <summary>
    /// A class collection for Image to Icon
    /// </summary>
    public static class ImageToIcon
    {
        /// <summary>
        /// Argb Copy
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap Format32bppArgbCopy(this System.Drawing.Bitmap sourceBitmap)
        {
            System.Drawing.Bitmap copyBitmap = new System.Drawing.Bitmap(sourceBitmap.Width, sourceBitmap.Height, PixelFormat.Format32bppArgb);

            using (System.Drawing.Graphics graphicsObject = System.Drawing.Graphics.FromImage(copyBitmap))
            {
                graphicsObject.CompositingQuality = CompositingQuality.HighQuality;
                graphicsObject.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsObject.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphicsObject.SmoothingMode = SmoothingMode.HighQuality;

                graphicsObject.DrawImage(sourceBitmap, 
                new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), 
                new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), GraphicsUnit.Pixel);
            }

            return copyBitmap;
        }

        /// <summary>
        /// Copy to canvas
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="canvasBackground">Set canvas Background</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap CopyToSquareCanvas(this System.Drawing.Bitmap sourceBitmap, Color canvasBackground)
        {
            int maxSide = sourceBitmap.Width > sourceBitmap.Height ? sourceBitmap.Width : sourceBitmap.Height;

            System.Drawing.Bitmap bitmapResult = new System.Drawing.Bitmap(maxSide, maxSide, PixelFormat.Format32bppArgb);

            using (System.Drawing.Graphics graphicsResult = System.Drawing.Graphics.FromImage(bitmapResult))
            {
                graphicsResult.Clear(canvasBackground);

                int xOffset = (sourceBitmap.Width - maxSide) / 2;
                int yOffset = (sourceBitmap.Height - maxSide) / 2;

                graphicsResult.DrawImage(sourceBitmap, new Point(xOffset, xOffset));
            }

            return bitmapResult;
        }

        /// <summary>
        /// Create Icon
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="iconSize">Set icon size</param>
        /// <returns></returns>
        public static Icon CreateIcon(this System.Drawing.Bitmap sourceBitmap, IconSizeDimensions iconSize)
        {
            System.Drawing.Bitmap squareCanvas = sourceBitmap.CopyToSquareCanvas(Color.Transparent);
            squareCanvas = (System.Drawing.Bitmap)squareCanvas.GetThumbnailImage((int)iconSize, (int)iconSize, null, new IntPtr());

            Icon iconResult = Icon.FromHandle(squareCanvas.GetHicon());

            return iconResult;
        }
    }

    /// <summary>
    /// Icon Size Dimensions
    /// </summary>
    public enum IconSizeDimensions
    {
        IconSize16x16Pixels = 16,
        IconSize24x24Pixels = 24,
        IconSize32x32Pixels = 32,
        IconSize48x48Pixels = 48,
        IconSize64x64Pixels = 64,
        IconSize96x96Pixels = 96,
        IconSize128x128Pixels = 128
    }
}
