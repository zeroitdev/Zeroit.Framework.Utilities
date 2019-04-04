// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ImageSolarise.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/

using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.Utilities.BitmapUtils.Imaging
{
    /// <summary>
    /// A class collection for Image Solarisation
    /// </summary>
    public static class ImageSolarise
    {

        /// <summary>
        /// Copy to canvas
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="canvasWidthLenght">Set canvas Width and Length</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap CopyToSquareCanvas(this System.Drawing.Bitmap sourceBitmap, int canvasWidthLenght)
        {
            float ratio = 1.0f;
            int maxSide = sourceBitmap.Width > sourceBitmap.Height ?
                          sourceBitmap.Width : sourceBitmap.Height;

            ratio = (float)maxSide / (float)canvasWidthLenght;

            System.Drawing.Bitmap bitmapResult = (sourceBitmap.Width > sourceBitmap.Height ?
                                    new System.Drawing.Bitmap(canvasWidthLenght, (int)(sourceBitmap.Height / ratio))
                                    : new System.Drawing.Bitmap((int)(sourceBitmap.Width / ratio), canvasWidthLenght));

            using (System.Drawing.Graphics graphicsResult = System.Drawing.Graphics.FromImage(bitmapResult))
            {
                graphicsResult.CompositingQuality = CompositingQuality.HighQuality;
                graphicsResult.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsResult.PixelOffsetMode = PixelOffsetMode.HighQuality;

                graphicsResult.DrawImage(sourceBitmap,
                                        new Rectangle(0, 0,
                                            bitmapResult.Width, bitmapResult.Height),
                                        new Rectangle(0, 0,
                                            sourceBitmap.Width, sourceBitmap.Height),
                                            GraphicsUnit.Pixel);
                graphicsResult.Flush();
            }

            return bitmapResult;
        }

        /// <summary>
        /// Solarise
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="blueValue">Set blue value</param>
        /// <param name="greenValue">Set green value</param>
        /// <param name="redValue">Set red value</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap Solarise(this System.Drawing.Bitmap sourceBitmap, byte blueValue,
                                        byte greenValue, byte redValue)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                    sourceBitmap.Width, sourceBitmap.Height),
                                    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);

            sourceBitmap.UnlockBits(sourceData);

            byte byte255 = 255;

            for (int k = 0; k + 4 < pixelBuffer.Length; k += 4)
            {
                if (pixelBuffer[k] < blueValue)
                {
                    pixelBuffer[k] = (byte)(byte255 - pixelBuffer[k]);
                }

                if (pixelBuffer[k + 1] < greenValue)
                {
                    pixelBuffer[k + 1] = (byte)(byte255 - pixelBuffer[k + 1]);
                }

                if (pixelBuffer[k + 2] < redValue)
                {
                    pixelBuffer[k + 2] = (byte)(byte255 - pixelBuffer[k + 2]);
                }
            }

            System.Drawing.Bitmap resultBitmap = new System.Drawing.Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                    resultBitmap.Width, resultBitmap.Height),
                                    ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(pixelBuffer, 0, resultData.Scan0, pixelBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }
    }
}
