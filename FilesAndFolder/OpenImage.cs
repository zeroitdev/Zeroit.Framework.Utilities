// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="OpenImage.cs" company="Zeroit Dev Technologies">
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
