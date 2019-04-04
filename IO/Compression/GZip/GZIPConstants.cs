// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="GZIPConstants.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.IO.Compression.GZip 
{

    /// <summary>
    /// This class contains constants used for gzip.
    /// </summary>
    public class GZipConstants
	{
        /// <summary>
        /// Magic number found at start of GZIP header
        /// </summary>
        public static readonly int GZIP_MAGIC = 0x1F8B;

        /*  The flag byte is divided into individual bits as follows:
			
			bit 0   FTEXT
			bit 1   FHCRC
			bit 2   FEXTRA
			bit 3   FNAME
			bit 4   FCOMMENT
			bit 5   reserved
			bit 6   reserved
			bit 7   reserved
		 */

        /// <summary>
        /// Flag bit mask for text
        /// </summary>
        public const int FTEXT    = 0x1;

        /// <summary>
        /// Flag bitmask for Crc
        /// </summary>
        public const int FHCRC    = 0x2;

        /// <summary>
        /// Flag bit mask for extra
        /// </summary>
        public const int FEXTRA   = 0x4;

        /// <summary>
        /// flag bitmask for name
        /// </summary>
        public const int FNAME    = 0x8;

        /// <summary>
        /// flag bit mask indicating comment is present
        /// </summary>
        public const int FCOMMENT = 0x10;

        /// <summary>
        /// Prevents a default instance of the <see cref="GZipConstants"/> class from being created.
        /// </summary>
        GZipConstants()
		{
		}
	}
}
