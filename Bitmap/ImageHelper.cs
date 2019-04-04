// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ImageHelper.cs" company="Zeroit Dev Technologies">
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
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Zeroit.Framework.Utilities.BitmapUtils
{
    /// <summary>
    /// Class for helping in image creation
    /// </summary>
    public static class ImageHelper
    {
        private static float[][] _colorMatrixElements = {
                                            new float[] {(float)0.299, (float)0.299, (float)0.299, 0, 0},
                                            new float[] {(float)0.587, (float)0.587, (float)0.587, 0, 0},
                                            new float[] {(float)0.114, (float)0.114, (float)0.114, 0, 0},
                                            new float[] {0,  0,  0,  1, 0},
                                            new float[] {0, 0, 0, 0, 1}
                                        };

        private static ColorMatrix _grayscaleColorMatrix = new ColorMatrix(_colorMatrixElements);


        /// <summary>
        /// Gray scale attributes
        /// </summary>
        /// <returns></returns>
        public static ImageAttributes GetGrayscaleAttributes()
        {
            ImageAttributes attr = new ImageAttributes();
            attr.SetColorMatrix(_grayscaleColorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            return attr;
        }

        /// <summary>
        /// Rescale Image to Fit
        /// </summary>
        /// <param name="imageSize">Image size</param>
        /// <param name="canvasSize">Canvas size</param>
        /// <returns></returns>
        public static Size RescaleImageToFit(Size imageSize, Size canvasSize)
        {
            //Code "borrowed" from http://stackoverflow.com/questions/1940581/c-sharp-image-resizing-to-different-size-while-preserving-aspect-ratio
            // and the Math.Min improvement from http://stackoverflow.com/questions/6501797/resize-image-proportionally-with-maxheight-and-maxwidth-constraints

            // Figure out the ratio
            double ratioX = (double)canvasSize.Width / (double)imageSize.Width;
            double ratioY = (double)canvasSize.Height / (double)imageSize.Height;

            // use whichever multiplier is smaller
            double ratio = Math.Min(ratioX, ratioY);

            // now we can get the new height and width
            int newHeight = Convert.ToInt32(imageSize.Height * ratio);
            int newWidth = Convert.ToInt32(imageSize.Width * ratio);

            Size resizedSize = new Size(newWidth, newHeight);

            if (resizedSize.Width > canvasSize.Width || resizedSize.Height > canvasSize.Height)
            {
                throw new Exception("ImageHelper.RescaleImageToFit - Resize failed!");
            }

            return resizedSize;
        }
    }

}
