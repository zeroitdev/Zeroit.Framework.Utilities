// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ImageDistortionBlur.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.Utilities.BitmapUtils.Imaging
{
    /// <summary>
    /// A class collection of Image Distortion Blur
    /// </summary>
    public static class ImageDistortionBlur
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
        /// Distortion Blur Filter
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="distortFactor">Set distort Factor</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap DistortionBlurFilter(
                 this System.Drawing.Bitmap sourceBitmap, int distortFactor)
        {
            byte[] pixelBuffer = sourceBitmap.GetByteArrayinDistortion();
            byte[] resultBuffer = sourceBitmap.GetByteArrayinDistortion();

            int imageStride = sourceBitmap.Width * 4;
            int calcOffset = 0, filterY = 0, filterX = 0;
            int factorMax = (distortFactor + 1) * 2;
            Random rand = new Random();

            for (int k = 0; k + 4 < pixelBuffer.Length; k += 4)
            {
                filterY = distortFactor - rand.Next(0, factorMax);
                filterX = distortFactor - rand.Next(0, factorMax);

                if (filterX * 4 + (k % imageStride) < imageStride 
                           && filterX * 4 + (k % imageStride) > 0)
                {
                    calcOffset = k + filterY * imageStride + 
                                 4 * filterX;

                    if (calcOffset >= 0 && 
                        calcOffset + 4 < resultBuffer.Length)
                    {
                        resultBuffer[calcOffset] = pixelBuffer[k];
                        resultBuffer[calcOffset + 1] = pixelBuffer[k + 1];
                        resultBuffer[calcOffset + 2] = pixelBuffer[k + 2];
                    }
                }
            }

            return resultBuffer.GetImageForDistortion(sourceBitmap.Width, 
                                sourceBitmap.Height).DistortionMedianFilter(3);
        }

        /// <summary>
        /// Distortion Median Filter
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="matrixSize">Set matrix size</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap DistortionMedianFilter(this System.Drawing.Bitmap sourceBitmap,
                                          int matrixSize)
        {
            byte[] pixelBuffer = sourceBitmap.GetByteArrayinDistortion();
            byte[] resultBuffer = new byte[pixelBuffer.Length];
            byte[] middlePixel;

            int imageStride = sourceBitmap.Width * 4;
            int filterOffset = (matrixSize - 1) / 2;
            int calcOffset = 0, filterY = 0, filterX = 0;
            List<int> neighbourPixels = new List<int>();

            for (int k = 0; k + 4 < pixelBuffer.Length; k += 4)
            {
                filterY = -filterOffset; filterX = -filterOffset;
                neighbourPixels.Clear();

                while (filterY <= filterOffset)
                {
                    calcOffset = k + (filterX * 4) +
                    (filterY * imageStride);

                    if (calcOffset > 0 && 
                        calcOffset + 4 < pixelBuffer.Length)
                    {
                        neighbourPixels.Add(BitConverter.ToInt32(
                                            pixelBuffer, calcOffset));
                    }

                    filterX++;

                    if (filterX > filterOffset)
                    { filterX = -filterOffset; filterY++; }
                }

                neighbourPixels.Sort();
                middlePixel = BitConverter.GetBytes(
                              neighbourPixels[filterOffset]);

                resultBuffer[k] = middlePixel[0];
                resultBuffer[k + 1] = middlePixel[1];
                resultBuffer[k + 2] = middlePixel[2];
                resultBuffer[k + 3] = middlePixel[3];
            }

            return resultBuffer.GetImageForDistortion(sourceBitmap.Width, 
                                         sourceBitmap.Height);
        }

        /// <summary>
        /// Get Byte Array in Distortion
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <returns></returns>
        public static byte[] GetByteArrayinDistortion(this System.Drawing.Bitmap sourceBitmap)
        {
            BitmapData sourceData =
                       sourceBitmap.LockBits(new Rectangle(0, 0,
                       sourceBitmap.Width, sourceBitmap.Height),
                       ImageLockMode.ReadOnly,
                       PixelFormat.Format32bppArgb);

            byte[] sourceBuffer = new byte[sourceData.Stride *
                                          sourceData.Height];

            Marshal.Copy(sourceData.Scan0, sourceBuffer, 0,
                                       sourceBuffer.Length);

            sourceBitmap.UnlockBits(sourceData);

            return sourceBuffer;
        }


        /// <summary>
        /// Get Image For Distortion
        /// </summary>
        /// <param name="resultBuffer">Set buffer value in byte</param>
        /// <param name="width">Set Width</param>
        /// <param name="height">Set Height</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap GetImageForDistortion(this byte[] resultBuffer, int width, int height)
        {
            System.Drawing.Bitmap resultBitmap = new System.Drawing.Bitmap(width, height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                    resultBitmap.Width, resultBitmap.Height),
                                    ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);

            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        private static byte ClipByte(double colour)
        {
            return (byte)(colour > 255 ? 255 :
                   (colour < 0 ? 0 : colour));
        }
    }

}
