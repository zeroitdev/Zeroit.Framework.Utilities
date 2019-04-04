// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Base64Bitmaps.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using System.Drawing.Imaging;

namespace Zeroit.Framework.Utilities.BitmapUtils.Imaging
{
    /// <summary>
    /// Class for converting Image to String and String to Image in Base 64.
    /// </summary>
    public static class Base64Bitmaps
    {
        /// <summary>
        /// Convert to Base 64 String
        /// </summary>
        /// <param name="bmp">Set Bitmap</param>
        /// <param name="imageFormat">Set Image Format</param>
        /// <returns></returns>
        public static string ConvertToBase64String(this System.Drawing.Bitmap bmp, ImageFormat imageFormat)
        {
            string base64String = string.Empty;

            MemoryStream memoryStream = new MemoryStream();
            bmp.Save(memoryStream, imageFormat);

            memoryStream.Position = 0;
            byte[] byteBuffer = memoryStream.ToArray();

            memoryStream.Close();

            base64String = Convert.ToBase64String(byteBuffer);
            byteBuffer = null;

            return base64String;
        }

        /// <summary>
        /// Convert to Base 64 Image
        /// </summary>
        /// <param name="bmp">Set Bitmap</param>
        /// <param name="imageFormat">Set Image Format</param>
        /// <returns></returns>
        public static string ToBase64ImageTag(this System.Drawing.Bitmap bmp, ImageFormat imageFormat)
        {
            string imgTag = string.Empty;
            string base64String = string.Empty;

            base64String = bmp.ConvertToBase64String(imageFormat);

            imgTag = "<img src=\"data:image/" + imageFormat.ToString() + ";base64,";
            imgTag += base64String + "\" ";
            imgTag += "width=\"" + bmp.Width.ToString() + "\" ";
            imgTag += "height=\"" + bmp.Height.ToString() + "\" />";

            return imgTag;
        }
    }
}
