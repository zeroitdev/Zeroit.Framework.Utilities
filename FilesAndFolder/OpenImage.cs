// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="OpenImage.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.Files
{
    /// <summary>
    /// A class collection for selecting Images
    /// </summary>
    public static class LoadImage
    {
        /// <summary>
        /// Select Image
        /// </summary>
        /// <param name="ofd">Set Open File Dialog</param>
        /// <param name="outputImage">Set Output Image</param>
        /// <param name="title">Set Title</param>
        /// <param name="filter">Set string Filter</param>
        public static void SelectImage(
            OpenFileDialog ofd,
            Image outputImage,
            string title = "Select an image file", 
            string filter = "Png files (*.png)|*.png|Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg"
            )
        {
            
            ofd.Title = title;
            ofd.Filter = filter;

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(ofd.FileName);
                System.Drawing.Bitmap sourceBitmap = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromStream(streamReader.BaseStream);
                streamReader.Close();

                outputImage = sourceBitmap;
                
            }
        }
    }
}
