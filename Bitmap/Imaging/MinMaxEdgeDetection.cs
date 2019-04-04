// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="MinMaxEdgeDetection.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.Utilities.BitmapUtils.Imaging
{
    /// <summary>
    /// A class collection for Minimum and Maximum Detection
    /// </summary>
    public static class MinMaxEdgeDetection
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
        /// To Pixel Buffer
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <returns></returns>
        public static byte[] ToPixelBuffer(this System.Drawing.Bitmap sourceBitmap)
        {
            BitmapData sourceData =
                       sourceBitmap.LockBits(new Rectangle(0, 0,
                       sourceBitmap.Width, sourceBitmap.Height),
                       ImageLockMode.ReadOnly,
                       PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride *
                                          sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0,
                                       pixelBuffer.Length);

            sourceBitmap.UnlockBits(sourceData);

            return pixelBuffer;
        }

        /// <summary>
        /// To Bitmap
        /// </summary>
        /// <param name="resultBuffer">Set buffer</param>
        /// <param name="width">Set Width</param>
        /// <param name="height">Set Height</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap ToBitmap(this byte[] resultBuffer, int width, int height)
        {
            System.Drawing.Bitmap resultBitmap = new System.Drawing.Bitmap(width,
                                             height, PixelFormat.Format32bppArgb);

            BitmapData resultData =
                       resultBitmap.LockBits(new Rectangle(0, 0,
                       width, height),
                       ImageLockMode.WriteOnly,
                       PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0,
                                       resultBuffer.Length);

            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        private const byte maxByteValue = Byte.MaxValue;
        private const byte minByteValue = Byte.MinValue;
        private const int greenOffset = 1;
        private const int redOffset = 2;
        private const int alphaOffset = 3;
        private const int pixelByteCount = 4;

        public static byte ByteVal(double val)
        {
            return (byte)val;
        }

        private static byte[] MedianFilter(this byte[] pixelBuffer,
                                           int imageWidth,
                                           int imageHeight,
                                           int filterSize)
        {
            byte[] resultBuffer = new byte[pixelBuffer.Length];

            int filterOffset = (filterSize - 1) / 2;
            int calcOffset = 0;
            int stride = imageWidth * pixelByteCount;

            int byteOffset = 0;
            var neighbourCount = filterSize * filterSize;
            int medianIndex = neighbourCount / 2;

            var blueNeighbours = new byte[neighbourCount];
            var greenNeighbours = new byte[neighbourCount];
            var redNeighbours = new byte[neighbourCount];

            for (int offsetY = filterOffset; offsetY <
                imageHeight - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    imageWidth - filterOffset; offsetX++)
                {
                    byteOffset = offsetY *
                                 stride +
                                 offsetX * pixelByteCount;

                    for (int filterY = -filterOffset, neighbour = 0;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++, neighbour++)
                        {
                            calcOffset = byteOffset +
                                         (filterX * pixelByteCount) +
                                         (filterY * stride);

                            blueNeighbours[neighbour] = pixelBuffer[calcOffset];
                            greenNeighbours[neighbour] = pixelBuffer[calcOffset + greenOffset];
                            redNeighbours[neighbour] = pixelBuffer[calcOffset + redOffset];
                        }
                    }

                    Array.Sort(blueNeighbours);
                    Array.Sort(greenNeighbours);
                    Array.Sort(redNeighbours);

                    resultBuffer[byteOffset] = blueNeighbours[medianIndex];
                    resultBuffer[byteOffset + greenOffset] = greenNeighbours[medianIndex];
                    resultBuffer[byteOffset + redOffset] = redNeighbours[medianIndex];
                    resultBuffer[byteOffset + alphaOffset] = maxByteValue;
                }
            }

            return resultBuffer;
        }

        /// <summary>
        /// Minimum and Maximum Edge Detection
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="filterSize">Set Filter Size</param>
        /// <param name="smoothNoise">Set smooth noise</param>
        /// <param name="grayscale">Set grayscale</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap MiniMaxiEdgeDetection(this System.Drawing.Bitmap sourceBitmap,
                                                 int filterSize, 
                                                 bool smoothNoise = false, 
                                                 bool grayscale = false)
        {
            return sourceBitmap.ToPixelBuffer()
                               .MiniMaxiEdgeDetection(sourceBitmap.Width, 
                                                    sourceBitmap.Height, 
                                                    filterSize,
                                                    smoothNoise,
                                                    grayscale)
                               .ToBitmap(sourceBitmap.Width, 
                                         sourceBitmap.Height);
        }

        private static byte[] MiniMaxiEdgeDetection(this byte[] sourceBuffer,
                                                  int imageWidth,
                                                  int imageHeight,
                                                  int filterSize,
                                                  bool smoothNoise = false,
                                                  bool grayscale = false)
        {
            byte[] pixelBuffer = sourceBuffer;

            if (smoothNoise)
            {
                pixelBuffer = sourceBuffer.MedianFilter(imageWidth, 
                                                        imageHeight, 
                                                        filterSize);
            }

            byte[] resultBuffer = new byte[pixelBuffer.Length];

            int filterOffset = (filterSize - 1) / 2;
            int calcOffset = 0;
            int stride = imageWidth * pixelByteCount;

            int byteOffset = 0;

            byte minBlue = 0, minGreen = 0, minRed = 0;
            byte maxBlue = 0, maxGreen = 0, maxRed = 0;

            for (int offsetY = filterOffset; offsetY <
                imageHeight - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    imageWidth - filterOffset; offsetX++)
                {
                    byteOffset = offsetY *
                                 stride +
                                 offsetX * pixelByteCount;

                    minBlue = maxByteValue;
                    minGreen = maxByteValue;
                    minRed = maxByteValue;

                    maxBlue = minByteValue;
                    maxGreen = minByteValue;
                    maxRed = minByteValue;

                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {
                            calcOffset = byteOffset +
                                         (filterX * pixelByteCount) +
                                         (filterY * stride);

                            minBlue = Math.Min(pixelBuffer[calcOffset], minBlue);
                            maxBlue = Math.Max(pixelBuffer[calcOffset], maxBlue);

                            minGreen = Math.Min(pixelBuffer[calcOffset + greenOffset], minGreen);
                            maxGreen = Math.Max(pixelBuffer[calcOffset + greenOffset], maxGreen);

                            minRed = Math.Min(pixelBuffer[calcOffset + redOffset], minRed);
                            maxRed = Math.Max(pixelBuffer[calcOffset + redOffset], maxRed);
                        }
                    }

                    if (grayscale)
                    {
                        resultBuffer[byteOffset] = ByteVal((maxBlue - minBlue) * 0.114 + 
                                                           (maxGreen - minGreen) * 0.587 + 
                                                           (maxRed - minRed) * 0.299);

                        resultBuffer[byteOffset + greenOffset] = resultBuffer[byteOffset];
                        resultBuffer[byteOffset + redOffset] = resultBuffer[byteOffset];
                        resultBuffer[byteOffset + alphaOffset] = maxByteValue;
                    }
                    else
                    {
                        resultBuffer[byteOffset] = (byte)(maxBlue - minBlue);
                        resultBuffer[byteOffset + greenOffset] = (byte)(maxGreen - minGreen);
                        resultBuffer[byteOffset + redOffset] = (byte)(maxRed - minRed);
                        resultBuffer[byteOffset + alphaOffset] = maxByteValue;
                    }
                }
            }

            return resultBuffer;
        }
    }
}