// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="MorphologicalEdgeDetection.cs" company="Zeroit Dev Technologies">
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
    /// A class collection for Morphological Edge Detection
    /// </summary>
    public static class MorphologicalEdgeDetection
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
        /// Open Morphology Filter
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="matrixSize">Set Matrix Size</param>
        /// <param name="applyBlue">Apply Blue</param>
        /// <param name="applyGreen">Apply Green</param>
        /// <param name="applyRed">Apply Red</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap OpenMorphologyFilter(this System.Drawing.Bitmap sourceBitmap,
                                                  int matrixSize,
                                                  bool applyBlue = true,
                                                  bool applyGreen = true,
                                                  bool applyRed = true)
        {
            System.Drawing.Bitmap resultBitmap = sourceBitmap.DilateAndErodeFilter(matrixSize, 
                                                        MorphologyType.Erosion,
                                               applyBlue, applyGreen, applyRed);

            resultBitmap = resultBitmap.DilateAndErodeFilter(matrixSize, 
                                                MorphologyType.Dilation, 
                                               applyBlue, applyGreen, applyRed);

            return resultBitmap;
        }

        /// <summary>
        /// Close Morphology Filter
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="matrixSize">Set Matrix Size</param>
        /// <param name="applyBlue">Apply Blue</param>
        /// <param name="applyGreen">Apply Green</param>
        /// <param name="applyRed">Apply Red</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap CloseMorphologyFilter(this System.Drawing.Bitmap sourceBitmap,
                                                   int matrixSize,
                                                   bool applyBlue = true,
                                                   bool applyGreen = true,
                                                   bool applyRed = true)
        {
            System.Drawing.Bitmap resultBitmap = sourceBitmap.DilateAndErodeFilter(matrixSize,
                                                        MorphologyType.Dilation,
                                                applyBlue, applyGreen, applyRed);

            resultBitmap = resultBitmap.DilateAndErodeFilter(matrixSize,
                                                 MorphologyType.Erosion, 
                                                applyBlue, applyGreen, applyRed);

            return resultBitmap;
        }


        /// <summary>
        /// Dilate And Erode Filter
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="matrixSize">Set matrix size</param>
        /// <param name="morphType">Set Morphology Type</param>
        /// <param name="applyBlue">Apply Blue</param>
        /// <param name="applyGreen">Apply Green</param>
        /// <param name="applyRed">Apply Red</param>
        /// <param name="edgeType">Morphology Edge Type</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap DilateAndErodeFilter(this System.Drawing.Bitmap sourceBitmap, 
                                                int matrixSize,
                                                MorphologyType morphType,
                                                bool applyBlue = true,
                                                bool applyGreen = true,
                                                bool applyRed = true,
                                                MorphologyEdgeType edgeType =
                                                MorphologyEdgeType.None) 
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

            int filterOffset = (matrixSize - 1) / 2;
            int calcOffset = 0;

            int byteOffset = 0;

            int blue = 0;
            int green = 0;
            int red = 0;

            byte morphResetValue = 0;

            if (morphType == MorphologyType.Erosion)
            {
                morphResetValue = 255;
            }

            for (int offsetY = filterOffset; offsetY < 
                sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX < 
                    sourceBitmap.Width - filterOffset; offsetX++)
                {
                    byteOffset = offsetY * 
                                 sourceData.Stride + 
                                 offsetX * 4;

                    blue = morphResetValue;
                    green = morphResetValue;
                    red = morphResetValue;

                    if (morphType == MorphologyType.Dilation)
                    {
                        for (int filterY = -filterOffset;
                            filterY <= filterOffset; filterY++)
                        {
                            for (int filterX = -filterOffset;
                                filterX <= filterOffset; filterX++)
                            {
                                calcOffset = byteOffset +
                                             (filterX * 4) +
                                (filterY * sourceData.Stride);

                                if (pixelBuffer[calcOffset] > blue)
                                {
                                    blue = pixelBuffer[calcOffset];
                                }

                                if (pixelBuffer[calcOffset + 1] > green)
                                {
                                    green = pixelBuffer[calcOffset + 1];
                                }

                                if (pixelBuffer[calcOffset + 2] > red)
                                {
                                    red = pixelBuffer[calcOffset + 2];
                                }
                            }
                        }
                    }
                    else if (morphType == MorphologyType.Erosion)
                    {
                        for (int filterY = -filterOffset;
                            filterY <= filterOffset; filterY++)
                        {
                            for (int filterX = -filterOffset;
                                filterX <= filterOffset; filterX++)
                            {
                                calcOffset = byteOffset +
                                             (filterX * 4) +
                                (filterY * sourceData.Stride);

                                if (pixelBuffer[calcOffset] < blue)
                                {
                                    blue = pixelBuffer[calcOffset];
                                }

                                if (pixelBuffer[calcOffset + 1] < green)
                                {
                                    green = pixelBuffer[calcOffset + 1];
                                }

                                if (pixelBuffer[calcOffset + 2] < red)
                                {
                                    red = pixelBuffer[calcOffset + 2];
                                }
                            }
                        }
                    }

                    if (applyBlue == false)
                    {
                        blue = pixelBuffer[byteOffset];
                    }

                    if (applyGreen == false)
                    {
                        green = pixelBuffer[byteOffset + 1];
                    }

                    if (applyRed == false)
                    {
                        red = pixelBuffer[byteOffset + 2];
                    }

                    if (edgeType == MorphologyEdgeType.EdgeDetection || 
                        edgeType == MorphologyEdgeType.SharpenEdgeDetection)
                    {
                        if (morphType == MorphologyType.Dilation)
                        {
                            blue = blue - pixelBuffer[byteOffset];
                            green = green - pixelBuffer[byteOffset + 1];
                            red = red - pixelBuffer[byteOffset + 2];
                        }
                        else if (morphType == MorphologyType.Erosion)
                        {
                            blue = pixelBuffer[byteOffset] - blue;
                            green = pixelBuffer[byteOffset + 1] - green;
                            red = pixelBuffer[byteOffset + 2] - red;
                        }

                        if (edgeType == MorphologyEdgeType.SharpenEdgeDetection)
                        {
                            blue += pixelBuffer[byteOffset];
                            green += pixelBuffer[byteOffset + 1];
                            red += pixelBuffer[byteOffset + 2];
                        }
                    }

                    blue = (blue > 255 ? 255 : (blue < 0 ? 0 : blue));
                    green = (green > 255 ? 255 : (green < 0 ? 0 : green));
                    red = (red > 255 ? 255 : (red < 0 ? 0 : red));

                    resultBuffer[byteOffset] = (byte)blue;
                    resultBuffer[byteOffset + 1] = (byte)green;
                    resultBuffer[byteOffset + 2] = (byte)red;
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
        /// Morphology Type Enum
        /// </summary>
        public enum MorphologyType
        {
            Dilation,
            Erosion
        }

        /// <summary>
        /// Morphology Edge Type Enum
        /// </summary>
        public enum MorphologyEdgeType
        {
            None,
            EdgeDetection,
            SharpenEdgeDetection
        }
    }  
}
