// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="FreeImage.cs" company="Zeroit Dev Technologies">
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
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing
{

    /// <summary>
    /// For use this class you need to have on your system the native library of
    /// FreeImage you can grab it from http://freeimage.sourceforge.net/
    /// This class is a Managed Wrapper for FreeImage library with the praticity of
    /// Classes.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    /// <seealso cref="System.ICloneable" />
    public class FreeImage:IDisposable,ICloneable
	{
        /// <summary>
        /// Finalizes an instance of the <see cref="FreeImage"/> class.
        /// </summary>
        ~FreeImage()
        {
            Dispose();
        }

        /// <summary>
        /// Initializes static members of the <see cref="FreeImage"/> class.
        /// </summary>
        static FreeImage()
        {
            Internal.FreeImageApi.Initialise(false);
            AppDomain.CurrentDomain.DomainUnload += new EventHandler(CurrentDomain_DomainUnload);
        }

        /// <summary>
        /// Handles the DomainUnload event of the CurrentDomain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        static void CurrentDomain_DomainUnload(object sender, EventArgs e)
        {
            Internal.FreeImageApi.DeInitialise();
        }




        /// <summary>
        /// Occurs when [transformation completed].
        /// </summary>
        public event EventHandler TransformationCompleted;

        #region API Declarations

        /// <summary>
        /// Sets the di bits to device.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="dx">The dx.</param>
        /// <param name="dy">The dy.</param>
        /// <param name="SrcX">The source x.</param>
        /// <param name="SrcY">The source y.</param>
        /// <param name="Scan">The scan.</param>
        /// <param name="NumScans">The number scans.</param>
        /// <param name="Bits">The bits.</param>
        /// <param name="BitsInfo">The bits information.</param>
        /// <param name="wUsage">The w usage.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("gdi32.dll")]
		private static extern int SetDIBitsToDevice(IntPtr hdc, int x, int y, int dx, int dy, int SrcX, int SrcY, int Scan, int NumScans, IntPtr Bits, IntPtr BitsInfo, int wUsage);

        #endregion

        #region Enumerations
        /*
		public enum FreeImageFormat
		{
			Unknown = -1,
			Bmp = 0,
			Ico = 1,
			Jpg = 2,
			Jng = 3,
			Koala = 4,
			Lbm = 5,
			Iff = Lbm,
			Mng = 6,
			Pbm = 7,
			PbmRaw = 8,
			Pcd = 9,
			Pcx = 10,
			Pgm = 11,
			PgmRaw = 12,
			Png = 13,
			Ppm = 14,
			PpmRaw = 15,
			Ras = 16,
			Tga = 17,
			Tif = 18,
			Wbmp = 19,
			Psd = 20,
			Cut = 21,
			Xbm = 22,
			Xpm = 23,
			Dds = 24,
			Gif = 25
		}
		public enum FreeImageQuantize
		{
			WUQuant = 0,
			NNQuant = 1
		}
		public enum FreeImageDither
		{
			FS = 0,
			BAYER4x4 = 1,
			BAYER8x8 = 2,
			CLUSTER6x6 = 3,
			CLUSTER8x8 = 4,
			CLUSTER16x16 = 5
		}
		public enum FreeImageFilter
		{
		FILTER_BOX		  = 0,	// Box, pulse, Fourier window, 1st order (constant) b-spline
		FILTER_BICUBIC	  = 1,	// Mitchell & Netravali's two-param cubic filter
		FILTER_BILINEAR   = 2,	// Bilinear filter
		FILTER_BSPLINE	  = 3,	// 4th order (cubic) b-spline
		FILTER_CATMULLROM = 4,	// Catmull-Rom spline, Overhauser spline
		FILTER_LANCZOS3	  = 5	// Lanczos3 filter
		}
		public enum FreeImageColorChannel
		{
			RGB = 0,
			RED = 1,
			GREEN = 2,
			BLUE = 3,
			ALPHA = 4,
			BLACK = 5
		}
		public enum FreeImageType
		{
			UNKNOWN = 0,
			BITMAP = 1,
			UINT16 = 2,
			INT16 = 3,
			UINT32 = 4,
			INT32 = 5,
			FLOAT = 6,
			DOUBLE = 7,
			COMPLEX = 8
		}
		public enum FreeImageColorType
		{
			MINISBLACK = 0,
			MINISWHITE = 1,
			PALETTE = 2,
			RGB = 3,
			RGBALPHA = 4,
			CMYK = 5
		}*/

        #endregion

        #region Static Members

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <returns>System.String.</returns>
        public static string GetVersion()
		{
			return Internal.FreeImageApi.GetVersion();
		}
        /// <summary>
        /// Gets the copyright.
        /// </summary>
        /// <returns>System.String.</returns>
        public static string GetCopyright()
		{
			return Internal.FreeImageApi.GetCopyrightMessage();
		}

        #endregion

        #region Private Members

        /// <summary>
        /// The m handle
        /// </summary>
        private uint m_Handle = 0;
        /// <summary>
        /// The m memory PTR
        /// </summary>
        private IntPtr m_MemPtr = IntPtr.Zero;

        /// <summary>
        /// Images the format to fif.
        /// </summary>
        /// <param name="imageFormat">The image format.</param>
        /// <returns>Internal.FREE_IMAGE_FORMAT.</returns>
        private Internal.FREE_IMAGE_FORMAT ImageFormatToFIF(ImageFormat imageFormat)
		{
			string fmt = imageFormat.ToString().ToLower();
			if (fmt == "bmp")
			{
				return Internal.FREE_IMAGE_FORMAT.FIF_BMP;
			}
			if (fmt == "jpg")
			{
				return Internal.FREE_IMAGE_FORMAT.FIF_JPEG;
			}
            return Internal.FREE_IMAGE_FORMAT.FIF_UNKNOWN;
		}

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FreeImage"/> class.
        /// </summary>
        /// <param name="handle">The handle.</param>
        internal FreeImage(uint handle)
			:this(handle,IntPtr.Zero)
		{
           // Internal.FreeImageApi.Initialise(false);
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="FreeImage"/> class.
        /// </summary>
        /// <param name="handle">The handle.</param>
        /// <param name="memPtr">The memory PTR.</param>
        internal FreeImage(uint handle,IntPtr memPtr)
		{
           // Internal.FreeImageApi.Initialise(true);

			m_Handle = handle;
			m_MemPtr = memPtr;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="FreeImage"/> class.
        /// </summary>
        /// <param name="bts">The BTS.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="pitch">The pitch.</param>
        /// <param name="bpp">The BPP.</param>
        /// <param name="redMask">The red mask.</param>
        /// <param name="greenMask">The green mask.</param>
        /// <param name="blueMask">The blue mask.</param>
        /// <param name="topDown">if set to <c>true</c> [top down].</param>
        public FreeImage(byte[] bts,int width,int height,int pitch,uint bpp,uint redMask,
            uint greenMask,uint blueMask,bool topDown)
        {
            m_Handle = Internal.FreeImageApi.ConvertFromRawBits(bts, width, height, 
                pitch, bpp, redMask, greenMask, blueMask, topDown);
        }

        /// <summary>
        /// Initialise a new FreeImage class from a file
        /// </summary>
        /// <param name="filename">The image filename</param>
        /// <exception cref="Exception">Unknown file format</exception>
		public FreeImage(string filename)
		{


            Internal.FREE_IMAGE_FORMAT fif = Internal.FreeImageApi.GetFIFFromFilename(filename);
            if (fif == Internal.FREE_IMAGE_FORMAT.FIF_UNKNOWN) throw new Exception("Unknown file format");

			m_Handle = Internal.FreeImageApi.Load(fif, filename, 0);
			m_MemPtr=IntPtr.Zero;
		}


        /// <summary>
        /// Initialise a new FreeImage class from a System.Drawing.Bitmap
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <exception cref="Exception">Image format \"" + imageFormat.ToString() + "\" is not supported</exception>
		public FreeImage(Bitmap bitmap, ImageFormat imageFormat)
		{

            Internal.FREE_IMAGE_FORMAT fif = ImageFormatToFIF(imageFormat);
            if (fif == Internal.FREE_IMAGE_FORMAT.FIF_UNKNOWN)
			{
				throw new Exception("Image format \"" + imageFormat.ToString() + "\" is not supported");
			}

			MemoryStream ms = new MemoryStream();
			bitmap.Save(ms, imageFormat);
			ms.Flush();

			byte[] buffer = new byte[((int)(ms.Length - 1)) + 1];
			ms.Position = 0;
			ms.Read(buffer, 0, (int)ms.Length);
			ms.Close();

			IntPtr dataPtr = Marshal.AllocHGlobal(buffer.Length);
			Marshal.Copy(buffer, 0, dataPtr, buffer.Length);

			m_MemPtr = (IntPtr)Internal.FreeImageApi.OpenMemory(dataPtr, buffer.Length);
			m_Handle = Internal.FreeImageApi.LoadFromMemory(fif, (uint)m_MemPtr, 0);

		}

        #endregion

        /// <summary>
        /// Converts to raw.
        /// </summary>
        /// <returns>System.Byte[].</returns>
        public byte[] ConvertToRaw()
        {
            IntPtr bits = IntPtr.Zero;

            bits = Marshal.AllocHGlobal(this.Height * this.Pitch);

            Internal.FreeImageApi.ConvertToRawBits(bits, m_Handle, this.Pitch, (uint)this.Bpp, (uint)0, (uint)0, (uint)0, false);
            byte[] bts = new byte[this.Height * this.Pitch];
            Marshal.Copy(bits, bts, 0, bts.Length);

            return bts;
        }

        #region Public Properties

        /// <summary>
        /// Gets the BPP.
        /// </summary>
        /// <value>The BPP.</value>
        public int Bpp
		{
			get
			{
				return (int)Internal.FreeImageApi.GetBPP(m_Handle);
			}
		}
        /// <summary>
        /// Gets the pitch.
        /// </summary>
        /// <value>The pitch.</value>
        public int Pitch
		{
			get
			{
				return (int)Internal.FreeImageApi.GetPitch(m_Handle);
			}
		}
        /// <summary>
        /// Gets the dots per meter x.
        /// </summary>
        /// <value>The dots per meter x.</value>
        public int DotsPerMeterX
		{
			get
			{
				return (int)Internal.FreeImageApi.GetDotsPerMeterX(m_Handle);
			}
		}
        /// <summary>
        /// Gets the dots per meter y.
        /// </summary>
        /// <value>The dots per meter y.</value>
        public int DotsPerMeterY
		{
			get
			{
				return (int)Internal.FreeImageApi.GetDotsPerMeterY(m_Handle);
			}
		}
        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width
		{
			get
			{
				return (int)Internal.FreeImageApi.GetWidth(m_Handle);
			}
		}
        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height
		{
			get
			{
				return (int)Internal.FreeImageApi.GetHeight(m_Handle);
			}
		}
        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <value>The size.</value>
        public SizeF Size
		{
			get
			{
				return new SizeF(this.Width, this.Height);
			}
		}
        /// <summary>
        /// Gets the used colors.
        /// </summary>
        /// <value>The used colors.</value>
        public int UsedColors
		{
			get
			{
				return (int)Internal.FreeImageApi.GetColorsUsed(m_Handle);
			}
		}
        /// <summary>
        /// Gets the transparency count.
        /// </summary>
        /// <value>The transparency count.</value>
        public int TransparencyCount
		{
			get
			{
				return (int)Internal.FreeImageApi.GetTransparencyCount(m_Handle);
			}
		}

        /// <summary>
        /// Gets or sets the background.
        /// </summary>
        /// <value>The background.</value>
        public Color Background
        {
            get
            {
                var rgbquad = new Internal.RGBQUAD();

                if (!Internal.FreeImageApi.GetBackgroundColor(this.m_Handle, rgbquad))
                    return Color.Empty;

                return Color.FromArgb(rgbquad.rgbRed, 
                    rgbquad.rgbGreen, rgbquad.rgbBlue);
            }
            set
            {
                Internal.FreeImageApi.SetBackgroundColor(this.m_Handle,
                    new Internal.RGBQUAD
                    {
                        rgbBlue = value.B,
                        rgbGreen = value.G,
                        rgbRed = value.R
                    });
            }
        }

        /// <summary>
        /// Gets the type of the color.
        /// </summary>
        /// <value>The type of the color.</value>
        public Internal.FREE_IMAGE_COLOR_TYPE ColorType
		{
			get
			{
                return (Internal.FREE_IMAGE_COLOR_TYPE)Internal.FreeImageApi.GetColorType(m_Handle);
			}
		}

        //public bool AdjustContrast(double percentage)
        //{
        //     return Internal.FreeImageApi.AdjustContrast(m_Handle, percentage);
        //}

        //public bool AdjustBrightness(double percentage)
        //{
        //    return Internal.FreeImageApi.AdjustBrightness(m_Handle, percentage);
        //}

        //public bool AdjustGamma(double percentage)
        //{
        //    return Internal.FreeImageApi.AdjustGamma(m_Handle, percentage);
        //}

        /// <summary>
        /// Gets the type of the image.
        /// </summary>
        /// <value>The type of the image.</value>
        public Internal.FREE_IMAGE_TYPE ImageType
		{
			get
			{
				return Internal.FreeImageApi.GetImageType(m_Handle);
			}
		}

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the bitmap.
        /// </summary>
        /// <returns>Bitmap.</returns>
        public Bitmap GetBitmap()
		{
			Bitmap bmp = new Bitmap(this.Width, this.Height);
			Graphics gfx = Graphics.FromImage(bmp);
			IntPtr ptrHDC = gfx.GetHdc();

			this.PaintToDevice(ptrHDC, 0, 0, bmp.Width, bmp.Height, 0, 0, 0, bmp.Height, 0);

			gfx.ReleaseHdc(ptrHDC);

			return bmp;
		}

        /// <summary>
        /// Enum ConvertFormat
        /// </summary>
        public enum ConvertFormat
        {
            /// <summary>
            /// The bits4
            /// </summary>
            Bits4,
            /// <summary>
            /// The bits8
            /// </summary>
            Bits8,
            /// <summary>
            /// The bits16 555
            /// </summary>
            Bits16_555,
            /// <summary>
            /// The bits16 565
            /// </summary>
            Bits16_565,
            /// <summary>
            /// The bits24
            /// </summary>
            Bits24,
            /// <summary>
            /// The bits32
            /// </summary>
            Bits32
        }

        /// <summary>
        /// Convert The current Image to the specified format
        /// </summary>
        /// <param name="format">The destination format of the new image</param>
        /// <returns>FreeImage.</returns>
        public FreeImage ConvertTo(ConvertFormat format)
        {
            switch (format)
            {
                case ConvertFormat.Bits4:
                    return new FreeImage(Internal.FreeImageApi.ConvertTo4Bits(this.m_Handle));
                case ConvertFormat.Bits8:
                    return new FreeImage(Internal.FreeImageApi.ConvertTo8Bits(this.m_Handle));
                case ConvertFormat.Bits16_565:
                    return new FreeImage(Internal.FreeImageApi.ConvertTo16Bits565(this.m_Handle));
                case ConvertFormat.Bits16_555:
                    return new FreeImage(Internal.FreeImageApi.ConvertTo16Bits555(this.m_Handle));
                case ConvertFormat.Bits24:
                    return new FreeImage(Internal.FreeImageApi.ConvertTo24Bits(this.m_Handle));
                case ConvertFormat.Bits32:
                    return new FreeImage(Internal.FreeImageApi.ConvertTo32Bits(this.m_Handle));
            }
            return null;
        }

        /// <summary>
        /// Get the native FreeImage Handle
        /// </summary>
        /// <returns>System.UInt32.</returns>
        public uint GetFreeImageHwnd()
        {
        
            return m_Handle;
        }

        /// <summary>
        /// Paint the image on the destination graphic context
        /// </summary>
        /// <param name="destDC">The dest dc.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="srcX">The source x.</param>
        /// <param name="srcY">The source y.</param>
        /// <param name="scan">The scan.</param>
        /// <param name="mumScans">The mum scans.</param>
        /// <param name="wUsage">The w usage.</param>
        public void PaintToDevice(IntPtr destDC, int x, int y, int width, int height, int srcX, int srcY, int scan, int mumScans, int wUsage)
		{
			try
			{
				IntPtr ptrBits = Internal.FreeImageApi.GetBits(m_Handle);
				IntPtr ptrInfo = Internal.FreeImageApi.FreeImage_GetInfo(m_Handle);
				SetDIBitsToDevice(destDC, x, y, width, height, srcX, srcY, scan, mumScans, ptrBits, ptrInfo, wUsage);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

        /// <summary>
        /// Paint the current freeimage to a System.Drawing.Bitmap
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="srcX">The source x.</param>
        /// <param name="srcY">The source y.</param>
        public void PaintToBitmap(Bitmap bitmap, int x, int y, int width, int height, int srcX, int srcY)
		{
			Graphics gfx = Graphics.FromImage(bitmap);

			IntPtr ptrHDC = gfx.GetHdc();

			this.PaintToDevice(ptrHDC, x, y, width, height, 0, 0, 0, this.Height, 0);

			gfx.ReleaseHdc(ptrHDC);
		}

        /// <summary>
        /// Paint the current freeimage to a System.Drawing.Graphics
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="srcX">The source x.</param>
        /// <param name="srcY">The source y.</param>
        public void PaintToGraphics(Graphics graphics, int x, int y, int width, int height, int srcX, int srcY)
		{

			IntPtr ptrHDC = graphics.GetHdc();

			this.PaintToDevice(ptrHDC, x, y, width, height, 0, 0, 0, this.Height, 0);

			graphics.ReleaseHdc(ptrHDC);
		}

        /// <summary>
        /// Rotate the image
        /// </summary>
        /// <param name="angle">The angle.</param>
        /// <returns>FreeImage.</returns>
        public FreeImage Rotate(double angle)
		{
			uint i = Internal.FreeImageApi.RotateClassic(m_Handle, angle);

            return new FreeImage(i);
		}

        /// <summary>
        /// Rotate the image, extended version
        /// </summary>
        /// <param name="angle">The angle.</param>
        /// <param name="xShift">The x shift.</param>
        /// <param name="yShift">The y shift.</param>
        /// <param name="xOrigin">The x origin.</param>
        /// <param name="yOrigin">The y origin.</param>
        /// <param name="mask">if set to <c>true</c> [mask].</param>
        /// <returns>FreeImage.</returns>
        public FreeImage RotateExtended(double angle, double xShift, double yShift, double xOrigin, double yOrigin, bool mask)
		{
			uint i = Internal.FreeImageApi.RotateEx(m_Handle, angle, xShift, yShift, xOrigin, yOrigin, mask);

            return new FreeImage(i);
		}

        /// <summary>
        /// Rotate the image, extended version
        /// </summary>
        /// <param name="angle">The angle.</param>
        /// <param name="xShift">The x shift.</param>
        /// <param name="yShift">The y shift.</param>
        /// <param name="xOrigin">The x origin.</param>
        /// <param name="yOrigin">The y origin.</param>
		public void RotateExtended(double angle, double xShift, double yShift, double xOrigin, double yOrigin)
		{
			RotateExtended(angle, xShift, yShift, xOrigin, yOrigin, false);
		}

        /// <summary>
        /// Rescale the current freeimage
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns>FreeImage.</returns>
		public FreeImage Rescale(int width, int height)
		{
			uint newHandle = Internal.FreeImageApi.Rescale(m_Handle, width, height, Internal.FREE_IMAGE_FILTER.FILTER_BICUBIC);
			return new FreeImage(newHandle);
		}

        /// <summary>
        /// Flip che current in Image vertically
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool FlipVertical()
        {
            return Internal.FreeImageApi.FlipVertical(m_Handle);
        }

        /// <summary>
        /// Flip the current image horizontally
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool FlipHorizontal()
        {
            return Internal.FreeImageApi.FlipHorizontal(m_Handle);
        }

        /// <summary>
        /// Converts a bitmap to 1-bit monochrome bitmap using a threshold T between [0..255].
        /// The function first converts the bitmap to a 8-bit greyscale bitmap. Then, any brightness
        /// level that is less than T is set to zero, otherwise to 1. For 1-bit input bitmaps, the
        /// function clones the input bitmap and builds a monochrome palette.
        /// </summary>
        /// <param name="range">The range.</param>
        /// <returns>FreeImage.</returns>
        public FreeImage Threshold(byte range)
        {            
            uint i = Internal.FreeImageApi.Threshold(m_Handle, range);

            return new FreeImage(i);
        }

        /// <summary>
        /// Invert the current Image
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Invert()
        {
            return Internal.FreeImageApi.Invert(m_Handle);
        }

        /// <summary>
        /// Save the image to the specified filename,
        /// this method retrevie the destination image
        /// format automatically by checking the file extension
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public bool Save(string filename)
		{
			if (File.Exists(filename))
				File.Delete(filename);

            Internal.FREE_IMAGE_FORMAT fif = Internal.FreeImageApi.GetFIFFromFilename(filename);
			Internal.FreeImageApi.SetPluginEnabled(fif, true);

			return Internal.FreeImageApi.Save(fif, m_Handle, filename, 0);
		}

        /// <summary>
        /// Save the image to the specified file with the specified format
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public bool Save(string filename, FreeImageFormatInfo type)
		{
			if (File.Exists(filename))
				File.Delete(filename);

			Internal.FreeImageApi.SetPluginEnabled(type.Format, true);

			return Internal.FreeImageApi.Save(type.Format, m_Handle, filename, 0);
		}

        #endregion

        #region IDisposable Members

        /// <summary>
        /// The disposed
        /// </summary>
        bool disposed = false;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
		{
            if (!disposed)
            {
                      Internal.FreeImageApi.Unload(m_Handle);
                if (m_MemPtr != IntPtr.Zero) Internal.FreeImageApi.CloseMemory(m_MemPtr);
            }
            disposed = true;
			//Internal.FreeImageApi.DeInitialize();
		}

        #endregion

        #region ICloneable Members

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>FreeImage.</returns>
        public FreeImage Clone()
		{
			uint clone = Internal.FreeImageApi.Clone(m_Handle);
			return new FreeImage(clone);
		}

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        object ICloneable.Clone()
		{
			return this.Clone();
		}

        #endregion

        #region Adjust's methods

        /// <summary>
        /// Adjusts the gamma.
        /// </summary>
        /// <param name="gamma">The gamma.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool AdjustGamma(double gamma)
        {
            return Internal.FreeImageApi.AdjustGamma(this.m_Handle, gamma);
        }

        /// <summary>
        /// Adjusts the brightness.
        /// </summary>
        /// <param name="percentage">The percentage.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool AdjustBrightness(double percentage)
        {
            return Internal.FreeImageApi.AdjustBrightness(this.m_Handle, percentage);
        }

        /// <summary>
        /// Adjusts the contrast.
        /// </summary>
        /// <param name="percentage">The percentage.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool AdjustContrast(double percentage)
        {
            return Internal.FreeImageApi.AdjustContrast(m_Handle, percentage);
        }

        #endregion


        //public void ApplyTransformation(FreeImageTransformation transform)
        //{
        //    transform.Run(this);

        //    if (TransformationCompleted != null)
        //        TransformationCompleted(this, new EventArgs());
        //}

        /// <summary>
        /// Disposes the and set handle.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        internal void DisposeAndSetHandle(uint hwnd)
        {
            Internal.FreeImageApi.Unload(m_Handle);

            m_Handle = hwnd;
        }
	}
}
