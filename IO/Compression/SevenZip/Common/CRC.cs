
// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="CRC.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.IO.Compression.SevenZip
{
    /// <summary>
    /// Class CRC.
    /// </summary>
    class CRC
	{
        /// <summary>
        /// The table
        /// </summary>
        public static readonly uint[] Table;

        /// <summary>
        /// Initializes static members of the <see cref="CRC"/> class.
        /// </summary>
        static CRC()
		{
			Table = new uint[256];
			const uint kPoly = 0xEDB88320;
			for (uint i = 0; i < 256; i++)
			{
				uint r = i;
				for (int j = 0; j < 8; j++)
					if ((r & 1) != 0)
						r = (r >> 1) ^ kPoly;
					else
						r >>= 1;
				Table[i] = r;
			}
		}

        /// <summary>
        /// The value
        /// </summary>
        uint _value = 0xFFFFFFFF;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Init() { _value = 0xFFFFFFFF; }

        /// <summary>
        /// Updates the byte.
        /// </summary>
        /// <param name="b">The b.</param>
        public void UpdateByte(byte b)
		{
			_value = Table[(((byte)(_value)) ^ b)] ^ (_value >> 8);
		}

        /// <summary>
        /// Updates the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="size">The size.</param>
        public void Update(byte[] data, uint offset, uint size)
		{
			for (uint i = 0; i < size; i++)
				_value = Table[(((byte)(_value)) ^ data[offset + i])] ^ (_value >> 8);
		}

        /// <summary>
        /// Gets the digest.
        /// </summary>
        /// <returns>System.UInt32.</returns>
        public uint GetDigest() { return _value ^ 0xFFFFFFFF; }

        /// <summary>
        /// Calculates the digest.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="size">The size.</param>
        /// <returns>System.UInt32.</returns>
        static uint CalculateDigest(byte[] data, uint offset, uint size)
		{
			CRC crc = new CRC();
			// crc.Init();
			crc.Update(data, offset, size);
			return crc.GetDigest();
		}

        /// <summary>
        /// Verifies the digest.
        /// </summary>
        /// <param name="digest">The digest.</param>
        /// <param name="data">The data.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="size">The size.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        static bool VerifyDigest(uint digest, byte[] data, uint offset, uint size)
		{
			return (CalculateDigest(data, offset, size) == digest);
		}
	}
}
