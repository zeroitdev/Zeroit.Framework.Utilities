// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="BitmapPixelManipulationExtended.cs" company="Zeroit Dev Technologies">
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

using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;

namespace Zeroit.Framework.Utilities.BitmapUtils.Imaging
{
    /// <summary>
    /// A class for Bitmap Manipulation (Extended version)
    /// </summary>
    public static class BitmapPixelManipulationExtended
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
            int maxSide = sourceBitmap.Width > sourceBitmap.Height ? sourceBitmap.Width : sourceBitmap.Height;

            ratio = (float)maxSide / (float)canvasWidthLenght;

            System.Drawing.Bitmap bitmapResult = (sourceBitmap.Width > sourceBitmap.Height ? new System.Drawing.Bitmap(canvasWidthLenght, (int)(sourceBitmap.Height / ratio)) : new System.Drawing.Bitmap((int)(sourceBitmap.Width / ratio), canvasWidthLenght));

            using (System.Drawing.Graphics graphicsResult = System.Drawing.Graphics.FromImage(bitmapResult))
            {
                graphicsResult.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphicsResult.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphicsResult.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                graphicsResult.DrawImage(sourceBitmap, new Rectangle(0, 0, bitmapResult.Width, bitmapResult.Height), new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), GraphicsUnit.Pixel);
                graphicsResult.Flush();
            }

            return bitmapResult;
        }
        
        /// <summary>
        /// Flip Pixels
        /// </summary>
        /// <param name="sourceImage">Set source Bitmap</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap FlipPixels(this System.Drawing.Bitmap sourceImage)
        {
            List<ArgbPixel> pixelList = GetPixelListFromBitmap(sourceImage);

            pixelList.Reverse();

            System.Drawing.Bitmap resultBitmap = GetBitmapFromPixelList(pixelList,
                                sourceImage.Width, sourceImage.Height);

            return resultBitmap;
        }

        /// <summary>
        /// Invert Colors
        /// </summary>
        /// <param name="sourceImage">Set source Bitmap</param>
        /// <param name="inversionType">Set inversion Type</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap InvertColors(this System.Drawing.Bitmap sourceImage,
                                        ColourInversionType inversionType)
        {
            List<ArgbPixel> pixelListSource = GetPixelListFromBitmap(sourceImage);

            List<ArgbPixel> pixelListResult = null;

            byte byte255 = 255;

            switch (inversionType)
            {
                case ColourInversionType.All:
                    {
                        pixelListResult =
                        (from t in pixelListSource
                            select new ArgbPixel
                            {
                                blue = (byte)(byte255 - t.blue),
                                red = (byte)(byte255 - t.red),
                                green = (byte)(byte255 - t.green),
                                alpha = t.alpha,
                            }).ToList();

                        break;
                    }
                case ColourInversionType.Blue:
                    {
                        pixelListResult =
                        (from t in pixelListSource
                            select new ArgbPixel
                            {
                                blue = (byte)(byte255 - t.blue),
                                red = t.red,
                                green = t.green,
                                alpha = t.alpha,
                            }).ToList();

                        break;
                    }
                case ColourInversionType.Green:
                    {
                        pixelListResult =
                        (from t in pixelListSource
                            select new ArgbPixel
                            {
                                blue = t.blue,
                                red = t.red,
                                green = (byte)(byte255 - t.green),
                                alpha = t.alpha,
                            }).ToList();

                        break;
                    }
                case ColourInversionType.Red:
                    {
                        pixelListResult =
                        (from t in pixelListSource
                            select new ArgbPixel
                            {
                                blue = t.blue,
                                red = (byte)(byte255 - t.green),
                                green = t.green,
                                alpha = t.alpha,
                            }).ToList();

                        break;
                    }
                case ColourInversionType.BlueRed:
                    {
                        pixelListResult =
                        (from t in pixelListSource
                            select new ArgbPixel
                            {
                                blue = (byte)(byte255 - t.blue),
                                red = (byte)(byte255 - t.red),
                                green = t.green,
                                alpha = t.alpha,
                            }).ToList();

                        break;
                    }
                case ColourInversionType.BlueGreen:
                    {
                        pixelListResult =
                        (from t in pixelListSource
                            select new ArgbPixel
                            {
                                blue = (byte)(byte255 - t.blue),
                                red = t.red,
                                green = (byte)(byte255 - t.green),
                                alpha = t.alpha,
                            }).ToList();

                        break;
                    }
                case ColourInversionType.RedGreen:
                    {
                        pixelListResult =
                        (from t in pixelListSource
                            select new ArgbPixel
                            {
                                blue = t.blue,
                                red = (byte)(byte255 - t.blue),
                                green = (byte)(byte255 - t.green),
                                alpha = t.alpha,
                            }).ToList();

                        break;
                    }
            }

            System.Drawing.Bitmap resultBitmap = GetBitmapFromPixelList(pixelListResult,
                        sourceImage.Width, sourceImage.Height);

            return resultBitmap;
        }

        /// <summary>
        /// Swap Colors
        /// </summary>
        /// <param name="sourceImage">Set source Bitmap</param>
        /// <param name="swapType">Set Swap Type</param>
        /// <param name="fixedValue">Set Fixed Value</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap SwapColors(this System.Drawing.Bitmap sourceImage,
                                        ColorSwapType swapType,
                                        byte fixedValue = 0)
        {
            List<ArgbPixel> pixelListSource = GetPixelListFromBitmap(sourceImage);

            List<ArgbPixel> pixelListResult = null;

            switch (swapType)
            {
                case ColorSwapType.ShiftRight:
                    {
                        pixelListResult = (from t in pixelListSource
                                           select new ArgbPixel
                        {
                            blue = t.red,
                            red = t.green,
                            green = t.blue,
                            alpha = t.alpha
                        }).ToList();
                        break;
                    }
                case ColorSwapType.ShiftLeft:
                    {
                        pixelListResult = (from t in pixelListSource
                                           select new ArgbPixel
                        {
                            blue = t.green,
                            red = t.blue,
                            green = t.red,
                            alpha = t.alpha
                        }).ToList();
                        break;
                    }
                case ColorSwapType.SwapBlueAndRed:
                    {
                        pixelListResult = (from t in pixelListSource
                                           select new ArgbPixel
                        {
                            blue = t.red,
                            red = t.blue,
                            green = t.green,
                            alpha = t.alpha
                        }).ToList();
                        break;
                    }
                case ColorSwapType.SwapBlueAndRedFixGreen:
                    {
                        pixelListResult = (from t in pixelListSource
                                           select new ArgbPixel
                        {
                            blue = t.red,
                            red = t.blue,
                            green = fixedValue,
                            alpha = t.alpha
                        }).ToList();
                        break;
                    }
                case ColorSwapType.SwapBlueAndGreen:
                    {
                        pixelListResult = (from t in pixelListSource
                                           select new ArgbPixel
                        {
                            blue = t.green,
                            red = t.red,
                            green = t.blue,
                            alpha = t.alpha
                        }).ToList();
                        break;
                    }
                case ColorSwapType.SwapBlueAndGreenFixRed:
                    {
                        pixelListResult = (from t in pixelListSource
                                           select new ArgbPixel
                        {
                            blue = t.green,
                            red = fixedValue,
                            green = t.blue,
                            alpha = t.alpha
                        }).ToList();
                        break;
                    }
                case ColorSwapType.SwapRedAndGreen:
                    {
                        pixelListResult = (from t in pixelListSource
                                           select new ArgbPixel
                        {
                            blue = t.blue,
                            red = t.green,
                            green = t.red,
                            alpha = t.alpha
                        }).ToList();
                        break;
                    }
                case ColorSwapType.SwapRedAndGreenFixBlue:
                    {
                        pixelListResult = (from t in pixelListSource
                                           select new ArgbPixel
                        {
                            blue = fixedValue,
                            red = t.green,
                            green = t.red,
                            alpha = t.alpha
                        }).ToList();
                        break;
                    }
            }

            System.Drawing.Bitmap resultBitmap = GetBitmapFromPixelList(pixelListResult,
                                  sourceImage.Width, sourceImage.Height);

            return resultBitmap;
        }

        /// <summary>
        /// Get Bitmap from Pixel List
        /// </summary>
        /// <param name="pixelList">Set Argb Pixel List</param>
        /// <param name="width">Set Width</param>
        /// <param name="height">Set Height</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap GetBitmapFromPixelList(List<ArgbPixel> pixelList, int width, int height)
        {
            System.Drawing.Bitmap resultBitmap = new System.Drawing.Bitmap(width, height, PixelFormat.Format32bppArgb);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                        resultBitmap.Width, resultBitmap.Height),
                        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] resultBuffer = new byte[resultData.Stride * resultData.Height];

            using (MemoryStream memoryStream = new MemoryStream(resultBuffer))
            {
                memoryStream.Position = 0;
                BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

                foreach (ArgbPixel pixel in pixelList)
                {
                    binaryWriter.Write(pixel.GetColorBytes());
                }

                binaryWriter.Close();
            }

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        /// <summary>
        /// Get Pixel List From Bitmap
        /// </summary>
        /// <param name="sourceImage">Set source Bitmap</param>
        /// <returns></returns>
        public static List<ArgbPixel> GetPixelListFromBitmap(System.Drawing.Bitmap sourceImage)
        {
            BitmapData sourceData = sourceImage.LockBits(new Rectangle(0, 0,
                        sourceImage.Width, sourceImage.Height),
                        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] sourceBuffer = new byte[sourceData.Stride * sourceData.Height];
            Marshal.Copy(sourceData.Scan0, sourceBuffer, 0, sourceBuffer.Length);
            sourceImage.UnlockBits(sourceData);

            List<ArgbPixel> pixelList = new List<ArgbPixel>(sourceBuffer.Length / 4);

            int x = 0;
            int y = 0;

            using (MemoryStream memoryStream = new MemoryStream(sourceBuffer))
            {
                memoryStream.Position = 0;
                BinaryReader binaryReader = new BinaryReader(memoryStream);

                while (memoryStream.Position + 4 <= memoryStream.Length)
                {
                    ArgbPixel pixel = new ArgbPixel(binaryReader.ReadBytes(4), x, y);
                    pixelList.Add(pixel);

                    x += 1;

                    if (x >= sourceData.Width)
                    {
                        x = 0;
                        y += 1;
                    }
                }

                binaryReader.Close();
            }

            return pixelList;
        }

        /// <summary>
        /// Argb Pixel
        /// </summary>
        public class ArgbPixel
        {
            public int pixelX = 0;
            public int pixelY = 0;

            public byte blue = 0;
            public byte green = 0;
            public byte red = 0;
            public byte alpha = 0;

            public ArgbPixel()
            {

            }

            public ArgbPixel(byte[] colorComponents)
            {
                blue = colorComponents[0];
                green = colorComponents[1];
                red = colorComponents[2];
                alpha = colorComponents[3];
            }

            public ArgbPixel(byte[] colorComponents, int x, int y)
            {
                blue = colorComponents[0];
                green = colorComponents[1];
                red = colorComponents[2];
                alpha = colorComponents[3];

                pixelX = x;
                pixelY = y;
            }

            public byte[] GetColorBytes()
            {
                return new byte[] { blue, green, red, alpha };
            }

            public byte this[int index]
            {
                get
                {
                    switch (index)
                    {
                        case 0: return blue;
                        case 1: return green;
                        case 2: return red;
                        case 3: return alpha;
                        default: return 0;
                    }
                }
            }
        }
    }

    public enum ColorSwapType
    {
        ShiftRight,
        ShiftLeft,
        SwapBlueAndRed,
        SwapBlueAndRedFixGreen,
        SwapBlueAndGreen,
        SwapBlueAndGreenFixRed,
        SwapRedAndGreen,
        SwapRedAndGreenFixBlue
    }

    /// <summary>
    /// Color Conversion Type
    /// </summary>

    public enum ColourInversionType
    {
        All,
        Blue,
        Green,
        Red,
        BlueRed,
        BlueGreen,
        RedGreen,
    }
}
