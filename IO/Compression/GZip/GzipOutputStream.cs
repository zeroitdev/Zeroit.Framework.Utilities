// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="GzipOutputStream.cs" company="Zeroit Dev Technologies">
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

using Zeroit.Framework.Utilities.IO.Compression.Checksums;
using Zeroit.Framework.Utilities.IO.Compression.Zip.Compression;
using Zeroit.Framework.Utilities.IO.Compression.Zip.Compression.Streams;

namespace Zeroit.Framework.Utilities.IO.Compression.GZip 
{

    /// <summary>
    /// This filter stream is used to compress a stream into a "GZIP" stream.
    /// The "GZIP" format is described in RFC 1952.
    /// author of the original java version : John Leuner
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.IO.Compression.Zip.Compression.Streams.DeflaterOutputStream" />
    /// <example> This sample shows how to gzip a file
    /// <code>
    /// using System;
    /// using System.IO;
    /// using Zeroit.Framework.Utilities.IO.Compression.GZip;
    /// class MainClass
    /// {
    /// public static void Main(string[] args)
    /// {
    /// Stream s = new GZipOutputStream(File.Create(args[0] + ".gz"));
    /// FileStream fs = File.OpenRead(args[0]);
    /// byte[] writeData = new byte[fs.Length];
    /// fs.Read(writeData, 0, (int)fs.Length);
    /// s.Write(writeData, 0, writeData.Length);
    /// s.Close();
    /// }
    /// }
    /// </code></example>
    public class GZipOutputStream : DeflaterOutputStream
	{
        /// <summary>
        /// CRC-32 value for uncompressed data
        /// </summary>
        protected Crc32 crc = new Crc32();

        /// <summary>
        /// Creates a GzipOutputStream with the default buffer size
        /// </summary>
        /// <param name="baseOutputStream">The stream to read data (to be compressed) from</param>
        public GZipOutputStream(Stream baseOutputStream) : this(baseOutputStream, 4096)
		{
		}

        /// <summary>
        /// Creates a GZipOutputStream with the specified buffer size
        /// </summary>
        /// <param name="baseOutputStream">The stream to read data (to be compressed) from</param>
        /// <param name="size">Size of the buffer to use</param>
        public GZipOutputStream(Stream baseOutputStream, int size) : base(baseOutputStream, new Deflater(Deflater.DEFAULT_COMPRESSION, true), size)
		{
			WriteHeader();
		}

        /// <summary>
        /// Writes the header.
        /// </summary>
        void WriteHeader()
		{
			int mod_time = (int)(DateTime.Now.Ticks / 10000L);  // Ticks give back 100ns intervals
			byte[] gzipHeader = {
				/* The two magic bytes */
				(byte) (GZipConstants.GZIP_MAGIC >> 8), (byte) GZipConstants.GZIP_MAGIC,
				
				/* The compression type */
				(byte) Deflater.DEFLATED,
				
				/* The flags (not set) */
				0,
				
				/* The modification time */
				(byte) mod_time, (byte) (mod_time >> 8),
				(byte) (mod_time >> 16), (byte) (mod_time >> 24),
				
				/* The extra flags */
				0,
				
				/* The OS type (unknown) */
				(byte) 255
			};
			baseOutputStream.Write(gzipHeader, 0, gzipHeader.Length);
		}

        /// <summary>
        /// Write given buffer to output updating crc
        /// </summary>
        /// <param name="buf">Buffer to write</param>
        /// <param name="off">Offset of first byte in buf to write</param>
        /// <param name="len">Number of bytes to write</param>
        public override void Write(byte[] buf, int off, int len)
		{
			crc.Update(buf, off, len);
			base.Write(buf, off, len);
		}

        /// <summary>
        /// Writes remaining compressed output data to the output stream
        /// and closes it.
        /// </summary>
        public override void Close()
		{
			Finish();
			
			if ( IsStreamOwner ) {
				baseOutputStream.Close();
			}
		}

        /// <summary>
        /// Sets the active compression level (1-9).  The new level will be activated
        /// immediately.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <exception cref="ArgumentOutOfRangeException">Level specified is not supported.</exception>
        /// <see cref="Deflater" />
        public void SetLevel(int level)
		{
			if (level < Deflater.BEST_SPEED) {
				throw new ArgumentOutOfRangeException("level");
			}
			def.SetLevel(level);
		}

        /// <summary>
        /// Get the current compression level.
        /// </summary>
        /// <returns>The current compression level.</returns>
        public int GetLevel()
		{
			return def.GetLevel();
		}

        /// <summary>
        /// Finish compression and write any footer information required to stream
        /// </summary>
        public override void Finish()
		{
			base.Finish();
			
			int totalin = def.TotalIn;
			int crcval = (int) (crc.Value & 0xffffffff);
			
			//    System.err.println("CRC val is " + Integer.toHexString( crcval ) 		       + " and length " + Integer.toHexString(totalin));
			
			byte[] gzipFooter = {
				(byte) crcval, (byte) (crcval >> 8),
				(byte) (crcval >> 16), (byte) (crcval >> 24),
				
				(byte) totalin, (byte) (totalin >> 8),
				(byte) (totalin >> 16), (byte) (totalin >> 24)
			};

			baseOutputStream.Write(gzipFooter, 0, gzipFooter.Length);
			//    System.err.println("wrote GZIP trailer (" + gzipFooter.length + " bytes )");
		}
	}
}
