// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Skew.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.BitmapUtils
{
    /// <summary>
    /// A class collection to skew images
    /// </summary>
    public static class Skew
    {

        #region Usage

        /***************************** Usage**********************************
         * 
            Bitmap bmp = SkewBitmap((Bitmap)pictureBox4.Image, 0.5f, 1f, 0.5f);

            pictureBox5.Image = pictureBox1.Image;
            pictureBox5.BackgroundImage = bmp;
            pictureBox5.ClientSize = new Size(bmp.Width, bmp.Height);
        */

        #endregion
            
        /// <summary>
        /// Skew image
        /// </summary>
        /// <param name="inMap">Set bitmap/param>
        /// <param name="skewX">Skew Horizontally</param>
        /// <param name="ratioX">Ratio X</param>
        /// <param name="ratioY">Ratio Y</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap SkewBitmap(System.Drawing.Bitmap inMap, float skewX, float ratioX, float ratioY)
        {
            int nWidth = (int)(inMap.Width * (skewX + ratioX));
            int nHeight = (int)(Math.Max(inMap.Height, inMap.Height * ratioY));
            int yOffset = inMap.Height - nHeight;

            System.Drawing.Bitmap outMap = new System.Drawing.Bitmap(nWidth, nHeight);

            Point[] destinationPoints = {
                new Point((int)(inMap.Width * skewX), (int)(inMap.Height * ratioY) + yOffset),
                new Point((int)(inMap.Width * skewX + inMap.Width * ratioX),
                    (int)(inMap.Height * ratioY) + yOffset),
                new Point(0, inMap.Height + yOffset ) };

            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(outMap))
                g.DrawImage(inMap, destinationPoints);

            return outMap;
        }

    }
}
