// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="RangeCoder.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.IO.Compression.SevenZip.Compression.RangeCoder
{
    /// <summary>
    /// Class Encoder.
    /// </summary>
    class Encoder
	{
        /// <summary>
        /// The k top value
        /// </summary>
        public const uint kTopValue = (1 << 24);

        /// <summary>
        /// The stream
        /// </summary>
        System.IO.Stream Stream;

        /// <summary>
        /// The low
        /// </summary>
        public UInt64 Low;
        /// <summary>
        /// The range
        /// </summary>
        public uint Range;
        /// <summary>
        /// The cache size
        /// </summary>
        uint _cacheSize;
        /// <summary>
        /// The cache
        /// </summary>
        byte _cache;

        /// <summary>
        /// The start position
        /// </summary>
        long StartPosition;

        /// <summary>
        /// Sets the stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public void SetStream(System.IO.Stream stream)
		{
			Stream = stream;
		}

        /// <summary>
        /// Releases the stream.
        /// </summary>
        public void ReleaseStream()
		{
			Stream = null;
		}

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Init()
		{
			StartPosition = Stream.Position;

			Low = 0;
			Range = 0xFFFFFFFF;
			_cacheSize = 1;
			_cache = 0;
		}

        /// <summary>
        /// Flushes the data.
        /// </summary>
        public void FlushData()
		{
			for (int i = 0; i < 5; i++)
				ShiftLow();
		}

        /// <summary>
        /// Flushes the stream.
        /// </summary>
        public void FlushStream()
		{
			Stream.Flush();
		}

        /// <summary>
        /// Closes the stream.
        /// </summary>
        public void CloseStream()
		{
			Stream.Close();
		}

        /// <summary>
        /// Encodes the specified start.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="size">The size.</param>
        /// <param name="total">The total.</param>
        public void Encode(uint start, uint size, uint total)
		{
			Low += start * (Range /= total);
			Range *= size;
			while (Range < kTopValue)
			{
				Range <<= 8;
				ShiftLow();
			}
		}

        /// <summary>
        /// Shifts the low.
        /// </summary>
        public void ShiftLow()
		{
			if ((uint)Low < (uint)0xFF000000 || (uint)(Low >> 32) == 1)
			{
				byte temp = _cache;
				do
				{
					Stream.WriteByte((byte)(temp + (Low >> 32)));
					temp = 0xFF;
				}
				while (--_cacheSize != 0);
				_cache = (byte)(((uint)Low) >> 24);
			}
			_cacheSize++;
			Low = ((uint)Low) << 8;
		}

        /// <summary>
        /// Encodes the direct bits.
        /// </summary>
        /// <param name="v">The v.</param>
        /// <param name="numTotalBits">The number total bits.</param>
        public void EncodeDirectBits(uint v, int numTotalBits)
		{
			for (int i = numTotalBits - 1; i >= 0; i--)
			{
				Range >>= 1;
				if (((v >> i) & 1) == 1)
					Low += Range;
				if (Range < kTopValue)
				{
					Range <<= 8;
					ShiftLow();
				}
			}
		}

        /// <summary>
        /// Encodes the bit.
        /// </summary>
        /// <param name="size0">The size0.</param>
        /// <param name="numTotalBits">The number total bits.</param>
        /// <param name="symbol">The symbol.</param>
        public void EncodeBit(uint size0, int numTotalBits, uint symbol)
		{
			uint newBound = (Range >> numTotalBits) * size0;
			if (symbol == 0)
				Range = newBound;
			else
			{
				Low += newBound;
				Range -= newBound;
			}
			while (Range < kTopValue)
			{
				Range <<= 8;
				ShiftLow();
			}
		}

        /// <summary>
        /// Gets the processed size add.
        /// </summary>
        /// <returns>System.Int64.</returns>
        public long GetProcessedSizeAdd()
		{
			return _cacheSize +
				Stream.Position - StartPosition + 4;
			// (long)Stream.GetProcessedSize();
		}
	}

    /// <summary>
    /// Class Decoder.
    /// </summary>
    class Decoder
	{
        /// <summary>
        /// The k top value
        /// </summary>
        public const uint kTopValue = (1 << 24);
        /// <summary>
        /// The range
        /// </summary>
        public uint Range;
        /// <summary>
        /// The code
        /// </summary>
        public uint Code;
        // public Buffer.InBuffer Stream = new Buffer.InBuffer(1 << 16);
        /// <summary>
        /// The stream
        /// </summary>
        public System.IO.Stream Stream;

        /// <summary>
        /// Initializes the specified stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public void Init(System.IO.Stream stream)
		{
			// Stream.Init(stream);
			Stream = stream;

			Code = 0;
			Range = 0xFFFFFFFF;
			for (int i = 0; i < 5; i++)
				Code = (Code << 8) | (byte)Stream.ReadByte();
		}

        /// <summary>
        /// Releases the stream.
        /// </summary>
        public void ReleaseStream()
		{
			// Stream.ReleaseStream();
			Stream = null;
		}

        /// <summary>
        /// Closes the stream.
        /// </summary>
        public void CloseStream()
		{
			Stream.Close();
		}

        /// <summary>
        /// Normalizes this instance.
        /// </summary>
        public void Normalize()
		{
			while (Range < kTopValue)
			{
				Code = (Code << 8) | (byte)Stream.ReadByte();
				Range <<= 8;
			}
		}

        /// <summary>
        /// Normalize2s this instance.
        /// </summary>
        public void Normalize2()
		{
			if (Range < kTopValue)
			{
				Code = (Code << 8) | (byte)Stream.ReadByte();
				Range <<= 8;
			}
		}

        /// <summary>
        /// Gets the threshold.
        /// </summary>
        /// <param name="total">The total.</param>
        /// <returns>System.UInt32.</returns>
        public uint GetThreshold(uint total)
		{
			return Code / (Range /= total);
		}

        /// <summary>
        /// Decodes the specified start.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="size">The size.</param>
        /// <param name="total">The total.</param>
        public void Decode(uint start, uint size, uint total)
		{
			Code -= start * Range;
			Range *= size;
			Normalize();
		}

        /// <summary>
        /// Decodes the direct bits.
        /// </summary>
        /// <param name="numTotalBits">The number total bits.</param>
        /// <returns>System.UInt32.</returns>
        public uint DecodeDirectBits(int numTotalBits)
		{
			uint range = Range;
			uint code = Code;
			uint result = 0;
			for (int i = numTotalBits; i > 0; i--)
			{
				range >>= 1;
				/*
				result <<= 1;
				if (code >= range)
				{
					code -= range;
					result |= 1;
				}
				*/
				uint t = (code - range) >> 31;
				code -= range & (t - 1);
				result = (result << 1) | (1 - t);

				if (range < kTopValue)
				{
					code = (code << 8) | (byte)Stream.ReadByte();
					range <<= 8;
				}
			}
			Range = range;
			Code = code;
			return result;
		}

        /// <summary>
        /// Decodes the bit.
        /// </summary>
        /// <param name="size0">The size0.</param>
        /// <param name="numTotalBits">The number total bits.</param>
        /// <returns>System.UInt32.</returns>
        public uint DecodeBit(uint size0, int numTotalBits)
		{
			uint newBound = (Range >> numTotalBits) * size0;
			uint symbol;
			if (Code < newBound)
			{
				symbol = 0;
				Range = newBound;
			}
			else
			{
				symbol = 1;
				Code -= newBound;
				Range -= newBound;
			}
			Normalize();
			return symbol;
		}

		// ulong GetProcessedSize() {return Stream.GetProcessedSize(); }
	}
}
