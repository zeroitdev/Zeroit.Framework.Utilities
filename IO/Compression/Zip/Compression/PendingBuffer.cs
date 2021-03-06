// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="PendingBuffer.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.IO.Compression.Zip.Compression 
{

    /// <summary>
    /// This class is general purpose class for writing data to a buffer.
    /// It allows you to write bits as well as bytes
    /// Based on DeflaterPending.java
    /// author of the original java version : Jochen Hoenicke
    /// </summary>
    public class PendingBuffer
	{
        /// <summary>
        /// Internal work buffer
        /// </summary>
        protected byte[] buf;

        /// <summary>
        /// The start
        /// </summary>
        int start;
        /// <summary>
        /// The end
        /// </summary>
        int end;

        /// <summary>
        /// The bits
        /// </summary>
        uint bits;
        /// <summary>
        /// The bit count
        /// </summary>
        int bitCount;

        /// <summary>
        /// construct instance using default buffer size of 4096
        /// </summary>
        public PendingBuffer() : this( 4096 )
		{
			
		}

        /// <summary>
        /// construct instance using specified buffer size
        /// </summary>
        /// <param name="bufsize">size to use for internal buffer</param>
        public PendingBuffer(int bufsize)
		{
			buf = new byte[bufsize];
		}

        /// <summary>
        /// Clear internal state/buffers
        /// </summary>
        public void Reset() 
		{
			start = end = bitCount = 0;
		}

        /// <summary>
        /// write a byte to buffer
        /// </summary>
        /// <param name="b">value to write</param>
        /// <exception cref="SharpZipBaseException"></exception>
        public void WriteByte(int b)
		{
			if (DeflaterConstants.DEBUGGING && start != 0) {
				throw new SharpZipBaseException();
			}
			buf[end++] = (byte) b;
		}

        /// <summary>
        /// Write a short value to buffer LSB first
        /// </summary>
        /// <param name="s">value to write</param>
        /// <exception cref="SharpZipBaseException"></exception>
        public void WriteShort(int s)
		{
			if (DeflaterConstants.DEBUGGING && start != 0) {
				throw new SharpZipBaseException();
			}
			buf[end++] = (byte) s;
			buf[end++] = (byte) (s >> 8);
		}

        /// <summary>
        /// write an integer LSB first
        /// </summary>
        /// <param name="s">value to write</param>
        /// <exception cref="SharpZipBaseException"></exception>
        public void WriteInt(int s)
		{
			if (DeflaterConstants.DEBUGGING && start != 0) {
				throw new SharpZipBaseException();
			}
			buf[end++] = (byte) s;
			buf[end++] = (byte) (s >> 8);
			buf[end++] = (byte) (s >> 16);
			buf[end++] = (byte) (s >> 24);
		}

        /// <summary>
        /// Write a block of data to buffer
        /// </summary>
        /// <param name="block">data to write</param>
        /// <param name="offset">offset of first byte to write</param>
        /// <param name="len">number of bytes to write</param>
        /// <exception cref="SharpZipBaseException"></exception>
        public void WriteBlock(byte[] block, int offset, int len)
		{
			if (DeflaterConstants.DEBUGGING && start != 0) {
				throw new SharpZipBaseException();
			}
			System.Array.Copy(block, offset, buf, end, len);
			end += len;
		}

        /// <summary>
        /// The number of bits written to the buffer
        /// </summary>
        /// <value>The bit count.</value>
        public int BitCount {
			get {
				return bitCount;
			}
		}

        /// <summary>
        /// Align internal buffer on a byte boundary
        /// </summary>
        /// <exception cref="SharpZipBaseException"></exception>
        public void AlignToByte() 
		{
			if (DeflaterConstants.DEBUGGING && start != 0) {
				throw new SharpZipBaseException();
			}
			if (bitCount > 0) {
				buf[end++] = (byte) bits;
				if (bitCount > 8) {
					buf[end++] = (byte) (bits >> 8);
				}
			}
			bits = 0;
			bitCount = 0;
		}

        /// <summary>
        /// Write bits to internal buffer
        /// </summary>
        /// <param name="b">source of bits</param>
        /// <param name="count">number of bits to write</param>
        /// <exception cref="SharpZipBaseException"></exception>
        public void WriteBits(int b, int count)
		{
			if (DeflaterConstants.DEBUGGING && start != 0) {
				throw new SharpZipBaseException();
			}
			//			if (DeflaterConstants.DEBUGGING) {
			//				//Console.WriteLine("writeBits("+b+","+count+")");
			//			}
			bits |= (uint)(b << bitCount);
			bitCount += count;
			if (bitCount >= 16) {
				buf[end++] = (byte) bits;
				buf[end++] = (byte) (bits >> 8);
				bits >>= 16;
				bitCount -= 16;
			}
		}

        /// <summary>
        /// Write a short value to internal buffer most significant byte first
        /// </summary>
        /// <param name="s">value to write</param>
        /// <exception cref="SharpZipBaseException"></exception>
        public void WriteShortMSB(int s) 
		{
			if (DeflaterConstants.DEBUGGING && start != 0) {
				throw new SharpZipBaseException();
			}
			buf[end++] = (byte) (s >> 8);
			buf[end++] = (byte) s;
		}

        /// <summary>
        /// Indicates if buffer has been flushed
        /// </summary>
        /// <value><c>true</c> if this instance is flushed; otherwise, <c>false</c>.</value>
        public bool IsFlushed {
			get {
				return end == 0;
			}
		}

        /// <summary>
        /// Flushes the pending buffer into the given output array.  If the
        /// output array is to small, only a partial flush is done.
        /// </summary>
        /// <param name="output">the output array;</param>
        /// <param name="offset">the offset into output array;</param>
        /// <param name="length">length the maximum number of bytes to store;</param>
        /// <returns>System.Int32.</returns>
        public int Flush(byte[] output, int offset, int length) 
		{
			if (bitCount >= 8) {
				buf[end++] = (byte) bits;
				bits >>= 8;
				bitCount -= 8;
			}
			if (length > end - start) {
				length = end - start;
				System.Array.Copy(buf, start, output, offset, length);
				start = 0;
				end = 0;
			} else {
				System.Array.Copy(buf, start, output, offset, length);
				start += length;
			}
			return length;
		}

        /// <summary>
        /// Convert internal buffer to byte array.
        /// Buffer is empty on completion
        /// </summary>
        /// <returns>converted buffer contents contents</returns>
        public byte[] ToByteArray()
		{
			byte[] ret = new byte[end - start];
			System.Array.Copy(buf, start, ret, 0, ret.Length);
			start = 0;
			end = 0;
			return ret;
		}
	}
}	
