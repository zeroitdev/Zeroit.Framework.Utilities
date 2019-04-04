// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="ZipInputStream.cs" company="Zeroit Dev Technologies">
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
using System.Text;
using System.IO;

using Zeroit.Framework.Utilities.IO.Compression.Checksums;
using Zeroit.Framework.Utilities.IO.Compression.Zip.Compression;
using Zeroit.Framework.Utilities.IO.Compression.Zip.Compression.Streams;
using Zeroit.Framework.Utilities.IO.Compression.Encryption;

namespace Zeroit.Framework.Utilities.IO.Compression.Zip 
{
    /// <summary>
    /// This is an InflaterInputStream that reads the files baseInputStream an zip archive
    /// one after another.  It has a special method to get the zip entry of
    /// the next file.  The zip entry contains information about the file name
    /// size, compressed size, Crc, etc.
    /// It includes support for Stored and Deflated entries.
    /// <br /><br />Author of the original java version : Jochen Hoenicke
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.IO.Compression.Zip.Compression.Streams.InflaterInputStream" />
    /// <example> This sample shows how to read a zip file
    /// <code lang="C#">
    /// using System;
    /// using System.Text;
    /// using System.IO;
    /// using Zeroit.Framework.Utilities.IO.Compression.Zip;
    /// class MainClass
    /// {
    /// public static void Main(string[] args)
    /// {
    /// ZipInputStream s = new ZipInputStream(File.OpenRead(args[0]));
    /// ZipEntry theEntry;
    /// while ((theEntry = s.GetNextEntry()) != null) {
    /// int size = 2048;
    /// byte[] data = new byte[2048];
    /// Console.Write("Show contents (y/n) ?");
    /// if (Console.ReadLine() == "y") {
    /// while (true) {
    /// size = s.Read(data, 0, data.Length);
    /// if (size &gt; 0) {
    /// Console.Write(new ASCIIEncoding().GetString(data, 0, size));
    /// } else {
    /// break;
    /// }
    /// }
    /// }
    /// }
    /// s.Close();
    /// }
    /// }
    /// </code></example>
    public class ZipInputStream : InflaterInputStream
	{
        // Delegate for reading bytes from a stream.
        /// <summary>
        /// Delegate ReaderDelegate
        /// </summary>
        /// <param name="b">The b.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="length">The length.</param>
        /// <returns>System.Int32.</returns>
        delegate int ReaderDelegate(byte[] b, int offset, int length);

        /// <summary>
        /// The current reader this instance.
        /// </summary>
        ReaderDelegate internalReader;

        /// <summary>
        /// The CRC
        /// </summary>
        Crc32 crc = new Crc32();
        /// <summary>
        /// The entry
        /// </summary>
        ZipEntry entry = null;

        /// <summary>
        /// The size
        /// </summary>
        long size;
        /// <summary>
        /// The method
        /// </summary>
        int method;
        /// <summary>
        /// The flags
        /// </summary>
        int flags;
        /// <summary>
        /// The password
        /// </summary>
        string password = null;

        /// <summary>
        /// Creates a new Zip input stream, for reading a zip archive.
        /// </summary>
        /// <param name="baseInputStream">The InputStream to read bytes from</param>
        public ZipInputStream(Stream baseInputStream) : base(baseInputStream, new Inflater(true))
		{
			internalReader = new ReaderDelegate(InitialRead);
		}


        /// <summary>
        /// Optional password used for encryption when non-null
        /// </summary>
        /// <value>The password.</value>
        public string Password 
		{
			get {
				return password;
			}
			set {
				password = value;
			}
		}


        /// <summary>
        /// Gets a value indicating if the entry can be decompressed
        /// </summary>
        /// <value><c>true</c> if this instance can decompress entry; otherwise, <c>false</c>.</value>
        /// <remarks>The entry can only be decompressed if the library supports the zip features required to extract it.
        /// See the <see cref="ZipEntry.Version">ZipEntry Version</see> property for more details.</remarks>
        public bool CanDecompressEntry {
			get {
				return entry != null && entry.Version <= ZipConstants.VERSION_MADE_BY;
			}
		}

        /// <summary>
        /// Advances to the next entry in the archive
        /// </summary>
        /// <returns>The next <see cref="ZipEntry">entry</see> in the archive or null if there are no more entries.</returns>
        /// <exception cref="InvalidOperationException">Input stream is closed</exception>
        /// <exception cref="Zeroit.Framework.Utilities.IO.Compression.Zip.ZipException">
        /// Wrong Local header signature: 0x" + String.Format("{0:X}", header)
        /// or
        /// Stored, but compressed != uncompressed
        /// or
        /// Unknown compression method " + method
        /// </exception>
        /// <exception cref="ZipException">Input stream is closed</exception>
        /// <remarks>If the previous entry is still open <see cref="CloseEntry">CloseEntry</see> is called.</remarks>
        public ZipEntry GetNextEntry()
		{
			if (crc == null) {
				throw new InvalidOperationException("Closed.");
			}
			
			if (entry != null) {
				CloseEntry();
			}

			int header = inputBuffer.ReadLeInt();

			if (header == ZipConstants.CENSIG || 
			    header == ZipConstants.ENDSIG || 
			    header == ZipConstants.CENDIGITALSIG || 
			    header == ZipConstants.CENSIG64) {
			    // No more individual entries exist
				Close();
				return null;
			}

			// -jr- 07-Dec-2003 Ignore spanning temporary signatures if found
			// SPANNINGSIG is same as descriptor signature and is untested as yet.
			if (header == ZipConstants.SPANTEMPSIG || header == ZipConstants.SPANNINGSIG) {
				header = inputBuffer.ReadLeInt();
			}
			
			if (header != ZipConstants.LOCSIG) {
				throw new ZipException("Wrong Local header signature: 0x" + String.Format("{0:X}", header));
			}
			
			short versionRequiredToExtract = (short)inputBuffer.ReadLeShort();
			
			flags          = inputBuffer.ReadLeShort();
			method         = inputBuffer.ReadLeShort();
			uint dostime   = (uint)inputBuffer.ReadLeInt();
			int crc2       = inputBuffer.ReadLeInt();
			csize          = inputBuffer.ReadLeInt();
			size           = inputBuffer.ReadLeInt();
			int nameLen    = inputBuffer.ReadLeShort();
			int extraLen   = inputBuffer.ReadLeShort();
			
			bool isCrypted = (flags & 1) == 1;
			
			byte[] buffer = new byte[nameLen];
			inputBuffer.ReadRawBuffer(buffer);
			
			string name = ZipConstants.ConvertToString(buffer);
			
			entry = new ZipEntry(name, versionRequiredToExtract);
			entry.Flags = flags;
			
			if (method == (int)CompressionMethod.Stored && (!isCrypted && csize != size || (isCrypted && csize - ZipConstants.CRYPTO_HEADER_SIZE != size))) {
				throw new ZipException("Stored, but compressed != uncompressed");
			}
			
			if (method != (int)CompressionMethod.Stored && method != (int)CompressionMethod.Deflated) {
				throw new ZipException("Unknown compression method " + method);
			}
			
			entry.CompressionMethod = (CompressionMethod)method;
			
			if ((flags & 8) == 0) {
				entry.Crc  = crc2 & 0xFFFFFFFFL;
				entry.Size = size & 0xFFFFFFFFL;
				entry.CompressedSize = csize & 0xFFFFFFFFL;
			} else {
				
				// This allows for GNU, WinZip and possibly other archives, the PKZIP spec says these are zero
				// under these circumstances.
				if (crc2 != 0) {
					entry.Crc = crc2 & 0xFFFFFFFFL;
				}
				
				if (size != 0) {
					entry.Size = size & 0xFFFFFFFFL;
				}
				if (csize != 0) {
					entry.CompressedSize = csize & 0xFFFFFFFFL;
				}
			}
			
			entry.DosTime = dostime;
			
			if (extraLen > 0) {
				byte[] extra = new byte[extraLen];
				inputBuffer.ReadRawBuffer(extra);
				entry.ExtraData = extra;
			}

			internalReader = new ReaderDelegate(InitialRead);
			return entry;
		}

        // Read data descriptor at the end of compressed data.
        /// <summary>
        /// Reads the data descriptor.
        /// </summary>
        /// <exception cref="Zeroit.Framework.Utilities.IO.Compression.Zip.ZipException">Data descriptor signature not found</exception>
        void ReadDataDescriptor()
		{
			if (inputBuffer.ReadLeInt() != ZipConstants.EXTSIG) {
				throw new ZipException("Data descriptor signature not found");
			}
			
			entry.Crc = inputBuffer.ReadLeInt() & 0xFFFFFFFFL;
			csize = inputBuffer.ReadLeInt();
			size = inputBuffer.ReadLeInt();
			
			entry.Size = size & 0xFFFFFFFFL;
			entry.CompressedSize = csize & 0xFFFFFFFFL;
		}

        /// <summary>
        /// Closes the current zip entry and moves to the next one.
        /// </summary>
        /// <exception cref="InvalidOperationException">The stream is closed</exception>
        /// <exception cref="Zeroit.Framework.Utilities.IO.Compression.Zip.ZipException">Zip archive ends early.</exception>
        /// <exception cref="ZipException">The stream is closed</exception>
        public void CloseEntry()
		{
			if (crc == null) {
				throw new InvalidOperationException("Closed.");
			}
			
			if (entry == null) {
				return;
			}
			
			if (method == (int)CompressionMethod.Deflated) {
				if ((flags & 8) != 0) {
					// We don't know how much we must skip, read until end.
					byte[] tmp = new byte[2048];
					while (Read(tmp, 0, tmp.Length) > 0)
						;
					// read will close this entry
					return;
				}
				csize -= inf.TotalIn;
				inputBuffer.Available -= inf.RemainingInput;	
			}

			if (inputBuffer.Available > csize && csize >= 0) {
				inputBuffer.Available = (int)((long)inputBuffer.Available - csize);
			} else {
				csize -= inputBuffer.Available;
				inputBuffer.Available = 0;
				while (csize != 0) {
					int skipped = (int)base.Skip(csize & 0xFFFFFFFFL);
					
					if (skipped <= 0) {
						throw new ZipException("Zip archive ends early.");
					}
					
					csize -= skipped;
				}
			}
			
			size = 0;
			crc.Reset();
			if (method == (int)CompressionMethod.Deflated) {
				inf.Reset();
			}
			entry = null;
		}

        /// <summary>
        /// Returns 1 if there is an entry available
        /// Otherwise returns 0.
        /// </summary>
        /// <value>The available.</value>
        public override int Available {
			get {
				return entry != null ? 1 : 0;
			}
		}

        /// <summary>
        /// Reads a byte from the current zip entry.
        /// </summary>
        /// <returns>The byte or -1 if end of stream is reached.</returns>
        public override int ReadByte()
		{
			byte[] b = new byte[1];
			if (Read(b, 0, 1) <= 0) {
				return -1;
			}
			return b[0] & 0xff;
		}

        // Perform the initial read on an entry which may include 
        // reading encryption headers and setting up inflation.
        /// <summary>
        /// Initials the read.
        /// </summary>
        /// <param name="destination">The destination.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="count">The count.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="Zeroit.Framework.Utilities.IO.Compression.Zip.ZipException">
        /// Libray cannot extract this entry version required (" + entry.Version.ToString() + ")
        /// or
        /// No password set.
        /// or
        /// Invalid password
        /// or
        /// Invalid password
        /// </exception>
        int InitialRead(byte[] destination, int offset, int count)
		{
			if (entry.Version > ZipConstants.VERSION_MADE_BY) {
				throw new ZipException("Libray cannot extract this entry version required (" + entry.Version.ToString() + ")");
			}
			
			// test for encryption
			if (entry.IsCrypted) {
		
				if (password == null) {
					throw new ZipException("No password set.");
				}
			
				// Generate and set crypto transform...
				PkzipClassicManaged managed = new PkzipClassicManaged();
				byte[] key = PkzipClassic.GenerateKeys(Encoding.ASCII.GetBytes(password));
					
				inputBuffer.CryptoTransform = managed.CreateDecryptor(key, null);
			
				byte[] cryptbuffer = new byte[ZipConstants.CRYPTO_HEADER_SIZE];
				inputBuffer.ReadClearTextBuffer(cryptbuffer, 0, ZipConstants.CRYPTO_HEADER_SIZE);
					
				if ((flags & 8) == 0) {
					if (cryptbuffer[ZipConstants.CRYPTO_HEADER_SIZE - 1] != (byte)(entry.Crc >> 24)) {
						throw new ZipException("Invalid password");
					}
				}
				else {
					if (cryptbuffer[ZipConstants.CRYPTO_HEADER_SIZE - 1] != (byte)((entry.DosTime >> 8) & 0xff)) {
						throw new ZipException("Invalid password");
					}
				}
					
				if (csize >= ZipConstants.CRYPTO_HEADER_SIZE) {
					csize -= ZipConstants.CRYPTO_HEADER_SIZE;
				}
			} 
			else {
				inputBuffer.CryptoTransform = null;
			}
			
			if (method == (int)CompressionMethod.Deflated && inputBuffer.Available > 0) {
				inputBuffer.SetInflaterInput(inf);
			}
			
			internalReader = new ReaderDelegate(BodyRead);
			return BodyRead(destination, offset, count);
		}


        /// <summary>
        /// Read a block of bytes from the stream.
        /// </summary>
        /// <param name="destination">The destination for the bytes.</param>
        /// <param name="index">The index to start storing data.</param>
        /// <param name="count">The number of bytes to attempt to read.</param>
        /// <returns>Returns the number of bytes read.</returns>
        /// <remarks>Zero bytes read means end of stream.</remarks>
        public override int Read(byte[] destination, int index, int count)
		{
			return internalReader(destination, index, count);
		}

        /// <summary>
        /// Reads a block of bytes from the current zip entry.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <param name="off">The off.</param>
        /// <param name="len">The length.</param>
        /// <returns>The number of bytes read (this may be less than the length requested, even before the end of stream), or 0 on end of stream.</returns>
        /// <exception cref="InvalidOperationException">The stream is not open.</exception>
        /// <exception cref="Zeroit.Framework.Utilities.IO.Compression.Zip.ZipException">
        /// Inflater not finished!?
        /// or
        /// size mismatch: " + csize + ";" + size + " <-> " + inf.TotalIn + ";" + inf.TotalOut
        /// or
        /// EOF in stored block
        /// or
        /// CRC mismatch
        /// </exception>
        /// <exception cref="ZipException">An i/o error occured.</exception>
        public int BodyRead(byte[] b, int off, int len)
		{
			if (crc == null) {
				throw new InvalidOperationException("Closed.");
			}
			
			if (entry == null || len <= 0 ) {
				return 0;
			}
			
			bool finished = false;
			
			switch (method) {
				case (int)CompressionMethod.Deflated:
					len = base.Read(b, off, len);
					if (len <= 0) {
						if (!inf.IsFinished) {
							throw new ZipException("Inflater not finished!?");
						}
						inputBuffer.Available = inf.RemainingInput;
						
						if ((flags & 8) == 0 && (inf.TotalIn != csize || inf.TotalOut != size)) {
							throw new ZipException("size mismatch: " + csize + ";" + size + " <-> " + inf.TotalIn + ";" + inf.TotalOut);
						}
						inf.Reset();
						finished = true;
					}
					break;
				
				case (int)CompressionMethod.Stored:
					if (len > csize && csize >= 0) {
						len = (int)csize;
					}
					len = inputBuffer.ReadClearTextBuffer(b, off, len);
					if (len > 0) {
						csize -= len;
						size -= len;
					}
					
					if (csize == 0) {
						finished = true;
					} else {
						if (len < 0) {
							throw new ZipException("EOF in stored block");
						}
					}
					break;
			}
				
			if (len > 0) {
				crc.Update(b, off, len);
			}
			
			if (finished) {
				StopDecrypting();
				
				if ((flags & 8) != 0) {
					ReadDataDescriptor();
				}
				
				if ((crc.Value & 0xFFFFFFFFL) != entry.Crc && entry.Crc != -1) {
					throw new ZipException("CRC mismatch");
				}
				crc.Reset();
				entry = null;
			}
			return len;
		}

        /// <summary>
        /// Closes the zip input stream
        /// </summary>
        public override void Close()
		{
			base.Close();
			crc = null;
			entry = null;
		}
	}
}
