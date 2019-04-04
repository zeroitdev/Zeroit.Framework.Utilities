// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="BitmapAdjuster.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.BitmapUtils
{

    /// <summary>
    /// Class BitmapAdjuster.
    /// </summary>
    public class BitmapAdjuster
    {
        #region Private Methods and Others

        /// <summary>
        /// Delegate PaletteAdjustEvent
        /// </summary>
        /// <param name="plt">The PLT.</param>
        /// <returns>ColorPalette.</returns>
        public delegate ColorPalette PaletteAdjustEvent(ColorPalette plt);

        /// <summary>
        /// Delegate ConvertScanLineEvent
        /// </summary>
        /// <param name="srcLine">The source line.</param>
        /// <param name="dstLine">The DST line.</param>
        /// <param name="width">The width.</param>
        /// <param name="srcPixBit">The source pix bit.</param>
        /// <param name="dstPixBit">The DST pix bit.</param>
        /// <param name="srcBmp">The source BMP.</param>
        /// <param name="dstBmp">The DST BMP.</param>
        public unsafe delegate void ConvertScanLineEvent(IntPtr srcLine, IntPtr dstLine, int width, int srcPixBit, int dstPixBit, System.Drawing.Bitmap srcBmp, System.Drawing.Bitmap dstBmp);

        /// <summary>
        /// The alpha
        /// </summary>
        private int alpha = 255;

        /// <summary>
        /// Initializes a new instance of the <see cref="BitmapAdjuster"/> class.
        /// </summary>
        public BitmapAdjuster()
        {

        }

        /// <summary>
        /// Adjusts the Bitmap
        /// </summary>
        /// <param name="alpha">The alpha.</param>
        public BitmapAdjuster(int alpha)
        {
            this.alpha = alpha;
        }

        /// <summary>
        /// Adjusts the color.
        /// </summary>
        /// <param name="bmp">The BMP.</param>
        /// <param name="format">The format.</param>
        /// <param name="PalleteAdjust">The pallete adjust.</param>
        /// <param name="ConvertScanLine">The convert scan line.</param>
        public void AdjustColor(ref System.Drawing.Bitmap bmp, PixelFormat format, PaletteAdjustEvent PalleteAdjust, ConvertScanLineEvent ConvertScanLine)
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Bitmap bmpOut = new System.Drawing.Bitmap(bmp.Width, bmp.Height, format);

            bmpOut.Palette = PalleteAdjust(bmpOut.Palette);

            PixelFormat srcFmt = bmp.PixelFormat;
            PixelFormat dstFmt = bmpOut.PixelFormat;
            int srcPixBit = GetPixelSize(srcFmt);
            int dstPixBit = GetPixelSize(dstFmt);

            BitmapData srcData = null;
            BitmapData dstData = null;
            try
            {
                srcData = bmp.LockBits(rect, ImageLockMode.ReadOnly, srcFmt);
                dstData = bmpOut.LockBits(rect, ImageLockMode.WriteOnly, dstFmt);

                unsafe
                {
                    byte* srcLine = (byte*)srcData.Scan0.ToPointer();
                    byte* dstLine = (byte*)dstData.Scan0.ToPointer();
                    for (int L = 0; L < srcData.Height; L++)
                    {
                        ConvertScanLine((IntPtr)srcLine, (IntPtr)dstLine, srcData.Width, srcPixBit, dstPixBit, bmp, bmpOut);

                        srcLine += srcData.Stride;
                        dstLine += dstData.Stride;
                    }
                }
            }
            finally
            {
                bmp.UnlockBits(srcData);
                bmpOut.UnlockBits(dstData);
            }

            bmp = bmpOut;
        }

        /// <summary>
        /// Gets the size of the pixel.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns>System.Int32.</returns>
        internal int GetPixelSize(PixelFormat format)
        {
            switch (format)
            {
                case PixelFormat.Format16bppRgb555: return 16;
                case PixelFormat.Format16bppRgb565: return 16;
                case PixelFormat.Format24bppRgb: return 24;
                case PixelFormat.Format32bppRgb: return 32;
                case PixelFormat.Format1bppIndexed: return 1;
                case PixelFormat.Format4bppIndexed: return 4;
                case PixelFormat.Format8bppIndexed: return 8;
                case PixelFormat.Format16bppArgb1555: return 16;
                case PixelFormat.Format32bppPArgb: return 32;
                case PixelFormat.Format16bppGrayScale: return 16;
                case PixelFormat.Format48bppRgb: return 48;
                case PixelFormat.Format64bppPArgb: return 64;
                case PixelFormat.Canonical: return 32;
                case PixelFormat.Format32bppArgb: return 32;
                case PixelFormat.Format64bppArgb: return 64;
            }
            return 0;
        }

        /// <summary>
        /// Monochromes the specified BMP.
        /// </summary>
        /// <param name="bmp">The BMP.</param>
        public unsafe void Monochrome(ref System.Drawing.Bitmap bmp)
        {
            AdjustColor(ref bmp, PixelFormat.Format1bppIndexed,
                new PaletteAdjustEvent(SetBlackWhitePallete),
                new ConvertScanLineEvent(ConvertBlackWhiteScanLine));
        }

        /// <summary>
        /// Sets the black white pallete.
        /// </summary>
        /// <param name="plt">The PLT.</param>
        /// <returns>ColorPalette.</returns>
        ColorPalette SetBlackWhitePallete(ColorPalette plt)
        {
            plt.Entries[0] = Color.Black;
            plt.Entries[1] = Color.White;
            return plt;
        }

        /// <summary>
        /// Converts the black white scan line.
        /// </summary>
        /// <param name="srcLine">The source line.</param>
        /// <param name="dstLine">The DST line.</param>
        /// <param name="width">The width.</param>
        /// <param name="srcPixBit">The source pix bit.</param>
        /// <param name="dstPixBit">The DST pix bit.</param>
        /// <param name="srcBmp">The source BMP.</param>
        /// <param name="dstBmp">The DST BMP.</param>
        unsafe void ConvertBlackWhiteScanLine(IntPtr srcLine, IntPtr dstLine, int width, int srcPixBit, int dstPixBit, System.Drawing.Bitmap srcBmp, System.Drawing.Bitmap dstBmp)
        {
            byte* src = (byte*)srcLine.ToPointer();
            byte* dst = (byte*)dstLine.ToPointer();
            int srcPixByte = srcPixBit / 8;
            int x, v, t = 0;

            for (x = 0; x < width; x++)
            {
                v = 28 * src[0] + 151 * src[1] + 77 * src[2];
                t = (t << 1) | (v > 200 * 256 ? 1 : 0);
                src += srcPixByte;

                if (x % 8 == 7)
                {
                    *dst = (byte)t;
                    dst++;
                    t = 0;
                }
            }

            if ((x %= 8) != 7)
            {
                t <<= 8 - x;
                *dst = (byte)t;
            }
        }

        /// <summary>
        /// Grays the specified BMP.
        /// </summary>
        /// <param name="bmp">The BMP.</param>
        public void Gray(ref System.Drawing.Bitmap bmp)
        {
            AdjustColor(ref bmp, PixelFormat.Format8bppIndexed,
                new PaletteAdjustEvent(SetGrayPallete),
                new ConvertScanLineEvent(ConvertGaryScanLine));
        }

        /// <summary>
        /// Sets the gray pallete.
        /// </summary>
        /// <param name="plt">The PLT.</param>
        /// <returns>ColorPalette.</returns>
        ColorPalette SetGrayPallete(ColorPalette plt)
        {
            //for (int i = plt.Entries.Length - 1; i >= 0; i--)
            //    plt.Entries[i] = Color.FromArgb( i, i, i);
            for (int i = plt.Entries.Length - 1; i >= 0; i--)
                plt.Entries[i] = Color.FromArgb(alpha, i, i, i);
            return plt;
        }

        /// <summary>
        /// Converts the gary scan line.
        /// </summary>
        /// <param name="srcLine">The source line.</param>
        /// <param name="dstLine">The DST line.</param>
        /// <param name="width">The width.</param>
        /// <param name="srcPixBit">The source pix bit.</param>
        /// <param name="dstPixBit">The DST pix bit.</param>
        /// <param name="srcBmp">The source BMP.</param>
        /// <param name="dstBmp">The DST BMP.</param>
        unsafe void ConvertGaryScanLine(IntPtr srcLine, IntPtr dstLine, int width, int srcPixBit, int dstPixBit, System.Drawing.Bitmap srcBmp, System.Drawing.Bitmap dstBmp)
        {
            byte* src = (byte*)srcLine.ToPointer();
            byte* dst = (byte*)dstLine.ToPointer();
            int srcPixByte = srcPixBit / 8;

            for (int x = 0; x < width; x++)
            {
                *dst = (byte)((28 * src[0] + 151 * src[1] + 77 * src[2]) >> 8);
                src += srcPixByte;
                dst++;
            }
        }

        #endregion

        /// <summary>
        /// Monochrome Lock Bits
        /// </summary>
        /// <param name="pimage">The pimage.</param>
        /// <returns>System.Drawing.Bitmap.</returns>
        public static System.Drawing.Bitmap MonochromeLockBits(System.Drawing.Bitmap pimage)
        {
            System.Drawing.Bitmap source = null;

            // If original bitmap is not already in 32 BPP, ARGB format, then convert
            if (pimage.PixelFormat != PixelFormat.Format32bppArgb)
            {
                source = new System.Drawing.Bitmap(pimage.Width, pimage.Height, PixelFormat.Format32bppArgb);
                source.SetResolution(pimage.HorizontalResolution, pimage.VerticalResolution);
                using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(source))
                {
                    g.DrawImageUnscaled(pimage, 0, 0);
                }
            }
            else
            {
                source = pimage;
            }

            // Lock source bitmap in memory
            BitmapData sourceData = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            // Copy image data to binary array
            int imageSize = sourceData.Stride * sourceData.Height;
            byte[] sourceBuffer = new byte[imageSize];
            Marshal.Copy(sourceData.Scan0, sourceBuffer, 0, imageSize);

            // Unlock source bitmap
            source.UnlockBits(sourceData);

            // Create destination bitmap
            System.Drawing.Bitmap destination = new System.Drawing.Bitmap(source.Width, source.Height, PixelFormat.Format1bppIndexed);

            // Lock destination bitmap in memory
            BitmapData destinationData = destination.LockBits(new Rectangle(0, 0, destination.Width, destination.Height), ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed);

            // Create destination buffer
            imageSize = destinationData.Stride * destinationData.Height;
            byte[] destinationBuffer = new byte[imageSize];

            int sourceIndex = 0;
            int destinationIndex = 0;
            int pixelTotal = 0;
            byte destinationValue = 0;
            int pixelValue = 128;
            int height = source.Height;
            int width = source.Width;
            int threshold = 500;

            // Iterate lines
            for (int y = 0; y < height; y++)
            {
                sourceIndex = y * sourceData.Stride;
                destinationIndex = y * destinationData.Stride;
                destinationValue = 0;
                pixelValue = 128;

                // Iterate pixels
                for (int x = 0; x < width; x++)
                {
                    // Compute pixel brightness (i.e. total of Red, Green, and Blue values)
                    pixelTotal = sourceBuffer[sourceIndex + 1] + sourceBuffer[sourceIndex + 2] + sourceBuffer[sourceIndex + 3];
                    if (pixelTotal > threshold)
                    {
                        destinationValue += (byte)pixelValue;
                    }
                    if (pixelValue == 1)
                    {
                        destinationBuffer[destinationIndex] = destinationValue;
                        destinationIndex++;
                        destinationValue = 0;
                        pixelValue = 128;
                    }
                    else
                    {
                        pixelValue >>= 1;
                    }
                    sourceIndex += 4;
                }
                if (pixelValue != 128)
                {
                    destinationBuffer[destinationIndex] = destinationValue;
                }
            }

            // Copy binary image data to destination bitmap
            Marshal.Copy(destinationBuffer, 0, destinationData.Scan0, imageSize);

            // Unlock destination bitmap
            destination.UnlockBits(destinationData);

            // Dispose of source if not originally supplied bitmap
            if (source != pimage)
            {
                source.Dispose();
            }

            // Return
            return destination;
        }

    }

}
