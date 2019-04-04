// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="IChecksum.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.IO.Compression.Checksums 
{

    /// <summary>
    /// Interface to compute a data checksum used by checked input/output streams.
    /// A data checksum can be updated by one byte or with a byte array. After each
    /// update the value of the current checksum can be returned by calling
    /// <code>getValue</code>. The complete checksum object can also be reset
    /// so it can be used again with new data.
    /// </summary>
    public interface IChecksum
	{
        /// <summary>
        /// Returns the data checksum computed so far.
        /// </summary>
        /// <value>The value.</value>
        long Value 
		{
			get;
		}

        /// <summary>
        /// Resets the data checksum as if no update was ever called.
        /// </summary>
        void Reset();

        /// <summary>
        /// Adds one byte to the data checksum.
        /// </summary>
        /// <param name="bval">the data value to add. The high byte of the int is ignored.</param>
        void Update(int bval);

        /// <summary>
        /// Updates the data checksum with the bytes taken from the array.
        /// </summary>
        /// <param name="buffer">buffer an array of bytes</param>
        void Update(byte[] buffer);

        /// <summary>
        /// Adds the byte array to the data checksum.
        /// </summary>
        /// <param name="buf">the buffer which contains the data</param>
        /// <param name="off">the offset in the buffer where the data starts</param>
        /// <param name="len">the length of the data</param>
        void Update(byte[] buf, int off, int len);
	}
}
