// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="SaveImage.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.Files
{
    /// <summary>
    /// A class collection for Saving Images
    /// </summary>
    public static class SaveImage
    {
        /// <summary>
        /// Save
        /// </summary>
        /// <param name="sfd">Save File Dialog</param>
        /// <param name="outputImage">Set Output Image</param>
        /// <param name="title">Set Title</param>
        /// <param name="filter">Set Filter</param>
        public static void Save(
            SaveFileDialog sfd,
            Image outputImage,
            string title = "Specify a file name and file path", 
            string filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg|Bitmap Images(*.bmp)|*.bmp"
            )
        {

            if (outputImage != null)
            {
                
                sfd.Title = title;
                sfd.Filter = filter;

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string fileExtension = Path.GetExtension(sfd.FileName).ToUpper();
                    ImageFormat imgFormat = ImageFormat.Png;

                    if (fileExtension == "BMP")
                    {
                        imgFormat = ImageFormat.Bmp;
                    }
                    else if (fileExtension == "JPG")
                    {
                        imgFormat = ImageFormat.Jpeg;
                    }

                    StreamWriter streamWriter = new StreamWriter(sfd.FileName, false);
                    outputImage.Save(streamWriter.BaseStream, imgFormat);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }
        }
    }
}
