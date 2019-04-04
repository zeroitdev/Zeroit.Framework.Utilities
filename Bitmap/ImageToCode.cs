// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ImageToCode.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace Zeroit.Framework.Utilities.BitmapUtils
{
    /// <summary>
    /// A class collection for converting an image to base 64 string and also converting
    /// a base 64 string to an image.
    /// </summary>
    public class ImageToCodeToImage
    {
        public string ImageToCode(System.Drawing.Bitmap Img)
        {
            return Convert.ToBase64String((byte[])System.ComponentModel.TypeDescriptor.GetConverter(Img).ConvertTo(Img, typeof(byte[])));
        }

        public Image CodeToImage(string Code)
        {
            return Image.FromStream(new System.IO.MemoryStream(Convert.FromBase64String(Code)));
        }

        public static Image ImageFromCode(ref String str)
        {
            byte[] imageBytes = Convert.FromBase64String(str);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image i = Image.FromStream(ms, true);
            return i;
        }
        public static TextureBrush TiledTextureFromCode(string str)
        {
            return new TextureBrush(ImageFromCode(ref str), WrapMode.Tile);
        }
    }
}
