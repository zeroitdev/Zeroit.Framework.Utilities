// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="TarHeader.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.IO.Compression.Tar 
{


    /// <summary>
    /// This class encapsulates the Tar Entry Header used in Tar Archives.
    /// The class also holds a number of tar constants, used mostly in headers.
    /// </summary>
    /// <seealso cref="System.ICloneable" />
    public class TarHeader : ICloneable
	{
        /// <summary>
        /// The length of the name field in a header buffer.
        /// </summary>
        public readonly static int NAMELEN = 100;

        /// <summary>
        /// The length of the mode field in a header buffer.
        /// </summary>
        public readonly static int MODELEN = 8;

        /// <summary>
        /// The length of the user id field in a header buffer.
        /// </summary>
        public readonly static int UIDLEN = 8;

        /// <summary>
        /// The length of the group id field in a header buffer.
        /// </summary>
        public readonly static int GIDLEN = 8;

        /// <summary>
        /// The length of the checksum field in a header buffer.
        /// </summary>
        public readonly static int CHKSUMLEN = 8;

        /// <summary>
        /// Offset of checksum in a header buffer.
        /// </summary>
        public const int CHKSUMOFS = 148;

        /// <summary>
        /// The length of the size field in a header buffer.
        /// </summary>
        public readonly static int SIZELEN = 12;

        /// <summary>
        /// The length of the magic field in a header buffer.
        /// </summary>
        public readonly static int MAGICLEN = 6;

        /// <summary>
        /// The length of the version field in a header buffer.
        /// </summary>
        public readonly static int VERSIONLEN = 2;

        /// <summary>
        /// The length of the modification time field in a header buffer.
        /// </summary>
        public readonly static int MODTIMELEN = 12;

        /// <summary>
        /// The length of the user name field in a header buffer.
        /// </summary>
        public readonly static int UNAMELEN = 32;

        /// <summary>
        /// The length of the group name field in a header buffer.
        /// </summary>
        public readonly static int GNAMELEN = 32;

        /// <summary>
        /// The length of the devices field in a header buffer.
        /// </summary>
        public readonly static int DEVLEN = 8;

        //
        // LF_ constants represent the "type" of an entry
        //

        /// <summary>
        /// The "old way" of indicating a normal file.
        /// </summary>
        public const byte	LF_OLDNORM	= 0;

        /// <summary>
        /// Normal file type.
        /// </summary>
        public const byte	LF_NORMAL	= (byte) '0';

        /// <summary>
        /// Link file type.
        /// </summary>
        public const byte	LF_LINK		= (byte) '1';

        /// <summary>
        /// Symbolic link file type.
        /// </summary>
        public const byte	LF_SYMLINK	= (byte) '2';

        /// <summary>
        /// Character device file type.
        /// </summary>
        public const byte	LF_CHR		= (byte) '3';

        /// <summary>
        /// Block device file type.
        /// </summary>
        public const byte	LF_BLK		= (byte) '4';

        /// <summary>
        /// Directory file type.
        /// </summary>
        public const byte	LF_DIR		= (byte) '5';

        /// <summary>
        /// FIFO (pipe) file type.
        /// </summary>
        public const byte	LF_FIFO		= (byte) '6';

        /// <summary>
        /// Contiguous file type.
        /// </summary>
        public const byte	LF_CONTIG	= (byte) '7';

        /// <summary>
        /// Posix.1 2001 global extended header
        /// </summary>
        public const byte   LF_GHDR    = (byte) 'g';

        /// <summary>
        /// Posix.1 2001 extended header
        /// </summary>
        public readonly static byte   LF_XHDR    = (byte) 'x';




        // POSIX allows for upper case ascii type as extensions

        /// <summary>
        /// Solaris access control list file type
        /// </summary>
        public const byte   LF_ACL            = (byte) 'A';

        /// <summary>
        /// GNU dir dump file type
        /// This is a dir entry that contains the names of files that were in the
        /// dir at the time the dump was made
        /// </summary>
        public const byte   LF_GNU_DUMPDIR    = (byte) 'D';

        /// <summary>
        /// Solaris Extended Attribute File
        /// </summary>
        public const byte   LF_EXTATTR        = (byte) 'E' ;

        /// <summary>
        /// Inode (metadata only) no file content
        /// </summary>
        public const byte   LF_META           = (byte) 'I';

        /// <summary>
        /// Identifies the next file on the tape as having a long link name
        /// </summary>
        public const byte   LF_GNU_LONGLINK   = (byte) 'K';

        /// <summary>
        /// Identifies the next file on the tape as having a long name
        /// </summary>
        public const byte   LF_GNU_LONGNAME   = (byte) 'L';

        /// <summary>
        /// Continuation of a file that began on another volume
        /// </summary>
        public const byte   LF_GNU_MULTIVOL   = (byte) 'M';

        /// <summary>
        /// For storing filenames that dont fit in the main header (old GNU)
        /// </summary>
        public const byte   LF_GNU_NAMES      = (byte) 'N';

        /// <summary>
        /// GNU Sparse file
        /// </summary>
        public const byte   LF_GNU_SPARSE     = (byte) 'S';

        /// <summary>
        /// GNU Tape/volume header ignore on extraction
        /// </summary>
        public const byte   LF_GNU_VOLHDR     = (byte) 'V';

        /// <summary>
        /// The magic tag representing a POSIX tar archive.  (includes trailing NULL)
        /// </summary>
        public readonly static string	TMAGIC		= "ustar ";

        /// <summary>
        /// The magic tag representing an old GNU tar archive where version is included in magic and overwrites it
        /// </summary>
        public readonly static string	GNU_TMAGIC	= "ustar  ";


        /// <summary>
        /// The name
        /// </summary>
        string name;

        /// <summary>
        /// Get/set the name for this tar entry.
        /// </summary>
        /// <value>The name.</value>
        /// <exception cref="ArgumentNullException">Thrown when attempting to set the property to null.</exception>
        public string Name
		{
			get { return name; }
			set { 
				if ( value == null ) {
					throw new ArgumentNullException();
				}
				name = value;	
			}
		}

        /// <summary>
        /// The mode
        /// </summary>
        int mode;

        /// <summary>
        /// Get/set the entry's Unix style permission mode.
        /// </summary>
        /// <value>The mode.</value>
        public int Mode
		{
			get { return mode; }
			set { mode = value; }
		}

        /// <summary>
        /// The user identifier
        /// </summary>
        int userId;

        /// <summary>
        /// The entry's user id.
        /// </summary>
        /// <value>The user identifier.</value>
        /// <remarks>This is only directly relevant to unix systems.
        /// The default is zero.</remarks>
        public int UserId
		{
			get { return userId; }
			set { userId = value; }
		}

        /// <summary>
        /// The group identifier
        /// </summary>
        int groupId;

        /// <summary>
        /// Get/set the entry's group id.
        /// </summary>
        /// <value>The group identifier.</value>
        /// <remarks>This is only directly relevant to linux/unix systems.
        /// The default value is zero.</remarks>
        public int GroupId
		{
			get { return groupId; }
			set { groupId = value; }
		}


        /// <summary>
        /// The size
        /// </summary>
        long size;

        /// <summary>
        /// Get/set the entry's size.
        /// </summary>
        /// <value>The size.</value>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when setting the size to less than zero.</exception>
        public long Size
		{
			get { return size; }
			set { 
				if ( value < 0 ) {
					throw new ArgumentOutOfRangeException();
				}
				size = value; 
			}
		}

        /// <summary>
        /// The mod time
        /// </summary>
        DateTime modTime;

        /// <summary>
        /// Get/set the entry's modification time.
        /// </summary>
        /// <value>The mod time.</value>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when setting the date time to less than 1/1/1970.</exception>
        /// <remarks>The modification time is only accurate to within a second.</remarks>
        public DateTime ModTime
		{
			get { return modTime; }
			set {
				if ( value < dateTime1970 )
				{
					throw new ArgumentOutOfRangeException();
				}
				modTime = new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, value.Second);
			}
		}

        /// <summary>
        /// The checksum
        /// </summary>
        int checksum;

        /// <summary>
        /// Get the entry's checksum.  This is only valid/updated after writing or reading an entry.
        /// </summary>
        /// <value>The checksum.</value>
        public int Checksum
		{
			get { return checksum; }
		}

        /// <summary>
        /// The is checksum valid
        /// </summary>
        bool isChecksumValid;

        /// <summary>
        /// Get value of true if the header checksum is valid, false otherwise.
        /// </summary>
        /// <value><c>true</c> if this instance is checksum valid; otherwise, <c>false</c>.</value>
        public bool IsChecksumValid
		{
			get { return isChecksumValid; }
		}

        /// <summary>
        /// The type flag
        /// </summary>
        byte typeFlag;

        /// <summary>
        /// Get/set the entry's type flag.
        /// </summary>
        /// <value>The type flag.</value>
        public byte TypeFlag
		{
			get { return typeFlag; }
			set { typeFlag = value; }
		}

        /// <summary>
        /// The link name
        /// </summary>
        string linkName;

        /// <summary>
        /// The entry's link name.
        /// </summary>
        /// <value>The name of the link.</value>
        /// <exception cref="ArgumentNullException">Thrown when attempting to set LinkName to null.</exception>
        public string LinkName
		{
			get { return linkName; }
			set {
				if ( value == null ) {
					throw new ArgumentNullException();
				}
				linkName = value; 
			}
		}

        /// <summary>
        /// The magic
        /// </summary>
        string magic;

        /// <summary>
        /// Get/set the entry's magic tag.
        /// </summary>
        /// <value>The magic.</value>
        /// <exception cref="ArgumentNullException">Thrown when attempting to set Magic to null.</exception>
        public string Magic
		{
			get { return magic; }
			set { 
				if ( value == null ) {
					throw new ArgumentNullException();
				}
				magic = value; 
			}
		}

        /// <summary>
        /// The version
        /// </summary>
        string version;

        /// <summary>
        /// The entry's version.
        /// </summary>
        /// <value>The version.</value>
        /// <exception cref="ArgumentNullException">Thrown when attempting to set Version to null.</exception>
        public string Version
		{
			get { return version; }
			set { 
				if ( value == null ) {
					throw new ArgumentNullException();
				}
				version = value; 
			}
		}

        /// <summary>
        /// The user name
        /// </summary>
        string userName;

        /// <summary>
        /// The entry's user name.
        /// </summary>
        /// <value>The name of the user.</value>
        /// <remarks>See <see cref="ResetValueDefaults">ResetValueDefaults</see>
        /// for detail on how this value is derived.</remarks>
        public string UserName
		{
			get { return userName; }
			set {
				if (value != null) {
					userName = value.Substring(0, Math.Min(UNAMELEN, value.Length));
				}
				else {
#if COMPACT_FRAMEWORK
					string currentUser = "PocketPC";
#else
					string currentUser = Environment.UserName;
#endif
					if (currentUser.Length > UNAMELEN) {
						currentUser = currentUser.Substring(0, UNAMELEN);
					}
					userName = currentUser;
				}
			}
		}

        /// <summary>
        /// The group name
        /// </summary>
        string groupName;

        /// <summary>
        /// Get/set the entry's group name.
        /// </summary>
        /// <value>The name of the group.</value>
        /// <remarks>This is only directly relevant to unix systems.</remarks>
        public string GroupName
		{
			get { return groupName; }
			set { 
				if ( value == null ) {
					groupName = "None";
				}
				else {
					groupName = value; 
				}
			}
		}

        /// <summary>
        /// The dev major
        /// </summary>
        int devMajor;

        /// <summary>
        /// Get/set the entry's major device number.
        /// </summary>
        /// <value>The dev major.</value>
        public int DevMajor
		{
			get { return devMajor; }
			set { devMajor = value; }
		}

        /// <summary>
        /// The dev minor
        /// </summary>
        int devMinor;

        /// <summary>
        /// Get/set the entry's minor device number.
        /// </summary>
        /// <value>The dev minor.</value>
        public int DevMinor
		{
			get { return devMinor; }
			set { devMinor = value; }
		}

        /// <summary>
        /// Initialise a default TarHeader instance
        /// </summary>
        public TarHeader()
		{
			this.Magic = TarHeader.TMAGIC;
			this.Version = " ";
			
			this.Name     = "";
			this.LinkName = "";
			
			this.UserId    = defaultUserId;
			this.GroupId   = defaultGroupId;
			this.UserName  = defaultUser;
			this.GroupName = defaultGroupName;
			this.Size      = 0;
		}

        // Values used during recursive operations.
        /// <summary>
        /// The user identifier as set
        /// </summary>
        static internal int userIdAsSet = 0;
        /// <summary>
        /// The group identifier as set
        /// </summary>
        static internal int groupIdAsSet = 0;
        /// <summary>
        /// The user name as set
        /// </summary>
        static internal string userNameAsSet = null;
        /// <summary>
        /// The group name as set
        /// </summary>
        static internal string groupNameAsSet = "None";

        /// <summary>
        /// The default user identifier
        /// </summary>
        static internal int defaultUserId = 0;
        /// <summary>
        /// The default group identifier
        /// </summary>
        static internal int defaultGroupId = 0;
        /// <summary>
        /// The default group name
        /// </summary>
        static internal string defaultGroupName = "None";
        /// <summary>
        /// The default user
        /// </summary>
        static internal string defaultUser = null;

        /// <summary>
        /// Restores the set values.
        /// </summary>
        static internal void RestoreSetValues()
		{
			defaultUserId = userIdAsSet;
			defaultUser = userNameAsSet;
			defaultGroupId = groupIdAsSet;
			defaultGroupName = groupNameAsSet;
		}

        /// <summary>
        /// Set defaults for values used when constructing a TarHeader instance.
        /// </summary>
        /// <param name="userId">Value to apply as a default for userId.</param>
        /// <param name="userName">Value to apply as a default for userName.</param>
        /// <param name="groupId">Value to apply as a default for groupId.</param>
        /// <param name="groupName">Value to apply as a default for groupName.</param>
        static public void SetValueDefaults(int userId, string userName, int groupId, string groupName)
		{
			defaultUserId = userIdAsSet = userId;
			defaultUser = userNameAsSet = userName;
			defaultGroupId = groupIdAsSet = groupId;
			defaultGroupName = groupNameAsSet = groupName;
		}

        /// <summary>
        /// Sets the active defaults.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="groupId">The group identifier.</param>
        /// <param name="groupName">Name of the group.</param>
        static internal void SetActiveDefaults(int userId, string userName, int groupId, string groupName)
		{
			defaultUserId = userId;
			defaultUser = userName;
			defaultGroupId = groupId;
			defaultGroupName = groupName;
		}

        /// <summary>
        /// Reset value defaults to initial values.
        /// </summary>
        /// <remarks>The default values are user id=0, group id=0, groupname="None", user name=null.
        /// When the default user name is null the value from Environment.UserName is used. Or "PocketPC" for the Compact framework.
        /// When the default group name is null the value "None" is used.</remarks>
        static public void ResetValueDefaults()
		{
			defaultUserId = 0;
			defaultGroupId = 0;
			defaultGroupName = "None";
			defaultUser = null;
		}

        /// <summary>
        /// Clone a TAR header.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone()
		{
			TarHeader hdr = new TarHeader();
			
			hdr.Name      = Name;
			hdr.Mode      = this.Mode;
			hdr.UserId    = this.UserId;
			hdr.GroupId   = this.GroupId;
			hdr.Size      = this.Size;
			hdr.ModTime   = this.ModTime;
			hdr.TypeFlag  = this.TypeFlag;
			hdr.LinkName  = this.LinkName;
			hdr.Magic     = this.Magic;
			hdr.Version   = this.Version;
			hdr.UserName  = this.UserName;
			hdr.GroupName = this.GroupName;
			hdr.DevMajor  = this.DevMajor;
			hdr.DevMinor  = this.DevMinor;
			
			return hdr;
		}
        /// <summary>
        /// Get a hash code for the current object.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
		{
			return Name.GetHashCode();
		}

        /// <summary>
        /// Determines if this instance is equal to the specified object.
        /// </summary>
        /// <param name="obj">The object to compare with.</param>
        /// <returns>true if the objects are equal, false otherwise.</returns>
        public override bool Equals(object obj)
		{
			if ( obj is TarHeader ) {
				TarHeader th = obj as TarHeader;
				return name == th.name
					&& mode == th.mode
					&& UserId == th.UserId
					&& GroupId == th.GroupId
					&& Size == th.Size
					&& ModTime == th.ModTime
					&& Checksum == th.Checksum
					&& TypeFlag == th.TypeFlag
					&& LinkName == th.LinkName
					&& Magic == th.Magic
					&& Version == th.Version
					&& UserName == th.UserName
					&& GroupName == th.GroupName
					&& DevMajor == th.DevMajor
					&& DevMinor == th.DevMinor;
			}
			else {
				return false;
			}
		}

        /// <summary>
        /// Get the name of this entry.
        /// </summary>
        /// <returns>The entry's name.</returns>
        /// <remarks>This is obsolete use the Name property instead.</remarks>
        [Obsolete]
		public string GetName()
		{
			return this.name.ToString();
		}

        /// <summary>
        /// Parse an octal string from a header buffer.
        /// </summary>
        /// <param name="header">The header buffer from which to parse.</param>
        /// <param name="offset">The offset into the buffer from which to parse.</param>
        /// <param name="length">The number of header bytes to parse.</param>
        /// <returns>The long equivalent of the octal string.</returns>
        public static long ParseOctal(byte[] header, int offset, int length)
		{
			long result = 0;
			bool stillPadding = true;
			
			int end = offset + length;
			for (int i = offset; i < end ; ++i) {
				if (header[i] == 0) {
					break;
				}
				
				if (header[i] == (byte)' ' || header[i] == '0') {
					if (stillPadding) {
						continue;
					}
					
					if (header[i] == (byte)' ') {
						break;
					}
				}
				
				stillPadding = false;
				
				result = (result << 3) + (header[i] - '0');
			}
			
			return result;
		}

        /// <summary>
        /// Parse a name from a header buffer.
        /// </summary>
        /// <param name="header">The header buffer from which to parse.</param>
        /// <param name="offset">The offset into the buffer from which to parse.</param>
        /// <param name="length">The number of header bytes to parse.</param>
        /// <returns>The name parsed.</returns>
        public static StringBuilder ParseName(byte[] header, int offset, int length)
		{
			StringBuilder result = new StringBuilder(length);
			
			for (int i = offset; i < offset + length; ++i) {
				if (header[i] == 0) {
					break;
				}
				result.Append((char)header[i]);
			}
			
			return result;
		}

        /// <summary>
        /// Add <paramref name="name">name</paramref> to the buffer as a collection of bytes
        /// </summary>
        /// <param name="name">The name to add</param>
        /// <param name="nameOffset">The offset of the first character</param>
        /// <param name="buf">The buffer to add to</param>
        /// <param name="bufferOffset">The index of the first byte to add</param>
        /// <param name="length">The number of characters/bytes to add</param>
        /// <returns>The next free index in the <paramref name="buf">buffer</paramref></returns>
        public static int GetNameBytes(StringBuilder name, int nameOffset, byte[] buf, int bufferOffset, int length)
		{
			return GetNameBytes(name.ToString(), nameOffset, buf, bufferOffset, length);
		}

        /// <summary>
        /// Add <paramref name="name">name</paramref> to the buffer as a collection of bytes
        /// </summary>
        /// <param name="name">The name to add</param>
        /// <param name="nameOffset">The offset of the first character</param>
        /// <param name="buf">The buffer to add to</param>
        /// <param name="bufferOffset">The index of the first byte to add</param>
        /// <param name="length">The number of characters/bytes to add</param>
        /// <returns>The next free index in the <paramref name="buf">buffer</paramref></returns>
        public static int GetNameBytes(string name, int nameOffset, byte[] buf, int bufferOffset, int length)
		{
			int i;
			
			for (i = 0 ; i < length - 1 && nameOffset + i < name.Length; ++i) {
				buf[bufferOffset + i] = (byte)name[nameOffset + i];
			}
			
			for (; i < length ; ++i) {
				buf[bufferOffset + i] = 0;
			}
			
			return bufferOffset + length;
		}

        /// <summary>
        /// Add an entry name to the buffer
        /// </summary>
        /// <param name="name">The name to add</param>
        /// <param name="buf">The buffer to add to</param>
        /// <param name="offset">The offset into the buffer from which to start adding</param>
        /// <param name="length">The number of header bytes to add</param>
        /// <returns>The index of the next free byte in the buffer</returns>
        public static int GetNameBytes(StringBuilder name, byte[] buf, int offset, int length)
		{
			return GetNameBytes(name.ToString(), 0, buf, offset, length);
		}

        /// <summary>
        /// Add an entry name to the buffer
        /// </summary>
        /// <param name="name">The name to add</param>
        /// <param name="buf">The buffer to add to</param>
        /// <param name="offset">The offset into the buffer from which to start adding</param>
        /// <param name="length">The number of header bytes to add</param>
        /// <returns>The index of the next free byte in the buffer</returns>
        public static int GetNameBytes(string name, byte[] buf, int offset, int length)
		{
			return GetNameBytes(name, 0, buf, offset, length);
		}

        /// <summary>
        /// Add a string to a buffer as a collection of ascii bytes.
        /// </summary>
        /// <param name="toAdd">The string to add</param>
        /// <param name="nameOffset">The offset of the first character to add.</param>
        /// <param name="buffer">The buffer to add to.</param>
        /// <param name="bufferOffset">The offset to start adding at.</param>
        /// <param name="length">The number of ascii characters to add.</param>
        /// <returns>The next free index in the buffer.</returns>
        public static int GetAsciiBytes(string toAdd, int nameOffset, byte[] buffer, int bufferOffset, int length )
		{
			for (int i = 0 ; i < length && nameOffset + i < toAdd.Length; ++i) 
		 	{
				buffer[bufferOffset + i] = (byte)toAdd[nameOffset + i];
		 	}
		 	return bufferOffset + length;
		}

        /// <summary>
        /// Put an octal representation of a value into a buffer
        /// </summary>
        /// <param name="val">the value to be converted to octal</param>
        /// <param name="buf">buffer to store the octal string</param>
        /// <param name="offset">The offset into the buffer where the value starts</param>
        /// <param name="length">The length of the octal string to create</param>
        /// <returns>The offset of the character next byte after the octal string</returns>
        public static int GetOctalBytes(long val, byte[] buf, int offset, int length)
		{
			int idx = length - 1;

			// Either a space or null is valid here.  We use NULL as per GNUTar
			buf[offset + idx] = 0;
			--idx;

			if (val > 0) {
				for (long v = val; idx >= 0 && v > 0; --idx) {
					buf[offset + idx] = (byte)((byte)'0' + (byte)(v & 7));
					v >>= 3;
				}
			}
				
			for (; idx >= 0; --idx) {
				buf[offset + idx] = (byte)'0';
			}
			
			return offset + length;
		}

        /// <summary>
        /// Put an octal representation of a value into a buffer
        /// </summary>
        /// <param name="val">Value to be convert to octal</param>
        /// <param name="buf">The buffer to update</param>
        /// <param name="offset">The offset into the buffer to store the value</param>
        /// <param name="length">The length of the octal string</param>
        /// <returns>Index of next byte</returns>
        public static int GetLongOctalBytes(long val, byte[] buf, int offset, int length)
		{
			return GetOctalBytes(val, buf, offset, length);
		}

        /// <summary>
        /// Add the checksum integer to header buffer.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <param name="buf">The header buffer to set the checksum for</param>
        /// <param name="offset">The offset into the buffer for the checksum</param>
        /// <param name="length">The number of header bytes to update.
        /// It's formatted differently from the other fields: it has 6 digits, a
        /// null, then a space -- rather than digits, a space, then a null.
        /// The final space is already there, from checksumming</param>
        /// <returns>The modified buffer offset</returns>
        private static int GetCheckSumOctalBytes(long val, byte[] buf, int offset, int length)
		{
			TarHeader.GetOctalBytes(val, buf, offset, length - 1);
			return offset + length;
		}

        /// <summary>
        /// Compute the checksum for a tar entry header.
        /// The checksum field must be all spaces prior to this happening
        /// </summary>
        /// <param name="buf">The tar entry's header buffer.</param>
        /// <returns>The computed checksum.</returns>
        private static int ComputeCheckSum(byte[] buf)
		{
			int sum = 0;
			for (int i = 0; i < buf.Length; ++i) {
				sum += buf[i];
			}
			return sum;
		}

        /// <summary>
        /// Make a checksum for a tar entry ignoring the checksum contents.
        /// </summary>
        /// <param name="buf">The tar entry's header buffer.</param>
        /// <returns>The checksum for the buffer</returns>
        private static int MakeCheckSum(byte[] buf)
		{
			int sum = 0;
			for ( int i = 0; i < CHKSUMOFS; ++i )
			{
				sum += buf[i];
			}
		
			for ( int i = 0; i < TarHeader.CHKSUMLEN; ++i)
			{
				sum += (byte)' ';
			}
		
			for (int i = CHKSUMOFS + CHKSUMLEN; i < buf.Length; ++i) 
			{
				sum += buf[i];
			}
			return sum;
		}


        /// <summary>
        /// The time conversion factor
        /// </summary>
        readonly static long     timeConversionFactor = 10000000L;           // 1 tick == 100 nanoseconds
                                                                             /// <summary>
                                                                             /// The date time1970
                                                                             /// </summary>
        readonly static DateTime dateTime1970        = new DateTime(1970, 1, 1, 0, 0, 0, 0);

        /// <summary>
        /// Gets the c time.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>System.Int32.</returns>
        static int GetCTime(System.DateTime dateTime)
		{
			return (int)((dateTime.Ticks - dateTime1970.Ticks) / timeConversionFactor);
		}

        /// <summary>
        /// Gets the date time from c time.
        /// </summary>
        /// <param name="ticks">The ticks.</param>
        /// <returns>DateTime.</returns>
        static DateTime GetDateTimeFromCTime(long ticks)
		{
			DateTime result;
			
			try {
				result = new DateTime(dateTime1970.Ticks + ticks * timeConversionFactor);
			}
			catch {
				result = dateTime1970;
			}
			return result;
		}

        /// <summary>
        /// Parse TarHeader information from a header buffer.
        /// </summary>
        /// <param name="header">The tar entry header buffer to get information from.</param>
        public void ParseBuffer(byte[] header)
		{
			int offset = 0;
			
			name = TarHeader.ParseName(header, offset, TarHeader.NAMELEN).ToString();
			offset += TarHeader.NAMELEN;
			
			mode = (int)TarHeader.ParseOctal(header, offset, TarHeader.MODELEN);
			offset += TarHeader.MODELEN;
			
			UserId = (int)TarHeader.ParseOctal(header, offset, TarHeader.UIDLEN);
			offset += TarHeader.UIDLEN;
			
			GroupId = (int)TarHeader.ParseOctal(header, offset, TarHeader.GIDLEN);
			offset += TarHeader.GIDLEN;
			
			Size = TarHeader.ParseOctal(header, offset, TarHeader.SIZELEN);
			offset += TarHeader.SIZELEN;
			
			ModTime = GetDateTimeFromCTime(TarHeader.ParseOctal(header, offset, TarHeader.MODTIMELEN));
			offset += TarHeader.MODTIMELEN;
			
			checksum = (int)TarHeader.ParseOctal(header, offset, TarHeader.CHKSUMLEN);
			offset += TarHeader.CHKSUMLEN;
			
			TypeFlag = header[ offset++ ];

			LinkName = TarHeader.ParseName(header, offset, TarHeader.NAMELEN).ToString();
			offset += TarHeader.NAMELEN;
			
			Magic = TarHeader.ParseName(header, offset, TarHeader.MAGICLEN).ToString();
			offset += TarHeader.MAGICLEN;
			
			Version = TarHeader.ParseName(header, offset, TarHeader.VERSIONLEN).ToString();
			offset += TarHeader.VERSIONLEN;
			
			UserName = TarHeader.ParseName(header, offset, TarHeader.UNAMELEN).ToString();
			offset += TarHeader.UNAMELEN;
			
			GroupName = TarHeader.ParseName(header, offset, TarHeader.GNAMELEN).ToString();
			offset += TarHeader.GNAMELEN;
			
			DevMajor = (int)TarHeader.ParseOctal(header, offset, TarHeader.DEVLEN);
			offset += TarHeader.DEVLEN;
			
			DevMinor = (int)TarHeader.ParseOctal(header, offset, TarHeader.DEVLEN);
			
			// Fields past this point not currently parsed or used...
			
			// TODO: prefix information.
			
			isChecksumValid = Checksum == TarHeader.MakeCheckSum(header);
		}

        /// <summary>
        /// 'Write' header information to buffer provided, updating the <see cref="Checksum">check sum</see>.
        /// </summary>
        /// <param name="outbuf">output buffer for header information</param>
        public void WriteHeader(byte[] outbuf)
		{
			int offset = 0;
			
			offset = GetNameBytes(this.Name, outbuf, offset, TarHeader.NAMELEN);
			offset = GetOctalBytes(this.mode, outbuf, offset, TarHeader.MODELEN);
			offset = GetOctalBytes(this.UserId, outbuf, offset, TarHeader.UIDLEN);
			offset = GetOctalBytes(this.GroupId, outbuf, offset, TarHeader.GIDLEN);
			
			long size = this.Size;
			
			offset = GetLongOctalBytes(size, outbuf, offset, TarHeader.SIZELEN);
			offset = GetLongOctalBytes(GetCTime(this.ModTime), outbuf, offset, TarHeader.MODTIMELEN);
			
			int csOffset = offset;
			for (int c = 0; c < TarHeader.CHKSUMLEN; ++c) {
				outbuf[offset++] = (byte)' ';
			}
			
			outbuf[offset++] = this.TypeFlag;
			
			offset = GetNameBytes(this.LinkName, outbuf, offset, NAMELEN);
			offset = GetAsciiBytes(this.Magic, 0, outbuf, offset, MAGICLEN);
			offset = GetNameBytes(this.Version, outbuf, offset, VERSIONLEN);
			offset = GetNameBytes(this.UserName, outbuf, offset, UNAMELEN);
			offset = GetNameBytes(this.GroupName, outbuf, offset, GNAMELEN);
			
			if (this.TypeFlag == LF_CHR || this.TypeFlag == LF_BLK) {
				offset = GetOctalBytes(this.DevMajor, outbuf, offset, DEVLEN);
				offset = GetOctalBytes(this.DevMinor, outbuf, offset, DEVLEN);
			}
			
			for ( ; offset < outbuf.Length; ) {
				outbuf[offset++] = 0;
			}
			
			checksum = ComputeCheckSum(outbuf);
			
			GetCheckSumOctalBytes(checksum, outbuf, csOffset, CHKSUMLEN);
			isChecksumValid = true;
		}
	}
}

/* The original Java file had this header:
 * 
** Authored by Timothy Gerard Endres
** <mailto:time@gjt.org>  <http://www.trustice.com>
** 
** This work has been placed into the public domain.
** You may use this work in any way and for any purpose you wish.
**
** THIS SOFTWARE IS PROVIDED AS-IS WITHOUT WARRANTY OF ANY KIND,
** NOT EVEN THE IMPLIED WARRANTY OF MERCHANTABILITY. THE AUTHOR
** OF THIS SOFTWARE, ASSUMES _NO_ RESPONSIBILITY FOR ANY
** CONSEQUENCE RESULTING FROM THE USE, MODIFICATION, OR
** REDISTRIBUTION OF THIS SOFTWARE. 
** 
*/
