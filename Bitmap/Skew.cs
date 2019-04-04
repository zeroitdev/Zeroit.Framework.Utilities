// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Skew.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
