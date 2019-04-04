// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="BooleanEdgeDetection.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.Utilities.BitmapUtils.Imaging
{

    /// <summary>
    /// A class collection of Boolean Edge Detection
    /// </summary>
    public static class BooleanEdgeDetection
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
        /// Boolean Edge Detection Filter
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="filterType">Set Filter Type</param>
        /// <param name="redFactor">Set red Factor</param>
        /// <param name="greenFactor">Set green factor</param>
        /// <param name="blueFactor">Set blue factor</param>
        /// <param name="threshold">Set threshold</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap BooleanEdgeDetectionFilter(
                                        this System.Drawing.Bitmap sourceBitmap,
                                        BooleanFilterType filterType,
                                        float redFactor = 1.0f,
                                        float greenFactor = 1.0f,
                                        float blueFactor = 1.0f,
                                        byte threshold = 0)
        {
            BitmapData sourceData =
                       sourceBitmap.LockBits(new Rectangle(0, 0,
                       sourceBitmap.Width, sourceBitmap.Height),
                       ImageLockMode.ReadOnly,
                       PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride *
                                          sourceData.Height];

            byte[] resultBuffer = new byte[sourceData.Stride *
                                           sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0,
                                       pixelBuffer.Length);

            sourceBitmap.UnlockBits(sourceData);

            List<string> edgeMasks = new List<string>();

            edgeMasks.Add("011011011");
            edgeMasks.Add("000111111");
            edgeMasks.Add("110110110");
            edgeMasks.Add("111111000");
            edgeMasks.Add("011011001");
            edgeMasks.Add("100110110");
            edgeMasks.Add("111011000");
            edgeMasks.Add("111110000");
            edgeMasks.Add("111011001");
            edgeMasks.Add("100110111");
            edgeMasks.Add("001011111");
            edgeMasks.Add("111110100");
            edgeMasks.Add("000011111");
            edgeMasks.Add("000110111");
            edgeMasks.Add("001011011");
            edgeMasks.Add("001011011");
            edgeMasks.Add("110110100");

            int filterOffset = 1;
            int calcOffset = 0;

            int byteOffset = 0;
            int matrixMean = 0;
            int matrixTotal = 0;
            double matrixVariance = 0;

            double blueValue = 0;
            double greenValue = 0;
            double redValue = 0;

            string matrixPatern = String.Empty;

            for (int offsetY = filterOffset; offsetY <
                sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    sourceBitmap.Width - filterOffset; offsetX++)
                {
                    byteOffset = offsetY *
                                 sourceData.Stride +
                                 offsetX * 4;

                    matrixMean = 0;
                    matrixTotal = 0;
                    matrixVariance = 0;

                    matrixPatern = String.Empty;

                    //Step 1: Calculate local matrix
                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {
                            calcOffset = byteOffset +
                                         (filterX * 4) +
                            (filterY * sourceData.Stride);

                            matrixMean += pixelBuffer[calcOffset];
                            matrixMean += pixelBuffer[calcOffset + 1];
                            matrixMean += pixelBuffer[calcOffset + 2];
                        }
                    }

                    matrixMean = matrixMean / 9;

                    //Step 3: Calculate Variance
                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {
                            calcOffset = byteOffset +
                                         (filterX * 4) +
                            (filterY * sourceData.Stride);

                            matrixTotal = pixelBuffer[calcOffset];
                            matrixTotal += pixelBuffer[calcOffset+1];
                            matrixTotal += pixelBuffer[calcOffset+2];

                            matrixPatern += (matrixTotal > matrixMean 
                                                         ? "1" : "0");

                            matrixVariance += 
                                Math.Pow(matrixMean - 
                                (pixelBuffer[calcOffset] + 
                                pixelBuffer[calcOffset + 1] + 
                                pixelBuffer[calcOffset + 2]), 2);

                        }
                    }

                    matrixVariance = matrixVariance / 9;

                    if (filterType == BooleanFilterType.Sharpen)
                    {
                        blueValue = pixelBuffer[byteOffset];
                        greenValue = pixelBuffer[byteOffset + 1];
                        redValue = pixelBuffer[byteOffset + 2];

                        //Step 4: Exlclude noise using global
                        //        threshold
                        if (matrixVariance > threshold)
                        {   //Step 2: Compare newly calculated
                            //        matrix and image masks
                            if (edgeMasks.Contains(matrixPatern))
                            {
                                blueValue = (blueValue * blueFactor);
                                greenValue = (greenValue * greenFactor);
                                redValue = (redValue * redFactor);

                                blueValue = (blueValue > 255 ? 255 :
                                            (blueValue < 0 ? 0 : blueValue));

                                greenValue = (greenValue > 255 ? 255 :
                                             (greenValue < 0 ? 0 : greenValue));

                                redValue = (redValue > 255 ? 255 :
                                           (redValue < 0 ? 0 : redValue));
                            }
                        }
                    }    //Step 4: Exlclude noise using global
                         //        threshold
                         //Step 2: Compare newly calculated
                         //        matrix and image masks
                    else if (matrixVariance > threshold && 
                             edgeMasks.Contains(matrixPatern))
                    {
                        blueValue = 255;
                        greenValue = 255;
                        redValue = 255;
                    }
                    else
                    {
                        blueValue = 0;
                        greenValue = 0;
                        redValue = 0;
                    }

                    resultBuffer[byteOffset] = (byte)blueValue;
                    resultBuffer[byteOffset + 1] = (byte)greenValue;
                    resultBuffer[byteOffset + 2] = (byte)redValue;
                    resultBuffer[byteOffset + 3] = 255;  
                }
            }

            System.Drawing.Bitmap resultBitmap = new System.Drawing.Bitmap(sourceBitmap.Width,
                                             sourceBitmap.Height);

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

        /// <summary>
        /// Boolean Filter Type
        /// </summary>
        public enum BooleanFilterType
        {
            None,
            EdgeDetect,
            Sharpen
        }
    }  
}
