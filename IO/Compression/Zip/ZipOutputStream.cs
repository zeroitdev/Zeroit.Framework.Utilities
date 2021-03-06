// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ZipOutputStream.cs" company="Zeroit Dev Technologies">
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
using System.Collections;
using Zeroit.Framework.Utilities.IO.Compression.Checksums;
using Zeroit.Framework.Utilities.IO.Compression.Zip.Compression;
using Zeroit.Framework.Utilities.IO.Compression.Zip.Compression.Streams;

namespace Zeroit.Framework.Utilities.IO.Compression.Zip
{
    /// <summary>
    /// This is a DeflaterOutputStream that writes the files into a zip
    /// archive one after another.  It has a special method to start a new
    /// zip entry.  The zip entries contains information about the file name
    /// size, compressed size, CRC, etc.
    /// It includes support for Stored and Deflated entries.
    /// This class is not thread safe.
    /// <br /><br />Author of the original java version : Jochen Hoenicke
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.IO.Compression.Zip.Compression.Streams.DeflaterOutputStream" />
    /// <example> This sample shows how to create a zip file
    /// <code>
    /// using System;
    /// using System.IO;
    /// using Zeroit.Framework.Utilities.IO.Compression.Zip;
    /// class MainClass
    /// {
    /// public static void Main(string[] args)
    /// {
    /// string[] filenames = Directory.GetFiles(args[0]);
    /// ZipOutputStream s = new ZipOutputStream(File.Create(args[1]));
    /// s.SetLevel(5); // 0 - store only to 9 - means best compression
    /// foreach (string file in filenames) {
    /// FileStream fs = File.OpenRead(file);
    /// byte[] buffer = new byte[fs.Length];
    /// fs.Read(buffer, 0, buffer.Length);
    /// ZipEntry entry = new ZipEntry(file);
    /// s.PutNextEntry(entry);
    /// s.Write(buffer, 0, buffer.Length);
    /// }
    /// s.Finish();
    /// s.Close();
    /// }
    /// }
    /// </code></example>
    public class ZipOutputStream : DeflaterOutputStream
	{
        /// <summary>
        /// The entries
        /// </summary>
        private ArrayList entries  = new ArrayList();
        /// <summary>
        /// The CRC
        /// </summary>
        private Crc32     crc      = new Crc32();
        /// <summary>
        /// The current entry
        /// </summary>
        private ZipEntry  curEntry = null;

        /// <summary>
        /// The default compression level
        /// </summary>
        int defaultCompressionLevel = Deflater.DEFAULT_COMPRESSION;
        /// <summary>
        /// The current method
        /// </summary>
        CompressionMethod curMethod = CompressionMethod.Deflated;


        /// <summary>
        /// The size
        /// </summary>
        private long size;
        /// <summary>
        /// The offset
        /// </summary>
        private long offset = 0;

        /// <summary>
        /// The zip comment
        /// </summary>
        private byte[] zipComment = new byte[0];

        /// <summary>
        /// Gets boolean indicating central header has been added for this archive...
        /// No further entries can be added once this has been done.
        /// </summary>
        /// <value><c>true</c> if this instance is finished; otherwise, <c>false</c>.</value>
        public bool IsFinished {
			get {
				return entries == null;
			}
		}

        /// <summary>
        /// Creates a new Zip output stream, writing a zip archive.
        /// </summary>
        /// <param name="baseOutputStream">The output stream to which the archive contents are written.</param>
        public ZipOutputStream(Stream baseOutputStream) : base(baseOutputStream, new Deflater(Deflater.DEFAULT_COMPRESSION, true))
		{
		}

        /// <summary>
        /// Set the zip file comment.
        /// </summary>
        /// <param name="comment">The comment string</param>
        /// <exception cref="ArgumentOutOfRangeException">comment</exception>
        public void SetComment(string comment)
		{
			byte[] commentBytes = ZipConstants.ConvertToArray(comment);
			if (commentBytes.Length > 0xffff) {
				throw new ArgumentOutOfRangeException("comment");
			}
			zipComment = commentBytes;
		}

        /// <summary>
        /// Sets default compression level.  The new level will be activated
        /// immediately.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <exception cref="ArgumentOutOfRangeException">Level specified is not supported.</exception>
        /// <see cref="Deflater" />
        public void SetLevel(int level)
		{
			defaultCompressionLevel = level;
			def.SetLevel(level);
		}

        /// <summary>
        /// Get the current deflate compression level
        /// </summary>
        /// <returns>The current compression level</returns>
        public int GetLevel()
		{
			return def.GetLevel();
		}

        /// <summary>
        /// Write an unsigned short in little endian byte order.
        /// </summary>
        /// <param name="value">The value.</param>
        private void WriteLeShort(int value)
		{
			baseOutputStream.WriteByte((byte)(value & 0xff));
			baseOutputStream.WriteByte((byte)((value >> 8) & 0xff));
		}

        /// <summary>
        /// Write an int in little endian byte order.
        /// </summary>
        /// <param name="value">The value.</param>
        private void WriteLeInt(int value)
		{
			WriteLeShort(value);
			WriteLeShort(value >> 16);
		}

        /// <summary>
        /// Write an int in little endian byte order.
        /// </summary>
        /// <param name="value">The value.</param>
        private void WriteLeLong(long value)
		{
			WriteLeInt((int)value);
			WriteLeInt((int)(value >> 32));
		}


        /// <summary>
        /// The patch entry header
        /// </summary>
        bool patchEntryHeader = false;

        /// <summary>
        /// The header patch position
        /// </summary>
        long headerPatchPos   = -1;

        /// <summary>
        /// Starts a new Zip entry. It automatically closes the previous
        /// entry if present.
        /// All entry elements bar name are optional, but must be correct if present.
        /// If the compression method is stored and the output is not patchable
        /// the compression for that entry is automatically changed to deflate level 0
        /// </summary>
        /// <param name="entry">the entry.</param>
        /// <exception cref="InvalidOperationException">ZipOutputStream was finished</exception>
        /// <exception cref="Zeroit.Framework.Utilities.IO.Compression.Zip.ZipException">
        /// Too many entries for Zip file
        /// or
        /// Method STORED, but compressed size != size
        /// or
        /// Entry name too long.
        /// or
        /// Extra data too long.
        /// </exception>
        /// <exception cref="System.IO.IOException">if an I/O error occured.</exception>
        /// <exception cref="System.InvalidOperationException">if stream was finished</exception>
        /// <exception cref="ZipException">Too many entries in the Zip file<br />
        /// Entry name is too long<br />
        /// Finish has already been called<br /></exception>
        public void PutNextEntry(ZipEntry entry)
		{
			if (entries == null) {
				throw new InvalidOperationException("ZipOutputStream was finished");
			}
			
			if (curEntry != null) {
				CloseEntry();
			}

			if (entries.Count >= 0xffff) {
				throw new ZipException("Too many entries for Zip file");
			}
			
			CompressionMethod method = entry.CompressionMethod;
			int compressionLevel = defaultCompressionLevel;
			
			entry.Flags = 0;
			patchEntryHeader = false;
			bool headerInfoAvailable = true;
			
			if (method == CompressionMethod.Stored) {
				if (entry.CompressedSize >= 0) {
					if (entry.Size < 0) {
						entry.Size = entry.CompressedSize;
					} else if (entry.Size != entry.CompressedSize) {
						throw new ZipException("Method STORED, but compressed size != size");
					}
				} else {
					if (entry.Size >= 0) {
						entry.CompressedSize = entry.Size;
					}
				}
					
				if (entry.Size < 0 || entry.Crc < 0) {
					if (CanPatchEntries == true) {
						headerInfoAvailable = false;
					}
					else {
                  // Cant patch entries so storing is not possible.
						method = CompressionMethod.Deflated;
						compressionLevel = 0;
					}
				}
			}
				
			if (method == CompressionMethod.Deflated) {
				if (entry.Size == 0) {
               // No need to compress - no data.
					entry.CompressedSize = entry.Size;
					entry.Crc = 0;
					method = CompressionMethod.Stored;
				} else if (entry.CompressedSize < 0 || entry.Size < 0 || entry.Crc < 0) {
					headerInfoAvailable = false;
				}
			}
			
			if (headerInfoAvailable == false) {
				if (CanPatchEntries == false) {
					entry.Flags |= 8;
				} else {
					patchEntryHeader = true;
				}
			}
			
			if (Password != null) {
				entry.IsCrypted = true;
				if (entry.Crc < 0) {
               // Need to append data descriptor as crc is used for encryption and its not known.
					entry.Flags |= 8;
				}
			}
			entry.Offset = (int)offset;
			entry.CompressionMethod = (CompressionMethod)method;
			
			curMethod    = method;
			
			// Write the local file header
			WriteLeInt(ZipConstants.LOCSIG);
			
			WriteLeShort(entry.Version);
			WriteLeShort(entry.Flags);
			WriteLeShort((byte)method);
			WriteLeInt((int)entry.DosTime);
			if (headerInfoAvailable == true) {
				WriteLeInt((int)entry.Crc);
				WriteLeInt(entry.IsCrypted ? (int)entry.CompressedSize + ZipConstants.CRYPTO_HEADER_SIZE : (int)entry.CompressedSize);
				WriteLeInt((int)entry.Size);
			} else {
				if (patchEntryHeader == true) {
					headerPatchPos = baseOutputStream.Position;
				}
				WriteLeInt(0);	// Crc
				WriteLeInt(0);	// Compressed size
				WriteLeInt(0);	// Uncompressed size
			}
			
			byte[] name = ZipConstants.ConvertToArray(entry.Name);
			
			if (name.Length > 0xFFFF) {
				throw new ZipException("Entry name too long.");
			}

			byte[] extra = entry.ExtraData;
			if (extra == null) {
				extra = new byte[0];
			}

			if (extra.Length > 0xFFFF) {
				throw new ZipException("Extra data too long.");
			}
			
			WriteLeShort(name.Length);
			WriteLeShort(extra.Length);
			baseOutputStream.Write(name, 0, name.Length);
			baseOutputStream.Write(extra, 0, extra.Length);
			
			offset += ZipConstants.LOCHDR + name.Length + extra.Length;
			
			// Activate the entry.
			curEntry = entry;
			crc.Reset();
			if (method == CompressionMethod.Deflated) {
				def.Reset();
				def.SetLevel(compressionLevel);
			}
			size = 0;
			
			if (entry.IsCrypted == true) {
				if (entry.Crc < 0) {			// so testing Zip will says its ok
					WriteEncryptionHeader(entry.DosTime << 16);
				} else {
					WriteEncryptionHeader(entry.Crc);
				}
			}
		}

        /// <summary>
        /// Closes the current entry, updating header and footer information as required
        /// </summary>
        /// <exception cref="InvalidOperationException">No open entry</exception>
        /// <exception cref="Zeroit.Framework.Utilities.IO.Compression.Zip.ZipException">
        /// size was " + size + ", but I expected " + curEntry.Size
        /// or
        /// compressed size was " + csize + ", but I expected " + curEntry.CompressedSize
        /// or
        /// crc was " + crc.Value +	", but I expected " + curEntry.Crc
        /// or
        /// Maximum Zip file size exceeded
        /// </exception>
        /// <exception cref="System.IO.IOException">An I/O error occurs.</exception>
        /// <exception cref="System.InvalidOperationException">No entry is active.</exception>
        public void CloseEntry()
		{
			if (curEntry == null) {
				throw new InvalidOperationException("No open entry");
			}
			
			// First finish the deflater, if appropriate
			if (curMethod == CompressionMethod.Deflated) {
				base.Finish();
			}
			
			long csize = curMethod == CompressionMethod.Deflated ? def.TotalOut : size;
			
			if (curEntry.Size < 0) {
				curEntry.Size = size;
			} else if (curEntry.Size != size) {
				throw new ZipException("size was " + size + ", but I expected " + curEntry.Size);
			}
			
			if (curEntry.CompressedSize < 0) {
				curEntry.CompressedSize = csize;
			} else if (curEntry.CompressedSize != csize) {
				throw new ZipException("compressed size was " + csize + ", but I expected " + curEntry.CompressedSize);
			}
			
			if (curEntry.Crc < 0) {
				curEntry.Crc = crc.Value;
			} else if (curEntry.Crc != crc.Value) {
				throw new ZipException("crc was " + crc.Value +	", but I expected " + curEntry.Crc);
			}
			
			offset += csize;

			if (offset > 0xffffffff) {
				throw new ZipException("Maximum Zip file size exceeded");
			}
				
			if (curEntry.IsCrypted == true) {
				curEntry.CompressedSize += ZipConstants.CRYPTO_HEADER_SIZE;
			}
				
			// Patch the header if possible
			if (patchEntryHeader == true) {
				long curPos = baseOutputStream.Position;
				baseOutputStream.Seek(headerPatchPos, SeekOrigin.Begin);
				WriteLeInt((int)curEntry.Crc);
				WriteLeInt((int)curEntry.CompressedSize);
				WriteLeInt((int)curEntry.Size);
				baseOutputStream.Seek(curPos, SeekOrigin.Begin);
				patchEntryHeader = false;
			}

			// Add data descriptor if flagged as required
			if ((curEntry.Flags & 8) != 0) {
				WriteLeInt(ZipConstants.EXTSIG);
				WriteLeInt((int)curEntry.Crc);
				WriteLeInt((int)curEntry.CompressedSize);
				WriteLeInt((int)curEntry.Size);
				offset += ZipConstants.EXTHDR;
			}
			
			entries.Add(curEntry);
			curEntry = null;
		}

        /// <summary>
        /// Writes the encryption header.
        /// </summary>
        /// <param name="crcValue">The CRC value.</param>
        void WriteEncryptionHeader(long crcValue)
		{
			offset += ZipConstants.CRYPTO_HEADER_SIZE;
			
			InitializePassword(Password);
			
			byte[] cryptBuffer = new byte[ZipConstants.CRYPTO_HEADER_SIZE];
			Random rnd = new Random();
			rnd.NextBytes(cryptBuffer);
			cryptBuffer[11] = (byte)(crcValue >> 24);
			
			EncryptBlock(cryptBuffer, 0, cryptBuffer.Length);
			baseOutputStream.Write(cryptBuffer, 0, cryptBuffer.Length);
		}

        /// <summary>
        /// Writes the given buffer to the current entry.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <param name="off">The off.</param>
        /// <param name="len">The length.</param>
        /// <exception cref="InvalidOperationException">No open entry.</exception>
        /// <exception cref="Zeroit.Framework.Utilities.IO.Compression.Zip.ZipException">Maximum entry size exceeded</exception>
        /// <exception cref="ZipException">Archive size is invalid</exception>
        /// <exception cref="System.InvalidOperationException">No entry is active.</exception>
        public override void Write(byte[] b, int off, int len)
		{
			if (curEntry == null) {
				throw new InvalidOperationException("No open entry.");
			}
			
			if (len <= 0)
				return;
			
			crc.Update(b, off, len);
			size += len;
			
			if (size > 0xffffffff || size < 0) {
				throw new ZipException("Maximum entry size exceeded");
			}
				

			switch (curMethod) {
				case CompressionMethod.Deflated:
					base.Write(b, off, len);
					break;
				
				case CompressionMethod.Stored:
					if (Password != null) {
						byte[] buf = new byte[len];
						Array.Copy(b, off, buf, 0, len);
						EncryptBlock(buf, 0, len);
						baseOutputStream.Write(buf, off, len);
					} else {
						baseOutputStream.Write(b, off, len);
					}
					break;
			}
		}

        /// <summary>
        /// Finishes the stream.  This will write the central directory at the
        /// end of the zip file and flush the stream.
        /// </summary>
        /// <exception cref="Zeroit.Framework.Utilities.IO.Compression.Zip.ZipException">
        /// Name too long.
        /// or
        /// Comment too long.
        /// </exception>
        /// <exception cref="System.IO.IOException">An I/O error occurs.</exception>
        /// <exception cref="ZipException">Comment exceeds the maximum length<br />
        /// Entry name exceeds the maximum length</exception>
        /// <remarks>This is automatically called when the stream is closed.</remarks>
        public override void Finish()
		{
			if (entries == null)  {
				return;
			}
			
			if (curEntry != null) {
				CloseEntry();
			}
			
			int numEntries = 0;
			int sizeEntries = 0;
			
			foreach (ZipEntry entry in entries) {
				CompressionMethod method = entry.CompressionMethod;
				WriteLeInt(ZipConstants.CENSIG); 
				WriteLeShort(ZipConstants.VERSION_MADE_BY);
				WriteLeShort(entry.Version);
				WriteLeShort(entry.Flags);
				WriteLeShort((short)method);
				WriteLeInt((int)entry.DosTime);
				WriteLeInt((int)entry.Crc);
				WriteLeInt((int)entry.CompressedSize);
				WriteLeInt((int)entry.Size);
				
				byte[] name = ZipConstants.ConvertToArray(entry.Name);
				
				if (name.Length > 0xffff) {
					throw new ZipException("Name too long.");
				}
				
				byte[] extra = entry.ExtraData;
				if (extra == null) {
					extra = new byte[0];
				}
				
				byte[] entryComment = entry.Comment != null ? ZipConstants.ConvertToArray(entry.Comment) : new byte[0];
				if (entryComment.Length > 0xffff) {
					throw new ZipException("Comment too long.");
				}
				
				WriteLeShort(name.Length);
				WriteLeShort(extra.Length);
				WriteLeShort(entryComment.Length);
				WriteLeShort(0);	// disk number
				WriteLeShort(0);	// internal file attr
									// external file attribute

				if (entry.ExternalFileAttributes != -1) {
					WriteLeInt(entry.ExternalFileAttributes);
				} else {
					if (entry.IsDirectory) {                         // mark entry as directory (from nikolam.AT.perfectinfo.com)
						WriteLeInt(16);
					} else {
						WriteLeInt(0);
					}
				}

				WriteLeInt(entry.Offset);
				
				baseOutputStream.Write(name,    0, name.Length);
				baseOutputStream.Write(extra,   0, extra.Length);
				baseOutputStream.Write(entryComment, 0, entryComment.Length);
				++numEntries;
				sizeEntries += ZipConstants.CENHDR + name.Length + extra.Length + entryComment.Length;
			}
			
			WriteLeInt(ZipConstants.ENDSIG);
			WriteLeShort(0);                    // number of this disk
			WriteLeShort(0);                    // no of disk with start of central dir
			WriteLeShort(numEntries);           // entries in central dir for this disk
			WriteLeShort(numEntries);           // total entries in central directory
			WriteLeInt(sizeEntries);            // size of the central directory
			WriteLeInt((int)offset);            // offset of start of central dir
			WriteLeShort(zipComment.Length);
			baseOutputStream.Write(zipComment, 0, zipComment.Length);
			baseOutputStream.Flush();
			entries = null;
		}
	}
}
