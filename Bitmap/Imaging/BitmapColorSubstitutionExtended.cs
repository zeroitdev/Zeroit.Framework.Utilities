// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="BitmapColorSubstitutionExtended.cs" company="Zeroit Dev Technologies">
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

using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.BitmapUtils.Imaging
{
    /// <summary>
    /// A class for Bitmap Color Substitution (Extended Version)
    /// </summary>
    public static class BitmapColorSubstitutionExtended
    {

        /// <summary>
        /// Color Substitution
        /// </summary>
        /// <param name="sourceBitmap">Set source bitmap</param>
        /// <param name="filterData">Set color substitution</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap ColorSubstitution(this System.Drawing.Bitmap sourceBitmap, ColorSubstitutionExtended filterData)
        {
            System.Drawing.Bitmap resultBitmap = new System.Drawing.Bitmap(sourceBitmap.Width, sourceBitmap.Height, PixelFormat.Format32bppArgb);

            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            byte[] resultBuffer = new byte[resultData.Stride * resultData.Height];
            Marshal.Copy(sourceData.Scan0, resultBuffer, 0, resultBuffer.Length);

            sourceBitmap.UnlockBits(sourceData);

            byte sourceRed = 0, sourceGreen = 0, sourceBlue = 0, sourceAlpha = 0;
            int resultRed = 0, resultGreen = 0, resultBlue = 0;

            byte newRedValue = filterData.NewColor.R;
            byte newGreenValue = filterData.NewColor.G;
            byte newBlueValue = filterData.NewColor.B;

            byte redFilter = filterData.SourceColor.R;
            byte greenFilter = filterData.SourceColor.G;
            byte blueFilter = filterData.SourceColor.B;

            byte minValue = 0;
            byte maxValue = 255;

            for (int k = 0; k < resultBuffer.Length; k += 4)
            {
                sourceAlpha = resultBuffer[k + 3];

                if (sourceAlpha != 0)
                {
                    sourceBlue = resultBuffer[k];
                    sourceGreen = resultBuffer[k + 1];
                    sourceRed = resultBuffer[k + 2];

                    if ((sourceBlue < blueFilter + filterData.ThresholdValue &&
                            sourceBlue > blueFilter - filterData.ThresholdValue) &&

                        (sourceGreen < greenFilter + filterData.ThresholdValue &&
                            sourceGreen > greenFilter - filterData.ThresholdValue) &&

                        (sourceRed < redFilter + filterData.ThresholdValue &&
                            sourceRed > redFilter - filterData.ThresholdValue))
                    {
                        resultBlue = blueFilter - sourceBlue + newBlueValue;

                        if (resultBlue > maxValue)
                        { resultBlue = maxValue; }
                        else if (resultBlue < minValue)
                        { resultBlue = minValue; }

                        resultGreen = greenFilter - sourceGreen + newGreenValue;

                        if (resultGreen > maxValue)
                        { resultGreen = maxValue; }
                        else if (resultGreen < minValue)
                        { resultGreen = minValue; }

                        resultRed = redFilter - sourceRed + newRedValue;

                        if (resultRed > maxValue)
                        { resultRed = maxValue; }
                        else if (resultRed < minValue)
                        { resultRed = minValue; }

                        resultBuffer[k] = (byte)resultBlue;
                        resultBuffer[k + 1] = (byte)resultGreen;
                        resultBuffer[k + 2] = (byte)resultRed;
                        resultBuffer[k + 3] = sourceAlpha;
                    }
                }
            }

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        /// <summary>
        /// Bitmap Copy
        /// </summary>
        /// <param name="sourceBitmap">Set source bitmap</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap Format32bppArgbCopy(this System.Drawing.Bitmap sourceBitmap)
        {
            System.Drawing.Bitmap copyBitmap = new System.Drawing.Bitmap(sourceBitmap.Width, sourceBitmap.Height, PixelFormat.Format32bppArgb);
            
            using (System.Drawing.Graphics graphicsObject = System.Drawing.Graphics.FromImage(copyBitmap))
            {
                graphicsObject.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphicsObject.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphicsObject.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                graphicsObject.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                
                graphicsObject.DrawImage(sourceBitmap, new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), GraphicsUnit.Pixel);
            }

            return copyBitmap;
        }
    }

    public class ColorSubstitutionExtended
    {
        private int thresholdValue = 10;

        /// <summary>
        /// Set Threshold Value
        /// </summary>
        public int ThresholdValue
        {
            get { return thresholdValue; }
            set { thresholdValue = value; }
        }

        private Color sourceColor = Color.White;

        /// <summary>
        /// Set source color
        /// </summary>
        public Color SourceColor
        {
            get { return sourceColor; }
            set { sourceColor = value; }
        }

        private Color newColor = Color.White;

        /// <summary>
        /// Set New Color
        /// </summary>
        public Color NewColor
        {
            get { return newColor; }
            set { newColor = value; }
        }
    }
}
