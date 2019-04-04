// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Base64ToBitmap.cs" company="Zeroit Dev Technologies">
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
    /// A class to convert Base 64 to Bitmap
    /// </summary>
    public static class Base64ToBitmap
    {
        /// <summary>
        /// Convert To Base 64 String
        /// </summary>
        /// <param name="bmp">Set Bitmap</param>
        /// <param name="imageFormat">Set Image Format</param>
        /// <returns></returns>
        public static string ToBase64String(this System.Drawing.Bitmap bmp, ImageFormat imageFormat)
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
        /// Convert to Base 64 Image Tag
        /// </summary>
        /// <param name="bmp">Set Bitmap</param>
        /// <param name="imageFormat">Set Image Format</param>
        /// <returns></returns>
        public static string ToBase64ImageTag(this System.Drawing.Bitmap bmp, ImageFormat imageFormat)
        {
            string imgTag = string.Empty;
            string base64String = string.Empty;

            base64String = bmp.ToBase64String(imageFormat);

            imgTag = "<img src=\"data:image/" + imageFormat.ToString() + ";base64,";
            imgTag += base64String + "\" ";
            imgTag += "width=\"" + bmp.Width.ToString() + "\" ";
            imgTag += "height=\"" + bmp.Height.ToString() + "\" />";

            return imgTag;
        }

        /// <summary>
        /// Convert Base 64 String to Bitmap
        /// </summary>
        /// <param name="base64String">Set Base 64 String</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap Base64StringToBitmap(this string base64String)
        {
            System.Drawing.Bitmap bmpReturn = null;

            byte[] byteBuffer = Convert.FromBase64String(base64String);
            MemoryStream memoryStream = new MemoryStream(byteBuffer);

            memoryStream.Position = 0;

            bmpReturn = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromStream(memoryStream);

            memoryStream.Close();
            memoryStream = null;
            byteBuffer = null;

            return bmpReturn;
        }
    }
}
