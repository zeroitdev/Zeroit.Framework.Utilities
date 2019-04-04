// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Base64Thumbnails.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace Zeroit.Framework.Utilities.BitmapUtils.Imaging
{
    /// <summary>
    /// A class for converting Base 64 Thumbnails
    /// </summary>
    public static class Base64Thumbnails
    {
        /// <summary>
        /// Convert to Base 64 Thumbnails
        /// </summary>
        /// <param name="path">Set string path</param>
        /// <param name="width">Set Width</param>
        /// <param name="height">Set Height</param>
        /// <param name="wrapImageTag">Wrap image</param>
        /// <param name="fileTypes">Set File Type</param>
        /// <returns></returns>
        public static List<string> ToBase64Thumbnails(this string path, int width, int height, bool wrapImageTag, params string[] fileTypes)
        {
            List<string> base64Thumbnails = new List<string>();

            string searchFilter = String.Empty;

            if (fileTypes != null)
            {
                for (int k = 0; k < fileTypes.Length; k++)
                {
                    searchFilter += "*." + fileTypes[k];

                    if (k < fileTypes.Length - 1)
                    {
                        searchFilter += "|";
                    }
                }
            }
            else
            {
                searchFilter = "*.*";
            }

            string[] files = Directory.GetFiles(path, searchFilter);

            for (int k = 0; k < files.Length; k++)
            {
                StreamReader streamReader = new StreamReader(files[k]);
                Image img = Image.FromStream(streamReader.BaseStream);
                streamReader.Close();

                base64Thumbnails.Add(img.ToBase64Thumbnail(width, height, wrapImageTag));

                img.Dispose();
            }

            return base64Thumbnails;
        }

        /// <summary>
        /// Convert to Base 64 Thumbnail
        /// </summary>
        /// <param name="bmp">Set Bitmap</param>
        /// <param name="width">Set Width</param>
        /// <param name="height">Set Height</param>
        /// <param name="wrapImageTag">Wrap Image</param>
        /// <returns>Return type is string</returns>
        public static string ToBase64Thumbnail(this Image bmp, int width, int height, bool wrapImageTag)
        {
            Image.GetThumbnailImageAbort callback = new Image.GetThumbnailImageAbort(ThumbnailCallback);

            Image thumbnailImage = bmp.GetThumbnailImage(width, height, callback, new IntPtr());

            string base64String = String.Empty;

            if (wrapImageTag == true)
            {
                base64String = thumbnailImage.ToBase64ImageTag();
            }
            else
            {
                base64String = thumbnailImage.ToBase64String();
            }

            thumbnailImage.Dispose();

            return base64String;
        }

        private static bool ThumbnailCallback()
        {
            return true;
        }
        
        /// <summary>
        /// Convert to Base 64 String
        /// </summary>
        /// <param name="bmp">Set Bitmap</param>
        /// <returns></returns>
        public static string ToBase64String(this Image bmp)
        {
            string base64String = string.Empty;
            MemoryStream memoryStream = null;

            try
            {
                memoryStream = new MemoryStream();
                bmp.Save(memoryStream, ImageFormat.Png);
            }
            catch (Exception exc)
            {
                return String.Empty;
            }

            memoryStream.Position = 0;
            byte[] byteBuffer = memoryStream.ToArray();

            memoryStream.Close();

            base64String = Convert.ToBase64String(byteBuffer, Base64FormattingOptions.InsertLineBreaks);
            byteBuffer = null;

            return base64String;
        }

        /// <summary>
        /// Convert to Base 64 Image Tag
        /// </summary>
        /// <param name="bmp">Set Bitmap</param>
        /// <returns>String</returns>
        public static string ToBase64ImageTag(this Image bmp)
        {
            string imgTag = string.Empty;
            string base64String = string.Empty;

            base64String = bmp.ToBase64String();

            imgTag = "<img src=\"data:image/" + "png" + ";base64,";
            imgTag += base64String + "\" ";
            imgTag += "width=\"" + bmp.Width.ToString() + "\" ";
            imgTag += "height=\"" + bmp.Height.ToString() + "\" />";

            return imgTag;
        }

        /// <summary>
        /// Convert Base 64 String to Bitmap
        /// </summary>
        /// <param name="base64String">Set Base 64 String</param>
        /// <returns>Bitmap</returns>
        public static System.Drawing.Bitmap Base64StringToBitmap(this string base64String)
        {
            System.Drawing.Bitmap bmpReturn = null;
            byte[] byteBuffer = null;

            try
            {
                byteBuffer = Convert.FromBase64String(base64String);
            }
            catch (Exception exc)
            {
                return null;
            }

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
