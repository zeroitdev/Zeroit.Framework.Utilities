// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="PixelBuffer.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Zeroit.Framework.Utilities.Collections.Generic;



namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Drawing2D
{
    /// <summary>
    /// Class PixelBuffer.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class PixelBuffer : IDisposable
    {
        #region Nested Classes

        /// <summary>
        /// Class PixelIterator.
        /// </summary>
        public unsafe class PixelIterator
        {
            /// <summary>
            /// The pixel
            /// </summary>
            private int* _pixel;
            /// <summary>
            /// The start x
            /// </summary>
            private int _startX;
            /// <summary>
            /// The start y
            /// </summary>
            private int _startY;

            /// <summary>
            /// The width
            /// </summary>
            private int _width;
            /// <summary>
            /// The height
            /// </summary>
            private int _height;

            /// <summary>
            /// The start index
            /// </summary>
            private int _startIndex;

            /// <summary>
            /// The count
            /// </summary>
            private int _count;

            /// <summary>
            /// The relative x
            /// </summary>
            private int _relativeX;
            /// <summary>
            /// The relative y
            /// </summary>
            private int _relativeY;
            /// <summary>
            /// The relative index
            /// </summary>
            private int _relativeIndex;

            /// <summary>
            /// The line offset
            /// </summary>
            private int _lineOffset;

            /// <summary>
            /// Initializes a new instance of the <see cref="PixelIterator"/> class.
            /// </summary>
            /// <param name="buffer">The buffer.</param>
            /// <param name="x">The x.</param>
            /// <param name="y">The y.</param>
            /// <param name="width">The width.</param>
            /// <param name="height">The height.</param>
            /// <param name="bufferWidth">Width of the buffer.</param>
            internal PixelIterator(int* buffer, int x, int y,int width,int height, int bufferWidth)
            {
                _startIndex = ((bufferWidth * y) + x);

                buffer += _startIndex;

                _pixel = buffer;
                _startX = x;
                _startY = y;
                _width = width;
                _height = height;
                _count = _width * _height;

                _relativeX = 0;
                _relativeY = 0;
                _relativeIndex = 0;

                _lineOffset = bufferWidth - _width;
            }

            /// <summary>
            /// Gets the relative x.
            /// </summary>
            /// <value>The relative x.</value>
            public int RelativeX
            {
                get
                {
                    return _relativeX;
                }
            }
            /// <summary>
            /// Gets the relative y.
            /// </summary>
            /// <value>The relative y.</value>
            public int RelativeY
            {
                get
                {
                    return _relativeY;
                }
            }
            /// <summary>
            /// Gets the index of the relative.
            /// </summary>
            /// <value>The index of the relative.</value>
            public int RelativeIndex
            {
                get
                {
                    return _relativeIndex;
                }
            }

            /// <summary>
            /// Gets the current x.
            /// </summary>
            /// <value>The current x.</value>
            public int CurrentX
            {
                get
                {
                    return _startX + _relativeX;
                }
            }
            /// <summary>
            /// Gets the curren y.
            /// </summary>
            /// <value>The curren y.</value>
            public int CurrenY
            {
                get
                {
                    return _startY + _relativeY;
                }
            }
            /// <summary>
            /// Gets the index of the current.
            /// </summary>
            /// <value>The index of the current.</value>
            public int CurrentIndex
            {
                get
                {
                    return _startIndex + _relativeIndex; 
                }
            }

            /// <summary>
            /// Gets the current pixel.
            /// </summary>
            /// <value>The current pixel.</value>
            public int* CurrentPixel
            {
                get
                {
                    return _pixel;
                }
            }

            /// <summary>
            /// Moves the next.
            /// </summary>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            public bool MoveNext()
            {
                _relativeIndex++;
                if (_relativeIndex < _count)
                {
                    _relativeX++;
                    if (_relativeX == _width)
                    {
                        _relativeX = 0;
                        _relativeY++;
                        _pixel += _lineOffset;
                    }

                    _pixel++;

                    return true;
                }

                return false;
            }
            /// <summary>
            /// Resets this instance.
            /// </summary>
            public void Reset()
            {
                _pixel -= _relativeIndex;

                _relativeX = 0;
                _relativeY = 0;
                _relativeIndex = 0;

            }

            /// <summary>
            /// Gets the alpha.
            /// </summary>
            /// <returns>System.Int32.</returns>
            public int GetAlpha()
            {
                return ((*(_pixel)) >> 24) & 0xff;
            }
            /// <summary>
            /// Gets the red.
            /// </summary>
            /// <returns>System.Int32.</returns>
            public int GetRed()
            {
                return ((*(_pixel)) >> 16) & 0xff;
            }
            /// <summary>
            /// Gets the green.
            /// </summary>
            /// <returns>System.Int32.</returns>
            public int GetGreen()
            {
                return ((*(_pixel)) >> 8) & 0xff;
            }
            /// <summary>
            /// Gets the blue.
            /// </summary>
            /// <returns>System.Int32.</returns>
            public int GetBlue()
            {
                return (*(_pixel)) & 0xff;
            }
        }

        #endregion

        #region Enums

        /// <summary>
        /// Enum FlipMode
        /// </summary>
        public enum FlipMode
        {
            /// <summary>
            /// The flip horizontal
            /// </summary>
            FlipHorizontal = 1,
            /// <summary>
            /// The flip vertical
            /// </summary>
            FlipVertical = 2,
            /// <summary>
            /// The flip both
            /// </summary>
            FlipBoth = 3
        }
        /// <summary>
        /// Enum ResizePivot
        /// </summary>
        public enum ResizePivot
        {
            /// <summary>
            /// The top left
            /// </summary>
            TopLeft = 0,
            /// <summary>
            /// The top center
            /// </summary>
            TopCenter = 1,
            /// <summary>
            /// The top right
            /// </summary>
            TopRight = 2,
            /// <summary>
            /// The middle left
            /// </summary>
            MiddleLeft = 3,
            /// <summary>
            /// The middle center
            /// </summary>
            MiddleCenter = 4,
            /// <summary>
            /// The middle right
            /// </summary>
            MiddleRight = 5,
            /// <summary>
            /// The bottom left
            /// </summary>
            BottomLeft = 6,
            /// <summary>
            /// The bottom center
            /// </summary>
            BottomCenter = 7,
            /// <summary>
            /// The bottom right
            /// </summary>
            BottomRight = 8
        }

        #endregion

        #region Fields

        /// <summary>
        /// The buffer
        /// </summary>
        private int[] _buffer;
        /// <summary>
        /// The width
        /// </summary>
        private int _width;
        /// <summary>
        /// The height
        /// </summary>
        private int _height;
        /// <summary>
        /// The bytes count
        /// </summary>
        private int _bytesCount;
        /// <summary>
        /// The pixels count
        /// </summary>
        private int _pixelsCount;

        /// <summary>
        /// The graphics
        /// </summary>
        private PixelBufferGraphics _graphics;

        /// <summary>
        /// The renderer
        /// </summary>
        private PixelBufferRenderer _renderer;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PixelBuffer"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="buffer">The buffer.</param>
        private unsafe PixelBuffer(int width, int height, int* buffer)
        {
            Initialize(width, height);
            fixed (int* dest = _buffer)
            {
                CopyBuffer(dest, buffer, _buffer.Length);
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PixelBuffer"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="buffer">The buffer.</param>
        internal unsafe PixelBuffer(int width, int height, int[] buffer)
        {
            Initialize(width, height);

            fixed (int* dest = _buffer)
            {
                fixed (int* src = buffer)
                {
                    CopyBuffer(dest, src, _buffer.Length);
                }
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PixelBuffer"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public PixelBuffer(int width, int height)
        {
            Initialize(width, height);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PixelBuffer"/> class.
        /// </summary>
        /// <param name="bmp">The BMP.</param>
        public PixelBuffer(Bitmap bmp)
            : this(bmp.Width, bmp.Height)
        {
            CopyBitmapToBuffer(bmp);
        }

        #endregion

        #region Destructors

        /// <summary>
        /// Finalizes an instance of the <see cref="PixelBuffer"/> class.
        /// </summary>
        ~PixelBuffer()
        {
            this.Dispose();
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _graphics.Dispose();
            _buffer = null;
        }

        #endregion

        #region Initialize

        /// <summary>
        /// Initializes the specified width.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        private unsafe void Initialize(int width, int height)
        {
            _width = width;
            _height = height;

            _pixelsCount = _width * _height;
            _bytesCount = _pixelsCount * 4;

            _buffer = new int[_pixelsCount];

            _renderer = new PixelBufferManagedRenderer(this);

            //_graphics = new PixelBufferGraphics(this);
            _graphics = new PixelBufferManagedGraphics(this);
            
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Blends the color by alpha.
        /// </summary>
        /// <param name="backColor">Color of the back.</param>
        /// <param name="foreColor">Color of the fore.</param>
        /// <returns>System.Int32.</returns>
        private int BlendColorByAlpha(int backColor, int foreColor)
        {
            int foreBlue = foreColor & 0xff;
            int foreGreen = (foreColor >> 8) & 0xff;
            int foreRed = (foreColor >> 16) & 0xff;
            int foreAlpha = (foreColor >> 24) & 0xff;

            int backBlue = backColor & 0xff;
            int backGreen = (backColor >> 8) & 0xff;
            int backRed = (backColor >> 16) & 0xff;
            int backAlpha = (backColor >> 24) & 0xff;

            int displayAlpha = foreAlpha * foreAlpha / 255 + backAlpha * (255 - foreAlpha) / 255;
            int displayRed = foreRed * foreAlpha / 255 + backRed * (255 - foreAlpha) / 255;
            int displayGreen = foreGreen * foreAlpha / 255 + backGreen * (255 - foreAlpha) / 255;
            int displayBlue = foreBlue * foreAlpha / 255 + backBlue * (255 - foreAlpha) / 255;

            int color = ((displayAlpha << 24) | (displayRed << 16) | (displayGreen << 8) | displayBlue);

            return color;

        }
        /// <summary>
        /// Blends the color of the buffer.
        /// </summary>
        /// <param name="dest">The dest.</param>
        /// <param name="color">The color.</param>
        private unsafe void BlendBufferColor(int* dest, int color)
        {
            for (int i = 0; i < _pixelsCount; i++)
            {
                int cDest = *((int*)dest);
                *((int*)dest) = BlendColorByAlpha(cDest, color);
                dest++;
            }
        }
        /// <summary>
        /// Blends the buffer rect buffer.
        /// </summary>
        /// <param name="dest">The dest.</param>
        /// <param name="src">The source.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        private unsafe void BlendBufferRectBuffer(int* dest, int* src, int x, int y, int width, int height)
        {
            int lineOffset = (_width - width);
            int start = GetPixelBytesIndex(x, y,_width);
            dest += start;

            for (int iy = 0; iy < height; iy++)
            {
                for (int ix = 0; ix < width; ix++)
                {
                    int cDest = *((int*)dest);
                    int cSrc = *((int*)src);
                    *((int*)dest) = BlendColorByAlpha(cDest, cSrc);
                    dest++;
                    src++;
                }
                dest += lineOffset;
            }
        }
        /// <summary>
        /// Blends the buffer rect buffer outside.
        /// </summary>
        /// <param name="srcBuffer">The source buffer.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        private unsafe void BlendBufferRectBufferOutside(int[] srcBuffer, int x, int y, int width, int height)
        {
            int sx = 0;
            int sy = 0;
            int sw = width;
            int sh = height;

            if (x < 0)
            {
                sx = -x;
                sw += x;
            }
            else if ((x + width) > _width)
            {
                sx = 0;
                sw = _width - x;
            }

            if (y < 0)
            {
                sy = -y;
                sh += y;
            }
            else if ((y + height) > _height)
            {
                sy = 0;
                sh = _height - y;
            }

            if (sw <= 0 || sh <= 0)
            {
                return;
            }

            //TODO: problema con l'indice del pixel di un buffer senza istanza
            //
            //int[] blitBufferArray = new int[sw * sh];
            //fixed (int* src = srcBuffer)
            //{
            //    fixed (int* dest = blitBufferArray)
            //    {
            //        CopyBufferRect(dest, src, sx, sy, sw, sh);
            //    }
            //}
            PixelBuffer srcBufferHelper = new PixelBuffer(width, height, srcBuffer);
            PixelBuffer blitBufferArray = srcBufferHelper.GetSubBuffer(sx, sy, sw, sh);

            int fx = x;
            int fy = y;
            if (x < 0) fx = 0;
            if (y < 0) fy = 0;

            fixed (int* src = blitBufferArray.InternalBuffer)
            {
                fixed (int* dest = _buffer)
                {
                    BlendBufferRectBuffer(dest, src, fx, fy, sw, sh);
                }
            }

            srcBufferHelper.Dispose();
            blitBufferArray.Dispose();
        }
        /// <summary>
        /// Blends the color of the buffer rect.
        /// </summary>
        /// <param name="dest">The dest.</param>
        /// <param name="color">The color.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        private unsafe void BlendBufferRectColor(int* dest, int color, int x, int y, int width, int height)
        {
            int lineOffset = (_width - width);
            int start = GetPixelBytesIndex(x, y,_width);
            dest += start;

            for (int iy = 0; iy < height; iy++)
            {
                for (int ix = 0; ix < width; ix++)
                {
                    int cDest = *((int*)dest);
                    *((int*)dest) = BlendColorByAlpha(cDest, color);
                    dest++;
                }
                dest += lineOffset;
            }
        }
        /// <summary>
        /// Blends the buffer rect color outside.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        private unsafe void BlendBufferRectColorOutside(int color, int x, int y, int width, int height)
        {
            int sx = x;
            int sy = y;
            int sw = width;
            int sh = height;

            if (x < 0)
            {
                sx = 0;
                sw += x;
            }
            else if ((x + width) > _width)
            {
                sw = _width - x;
            }

            if (y < 0)
            {
                sy = 0;
                sh += y;
            }
            else if ((y + height) > _height)
            {
                sh = _height - y;
            }

            if (sw <= 0 || sh <= 0)
            {
                return;
            }

            fixed (int* dest = _buffer)
            {
                BlendBufferRectColor(dest, color, sx, sy, sw, sh);
            }

        }
        /// <summary>
        /// Counts the color.
        /// </summary>
        /// <param name="buff">The buff.</param>
        /// <param name="color">The color.</param>
        /// <returns>System.Int32.</returns>
        private unsafe int CountColor(int* buff, int color)
        {
            int count = 0;
            for (int i = 0; i < _pixelsCount; i++)
            {
                if (*((int*)buff) == color)
                {
                    count++;
                }
            }
            return count;
        }
        /// <summary>
        /// Changes the color.
        /// </summary>
        /// <param name="buff">The buff.</param>
        /// <param name="oldColor">The old color.</param>
        /// <param name="newColor">The new color.</param>
        /// <returns>System.Int32.</returns>
        private unsafe int ChangeColor(int* buff, int oldColor, int newColor)
        {
            int count = 0;
            for (int i = 0; i < _pixelsCount; i++)
            {
                if (*((int*)buff) == oldColor)
                {
                    *((int*)buff) = newColor;
                    count++;
                }
            }
            return count;
        }
        /// <summary>
        /// Clips the rect.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="w">The w.</param>
        /// <param name="h">The h.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ClipRect(ref int x, ref int y, ref int w, ref int h, int width, int height)
        {
            if (x >= width) return false;
            if (y >= height) return false;
            if ((x + w) <= 0) return false;
            if ((y + h) <= 0) return false;

            if ((x + w) > width) w = width - x;
            if ((y + h) > height) h = height - y;

            if (x < 0)
            {
                w += x;
                x = 0;
            }
            if (y < 0)
            {
                h += y;
                y = 0;
            }

            return true;
        }
        /// <summary>
        /// Copies the bitmap to buffer.
        /// </summary>
        /// <param name="bmp">The BMP.</param>
        private unsafe void CopyBitmapToBuffer(Bitmap bmp)
        {
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, _width, _height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            int* src = (int*)bmpData.Scan0;

            fixed (int* dest = _buffer)
            {
                CopyBuffer(dest, src, _buffer.Length);
            }

            bmp.UnlockBits(bmpData);
        }
        /// <summary>
        /// Copies the buffer.
        /// </summary>
        /// <param name="dest">The dest.</param>
        /// <param name="src">The source.</param>
        /// <param name="lenght">The lenght.</param>
        private unsafe void CopyBuffer(int* dest, int* src, int lenght)
        {
            for (int i = 0; i < lenght; i++)
            {
                *((int*)dest) = *((int*)src);
                dest++;
                src++;
            }
        }
        /// <summary>
        /// Copies the buffer rect.
        /// </summary>
        /// <param name="dest">The dest.</param>
        /// <param name="src">The source.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        private unsafe void CopyBufferRect(int* dest, int* src, int x, int y, int width, int height)
        {
            int lineOffset = (_width - width);
            int start = GetPixelBytesIndex(x, y,_width);
            src += start;

            for (int iy = 0; iy < height; iy++)
            {
                for (int ix = 0; ix < width; ix++)
                {
                    *((int*)dest) = *((int*)src);
                    dest++;
                    src++;
                }
                src += lineOffset;
            }
        }
        /// <summary>
        /// Copies the buffer to bitmap.
        /// </summary>
        /// <returns>Bitmap.</returns>
        private unsafe Bitmap CopyBufferToBitmap()
        {
            Bitmap bmp = new Bitmap(_width, _height, PixelFormat.Format32bppArgb);
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, _width, _height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            int* dest = (int*)bmpData.Scan0;

            fixed (int* src = _buffer)
            {
                CopyBuffer(dest, src, _buffer.Length);
            }

            bmp.UnlockBits(bmpData);
            return bmp;
        }
        /// <summary>
        /// Fills the zero buffer.
        /// </summary>
        /// <param name="buff">The buff.</param>
        private unsafe void FillZeroBuffer(int* buff)
        {
            SetBufferColor(buff, 0);
        }
        /// <summary>
        /// Flips the buffer both.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <param name="dest">The dest.</param>
        private unsafe void FlipBufferBoth(int* src, int* dest)
        {
            dest += GetPixelBytesIndex(_width - 1, _height - 1, _width);
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    *((int*)dest) = *((int*)src);
                    src++;
                    dest--;
                }
            }
        }
        /// <summary>
        /// Flips the buffer horizontal.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <param name="dest">The dest.</param>
        private unsafe void FlipBufferHorizontal(int* src, int* dest)
        {
            for (int y = 0; y < _height; y++)
            {
                dest += _width - 1;
                for (int x = 0; x < _width; x++)
                {
                    *((int*)dest) = *((int*)src);
                    src++;
                    dest--;
                }
                dest += _width + 1;
            }
        }
        /// <summary>
        /// Flips the buffer vertical.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <param name="dest">The dest.</param>
        private unsafe void FlipBufferVertical(int* src, int* dest)
        {
            dest += GetPixelBytesIndex(0, _height - 1,_width);
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    *((int*)dest) = *((int*)src);
                    src++;
                    dest++;
                }
                dest -= _width * 2;
            }
        }
        /// <summary>
        /// Gets the buffer color array.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <returns>System.Int32[].</returns>
        private unsafe int[] GetBufferColorArray(int* src)
        {
            int[] colors = new int[_pixelsCount];
            for (int i = 0; i < _pixelsCount; i++)
            {
                colors[i] = *((int*)src);
                src++;
            }
            return colors;
        }
        /// <summary>
        /// Gets the buffer used color array.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <returns>System.Int32[].</returns>
        private unsafe int[] GetBufferUsedColorArray(int* src)
        {
            LightCollection<int> colors = new LightCollection<int>();
            for (int i = 0; i < _pixelsCount; i++)
            {
                int c = *((int*)src);
                if (!colors.Contains(c))
                {
                    colors.Add(c);
                }
                src++;
            }
            return colors.GetItems();
        }
        /// <summary>
        /// Gets the index of the pixel bytes.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <returns>System.Int32.</returns>
        private int GetPixelBytesIndex(int x, int y,int width)
        {
            return ((width * y) + x);
        }
        /// <summary>
        /// Gets the index of the pixel color by.
        /// </summary>
        /// <param name="buff">The buff.</param>
        /// <param name="index">The index.</param>
        /// <returns>System.Int32.</returns>
        private unsafe int GetPixelColorByIndex(int* buff, int index)
        {
            buff += index;
            int i = *((int*)buff);

            return i;
        }
        /// <summary>
        /// Gets the sub buffer outside.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns>PixelBuffer.</returns>
        private unsafe PixelBuffer GetSubBufferOutside(int x, int y, int width, int height)
        {
            PixelBuffer retBuff = new PixelBuffer(width, height);

            int sx = x;
            int sy = y;
            int sw = width;
            int sh = height;

            if (x < 0)
            {
                sx = 0;
                sw += x;
            }
            else if ((x + width) > _width)
            {
                sw = _width - x;
            }

            if (y < 0)
            {
                sy = 0;
                sh += y;
            }
            else if ((y + height) > _height)
            {
                sh = _height - y;
            }

            if (sw <= 0 || sh <= 0)
            {
                return new PixelBuffer(width,height);
            }

            int defaultColor = 0;
            fixed (int* src = _buffer)
            {
                int index = this.GetPixelBytesIndex(sx, sy, _width);
                defaultColor = this.GetPixelColorByIndex(src, index);
            }

            fixed (int* dest = retBuff.InternalBuffer)
            {
                retBuff.SetBufferColor(dest, defaultColor);
            }

            using (PixelBuffer subBuff = this.GetSubBuffer(sx, sy, sw, sh))
            {
                int fx = 0;
                int fy = 0;
                if (x < 0) fx = -x;
                if (y < 0) fy = -y;

                retBuff.SetSubBuffer(subBuff, fx, fy);
            }

            return retBuff;
        }
        /// <summary>
        /// Inverts the buffer RGB.
        /// </summary>
        /// <param name="src">The source.</param>
        private unsafe void InvertBufferRGB(int* src)
        {
            for (int i = 0; i < _pixelsCount; i++)
            {
                int color = *src;
                int b = 255 - (color & 0xff);
                int g = 255 - ((color >> 8) & 0xff);
                int r = 255 - ((color >> 16) & 0xff);
                int a = (color >> 24) & 0xff;
                *src = ((a << 24) | (r << 16) | (g << 8) | b);
                src++;
            }
        }
        /// <summary>
        /// Sets the index of the pixel color by.
        /// </summary>
        /// <param name="buff">The buff.</param>
        /// <param name="index">The index.</param>
        /// <param name="color">The color.</param>
        private unsafe void SetPixelColorByIndex(int* buff, int index, int color)
        {
            buff += index;
            *((int*)buff) = color;
        }
        /// <summary>
        /// Sets the pixels.
        /// </summary>
        /// <param name="buff">The buff.</param>
        /// <param name="index">The index.</param>
        /// <param name="offsets">The offsets.</param>
        /// <param name="offsetsCount">The offsets count.</param>
        /// <param name="color">The color.</param>
        private unsafe void SetPixels(int* buff, int index, int* offsets, int offsetsCount, int color)
        {
            buff += index;
            for (int i = 0; i < (offsetsCount+1); i++)
            {
                *buff = color;
                buff += *offsets;
                offsets++;
            }
        }
        /// <summary>
        /// Sets the color of the buffer.
        /// </summary>
        /// <param name="buff">The buff.</param>
        /// <param name="color">The color.</param>
        private unsafe void SetBufferColor(int* buff, int color)
        {
            for (int i = 0; i < _pixelsCount; i++)
            {
                *((int*)buff) = color;
                buff++;
            }
        }
        /// <summary>
        /// Sets the buffer rect buffer.
        /// </summary>
        /// <param name="dest">The dest.</param>
        /// <param name="src">The source.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        private unsafe void SetBufferRectBuffer(int* dest, int* src, int x, int y, int width, int height)
        {
            int lineOffset = (_width - width);
            int start = GetPixelBytesIndex(x, y, _width);
            dest += start;

            for (int iy = 0; iy < height; iy++)
            {
                for (int ix = 0; ix < width; ix++)
                {
                    *((int*)dest) = *((int*)src);
                    dest++;
                    src++;
                }
                dest += lineOffset;
            }
        }
        /// <summary>
        /// Sets the buffer rect buffer outside.
        /// </summary>
        /// <param name="srcBuffer">The source buffer.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        private unsafe void SetBufferRectBufferOutside(int[] srcBuffer, int x, int y, int width, int height)
        {
            int sx = 0;
            int sy = 0;
            int sw = width;
            int sh = height;

            if (x < 0)
            {
                sx = -x;
                sw += x;
            }
            else if ((x + width) > _width)
            {
                sx = 0;
                sw = _width - x;
            }

            if (y < 0)
            {
                sy = -y;
                sh += y;
            }
            else if ((y + height) > _height)
            {
                sy = 0;
                sh = _height - y;
            }

            if (sw <= 0 || sh <= 0)
            {
                return;
            }

            //TODO: problema con l'indice del pixel di un buffer senza istanza
            //
            //int[] blitBufferArray = new int[sw * sh];
            //fixed (int* src = srcBuffer)
            //{
            //    fixed (int* dest = blitBufferArray)
            //    {
            //        CopyBufferRect(dest, src, sx, sy, sw, sh);
            //    }
            //}
            PixelBuffer srcBufferHelper = new PixelBuffer(width, height, srcBuffer);
            PixelBuffer blitBufferArray = srcBufferHelper.GetSubBuffer(sx, sy, sw, sh);

            int fx = x;
            int fy = y;
            if (x < 0) fx = 0;
            if (y < 0) fy = 0;

            fixed (int* src = blitBufferArray.InternalBuffer)
            {
                fixed (int* dest = _buffer)
                {
                    SetBufferRectBuffer(dest, src, fx, fy, sw, sh);
                }
            }

            srcBufferHelper.Dispose();
            blitBufferArray.Dispose();
        }
        /// <summary>
        /// Sets the color of the buffer rect.
        /// </summary>
        /// <param name="dest">The dest.</param>
        /// <param name="color">The color.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        private unsafe void SetBufferRectColor(int* dest, int color, int x, int y, int width, int height)
        {
            int lineOffset = (_width - width);
            int start = GetPixelBytesIndex(x, y, _width);
            dest += start;

            for (int iy = 0; iy < height; iy++)
            {
                for (int ix = 0; ix < width; ix++)
                {
                    *((int*)dest) = color;
                    dest++;
                }
                dest += lineOffset;
            }
        }
        /// <summary>
        /// Sets the buffer rect color outside.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        private unsafe void SetBufferRectColorOutside(int color, int x, int y, int width, int height)
        {
            int sx = x;
            int sy = y;
            int sw = width;
            int sh = height;

            if (x < 0)
            {
                sx = -x;
                sw += x;
            }
            else if ((x + width) > _width)
            {
                sx = 0;
                sw = _width - x;
            }

            if (y < 0)
            {
                sy = -y;
                sh += y;
            }
            else if ((y + height) > _height)
            {
                sy = 0;
                sh = _height - y;
            }

            if (sw <= 0 || sh <= 0)
            {
                return;
            }

            fixed (int* dest = _buffer)
            {
                SetBufferRectColor(dest, color, sx, sy, sw, sh);
            }

        }

        #endregion

        #region Public Members

        /// <summary>
        /// Blends the color of the buffer.
        /// </summary>
        /// <param name="color">The color.</param>
        public unsafe void BlendBufferColor(int color)
        {
            fixed (int* dest = _buffer)
            {
                BlendBufferColor(dest, color);
            }
        }
        /// <summary>
        /// Blends the color of the buffer.
        /// </summary>
        /// <param name="color">The color.</param>
        public unsafe void BlendBufferColor(Color color)
        {
            BlendBufferColor(color.ToArgb());
        }
        /// <summary>
        /// Blends the sub buffer.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public unsafe void BlendSubBuffer(int color, int x, int y, int width, int height)
        {
            if ((x >= _width) || (y >= _height) || ((x + width) <= 0) || ((y + height) <= 0))
            {
                return;
            }
            if ((x < 0) || (y < 0) || ((x + width) > _width) || ((y + height) > _height))
            {
                BlendBufferRectColorOutside(color, x, y, width, height);
                return;
            }

            fixed (int* dest = _buffer)
            {
                BlendBufferRectColor(dest, color, x, y, width, height);
            }
        }
        /// <summary>
        /// Blends the sub buffer.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public unsafe void BlendSubBuffer(Color color, int x, int y, int width, int height)
        {
            BlendSubBuffer(color.ToArgb(), x, y, width, height);
        }
        /// <summary>
        /// Blends the sub buffer.
        /// </summary>
        /// <param name="subBuffer">The sub buffer.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public unsafe void BlendSubBuffer(int[] subBuffer, int x, int y, int width, int height)
        {
            if ((x >= _width) || (y >= _height) || ((x + width) <= 0) || ((y + height) <= 0))
            {
                return;
            }
            if ((x < 0) || (y < 0) || ((x + width) > _width) || ((y + height) > _height))
            {
                BlendBufferRectBufferOutside(subBuffer, x, y, width, height);
                return;
            }

            fixed (int* src = subBuffer)
            {
                fixed (int* dest = _buffer)
                {
                    BlendBufferRectBuffer(dest, src, x, y, width, height);
                }
            }
        }
        /// <summary>
        /// Blends the sub buffer.
        /// </summary>
        /// <param name="subBuffer">The sub buffer.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public unsafe void BlendSubBuffer(PixelBuffer subBuffer, int x, int y)
        {
            BlendSubBuffer(subBuffer.InternalBuffer, x, y, subBuffer.Width, subBuffer.Height);
        }
        /// <summary>
        /// Changes the color.
        /// </summary>
        /// <param name="oldColor">The old color.</param>
        /// <param name="newColor">The new color.</param>
        /// <returns>System.Int32.</returns>
        public unsafe int ChangeColor(int oldColor, int newColor)
        {
            fixed (int* buff = _buffer)
            {
                return ChangeColor(buff, oldColor, newColor);
            }
        }
        /// <summary>
        /// Changes the color.
        /// </summary>
        /// <param name="oldColor">The old color.</param>
        /// <param name="newColor">The new color.</param>
        /// <returns>System.Int32.</returns>
        public unsafe int ChangeColor(Color oldColor, Color newColor)
        {
            return ChangeColor(oldColor.ToArgb(), newColor.ToArgb());
        }
        /// <summary>
        /// Clears the buffer.
        /// </summary>
        public unsafe void ClearBuffer()
        {
            fixed (int* buff = _buffer)
            {
                FillZeroBuffer(buff);
            }
            this._graphics.ClearGraphics();
        }
        /// <summary>
        /// Clears the buffer.
        /// </summary>
        /// <param name="color">The color.</param>
        public unsafe void ClearBuffer(int color)
        {
            fixed (int* buff = _buffer)
            {
                SetBufferColor(buff, color);
            }
        }
        /// <summary>
        /// Clears the buffer.
        /// </summary>
        /// <param name="color">The color.</param>
        public unsafe void ClearBuffer(Color color)
        {
            ClearBuffer(color.ToArgb());
        }
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>PixelBuffer.</returns>
        public PixelBuffer Clone()
        {
            return new PixelBuffer(_width, _height, _buffer);
        }
        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="destDeviceData">The dest device data.</param>
        /// <param name="length">The length.</param>
        public unsafe void CopyTo(IntPtr destDeviceData, int length)
        {
            Marshal.Copy(_buffer, 0, destDeviceData, length);
        }
        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="destDeviceData">The dest device data.</param>
        /// <param name="length">The length.</param>
        public unsafe void CopyTo(int[] destDeviceData, int length)
        {
            fixed (int* src = _buffer)
            {
                fixed (int* dest = destDeviceData)
                {
                    CopyBuffer(src, dest, length);
                }
            }
        }
        /// <summary>
        /// Copies the bitmap.
        /// </summary>
        /// <param name="bmp">The BMP.</param>
        public void CopyBitmap(Bitmap bmp)
        {
            int w = bmp.Width;
            int h = bmp.Height;
            bool resize = false;
            if (w != _width)
            {
                w = _width;
                resize = true;
            }
            if (h != _height)
            {
                h = _height;
                resize = true;
            }
            if (resize)
            {
                bmp = new Bitmap(bmp, new Size(w, h));
            }
            this.CopyBitmapToBuffer(bmp);
        }
        /// <summary>
        /// Counts the color.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>System.Int32.</returns>
        public unsafe int CountColor(int color)
        {
            fixed (int* buff = _buffer)
            {
                return CountColor(buff, color);
            }
        }
        /// <summary>
        /// Counts the color.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>System.Int32.</returns>
        public unsafe int CountColor(Color color)
        {
            return CountColor(color.ToArgb());
        }
        /// <summary>
        /// Flips the buffer.
        /// </summary>
        /// <param name="flipMode">The flip mode.</param>
        public unsafe void FlipBuffer(FlipMode flipMode)
        {
            PixelBuffer pb = new PixelBuffer(_width, _height);
            fixed (int* src = _buffer)
            {
                fixed (int* dest = pb.InternalBuffer)
                {
                    switch (flipMode)
                    {
                        default:
                        case FlipMode.FlipHorizontal:
                            FlipBufferHorizontal(src, dest);
                            break;
                        case FlipMode.FlipVertical:
                            FlipBufferVertical(src, dest);
                            break;
                        case FlipMode.FlipBoth:
                            FlipBufferBoth(src, dest);
                            break;
                    }
                }
            }
            fixed (int* src = pb.InternalBuffer)
            {
                fixed (int* dest = _buffer)
                {
                    CopyBuffer(dest, src, _pixelsCount);
                }
            }
            pb.Dispose();
        }
        /// <summary>
        /// Gets all pixels.
        /// </summary>
        /// <returns>Color[].</returns>
        public unsafe Color[] GetAllPixels()
        {
            int[] icols = new int[0];
            fixed (int* src = _buffer)
            {
                icols = GetBufferColorArray(src);
            }
            Color[] cols = new Color[icols.Length];
            for (int i = 0; i < icols.Length; i++)
            {
                cols[i] = Color.FromArgb(icols[i]);
            }
            return cols;
        }
        /// <summary>
        /// Gets the buffer.
        /// </summary>
        /// <returns>System.Int32[].</returns>
        public unsafe int[] GetBuffer()
        {
            int[] retBuffer = new int[_pixelsCount];

            fixed (int* src = _buffer)
            {
                fixed (int* dest = retBuffer)
                {
                    CopyBuffer(dest, src, _pixelsCount);
                }
            }
            return retBuffer;
        }
        /// <summary>
        /// Gets the buffer pixel.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>System.Int32.</returns>
        public unsafe int GetBufferPixel(int index)
        {
            if (index < 0 || index >= _pixelsCount)
            {
                return 0;
            }

            fixed (int* buff = _buffer)
            {
                return GetPixelColorByIndex(buff, index);
            }
        }
        /// <summary>
        /// Gets the buffer pixel.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>System.Int32.</returns>
        public unsafe int GetBufferPixel(int x, int y)
        {
            if (x < 0 || y < 0 || x >= _width || y >= _height)
            {
                return 0;
            }

            int index = GetPixelBytesIndex(x, y, _width);
            return GetBufferPixel(index);
        }
        /// <summary>
        /// Gets the buffer used colors.
        /// </summary>
        /// <returns>System.Int32[].</returns>
        public unsafe int[] GetBufferUsedColors()
        {
            int[] icols = new int[0];
            fixed (int* src = _buffer)
            {
                icols = GetBufferUsedColorArray(src);
            }
            return icols;
        }
        /// <summary>
        /// Gets the pixel.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>Color.</returns>
        public unsafe Color GetPixel(int index)
        {
            return Color.FromArgb(GetBufferPixel(index));
        }
        /// <summary>
        /// Gets the pixel.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>Color.</returns>
        public unsafe Color GetPixel(int x, int y)
        {
            return Color.FromArgb(GetBufferPixel(x, y));
        }
        /// <summary>
        /// Gets the pixel iterator.
        /// </summary>
        /// <returns>PixelIterator.</returns>
        public PixelIterator GetPixelIterator()
        {
            return GetPixelIterator(0, 0, _width, _height);
        }
        /// <summary>
        /// Gets the pixel iterator.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <returns>PixelIterator.</returns>
        public PixelIterator GetPixelIterator(Rectangle rect)
        {
            return GetPixelIterator(rect.X, rect.Y, rect.Width, rect.Height);
        }
        /// <summary>
        /// Gets the pixel iterator.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns>PixelIterator.</returns>
        public unsafe PixelIterator GetPixelIterator(int x, int y, int width, int height)
        {
            fixed (int* buff = _buffer)
            {
                if (!ClipRect(ref x, ref y, ref width, ref height, _width, _height)) return null;
                return new PixelIterator(buff, x, y, width, height, _width);
            }
        }
        /// <summary>
        /// Gets the sub buffer.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns>PixelBuffer.</returns>
        public unsafe PixelBuffer GetSubBuffer(int x, int y, int width, int height)
        {
            if ((x >= _width) || (y >= _height) || ((x + width) <= 0) || ((y + height) <= 0))
            {
                new PixelBuffer(width, height);
            }
            if ((x < 0) || (y < 0) || ((x + width) > _width) || ((y + height) > _height))
            {
                return GetSubBufferOutside(x, y, width, height);
            }

            //TODO: use ClipRect(...)

            int[] pixels = new int[width * height];
            fixed (int* src = _buffer)
            {
                fixed (int* dest = pixels)
                {
                    CopyBufferRect(dest, src, x, y, width, height);
                }
            }
            return new PixelBuffer(width, height, pixels);
        }
        /// <summary>
        /// Gets the used colors.
        /// </summary>
        /// <returns>Color[].</returns>
        public unsafe Color[] GetUsedColors()
        {
            int[] icols = GetBufferUsedColors();
            Color[] cols = new Color[icols.Length];
            for (int i = 0; i < icols.Length; i++)
            {
                cols[i] = Color.FromArgb(icols[i]);
            }
            return cols;
        }
        /// <summary>
        /// Inverts the buffer RGB.
        /// </summary>
        public unsafe void InvertBufferRGB()
        {
            fixed (int* src = _buffer)
            {
                InvertBufferRGB(src);
            }
        }
        /// <summary>
        /// Resizes the buffer.
        /// </summary>
        /// <param name="pivot">The pivot.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="backColor">Color of the back.</param>
        public void ResizeBuffer(ResizePivot pivot, int width, int height, Color backColor)
        {
            if (width == _width && height == _height) return;

            PixelBuffer newBuffer = new PixelBuffer(width, height);
            newBuffer.ClearBuffer(backColor);

            int dataWidth = Math.Min(width, _width);
            int dataHeight = Math.Min(height, _height);

            int deltaX = Math.Abs(width - _width);
            int deltaY = Math.Abs(height - _height);
            int midDeltaX = (int)Math.Round(deltaX / 2f, MidpointRounding.AwayFromZero);
            int midDeltaY = (int)Math.Round(deltaY / 2f, MidpointRounding.AwayFromZero);

            bool inflateX = (width > _width);
            bool inflateY = (height > _height);

            int srcX = 0;
            int srcY = 0;
            int destX = 0;
            int destY = 0;

            int srcW = width;
            int srcH = height;

            switch (pivot)
            {
                case ResizePivot.TopLeft:
                    srcX = 0;
                    destX = 0;
                    srcY = 0;
                    destY = 0;
                    break;
                case ResizePivot.TopCenter:
                    if (inflateX)
                    {
                        srcX = 0;
                        destX = midDeltaX;
                    }
                    else
                    {
                        srcX = midDeltaX;
                        destX = 0;
                    }
                    srcY = 0;
                    destY = 0;
                    break;
                case ResizePivot.TopRight:
                    if (inflateX)
                    {
                        srcX = 0;
                        destX = deltaX;
                    }
                    else
                    {
                        srcX = deltaX;
                        destX = 0;
                    }
                    srcY = 0;
                    destY = 0;
                    break;
                case ResizePivot.MiddleLeft:
                    srcX = 0;
                    destX = 0;
                    if (inflateY)
                    {
                        srcY = 0;
                        destY = midDeltaY;
                    }
                    else
                    {
                        srcY = midDeltaY;
                        destY = 0;
                    }
                    break;
                case ResizePivot.MiddleCenter:
                    if (inflateX)
                    {
                        srcX = 0;
                        destX = midDeltaX;
                    }
                    else
                    {
                        srcX = midDeltaX;
                        destX = 0;
                    }
                    if (inflateY)
                    {
                        srcY = 0;
                        destY = midDeltaY;
                    }
                    else
                    {
                        srcY = midDeltaY;
                        destY = 0;
                    }
                    break;
                case ResizePivot.MiddleRight:
                    if (inflateX)
                    {
                        srcX = 0;
                        destX = deltaX;
                    }
                    else
                    {
                        srcX = deltaX;
                        destX = 0;
                    }
                    if (inflateY)
                    {
                        srcY = 0;
                        destY = midDeltaY;
                    }
                    else
                    {
                        srcY = midDeltaY;
                        destY = 0;
                    }
                    break;
                case ResizePivot.BottomLeft:
                    srcX = 0;
                    destX = 0;
                    if (inflateY)
                    {
                        srcY = 0;
                        destY = deltaY;
                    }
                    else
                    {
                        srcY = deltaY;
                        destY = 0;
                    }
                    break;
                case ResizePivot.BottomCenter:
                    if (inflateX)
                    {
                        srcX = 0;
                        destX = midDeltaX;
                    }
                    else
                    {
                        srcX = midDeltaX;
                        destX = 0;
                    }
                    if (inflateY)
                    {
                        srcY = 0;
                        destY = deltaY;
                    }
                    else
                    {
                        srcY = deltaY;
                        destY = 0;
                    }
                    break;
                case ResizePivot.BottomRight:
                    if (inflateX)
                    {
                        srcX = 0;
                        destX = deltaX;
                    }
                    else
                    {
                        srcX = deltaX;
                        destX = 0;
                    }
                    if (inflateY)
                    {
                        srcY = 0;
                        destY = deltaY;
                    }
                    else
                    {
                        srcY = deltaY;
                        destY = 0;
                    }
                    break;
            }

            if (inflateX && inflateY)
            {
                newBuffer.SetSubBuffer(_buffer, destX, destY, dataWidth, dataHeight);
            }
            else
            {
                PixelBuffer blitBuffer = this.GetSubBuffer(srcX, srcY, dataWidth, dataHeight);
                newBuffer.SetSubBuffer(blitBuffer, destX, destY);
            }

            this.Initialize(width, height);
            Array.Copy(newBuffer.InternalBuffer, _buffer, _buffer.Length);

            newBuffer.Dispose();

        }
        /// <summary>
        /// Sets the buffer.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        public unsafe void SetBuffer(int[] buffer)
        {
            fixed (int* src = buffer)
            {
                fixed (int* dest = _buffer)
                {
                    CopyBuffer(dest, src, buffer.Length);
                }
            }
        }
        /// <summary>
        /// Sets the buffer pixel.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="color">The color.</param>
        public unsafe void SetBufferPixel(int index, int color)
        {
            if (index < 0 || index >= _pixelsCount)
            {
                return;
            }
            fixed (int* buff = _buffer)
            {
                SetPixelColorByIndex(buff, index, color);
            }
        }
        /// <summary>
        /// Sets the buffer pixel.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="color">The color.</param>
        public unsafe void SetBufferPixel(int x, int y, int color)
        {
            if (x < 0 || y < 0 || x >= _width || y >= _height)
            {
                return;
            }

            int index = GetPixelBytesIndex(x, y, _width);
            SetBufferPixel(index, color);
        }
        /// <summary>
        /// Sets the pixel.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="color">The color.</param>
        public unsafe void SetPixel(int index, Color color)
        {
            SetBufferPixel(index, color.ToArgb());
        }
        /// <summary>
        /// Sets the pixel.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="color">The color.</param>
        public unsafe void SetPixel(int x, int y, Color color)
        {
            SetBufferPixel(x, y, color.ToArgb());
        }
        /// <summary>
        /// Sets the pixels.
        /// </summary>
        /// <param name="startPixelX">The start pixel x.</param>
        /// <param name="startPixelY">The start pixel y.</param>
        /// <param name="offsets">The offsets.</param>
        /// <param name="color">The color.</param>
        public unsafe void SetPixels(int startPixelX, int startPixelY, int[] offsets, Color color)
        {
            int index = GetPixelBytesIndex(startPixelX, startPixelY, _width);
            fixed (int* buff = _buffer)
            {
                fixed (int* offsetsArray = offsets)
                {
                    SetPixels(buff, index, offsetsArray, offsets.Length, color.ToArgb());
                }
            }
        }
        /// <summary>
        /// Sets the sub buffer.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public unsafe void SetSubBuffer(int color, int x, int y, int width, int height)
        {
            if ((x >= _width) || (y >= _height) || ((x + width) <= 0) || ((y + height) <= 0))
            {
                return;
            }
            if ((x < 0) || (y < 0) || ((x + width) > _width) || ((y + height) > _height))
            {
                SetBufferRectColorOutside(color, x, y, width, height);
                return;
            }

            fixed (int* dest = _buffer)
            {
                SetBufferRectColor(dest, color, x, y, width, height);
            }
        }
        /// <summary>
        /// Sets the sub buffer.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public unsafe void SetSubBuffer(Color color, int x, int y, int width, int height)
        {
            SetSubBuffer(color.ToArgb(), x, y, width, height);
        }
        /// <summary>
        /// Sets the sub buffer.
        /// </summary>
        /// <param name="subBuffer">The sub buffer.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public unsafe void SetSubBuffer(PixelBuffer subBuffer, int x, int y)
        {
            SetSubBuffer(subBuffer.InternalBuffer, x, y, subBuffer.Width, subBuffer.Height);
        }
        /// <summary>
        /// Sets the sub buffer.
        /// </summary>
        /// <param name="subBuffer">The sub buffer.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public unsafe void SetSubBuffer(int[] subBuffer, int x, int y, int width, int height)
        {
            if ((x >= _width) || (y >= _height) || ((x + width) <= 0) || ((y + height) <= 0))
            {
                return;
            }
            if ((x < 0) || (y < 0) || ((x + width) > _width) || ((y + height) > _height))
            {

                SetBufferRectBufferOutside(subBuffer, x, y, width, height);
                return;
            }

            fixed (int* src = subBuffer)
            {
                fixed (int* dest = _buffer)
                {
                    SetBufferRectBuffer(dest, src, x, y, width, height);
                }
            }
        }
        /// <summary>
        /// Translates the buffer.
        /// </summary>
        /// <param name="dx">The dx.</param>
        /// <param name="dy">The dy.</param>
        /// <param name="backColor">Color of the back.</param>
        public void TranslateBuffer(int dx, int dy, Color backColor)
        {
            int absDX = Math.Abs(dx);
            int absDY = Math.Abs(dy);

            if ((absDX > _width) || (absDY > _height))
            {
                this.ClearBuffer(backColor.ToArgb());
                return;
            }

            int newWidth = _width - absDX;
            int newHeight = _height - absDY;

            int srcX = 0;
            int srcY = 0;
            int destX = 0;
            int destY = 0;

            if (dx > 0)
            {
                srcX = 0;
                destX = dx;
            }
            else
            {
                srcX = -dx;
                destX = 0;
            }
            if (dy > 0)
            {
                srcY = 0;
                destY = dy;
            }
            else
            {
                srcY = -dy;
                destY = 0;
            }

            PixelBuffer subBuffer = this.GetSubBuffer(srcX, srcY, newWidth, newHeight);

            this.ClearBuffer(backColor.ToArgb());

            this.SetSubBuffer(subBuffer, destX, destY);

            subBuffer.Dispose();
        }
        /// <summary>
        /// To the bitmap.
        /// </summary>
        /// <returns>Bitmap.</returns>
        public Bitmap ToBitmap()
        {
            return CopyBufferToBitmap();
        }

        /// <summary>
        /// Gets the bytes count.
        /// </summary>
        /// <value>The bytes count.</value>
        public int BytesCount
        {
            get
            {
                return _bytesCount;
            }
        }
        /// <summary>
        /// Gets the bytes per line.
        /// </summary>
        /// <value>The bytes per line.</value>
        public int BytesPerLine
        {
            get
            {
                return _width * 4;
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
                return _height;
            }
        }
        /// <summary>
        /// Gets the pixels count.
        /// </summary>
        /// <value>The pixels count.</value>
        public int PixelsCount
        {
            get
            {
                return _pixelsCount;
            }
        }
        /// <summary>
        /// Gets the <see cref="System.Int32"/> with the specified pixel index.
        /// </summary>
        /// <param name="pixelIndex">Index of the pixel.</param>
        /// <returns>System.Int32.</returns>
        public unsafe int this[int pixelIndex]
        {
            get
            {
                return GetBufferPixel(pixelIndex);
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
                return _width;
            }
        }
        /// <summary>
        /// Gets the internal buffer.
        /// </summary>
        /// <value>The internal buffer.</value>
        public int[] InternalBuffer
        {
            get
            {
                return _buffer;
            }
        }
        /// <summary>
        /// Gets or sets the graphics.
        /// </summary>
        /// <value>The graphics.</value>
        public PixelBufferGraphics Graphics
        {
            get
            {
                return _graphics;
            }
            set
            {
                _graphics = value;
            }
        }
        /// <summary>
        /// Gets or sets the renderer.
        /// </summary>
        /// <value>The renderer.</value>
        public PixelBufferRenderer Renderer
        {
            get { return _renderer; }
            set { _renderer = value; }
        }

        #endregion

        #region Stubs

        /// <summary>
        /// Resizes the buffer.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="stretch">if set to <c>true</c> [stretch].</param>
        /// <exception cref="NotImplementedException"></exception>
        public void ResizeBuffer(int width, int height, bool stretch)
        {
            if (!stretch)
            {
                ResizeBuffer(ResizePivot.TopLeft, width, height, Color.Transparent);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        /// <summary>
        /// Rotates the buffer.
        /// </summary>
        /// <param name="angle">The angle.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void RotateBuffer(float angle)
        {
            throw new NotImplementedException();
        }

        //public unsafe PixelBuffer[] InterpolateBuffers(PixelBuffer pixelBuffer1, PixelBuffer pixelBuffer2, int steps)
        //{
        //    IntPtr arrayPtr = Marshal.AllocHGlobal((steps + 2) * 4);
        //    int** array = (int*)(void*)arrayPtr;

        //    PixelBuffer[] buffers = new PixelBuffer[steps + 2];
        //    buffers[0] = pixelBuffer1.Clone();
        //    fixed (int* fbuff = buffers[0].InternalBuffer)
        //    {
        //        *array = fbuff;
        //        array++;
        //    }
        //    for (int i = 1; i < buffers.Length - 1; i++)
        //    {
        //        buffers[i] = new PixelBuffer(pixelBuffer1.Width, pixelBuffer1.Height);
        //        fixed (int* sbuff = buffers[i].InternalBuffer)
        //        {
        //            *array = sbuff;
        //            array++;
        //        }
        //    }
        //    buffers[buffers.Length - 1] = pixelBuffer2.Clone();
        //    fixed (int* ebuff = buffers[buffers.Length - 1].InternalBuffer)
        //    {
        //        *array = ebuff;
        //        array++;
        //    }

        //    array -= buffers.Length;

        //    fixed (int* buff1 = pixelBuffer1.InternalBuffer)
        //    {
        //        fixed (int* buff2 = pixelBuffer2.InternalBuffer)
        //        {
        //            InterpolateBuffers(buff1, buff2, array, pixelBuffer1.PixelsCount);
        //        }
        //    }

        //}
        /// <summary>
        /// Interpolates the buffers.
        /// </summary>
        /// <param name="buffer1">The buffer1.</param>
        /// <param name="buffer2">The buffer2.</param>
        /// <param name="destBufferArray">The dest buffer array.</param>
        /// <param name="count">The count.</param>
        /// <param name="steps">The steps.</param>
        private unsafe void InterpolateBuffers(int* buffer1, int* buffer2, int* destBufferArray, int count,int steps)
        {

            for (int i = 0; i < count; i++)
            {
                int color1 = *buffer1;
                int b1 = (color1 & 0xff);
                int g1 = ((color1 >> 8) & 0xff);
                int r1 = ((color1 >> 16) & 0xff);
                int a1 = (color1 >> 24) & 0xff;

                int color2 = *buffer2;
                int b2 = (color2 & 0xff);
                int g2 = ((color2 >> 8) & 0xff);
                int r2 = ((color2 >> 16) & 0xff);
                int a2 = (color2 >> 24) & 0xff;

                int dB = ((b2 - b1) / (steps + 1));
                int dG = ((g2 - g1) / (steps + 1));
                int dR = ((r2 - r1) / (steps + 1));
                int dA = ((a2 - a1) / (steps + 1));

                for (int j = 0; j < steps; j++)
                {
                    int* dest = (int*)*destBufferArray;
                    dest += i;
                    
                    *dest = (((a1 + (dA * j)) << 24) | ((r1 + (dR * j)) << 16) | ((g1 + (dG * j)) << 8) | (b1 + (dB * j)));

                    destBufferArray++;
                }

                destBufferArray -= steps;

                buffer1++;
                buffer2++;
            }

        }
        /// <summary>
        /// Interpolates the buffers.
        /// </summary>
        /// <param name="buffer1">The buffer1.</param>
        /// <param name="buffer2">The buffer2.</param>
        /// <param name="destBuffer">The dest buffer.</param>
        /// <param name="count">The count.</param>
        private unsafe void InterpolateBuffers(int* buffer1, int* buffer2, int* destBuffer, int count)
        {
            InterpolateBuffers(buffer1, buffer2, destBuffer, count, 1, 0);
        }
        /// <summary>
        /// Interpolates the buffers.
        /// </summary>
        /// <param name="buffer1">The buffer1.</param>
        /// <param name="buffer2">The buffer2.</param>
        /// <param name="destBuffer">The dest buffer.</param>
        /// <param name="count">The count.</param>
        /// <param name="steps">The steps.</param>
        /// <param name="index">The index.</param>
        /// <exception cref="ArgumentOutOfRangeException">index</exception>
        private unsafe void InterpolateBuffers(int* buffer1, int* buffer2, int* destBuffer, int count,int steps,int index)
        {
            if (index < 0 || index >= steps)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            for (int i = 0; i < count; i++)
            {
                InterpolatePixel(buffer1, buffer2, destBuffer, steps, index);

                buffer1++;
                buffer2++;
                destBuffer++;
            }
        }
        /// <summary>
        /// Interpolates the pixel.
        /// </summary>
        /// <param name="pix1">The pix1.</param>
        /// <param name="pix2">The pix2.</param>
        /// <param name="destPix">The dest pix.</param>
        /// <param name="steps">The steps.</param>
        /// <param name="index">The index.</param>
        private unsafe void InterpolatePixel(int* pix1, int* pix2,int* destPix, int steps, int index)
        {
            steps++;
            index++;

            int color1 = *pix1;
            int b1 = (color1 & 0xff);
            int g1 = ((color1 >> 8) & 0xff);
            int r1 = ((color1 >> 16) & 0xff);
            int a1 = (color1 >> 24) & 0xff;

            int color2 = *pix2;
            int b2 = (color2 & 0xff);
            int g2 = ((color2 >> 8) & 0xff);
            int r2 = ((color2 >> 16) & 0xff);
            int a2 = (color2 >> 24) & 0xff;

            int b = b1 + (((b2 - b1) / steps) * index);
            int g = g1 + (((g2 - g1) / steps) * index);
            int r = r1 + (((r2 - r1) / steps) * index);
            int a = a1 + (((a2 - a1) / steps) * index);

            *destPix = ((a << 24) | (r << 16) | (g << 8) | b);
        }


        #endregion

    }
}
