// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="PngToBmp.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
