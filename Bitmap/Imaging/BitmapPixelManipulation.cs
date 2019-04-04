// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="BitmapPixelManipulation.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
    /// A class for Bitmap Pixel Manipulation
    /// </summary>
    public static class BitmapPixelManipulation
    {

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
        /// Swap Colors
        /// </summary>
        /// <param name="sourceImage">Set source Bitmap</param>
        /// <param name="swapType">Set Swap Type</param>
        /// <param name="fixedValue">Set Fixed Value. Default is 0</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap SwapColors(this System.Drawing.Bitmap sourceImage, 
                                        ColourSwapType swapType, 
                                        byte fixedValue = 0)
        {
            List<ArgbPixel> pixelListSource = GetPixelListFromBitmap(sourceImage);

            List<ArgbPixel> pixelListResult = null;

            switch (swapType)
            {
                case ColourSwapType.ShiftRight:
                    {
                        pixelListResult = (from t in pixelListSource 
                                           select new ArgbPixel 
                        { blue = t.red, 
                          red = t.green, 
                          green = t.blue, 
                          alpha = t.alpha }).ToList();
                        break;
                    }
                case ColourSwapType.ShiftLeft:
                    {
                        pixelListResult = (from t in pixelListSource 
                                           select new ArgbPixel 
                        { blue = t.green, 
                           red = t.blue, 
                           green = t.red, 
                           alpha = t.alpha }).ToList();                        
                        break;
                    }
                case ColourSwapType.SwapBlueAndRed:
                    {
                        pixelListResult = (from t in pixelListSource
                                           select new ArgbPixel 
                        { blue = t.red, 
                          red = t.blue, 
                          green = t.green, 
                          alpha = t.alpha }).ToList();
                        break;
                    }
                case ColourSwapType.SwapBlueAndRedFixGreen:
                    {
                        pixelListResult = (from t in pixelListSource 
                                           select new ArgbPixel 
                        { blue = t.red, 
                          red = t.blue, 
                          green = fixedValue, 
                          alpha = t.alpha }).ToList();
                        break;
                    }
                case ColourSwapType.SwapBlueAndGreen:
                    {
                        pixelListResult = (from t in pixelListSource 
                                           select new ArgbPixel 
                        { blue = t.green, 
                          red = t.red, 
                          green = t.blue, 
                          alpha = t.alpha }).ToList();                        
                        break;
                    }
                case ColourSwapType.SwapBlueAndGreenFixRed:
                    {
                        pixelListResult = (from t in pixelListSource 
                                           select new ArgbPixel 
                        { blue = t.green, 
                          red = fixedValue,
                          green = t.blue, 
                          alpha = t.alpha }).ToList();
                        break;
                    }
                case ColourSwapType.SwapRedAndGreen:
                    {
                        pixelListResult = (from t in pixelListSource 
                                           select new ArgbPixel 
                        { blue = t.blue, 
                          red = t.green, 
                          green = t.red, 
                          alpha = t.alpha }).ToList();
                        break;
                    }
                case ColourSwapType.SwapRedAndGreenFixBlue:
                    {
                        pixelListResult = (from t in pixelListSource 
                                           select new ArgbPixel 
                        { blue = fixedValue, 
                          red = t.green, 
                          green = t.red, 
                          alpha = t.alpha }).ToList();
                        break;
                    }
            }

            System.Drawing.Bitmap resultBitmap = GetBitmapFromPixelList(pixelListResult, 
                                  sourceImage.Width, sourceImage.Height);

            return resultBitmap;
        }

        /// <summary>
        /// Get Bitmap From Pixel List
        /// </summary>
        /// <param name="pixelList">Set Argb Pixel List</param>
        /// <param name="width">Set width</param>
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

        private static List<ArgbPixel> GetPixelListFromBitmap(System.Drawing.Bitmap sourceImage)
        {
            BitmapData sourceData = sourceImage.LockBits(new Rectangle(0, 0, 
                        sourceImage.Width, sourceImage.Height), 
                        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] sourceBuffer = new byte[sourceData.Stride * sourceData.Height];
            Marshal.Copy(sourceData.Scan0, sourceBuffer, 0, sourceBuffer.Length);
            sourceImage.UnlockBits(sourceData);

            List<ArgbPixel> pixelList = new List<ArgbPixel>(sourceBuffer.Length / 4);

            using (MemoryStream memoryStream = new MemoryStream(sourceBuffer))
            {
                memoryStream.Position = 0;
                BinaryReader binaryReader = new BinaryReader(memoryStream);

                while (memoryStream.Position + 4 <= memoryStream.Length)
                {
                    ArgbPixel pixel = new ArgbPixel(binaryReader.ReadBytes(4));
                    pixelList.Add(pixel);
                }

                binaryReader.Close();
            }

            return pixelList;
        }

        /// <summary>
        /// A class collection of Argb Functionalities
        /// </summary>
        public class ArgbPixel
        {
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

            /// <summary>
            /// Get Color Bytes
            /// </summary>
            /// <returns></returns>
            public byte[] GetColorBytes()
            {
                return new byte[] {blue, green, red, alpha};
            }
        }
    }

    /// <summary>
    /// Color Swap Type
    /// </summary>
    public enum ColourSwapType
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
}
