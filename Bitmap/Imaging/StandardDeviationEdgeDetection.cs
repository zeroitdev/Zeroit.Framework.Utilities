// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="StandardDeviationEdgeDetection.cs" company="Zeroit Dev Technologies">
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
/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/
using System;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.Utilities.BitmapUtils.Imaging
{
    /// <summary>
    /// A class collection for Calculating Standard Deviation Edge Detection
    /// </summary>
    public static class StandardDeviationEdgeDetection
    {
        /// <summary>
        /// Copy to canvas
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="canvasWidthLenght">Set canvas Width and Height</param>
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
        /// SD To Pixel Buffer
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <returns></returns>
        public static byte[] SDToPixelBuffer(this System.Drawing.Bitmap sourceBitmap)
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
        /// SD Edge To Bitmap
        /// </summary>
        /// <param name="resultBuffer">Set buffer</param>
        /// <param name="width">Set Width</param>
        /// <param name="height">Set Height</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap SDEdgeToBitmap(this byte[] resultBuffer, int width, int height)
        {
            System.Drawing.Bitmap resultBitmap = new System.Drawing.Bitmap(width,
                                             height, PixelFormat.Format32bppArgb);

            BitmapData resultData =
                       resultBitmap.LockBits(new Rectangle(0, 0,
                       resultBitmap.Width, resultBitmap.Height),
                       ImageLockMode.WriteOnly,
                       PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0,
                                       resultBuffer.Length);

            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        private const byte maxByteValue = Byte.MaxValue;
        private const byte minByteValue = Byte.MinValue;

        public static byte ByteVal(int val)
        {
            if (val < minByteValue) { return minByteValue; }
            else if (val > maxByteValue) { return maxByteValue; }
            else { return (byte)val; }
        }

        public static byte ByteVal(double val)
        {
            if (val < minByteValue) { return minByteValue; }
            else if (val > maxByteValue) { return maxByteValue; }
            else { return (byte)val; }
        }

        private const int pixelByteCount = 4;

        /// <summary>
        /// Standard Deviation Edge Detect
        /// </summary>
        /// <param name="sourceBuffer">Set source Bitmap</param>
        /// <param name="filterSize">Set filter size</param>
        /// <param name="varianceFactor">Set variance Factor</param>
        /// <param name="grayscaleOutput">Set grayscale</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap StandardDeviationEdgeDetect(this System.Drawing.Bitmap sourceBuffer, 
                                                            int filterSize, 
                                                            float varianceFactor = 1.0f, 
                                                            bool grayscaleOutput = true)
        {
            return sourceBuffer.SDToPixelBuffer()
                               .StandardDeviationEdgeDetect(sourceBuffer.Width, 
                                                               sourceBuffer.Height,
                                                               filterSize,
                                                               varianceFactor,
                                                               grayscaleOutput)
                                .SDEdgeToBitmap(sourceBuffer.Width, sourceBuffer.Height);
        }

        private static byte[] StandardDeviationEdgeDetect(this byte[] pixelBuffer, 
                                                             int imageWidth, 
                                                             int imageHeight,
                                                             int filterSize,
                                                             float varianceFactor = 1.0f,
                                                             bool grayscaleOutput = true)
        {
            byte[] resultBuffer = new byte[pixelBuffer.Length];

            int filterOffset = (filterSize - 1) / 2;
            int calcOffset = 0;
            int stride = imageWidth * pixelByteCount;
            
            int byteOffset = 0;
            var neighbourCount = filterSize * filterSize;
            
            var blueNeighbours = new int[neighbourCount];
            var greenNeighbours = new int[neighbourCount];
            var redNeighbours = new int[neighbourCount];

            double resetValue = 0;
            double meanBlue = 0, meanGreen = 0, meanRed = 0;
            double varianceBlue = 0, varianceGreen = 0, varianceRed = 0;

            varianceFactor = varianceFactor * varianceFactor;

            for (int offsetY = filterOffset; offsetY <
                imageHeight - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    imageWidth - filterOffset; offsetX++)
                {
                    byteOffset = offsetY *
                                 stride +
                                 offsetX * pixelByteCount;

                    meanBlue = resetValue;
                    meanGreen = resetValue;
                    meanRed = resetValue;

                    varianceBlue = resetValue;
                    varianceGreen = resetValue;
                    varianceRed = resetValue;

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
                            greenNeighbours[neighbour] = pixelBuffer[calcOffset + 1];
                            redNeighbours[neighbour] = pixelBuffer[calcOffset + 2];
                        }
                    }

                    meanBlue = blueNeighbours.Average();
                    meanGreen = greenNeighbours.Average();
                    meanRed = redNeighbours.Average();

                    for (int n = 0; n < neighbourCount; n++)
                    {
                        varianceBlue = varianceBlue + 
                                       SquareNumber(blueNeighbours[n] - meanBlue);
                        varianceGreen = varianceGreen + 
                                        SquareNumber(greenNeighbours[n] - meanGreen);
                        varianceRed = varianceRed + 
                                      SquareNumber(redNeighbours[n] - meanRed);
                    }

                    varianceBlue = varianceBlue / 
                                   neighbourCount * 
                                   varianceFactor;

                    varianceGreen = varianceGreen /
                                    neighbourCount * 
                                    varianceFactor;

                    varianceRed = varianceRed / 
                                  neighbourCount * 
                                  varianceFactor;

                    if (grayscaleOutput)
                    {
                        var pixelValue = ByteVal(ByteVal(Math.Sqrt(varianceBlue)) |
                                                 ByteVal(Math.Sqrt(varianceGreen)) | 
                                                 ByteVal(Math.Sqrt(varianceRed)));

                        resultBuffer[byteOffset] = pixelValue;
                        resultBuffer[byteOffset + 1] = pixelValue;
                        resultBuffer[byteOffset + 2] = pixelValue;
                        resultBuffer[byteOffset + 3] = Byte.MaxValue;
                    }
                    else
                    {
                        resultBuffer[byteOffset] = ByteVal(Math.Sqrt(varianceBlue));
                        resultBuffer[byteOffset + 1] = ByteVal(Math.Sqrt(varianceGreen));
                        resultBuffer[byteOffset + 2] = ByteVal(Math.Sqrt(varianceRed));
                        resultBuffer[byteOffset + 3] = Byte.MaxValue;
                    }
                }
            }

            return resultBuffer;
        }

        private static double SquareNumber(double val)
        {
            return val * val;
        }
    }
}