// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="GzipInputStream.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.IO;

using Zeroit.Framework.Utilities.IO.Compression.Checksums;
using Zeroit.Framework.Utilities.IO.Compression.Zip.Compression;
using Zeroit.Framework.Utilities.IO.Compression.Zip.Compression.Streams;

namespace Zeroit.Framework.Utilities.IO.Compression.GZip 
{

    /// <summary>
    /// This filter stream is used to decompress a "GZIP" format stream.
    /// The "GZIP" format is described baseInputStream RFC 1952.
    /// author of the original java version : John Leuner
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.IO.Compression.Zip.Compression.Streams.InflaterInputStream" />
    /// <example> This sample shows how to unzip a gzipped file
    /// <code>
    /// using System;
    /// using System.IO;
    /// using Zeroit.Framework.Utilities.IO.Compression.GZip;
    /// class MainClass
    /// {
    /// public static void Main(string[] args)
    /// {
    /// Stream s = new GZipInputStream(File.OpenRead(args[0]));
    /// FileStream fs = File.Create(Path.GetFileNameWithoutExtension(args[0]));
    /// int size = 2048;
    /// byte[] writeData = new byte[2048];
    /// while (true) {
    /// size = s.Read(writeData, 0, size);
    /// if (size &gt; 0) {
    /// fs.Write(writeData, 0, size);
    /// } else {
    /// break;
    /// }
    /// }
    /// s.Close();
    /// }
    /// }
    /// </code></example>
    public class GZipInputStream : InflaterInputStream 
	{
        /// <summary>
        /// CRC-32 value for uncompressed data
        /// </summary>
        protected Crc32 crc = new Crc32();

        /// <summary>
        /// Indicates end of stream
        /// </summary>
        protected bool eos;

        // Have we read the GZIP header yet?
        /// <summary>
        /// The read gzip header
        /// </summary>
        bool readGZIPHeader;

        /// <summary>
        /// Creates a GzipInputStream with the default buffer size
        /// </summary>
        /// <param name="baseInputStream">The stream to read compressed data from (baseInputStream GZIP format)</param>
        public GZipInputStream(Stream baseInputStream) : this(baseInputStream, 4096)
		{
		}

        /// <summary>
        /// Creates a GZIPInputStream with the specified buffer size
        /// </summary>
        /// <param name="baseInputStream">The stream to read compressed data from (baseInputStream GZIP format)</param>
        /// <param name="size">Size of the buffer to use</param>
        public GZipInputStream(Stream baseInputStream, int size) : base(baseInputStream, new Inflater(true), size)
		{
		}

        /// <summary>
        /// Reads uncompressed data into an array of bytes
        /// </summary>
        /// <param name="buf">The buffer to read uncompressed data into</param>
        /// <param name="offset">The offset indicating where the data should be placed</param>
        /// <param name="len">The number of uncompressed bytes to be read</param>
        /// <returns>System.Int32.</returns>
        public override int Read(byte[] buf, int offset, int len) 
		{
			// We first have to read the GZIP header, then we feed all the
			// rest of the data to the base class.
			//
			// As we do that we continually update the CRC32. Once the data is
			// finished, we check the CRC32
			//
			// This means we don't need our own buffer, as everything is done
			// baseInputStream the superclass.
			if (!readGZIPHeader) {
				ReadHeader();
			}
			
			if (eos) {
				return 0;
			}
			
			// We don't have to read the header, so we just grab data from the superclass
			int numRead = base.Read(buf, offset, len);
			if (numRead > 0) {
				crc.Update(buf, offset, numRead);
			}
			
			if (inf.IsFinished) {
				ReadFooter();
			}
			return numRead;
		}

        /// <summary>
        /// Reads the header.
        /// </summary>
        /// <exception cref="Zeroit.Framework.Utilities.IO.Compression.GZip.GZipException">
        /// Error baseInputStream GZIP header, first byte doesn't match
        /// or
        /// Error baseInputStream GZIP header,  second byte doesn't match
        /// or
        /// Error baseInputStream GZIP header, data not baseInputStream deflate format
        /// or
        /// Early EOF baseInputStream GZIP header
        /// or
        /// Reserved flag bits baseInputStream GZIP header != 0
        /// or
        /// Early EOF baseInputStream GZIP header
        /// or
        /// Early EOF baseInputStream GZIP header
        /// or
        /// Early EOF baseInputStream GZIP header
        /// or
        /// Early EOF baseInputStream GZIP header
        /// or
        /// Early EOF baseInputStream GZIP header
        /// or
        /// Early EOF baseInputStream GZIP file name
        /// or
        /// Early EOF baseInputStream GZIP comment
        /// or
        /// Early EOF baseInputStream GZIP header
        /// or
        /// Early EOF baseInputStream GZIP header
        /// or
        /// Header CRC value mismatch
        /// </exception>
        void ReadHeader() 
		{
			/* 1. Check the two magic bytes */
			Crc32 headCRC = new Crc32();
			int magic = baseInputStream.ReadByte();
			if (magic < 0) {
				eos = true;
				return;
			}
			headCRC.Update(magic);
			if (magic != (GZipConstants.GZIP_MAGIC >> 8)) {
				throw new GZipException("Error baseInputStream GZIP header, first byte doesn't match");
			}
				
			magic = baseInputStream.ReadByte();
			if (magic != (GZipConstants.GZIP_MAGIC & 0xFF)) {
				throw new GZipException("Error baseInputStream GZIP header,  second byte doesn't match");
			}
			headCRC.Update(magic);
			
			/* 2. Check the compression type (must be 8) */
			int CM = baseInputStream.ReadByte();
			if (CM != 8) {
				throw new GZipException("Error baseInputStream GZIP header, data not baseInputStream deflate format");
			}
			headCRC.Update(CM);
			
			/* 3. Check the flags */
			int flags = baseInputStream.ReadByte();
			if (flags < 0) {
				throw new GZipException("Early EOF baseInputStream GZIP header");
			}
			headCRC.Update(flags);
			
			/*    This flag byte is divided into individual bits as follows:
				
				bit 0   FTEXT
				bit 1   FHCRC
				bit 2   FEXTRA
				bit 3   FNAME
				bit 4   FCOMMENT
				bit 5   reserved
				bit 6   reserved
				bit 7   reserved
				*/
				
			/* 3.1 Check the reserved bits are zero */
			
			if ((flags & 0xd0) != 0) {
				throw new GZipException("Reserved flag bits baseInputStream GZIP header != 0");
			}
			
			/* 4.-6. Skip the modification time, extra flags, and OS type */
			for (int i=0; i< 6; i++) {
				int readByte = baseInputStream.ReadByte();
				if (readByte < 0) {
					throw new GZipException("Early EOF baseInputStream GZIP header");
				}
				headCRC.Update(readByte);
			}
			
			/* 7. Read extra field */
			if ((flags & GZipConstants.FEXTRA) != 0) {
				/* Skip subfield id */
				for (int i=0; i< 2; i++) {
					int readByte = baseInputStream.ReadByte();
					if (readByte < 0) {
						throw new GZipException("Early EOF baseInputStream GZIP header");
					}
					headCRC.Update(readByte);
				}
				if (baseInputStream.ReadByte() < 0 || baseInputStream.ReadByte() < 0) {
					throw new GZipException("Early EOF baseInputStream GZIP header");
				}
				
				int len1, len2, extraLen;
				len1 = baseInputStream.ReadByte();
				len2 = baseInputStream.ReadByte();
				if ((len1 < 0) || (len2 < 0)) {
					throw new GZipException("Early EOF baseInputStream GZIP header");
				}
				headCRC.Update(len1);
				headCRC.Update(len2);
				
				extraLen = (len1 << 8) | len2;
				for (int i = 0; i < extraLen;i++) {
					int readByte = baseInputStream.ReadByte();
					if (readByte < 0) 
					{
						throw new GZipException("Early EOF baseInputStream GZIP header");
					}
					headCRC.Update(readByte);
				}
			}
			
			/* 8. Read file name */
			if ((flags & GZipConstants.FNAME) != 0) {
				int readByte;
				while ( (readByte = baseInputStream.ReadByte()) > 0) {
					headCRC.Update(readByte);
				}
				if (readByte < 0) {
					throw new GZipException("Early EOF baseInputStream GZIP file name");
				}
				headCRC.Update(readByte);
			}
			
			/* 9. Read comment */
			if ((flags & GZipConstants.FCOMMENT) != 0) {
				int readByte;
				while ( (readByte = baseInputStream.ReadByte()) > 0) {
					headCRC.Update(readByte);
				}
				
				if (readByte < 0) {
					throw new GZipException("Early EOF baseInputStream GZIP comment");
				}
				headCRC.Update(readByte);
			}
			
			/* 10. Read header CRC */
			if ((flags & GZipConstants.FHCRC) != 0) {
				int tempByte;
				int crcval = baseInputStream.ReadByte();
				if (crcval < 0) {
					throw new GZipException("Early EOF baseInputStream GZIP header");
				}
				
				tempByte = baseInputStream.ReadByte();
				if (tempByte < 0) {
					throw new GZipException("Early EOF baseInputStream GZIP header");
				}
				
				crcval = (crcval << 8) | tempByte;
				if (crcval != ((int) headCRC.Value & 0xffff)) {
					throw new GZipException("Header CRC value mismatch");
				}
			}
			
			readGZIPHeader = true;
		}

        /// <summary>
        /// Reads the footer.
        /// </summary>
        /// <exception cref="Zeroit.Framework.Utilities.IO.Compression.GZip.GZipException">
        /// Early EOF baseInputStream GZIP footer
        /// or
        /// GZIP crc sum mismatch, theirs \"" + crcval + "\" and ours \"" + (int) crc.Value
        /// or
        /// Number of bytes mismatch in footer
        /// </exception>
        void ReadFooter() 
		{
			byte[] footer = new byte[8];
			int avail = inf.RemainingInput;
			
			if (avail > 8) {
				avail = 8;
			}
			
         System.Array.Copy(inputBuffer.RawData, inputBuffer.RawLength - inf.RemainingInput, footer, 0, avail);
         int needed = 8 - avail;
			
			while (needed > 0) {
				int count = baseInputStream.Read(footer, 8 - needed, needed);
				if (count <= 0) {
					throw new GZipException("Early EOF baseInputStream GZIP footer");
				}
				needed -= count; // Jewel Jan 16
			}
			int crcval = (footer[0] & 0xff) | ((footer[1] & 0xff) << 8) | ((footer[2] & 0xff) << 16) | (footer[3] << 24);
			if (crcval != (int) crc.Value) {
				throw new GZipException("GZIP crc sum mismatch, theirs \"" + crcval + "\" and ours \"" + (int) crc.Value);
			}
			
			int total = (footer[4] & 0xff) | ((footer[5] & 0xff) << 8) | ((footer[6] & 0xff) << 16) | (footer[7] << 24);
			if (total != inf.TotalOut) {
				throw new GZipException("Number of bytes mismatch in footer");
			}
			
			/* XXX Should we support multiple members.
			* Difficult, since there may be some bytes still baseInputStream dataBuffer
			*/
			eos = true;
		}
	}
}
