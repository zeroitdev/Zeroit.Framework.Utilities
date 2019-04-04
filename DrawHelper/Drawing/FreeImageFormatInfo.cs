// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="FreeImageFormatInfo.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing
{
    public struct FreeImageFormatInfo
    {
        private string[] _Extensions;

        private Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT _Format;

        internal Internal.FREE_IMAGE_FORMAT Format
        {
            get
            {
                return _Format;
            }
        }

        public override string ToString()
        {
            var a = this.Format.ToString();
            return a.Substring(a.LastIndexOf("_") + 1);
        }

        public static FreeImageFormatInfo GetFromFilename(string filename)
        {
            return new FreeImageFormatInfo
            (Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FreeImageApi.GetFIFFromFilename(filename));
        }

        /// <summary>
        /// File Extensions for this Image Format
        /// </summary>
        public string[] Extensions
        {
            get
            {
                return _Extensions;
            }
        }

        internal FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT format)
        {
            _Extensions = GetAllExtensions(format);
            _Format = format;
        }

        private static string[] GetAllExtensions(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT format)
        {
            var exts = Internal.FreeImageApi.GetFIFExtensionList(format);

            return exts.Split(new string[]{","},  StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// FormatInfo for BMP 
        /// </summary>
        public static FreeImageFormatInfo Bmp
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_BMP);
            }
        }

        /// <summary>
        /// FormatInfo for ICO 
        /// </summary>
        public static FreeImageFormatInfo Ico
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_ICO);
            }
        }

        /// <summary>
        /// FormatInfo for JPEG
        /// </summary>
        public static FreeImageFormatInfo Jpeg
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_JPEG);
            }
        }

        /// <summary>
        /// FormatInfo for Jng 
        /// </summary>
        public static FreeImageFormatInfo Jng
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_JNG);
            }
        }

        /// <summary>
        /// FormatInfo for Koala 
        /// </summary>
        public static FreeImageFormatInfo Koala
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_KOALA);
            }
        }

        /// <summary>
        /// FormatInfo for Lbm
        /// </summary>
        public static FreeImageFormatInfo Lbm
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_LBM);
            }
        }

        /// <summary>
        /// FormatInfo for Iff
        /// </summary>
        public static FreeImageFormatInfo Iff
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_IFF);
            }
        }

        /// <summary>
        /// FormatInfo for Mng 
        /// </summary>
        public static FreeImageFormatInfo Mng
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_MNG);
            }
        }

        /// <summary>
        /// FormatInfo for Pbm 
        /// </summary>
        public static FreeImageFormatInfo Pbm
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_PBM);
            }
        }

        /// <summary>
        /// FormatInfo for PbmRaw
        /// </summary>
        public static FreeImageFormatInfo PbmRaw
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_PBMRAW);
            }
        }

        /// <summary>
        /// FormatInfo for PCD
        /// </summary>
        public static FreeImageFormatInfo Pcd
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_PCD);
            }
        }

        /// <summary>
        /// FormatInfo for PCX
        /// </summary>
        public static FreeImageFormatInfo Pcx
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_PCX);
            }
        }

        /// <summary>
        /// FormatInfo for PGM
        /// </summary>
        public static FreeImageFormatInfo Pgm
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_PGM);
            }
        }

        /// <summary>
        /// FormatInfo for PGMRAW
        /// </summary>
        public static FreeImageFormatInfo PgmRaw
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_PGMRAW);
            }
        }

        /// <summary>
        /// FormatInfo for PNG
        /// </summary>
        public static FreeImageFormatInfo Png
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_PNG);
            }
        }

        /// <summary>
        /// FormatInfo for PPM
        /// </summary>
        public static FreeImageFormatInfo Ppm
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_PPM);
            }
        }

        /// <summary>
        /// FormatInfo for PPMRAW 
        /// </summary>
        public static FreeImageFormatInfo PpmRaw
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_PPMRAW);
            }
        }

        /// <summary>
        /// FormatInfo for RAS
        /// </summary>
        public static FreeImageFormatInfo Ras
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_RAS);
            }
        }

        /// <summary>
        /// FormatInfo for TARGA 
        /// </summary>
        public static FreeImageFormatInfo Targa
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_TARGA);
            }
        }

        /// <summary>
        /// FormatInfo for TIFF
        /// </summary>
        public static FreeImageFormatInfo Tiff
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_TIFF);
            }
        }

        /// <summary>
        /// FormatInfo for WBMP
        /// </summary>
        public static FreeImageFormatInfo Wbmp
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_WBMP);
            }
        }

        /// <summary>
        /// FormatInfo for PSD 
        /// </summary>
        public static FreeImageFormatInfo Psd
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_PSD);
            }
        }

        /// <summary>
        /// FormatInfo for CUT 
        /// </summary>
        public static FreeImageFormatInfo Cut
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_CUT);
            }
        }

        /// <summary>
        /// FormatInfo for XBM 
        /// </summary>
        public static FreeImageFormatInfo Xbm
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_XBM);
            }
        }

        /// <summary>
        /// FormatInfo for DDS 
        /// </summary>
        public static FreeImageFormatInfo Dds
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_DDS);
            }
        }

        /// <summary>
        /// FormatInfo for GIF 
        /// </summary>
        public static FreeImageFormatInfo Gif
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_GIF);
            }
        }

        /// <summary>
        /// FormatInfo for HDR 
        /// </summary>
        public static FreeImageFormatInfo Hdr
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_HDR);
            }
        }

        /// <summary>
        /// FormatInfo for FAXG3 
        /// </summary>
        public static FreeImageFormatInfo Faxg3
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_FAXG3);
            }
        }

        /// <summary>
        /// FormatInfo for SGI 
        /// </summary>
        public static FreeImageFormatInfo Sgi
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_SGI);
            }
        }

        /// <summary>
        /// FormatInfo for EXR 
        /// </summary>
        public static FreeImageFormatInfo Exr
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_EXR);
            }
        }

        /// <summary>
        /// FormatInfo for J2k 
        /// </summary>
        public static FreeImageFormatInfo J2k
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_BMP);
            }
        }

        /// <summary>
        /// FormatInfo for JP2 
        /// </summary>
        public static FreeImageFormatInfo Jp2
        {
            get
            {
                return new FreeImageFormatInfo(Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal.FREE_IMAGE_FORMAT.FIF_JP2);
            }
        }
    }
}
