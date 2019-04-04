// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="BitmapImageBlending.cs" company="Zeroit Dev Technologies">
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
/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/
using System;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.BitmapUtils.Imaging
{
    /// <summary>
    /// A class for Bitmap image blending
    /// </summary>
    public static class BitmapImageBlending
    {
        /// <summary>
        /// Blend Image
        /// </summary>
        /// <param name="baseImage">Set base Bitmap</param>
        /// <param name="overlayImage">Set Overlay Bitmap</param>
        /// <param name="filterData">Set Bitmap Filter</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap BlendImage(this System.Drawing.Bitmap baseImage, System.Drawing.Bitmap overlayImage, BitmapFilterData filterData)
        {
            BitmapData baseImageData = baseImage.LockBits(new Rectangle(0, 0, baseImage.Width, baseImage.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            byte[] baseImageBuffer = new byte[baseImageData.Stride * baseImageData.Height];

            Marshal.Copy(baseImageData.Scan0, baseImageBuffer, 0, baseImageBuffer.Length);

            BitmapData overlayImageData = overlayImage.LockBits(new Rectangle(0, 0, overlayImage.Width, overlayImage.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            byte[] overlayImageBuffer = new byte[overlayImageData.Stride * overlayImageData.Height];

            Marshal.Copy(overlayImageData.Scan0, overlayImageBuffer, 0, overlayImageBuffer.Length);

            float sourceBlue = 0;
            float sourceGreen = 0;
            float sourceRed = 0;

            float overlayBlue = 0;
            float overlayGreen = 0;
            float overlayRed = 0;

            for (int k = 0; k < baseImageBuffer.Length && k < overlayImageBuffer.Length; k += 4)
            {
                sourceBlue = (filterData.SourceBlueEnabled ? baseImageBuffer[k] * filterData.SourceBlueLevel : 0);
                sourceGreen = (filterData.SourceGreenEnabled ? baseImageBuffer[k+1] * filterData.SourceGreenLevel : 0);
                sourceRed = (filterData.SourceRedEnabled ? baseImageBuffer[k+2] * filterData.SourceRedLevel : 0);

                overlayBlue = (filterData.OverlayBlueEnabled ? overlayImageBuffer[k] * filterData.OverlayBlueLevel : 0);
                overlayGreen = (filterData.OverlayGreenEnabled ? overlayImageBuffer[k + 1] * filterData.OverlayGreenLevel : 0);
                overlayRed = (filterData.OverlayRedEnabled ? overlayImageBuffer[k + 2] * filterData.OverlayRedLevel : 0);

                baseImageBuffer[k] = CalculateColorComponentBlendValue(sourceBlue, overlayBlue, filterData.BlendTypeBlue);
                baseImageBuffer[k + 1] = CalculateColorComponentBlendValue(sourceGreen, overlayGreen, filterData.BlendTypeGreen);
                baseImageBuffer[k + 2] = CalculateColorComponentBlendValue(sourceRed, overlayRed, filterData.BlendTypeRed);
            }

            System.Drawing.Bitmap bitmapResult = new System.Drawing.Bitmap(baseImage.Width, baseImage.Height, PixelFormat.Format32bppArgb);
            BitmapData resultImageData = bitmapResult.LockBits(new Rectangle(0, 0, bitmapResult.Width, bitmapResult.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            Marshal.Copy(baseImageBuffer, 0, resultImageData.Scan0, baseImageBuffer.Length);

            bitmapResult.UnlockBits(resultImageData);
            baseImage.UnlockBits(baseImageData);
            overlayImage.UnlockBits(overlayImageData);

            return bitmapResult;
        }

        /// <summary>
        /// Calculate Color blend value
        /// </summary>
        /// <param name="source">Set source value</param>
        /// <param name="overlay">Set overlay value</param>
        /// <param name="blendType">Set Blend type</param>
        /// <returns></returns>
        public static byte CalculateColorComponentBlendValue(float source, float overlay, ColorComponentBlendType blendType)
        {
            float resultValue = 0;
            byte resultByte = 0;

            if (blendType == ColorComponentBlendType.Add)
            {
                resultValue = source + overlay;
            }
            else if (blendType == ColorComponentBlendType.Subtract)
            {
                resultValue = source - overlay;
            }
            else if (blendType == ColorComponentBlendType.Average)
            {
                resultValue = (source + overlay) / 2.0f;
            }
            else if (blendType == ColorComponentBlendType.AscendingOrder)
            {
                resultValue = (source > overlay ? overlay : source);
            }
            else if (blendType == ColorComponentBlendType.DescendingOrder)
            {
                resultValue = (source < overlay ? overlay : source);
            }

            if (resultValue > 255)
            {
                resultByte = 255;
            }
            else if (resultValue < 0)
            {
                resultByte = 0;
            }
            else
            {
                resultByte = (byte)resultValue;
            }

            return resultByte;
        }

        /// <summary>
        /// Load Argb Bitmap
        /// </summary>
        /// <param name="filePath">Set File Path</param>
        /// <param name="imageDimensions">Set Image dimension</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap LoadArgbBitmap(this string filePath, Size? imageDimensions = null)
        {
            StreamReader streamReader = new StreamReader(filePath);
            System.Drawing.Bitmap fileBmp = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromStream(streamReader.BaseStream);
            streamReader.Close();

            int width = fileBmp.Width;
            int height = fileBmp.Height;

            if (imageDimensions != null)
            {
                width = imageDimensions.Value.Width;
                height = imageDimensions.Value.Height;
            }

            if (fileBmp.PixelFormat != PixelFormat.Format32bppArgb || fileBmp.Width != width || fileBmp.Height != height)
            {
                fileBmp = GetArgbCopy(fileBmp, width, height);
            }

            return fileBmp;
        }

        /// <summary>
        /// Get Argb
        /// </summary>
        /// <param name="sourceImage">Set source Bitmap</param>
        /// <param name="width">Set Width</param>
        /// <param name="height">Set Height</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap GetArgbCopy(System.Drawing.Bitmap sourceImage, int width, int height)
        {
            System.Drawing.Bitmap bmpNew = new System.Drawing.Bitmap(width, height, PixelFormat.Format32bppArgb);

            using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bmpNew))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                graphics.DrawImage(sourceImage, new Rectangle(0, 0, bmpNew.Width, bmpNew.Height), new Rectangle(0, 0, sourceImage.Width, sourceImage.Height), GraphicsUnit.Pixel);
                graphics.Flush();
            }

            return bmpNew;
        }

        /// <summary>
        /// Get Bitmap
        /// </summary>
        /// <param name="pictureBox">Set Picture Box</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap GetBitmap(this PictureBox pictureBox)
        {
            System.Drawing.Bitmap bitmapPicturebox = null;

            if (pictureBox.Image != null)
            {
                bitmapPicturebox = new System.Drawing.Bitmap(pictureBox.Image);
            }

            return bitmapPicturebox;
        }
    }

    [Serializable]
    public class BitmapFilterData
    {
        private bool sourceBlueEnabled = false;
        
        /// <summary>
        /// Source Blue Enabled
        /// </summary>
        public bool SourceBlueEnabled { get { return sourceBlueEnabled; } set { sourceBlueEnabled = value; } }

        private bool sourceGreenEnabled = false;

        /// <summary>
        /// Source Green Enabled
        /// </summary>
        public bool SourceGreenEnabled { get { return sourceGreenEnabled; } set { sourceGreenEnabled = value; } }

        private bool sourceRedEnabled = false;

        /// <summary>
        /// Source Red Enabled
        /// </summary>
        public bool SourceRedEnabled { get { return sourceRedEnabled; } set { sourceRedEnabled = value; } }

        private bool overlayBlueEnabled = false;

        /// <summary>
        /// Overlay Blue Enabled
        /// </summary>
        public bool OverlayBlueEnabled { get { return overlayBlueEnabled; } set { overlayBlueEnabled = value; } }

        private bool overlayGreenEnabled = false;

        /// <summary>
        /// Overlay Green Enabled
        /// </summary>
        public bool OverlayGreenEnabled { get { return overlayGreenEnabled; } set { overlayGreenEnabled = value; } }

        private bool overlayRedEnabled = false;

        /// <summary>
        /// Overlay Red Enabled
        /// </summary>
        public bool OverlayRedEnabled { get { return overlayRedEnabled; } set { overlayRedEnabled = value; } }

        private float sourceBlueLevel = 1.0f;

        /// <summary>
        /// Source Blue Level
        /// </summary>
        public float SourceBlueLevel { get { return sourceBlueLevel; } set { sourceBlueLevel = value; } }

        private float sourceGreenLevel = 1.0f;

        /// <summary>
        /// Source Green Level
        /// </summary>
        public float SourceGreenLevel { get { return sourceGreenLevel; } set { sourceGreenLevel = value; } }

        private float sourceRedLevel = 1.0f;

        /// <summary>
        /// Source Red Level
        /// </summary>
        public float SourceRedLevel { get { return sourceRedLevel; } set { sourceRedLevel = value; } }

        private float overlayBlueLevel = 0.0f;

        /// <summary>
        /// Overlay Blue Level
        /// </summary>
        public float OverlayBlueLevel { get { return overlayBlueLevel; } set { overlayBlueLevel = value; } }

        private float overlayGreenLevel = 0.0f;

        /// <summary>
        /// Overlay Green Level
        /// </summary>
        public float OverlayGreenLevel { get { return overlayGreenLevel; } set { overlayGreenLevel = value; } }

        private float overlayRedLevel = 0.0f;

        /// <summary>
        /// Overlay Red Level
        /// </summary>
        public float OverlayRedLevel { get { return overlayRedLevel; } set { overlayRedLevel = value; } }

        private ColorComponentBlendType blendTypeBlue = ColorComponentBlendType.Add;

        /// <summary>
        /// Blue Blend Type
        /// </summary>
        public ColorComponentBlendType BlendTypeBlue { get { return blendTypeBlue; } set { blendTypeBlue = value; } }

        private ColorComponentBlendType blendTypeGreen = ColorComponentBlendType.Add;

        /// <summary>
        /// Green Blend Type
        /// </summary>
        public ColorComponentBlendType BlendTypeGreen { get { return blendTypeGreen; } set { blendTypeGreen = value; } }

        private ColorComponentBlendType blendTypeRed = ColorComponentBlendType.Add;

        /// <summary>
        /// Red Blend Type
        /// </summary>
        public ColorComponentBlendType BlendTypeRed { get { return blendTypeRed; } set { blendTypeRed = value; } }


        /// <summary>
        /// XML Serialization
        /// </summary>
        /// <param name="filterData">Set Bitmap Filter</param>
        /// <returns></returns>
        public static string XmlSerialize(BitmapFilterData filterData)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BitmapFilterData));

            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Encoding = Encoding.UTF8;
            xmlSettings.Indent = true;

            MemoryStream memoryStream = new MemoryStream();
            XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlSettings);

            xmlSerializer.Serialize(xmlWriter, filterData);
            xmlWriter.Flush();

            string xmlString = xmlSettings.Encoding.GetString(memoryStream.ToArray());
            
            xmlWriter.Close();
            memoryStream.Close();
            memoryStream.Dispose();

            return xmlString;
        }

        /// <summary>
        /// XML Deserialize
        /// </summary>
        /// <param name="xmlString">Set xml</param>
        /// <returns></returns>
        public static BitmapFilterData XmlDeserialize(string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BitmapFilterData));
            MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xmlString));

            XmlReader xmlReader = XmlReader.Create(memoryStream);

            BitmapFilterData filterData = null;

            if(xmlSerializer.CanDeserialize(xmlReader) == true)
            {
                xmlReader.Close();
                memoryStream.Position = 0;

                filterData = (BitmapFilterData)xmlSerializer.Deserialize(memoryStream);
            }

            memoryStream.Close();
            memoryStream.Dispose();

            return filterData;
        }
    }

    /// <summary>
    /// Color Blend Type
    /// </summary>
    public enum ColorComponentBlendType
    {
        Add,
        Subtract,
        Average,
        DescendingOrder,
        AscendingOrder
    }
}
