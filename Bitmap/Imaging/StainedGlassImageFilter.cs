// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="StainedGlassImageFilter.cs" company="Zeroit Dev Technologies">
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
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.Utilities.BitmapUtils.Imaging
{
    /// <summary>
    /// A class collection for stained glass image filter
    /// </summary>
    public static class StainedGlassImageFilter
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
        /// Gradient Based Edge Detection Filter
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="edgeColour">Set edge color</param>
        /// <param name="threshold">Set threshold</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap GradientBasedEdgeDetectionFilter(
                        this System.Drawing.Bitmap sourceBitmap,
                        Color edgeColour,
                        byte threshold = 0)
        {
            BitmapData sourceData =
                       sourceBitmap.LockBits(new Rectangle(0, 0,
                       sourceBitmap.Width, sourceBitmap.Height),
                       ImageLockMode.ReadOnly,
                       PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            Marshal.Copy(sourceData.Scan0, resultBuffer, 0, resultBuffer.Length);

            sourceBitmap.UnlockBits(sourceData);

            int sourceOffset = 0, gradientValue = 0;
            bool exceedsThreshold = false;

            for (int offsetY = 1; offsetY < sourceBitmap.Height - 1; offsetY++)
            {
                for (int offsetX = 1; offsetX < sourceBitmap.Width - 1; offsetX++)
                {
                    sourceOffset = offsetY * sourceData.Stride + offsetX * 4;
                    gradientValue = 0;
                    exceedsThreshold = true;

                    // Horizontal Gradient
                    CheckThreshold(pixelBuffer,
                                   sourceOffset - 4,
                                   sourceOffset + 4,
                                   ref gradientValue, threshold, 2);
                    // Vertical Gradient
                    exceedsThreshold =
                    CheckThreshold(pixelBuffer,
                                   sourceOffset - sourceData.Stride,
                                   sourceOffset + sourceData.Stride,
                                   ref gradientValue, threshold, 2);

                    if (exceedsThreshold == false)
                    {
                        gradientValue = 0;

                        // Horizontal Gradient
                        exceedsThreshold =
                        CheckThreshold(pixelBuffer,
                                       sourceOffset - 4,
                                       sourceOffset + 4,
                                       ref gradientValue, threshold);

                        if (exceedsThreshold == false)
                        {
                            gradientValue = 0;

                            // Vertical Gradient
                            exceedsThreshold =
                            CheckThreshold(pixelBuffer,
                                           sourceOffset - sourceData.Stride,
                                           sourceOffset + sourceData.Stride,
                                           ref gradientValue, threshold);

                            if (exceedsThreshold == false)
                            {
                                gradientValue = 0;

                                // Diagonal Gradient : NW-SE
                                CheckThreshold(pixelBuffer,
                                               sourceOffset - 4 - sourceData.Stride,
                                               sourceOffset + 4 + sourceData.Stride,
                                               ref gradientValue, threshold, 2);
                                // Diagonal Gradient : NE-SW
                                exceedsThreshold =
                                CheckThreshold(pixelBuffer,
                                               sourceOffset - sourceData.Stride + 4,
                                               sourceOffset - 4 + sourceData.Stride,
                                               ref gradientValue, threshold, 2);

                                if (exceedsThreshold == false)
                                {
                                    gradientValue = 0;

                                    // Diagonal Gradient : NW-SE
                                    exceedsThreshold =
                                    CheckThreshold(pixelBuffer,
                                                   sourceOffset - 4 - sourceData.Stride,
                                                   sourceOffset + 4 + sourceData.Stride,
                                                   ref gradientValue, threshold);

                                    if (exceedsThreshold == false)
                                    {
                                        gradientValue = 0;

                                        // Diagonal Gradient : NE-SW
                                        exceedsThreshold =
                                        CheckThreshold(pixelBuffer,
                                                       sourceOffset - sourceData.Stride + 4,
                                                       sourceOffset + sourceData.Stride - 4,
                                                       ref gradientValue, threshold);
                                    }
                                }
                            }
                        }
                    }

                    if (exceedsThreshold == true)
                    {
                        resultBuffer[sourceOffset] = edgeColour.B;
                        resultBuffer[sourceOffset + 1] = edgeColour.G;
                        resultBuffer[sourceOffset + 2] = edgeColour.R;
                    }

                    resultBuffer[sourceOffset + 3] = 255;
                }
            }

            System.Drawing.Bitmap resultBitmap = new System.Drawing.Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                    resultBitmap.Width, resultBitmap.Height),
                                    ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        private static bool CheckThreshold(byte[] pixelBuffer,
                                           int offset1, int offset2,
                                           ref int gradientValue,
                                           byte threshold,
                                           int divideBy = 1)
        {
            gradientValue +=
            Math.Abs(pixelBuffer[offset1] -
            pixelBuffer[offset2]) / divideBy;

            gradientValue +=
            Math.Abs(pixelBuffer[offset1 + 1] -
            pixelBuffer[offset2 + 1]) / divideBy;

            gradientValue +=
            Math.Abs(pixelBuffer[offset1 + 2] -
            pixelBuffer[offset2 + 2]) / divideBy;

            return (gradientValue >= threshold);
        }

        private static byte ClipByte(double color)
        {
            return (byte)(color > 255 ? 255 :
                   (color < 0 ? 0 : color));
        }

        /// <summary>
        /// Stained Glass Color Filter
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="blockSize">Set block size</param>
        /// <param name="blockFactor">Set block factor</param>
        /// <param name="distanceType">Set distance type</param>
        /// <param name="highlightEdges">Highlight Edges</param>
        /// <param name="edgeThreshold">Set edge threshold</param>
        /// <param name="edgeColor">Set edge color</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap StainedGlassColorFilter(this System.Drawing.Bitmap sourceBitmap, 
                                                     int blockSize, double blockFactor,
                                                     DistanceFormulaType distanceType,
                                                     bool highlightEdges, 
                                                     byte edgeThreshold, Color edgeColor)
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

            int neighbourHoodTotal = 0;
            int sourceOffset = 0;
            int resultOffset = 0;
            int currentPixelDistance = 0;
            int nearestPixelDistance = 0;
            int nearesttPointIndex = 0;

            Random randomizer = new Random();

            List<VoronoiPoint> randomPointList = new List<VoronoiPoint>();

            for (int row = 0; row < sourceBitmap.Height - blockSize; row += blockSize)
            {
                for (int col = 0; col < sourceBitmap.Width - blockSize; col += blockSize)
                {
                    sourceOffset = row * sourceData.Stride + col * 4;

                    neighbourHoodTotal = 0;

                    for (int y = 0; y < blockSize; y++)
                    {
                        for (int x = 0; x < blockSize; x++)
                        {
                            resultOffset = sourceOffset + y * sourceData.Stride + x * 4;
                            neighbourHoodTotal += pixelBuffer[resultOffset];
                            neighbourHoodTotal += pixelBuffer[resultOffset + 1];
                            neighbourHoodTotal += pixelBuffer[resultOffset + 2];
                        }
                    }

                    randomizer = new Random(neighbourHoodTotal);

                    VoronoiPoint randomPoint = new VoronoiPoint();
                    randomPoint.XOffset = randomizer.Next(0, blockSize) + col;
                    randomPoint.YOffset = randomizer.Next(0, blockSize) + row;

                    randomPointList.Add(randomPoint);
                }
            }

            int rowOffset = 0;
            int colOffset = 0;

            for (int bufferOffset = 0; bufferOffset < pixelBuffer.Length - 4; bufferOffset += 4)
            {
                rowOffset = bufferOffset / sourceData.Stride;
                colOffset = (bufferOffset % sourceData.Stride) / 4;

                currentPixelDistance = 0;
                nearestPixelDistance = blockSize * 4;
                nearesttPointIndex = 0;

                List<VoronoiPoint> pointSubset = new List<VoronoiPoint>();

                pointSubset.AddRange(from t in randomPointList 
                                     where 
                                     rowOffset >= t.YOffset - blockSize * 2 &&
                                     rowOffset <= t.YOffset + blockSize * 2 
                                     select t);

                for (int k = 0; k < pointSubset.Count; k++)
                {
                    if (distanceType == DistanceFormulaType.Euclidean)
                    {
                        currentPixelDistance = 
                        CalculateDistanceEuclidean(pointSubset[k].XOffset, 
                             colOffset, pointSubset[k].YOffset, rowOffset);
                    }
                    else if (distanceType == DistanceFormulaType.Manhattan)
                    {
                        currentPixelDistance = 
                        CalculateDistanceManhattan(pointSubset[k].XOffset, 
                             colOffset, pointSubset[k].YOffset, rowOffset);
                    }
                    else if (distanceType == DistanceFormulaType.Chebyshev)
                    {
                        currentPixelDistance = 
                        CalculateDistanceChebyshev(pointSubset[k].XOffset, 
                             colOffset, pointSubset[k].YOffset, rowOffset);
                    }

                    if (currentPixelDistance <= nearestPixelDistance)
                    {
                        nearestPixelDistance = currentPixelDistance;
                        nearesttPointIndex = k;

                        if (nearestPixelDistance <= blockSize / blockFactor)
                        {
                            break;
                        }
                    }
                }

                Pixel tmpPixel = new Pixel();
                tmpPixel.XOffset = colOffset;
                tmpPixel.YOffset = rowOffset;
                tmpPixel.Blue = pixelBuffer[bufferOffset];
                tmpPixel.Green = pixelBuffer[bufferOffset + 1];
                tmpPixel.Red = pixelBuffer[bufferOffset + 2];

                pointSubset[nearesttPointIndex].AddPixel(tmpPixel);

            }

            for (int k = 0; k < randomPointList.Count; k++)
            {
                randomPointList[k].CalculateAverages();

                for (int i = 0; i < randomPointList[k].PixelCollection.Count; i++)
                {
                    resultOffset = randomPointList[k].PixelCollection[i].YOffset * 
                                   sourceData.Stride + 
                                   randomPointList[k].PixelCollection[i].XOffset * 4;

                    resultBuffer[resultOffset] = (byte)randomPointList[k].BlueAverage;
                    resultBuffer[resultOffset + 1] = (byte)randomPointList[k].GreenAverage;
                    resultBuffer[resultOffset + 2] = (byte)randomPointList[k].RedAverage;

                    resultBuffer[resultOffset + 3] = 255;
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

            if (highlightEdges == true)
            {
                resultBitmap = 
                resultBitmap.GradientBasedEdgeDetectionFilter(edgeColor, edgeThreshold);
            }

            return resultBitmap;
        }

        private static Dictionary<int, int> squareRoots = new Dictionary<int, int>();

        private static int CalculateDistanceEuclidean(int x1, int x2, int y1, int y2)
        {
            int square = (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2);

            if (squareRoots.ContainsKey(square) == false)
            {
                squareRoots.Add(square, (int)Math.Sqrt(square));
            }

            return squareRoots[square];
        }

        private static int CalculateDistanceManhattan(int x1, int x2, int y1, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

        private static int CalculateDistanceChebyshev(int x1, int x2, int y1, int y2)
        {
            return Math.Max(Math.Abs(x1 - x2), Math.Abs(y1 - y2));
        }

        /// <summary>
        /// Distance Formula Type
        /// </summary>
        public enum DistanceFormulaType
        {
            Euclidean,
            Manhattan,
            Chebyshev
        }

        /// <summary>
        /// A class collection for Pixel
        /// </summary>
        public class Pixel
        {
            private int xOffset = 0;

            /// <summary>
            /// Get X Offset
            /// </summary>
            public int XOffset
            {
                get { return xOffset; }  set { xOffset = value; }
            }

            private int yOffset = 0;

            /// <summary>
            /// Get Y Offset
            /// </summary>
            public int YOffset
            {
                get { return yOffset; } set { yOffset = value; }
            }

            private byte blue = 0;

            /// <summary>
            /// Get Blue
            /// </summary>
            public byte Blue
            {
                get { return blue; } set { blue = value; }
            }

            private byte green = 0;

            /// <summary>
            /// Get Green
            /// </summary>
            public byte Green
            {
                get { return green; } set { green = value; }
            }

            private byte red = 0;

            /// <summary>
            /// Get Red
            /// </summary>
            public byte Red
            {
                get { return red; } set { red = value; }
            }
        }

        /// <summary>
        /// A class collection for VoronoiPoint
        /// </summary>
        public class VoronoiPoint
        {
            private int xOffset = 0;

            /// <summary>
            /// Get X Offset
            /// </summary>
            public int XOffset
            {
                get { return xOffset; } set { xOffset = value; }
            }

            private int yOffset = 0;

            /// <summary>
            /// Get Y Offset
            /// </summary>
            public int YOffset
            {
                get { return yOffset; } set { yOffset = value; }
            }

            private int blueTotal = 0;

            /// <summary>
            /// Get Blue Total
            /// </summary>
            public int BlueTotal
            {
                get { return blueTotal; } set { blueTotal = value; }
            }

            private int greenTotal = 0;

            /// <summary>
            /// Get Green Total
            /// </summary>
            public int GreenTotal
            {
                get { return greenTotal; } set { greenTotal = value; }
            }

            private int redTotal = 0;

            /// <summary>
            /// Get Red Total
            /// </summary>
            public int RedTotal
            {
                get { return redTotal; } set { redTotal = value; }
            }

            /// <summary>
            /// Calculate Averages
            /// </summary>
            public void CalculateAverages()
            {
                if (pixelCollection.Count > 0)
                {
                    blueAverage = blueTotal / pixelCollection.Count;
                    greenAverage = greenTotal / pixelCollection.Count;
                    redAverage = redTotal / pixelCollection.Count;
                }
            }

            private int blueAverage = 0;

            /// <summary>
            /// Get Blue Average
            /// </summary>
            public int BlueAverage
            {
                get { return blueAverage; }
            }

            private int greenAverage = 0;

            /// <summary>
            /// Get Green Average
            /// </summary>
            public int GreenAverage
            {
                get { return greenAverage; }
            }

            private int redAverage = 0;

            /// <summary>
            /// Get Red Average
            /// </summary>
            public int RedAverage
            {
                get { return redAverage; }
            }

            private List<Pixel> pixelCollection = new List<Pixel>();

            /// <summary>
            /// Get Pixel Collection
            /// </summary>
            public List<Pixel> PixelCollection
            {
                get { return pixelCollection; }
            }

            /// <summary>
            /// Add Pixel
            /// </summary>
            public void AddPixel(Pixel pixel)
            {
                blueTotal += pixel.Blue;
                greenTotal += pixel.Green;
                redTotal += pixel.Red;

                pixelCollection.Add(pixel);
            }
        }
    }  
}
