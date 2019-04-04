﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ImageEdgeDetection.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.Utilities.BitmapUtils.Imaging
{
    /// <summary>
    /// A class collection of Image Edge Detection
    /// </summary>
    public static class ImageEdgeDetection
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
        /// Convolution Filter
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="filterMatrix">Set Filter Matrix</param>
        /// <param name="factor">Set Factor</param>
        /// <param name="bias">Set Bias</param>
        /// <param name="grayscale">Set Grayscale</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap ConvolutionFilter(System.Drawing.Bitmap sourceBitmap, 
                                             double[,] filterMatrix, 
                                                  double factor = 1, 
                                                       int bias = 0, 
                                             bool grayscale = false) 
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                     sourceBitmap.Width, sourceBitmap.Height),
                                                       ImageLockMode.ReadOnly, 
                                                 PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);

            if (grayscale == true)
            {
                float rgb = 0;

                for (int k = 0; k < pixelBuffer.Length; k += 4)
                {
                    rgb = pixelBuffer[k] * 0.11f;
                    rgb += pixelBuffer[k + 1] * 0.59f;
                    rgb += pixelBuffer[k + 2] * 0.3f;


                    pixelBuffer[k] = (byte)rgb;
                    pixelBuffer[k + 1] = pixelBuffer[k];
                    pixelBuffer[k + 2] = pixelBuffer[k];
                    pixelBuffer[k + 3] = 255;
                }
            }

            double blue = 0.0;
            double green = 0.0;
            double red = 0.0;

            int filterWidth = filterMatrix.GetLength(1);
            int filterHeight = filterMatrix.GetLength(0);

            int filterOffset = (filterWidth-1) / 2;
            int calcOffset = 0;

            int byteOffset = 0;

            for (int offsetY = filterOffset; offsetY < 
                sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX < 
                    sourceBitmap.Width - filterOffset; offsetX++)
                {
                    blue = 0;
                    green = 0;
                    red = 0;

                    byteOffset = offsetY * 
                                 sourceData.Stride + 
                                 offsetX * 4;

                    for (int filterY = -filterOffset; 
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {

                            calcOffset = byteOffset + 
                                         (filterX * 4) + 
                                         (filterY * sourceData.Stride);

                            blue += (double)(pixelBuffer[calcOffset]) *
                                    filterMatrix[filterY + filterOffset, 
                                                        filterX + filterOffset];

                            green += (double)(pixelBuffer[calcOffset + 1]) *
                                     filterMatrix[filterY + filterOffset, 
                                                        filterX + filterOffset];

                            red += (double)(pixelBuffer[calcOffset + 2]) *
                                   filterMatrix[filterY + filterOffset, 
                                                      filterX + filterOffset];
                        }
                    }

                    blue = factor * blue + bias;
                    green = factor * green + bias;
                    red = factor * red + bias;

                    if (blue > 255)
                    { blue = 255; }
                    else if (blue < 0)
                    { blue = 0; }

                    if (green > 255)
                    { green = 255; }
                    else if (green < 0)
                    { green = 0; }

                    if (red > 255)
                    { red = 255; }
                    else if (red < 0)
                    { red = 0; }

                    resultBuffer[byteOffset] = (byte)(blue);
                    resultBuffer[byteOffset + 1] = (byte)(green);
                    resultBuffer[byteOffset + 2] = (byte)(red);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            System.Drawing.Bitmap resultBitmap = new System.Drawing.Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                     resultBitmap.Width, resultBitmap.Height),
                                                      ImageLockMode.WriteOnly,
                                                 PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        /// <summary>
        /// Convolution Filter
        /// </summary>
        /// <param name="sourceBitmap">Set source </param>
        /// <param name="xFilterMatrix"></param>
        /// <param name="yFilterMatrix"></param>
        /// <param name="factor"></param>
        /// <param name="bias"></param>
        /// <param name="grayscale"></param>
        /// <returns></returns>
        public static System.Drawing.Bitmap ConvolutionFilter(this System.Drawing.Bitmap sourceBitmap,
                                                double[,] xFilterMatrix,
                                                double[,] yFilterMatrix,
                                                      double factor = 1,
                                                           int bias = 0,
                                                 bool grayscale = false)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                     sourceBitmap.Width, sourceBitmap.Height),
                                                       ImageLockMode.ReadOnly,
                                                  PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);

            if (grayscale == true)
            {
                float rgb = 0;

                for (int k = 0; k < pixelBuffer.Length; k += 4)
                {
                    rgb = pixelBuffer[k] * 0.11f;
                    rgb += pixelBuffer[k + 1] * 0.59f;
                    rgb += pixelBuffer[k + 2] * 0.3f;

                    pixelBuffer[k] = (byte)rgb;
                    pixelBuffer[k + 1] = pixelBuffer[k];
                    pixelBuffer[k + 2] = pixelBuffer[k];
                    pixelBuffer[k + 3] = 255;
                }
            }

            double blueX = 0.0;
            double greenX = 0.0;
            double redX = 0.0;

            double blueY = 0.0;
            double greenY = 0.0;
            double redY = 0.0;

            double blueTotal = 0.0;
            double greenTotal = 0.0;
            double redTotal = 0.0;

            int filterOffset = 1;
            int calcOffset = 0;

            int byteOffset = 0;

            for (int offsetY = filterOffset; offsetY <
                sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    sourceBitmap.Width - filterOffset; offsetX++)
                {
                    blueX = greenX = redX = 0;
                    blueY = greenY = redY = 0;

                    blueTotal = greenTotal = redTotal = 0.0;

                    byteOffset = offsetY *
                                 sourceData.Stride +
                                 offsetX * 4;

                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {
                            calcOffset = byteOffset +
                                         (filterX * 4) +
                                         (filterY * sourceData.Stride);

                            blueX += (double)(pixelBuffer[calcOffset]) *
                                      xFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            greenX += (double)(pixelBuffer[calcOffset + 1]) *
                                      xFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            redX += (double)(pixelBuffer[calcOffset + 2]) *
                                      xFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            blueY += (double)(pixelBuffer[calcOffset]) *
                                      yFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            greenY += (double)(pixelBuffer[calcOffset + 1]) *
                                      yFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            redY += (double)(pixelBuffer[calcOffset + 2]) *
                                      yFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];
                        }
                    }

                    blueTotal = Math.Sqrt((blueX * blueX) + (blueY * blueY));
                    greenTotal = Math.Sqrt((greenX * greenX) + (greenY * greenY));
                    redTotal = Math.Sqrt((redX * redX) + (redY * redY));

                    if (blueTotal > 255)
                    { blueTotal = 255; }
                    else if (blueTotal < 0)
                    { blueTotal = 0; }

                    if (greenTotal > 255)
                    { greenTotal = 255; }
                    else if (greenTotal < 0)
                    { greenTotal = 0; }

                    if (redTotal > 255)
                    { redTotal = 255; }
                    else if (redTotal < 0)
                    { redTotal = 0; }

                    resultBuffer[byteOffset] = (byte)(blueTotal);
                    resultBuffer[byteOffset + 1] = (byte)(greenTotal);
                    resultBuffer[byteOffset + 2] = (byte)(redTotal);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            System.Drawing.Bitmap resultBitmap = new System.Drawing.Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                     resultBitmap.Width, resultBitmap.Height),
                                                      ImageLockMode.WriteOnly,
                                                  PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        /// <summary>
        /// Laplacian 3x3 Filter
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="grayscale">Set grayscale</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap Laplacian3x3Filter(this System.Drawing.Bitmap sourceBitmap, 
                                                    bool grayscale = true)
        {
            System.Drawing.Bitmap resultBitmap = ConvolutionFilter(sourceBitmap, 
                                    Matrix.Laplacian3x3, 1.0, 0, grayscale);

            return resultBitmap;
        }

        /// <summary>
        /// Laplacian 5x5 Filter
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="grayscale">Set grayscale</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap Laplacian5x5Filter(this System.Drawing.Bitmap sourceBitmap, 
                                                    bool grayscale = true)
        {
            System.Drawing.Bitmap resultBitmap = ConvolutionFilter(sourceBitmap, 
                                    Matrix.Laplacian5x5, 1.0, 0, grayscale);

            return resultBitmap;
        }

        /// <summary>
        /// Laplacian Of Gaussian Filter
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap LaplacianOfGaussianFilter(this System.Drawing.Bitmap sourceBitmap)
        {
            System.Drawing.Bitmap resultBitmap = ConvolutionFilter(sourceBitmap, 
                                  Matrix.LaplacianOfGaussian, 1.0, 0, true);

            return resultBitmap;
        }

        /// <summary>
        /// Laplacian 3x3 Of Gaussian 3x3 Filter
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap Laplacian3x3OfGaussian3x3Filter(this System.Drawing.Bitmap sourceBitmap)
        {
            System.Drawing.Bitmap resultBitmap = ConvolutionFilter(sourceBitmap, 
                                   Matrix.Gaussian3x3, 1.0 / 16.0, 0, true);

            resultBitmap = ConvolutionFilter(resultBitmap, 
                                 Matrix.Laplacian3x3, 1.0, 0, false);

            return resultBitmap;
        }

        /// <summary>
        /// Laplacian 3x3 Of Gaussian 3x3 Filter 1
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap Laplacian3x3OfGaussian5x5Filter1(this System.Drawing.Bitmap sourceBitmap)
        {
            System.Drawing.Bitmap resultBitmap = ConvolutionFilter(sourceBitmap, 
                             Matrix.Gaussian5x5Type1, 1.0 / 159.0, 0, true);

            resultBitmap = ConvolutionFilter(resultBitmap, 
                                 Matrix.Laplacian3x3, 1.0, 0, false);

            return resultBitmap;
        }

        /// <summary>
        /// Laplacian 3x3 Of Gaussian 5x5 Filter 2
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap Laplacian3x3OfGaussian5x5Filter2(this System.Drawing.Bitmap sourceBitmap)
        {
            System.Drawing.Bitmap resultBitmap = ConvolutionFilter(sourceBitmap, 
                             Matrix.Gaussian5x5Type2, 1.0 / 256.0, 0, true);

            resultBitmap = ConvolutionFilter(resultBitmap, 
                                 Matrix.Laplacian3x3, 1.0, 0, false);

            return resultBitmap;
        }

        /// <summary>
        /// Laplacian 5x5 Of Gaussian 3x3 Filter
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap Laplacian5x5OfGaussian3x3Filter(this System.Drawing.Bitmap sourceBitmap)
        {
            System.Drawing.Bitmap resultBitmap = ConvolutionFilter(sourceBitmap, 
                                   Matrix.Gaussian3x3, 1.0 / 16.0, 0, true);

            resultBitmap = ConvolutionFilter(resultBitmap,
                                 Matrix.Laplacian5x5, 1.0, 0, false);

            return resultBitmap;
        }

        /// <summary>
        /// Laplacian 5x5 Of Gaussian 5x5 Filter 1
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap Laplacian5x5OfGaussian5x5Filter1(this System.Drawing.Bitmap sourceBitmap)
        {
            System.Drawing.Bitmap resultBitmap = ConvolutionFilter(sourceBitmap, 
                             Matrix.Gaussian5x5Type1, 1.0 / 159.0, 0, true);

            resultBitmap = ConvolutionFilter(resultBitmap,
                                 Matrix.Laplacian5x5, 1.0, 0, false);

            return resultBitmap;
        }

        /// <summary>
        /// Laplacian 5x5 Of Gaussian 5x5 Filter 2
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap Laplacian5x5OfGaussian5x5Filter2(this System.Drawing.Bitmap sourceBitmap)
        {
            System.Drawing.Bitmap resultBitmap = ConvolutionFilter(sourceBitmap, 
                                                   Matrix.Gaussian5x5Type2, 
                                                     1.0 / 256.0, 0, true);

            resultBitmap = ConvolutionFilter(resultBitmap, 
                                 Matrix.Laplacian5x5, 1.0, 0, false);

            return resultBitmap;
        }

        /// <summary>
        /// Sobel 3x3 Filter
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="grayscale">Set grayscale</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap Sobel3x3Filter(this System.Drawing.Bitmap sourceBitmap, 
                                                bool grayscale = true)
        {
            System.Drawing.Bitmap resultBitmap = ConvolutionFilter(sourceBitmap, 
                                                 Matrix.Sobel3x3Horizontal, 
                                                   Matrix.Sobel3x3Vertical, 
                                                        1.0, 0, grayscale);

            return resultBitmap;
        }

        /// <summary>
        /// Prewitt Filter
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="grayscale">Set grayscale</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap PrewittFilter(this System.Drawing.Bitmap sourceBitmap, 
                                               bool grayscale = true)
        {
            System.Drawing.Bitmap resultBitmap = ConvolutionFilter(sourceBitmap, 
                                               Matrix.Prewitt3x3Horizontal, 
                                                 Matrix.Prewitt3x3Vertical, 
                                                        1.0, 0, grayscale);

            return resultBitmap;
        }

        /// <summary>
        /// Kirsch Filter
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="grayscale">Set grayscale</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap KirschFilter(this System.Drawing.Bitmap sourceBitmap, 
                                              bool grayscale = true)
        {
            System.Drawing.Bitmap resultBitmap = ConvolutionFilter(sourceBitmap, 
                                                Matrix.Kirsch3x3Horizontal, 
                                                  Matrix.Kirsch3x3Vertical, 
                                                        1.0, 0, grayscale);

            return resultBitmap;
        }
    }  
}
