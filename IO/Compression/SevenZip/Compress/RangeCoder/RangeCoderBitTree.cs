// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="RangeCoderBitTree.cs" company="Zeroit Dev Technologies">
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
    /// Struct BitTreeEncoder
    /// </summary>
    struct BitTreeEncoder
	{
        /// <summary>
        /// The models
        /// </summary>
        BitEncoder[] Models;
        /// <summary>
        /// The number bit levels
        /// </summary>
        int NumBitLevels;

        /// <summary>
        /// Initializes a new instance of the <see cref="BitTreeEncoder"/> struct.
        /// </summary>
        /// <param name="numBitLevels">The number bit levels.</param>
        public BitTreeEncoder(int numBitLevels)
		{
			NumBitLevels = numBitLevels;
			Models = new BitEncoder[1 << numBitLevels];
		}

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Init()
		{
			for (uint i = 1; i < (1 << NumBitLevels); i++)
				Models[i].Init();
		}

        /// <summary>
        /// Encodes the specified range encoder.
        /// </summary>
        /// <param name="rangeEncoder">The range encoder.</param>
        /// <param name="symbol">The symbol.</param>
        public void Encode(Encoder rangeEncoder, UInt32 symbol)
		{
			UInt32 m = 1;
			for (int bitIndex = NumBitLevels; bitIndex > 0; )
			{
				bitIndex--;
				UInt32 bit = (symbol >> bitIndex) & 1;
				Models[m].Encode(rangeEncoder, bit);
				m = (m << 1) | bit;
			}
		}

        /// <summary>
        /// Reverses the encode.
        /// </summary>
        /// <param name="rangeEncoder">The range encoder.</param>
        /// <param name="symbol">The symbol.</param>
        public void ReverseEncode(Encoder rangeEncoder, UInt32 symbol)
		{
			UInt32 m = 1;
			for (UInt32 i = 0; i < NumBitLevels; i++)
			{
				UInt32 bit = symbol & 1;
				Models[m].Encode(rangeEncoder, bit);
				m = (m << 1) | bit;
				symbol >>= 1;
			}
		}

        /// <summary>
        /// Gets the price.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns>UInt32.</returns>
        public UInt32 GetPrice(UInt32 symbol)
		{
			UInt32 price = 0;
			UInt32 m = 1;
			for (int bitIndex = NumBitLevels; bitIndex > 0; )
			{
				bitIndex--;
				UInt32 bit = (symbol >> bitIndex) & 1;
				price += Models[m].GetPrice(bit);
				m = (m << 1) + bit;
			}
			return price;
		}

        /// <summary>
        /// Reverses the get price.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns>UInt32.</returns>
        public UInt32 ReverseGetPrice(UInt32 symbol)
		{
			UInt32 price = 0;
			UInt32 m = 1;
			for (int i = NumBitLevels; i > 0; i--)
			{
				UInt32 bit = symbol & 1;
				symbol >>= 1;
				price += Models[m].GetPrice(bit);
				m = (m << 1) | bit;
			}
			return price;
		}

        /// <summary>
        /// Reverses the get price.
        /// </summary>
        /// <param name="Models">The models.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="NumBitLevels">The number bit levels.</param>
        /// <param name="symbol">The symbol.</param>
        /// <returns>UInt32.</returns>
        public static UInt32 ReverseGetPrice(BitEncoder[] Models, UInt32 startIndex,
			int NumBitLevels, UInt32 symbol)
		{
			UInt32 price = 0;
			UInt32 m = 1;
			for (int i = NumBitLevels; i > 0; i--)
			{
				UInt32 bit = symbol & 1;
				symbol >>= 1;
				price += Models[startIndex + m].GetPrice(bit);
				m = (m << 1) | bit;
			}
			return price;
		}

        /// <summary>
        /// Reverses the encode.
        /// </summary>
        /// <param name="Models">The models.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="rangeEncoder">The range encoder.</param>
        /// <param name="NumBitLevels">The number bit levels.</param>
        /// <param name="symbol">The symbol.</param>
        public static void ReverseEncode(BitEncoder[] Models, UInt32 startIndex,
			Encoder rangeEncoder, int NumBitLevels, UInt32 symbol)
		{
			UInt32 m = 1;
			for (int i = 0; i < NumBitLevels; i++)
			{
				UInt32 bit = symbol & 1;
				Models[startIndex + m].Encode(rangeEncoder, bit);
				m = (m << 1) | bit;
				symbol >>= 1;
			}
		}
	}

    /// <summary>
    /// Struct BitTreeDecoder
    /// </summary>
    struct BitTreeDecoder
	{
        /// <summary>
        /// The models
        /// </summary>
        BitDecoder[] Models;
        /// <summary>
        /// The number bit levels
        /// </summary>
        int NumBitLevels;

        /// <summary>
        /// Initializes a new instance of the <see cref="BitTreeDecoder"/> struct.
        /// </summary>
        /// <param name="numBitLevels">The number bit levels.</param>
        public BitTreeDecoder(int numBitLevels)
		{
			NumBitLevels = numBitLevels;
			Models = new BitDecoder[1 << numBitLevels];
		}

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Init()
		{
			for (uint i = 1; i < (1 << NumBitLevels); i++)
				Models[i].Init();
		}

        /// <summary>
        /// Decodes the specified range decoder.
        /// </summary>
        /// <param name="rangeDecoder">The range decoder.</param>
        /// <returns>System.UInt32.</returns>
        public uint Decode(RangeCoder.Decoder rangeDecoder)
		{
			uint m = 1;
			for (int bitIndex = NumBitLevels; bitIndex > 0; bitIndex--)
				m = (m << 1) + Models[m].Decode(rangeDecoder);
			return m - ((uint)1 << NumBitLevels);
		}

        /// <summary>
        /// Reverses the decode.
        /// </summary>
        /// <param name="rangeDecoder">The range decoder.</param>
        /// <returns>System.UInt32.</returns>
        public uint ReverseDecode(RangeCoder.Decoder rangeDecoder)
		{
			uint m = 1;
			uint symbol = 0;
			for (int bitIndex = 0; bitIndex < NumBitLevels; bitIndex++)
			{
				uint bit = Models[m].Decode(rangeDecoder);
				m <<= 1;
				m += bit;
				symbol |= (bit << bitIndex);
			}
			return symbol;
		}

        /// <summary>
        /// Reverses the decode.
        /// </summary>
        /// <param name="Models">The models.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="rangeDecoder">The range decoder.</param>
        /// <param name="NumBitLevels">The number bit levels.</param>
        /// <returns>System.UInt32.</returns>
        public static uint ReverseDecode(BitDecoder[] Models, UInt32 startIndex,
			RangeCoder.Decoder rangeDecoder, int NumBitLevels)
		{
			uint m = 1;
			uint symbol = 0;
			for (int bitIndex = 0; bitIndex < NumBitLevels; bitIndex++)
			{
				uint bit = Models[startIndex + m].Decode(rangeDecoder);
				m <<= 1;
				m += bit;
				symbol |= (bit << bitIndex);
			}
			return symbol;
		}
	}
}
