// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="PngToBmp.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Imaging;

namespace Zeroit.Framework.Utilities.BitmapUtils
{
    /// <summary>
    /// Type of Image. Bmp,Jpg,Png,Icon,Tiff,Emf,Exif,Gif,Wmf
    /// </summary>
    public enum ImageForm
    {
        /// <summary>
        /// The BMP
        /// </summary>
        Bmp,
        /// <summary>
        /// The EMF
        /// </summary>
        Emf,
        /// <summary>
        /// The exif
        /// </summary>
        Exif,
        /// <summary>
        /// The GIF
        /// </summary>
        Gif,
        /// <summary>
        /// The icon
        /// </summary>
        Icon,
        /// <summary>
        /// The JPEG
        /// </summary>
        Jpeg,
        /// <summary>
        /// The PNG
        /// </summary>
        Png,
        /// <summary>
        /// The tiff
        /// </summary>
        Tiff,
        /// <summary>
        /// The WMF
        /// </summary>
        Wmf
    }

    /// <summary>
    /// Convert from one image format to Bmp,Emf,Exif,Gif,Icon,Jpeg,Png,Tiff,Wmf
    /// </summary>
    public class PngToBmp
    {

        /// <summary>
        /// Method to convert an image from one format to the other
        /// </summary>
        /// <param name="sourceFile">Select the source file path excluding the extension</param>
        /// <param name="sourceExtension">Set the source extension eg. bmp,gif,ico,jpg,png,tiff,wmf</param>
        /// <param name="outputFile">Set the output file with its path</param>
        /// <param name="outputExtension">Set the output extension eg. bmp,gif,ico,jpg,png,tiff,wmf</param>
        /// <param name="imgForm">Set the image format</param>
        public static void Convert(
            string sourceFile, 
            string sourceExtension, 
            string outputFile, 
            string outputExtension, 
            ImageForm imgForm)
        {
            
            Image image = Image.FromFile(sourceFile + sourceExtension);

            if (imgForm == ImageForm.Bmp)
            {
                image.Save(outputFile + outputExtension, ImageFormat.Bmp);
            }

            else if (imgForm == ImageForm.Emf)
            {
                image.Save(outputFile + outputExtension, ImageFormat.Emf);
            }

            else if (imgForm == ImageForm.Exif)
            {
                image.Save(outputFile + outputExtension, ImageFormat.Exif);
            }

            else if (imgForm == ImageForm.Gif)
            {
                image.Save(outputFile + outputExtension, ImageFormat.Gif);
            }

            else if (imgForm == ImageForm.Icon)
            {
                image.Save(outputFile + outputExtension, ImageFormat.Icon);
            }

            else if (imgForm == ImageForm.Jpeg)
            {
                image.Save(outputFile + outputExtension, ImageFormat.Jpeg);
            }

            else if (imgForm == ImageForm.Png)
            {
                image.Save(outputFile + outputExtension, ImageFormat.Png);
            }

            else if (imgForm == ImageForm.Tiff)
            {
                image.Save(outputFile + outputExtension, ImageFormat.Tiff);
            }

            else
            {
                image.Save(outputFile + outputExtension, ImageFormat.Wmf);
            }

        }
        
    }
}
