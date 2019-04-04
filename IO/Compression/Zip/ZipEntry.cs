// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="ZipEntry.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.IO.Compression.Zip
{

    /// <summary>
    /// This class represents an entry in a zip archive.  This can be a file
    /// or a directory
    /// ZipFile and ZipInputStream will give you instances of this class as
    /// information about the members in an archive.  ZipOutputStream
    /// uses an instance of this class when creating an entry in a Zip file.
    /// <br /><br />Author of the original java version : Jochen Hoenicke
    /// </summary>
    /// <seealso cref="System.ICloneable" />
    public class ZipEntry : ICloneable
	{
        /// <summary>
        /// The known size
        /// </summary>
        static int KNOWN_SIZE               = 1;
        /// <summary>
        /// The known csize
        /// </summary>
        static int KNOWN_CSIZE              = 2;
        /// <summary>
        /// The known CRC
        /// </summary>
        static int KNOWN_CRC                = 4;
        /// <summary>
        /// The known time
        /// </summary>
        static int KNOWN_TIME               = 8;
        /// <summary>
        /// The known extern attributes
        /// </summary>
        static int KNOWN_EXTERN_ATTRIBUTES 	= 16;

        /// <summary>
        /// The known
        /// </summary>
        ushort known = 0;                       // Bit flags made up of above bits
                                                /// <summary>
                                                /// The external file attributes
                                                /// </summary>
        int externalFileAttributes = -1;     // contains external attributes (os dependant)

        /// <summary>
        /// The version made by
        /// </summary>
        ushort versionMadeBy;                   // Contains host system and version information
                                                // only relevant for central header entries

        /// <summary>
        /// The name
        /// </summary>
        string name;
        /// <summary>
        /// The size
        /// </summary>
        ulong size;
        /// <summary>
        /// The compressed size
        /// </summary>
        ulong compressedSize;
        /// <summary>
        /// The version to extract
        /// </summary>
        ushort versionToExtract;                // Version required to extract (library handles <= 2.0)
                                                /// <summary>
                                                /// The CRC
                                                /// </summary>
        uint crc;
        /// <summary>
        /// The dos time
        /// </summary>
        uint dosTime;

        /// <summary>
        /// The method
        /// </summary>
        CompressionMethod method = CompressionMethod.Deflated;
        /// <summary>
        /// The extra
        /// </summary>
        byte[] extra = null;
        /// <summary>
        /// The comment
        /// </summary>
        string comment = null;

        /// <summary>
        /// The flags
        /// </summary>
        int flags;                             // general purpose bit flags

        /// <summary>
        /// The zip file index
        /// </summary>
        int zipFileIndex = -1;                 // used by ZipFile
                                               /// <summary>
                                               /// The offset
                                               /// </summary>
        int offset;                            // used by ZipFile and ZipOutputStream

        /// <summary>
        /// Get/Set flag indicating if entry is encrypted.
        /// A simple helper routine to aid interpretation of <see cref="Flags">flags</see>
        /// </summary>
        /// <value><c>true</c> if this instance is crypted; otherwise, <c>false</c>.</value>
        public bool IsCrypted {
			get {
				return (flags & 1) != 0; 
			}
			set {
				if (value) {
					flags |= 1;
				} else {
					flags &= ~1;
				}
			}
		}

        /// <summary>
        /// Get/Set general purpose bit flag for entry
        /// </summary>
        /// <value>The flags.</value>
        /// <remarks>General purpose bit flag<br />
        /// Bit 0: If set, indicates the file is encrypted<br />
        /// Bit 1-2 Only used for compression type 6 Imploding, and 8, 9 deflating<br />
        /// Imploding:<br />
        /// Bit 1 if set indicates an 8K sliding dictionary was used.  If clear a 4k dictionary was used<br />
        /// Bit 2 if set indicates 3 Shannon-Fanno trees were used to encode the sliding dictionary, 2 otherwise<br /><br />
        /// Deflating:<br />
        /// Bit 2    Bit 1<br />
        /// 0        0       Normal compression was used<br />
        /// 0        1       Maximum compression was used<br />
        /// 1        0       Fast compression was used<br />
        /// 1        1       Super fast compression was used<br /><br />
        /// Bit 3: If set, the fields crc-32, compressed size
        /// and uncompressed size are were not able to be written during zip file creation
        /// The correct values are held in a data descriptor immediately following the compressed data. <br />
        /// Bit 4: Reserved for use by PKZIP for enhanced deflating<br />
        /// Bit 5: If set indicates the file contains compressed patch data<br />
        /// Bit 6: If set indicates strong encryption was used.<br />
        /// Bit 7-15: Unused or reserved<br /></remarks>
        public int Flags {
			get { 
				return flags; 
			}
			set {
				flags = value; 
			}
		}


        /// <summary>
        /// Get/Set index of this entry in Zip file
        /// </summary>
        /// <value>The index of the zip file.</value>
        public int ZipFileIndex {
			get {
				return zipFileIndex;
			}
			set {
				zipFileIndex = value;
			}
		}

        /// <summary>
        /// Get/set offset for use in central header
        /// </summary>
        /// <value>The offset.</value>
        /// <exception cref="ArgumentOutOfRangeException">Offset</exception>
        public int Offset {
			get {
				return offset;
			}
			set {
				if (((ulong)value & 0xFFFFFFFF00000000L) != 0) {
					throw new ArgumentOutOfRangeException("Offset");
				}
				offset = value;
			}
		}


        /// <summary>
        /// Get/Set external file attributes as an integer.
        /// The values of this are operating system dependant see
        /// <see cref="HostSystem">HostSystem</see> for details
        /// </summary>
        /// <value>The external file attributes.</value>
        public int ExternalFileAttributes {
			get {
				if ((known & KNOWN_EXTERN_ATTRIBUTES) == 0) {
					return -1;
				} else {
					return externalFileAttributes;
				}
			}
			
			set {
				externalFileAttributes = value;
				known |= (ushort)KNOWN_EXTERN_ATTRIBUTES;
			}
		}

        /// <summary>
        /// Get the version made by for this entry or zero if unknown.
        /// The value / 10 indicates the major version number, and
        /// the value mod 10 is the minor version number
        /// </summary>
        /// <value>The version made by.</value>
        public int VersionMadeBy {
			get { 
				return versionMadeBy & 0xff; 
			}
		}

        /// <summary>
        /// Gets the compatability information for the <see cref="ExternalFileAttributes">external file attribute</see>
        /// If the external file attributes are compatible with MS-DOS and can be read
        /// by PKZIP for DOS version 2.04g then this value will be zero.  Otherwise the value
        /// will be non-zero and identify the host system on which the attributes are compatible.
        /// </summary>
        /// <value>The host system.</value>
        /// <remarks>The values for this as defined in the Zip File format and by others are shown below.  The values are somewhat
        /// misleading in some cases as they are not all used as shown.  You should consult the relevant documentation
        /// to obtain up to date and correct information.  The modified appnote by the infozip group is
        /// particularly helpful as it documents a lot of peculiarities.  The document is however a little dated.
        /// <list type="table"><item>0 - MS-DOS and OS/2 (FAT / VFAT / FAT32 file systems)</item><item>1 - Amiga</item><item>2 - OpenVMS</item><item>3 - Unix</item><item>4 - VM/CMS</item><item>5 - Atari ST</item><item>6 - OS/2 HPFS</item><item>7 - Macintosh</item><item>8 - Z-System</item><item>9 - CP/M</item><item>10 - Windows NTFS</item><item>11 - MVS (OS/390 - Z/OS)</item><item>12 - VSE</item><item>13 - Acorn Risc</item><item>14 - VFAT</item><item>15 - Alternate MVS</item><item>16 - BeOS</item><item>17 - Tandem</item><item>18 - OS/400</item><item>19 - OS/X (Darwin)</item><item>99 - WinZip AES</item><item>remainder - unused</item></list></remarks>

        public int HostSystem {
			get { return (versionMadeBy >> 8) & 0xff; }
		}

        /// <summary>
        /// Creates a zip entry with the given name.
        /// </summary>
        /// <param name="name">The name for this entry. Can include directory components.
        /// The convention for names is 'unix'  style paths with no device names and
        /// path elements separated by '/' characters.  This is not enforced see <see cref="CleanName">CleanName</see>
        /// on how to ensure names are valid if this is desired.</param>
        /// <exception cref="ArgumentNullException">The name passed is null</exception>
        public ZipEntry(string name) : this(name, 0, ZipConstants.VERSION_MADE_BY)
		{
		}

        /// <summary>
        /// Creates a zip entry with the given name and version required to extract
        /// </summary>
        /// <param name="name">The name for this entry. Can include directory components.
        /// The convention for names is 'unix'  style paths with no device names and
        /// path elements separated by '/' characters.  This is not enforced see <see cref="CleanName">CleanName</see>
        /// on how to ensure names are valid if this is desired.</param>
        /// <param name="versionRequiredToExtract">The minimum 'feature version' required this entry</param>
        /// <exception cref="ArgumentNullException">The name passed is null</exception>
        internal ZipEntry(string name, int versionRequiredToExtract) : this(name, versionRequiredToExtract, ZipConstants.VERSION_MADE_BY)
		{
		}

        /// <summary>
        /// Initializes an entry with the given name and made by information
        /// </summary>
        /// <param name="name">Name for this entry</param>
        /// <param name="versionRequiredToExtract">Minimum required zip feature version required to extract this entry</param>
        /// <param name="madeByInfo">Version and HostSystem Information</param>
        /// <exception cref="System.ArgumentNullException">ZipEntry name</exception>
        /// <exception cref="ArgumentException">ZipEntry name is empty</exception>
        /// <exception cref="ArgumentOutOfRangeException">versionRequiredToExtract should be 0 (auto-calculate) or &gt; 10</exception>
        /// <exception cref="ArgumentNullException">The name passed is null</exception>
        /// <remarks>This constructor is used by the ZipFile class when reading from the central header
        /// It is not generally useful, use the constructor specifying the name only.</remarks>
        internal ZipEntry(string name, int versionRequiredToExtract, int madeByInfo)
		{
			if (name == null)  {
				throw new System.ArgumentNullException("ZipEntry name");
			}

			if ( name.Length == 0 ) {
				throw new ArgumentException("ZipEntry name is empty");
			}

			if (versionRequiredToExtract != 0 && versionRequiredToExtract < 10) {
				throw new ArgumentOutOfRangeException("versionRequiredToExtract");
			}
			
			this.DateTime         = System.DateTime.Now;
			this.name             = name;
			this.versionMadeBy    = (ushort)madeByInfo;
			this.versionToExtract = (ushort)versionRequiredToExtract;
		}

        /// <summary>
        /// Creates a copy of the given zip entry.
        /// </summary>
        /// <param name="e">The entry to copy.</param>
        public ZipEntry(ZipEntry e)
		{
			known                  = e.known;
			name                   = e.name;
			size                   = e.size;
			compressedSize         = e.compressedSize;
			crc                    = e.crc;
			dosTime                = e.dosTime;
			method                 = e.method;
			ExtraData              = e.ExtraData;     // Note use of property ensuring data is unique
			comment                = e.comment;
			versionToExtract       = e.versionToExtract;
			versionMadeBy          = e.versionMadeBy;
			externalFileAttributes = e.externalFileAttributes;
			flags                  = e.flags;

			zipFileIndex           = -1;
			offset                 = 0;
		}

        /// <summary>
        /// Get minimum Zip feature version required to extract this entry
        /// </summary>
        /// <value>The version.</value>
        /// <remarks>Minimum features are defined as:<br />
        /// 1.0 - Default value<br />
        /// 1.1 - File is a volume label<br />
        /// 2.0 - File is a folder/directory<br />
        /// 2.0 - File is compressed using Deflate compression<br />
        /// 2.0 - File is encrypted using traditional encryption<br />
        /// 2.1 - File is compressed using Deflate64<br />
        /// 2.5 - File is compressed using PKWARE DCL Implode<br />
        /// 2.7 - File is a patch data set<br />
        /// 4.5 - File uses Zip64 format extensions<br />
        /// 4.6 - File is compressed using BZIP2 compression<br />
        /// 5.0 - File is encrypted using DES<br />
        /// 5.0 - File is encrypted using 3DES<br />
        /// 5.0 - File is encrypted using original RC2 encryption<br />
        /// 5.0 - File is encrypted using RC4 encryption<br />
        /// 5.1 - File is encrypted using AES encryption<br />
        /// 5.1 - File is encrypted using corrected RC2 encryption<br />
        /// 5.1 - File is encrypted using corrected RC2-64 encryption<br />
        /// 6.1 - File is encrypted using non-OAEP key wrapping<br />
        /// 6.2 - Central directory encryption (not confirmed yet)<br /></remarks>
        public int Version {
			get {
				if (versionToExtract != 0) {
					return versionToExtract;
				} else {
					int result = 10;
					if (CompressionMethod.Deflated == method) {
						result = 20;
					} else if (IsDirectory == true) {
						result = 20;
					} else if (IsCrypted == true) {
						result = 20;
					} else if ((known & KNOWN_EXTERN_ATTRIBUTES) != 0 && (externalFileAttributes & 0x08) != 0) {
						result = 11;
					}
					return result;
				}
			}
		}

        /// <summary>
        /// Gets a value indicating if the entry requires Zip64 extensions to be stored
        /// </summary>
        /// <value><c>true</c> if [requires zip64]; otherwise, <c>false</c>.</value>
        public bool RequiresZip64 {
			get {
				return (this.size > uint.MaxValue) || (this.compressedSize > uint.MaxValue);
			}
		}

        /// <summary>
        /// Get/Set DosTime
        /// </summary>
        /// <value>The dos time.</value>
        public long DosTime {
			get {
				if ((known & KNOWN_TIME) == 0) {
					return 0;
				} else {
					return dosTime;
				}
			}
			set {
				this.dosTime = (uint)value;
				known |= (ushort)KNOWN_TIME;
			}
		}


        /// <summary>
        /// Gets/Sets the time of last modification of the entry.
        /// </summary>
        /// <value>The date time.</value>
        public DateTime DateTime {
			get {
				// Although technically not valid some archives have dates set to zero.
				// This mimics some archivers handling and is a good a cludge as any probably.
				if ( dosTime == 0 ) {
					return DateTime.Now;
				}
				else {
					uint sec  = 2 * (dosTime & 0x1f);
					uint min  = (dosTime >> 5) & 0x3f;
					uint hrs  = (dosTime >> 11) & 0x1f;
					uint day  = (dosTime >> 16) & 0x1f;
					uint mon  = ((dosTime >> 21) & 0xf);
					uint year = ((dosTime >> 25) & 0x7f) + 1980;
					return new System.DateTime((int)year, (int)mon, (int)day, (int)hrs, (int)min, (int)sec);
				}
			}
			set {
				DosTime = ((uint)value.Year - 1980 & 0x7f) << 25 | 
				          ((uint)value.Month) << 21 |
				          ((uint)value.Day) << 16 |
				          ((uint)value.Hour) << 11 |
				          ((uint)value.Minute) << 5 |
				          ((uint)value.Second) >> 1;
			}
		}

        /// <summary>
        /// Returns the entry name.  The path components in the entry should
        /// always separated by slashes ('/').  Dos device names like C: should also
        /// be removed.  See <see cref="CleanName">CleanName</see>.
        /// </summary>
        /// <value>The name.</value>
        public string Name {
			get {
				return name;
			}
		}

        /// <summary>
        /// Cleans a name making it conform to Zip file conventions.
        /// Devices names ('c:\') and UNC share names ('\\server\share') are removed
        /// and forward slashes ('\') are converted to back slashes ('/').
        /// </summary>
        /// <param name="name">Name to clean</param>
        /// <param name="relativePath">Make names relative if true or absolute if false</param>
        /// <returns>System.String.</returns>
        static public string CleanName(string name, bool relativePath)
		{
			if (name == null) {
				return "";
			}
			
			if (Path.IsPathRooted(name) == true) {
				// NOTE:
				// for UNC names...  \\machine\share\zoom\beet.txt gives \zoom\beet.txt
				name = name.Substring(Path.GetPathRoot(name).Length);
			}

			name = name.Replace(@"\", "/");
			
			if (relativePath == true) {
				if (name.Length > 0 && (name[0] == Path.AltDirectorySeparatorChar || name[0] == Path.DirectorySeparatorChar)) {
					name = name.Remove(0, 1);
				}
			} else {
				if (name.Length > 0 && name[0] != Path.AltDirectorySeparatorChar && name[0] != Path.DirectorySeparatorChar) {
					name = name.Insert(0, "/");
				}
			}
			return name;
		}

        /// <summary>
        /// Cleans a name making it conform to Zip file conventions.
        /// Devices names ('c:\') and UNC share names ('\\server\share') are removed
        /// and forward slashes ('\') are converted to back slashes ('/').
        /// Names are made relative by trimming leading slashes which is compatible
        /// with Windows-XPs built in Zip file handling.
        /// </summary>
        /// <param name="name">Name to clean</param>
        /// <returns>System.String.</returns>
        static public string CleanName(string name)
		{
			return CleanName(name, true);
		}

        /// <summary>
        /// Gets/Sets the size of the uncompressed data.
        /// </summary>
        /// <value>The size.</value>
        /// <exception cref="ArgumentOutOfRangeException">size</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">If the size is not in the range 0..0xffffffffL</exception>
        public long Size {
			get {
				return (known & KNOWN_SIZE) != 0 ? (long)size : -1L;
			}
			set {
				if (((ulong)value & 0xFFFFFFFF00000000L) != 0) {
					throw new ArgumentOutOfRangeException("size");
				}
				this.size  = (ulong)value;
				this.known |= (ushort)KNOWN_SIZE;
			}
		}

        /// <summary>
        /// Gets/Sets the size of the compressed data.
        /// </summary>
        /// <value>The size of the compressed.</value>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Size is not in the range 0..0xffffffff</exception>
        public long CompressedSize {
			get {
				return (known & KNOWN_CSIZE) != 0 ? (long)compressedSize : -1L;
			}
			set {
				if (((ulong)value & 0xffffffff00000000L) != 0) {
					throw new ArgumentOutOfRangeException();
				}
				this.compressedSize = (ulong)value;
				this.known |= (ushort)KNOWN_CSIZE;
			}
		}

        /// <summary>
        /// Gets/Sets the crc of the uncompressed data.
        /// </summary>
        /// <value>The CRC.</value>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Crc is not in the range 0..0xffffffffL</exception>
        public long Crc {
			get {
				return (known & KNOWN_CRC) != 0 ? crc & 0xffffffffL : -1L;
			}
			set {
				if (((ulong)crc & 0xffffffff00000000L) != 0) {
					throw new ArgumentOutOfRangeException();
				}
				this.crc = (uint)value;
				this.known |= (ushort)KNOWN_CRC;
			}
		}

        /// <summary>
        /// Gets/Sets the compression method. Only Deflated and Stored are supported.
        /// </summary>
        /// <value>The compression method.</value>
        /// <see cref="Zeroit.Framework.Utilities.IO.Compression.Zip.CompressionMethod.Deflated" />
        /// <see cref="Zeroit.Framework.Utilities.IO.Compression.Zip.CompressionMethod.Stored" />
        public CompressionMethod CompressionMethod {
			get {
				return method;
			}
			set {
				this.method = value;
			}
		}

        /// <summary>
        /// Gets/Sets the extra data.
        /// </summary>
        /// <value>The extra data.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Extra data is longer than 0xffff bytes.</exception>
        public byte[] ExtraData {
			get {
				return extra;
			}
			set {
				if (value == null) {
					this.extra = null;
					return;
				}
				
				if (value.Length > 0xffff) {
					throw new System.ArgumentOutOfRangeException();
				}
				
				this.extra = new byte[value.Length];
				Array.Copy(value, 0, this.extra, 0, value.Length);
				
				try {
					int pos = 0;
					while (pos < extra.Length) {
						int sig = (extra[pos++] & 0xff) | (extra[pos++] & 0xff) << 8;
						int len = (extra[pos++] & 0xff) | (extra[pos++] & 0xff) << 8;
						
						if (len < 0 || pos + len > extra.Length) {
							// This is still lenient but the extra data is corrupt
							// TODO: drop the extra data? or somehow indicate to user 
							// there is a problem...
							break;
						}
						
						if (sig == 0x5455) {
							// extended time stamp, unix format by Rainer Prem <Rainer@Prem.de>
							int flags = extra[pos];
							// Can include other times but these are ignored.  Length of data should
							// actually be 1 + 4 * no of bits in flags.
							if ((flags & 1) != 0 && len >= 5) {
								int iTime = ((extra[pos+1] & 0xff) |
									(extra[pos + 2] & 0xff) << 8 |
									(extra[pos + 3] & 0xff) << 16 |
									(extra[pos + 4] & 0xff) << 24);
								
								DateTime = (new DateTime ( 1970, 1, 1, 0, 0, 0 ) + new TimeSpan ( 0, 0, 0, iTime, 0 )).ToLocalTime ();
								known |= (ushort)KNOWN_TIME;
							}
						} else if (sig == 0x0001) { 
							// ZIP64 extended information extra field
							// Of variable size depending on which fields in header are too small
							// fields appear here if the corresponding local or central directory record field
							// is set to 0xFFFF or 0xFFFFFFFF and the entry is in Zip64 format.
							//
							// Original Size          8 bytes
							// Compressed size        8 bytes
							// Relative header offset 8 bytes
							// Disk start number      4 bytes
						}
						pos += len;
					}
				} catch (Exception) {
					/* be lenient */
					return;
				}
			}
		}


        /// <summary>
        /// Gets/Sets the entry comment.
        /// </summary>
        /// <value>The comment.</value>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="System.ArgumentOutOfRangeException">If comment is longer than 0xffff.</exception>
        public string Comment {
			get {
				return comment;
			}
			set {
				// TODO: this test is strictly incorrect as the length is in characters
				// While the test is correct in that a comment of this length or greater 
				// is definitely invalid, shorter comments may also have an invalid length.
				if (value != null && value.Length > 0xffff) {
					throw new ArgumentOutOfRangeException();
				}
				this.comment = value;
			}
		}

        /// <summary>
        /// Gets a value indicating of the if the entry is a directory.  A directory is determined by
        /// an entry name with a trailing slash '/'.  The external file attributes
        /// can also mark a file as a directory.  The trailing slash convention should always be followed
        /// however.
        /// </summary>
        /// <value><c>true</c> if this instance is directory; otherwise, <c>false</c>.</value>
        public bool IsDirectory {
			get {
				int nlen = name.Length;
				bool result = nlen > 0 && name[nlen - 1] == '/';
				
				if (result == false && (known & KNOWN_EXTERN_ATTRIBUTES) != 0) {
					if (HostSystem == 0 && (ExternalFileAttributes & 16) != 0) {
						result = true;
					}
				}
				return result;
			}
		}

        /// <summary>
        /// Get a value of true if the entry appears to be a file; false otherwise
        /// </summary>
        /// <value><c>true</c> if this instance is file; otherwise, <c>false</c>.</value>
        /// <remarks>This only takes account Windows attributes.  Other operating systems are ignored.
        /// For linux and others the result may be incorrect.</remarks>
        public bool IsFile {
			get {
				bool result = !IsDirectory;

				// Exclude volume labels
				if ( result && (known & KNOWN_EXTERN_ATTRIBUTES) != 0) {
					if (HostSystem == 0 && (ExternalFileAttributes & 8) != 0) {
						result = false;
					}
				}
				return result;
			}
		}

        /// <summary>
        /// Creates a copy of this zip entry.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone()
		{
			return this.MemberwiseClone();
		}

        /// <summary>
        /// Gets the string representation of this ZipEntry.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
		{
			return name;
		}
	}
}
