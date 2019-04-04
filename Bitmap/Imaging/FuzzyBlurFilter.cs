// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="FuzzyBlurFilter.cs" company="Zeroit Dev Technologies">
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
    /// A class collection of Fuzzy Blur Filter
    /// </summary>
    public static class FuzzyBlurFilter
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
        /// Fuzzy Edge Blur Filter
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="filterSize">Set Filter size</param>
        /// <param name="edgeFactor1">Set edge factor 1</param>
        /// <param name="edgeFactor2">Set edge factor 2</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap FuzzyEdgeBlurFilter(this System.Drawing.Bitmap sourceBitmap, 
                                                 int filterSize, 
                                                 float edgeFactor1, 
                                                 float edgeFactor2)
        {
            return 
            sourceBitmap.BooleanEdgeDetectionFilter(edgeFactor1).
            MeanFilter(filterSize).BooleanEdgeDetectionFilter(edgeFactor2);
        }

        /// <summary>
        /// Boolean Edge Detection Filter
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="edgeFactor">Set edge factor</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap BooleanEdgeDetectionFilter(
               this System.Drawing.Bitmap sourceBitmap, float edgeFactor)
        {
            byte[] pixelBuffer = sourceBitmap.GetByteArray();
            byte[] resultBuffer = new byte[pixelBuffer.Length];
            Buffer.BlockCopy(pixelBuffer, 0, resultBuffer,
                             0, pixelBuffer.Length);

            List<string> edgeMasks = GetBooleanEdgeMasks();

            int imageStride = sourceBitmap.Width * 4;
            int matrixMean = 0, pixelTotal = 0;
            int filterY = 0, filterX = 0, calcOffset = 0;
            string matrixPatern = String.Empty;

            for (int k = 0; k + 4 < pixelBuffer.Length; k += 4)
            {
                matrixPatern = String.Empty;
                matrixMean = 0; pixelTotal = 0;
                filterY = -1; filterX = -1;

                while (filterY < 2)
                {
                    calcOffset = k + (filterX * 4) +
                    (filterY * imageStride);

                    calcOffset = (calcOffset < 0 ? 0 :
                    (calcOffset >= pixelBuffer.Length - 2 ?
                    pixelBuffer.Length - 3 : calcOffset));

                    matrixMean += pixelBuffer[calcOffset];
                    matrixMean += pixelBuffer[calcOffset + 1];
                    matrixMean += pixelBuffer[calcOffset + 2];

                    filterX += 1;

                    if (filterX > 1)
                    { filterX = -1; filterY += 1; }
                }

                matrixMean = matrixMean / 9;
                filterY = -1; filterX = -1;

                while (filterY < 2)
                {
                    calcOffset = k + (filterX * 4) +
                    (filterY * imageStride);

                    calcOffset = (calcOffset < 0 ? 0 :
                    (calcOffset >= pixelBuffer.Length - 2 ?
                    pixelBuffer.Length - 3 : calcOffset));

                    pixelTotal = pixelBuffer[calcOffset];
                    pixelTotal += pixelBuffer[calcOffset + 1];
                    pixelTotal += pixelBuffer[calcOffset + 2];

                    matrixPatern += (pixelTotal > matrixMean
                                                 ? "1" : "0");
                    filterX += 1;

                    if (filterX > 1)
                    { filterX = -1; filterY += 1; }
                }

                if (edgeMasks.Contains(matrixPatern))
                {
                    resultBuffer[k] =
                    ClipByte(resultBuffer[k] * edgeFactor);

                    resultBuffer[k + 1] =
                    ClipByte(resultBuffer[k + 1] * edgeFactor);

                    resultBuffer[k + 2] =
                    ClipByte(resultBuffer[k + 2] * edgeFactor);
                }
            }

            return resultBuffer.GetImage(sourceBitmap.Width, sourceBitmap.Height);
        }

        /// <summary>
        /// Get Boolean Edge Masks
        /// </summary>
        /// <returns></returns>
        public static List<string> GetBooleanEdgeMasks()
        {
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
            edgeMasks.Add("110110100");

            return edgeMasks;
        }

        /// <summary>
        /// Mean Filter
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="meanSize">Set mean size</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap MeanFilter(this System.Drawing.Bitmap sourceBitmap,
                                         int meanSize)
        {
            byte[] pixelBuffer = sourceBitmap.GetByteArray();
            byte[] resultBuffer = new byte[pixelBuffer.Length];

            double blue = 0.0, green = 0.0, red = 0.0;
            double factor = 1.0 / (meanSize * meanSize);

            int imageStride = sourceBitmap.Width * 4;
            int filterOffset = meanSize / 2;
            int calcOffset = 0, filterY = 0, filterX = 0;

            for (int k = 0; k + 4 < pixelBuffer.Length; k += 4)
            {
                blue = 0; green = 0; red = 0;
                filterY = -filterOffset;
                filterX = -filterOffset;

                while (filterY <= filterOffset)
                {
                    calcOffset = k + (filterX * 4) +
                    (filterY * imageStride);

                    calcOffset = (calcOffset < 0 ? 0 :
                    (calcOffset >= pixelBuffer.Length - 2 ?
                    pixelBuffer.Length - 3 : calcOffset));

                    blue += pixelBuffer[calcOffset];
                    green += pixelBuffer[calcOffset + 1];
                    red += pixelBuffer[calcOffset + 2];

                    filterX++;
                    
                    if (filterX > filterOffset)
                    {
                        filterX = -filterOffset;
                        filterY++;
                    }
                }

                resultBuffer[k] = ClipByte(factor * blue);
                resultBuffer[k + 1] = ClipByte(factor * green);
                resultBuffer[k + 2] = ClipByte(factor * red);
                resultBuffer[k + 3] = 255;
            }

            return resultBuffer.GetImage(sourceBitmap.Width, sourceBitmap.Height);
        }

        /// <summary>
        /// Get Byte Array
        /// </summary>
        /// <param name="sourceBitmap"></param>
        /// <returns></returns>
        public static byte[] GetByteArray(this System.Drawing.Bitmap sourceBitmap)
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
        /// Get Image
        /// </summary>
        /// <param name="resultBuffer">Set buffer</param>
        /// <param name="width">Set width</param>
        /// <param name="height">Set height</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap GetImage(this byte[] resultBuffer, int width, int height)
        {
            System.Drawing.Bitmap resultBitmap = new System.Drawing.Bitmap(width, height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                    resultBitmap.Width, resultBitmap.Height),
                                    ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);

            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        /// <summary>
        /// Clip Byte
        /// </summary>
        /// <param name="colour">Set color value</param>
        /// <returns></returns>
        public static byte ClipByte(double colour)
        {
            return (byte)(colour > 255 ? 255 :
                   (colour < 0 ? 0 : colour));
        }
    }  
}
