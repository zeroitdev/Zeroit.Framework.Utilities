// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="ZipFile.cs" company="Zeroit Dev Technologies">
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
using System.Security.Cryptography;
using System.Collections;
using System.IO;
using System.Text;

using Zeroit.Framework.Utilities.IO.Compression.Checksums;
using Zeroit.Framework.Utilities.IO.Compression.Zip.Compression.Streams;
using Zeroit.Framework.Utilities.IO.Compression.Zip.Compression;
using Zeroit.Framework.Utilities.IO.Compression.Encryption;

namespace Zeroit.Framework.Utilities.IO.Compression.Zip 
{

    /// <summary>
    /// Arguments used with KeysRequiredEvent
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class KeysRequiredEventArgs : EventArgs
	{
        /// <summary>
        /// The file name
        /// </summary>
        string fileName;

        /// <summary>
        /// Get the name of the file for which keys are required.
        /// </summary>
        /// <value>The name of the file.</value>
        public string FileName
		{
			get { return fileName; }
		}

        /// <summary>
        /// The key
        /// </summary>
        byte[] key;

        /// <summary>
        /// Get/set the key value
        /// </summary>
        /// <value>The key.</value>
        public byte[] Key
		{
			get { return key; }
			set { key = value; }
		}

        /// <summary>
        /// Initialise a new instance of <see cref="KeysRequiredEventArgs"></see>
        /// </summary>
        /// <param name="name">The name of the file for which keys are required.</param>
        public KeysRequiredEventArgs(string name)
		{
			fileName = name;
		}

        /// <summary>
        /// Initialise a new instance of <see cref="KeysRequiredEventArgs"></see>
        /// </summary>
        /// <param name="name">The name of the file for which keys are required.</param>
        /// <param name="keyValue">The current key value.</param>
        public KeysRequiredEventArgs(string name, byte[] keyValue)
		{
			fileName = name;
			key = keyValue;
		}
	}

    /// <summary>
    /// This class represents a Zip archive.  You can ask for the contained
    /// entries, or get an input stream for a file entry.  The entry is
    /// automatically decompressed.
    /// This class is thread safe:  You can open input streams for arbitrary
    /// entries in different threads.
    /// <br /><br />Author of the original java version : Jochen Hoenicke
    /// </summary>
    /// <seealso cref="System.Collections.IEnumerable" />
    /// <example>
    ///   <code>
    /// using System;
    /// using System.Text;
    /// using System.Collections;
    /// using System.IO;
    /// using Zeroit.Framework.Utilities.IO.Compression.Zip;
    /// class MainClass
    /// {
    /// static public void Main(string[] args)
    /// {
    /// ZipFile zFile = new ZipFile(args[0]);
    /// Console.WriteLine("Listing of : " + zFile.Name);
    /// Console.WriteLine("");
    /// Console.WriteLine("Raw Size    Size      Date     Time     Name");
    /// Console.WriteLine("--------  --------  --------  ------  ---------");
    /// foreach (ZipEntry e in zFile) {
    /// DateTime d = e.DateTime;
    /// Console.WriteLine("{0, -10}{1, -10}{2}  {3}   {4}", e.Size, e.CompressedSize,
    /// d.ToString("dd-MM-yy"), d.ToString("t"),
    /// e.Name);
    /// }
    /// }
    /// }
    /// </code>
    /// </example>
    public class ZipFile : IEnumerable
	{
        /// <summary>
        /// The name
        /// </summary>
        string name;
        /// <summary>
        /// The comment
        /// </summary>
        string comment;
        /// <summary>
        /// The base stream
        /// </summary>
        Stream baseStream;
        /// <summary>
        /// The is stream owner
        /// </summary>
        bool isStreamOwner = true;
        /// <summary>
        /// The offset of first entry
        /// </summary>
        long offsetOfFirstEntry = 0;
        /// <summary>
        /// The entries
        /// </summary>
        ZipEntry[] entries;

        #region KeyHandling

        /// <summary>
        /// Delegate for handling keys/password setting during compresion/decompression.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KeysRequiredEventArgs"/> instance containing the event data.</param>
        public delegate void KeysRequiredEventHandler(
			object sender,
			KeysRequiredEventArgs e
		);

        /// <summary>
        /// Event handler for handling encryption keys.
        /// </summary>
        public KeysRequiredEventHandler KeysRequired;

        /// <summary>
        /// Handles getting of encryption keys when required.
        /// </summary>
        /// <param name="fileName">The file for which encryptino keys are required.</param>
        void OnKeysRequired(string fileName)
		{
			if (KeysRequired != null) {
				KeysRequiredEventArgs krea = new KeysRequiredEventArgs(fileName, key);
				KeysRequired(this, krea);
				key = krea.Key;
			}
		}

        /// <summary>
        /// The key
        /// </summary>
        byte[] key = null;

        /// <summary>
        /// Get/set the encryption key value.
        /// </summary>
        /// <value>The key.</value>
        byte[] Key
		{
			get { return key; }
			set { key = value; }
		}

        /// <summary>
        /// Password to be used for encrypting/decrypting files.
        /// </summary>
        /// <value>The password.</value>
        /// <remarks>Set to null if no password is required.</remarks>
        public string Password
		{
			set 
			{
				if ( (value == null) || (value.Length == 0) ) {
					key = null;
				}
				else {
					key = PkzipClassic.GenerateKeys(Encoding.ASCII.GetBytes(value));
				}
			}
		}

        /// <summary>
        /// The iv
        /// </summary>
        byte[] iv = null;

        /// <summary>
        /// Gets a value indicating whether [have keys].
        /// </summary>
        /// <value><c>true</c> if [have keys]; otherwise, <c>false</c>.</value>
        bool HaveKeys
		{
		 get { return key != null; }
		}
        #endregion

        /// <summary>
        /// Opens a Zip file with the given name for reading.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <exception cref="IOException">An i/o error occurs</exception>
        /// <exception cref="ZipException">The file doesn't contain a valid zip archive.</exception>
        public ZipFile(string name)
		{
			this.name = name;
			this.baseStream = File.OpenRead(name);
			try {
				ReadEntries();
			}
			catch {
				Close();
				throw;
			}
		}

        /// <summary>
        /// Opens a Zip file reading the given FileStream
        /// </summary>
        /// <param name="file">The file.</param>
        /// <exception cref="IOException">An i/o error occurs.</exception>
        /// <exception cref="ZipException">The file doesn't contain a valid zip archive.</exception>
        public ZipFile(FileStream file)
		{
			this.baseStream  = file;
			this.name = file.Name;
			try {
				ReadEntries();
			}
			catch {
				Close();
				throw;
			}
		}

        /// <summary>
        /// Opens a Zip file reading the given Stream
        /// </summary>
        /// <param name="baseStream">The base stream.</param>
        /// <exception cref="IOException">An i/o error occurs</exception>
        /// <exception cref="ZipException">The file doesn't contain a valid zip archive.<br />
        /// The stream provided cannot seek</exception>
        public ZipFile(Stream baseStream)
		{
			this.baseStream  = baseStream;
			this.name = null;
			try {
				ReadEntries();
			}
			catch {
				Close();
				throw;
			}
		}


        /// <summary>
        /// Get/set a flag indicating if the underlying stream is owned by the ZipFile instance.
        /// If the flag is true then the stream will be closed when <see cref="Close">Close</see> is called.
        /// </summary>
        /// <value><c>true</c> if this instance is stream owner; otherwise, <c>false</c>.</value>
        /// <remarks>The default value is true in all cases.</remarks>
        bool IsStreamOwner
		{
			get { return isStreamOwner; }
			set { isStreamOwner = value; }
		}

        /// <summary>
        /// Read an unsigned short in little endian byte order.
        /// </summary>
        /// <returns>Returns the value read.</returns>
        /// <exception cref="IOException">An i/o error occurs.</exception>
        /// <exception cref="EndOfStreamException">The file ends prematurely</exception>
        int ReadLeShort()
		{
			return baseStream.ReadByte() | baseStream.ReadByte() << 8;
		}

        /// <summary>
        /// Read an int in little endian byte order.
        /// </summary>
        /// <returns>Returns the value read.</returns>
        /// <exception cref="IOException">An i/o error occurs.</exception>
        /// <exception cref="System.IO.EndOfStreamException">The file ends prematurely</exception>
        int ReadLeInt()
		{
			return ReadLeShort() | ReadLeShort() << 16;
		}

        // NOTE this returns the offset of the first byte after the signature.
        /// <summary>
        /// Locates the block with signature.
        /// </summary>
        /// <param name="signature">The signature.</param>
        /// <param name="endLocation">The end location.</param>
        /// <param name="minimumBlockSize">Minimum size of the block.</param>
        /// <param name="maximumVariableData">The maximum variable data.</param>
        /// <returns>System.Int64.</returns>
        long LocateBlockWithSignature(int signature, long endLocation, int minimumBlockSize, int maximumVariableData)
		{
			long pos = endLocation - minimumBlockSize;
			if (pos < 0) {
				return -1;
			}
		
			long giveUpMarker = Math.Max(pos - maximumVariableData, 0);
		
			// TODO: this loop could be optimised for speed.
			do 
			{
				if (pos < giveUpMarker) {
					return -1;
				}
				baseStream.Seek(pos--, SeekOrigin.Begin);
			} while (ReadLeInt() != signature);
	
			return baseStream.Position;
		}

        /// <summary>
        /// Search for and read the central directory of a zip file filling the entries
        /// array.  This is called exactly once by the constructors.
        /// </summary>
        /// <exception cref="Zeroit.Framework.Utilities.IO.Compression.Zip.ZipException">The central directory is malformed or cannot be found</exception>
        /// <exception cref="System.IO.IOException">An i/o error occurs.</exception>
        void ReadEntries()
		{
			// Search for the End Of Central Directory.  When a zip comment is
			// present the directory may start earlier.
			// 
			// TODO: The search is limited to 64K which is the maximum size of a trailing comment field to aid speed.
			// This should be compatible with both SFX and ZIP files but has only been tested for Zip files
			// Need to confirm this is valid in all cases.
			// Could also speed this up by reading memory in larger blocks.			

			if (baseStream.CanSeek == false) {
				throw new ZipException("ZipFile stream must be seekable");
			}
			
			long locatedCentralDirOffset = LocateBlockWithSignature(ZipConstants.ENDSIG, baseStream.Length, ZipConstants.ENDHDR, 0xffff);
			if (locatedCentralDirOffset < 0) {
				throw new ZipException("Cannot find central directory");
			}

			int thisDiskNumber            = ReadLeShort();
			int startCentralDirDisk       = ReadLeShort();
			int entriesForThisDisk        = ReadLeShort();
			int entriesForWholeCentralDir = ReadLeShort();
			int centralDirSize            = ReadLeInt();
			int offsetOfCentralDir        = ReadLeInt();
			int commentSize               = ReadLeShort();
			
			byte[] zipComment = new byte[commentSize]; 
			baseStream.Read(zipComment, 0, zipComment.Length); 
			comment = ZipConstants.ConvertToString(zipComment); 
			
/* Its seems possible that this is too strict, more digging required.
			if (thisDiskNumber != 0 || startCentralDirDisk != 0 || entriesForThisDisk != entriesForWholeCentralDir) {
				throw new ZipException("Spanned archives are not currently handled");
			}
*/

			entries = new ZipEntry[entriesForWholeCentralDir];
			
			// SFX support, find the offset of the first entry vis the start of the stream
			// This applies to Zip files that are appended to the end of the SFX stub.
			// Zip files created by some archivers have the offsets altered to reflect the true offsets
			// and so dont require any adjustment here...
			if (offsetOfCentralDir < locatedCentralDirOffset - (4 + centralDirSize)) {
				offsetOfFirstEntry = locatedCentralDirOffset - (4 + centralDirSize + offsetOfCentralDir);
				if (offsetOfFirstEntry <= 0) {
					throw new ZipException("Invalid SFX file");
				}
			}

			baseStream.Seek(offsetOfFirstEntry + offsetOfCentralDir, SeekOrigin.Begin);
			
			for (int i = 0; i < entriesForThisDisk; i++) {
				if (ReadLeInt() != ZipConstants.CENSIG) {
					throw new ZipException("Wrong Central Directory signature");
				}
				
				int versionMadeBy      = ReadLeShort();
				int versionToExtract   = ReadLeShort();
				int bitFlags           = ReadLeShort();
				int method             = ReadLeShort();
				int dostime            = ReadLeInt();
				int crc                = ReadLeInt();
				int csize              = ReadLeInt();
				int size               = ReadLeInt();
				int nameLen            = ReadLeShort();
				int extraLen           = ReadLeShort();
				int commentLen         = ReadLeShort();
				
				int diskStartNo        = ReadLeShort();  // Not currently used
				int internalAttributes = ReadLeShort();  // Not currently used

				int externalAttributes = ReadLeInt();
				int offset             = ReadLeInt();
				
				byte[] buffer = new byte[Math.Max(nameLen, commentLen)];
				
				baseStream.Read(buffer, 0, nameLen);
				string name = ZipConstants.ConvertToString(buffer, nameLen);
				
				ZipEntry entry = new ZipEntry(name, versionToExtract, versionMadeBy);
				entry.CompressionMethod = (CompressionMethod)method;
				entry.Crc = crc & 0xffffffffL;
				entry.Size = size & 0xffffffffL;
				entry.CompressedSize = csize & 0xffffffffL;
				entry.Flags = bitFlags;
				entry.DosTime = (uint)dostime;
				
				if (extraLen > 0) {
					byte[] extra = new byte[extraLen];
					baseStream.Read(extra, 0, extraLen);
					entry.ExtraData = extra;
				}
				
				if (commentLen > 0) {
					baseStream.Read(buffer, 0, commentLen);
					entry.Comment = ZipConstants.ConvertToString(buffer, commentLen);
				}
				
				entry.ZipFileIndex           = i;
				entry.Offset                 = offset;
				entry.ExternalFileAttributes = externalAttributes;
				
				entries[i] = entry;
			}
		}

        /// <summary>
        /// Closes the ZipFile.  If the stream is <see cref="IsStreamOwner">owned</see> then this also closes the underlying input stream.
        /// Once closed, no further instance methods should be called.
        /// </summary>
        /// <exception cref="System.IO.IOException">An i/o error occurs.</exception>
        public void Close()
		{
			entries = null;
			if ( isStreamOwner ) {
				lock(baseStream) {
					baseStream.Close();
				}
			}
		}

        /// <summary>
        /// Returns an enumerator for the Zip entries in this Zip file.
        /// </summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
        /// <exception cref="InvalidOperationException">The Zip file has been closed.</exception>
        public IEnumerator GetEnumerator()
		{
			if (entries == null) {
				throw new InvalidOperationException("ZipFile has closed");
			}
			
			return new ZipEntryEnumeration(entries);
		}

        /// <summary>
        /// Return the index of the entry with a matching name
        /// </summary>
        /// <param name="name">Entry name to find</param>
        /// <param name="ignoreCase">If true the comparison is case insensitive</param>
        /// <returns>The index position of the matching entry or -1 if not found</returns>
        /// <exception cref="InvalidOperationException">The Zip file has been closed.</exception>
        public int FindEntry(string name, bool ignoreCase)
		{
			if (entries == null) {
				throw new InvalidOperationException("ZipFile has been closed");
			}
			
			for (int i = 0; i < entries.Length; i++) {
				if (string.Compare(name, entries[i].Name, ignoreCase) == 0) {
					return i;
				}
			}
			return -1;
		}

        /// <summary>
        /// Indexer property for ZipEntries
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>ZipEntry.</returns>
        [System.Runtime.CompilerServices.IndexerNameAttribute("EntryByIndex")]
		public ZipEntry this[int index] {
			get {
				return (ZipEntry) entries[index].Clone();	
			}
		}

        /// <summary>
        /// Searches for a zip entry in this archive with the given name.
        /// String comparisons are case insensitive
        /// </summary>
        /// <param name="name">The name to find. May contain directory components separated by slashes ('/').</param>
        /// <returns>The zip entry, or null if no entry with that name exists.</returns>
        /// <exception cref="InvalidOperationException">The Zip file has been closed.</exception>
        public ZipEntry GetEntry(string name)
		{
			if (entries == null) {
				throw new InvalidOperationException("ZipFile has been closed");
			}
			
			int index = FindEntry(name, true);
			return index >= 0 ? (ZipEntry) entries[index].Clone() : null;
		}
        /// <summary>
        /// Test an archive for integrity/validity
        /// </summary>
        /// <param name="testData">Perform low level data Crc check</param>
        /// <returns>true iff the test passes, false otherwise</returns>
        public bool TestArchive(bool testData)
		{
			bool result = true;
			try {
				for (int i = 0; i < Size; ++i) {
					long offset = TestLocalHeader(this[i], true, true);
					if (testData) {
						Stream entryStream = this.GetInputStream(this[i]);
						// TODO: events for updating info, recording errors etc
						Crc32 crc = new Crc32();
						byte[] buffer = new byte[4096];
						int bytesRead;
						while ((bytesRead = entryStream.Read(buffer, 0, buffer.Length)) > 0) {
							crc.Update(buffer, 0, bytesRead);
						}
	
						if (this[i].Crc != crc.Value) {
							result = false;
							// TODO: Event here....
							break; // Do all entries giving more info at some point?
						}
					}
				}
			}
			catch {
				result = false;
			}
			return result;
		}

        /// <summary>
        /// Test the local header against that provided from the central directory
        /// </summary>
        /// <param name="entry">The entry to test against</param>
        /// <param name="fullTest">If true be extremely picky about the testing, otherwise be relaxed</param>
        /// <param name="extractTest">Apply extra testing to see if the entry can be extracted by the library</param>
        /// <returns>The offset of the entries data in the file</returns>
        /// <exception cref="Zeroit.Framework.Utilities.IO.Compression.Zip.ZipException">
        /// Wrong local header signature
        /// or
        /// or
        /// The library doesnt support the zip version required to extract this entry
        /// or
        /// Central header/local header flags mismatch
        /// or
        /// Central header/local header compression method mismatch
        /// or
        /// Central header/local header crc mismatch
        /// or
        /// file name length mismatch
        /// </exception>
        long TestLocalHeader(ZipEntry entry, bool fullTest, bool extractTest)
		{
			lock(baseStream) 
			{
				baseStream.Seek(offsetOfFirstEntry + entry.Offset, SeekOrigin.Begin);
				if (ReadLeInt() != ZipConstants.LOCSIG) {
					throw new ZipException("Wrong local header signature");
				}
				
				short shortValue = (short)ReadLeShort();	 // version required to extract
				if (extractTest == true && shortValue > ZipConstants.VERSION_MADE_BY) {
					throw new ZipException(string.Format("Version required to extract this entry not supported ({0})", shortValue));
				}

				short localFlags = (short)ReadLeShort();				  // general purpose bit flags.
				if (extractTest == true) {
					if ((localFlags & (int)(GeneralBitFlags.Patched | GeneralBitFlags.StrongEncryption | GeneralBitFlags.EnhancedCompress | GeneralBitFlags.HeaderMasked)) != 0) {
						throw new ZipException("The library doesnt support the zip version required to extract this entry");
					}
				}
					
				if (localFlags != entry.Flags) {
				   throw new ZipException("Central header/local header flags mismatch");
				}

				if (entry.CompressionMethod != (CompressionMethod)ReadLeShort()) {
				   throw new ZipException("Central header/local header compression method mismatch");
				}
	
				shortValue = (short)ReadLeShort();  // file time
				shortValue = (short)ReadLeShort();  // file date
	
				int intValue = ReadLeInt();         // Crc
	
				if (fullTest) {
					if ((localFlags & (int)GeneralBitFlags.Descriptor) == 0) {
						if (intValue != (int)entry.Crc) 
							throw new ZipException("Central header/local header crc mismatch");
					}
				}
	
				intValue = ReadLeInt();	   // compressed Size
				intValue = ReadLeInt();	   // uncompressed size
	
				// TODO: make test more correct...  can't compare lengths as was done originally as this can fail for MBCS strings
				// Assuming a code page at this point is not valid?  Best is to store the name length in the ZipEntry probably
				int storedNameLength = ReadLeShort();
				if (entry.Name.Length > storedNameLength) {
					throw new ZipException("file name length mismatch");
				}
					
				int extraLen = storedNameLength + ReadLeShort();
				return offsetOfFirstEntry + entry.Offset + ZipConstants.LOCHDR + extraLen;
			}
		}

        /// <summary>
        /// Checks, if the local header of the entry at index i matches the
        /// central directory, and returns the offset to the data.
        /// </summary>
        /// <param name="entry">The entry.</param>
        /// <returns>The start offset of the (compressed) data.</returns>
        /// <exception cref="System.IO.EndOfStreamException">The stream ends prematurely</exception>
        /// <exception cref="Zeroit.Framework.Utilities.IO.Compression.Zip.ZipException">The local header signature is invalid, the entry and central header file name lengths are different
        /// or the local and entry compression methods dont match</exception>
        long CheckLocalHeader(ZipEntry entry)
		{
			return TestLocalHeader(entry, false, true);
		}

        // Refactor this, its done elsewhere as well
        /// <summary>
        /// Reads the fully.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="outBuf">The out buf.</param>
        /// <exception cref="Zeroit.Framework.Utilities.IO.Compression.Zip.ZipException">Unexpected EOF</exception>
        void ReadFully(Stream s, byte[] outBuf)
		{
			int off = 0;
			int len = outBuf.Length;
			while (len > 0) {
				int count = s.Read(outBuf, off, len);
				if (count <= 0) {
					throw new ZipException("Unexpected EOF"); 
				}
				off += count;
				len -= count;
			}
		}

        /// <summary>
        /// Checks the classic password.
        /// </summary>
        /// <param name="classicCryptoStream">The classic crypto stream.</param>
        /// <param name="entry">The entry.</param>
        /// <exception cref="Zeroit.Framework.Utilities.IO.Compression.Zip.ZipException">
        /// Invalid password
        /// or
        /// Invalid password
        /// </exception>
        void CheckClassicPassword(CryptoStream classicCryptoStream, ZipEntry entry)
		{
			byte[] cryptbuffer = new byte[ZipConstants.CRYPTO_HEADER_SIZE];
			ReadFully(classicCryptoStream, cryptbuffer);

			if ((entry.Flags & (int)GeneralBitFlags.Descriptor) == 0) {
				if (cryptbuffer[ZipConstants.CRYPTO_HEADER_SIZE - 1] != (byte)(entry.Crc >> 24)) {
					throw new ZipException("Invalid password");
				}
			}
			else {
				if (cryptbuffer[ZipConstants.CRYPTO_HEADER_SIZE - 1] != (byte)((entry.DosTime >> 8) & 0xff)) {
					throw new ZipException("Invalid password");
				}
			}
		}

        /// <summary>
        /// Creates the and initialize decryption stream.
        /// </summary>
        /// <param name="baseStream">The base stream.</param>
        /// <param name="entry">The entry.</param>
        /// <returns>Stream.</returns>
        /// <exception cref="Zeroit.Framework.Utilities.IO.Compression.Zip.ZipException">
        /// No password available for encrypted stream
        /// or
        /// Decryption method not supported
        /// </exception>
        Stream CreateAndInitDecryptionStream(Stream baseStream, ZipEntry entry)
		{
			CryptoStream result = null;

			if (entry.Version < ZipConstants.VERSION_STRONG_ENCRYPTION 
				|| (entry.Flags & (int)GeneralBitFlags.StrongEncryption) == 0) {
				PkzipClassicManaged classicManaged = new PkzipClassicManaged();

				OnKeysRequired(entry.Name);
				if (HaveKeys == false) {
					throw new ZipException("No password available for encrypted stream");
				}

				result = new CryptoStream(baseStream, classicManaged.CreateDecryptor(key, iv), CryptoStreamMode.Read);
				CheckClassicPassword(result, entry);
			}
			else {
				throw new ZipException("Decryption method not supported");
			}

			return result;
		}

        /// <summary>
        /// Writes the encryption header.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="crcValue">The CRC value.</param>
        void WriteEncryptionHeader(Stream stream, long crcValue)
		{
			byte[] cryptBuffer = new byte[ZipConstants.CRYPTO_HEADER_SIZE];
			Random rnd = new Random();
			rnd.NextBytes(cryptBuffer);
			cryptBuffer[11] = (byte)(crcValue >> 24);
			stream.Write(cryptBuffer, 0, cryptBuffer.Length);
		}

        /// <summary>
        /// Creates the and initialize encryption stream.
        /// </summary>
        /// <param name="baseStream">The base stream.</param>
        /// <param name="entry">The entry.</param>
        /// <returns>Stream.</returns>
        /// <exception cref="Zeroit.Framework.Utilities.IO.Compression.Zip.ZipException">No password available for encrypted stream</exception>
        Stream CreateAndInitEncryptionStream(Stream baseStream, ZipEntry entry)
		{
			CryptoStream result = null;
			if (entry.Version < ZipConstants.VERSION_STRONG_ENCRYPTION 
			    || (entry.Flags & (int)GeneralBitFlags.StrongEncryption) == 0) {
				PkzipClassicManaged classicManaged = new PkzipClassicManaged();

				OnKeysRequired(entry.Name);
				if (HaveKeys == false) {
					throw new ZipException("No password available for encrypted stream");
				}

				result = new CryptoStream(baseStream, classicManaged.CreateEncryptor(key, iv), CryptoStreamMode.Write);
				if (entry.Crc < 0 || (entry.Flags & 8) != 0) {
					WriteEncryptionHeader(result, entry.DosTime << 16);
				}
				else {
					WriteEncryptionHeader(result, entry.Crc);
				}
			}
			return result;
		}

        /// <summary>
        /// Gets an output stream for the specified <see cref="ZipEntry" />
        /// </summary>
        /// <param name="entry">The entry to get an outputstream for.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>The output stream obtained for the entry.</returns>
        /// <exception cref="Zeroit.Framework.Utilities.IO.Compression.Zip.ZipException">Unknown compression method " + entry.CompressionMethod</exception>
        Stream GetOutputStream(ZipEntry entry, string fileName)
		{
			baseStream.Seek(0, SeekOrigin.End);
			Stream result = File.OpenWrite(fileName);
		
			if (entry.IsCrypted == true)
			{
				result = CreateAndInitEncryptionStream(result, entry);
			}
		
			switch (entry.CompressionMethod) 
			{
				case CompressionMethod.Stored:
					break;
		
				case CompressionMethod.Deflated:
					result = new DeflaterOutputStream(result);
					break;
					
				default:
					throw new ZipException("Unknown compression method " + entry.CompressionMethod);
			}
			return result;
		}

        /// <summary>
        /// Creates an input stream reading the given zip entry as
        /// uncompressed data.  Normally zip entry should be an entry
        /// returned by GetEntry().
        /// </summary>
        /// <param name="entry">The entry.</param>
        /// <returns>the input stream.</returns>
        /// <exception cref="InvalidOperationException">The ZipFile has already been closed</exception>
        /// <exception cref="IndexOutOfRangeException">The entry is not found in the ZipFile</exception>
        /// <exception cref="Zeroit.Framework.Utilities.IO.Compression.Zip.ZipException">The ZipFile has already been closed</exception>
        public Stream GetInputStream(ZipEntry entry)
		{
			if (entries == null) {
				throw new InvalidOperationException("ZipFile has closed");
			}
			
			int index = entry.ZipFileIndex;
			if (index < 0 || index >= entries.Length || entries[index].Name != entry.Name) {
				index = FindEntry(entry.Name, true);
				if (index < 0) {
					throw new IndexOutOfRangeException();
				}
			}
			return GetInputStream(index);			
		}

        /// <summary>
        /// Creates an input stream reading a zip entry
        /// </summary>
        /// <param name="entryIndex">The index of the entry to obtain an input stream for.</param>
        /// <returns>An input stream.</returns>
        /// <exception cref="InvalidOperationException">The ZipFile has already been closed</exception>
        /// <exception cref="Zeroit.Framework.Utilities.IO.Compression.Zip.ZipException">The compression method for the entry is unknown</exception>
        /// <exception cref="IndexOutOfRangeException">The ZipFile has already been closed</exception>
        public Stream GetInputStream(int entryIndex)
		{
			if (entries == null) {
				throw new InvalidOperationException("ZipFile has closed");
			}
			
			long start = CheckLocalHeader(entries[entryIndex]);
			CompressionMethod method = entries[entryIndex].CompressionMethod;
			Stream istr = new PartialInputStream(baseStream, start, entries[entryIndex].CompressedSize);

			if (entries[entryIndex].IsCrypted == true) {
				istr = CreateAndInitDecryptionStream(istr, entries[entryIndex]);
				if (istr == null) {
					throw new ZipException("Unable to decrypt this entry");
				}
			}

			switch (method) {
				case CompressionMethod.Stored:
					return istr;
				case CompressionMethod.Deflated:
					return new InflaterInputStream(istr, new Inflater(true));
				default:
					throw new ZipException("Unsupported compression method " + method);
			}
		}


        /// <summary>
        /// Gets the comment for the zip file.
        /// </summary>
        /// <value>The zip file comment.</value>
        public string ZipFileComment {
			get {
				return comment;
			}
		}

        /// <summary>
        /// Gets the name of this zip file.
        /// </summary>
        /// <value>The name.</value>
        public string Name {
			get {
				return name;
			}
		}

        /// <summary>
        /// Gets the number of entries in this zip file.
        /// </summary>
        /// <value>The size.</value>
        /// <exception cref="InvalidOperationException">The Zip file has been closed.</exception>
        public int Size {
			get {
				if (entries != null) {
					return entries.Length;
				} else {
					throw new InvalidOperationException("ZipFile is closed");
				}
			}
		}

        /// <summary>
        /// Class ZipEntryEnumeration.
        /// </summary>
        /// <seealso cref="System.Collections.IEnumerator" />
        class ZipEntryEnumeration : IEnumerator
		{
            /// <summary>
            /// The array
            /// </summary>
            ZipEntry[] array;
            /// <summary>
            /// The PTR
            /// </summary>
            int ptr = -1;

            /// <summary>
            /// Initializes a new instance of the <see cref="ZipEntryEnumeration"/> class.
            /// </summary>
            /// <param name="arr">The arr.</param>
            public ZipEntryEnumeration(ZipEntry[] arr)
			{
				array = arr;
			}

            /// <summary>
            /// Gets the current element in the collection.
            /// </summary>
            /// <value>The current.</value>
            public object Current {
				get {
					return array[ptr];
				}
			}

            /// <summary>
            /// Sets the enumerator to its initial position, which is before the first element in the collection.
            /// </summary>
            public void Reset()
			{
				ptr = -1;
			}

            /// <summary>
            /// Advances the enumerator to the next element of the collection.
            /// </summary>
            /// <returns>true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.</returns>
            public bool MoveNext() 
			{
				return (++ptr < array.Length);
			}
		}

        /// <summary>
        /// Class PartialInputStream.
        /// </summary>
        /// <seealso cref="Zeroit.Framework.Utilities.IO.Compression.Zip.Compression.Streams.InflaterInputStream" />
        class PartialInputStream : InflaterInputStream
		{
            /// <summary>
            /// The base stream
            /// </summary>
            Stream baseStream;
            /// <summary>
            /// The filepos
            /// </summary>
            long filepos, end;

            /// <summary>
            /// Initializes a new instance of the <see cref="PartialInputStream"/> class.
            /// </summary>
            /// <param name="baseStream">The base stream.</param>
            /// <param name="start">The start.</param>
            /// <param name="len">The length.</param>
            public PartialInputStream(Stream baseStream, long start, long len) : base(baseStream)
			{
				this.baseStream = baseStream;
				filepos = start;
				end = start + len;
			}

            /// <summary>
            /// Returns 0 once the end of the stream (EOF) has been reached.
            /// Otherwise returns 1.
            /// </summary>
            /// <value>The available.</value>
            public override int Available 
			{
				get {
					long amount = end - filepos;
					if (amount > Int32.MaxValue) {
						return Int32.MaxValue;
					}
					
					return (int) amount;
				}
			}

            /// <summary>
            /// Read a byte from this stream.
            /// </summary>
            /// <returns>Returns the byte read or -1 on end of stream.</returns>
            public override int ReadByte()
			{
				if (filepos == end) {
					return -1; //ok
				}
				
				lock(baseStream) {
					baseStream.Seek(filepos++, SeekOrigin.Begin);
					return baseStream.ReadByte();
				}
			}


            /// <summary>
            /// Close this partial input stream.
            /// </summary>
            /// <remarks>The underlying stream is not closed.  Close the parent ZipFile class to do that.</remarks>
            public override void Close()
			{
				// Do nothing at all!
			}

            /// <summary>
            /// Decompresses data into the byte array
            /// </summary>
            /// <param name="b">The array to read and decompress data into</param>
            /// <param name="off">The offset indicating where the data should be placed</param>
            /// <param name="len">The number of bytes to decompress</param>
            /// <returns>The number of bytes read.  Zero signals the end of stream</returns>
            public override int Read(byte[] b, int off, int len)
			{
				if (len > end - filepos) {
					len = (int) (end - filepos);
					if (len == 0) {
						return 0;
					}
				}
				
				lock(baseStream) {
					baseStream.Seek(filepos, SeekOrigin.Begin);
					int count = baseStream.Read(b, off, len);
					if (count > 0) {
						filepos += len;
					}
					return count;
				}
			}

            /// <summary>
            /// Skips the bytes.
            /// </summary>
            /// <param name="amount">The amount.</param>
            /// <returns>System.Int64.</returns>
            /// <exception cref="ArgumentOutOfRangeException"></exception>
            public long SkipBytes(long amount)
			{
				if (amount < 0) {
					throw new ArgumentOutOfRangeException();
				}
				if (amount > end - filepos) {
					amount = end - filepos;
				}
				filepos += amount;
				return amount;
			}
		}
	}
}
