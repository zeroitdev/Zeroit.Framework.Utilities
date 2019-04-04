// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="FreeImageAPI.cs" company="Zeroit Dev Technologies">
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
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal
{
	/**
	Handle to a bitmap
	*/
	using FIBITMAP = UInt32;
	/**
	Handle to a multipage file
	*/
	using FIMULTIBITMAP = UInt32;
	/**
	Handle to a memory I/O stream
	*/
	using FIMEMORY = UInt32;
	/**
	  Handle to a metadata model
	*/
	using FIMETADATA = UInt32;
	/** 
	Handle to a FreeImage tag
	*/
	using FITAG = UInt32;

    /*	[StructLayout(LayoutKind.Sequential)]
		public class FreeImageIO
		{
			public FI_ReadProc readProc;
			public FI_WriteProc writeProc;
			public FI_SeekProc seekProc;
			public FI_TellProc tellProc;
		}
	
		[StructLayout(LayoutKind.Sequential)]
		public class FI_Handle
		{
			public FileStream stream;
		}
		public delegate void FI_ReadProc(IntPtr buffer, uint size, uint count, IntPtr handle);
		public delegate void FI_WriteProc(IntPtr buffer, uint size, uint count, IntPtr handle);
		public delegate int FI_SeekProc(IntPtr handle, long offset, int origin);
		public delegate int FI_TellProc(IntPtr handle);
		*/

    // Types used in the library (directly copied from Windows) -----------------

    /// <summary>
    /// Class RGBQUAD.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
	public class RGBQUAD {
        /// <summary>
        /// The RGB blue
        /// </summary>
        public byte rgbBlue;
        /// <summary>
        /// The RGB green
        /// </summary>
        public byte rgbGreen;
        /// <summary>
        /// The RGB red
        /// </summary>
        public byte rgbRed;
        /// <summary>
        /// The RGB reserved
        /// </summary>
        public byte rgbReserved;
	}

    /// <summary>
    /// Class RGBTRIPLE.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
	public class RGBTRIPLE {
        /// <summary>
        /// The RGBT blue
        /// </summary>
        public byte rgbtBlue;
        /// <summary>
        /// The RGBT green
        /// </summary>
        public byte rgbtGreen;
        /// <summary>
        /// The RGBT red
        /// </summary>
        public byte rgbtRed;
	}

    /*
	These structures should not be used by a wrapper
	[StructLayout(LayoutKind.Sequential)]
	public class BITMAPINFOHEADER {
		public uint size;
		public int width; 
		public int height; 
		public ushort biPlanes; 
		public ushort biBitCount;
		public uint biCompression; 
		public uint biSizeImage; 
		public int biXPelsPerMeter; 
		public int biYPelsPerMeter; 
		public uint biClrUsed; 
		public uint biClrImportant;
	}

	[StructLayout(LayoutKind.Sequential)]
	public class BITMAPINFO {
	  public BITMAPINFOHEADER bmiHeader; 
	  public RGBQUAD bmiColors;
	}
	*/

    // Types used in the library (specific to FreeImage) ------------------------
    /** 48-bit RGB 
	*/
    /// <summary>
    /// Class FIRGB16.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
	public class FIRGB16 {
        /// <summary>
        /// The red
        /// </summary>
        public ushort red;
        /// <summary>
        /// The green
        /// </summary>
        public ushort green;
        /// <summary>
        /// The blue
        /// </summary>
        public ushort blue;
	}

    /** 64-bit RGBA
	*/
    /// <summary>
    /// Class FIRGBA16.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
	public class FIRGBA16 {
        /// <summary>
        /// The red
        /// </summary>
        public ushort red;
        /// <summary>
        /// The green
        /// </summary>
        public ushort green;
        /// <summary>
        /// The blue
        /// </summary>
        public ushort blue;
        /// <summary>
        /// The alpha
        /// </summary>
        public ushort alpha;
	}

    /** 96-bit RGB Float
	*/
    /// <summary>
    /// Class FIRGBF.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
	public class FIRGBF {
        /// <summary>
        /// The red
        /// </summary>
        public float red;
        /// <summary>
        /// The green
        /// </summary>
        public float green;
        /// <summary>
        /// The blue
        /// </summary>
        public float blue;
	}

    /** 128-bit RGBA Float
	*/
    /// <summary>
    /// Class FIRGBAF.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
	public class FIRGBAF {
        /// <summary>
        /// The red
        /// </summary>
        public float red;
        /// <summary>
        /// The green
        /// </summary>
        public float green;
        /// <summary>
        /// The blue
        /// </summary>
        public float blue;
        /// <summary>
        /// The alpha
        /// </summary>
        public float alpha;
	}

    /** Data structure for COMPLEX type (complex number)
	*/
    /// <summary>
    /// Class FICOMPLEX.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
	public class FICOMPLEX {
        // real part
        /// <summary>
        /// The r
        /// </summary>
        public double r;
        // imaginary part
        /// <summary>
        /// The i
        /// </summary>
        public double i;
	}

    // ICC profile support ------------------------------------------------------

    /// <summary>
    /// Enum ICCFlags
    /// </summary>
    public enum ICCFlags {
        /// <summary>
        /// The fiicc default
        /// </summary>
        FIICC_DEFAULT = 0x00,
        /// <summary>
        /// The fiicc color is cmyk
        /// </summary>
        FIICC_COLOR_IS_CMYK = 0x01
	}

    /// <summary>
    /// Class FIICCPROFILE.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
	public class FIICCPROFILE {
        /// <summary>
        /// The flags
        /// </summary>
        public ushort flags;    // info flag
                                /// <summary>
                                /// The size
                                /// </summary>
        public uint size;       // profile's size measured in bytes
                                /// <summary>
                                /// The data
                                /// </summary>
        public IntPtr data;		// points to a block of contiguous memory containing the profile
	}

    // Important enums ----------------------------------------------------------

    /// <summary>
    /// Enum LoadSaveFlags
    /// </summary>
    public enum LoadSaveFlags {
        /// <summary>
        /// The BMP default
        /// </summary>
        BMP_DEFAULT = 0,
        /// <summary>
        /// The BMP save rle
        /// </summary>
        BMP_SAVE_RLE = 1,
        /// <summary>
        /// The cut default
        /// </summary>
        CUT_DEFAULT = 0,
        /// <summary>
        /// The DDS default
        /// </summary>
        DDS_DEFAULT = 0,
        /// <summary>
        /// The exr default
        /// </summary>
        EXR_DEFAULT = 0,        // save data as half with piz-based wavelet compression
                                        /// <summary>
                                        /// The exr float
                                        /// </summary>
        EXR_FLOAT = 0x0001,   // save data as float instead of as half (not recommended)
                                        /// <summary>
                                        /// The exr none
                                        /// </summary>
        EXR_NONE = 0x0002,   // save with no compression
                                        /// <summary>
                                        /// The exr zip
                                        /// </summary>
        EXR_ZIP = 0x0004,   // save with zlib compression, in blocks of 16 scan lines
                                        /// <summary>
                                        /// The exr piz
                                        /// </summary>
        EXR_PIZ = 0x0008,   // save with piz-based wavelet compression
                                        /// <summary>
                                        /// The exr px R24
                                        /// </summary>
        EXR_PXR24 = 0x0010,   // save with lossy 24-bit float compression
                                        /// <summary>
                                        /// The exr B44
                                        /// </summary>
        EXR_B44 = 0x0020,   // save with lossy 44% float compression - goes to 22% when combined with EXR_LC
                                        /// <summary>
                                        /// The exr lc
                                        /// </summary>
        EXR_LC = 0x0040,   // save images with one luminance and two chroma channels, rather than as RGB (lossy compression)
                                        /// <summary>
                                        /// The fax g3 default
                                        /// </summary>
        FAXG3_DEFAULT = 0,
        /// <summary>
        /// The GIF default
        /// </summary>
        GIF_DEFAULT = 0,
        /// <summary>
        /// The GIF loa D256
        /// </summary>
        GIF_LOAD256 = 1,        // Load	the	image as a 256 color image with	ununsed	palette	entries, if	it's 16	or 2 color
                                        /// <summary>
                                        /// The GIF playback
                                        /// </summary>
        GIF_PLAYBACK = 2,        // 'Play' the GIF to generate each frame (as 32bpp)	instead	of returning raw frame data	when loading
                                        /// <summary>
                                        /// The HDR default
                                        /// </summary>
        HDR_DEFAULT = 0,
        /// <summary>
        /// The icon default
        /// </summary>
        ICO_DEFAULT = 0,
        /// <summary>
        /// The icon makealpha
        /// </summary>
        ICO_MAKEALPHA = 1,        // convert to 32bpp	and	create an alpha	channel	from the AND-mask when loading
                                        /// <summary>
                                        /// The iff default
                                        /// </summary>
        IFF_DEFAULT = 0,
        /// <summary>
        /// The j2 k default
        /// </summary>
        J2K_DEFAULT = 0,        // save with a 16:1 rate
                                        /// <summary>
                                        /// The j p2 default
                                        /// </summary>
        JP2_DEFAULT = 0,        // save with a 16:1 rate
                                        /// <summary>
                                        /// The JPEG default
                                        /// </summary>
        JPEG_DEFAULT = 0,
        /// <summary>
        /// The JPEG fast
        /// </summary>
        JPEG_FAST = 1,
        /// <summary>
        /// The JPEG accurate
        /// </summary>
        JPEG_ACCURATE = 2,
        /// <summary>
        /// The JPEG qualitysuperb
        /// </summary>
        JPEG_QUALITYSUPERB = 0x80,
        /// <summary>
        /// The JPEG qualitygood
        /// </summary>
        JPEG_QUALITYGOOD = 0x100,
        /// <summary>
        /// The JPEG qualitynormal
        /// </summary>
        JPEG_QUALITYNORMAL = 0x200,
        /// <summary>
        /// The JPEG qualityaverage
        /// </summary>
        JPEG_QUALITYAVERAGE = 0x400,
        /// <summary>
        /// The JPEG qualitybad
        /// </summary>
        JPEG_QUALITYBAD = 0x800,
        /// <summary>
        /// The JPEG cmyk
        /// </summary>
        JPEG_CMYK = 0x1000,   // load	separated CMYK "as is" (use	| to combine with other	flags)
                                        /// <summary>
                                        /// The koala default
                                        /// </summary>
        KOALA_DEFAULT = 0,
        /// <summary>
        /// The LBM default
        /// </summary>
        LBM_DEFAULT = 0,
        /// <summary>
        /// The MNG default
        /// </summary>
        MNG_DEFAULT = 0,
        /// <summary>
        /// The PCD default
        /// </summary>
        PCD_DEFAULT = 0,
        /// <summary>
        /// The PCD base
        /// </summary>
        PCD_BASE = 1,        // load	the	bitmap sized 768 x 512
                                        /// <summary>
                                        /// The PCD basedi v4
                                        /// </summary>
        PCD_BASEDIV4 = 2,        // load	the	bitmap sized 384 x 256
                                        /// <summary>
                                        /// The PCD basedi V16
                                        /// </summary>
        PCD_BASEDIV16 = 3,        // load	the	bitmap sized 192 x 128
                                        /// <summary>
                                        /// The PCX default
                                        /// </summary>
        PCX_DEFAULT = 0,
        /// <summary>
        /// The PNG default
        /// </summary>
        PNG_DEFAULT = 0,
        /// <summary>
        /// The PNG ignoregamma
        /// </summary>
        PNG_IGNOREGAMMA = 1,        // avoid gamma correction
                                        /// <summary>
                                        /// The PNM default
                                        /// </summary>
        PNM_DEFAULT = 0,
        /// <summary>
        /// The PNM save raw
        /// </summary>
        PNM_SAVE_RAW = 0,        //	If set the writer saves	in RAW format (i.e.	P4,	P5 or P6)
                                        /// <summary>
                                        /// The PNM save ASCII
                                        /// </summary>
        PNM_SAVE_ASCII = 1,        // If	set	the	writer saves in	ASCII format (i.e. P1, P2 or P3)
                                        /// <summary>
                                        /// The PSD default
                                        /// </summary>
        PSD_DEFAULT = 0,
        /// <summary>
        /// The ras default
        /// </summary>
        RAS_DEFAULT = 0,
        /// <summary>
        /// The targa default
        /// </summary>
        TARGA_DEFAULT = 0,
        /// <summary>
        /// The targa load rg B888
        /// </summary>
        TARGA_LOAD_RGB888 = 1,        //	If set the loader converts RGB555 and ARGB8888 -> RGB888.
                                        /// <summary>
                                        /// The tiff default
                                        /// </summary>
        TIFF_DEFAULT = 0,
        /// <summary>
        /// The tiff cmyk
        /// </summary>
        TIFF_CMYK = 0x0001,   // reads/stores	tags for separated CMYK	(use | to combine with compression flags)
                                        /// <summary>
                                        /// The tiff packbits
                                        /// </summary>
        TIFF_PACKBITS = 0x0100,   // save using	PACKBITS compression
                                        /// <summary>
                                        /// The tiff deflate
                                        /// </summary>
        TIFF_DEFLATE = 0x0200,   // save using	DEFLATE	compression	(a.k.a.	ZLIB compression)
                                        /// <summary>
                                        /// The tiff adobe deflate
                                        /// </summary>
        TIFF_ADOBE_DEFLATE = 0x0400,   // save using	ADOBE DEFLATE compression
                                        /// <summary>
                                        /// The tiff none
                                        /// </summary>
        TIFF_NONE = 0x0800,   // save without any compression
                                        /// <summary>
                                        /// The tiff ccittfa x3
                                        /// </summary>
        TIFF_CCITTFAX3 = 0x1000,   //	save using CCITT Group 3 fax encoding
                                        /// <summary>
                                        /// The tiff ccittfa x4
                                        /// </summary>
        TIFF_CCITTFAX4 = 0x2000,   //	save using CCITT Group 4 fax encoding
                                        /// <summary>
                                        /// The tiff LZW
                                        /// </summary>
        TIFF_LZW = 0x4000,   // save	using LZW compression
                                        /// <summary>
                                        /// The tiff JPEG
                                        /// </summary>
        TIFF_JPEG = 0x8000,   // save	using JPEG compression
                                        /// <summary>
                                        /// The WBMP default
                                        /// </summary>
        WBMP_DEFAULT = 0,
        /// <summary>
        /// The XBM default
        /// </summary>
        XBM_DEFAULT = 0,
        /// <summary>
        /// The XPM default
        /// </summary>
        XPM_DEFAULT = 0,
	}

    /** I/O image format identifiers.
	*/
    /// <summary>
    /// Enum FREE_IMAGE_FORMAT
    /// </summary>
    public enum FREE_IMAGE_FORMAT {
        /// <summary>
        /// The fif unknown
        /// </summary>
        FIF_UNKNOWN = -1,
        /// <summary>
        /// The fif BMP
        /// </summary>
        FIF_BMP = 0,
        /// <summary>
        /// The fif icon
        /// </summary>
        FIF_ICO = 1,
        /// <summary>
        /// The fif JPEG
        /// </summary>
        FIF_JPEG = 2,
        /// <summary>
        /// The fif JNG
        /// </summary>
        FIF_JNG = 3,
        /// <summary>
        /// The fif koala
        /// </summary>
        FIF_KOALA = 4,
        /// <summary>
        /// The fif LBM
        /// </summary>
        FIF_LBM = 5,
        /// <summary>
        /// The fif iff
        /// </summary>
        FIF_IFF = FIF_LBM,
        /// <summary>
        /// The fif MNG
        /// </summary>
        FIF_MNG = 6,
        /// <summary>
        /// The fif PBM
        /// </summary>
        FIF_PBM = 7,
        /// <summary>
        /// The fif pbmraw
        /// </summary>
        FIF_PBMRAW = 8,
        /// <summary>
        /// The fif PCD
        /// </summary>
        FIF_PCD = 9,
        /// <summary>
        /// The fif PCX
        /// </summary>
        FIF_PCX = 10,
        /// <summary>
        /// The fif PGM
        /// </summary>
        FIF_PGM = 11,
        /// <summary>
        /// The fif pgmraw
        /// </summary>
        FIF_PGMRAW = 12,
        /// <summary>
        /// The fif PNG
        /// </summary>
        FIF_PNG = 13,
        /// <summary>
        /// The fif PPM
        /// </summary>
        FIF_PPM = 14,
        /// <summary>
        /// The fif ppmraw
        /// </summary>
        FIF_PPMRAW = 15,
        /// <summary>
        /// The fif ras
        /// </summary>
        FIF_RAS = 16,
        /// <summary>
        /// The fif targa
        /// </summary>
        FIF_TARGA = 17,
        /// <summary>
        /// The fif tiff
        /// </summary>
        FIF_TIFF = 18,
        /// <summary>
        /// The fif WBMP
        /// </summary>
        FIF_WBMP = 19,
        /// <summary>
        /// The fif PSD
        /// </summary>
        FIF_PSD = 20,
        /// <summary>
        /// The fif cut
        /// </summary>
        FIF_CUT = 21,
        /// <summary>
        /// The fif XBM
        /// </summary>
        FIF_XBM = 22,
        /// <summary>
        /// The fif XPM
        /// </summary>
        FIF_XPM = 23,
        /// <summary>
        /// The fif DDS
        /// </summary>
        FIF_DDS = 24,
        /// <summary>
        /// The fif GIF
        /// </summary>
        FIF_GIF = 25,
        /// <summary>
        /// The fif HDR
        /// </summary>
        FIF_HDR = 26,
        /// <summary>
        /// The fif fax g3
        /// </summary>
        FIF_FAXG3 = 27,
        /// <summary>
        /// The fif sgi
        /// </summary>
        FIF_SGI = 28,
        /// <summary>
        /// The fif exr
        /// </summary>
        FIF_EXR = 29,
        /// <summary>
        /// The fif j2 k
        /// </summary>
        FIF_J2K = 30,
        /// <summary>
        /// The fif j p2
        /// </summary>
        FIF_JP2 = 31		
	}

    /** Image type used in FreeImage.
	*/
    /// <summary>
    /// Enum FREE_IMAGE_TYPE
    /// </summary>
    public enum FREE_IMAGE_TYPE {
        /// <summary>
        /// The fit unknown
        /// </summary>
        FIT_UNKNOWN = 0,    // unknown type
                            /// <summary>
                            /// The fit bitmap
                            /// </summary>
        FIT_BITMAP = 1,    // standard image			: 1-, 4-, 8-, 16-, 24-, 32-bit
                            /// <summary>
                            /// The fit uin T16
                            /// </summary>
        FIT_UINT16 = 2,    // array of unsigned short	: unsigned 16-bit
                            /// <summary>
                            /// The fit in T16
                            /// </summary>
        FIT_INT16 = 3,    // array of short			: signed 16-bit
                            /// <summary>
                            /// The fit uin T32
                            /// </summary>
        FIT_UINT32 = 4,    // array of unsigned long	: unsigned 32-bit
                            /// <summary>
                            /// The fit in T32
                            /// </summary>
        FIT_INT32 = 5,    // array of long			: signed 32-bit
                            /// <summary>
                            /// The fit float
                            /// </summary>
        FIT_FLOAT = 6,    // array of float			: 32-bit IEEE floating point
                            /// <summary>
                            /// The fit double
                            /// </summary>
        FIT_DOUBLE = 7,    // array of double			: 64-bit IEEE floating point
                            /// <summary>
                            /// The fit complex
                            /// </summary>
        FIT_COMPLEX = 8,    // array of FICOMPLEX		: 2 x 64-bit IEEE floating point
                            /// <summary>
                            /// The fit rg B16
                            /// </summary>
        FIT_RGB16 = 9,    // 48-bit RGB image			: 3 x 16-bit
                            /// <summary>
                            /// The fit RGB a16
                            /// </summary>
        FIT_RGBA16 = 10,   // 64-bit RGBA image		: 4 x 16-bit
                            /// <summary>
                            /// The fit RGBF
                            /// </summary>
        FIT_RGBF = 11,   // 96-bit RGB float image	: 3 x 32-bit IEEE floating point
                            /// <summary>
                            /// The fit rgbaf
                            /// </summary>
        FIT_RGBAF = 12	// 128-bit RGBA float image	: 4 x 32-bit IEEE floating point
	}

    /** Image color type used in FreeImage.
	*/
    /// <summary>
    /// Enum FREE_IMAGE_COLOR_TYPE
    /// </summary>
    public enum	FREE_IMAGE_COLOR_TYPE {
        /// <summary>
        /// The fic miniswhite
        /// </summary>
        FIC_MINISWHITE = 0,     // min value is white
                                /// <summary>
                                /// The fic minisblack
                                /// </summary>
        FIC_MINISBLACK = 1,     // min value is black
                                /// <summary>
                                /// The fic RGB
                                /// </summary>
        FIC_RGB = 2,     // RGB color model
                                /// <summary>
                                /// The fic palette
                                /// </summary>
        FIC_PALETTE = 3,     // color map indexed
                                /// <summary>
                                /// The fic rgbalpha
                                /// </summary>
        FIC_RGBALPHA = 4,     // RGB color model with alpha channel
                                /// <summary>
                                /// The fic cmyk
                                /// </summary>
        FIC_CMYK = 5		// CMYK color model
	};

    /** Color quantization algorithms.
	Constants used in FreeImage_ColorQuantize.
	*/
    /// <summary>
    /// Enum FREE_IMAGE_QUANTIZE
    /// </summary>
    public enum FREE_IMAGE_QUANTIZE	{
        /// <summary>
        /// The fiq wuquant
        /// </summary>
        FIQ_WUQUANT = 0,        // Xiaolin Wu color quantization algorithm
                                /// <summary>
                                /// The fiq nnquant
                                /// </summary>
        FIQ_NNQUANT = 1			// NeuQuant neural-net quantization algorithm by Anthony Dekker
	}

    /** Dithering algorithms.
	Constants used in FreeImage_Dither.
	*/
    /// <summary>
    /// Enum FREE_IMAGE_DITHER
    /// </summary>
    public enum FREE_IMAGE_DITHER {
        /// <summary>
        /// The fid fs
        /// </summary>
        FID_FS = 0,    // Floyd & Steinberg error diffusion
                                /// <summary>
                                /// The fid baye R4X4
                                /// </summary>
        FID_BAYER4x4 = 1,    // Bayer ordered dispersed dot dithering (order 2 dithering matrix)
                                /// <summary>
                                /// The fid baye R8X8
                                /// </summary>
        FID_BAYER8x8 = 2,    // Bayer ordered dispersed dot dithering (order 3 dithering matrix)
                                /// <summary>
                                /// The fid cluste R6X6
                                /// </summary>
        FID_CLUSTER6x6 = 3,    // Ordered clustered dot dithering (order 3 - 6x6 matrix)
                                /// <summary>
                                /// The fid cluste R8X8
                                /// </summary>
        FID_CLUSTER8x8 = 4,    // Ordered clustered dot dithering (order 4 - 8x8 matrix)
                                /// <summary>
                                /// The fid cluste R16X16
                                /// </summary>
        FID_CLUSTER16x16 = 5,    // Ordered clustered dot dithering (order 8 - 16x16 matrix)
                                /// <summary>
                                /// The fid baye R16X16
                                /// </summary>
        FID_BAYER16x16 = 6		// Bayer ordered dispersed dot dithering (order 4 dithering matrix)
	}
    /** Lossless JPEG transformations
	Constants used in FreeImage_JPEGTransform
	*/
    /// <summary>
    /// Enum FREE_IMAGE_JPEG_OPERATION
    /// </summary>
    public enum FREE_IMAGE_JPEG_OPERATION {
        /// <summary>
        /// The fijpeg op none
        /// </summary>
        FIJPEG_OP_NONE = 0,    // no transformation
                                        /// <summary>
                                        /// The fijpeg op flip h
                                        /// </summary>
        FIJPEG_OP_FLIP_H = 1,    // horizontal flip
                                        /// <summary>
                                        /// The fijpeg op flip v
                                        /// </summary>
        FIJPEG_OP_FLIP_V = 2,    // vertical flip
                                        /// <summary>
                                        /// The fijpeg op transpose
                                        /// </summary>
        FIJPEG_OP_TRANSPOSE = 3,    // transpose across UL-to-LR axis
                                        /// <summary>
                                        /// The fijpeg op transverse
                                        /// </summary>
        FIJPEG_OP_TRANSVERSE = 4,    // transpose across UR-to-LL axis
                                        /// <summary>
                                        /// The fijpeg op rotate 90
                                        /// </summary>
        FIJPEG_OP_ROTATE_90 = 5,    // 90-degree clockwise rotation
                                        /// <summary>
                                        /// The fijpeg op rotate 180
                                        /// </summary>
        FIJPEG_OP_ROTATE_180 = 6,    // 180-degree rotation
                                        /// <summary>
                                        /// The fijpeg op rotate 270
                                        /// </summary>
        FIJPEG_OP_ROTATE_270 = 7		// 270-degree clockwise (or 90 ccw)
	};

    /** Tone mapping operators.
	Constants used in FreeImage_ToneMapping.
	*/
    /// <summary>
    /// Enum FREE_IMAGE_TMO
    /// </summary>
    public enum FREE_IMAGE_TMO {
        /// <summary>
        /// The fitmo drag o03
        /// </summary>
        FITMO_DRAGO03 = 0,   // Adaptive logarithmic mapping (F. Drago, 2003)
                                /// <summary>
                                /// The fitmo reinhar D05
                                /// </summary>
        FITMO_REINHARD05 = 1,   // Dynamic range reduction inspired by photoreceptor physiology (E. Reinhard, 2005)
                                /// <summary>
                                /// The fitmo fatta L02
                                /// </summary>
        FITMO_FATTAL02 = 2	// Gradient domain high dynamic range compression (R. Fattal, 2002)
	};

    /** Upsampling / downsampling filters. 
	Constants used in FreeImage_Rescale.
	*/
    /// <summary>
    /// Enum FREE_IMAGE_FILTER
    /// </summary>
    public enum FREE_IMAGE_FILTER {
        /// <summary>
        /// The filter box
        /// </summary>
        FILTER_BOX = 0,  // Box, pulse, Fourier window, 1st order (constant) b-spline
                                /// <summary>
                                /// The filter bicubic
                                /// </summary>
        FILTER_BICUBIC = 1,  // Mitchell & Netravali's two-param cubic filter
                                /// <summary>
                                /// The filter bilinear
                                /// </summary>
        FILTER_BILINEAR = 2,  // Bilinear filter
                                /// <summary>
                                /// The filter bspline
                                /// </summary>
        FILTER_BSPLINE = 3,  // 4th order (cubic) b-spline
                                /// <summary>
                                /// The filter catmullrom
                                /// </summary>
        FILTER_CATMULLROM = 4,  // Catmull-Rom spline, Overhauser spline
                                /// <summary>
                                /// The filter lanczo s3
                                /// </summary>
        FILTER_LANCZOS3 = 5	// Lanczos3 filter
	}

    /** Color channels.
	Constants used in color manipulation routines.
	*/
    /// <summary>
    /// Enum FREE_IMAGE_COLOR_CHANNEL
    /// </summary>
    public enum FREE_IMAGE_COLOR_CHANNEL {
        /// <summary>
        /// The ficc RGB
        /// </summary>
        FICC_RGB = 0,    // Use red, green and blue channels
                            /// <summary>
                            /// The ficc red
                            /// </summary>
        FICC_RED = 1,    // Use red channel
                            /// <summary>
                            /// The ficc green
                            /// </summary>
        FICC_GREEN = 2,    // Use green channel
                            /// <summary>
                            /// The ficc blue
                            /// </summary>
        FICC_BLUE = 3,    // Use blue channel
                            /// <summary>
                            /// The ficc alpha
                            /// </summary>
        FICC_ALPHA = 4,    // Use alpha channel
                            /// <summary>
                            /// The ficc black
                            /// </summary>
        FICC_BLACK = 5,    // Use black channel
                            /// <summary>
                            /// The ficc real
                            /// </summary>
        FICC_REAL = 6,    // Complex images: use real part
                            /// <summary>
                            /// The ficc imag
                            /// </summary>
        FICC_IMAG = 7,    // Complex images: use imaginary part
                            /// <summary>
                            /// The ficc mag
                            /// </summary>
        FICC_MAG = 8,    // Complex images: use magnitude
                            /// <summary>
                            /// The ficc phase
                            /// </summary>
        FICC_PHASE = 9		// Complex images: use phase
	}

    // Metadata support ---------------------------------------------------------

    /**
	  Tag data type information (based on TIFF specifications)
	
	  Note: RATIONALs are the ratio of two 32-bit integer values.
	*/
    /// <summary>
    /// Enum FREE_IMAGE_MDTYPE
    /// </summary>
    public enum FREE_IMAGE_MDTYPE {
        /// <summary>
        /// The fidt notype
        /// </summary>
        FIDT_NOTYPE = 0,    // placeholder 
                                /// <summary>
                                /// The fidt byte
                                /// </summary>
        FIDT_BYTE = 1,    // 8-bit unsigned integer 
                                /// <summary>
                                /// The fidt ASCII
                                /// </summary>
        FIDT_ASCII = 2,    // 8-bit bytes w/ last byte null 
                                /// <summary>
                                /// The fidt short
                                /// </summary>
        FIDT_SHORT = 3,    // 16-bit unsigned integer 
                                /// <summary>
                                /// The fidt long
                                /// </summary>
        FIDT_LONG = 4,    // 32-bit unsigned integer 
                                /// <summary>
                                /// The fidt rational
                                /// </summary>
        FIDT_RATIONAL = 5,    // 64-bit unsigned fraction 
                                /// <summary>
                                /// The fidt sbyte
                                /// </summary>
        FIDT_SBYTE = 6,    // 8-bit signed integer 
                                /// <summary>
                                /// The fidt undefined
                                /// </summary>
        FIDT_UNDEFINED = 7,    // 8-bit untyped data 
                                /// <summary>
                                /// The fidt sshort
                                /// </summary>
        FIDT_SSHORT = 8,    // 16-bit signed integer 
                                /// <summary>
                                /// The fidt slong
                                /// </summary>
        FIDT_SLONG = 9,    // 32-bit signed integer 
                                /// <summary>
                                /// The fidt srational
                                /// </summary>
        FIDT_SRATIONAL = 10,   // 64-bit signed fraction 
                                /// <summary>
                                /// The fidt float
                                /// </summary>
        FIDT_FLOAT = 11,   // 32-bit IEEE floating point 
                                /// <summary>
                                /// The fidt double
                                /// </summary>
        FIDT_DOUBLE = 12,   // 64-bit IEEE floating point 
                                /// <summary>
                                /// The fidt ifd
                                /// </summary>
        FIDT_IFD = 13,   // 32-bit unsigned integer (offset) 
                                /// <summary>
                                /// The fidt palette
                                /// </summary>
        FIDT_PALETTE = 14	// 32-bit RGBQUAD 
	};

    /**
	  Metadata models supported by FreeImage
	*/
    /// <summary>
    /// Enum FREE_IMAGE_MDMODEL
    /// </summary>
    public enum FREE_IMAGE_MDMODEL {
        /// <summary>
        /// The fimd nodata
        /// </summary>
        FIMD_NODATA = -1,
        /// <summary>
        /// The fimd comments
        /// </summary>
        FIMD_COMMENTS = 0,    // single comment or keywords
                                    /// <summary>
                                    /// The fimd exif main
                                    /// </summary>
        FIMD_EXIF_MAIN = 1,    // Exif-TIFF metadata
                                    /// <summary>
                                    /// The fimd exif exif
                                    /// </summary>
        FIMD_EXIF_EXIF = 2,    // Exif-specific metadata
                                    /// <summary>
                                    /// The fimd exif GPS
                                    /// </summary>
        FIMD_EXIF_GPS = 3,    // Exif GPS metadata
                                    /// <summary>
                                    /// The fimd exif makernote
                                    /// </summary>
        FIMD_EXIF_MAKERNOTE = 4,    // Exif maker note metadata
                                    /// <summary>
                                    /// The fimd exif interop
                                    /// </summary>
        FIMD_EXIF_INTEROP = 5,    // Exif interoperability metadata
                                    /// <summary>
                                    /// The fimd iptc
                                    /// </summary>
        FIMD_IPTC = 6,    // IPTC/NAA metadata
                                    /// <summary>
                                    /// The fimd XMP
                                    /// </summary>
        FIMD_XMP = 7,    // Abobe XMP metadata
                                    /// <summary>
                                    /// The fimd geotiff
                                    /// </summary>
        FIMD_GEOTIFF = 8,    // GeoTIFF metadata
                                    /// <summary>
                                    /// The fimd animation
                                    /// </summary>
        FIMD_ANIMATION = 9,    // Animation metadata
                                    /// <summary>
                                    /// The fimd custom
                                    /// </summary>
        FIMD_CUSTOM = 10	// Used to attach other metadata types to a dib
	};


    // Message output function --------------------------------------------------

    /// <summary>
    /// Delegate FreeImage_OutputMessageFunction
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="msg">The MSG.</param>
    public delegate void FreeImage_OutputMessageFunction(FREE_IMAGE_FORMAT format, string msg);

    /**
	  FreeImage API
	  See the FreeImage PDF documentation for a definition of each function. 
	*/


    /// <summary>
    /// Class FreeImageApi.
    /// </summary>
    internal class FreeImageApi
	{
        // Init/Error routines ----------------------------------------
        /// <summary>
        /// Initialises the specified load local plugins only.
        /// </summary>
        /// <param name="loadLocalPluginsOnly">if set to <c>true</c> [load local plugins only].</param>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_Initialise")]
		public static extern void Initialise(bool loadLocalPluginsOnly);

        // alias for Americans :)
        /// <summary>
        /// Initializes the specified load local plugins only.
        /// </summary>
        /// <param name="loadLocalPluginsOnly">if set to <c>true</c> [load local plugins only].</param>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_Initialise")]
		public static extern void Initialize(bool loadLocalPluginsOnly);


        /// <summary>
        /// Des the initialise.
        /// </summary>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_DeInitialise")]
		public static extern void DeInitialise();

        // alias for Americians :)
        /// <summary>
        /// Des the initialize.
        /// </summary>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_DeInitialise")]
		public static extern void DeInitialize();

        /// <summary>
        /// Closes the memory.
        /// </summary>
        /// <param name="stream">The stream.</param>
        [DllImport("FreeImage.dll", EntryPoint = "FreeImage_CloseMemory")]
		public static extern void CloseMemory(IntPtr stream);

        // Version routines -------------------------------------------
        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <returns>System.String.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetVersion")]
		public static extern string GetVersion();

        /// <summary>
        /// Gets the copyright message.
        /// </summary>
        /// <returns>System.String.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetCopyrightMessage")]
		public static extern string GetCopyrightMessage();



        // Message Output routines ------------------------------------
        // missing void FreeImage_OutputMessageProc(int fif, 
        // 				const char *fmt, ...);

        /// <summary>
        /// Sets the output message.
        /// </summary>
        /// <param name="omf">The omf.</param>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_SetOutputMessage")]
		public static extern void SetOutputMessage(FreeImage_OutputMessageFunction omf);



        // Allocate/Clone/Unload routines -----------------------------
        /// <summary>
        /// Allocates the specified width.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="bpp">The BPP.</param>
        /// <param name="red_mask">The red mask.</param>
        /// <param name="green_mask">The green mask.</param>
        /// <param name="blue_mask">The blue mask.</param>
        /// <returns>FIBITMAP.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_Allocate")]
		public static extern FIBITMAP Allocate(int width, int height, 
				int bpp, uint red_mask, uint green_mask, uint blue_mask);

        /// <summary>
        /// Allocates the t.
        /// </summary>
        /// <param name="ftype">The ftype.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="bpp">The BPP.</param>
        /// <param name="red_mask">The red mask.</param>
        /// <param name="green_mask">The green mask.</param>
        /// <param name="blue_mask">The blue mask.</param>
        /// <returns>FIBITMAP.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_AllocateT")]
		public static extern FIBITMAP AllocateT(FREE_IMAGE_TYPE ftype, int width, 
				int height, int bpp, uint red_mask, uint green_mask, 
				uint blue_mask);

        /// <summary>
        /// Clones the specified dib.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns>FIBITMAP.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_Clone")]
		public static extern FIBITMAP Clone(FIBITMAP dib);

        /// <summary>
        /// Unloads the specified dib.
        /// </summary>
        /// <param name="dib">The dib.</param>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_Unload")]
		public static extern void Unload(FIBITMAP dib);



        // Load/Save routines -----------------------------------------
        /// <summary>
        /// Loads the specified format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="flags">The flags.</param>
        /// <returns>FIBITMAP.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_Load")]
		public static extern FIBITMAP Load(FREE_IMAGE_FORMAT format, string filename, int flags);

        // missing FIBITMAP FreeImage_LoadFromHandle(FREE_IMAGE_FORMAT fif,
        // 				FreeImageIO *io, fi_handle handle, int flags);

        /// <summary>
        /// Saves the specified format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="dib">The dib.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="flags">The flags.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_Save")]
		public static extern bool Save(FREE_IMAGE_FORMAT format, FIBITMAP dib, string filename, int flags);

        // missing BOOL FreeImage_SaveToHandle(FREE_IMAGE_FORMAT fif, FIBITMAP *dib,
        // 				FreeImageIO *io, fi_handle handle, int flags);

        // Memory I/O stream routines -----------------------------------------------

        /// <summary>
        /// Opens the memory.
        /// </summary>
        /// <param name="bits">The bits.</param>
        /// <param name="size_in_bytes">The size in bytes.</param>
        /// <returns>FIMEMORY.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_OpenMemory")] 
		public static extern FIMEMORY OpenMemory(IntPtr bits, Int32 size_in_bytes);

        /// <summary>
        /// Closes the memory.
        /// </summary>
        /// <param name="stream">The stream.</param>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_CloseMemory")] 
		public static extern void CloseMemory(FIMEMORY stream);

        /// <summary>
        /// Loads from memory.
        /// </summary>
        /// <param name="fif">The fif.</param>
        /// <param name="stream">The stream.</param>
        /// <param name="flags">The flags.</param>
        /// <returns>FIBITMAP.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_LoadFromMemory")] 
		public static extern FIBITMAP LoadFromMemory(FREE_IMAGE_FORMAT fif, FIMEMORY stream, int flags);

        /// <summary>
        /// Saves to memory.
        /// </summary>
        /// <param name="fif">The fif.</param>
        /// <param name="dib">The dib.</param>
        /// <param name="stream">The stream.</param>
        /// <param name="flags">The flags.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_SaveToMemory")] 
		public static extern bool SaveToMemory(FREE_IMAGE_FORMAT fif, FIBITMAP dib, FIMEMORY stream, int flags);

        /// <summary>
        /// Tells the memory.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="flags">The flags.</param>
        /// <returns>System.Int64.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_TellMemory")] 
		public static extern long TellMemory(FIMEMORY stream, int flags);

        /// <summary>
        /// Seeks the memory.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="origin">The origin.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_SeekMemory")] 
		public static extern bool SeekMemory(FIMEMORY stream, long offset, int origin);

        /// <summary>
        /// Acquires the memory.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="data">The data.</param>
        /// <param name="size_in_bytes">The size in bytes.</param>
        /// <returns>System.Int64.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_AcquireMemory")] 
		public static extern long AcquireMemory(FIMEMORY stream, ref IntPtr data, ref int size_in_bytes);


        // Plugin interface -------------------------------------------

        // missing FREE_IMAGE_FORMAT FreeImage_RegisterLocalPlugin(FI_InitProc proc_address, 
        // 				const char *format, const char *description, 
        // 				const char *extension, const char *regexpr);
        //
        // missing FREE_IMAGE_FORMAT FreeImage_RegisterExternalPlugin(const char *path,
        // 				const char *format, const char *description,
        // 				const char *extension, const char *regexpr);

        /// <summary>
        /// Gets the fif count.
        /// </summary>
        /// <returns>System.Int32.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetFIFCount")]
		public static extern int GetFIFCount();

        /// <summary>
        /// Sets the plugin enabled.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="enabled">if set to <c>true</c> [enabled].</param>
        /// <returns>System.Int32.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_SetPluginEnabled")]
		public static extern int SetPluginEnabled(FREE_IMAGE_FORMAT format, bool enabled);

        /// <summary>
        /// Determines whether [is plugin enabled] [the specified format].
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_IsPluginEnabled")]
		public static extern int IsPluginEnabled(FREE_IMAGE_FORMAT format);

        /// <summary>
        /// Gets the fif from format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns>FREE_IMAGE_FORMAT.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetFIFFromFormat")]
		public static extern FREE_IMAGE_FORMAT GetFIFFromFormat(string format);

        /// <summary>
        /// Gets the fif from MIME.
        /// </summary>
        /// <param name="mime">The MIME.</param>
        /// <returns>FREE_IMAGE_FORMAT.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetFIFFromMime")]
		public static extern FREE_IMAGE_FORMAT GetFIFFromMime(string mime);

        /// <summary>
        /// Gets the format from fif.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns>System.String.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetFormatFromFIF")]
		public static extern string GetFormatFromFIF(FREE_IMAGE_FORMAT format);

        /// <summary>
        /// Gets the fif extension list.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns>System.String.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetFIFExtensionList")]
		public static extern string GetFIFExtensionList(FREE_IMAGE_FORMAT format);

        /// <summary>
        /// Gets the fif description.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns>System.String.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetFIFDescription")]
		public static extern string GetFIFDescription(FREE_IMAGE_FORMAT format);

        /// <summary>
        /// Gets the fif reg expr.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns>System.String.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetFIFRegExpr")]
		public static extern string GetFIFRegExpr(FREE_IMAGE_FORMAT format);

        /// <summary>
        /// Gets the fif from filename.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>FREE_IMAGE_FORMAT.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetFIFFromFilename")]
		public static extern FREE_IMAGE_FORMAT GetFIFFromFilename([MarshalAs( UnmanagedType.LPStr) ]string filename);

        /// <summary>
        /// Fifs the supports reading.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_FIFSupportsReading")]
		public static extern bool FIFSupportsReading(FREE_IMAGE_FORMAT format);

        /// <summary>
        /// Fifs the supports writing.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_FIFSupportsWriting")]
		public static extern bool FIFSupportsWriting(FREE_IMAGE_FORMAT format);

        /// <summary>
        /// Fifs the supports export BPP.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="bpp">The BPP.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_FIFSupportsExportBPP")]
		public static extern bool FIFSupportsExportBPP(FREE_IMAGE_FORMAT format, int bpp);

        /// <summary>
        /// Fifs the type of the supports export.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="ftype">The ftype.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_FIFSupportsExportType")]
		public static extern bool FIFSupportsExportType(FREE_IMAGE_FORMAT format, FREE_IMAGE_TYPE ftype);

        /// <summary>
        /// Fifs the supports icc profiles.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="ftype">The ftype.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_FIFSupportsICCProfiles")]
		public static extern bool FIFSupportsICCProfiles(FREE_IMAGE_FORMAT format, FREE_IMAGE_TYPE ftype);



        // Multipage interface ----------------------------------------
        /// <summary>
        /// Opens the multi bitmap.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="createNew">if set to <c>true</c> [create new].</param>
        /// <param name="readOnly">if set to <c>true</c> [read only].</param>
        /// <param name="keepCacheInMemory">if set to <c>true</c> [keep cache in memory].</param>
        /// <returns>FIMULTIBITMAP.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_OpenMultiBitmap")]
		public static extern FIMULTIBITMAP OpenMultiBitmap(
			FREE_IMAGE_FORMAT format, string filename, bool createNew, bool readOnly, bool keepCacheInMemory);

        /// <summary>
        /// Closes the multi bitmap.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="flags">The flags.</param>
        /// <returns>System.Int64.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_CloseMultiBitmap")]
		public static extern long CloseMultiBitmap(FIMULTIBITMAP bitmap, int flags);

        /// <summary>
        /// Gets the page count.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetPageCount")]
		public static extern int GetPageCount(FIMULTIBITMAP bitmap);

        /// <summary>
        /// Appends the page.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="data">The data.</param>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_AppendPage")]
		public static extern void AppendPage(FIMULTIBITMAP bitmap, FIBITMAP data);

        /// <summary>
        /// Inserts the page.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="page">The page.</param>
        /// <param name="data">The data.</param>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_InsertPage")]
		public static extern void InsertPage(FIMULTIBITMAP bitmap, int page, FIBITMAP data);

        /// <summary>
        /// Deletes the page.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="page">The page.</param>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_DeletePage")]
		public static extern void DeletePage(FIMULTIBITMAP bitmap, int page);

        /// <summary>
        /// Locks the page.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="page">The page.</param>
        /// <returns>FIBITMAP.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_LockPage")]
		public static extern FIBITMAP LockPage(FIMULTIBITMAP bitmap, int page);

        /// <summary>
        /// Unlocks the page.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="page">The page.</param>
        /// <param name="changed">if set to <c>true</c> [changed].</param>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_UnlockPage")]
		public static extern void UnlockPage(FIMULTIBITMAP bitmap, int page, bool changed);

        /// <summary>
        /// Moves the page.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_MovePage")]
		public static extern bool MovePage(FIMULTIBITMAP bitmap, int target, int source);

        /// <summary>
        /// Gets the locked page numbers.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="pages">The pages.</param>
        /// <param name="count">The count.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetLockedPageNumbers")]
		public static extern bool GetLockedPageNumbers(FIMULTIBITMAP bitmap, IntPtr pages, IntPtr count);



        // File type request routines ---------------------------------
        /// <summary>
        /// Gets the type of the file.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="size">The size.</param>
        /// <returns>FREE_IMAGE_FORMAT.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetFileType")]
		public static extern FREE_IMAGE_FORMAT GetFileType(string filename, int size);

        // missing FREE_IMAGE_FORMAT FreeImage_GetFileTypeFromHandle(FreeImageIO *io,
        // 			fi_handle handle, int size);

        /// <summary>
        /// Gets the file type from memory.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="size">The size.</param>
        /// <returns>FREE_IMAGE_FORMAT.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetFileTypeFromMemory")]
		public static extern FREE_IMAGE_FORMAT GetFileTypeFromMemory(FIMEMORY stream, int size);

        // Image type request routines --------------------------------
        /// <summary>
        /// Gets the type of the image.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns>FREE_IMAGE_TYPE.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetImageType")]
		public static extern FREE_IMAGE_TYPE GetImageType(FIBITMAP dib);

        // FreeImage helper routines ------------------------------------------------

        /// <summary>
        /// Determines whether [is little endian].
        /// </summary>
        /// <returns><c>true</c> if [is little endian]; otherwise, <c>false</c>.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_IsLittleEndian")]
		public static extern bool IsLittleEndian();

        /// <summary>
        /// Lookups the color of the X11.
        /// </summary>
        /// <param name="szColor">Color of the sz.</param>
        /// <param name="red">The red.</param>
        /// <param name="green">The green.</param>
        /// <param name="blue">The blue.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_LookupX11Color")]
		public static extern bool LookupX11Color(string szColor, ref int red, ref int green, ref int blue);

        /// <summary>
        /// Lookups the color of the SVG.
        /// </summary>
        /// <param name="szColor">Color of the sz.</param>
        /// <param name="red">The red.</param>
        /// <param name="green">The green.</param>
        /// <param name="blue">The blue.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_LookupSVGColor")]
		public static extern bool LookupSVGColor(string szColor, ref int red, ref int green, ref int blue);

        // Pixel access functions -------------------------------------
        /// <summary>
        /// Gets the bits.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetBits")]
		public static extern IntPtr GetBits(FIBITMAP dib);

        /// <summary>
        /// Gets the scan line.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="scanline">The scanline.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetScanLine")]
		public static extern IntPtr GetScanLine(FIBITMAP dib, int scanline);

        /// <summary>
        /// Gets the index of the pixel.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetPixelIndex")]
		public static extern bool GetPixelIndex(FIBITMAP dib, uint x, uint y, ref byte value);

        /// <summary>
        /// Gets the color of the pixel.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetPixelColor")]
		public static extern bool GetPixelColor(FIBITMAP dib, uint x, uint y, 
			[Out, MarshalAs(UnmanagedType.LPStruct)]RGBQUAD value);

        /// <summary>
        /// Sets the index of the pixel.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_SetPixelIndex")]
		public static extern bool SetPixelIndex(FIBITMAP dib, uint x, uint y, ref byte value);

        /// <summary>
        /// Sets the color of the pixel.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_SetPixelColor")]
		public static extern bool SetPixelColor(FIBITMAP dib, uint x, uint y, 
			[In, MarshalAs(UnmanagedType.LPStruct)] RGBQUAD value);

        // DIB info routines --------------------------------------------------------

        /// <summary>
        /// Gets the colors used.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns>System.UInt32.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetColorsUsed")]
		public static extern uint GetColorsUsed(FIBITMAP dib);

        /// <summary>
        /// Gets the BPP.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns>System.UInt32.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetBPP")]
		public static extern uint GetBPP(FIBITMAP dib);

        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns>System.UInt32.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetWidth")]
		public static extern uint GetWidth(FIBITMAP dib);

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns>System.UInt32.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetHeight")]
		public static extern uint GetHeight(FIBITMAP dib);

        /// <summary>
        /// Gets the line.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns>System.UInt32.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetLine")]
		public static extern uint GetLine(FIBITMAP dib);

        /// <summary>
        /// Gets the pitch.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns>System.UInt32.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetPitch")]
		public static extern uint GetPitch(FIBITMAP dib);

        /// <summary>
        /// Gets the size of the dib.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns>System.UInt32.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetDIBSize")]
		public static extern uint GetDIBSize(FIBITMAP dib);

        /**
		Returns a pointer to the bitmap�s palette. If the bitmap doesn�t have a palette 
		(i.e. when the pixel bit depth is greater than 8), this function returns NULL. 
		@param dib Bitmap to get the palette for.
		@return Pointer to the start of the palette data.
		*/
        /// <summary>
        /// Gets the raw palette.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns>UIntPtr.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetPalette")] 
		private static extern UIntPtr GetRawPalette(FIBITMAP dib);

        /**
		Get a deep copy of the image palette.
		@param bitmap Pointer to a loaded image.
		@return Array or RGBQUAD values representing the image palette.
		*/
        /// <summary>
        /// Gets the palette copy.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns>RGBQUAD[].</returns>
        public static unsafe RGBQUAD [] GetPaletteCopy(FIBITMAP dib) {  
			RGBQUAD [] paletteCopy = new RGBQUAD[256];  
 
			// Only interested in indexed images. 
			if (GetBPP(dib) <= 8) { 
				UIntPtr palette = GetRawPalette(dib);  
 				byte * ptr = (byte *)(void*)palette; 
 				for (int q = 0; q < 256; q++) { 
					paletteCopy[q] = new RGBQUAD(); 
					paletteCopy[q].rgbBlue = (byte)*ptr; 
					ptr += 1;  
					paletteCopy[q].rgbGreen = (byte)*ptr; 
					ptr += 1;  
					paletteCopy[q].rgbRed = (byte)*ptr; 
					ptr += 1;  
					paletteCopy[q].rgbReserved = (byte)*ptr; 
					ptr += 1;  
				}  
			} 
 
			return paletteCopy; 
		}

        /// <summary>
        /// Gets the dots per meter x.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns>System.UInt32.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetDotsPerMeterX")]
		public static extern uint GetDotsPerMeterX(FIBITMAP dib);

        /// <summary>
        /// Gets the dots per meter y.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns>System.UInt32.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetDotsPerMeterY")]
		public static extern uint GetDotsPerMeterY(FIBITMAP dib);

        /// <summary>
        /// Sets the dots per meter x.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="res">The resource.</param>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_SetDotsPerMeterX")]
		public static extern void SetDotsPerMeterX(FIBITMAP dib, uint res);

        /// <summary>
        /// Sets the dots per meter y.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="res">The resource.</param>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_SetDotsPerMeterY")]
		public static extern void SetDotsPerMeterY(FIBITMAP dib, uint res);

        /// <summary>
        /// Frees the image get information header.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("FreeImage.dll", EntryPoint = "FreeImage_GetInfoHeader")]
		public static extern IntPtr FreeImage_GetInfoHeader(FIBITMAP dib);

        /// <summary>
        /// Frees the image get information.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("FreeImage.dll", EntryPoint = "FreeImage_GetInfo")]
		public static extern IntPtr FreeImage_GetInfo(FIBITMAP dib);

        /// <summary>
        /// Gets the type of the color.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns>FREE_IMAGE_COLOR_TYPE.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetColorType")]
		public static extern FREE_IMAGE_COLOR_TYPE GetColorType(FIBITMAP dib);

        /// <summary>
        /// Gets the red mask.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns>System.UInt32.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetRedMask")]
		public static extern uint GetRedMask(FIBITMAP dib);

        /// <summary>
        /// Gets the green mask.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns>System.UInt32.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetGreenMask")]
		public static extern uint GetGreenMask(FIBITMAP dib);

        /// <summary>
        /// Gets the blue mask.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns>System.UInt32.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetBlueMask")]
		public static extern uint GetBlueMask(FIBITMAP dib);

        /// <summary>
        /// Gets the transparency count.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns>System.UInt32.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetTransparencyCount")]
		public static extern uint GetTransparencyCount(FIBITMAP dib);

        /// <summary>
        /// Gets the transparency table.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetTransparencyTable")]
		public static extern IntPtr GetTransparencyTable(FIBITMAP dib);

        /// <summary>
        /// Sets the transparent.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="enabled">if set to <c>true</c> [enabled].</param>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_SetTransparent")]
		public static extern void SetTransparent(FIBITMAP dib, bool enabled);

        /// <summary>
        /// Sets the transparency table.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="table">The table.</param>
        /// <param name="count">The count.</param>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_SetTransparencyTable")]
		public static extern void SetTransparencyTable(FIBITMAP dib, IntPtr table, int count);

        /// <summary>
        /// Determines whether the specified dib is transparent.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns><c>true</c> if the specified dib is transparent; otherwise, <c>false</c>.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_IsTransparent")]
		public static extern bool IsTransparent(FIBITMAP dib);

        /// <summary>
        /// Determines whether [has background color] [the specified dib].
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns><c>true</c> if [has background color] [the specified dib]; otherwise, <c>false</c>.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_HasBackgroundColor")]
		public static extern bool HasBackgroundColor(FIBITMAP dib);

        /// <summary>
        /// Gets the color of the background.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="bkcolor">The bkcolor.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetBackgroundColor")]
		public static extern bool GetBackgroundColor(FIBITMAP dib, 
			[Out, MarshalAs(UnmanagedType.LPStruct)]RGBQUAD bkcolor);

        /// <summary>
        /// Sets the color of the background.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="bkcolor">The bkcolor.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_SetBackgroundColor")]
		public static extern bool SetBackgroundColor(FIBITMAP dib, 
			[In, MarshalAs(UnmanagedType.LPStruct)]RGBQUAD bkcolor);

        // ICC profile routines -----------------------------------------------------

        /// <summary>
        /// Destroys the icc profile.
        /// </summary>
        /// <param name="dib">The dib.</param>
        [DllImport("FreeImage.dll",EntryPoint="FreeImage_DestroyICCProfile")]
		public static extern void DestroyICCProfile(FIBITMAP dib);

        /// <summary>
        /// Gets the icc profile.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns>FIICCPROFILE.</returns>
        [DllImport("FreeImage.dll",EntryPoint="FreeImage_GetICCProfile")]
		public static extern FIICCPROFILE GetICCProfile(FIBITMAP dib);

        /// <summary>
        /// Creates the icc profile.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="data">The data.</param>
        /// <param name="size">The size.</param>
        /// <returns>FIICCPROFILE.</returns>
        [DllImport("FreeImage.dll",EntryPoint="FreeImage_CreateICCProfile")]
		public static extern FIICCPROFILE CreateICCProfile(FIBITMAP dib, IntPtr data, uint size);

        // Smart conversion routines ------------------------------------------------

        /// <summary>
        /// Converts the to4 bits.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns>FIBITMAP.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_ConvertTo4Bits")]
		public static extern FIBITMAP ConvertTo4Bits(FIBITMAP dib);

        /// <summary>
        /// Converts the to8 bits.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns>FIBITMAP.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_ConvertTo8Bits")]
		public static extern FIBITMAP ConvertTo8Bits(FIBITMAP dib);

        /// <summary>
        /// Converts the to16 bits555.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns>FIBITMAP.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_ConvertTo16Bits555")]
		public static extern FIBITMAP ConvertTo16Bits555(FIBITMAP dib);

        /// <summary>
        /// Converts the to16 bits565.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns>FIBITMAP.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_ConvertTo16Bits565")]
		public static extern FIBITMAP ConvertTo16Bits565(FIBITMAP dib);

        /// <summary>
        /// Converts the to24 bits.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns>FIBITMAP.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_ConvertTo24Bits")]
		public static extern FIBITMAP ConvertTo24Bits(FIBITMAP dib);

        /// <summary>
        /// Converts the to32 bits.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns>FIBITMAP.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_ConvertTo32Bits")]
		public static extern FIBITMAP ConvertTo32Bits(FIBITMAP dib);

        /// <summary>
        /// Colors the quantize.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="quantize">The quantize.</param>
        /// <returns>FIBITMAP.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_ColorQuantize")]
		public static extern FIBITMAP ColorQuantize(FIBITMAP dib, FREE_IMAGE_QUANTIZE quantize);

        /// <summary>
        /// Thresholds the specified dib.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="T">The t.</param>
        /// <returns>FIBITMAP.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_Threshold")]
		public static extern FIBITMAP Threshold(FIBITMAP dib, uint T);

        /// <summary>
        /// Dithers the specified dib.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="algorithm">The algorithm.</param>
        /// <returns>FIBITMAP.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_Dither")]
		public static extern FIBITMAP Dither(FIBITMAP dib, FREE_IMAGE_DITHER algorithm);


        /// <summary>
        /// Thresholds the specified dib.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="t">The t.</param>
        /// <returns>FIBITMAP.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_Threshold")]
		public static extern FIBITMAP Threshold(FIBITMAP dib, byte t);


        /// <summary>
        /// Converts from raw bits.
        /// </summary>
        /// <param name="bits">The bits.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="pitch">The pitch.</param>
        /// <param name="bpp">The BPP.</param>
        /// <param name="redMask">The red mask.</param>
        /// <param name="greenMask">The green mask.</param>
        /// <param name="blueMask">The blue mask.</param>
        /// <param name="topDown">if set to <c>true</c> [top down].</param>
        /// <returns>FIBITMAP.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_ConvertFromRawBits")]
		public static extern FIBITMAP ConvertFromRawBits(byte[] bits, int width, int height,
			int pitch, uint bpp, uint redMask, uint greenMask, uint blueMask, bool topDown);

        /// <summary>
        /// Converts to raw bits.
        /// </summary>
        /// <param name="bits">The bits.</param>
        /// <param name="dib">The dib.</param>
        /// <param name="pitch">The pitch.</param>
        /// <param name="bpp">The BPP.</param>
        /// <param name="redMask">The red mask.</param>
        /// <param name="greenMask">The green mask.</param>
        /// <param name="blueMask">The blue mask.</param>
        /// <param name="topDown">if set to <c>true</c> [top down].</param>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_ConvertToRawBits")]
		public static extern void ConvertToRawBits(IntPtr bits, FIBITMAP dib, int pitch,
			uint bpp, uint redMask, uint greenMask, uint blueMask, bool topDown);

        /// <summary>
        /// Converts the type of to standard.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="dst_type">Type of the DST.</param>
        /// <param name="scale_linear">if set to <c>true</c> [scale linear].</param>
        /// <returns>FIBITMAP.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_ConvertToStandardType")]
		public static extern FIBITMAP ConvertToStandardType(FIBITMAP dib, FREE_IMAGE_TYPE dst_type, bool scale_linear);

        /// <summary>
        /// Converts to type.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="dst_type">Type of the DST.</param>
        /// <param name="scale_linear">if set to <c>true</c> [scale linear].</param>
        /// <returns>FIBITMAP.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_ConvertToType")]
		public static extern FIBITMAP ConvertToType(FIBITMAP dib, FREE_IMAGE_TYPE dst_type, bool scale_linear);

        /// <summary>
        /// Converts to RGBF.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns>FIBITMAP.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_ConvertToRGBF")]
		public static extern FIBITMAP ConvertToRGBF(FIBITMAP dib);

        /// <summary>
        /// Tones the mapping.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="tmo">The tmo.</param>
        /// <param name="first_param">The first parameter.</param>
        /// <param name="second_param">The second parameter.</param>
        /// <returns>FIBITMAP.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_ToneMapping")]
		public static extern FIBITMAP ToneMapping(FIBITMAP dib, FREE_IMAGE_TMO tmo, double first_param, double second_param);

        /// <summary>
        /// Tmoes the drago03.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="gamma">The gamma.</param>
        /// <param name="exposure">The exposure.</param>
        /// <returns>FIBITMAP.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_TmoDrago03")]
		public static extern FIBITMAP TmoDrago03(FIBITMAP dib, double gamma, double exposure);

        /// <summary>
        /// Tmoes the reinhard05.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="intensity">The intensity.</param>
        /// <param name="contrast">The contrast.</param>
        /// <returns>FIBITMAP.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_TmoReinhard05")]
		public static extern FIBITMAP TmoReinhard05(FIBITMAP dib, double intensity, double contrast);

        // ZLib interface -----------------------------------------------------------

        /// <summary>
        /// zs the library compress.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="target_size">Size of the target.</param>
        /// <param name="source">The source.</param>
        /// <param name="source_size">Size of the source.</param>
        /// <returns>Int32.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_ZLibCompress")]
		public static extern Int32 ZLibCompress(IntPtr target, Int32 target_size, IntPtr source, Int32 source_size);

        /// <summary>
        /// zs the library uncompress.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="target_size">Size of the target.</param>
        /// <param name="source">The source.</param>
        /// <param name="source_size">Size of the source.</param>
        /// <returns>Int32.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_ZLibUncompress")]
		public static extern Int32 ZLibUncompress(IntPtr target, Int32 target_size, IntPtr source, Int32 source_size);

        /// <summary>
        /// zs the library g zip.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="target_size">Size of the target.</param>
        /// <param name="source">The source.</param>
        /// <param name="source_size">Size of the source.</param>
        /// <returns>Int32.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_ZLibGZip")]
		public static extern Int32 ZLibGZip(IntPtr target, Int32 target_size, IntPtr source, Int32 source_size);

        /// <summary>
        /// zs the library g unzip.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="target_size">Size of the target.</param>
        /// <param name="source">The source.</param>
        /// <param name="source_size">Size of the source.</param>
        /// <returns>Int32.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_ZLibGUnzip")]
		public static extern Int32 ZLibGUnzip(IntPtr target, Int32 target_size, IntPtr source, Int32 source_size);

        /// <summary>
        /// zs the library cr C32.
        /// </summary>
        /// <param name="crc">The CRC.</param>
        /// <param name="source">The source.</param>
        /// <param name="source_size">Size of the source.</param>
        /// <returns>Int32.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_ZLibCRC32")]
		public static extern Int32 ZLibCRC32(Int32 crc, IntPtr source, Int32 source_size);

        // --------------------------------------------------------------------------
        // Image manipulation toolkit -----------------------------------------------
        // --------------------------------------------------------------------------

        // rotation and flipping

        /// <summary>
        /// Rotates the classic.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="angle">The angle.</param>
        /// <returns>FIBITMAP.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_RotateClassic")]
		public static extern FIBITMAP RotateClassic(FIBITMAP dib, double angle);

        /// <summary>
        /// Rotates the ex.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="angle">The angle.</param>
        /// <param name="xShift">The x shift.</param>
        /// <param name="yShift">The y shift.</param>
        /// <param name="xOrigin">The x origin.</param>
        /// <param name="yOrigin">The y origin.</param>
        /// <param name="useMask">if set to <c>true</c> [use mask].</param>
        /// <returns>FIBITMAP.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_RotateEx")]
		public static extern FIBITMAP RotateEx(
			FIBITMAP dib, Double angle, Double xShift, Double yShift, Double xOrigin, Double yOrigin, bool useMask);

        /// <summary>
        /// Flips the horizontal.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_FlipHorizontal")]
		public static extern bool FlipHorizontal(FIBITMAP dib);

        /// <summary>
        /// Flips the vertical.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_FlipVertical")]
		public static extern bool FlipVertical(FIBITMAP dib);

        /// <summary>
        /// JPEGs the transform.
        /// </summary>
        /// <param name="src_file">The source file.</param>
        /// <param name="dst_file">The DST file.</param>
        /// <param name="operation">The operation.</param>
        /// <param name="perfect">if set to <c>true</c> [perfect].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_JPEGTransform")]
		public static extern bool JPEGTransform(string src_file, string dst_file, FREE_IMAGE_JPEG_OPERATION operation, bool perfect);

        // upsampling / downsampling

        /// <summary>
        /// Rescales the specified dib.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="dst_width">Width of the DST.</param>
        /// <param name="dst_height">Height of the DST.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>FIBITMAP.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_Rescale")]
		public static extern FIBITMAP Rescale(FIBITMAP dib, int dst_width, int dst_height, FREE_IMAGE_FILTER filter);


        /// <summary>
        /// Adjusts the curve.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="lut">The lut.</param>
        /// <param name="channel">The channel.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_AdjustCurve")]
		public static extern bool AdjustCurve(FIBITMAP dib, byte[] lut, FREE_IMAGE_COLOR_CHANNEL channel);

        /// <summary>
        /// Adjusts the gamma.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="gamma">The gamma.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_AdjustGamma")]
		public static extern bool AdjustGamma(FIBITMAP dib, double gamma);

        /// <summary>
        /// Adjusts the brightness.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="percentage">The percentage.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_AdjustBrightness")]
		public static extern bool AdjustBrightness(FIBITMAP dib, double percentage);

        /// <summary>
        /// Adjusts the contrast.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="percentage">The percentage.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_AdjustContrast")]
		public static extern bool AdjustContrast(FIBITMAP dib, double percentage);


        /// <summary>
        /// Inverts the specified dib.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_Invert")]
		public static extern bool Invert(FIBITMAP dib);

        /// <summary>
        /// Gets the histogram.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="histo">The histo.</param>
        /// <param name="channel">The channel.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetHistogram")]
		public static extern bool GetHistogram(FIBITMAP dib, IntPtr histo, FREE_IMAGE_COLOR_CHANNEL channel);

        // channel processing routines

        /// <summary>
        /// Gets the channel.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="channel">The channel.</param>
        /// <returns>FIBITMAP.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_GetChannel")]
		public static extern FIBITMAP GetChannel(FIBITMAP dib, FREE_IMAGE_COLOR_CHANNEL channel);

        /// <summary>
        /// Sets the channel.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="dib8">The dib8.</param>
        /// <param name="channel">The channel.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_SetChannel")]
		public static extern bool SetChannel(FIBITMAP dib, FIBITMAP dib8, FREE_IMAGE_COLOR_CHANNEL channel);

        // copy / paste / composite routines

        /// <summary>
        /// Copies the specified dib.
        /// </summary>
        /// <param name="dib">The dib.</param>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="right">The right.</param>
        /// <param name="bottom">The bottom.</param>
        /// <returns>FIBITMAP.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_Copy")]
		public static extern FIBITMAP Copy(FIBITMAP dib, int left, int top, int right, int bottom);

        /// <summary>
        /// Pastes the specified DST.
        /// </summary>
        /// <param name="dst">The DST.</param>
        /// <param name="src">The source.</param>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="alpha">The alpha.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_Paste")]
		public static extern bool Paste(FIBITMAP dst, FIBITMAP src, int left, int top, int alpha);

        /// <summary>
        /// Composites the specified fg.
        /// </summary>
        /// <param name="fg">The fg.</param>
        /// <param name="useFileBkg">if set to <c>true</c> [use file BKG].</param>
        /// <param name="appBkColor">Color of the application bk.</param>
        /// <param name="bg">The bg.</param>
        /// <returns>FIBITMAP.</returns>
        [DllImport("FreeImage.dll", EntryPoint="FreeImage_Composite")]
		public static extern FIBITMAP Composite(FIBITMAP fg, bool useFileBkg, 
			[In, MarshalAs(UnmanagedType.LPStruct)] RGBQUAD appBkColor, FIBITMAP bg);
	}
}
