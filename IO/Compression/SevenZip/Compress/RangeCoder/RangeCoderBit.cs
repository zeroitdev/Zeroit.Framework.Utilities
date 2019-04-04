// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="RangeCoderBit.cs" company="Zeroit Dev Technologies">
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
    /// Struct BitEncoder
    /// </summary>
    struct BitEncoder
	{
        /// <summary>
        /// The k number bit model total bits
        /// </summary>
        public const int kNumBitModelTotalBits = 11;
        /// <summary>
        /// The k bit model total
        /// </summary>
        public const uint kBitModelTotal = (1 << kNumBitModelTotalBits);
        /// <summary>
        /// The k number move bits
        /// </summary>
        const int kNumMoveBits = 5;
        /// <summary>
        /// The k number move reducing bits
        /// </summary>
        const int kNumMoveReducingBits = 2;
        /// <summary>
        /// The k number bit price shift bits
        /// </summary>
        public const int kNumBitPriceShiftBits = 6;

        /// <summary>
        /// The prob
        /// </summary>
        uint Prob;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Init() { Prob = kBitModelTotal >> 1; }

        /// <summary>
        /// Updates the model.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        public void UpdateModel(uint symbol)
		{
			if (symbol == 0)
				Prob += (kBitModelTotal - Prob) >> kNumMoveBits;
			else
				Prob -= (Prob) >> kNumMoveBits;
		}

        /// <summary>
        /// Encodes the specified encoder.
        /// </summary>
        /// <param name="encoder">The encoder.</param>
        /// <param name="symbol">The symbol.</param>
        public void Encode(Encoder encoder, uint symbol)
		{
			// encoder.EncodeBit(Prob, kNumBitModelTotalBits, symbol);
			// UpdateModel(symbol);
			uint newBound = (encoder.Range >> kNumBitModelTotalBits) * Prob;
			if (symbol == 0)
			{
				encoder.Range = newBound;
				Prob += (kBitModelTotal - Prob) >> kNumMoveBits;
			}
			else
			{
				encoder.Low += newBound;
				encoder.Range -= newBound;
				Prob -= (Prob) >> kNumMoveBits;
			}
			if (encoder.Range < Encoder.kTopValue)
			{
				encoder.Range <<= 8;
				encoder.ShiftLow();
			}
		}

        /// <summary>
        /// The prob prices
        /// </summary>
        private static UInt32[] ProbPrices = new UInt32[kBitModelTotal >> kNumMoveReducingBits];

        /// <summary>
        /// Initializes static members of the <see cref="BitEncoder"/> struct.
        /// </summary>
        static BitEncoder()
		{
			const int kNumBits = (kNumBitModelTotalBits - kNumMoveReducingBits);
			for (int i = kNumBits - 1; i >= 0; i--)
			{
				UInt32 start = (UInt32)1 << (kNumBits - i - 1);
				UInt32 end = (UInt32)1 << (kNumBits - i);
				for (UInt32 j = start; j < end; j++)
					ProbPrices[j] = ((UInt32)i << kNumBitPriceShiftBits) +
						(((end - j) << kNumBitPriceShiftBits) >> (kNumBits - i - 1));
			}
		}

        /// <summary>
        /// Gets the price.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns>System.UInt32.</returns>
        public uint GetPrice(uint symbol)
		{
			return ProbPrices[(((Prob - symbol) ^ ((-(int)symbol))) & (kBitModelTotal - 1)) >> kNumMoveReducingBits];
		}
        /// <summary>
        /// Gets the price0.
        /// </summary>
        /// <returns>System.UInt32.</returns>
        public uint GetPrice0() { return ProbPrices[Prob >> kNumMoveReducingBits]; }
        /// <summary>
        /// Gets the price1.
        /// </summary>
        /// <returns>System.UInt32.</returns>
        public uint GetPrice1() { return ProbPrices[(kBitModelTotal - Prob) >> kNumMoveReducingBits]; }
	}

    /// <summary>
    /// Struct BitDecoder
    /// </summary>
    struct BitDecoder
	{
        /// <summary>
        /// The k number bit model total bits
        /// </summary>
        public const int kNumBitModelTotalBits = 11;
        /// <summary>
        /// The k bit model total
        /// </summary>
        public const uint kBitModelTotal = (1 << kNumBitModelTotalBits);
        /// <summary>
        /// The k number move bits
        /// </summary>
        const int kNumMoveBits = 5;

        /// <summary>
        /// The prob
        /// </summary>
        uint Prob;

        /// <summary>
        /// Updates the model.
        /// </summary>
        /// <param name="numMoveBits">The number move bits.</param>
        /// <param name="symbol">The symbol.</param>
        public void UpdateModel(int numMoveBits, uint symbol)
		{
			if (symbol == 0)
				Prob += (kBitModelTotal - Prob) >> numMoveBits;
			else
				Prob -= (Prob) >> numMoveBits;
		}

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Init() { Prob = kBitModelTotal >> 1; }

        /// <summary>
        /// Decodes the specified range decoder.
        /// </summary>
        /// <param name="rangeDecoder">The range decoder.</param>
        /// <returns>System.UInt32.</returns>
        public uint Decode(RangeCoder.Decoder rangeDecoder)
		{
			uint newBound = (uint)(rangeDecoder.Range >> kNumBitModelTotalBits) * (uint)Prob;
			if (rangeDecoder.Code < newBound)
			{
				rangeDecoder.Range = newBound;
				Prob += (kBitModelTotal - Prob) >> kNumMoveBits;
				if (rangeDecoder.Range < Decoder.kTopValue)
				{
					rangeDecoder.Code = (rangeDecoder.Code << 8) | (byte)rangeDecoder.Stream.ReadByte();
					rangeDecoder.Range <<= 8;
				}
				return 0;
			}
			else
			{
				rangeDecoder.Range -= newBound;
				rangeDecoder.Code -= newBound;
				Prob -= (Prob) >> kNumMoveBits;
				if (rangeDecoder.Range < Decoder.kTopValue)
				{
					rangeDecoder.Code = (rangeDecoder.Code << 8) | (byte)rangeDecoder.Stream.ReadByte();
					rangeDecoder.Range <<= 8;
				}
				return 1;
			}
		}
	}
}
