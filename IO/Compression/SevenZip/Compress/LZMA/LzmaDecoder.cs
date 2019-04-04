// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-22-2018
// ***********************************************************************
// <copyright file="LzmaDecoder.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.IO.Compression.SevenZip.Compression.LZMA
{
	using RangeCoder;

    /// <summary>
    /// Class Decoder.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.IO.Compression.SevenZip.ICoder" />
    /// <seealso cref="Zeroit.Framework.Utilities.IO.Compression.SevenZip.ISetDecoderProperties" />
    public class Decoder : ICoder, ISetDecoderProperties // ,System.IO.Stream
	{
        /// <summary>
        /// Class LenDecoder.
        /// </summary>
        class LenDecoder
		{
            /// <summary>
            /// The m choice
            /// </summary>
            BitDecoder m_Choice = new BitDecoder();
            /// <summary>
            /// The m choice2
            /// </summary>
            BitDecoder m_Choice2 = new BitDecoder();
            /// <summary>
            /// The m low coder
            /// </summary>
            BitTreeDecoder[] m_LowCoder = new BitTreeDecoder[Base.kNumPosStatesMax];
            /// <summary>
            /// The m mid coder
            /// </summary>
            BitTreeDecoder[] m_MidCoder = new BitTreeDecoder[Base.kNumPosStatesMax];
            /// <summary>
            /// The m high coder
            /// </summary>
            BitTreeDecoder m_HighCoder = new BitTreeDecoder(Base.kNumHighLenBits);
            /// <summary>
            /// The m number position states
            /// </summary>
            uint m_NumPosStates = 0;

            /// <summary>
            /// Creates the specified number position states.
            /// </summary>
            /// <param name="numPosStates">The number position states.</param>
            public void Create(uint numPosStates)
			{
				for (uint posState = m_NumPosStates; posState < numPosStates; posState++)
				{
					m_LowCoder[posState] = new BitTreeDecoder(Base.kNumLowLenBits);
					m_MidCoder[posState] = new BitTreeDecoder(Base.kNumMidLenBits);
				}
				m_NumPosStates = numPosStates;
			}

            /// <summary>
            /// Initializes this instance.
            /// </summary>
            public void Init()
			{
				m_Choice.Init();
				for (uint posState = 0; posState < m_NumPosStates; posState++)
				{
					m_LowCoder[posState].Init();
					m_MidCoder[posState].Init();
				}
				m_Choice2.Init();
				m_HighCoder.Init();
			}

            /// <summary>
            /// Decodes the specified range decoder.
            /// </summary>
            /// <param name="rangeDecoder">The range decoder.</param>
            /// <param name="posState">State of the position.</param>
            /// <returns>System.UInt32.</returns>
            public uint Decode(RangeCoder.Decoder rangeDecoder, uint posState)
			{
				if (m_Choice.Decode(rangeDecoder) == 0)
					return m_LowCoder[posState].Decode(rangeDecoder);
				else
				{
					uint symbol = Base.kNumLowLenSymbols;
					if (m_Choice2.Decode(rangeDecoder) == 0)
						symbol += m_MidCoder[posState].Decode(rangeDecoder);
					else
					{
						symbol += Base.kNumMidLenSymbols;
						symbol += m_HighCoder.Decode(rangeDecoder);
					}
					return symbol;
				}
			}
		}

        /// <summary>
        /// Class LiteralDecoder.
        /// </summary>
        class LiteralDecoder
		{
            /// <summary>
            /// Struct Decoder2
            /// </summary>
            struct Decoder2
			{
                /// <summary>
                /// The m decoders
                /// </summary>
                BitDecoder[] m_Decoders;
                /// <summary>
                /// Creates this instance.
                /// </summary>
                public void Create() { m_Decoders = new BitDecoder[0x300]; }
                /// <summary>
                /// Initializes this instance.
                /// </summary>
                public void Init() { for (int i = 0; i < 0x300; i++) m_Decoders[i].Init(); }

                /// <summary>
                /// Decodes the normal.
                /// </summary>
                /// <param name="rangeDecoder">The range decoder.</param>
                /// <returns>System.Byte.</returns>
                public byte DecodeNormal(RangeCoder.Decoder rangeDecoder)
				{
					uint symbol = 1;
					do
						symbol = (symbol << 1) | m_Decoders[symbol].Decode(rangeDecoder);
					while (symbol < 0x100);
					return (byte)symbol;
				}

                /// <summary>
                /// Decodes the with match byte.
                /// </summary>
                /// <param name="rangeDecoder">The range decoder.</param>
                /// <param name="matchByte">The match byte.</param>
                /// <returns>System.Byte.</returns>
                public byte DecodeWithMatchByte(RangeCoder.Decoder rangeDecoder, byte matchByte)
				{
					uint symbol = 1;
					do
					{
						uint matchBit = (uint)(matchByte >> 7) & 1;
						matchByte <<= 1;
						uint bit = m_Decoders[((1 + matchBit) << 8) + symbol].Decode(rangeDecoder);
						symbol = (symbol << 1) | bit;
						if (matchBit != bit)
						{
							while (symbol < 0x100)
								symbol = (symbol << 1) | m_Decoders[symbol].Decode(rangeDecoder);
							break;
						}
					}
					while (symbol < 0x100);
					return (byte)symbol;
				}
			}

            /// <summary>
            /// The m coders
            /// </summary>
            Decoder2[] m_Coders;
            /// <summary>
            /// The m number previous bits
            /// </summary>
            int m_NumPrevBits;
            /// <summary>
            /// The m number position bits
            /// </summary>
            int m_NumPosBits;
            /// <summary>
            /// The m position mask
            /// </summary>
            uint m_PosMask;

            /// <summary>
            /// Creates the specified number position bits.
            /// </summary>
            /// <param name="numPosBits">The number position bits.</param>
            /// <param name="numPrevBits">The number previous bits.</param>
            public void Create(int numPosBits, int numPrevBits)
			{
				if (m_Coders != null && m_NumPrevBits == numPrevBits &&
					m_NumPosBits == numPosBits)
					return;
				m_NumPosBits = numPosBits;
				m_PosMask = ((uint)1 << numPosBits) - 1;
				m_NumPrevBits = numPrevBits;
				uint numStates = (uint)1 << (m_NumPrevBits + m_NumPosBits);
				m_Coders = new Decoder2[numStates];
				for (uint i = 0; i < numStates; i++)
					m_Coders[i].Create();
			}

            /// <summary>
            /// Initializes this instance.
            /// </summary>
            public void Init()
			{
				uint numStates = (uint)1 << (m_NumPrevBits + m_NumPosBits);
				for (uint i = 0; i < numStates; i++)
					m_Coders[i].Init();
			}

            /// <summary>
            /// Gets the state.
            /// </summary>
            /// <param name="pos">The position.</param>
            /// <param name="prevByte">The previous byte.</param>
            /// <returns>System.UInt32.</returns>
            uint GetState(uint pos, byte prevByte)
			{ return ((pos & m_PosMask) << m_NumPrevBits) + (uint)(prevByte >> (8 - m_NumPrevBits)); }

            /// <summary>
            /// Decodes the normal.
            /// </summary>
            /// <param name="rangeDecoder">The range decoder.</param>
            /// <param name="pos">The position.</param>
            /// <param name="prevByte">The previous byte.</param>
            /// <returns>System.Byte.</returns>
            public byte DecodeNormal(RangeCoder.Decoder rangeDecoder, uint pos, byte prevByte)
			{ return m_Coders[GetState(pos, prevByte)].DecodeNormal(rangeDecoder); }

            /// <summary>
            /// Decodes the with match byte.
            /// </summary>
            /// <param name="rangeDecoder">The range decoder.</param>
            /// <param name="pos">The position.</param>
            /// <param name="prevByte">The previous byte.</param>
            /// <param name="matchByte">The match byte.</param>
            /// <returns>System.Byte.</returns>
            public byte DecodeWithMatchByte(RangeCoder.Decoder rangeDecoder, uint pos, byte prevByte, byte matchByte)
			{ return m_Coders[GetState(pos, prevByte)].DecodeWithMatchByte(rangeDecoder, matchByte); }
		};

        /// <summary>
        /// The m out window
        /// </summary>
        LZ.OutWindow m_OutWindow = new LZ.OutWindow();
        /// <summary>
        /// The m range decoder
        /// </summary>
        RangeCoder.Decoder m_RangeDecoder = new RangeCoder.Decoder();

        /// <summary>
        /// The m is match decoders
        /// </summary>
        BitDecoder[] m_IsMatchDecoders = new BitDecoder[Base.kNumStates << Base.kNumPosStatesBitsMax];
        /// <summary>
        /// The m is rep decoders
        /// </summary>
        BitDecoder[] m_IsRepDecoders = new BitDecoder[Base.kNumStates];
        /// <summary>
        /// The m is rep g0 decoders
        /// </summary>
        BitDecoder[] m_IsRepG0Decoders = new BitDecoder[Base.kNumStates];
        /// <summary>
        /// The m is rep g1 decoders
        /// </summary>
        BitDecoder[] m_IsRepG1Decoders = new BitDecoder[Base.kNumStates];
        /// <summary>
        /// The m is rep g2 decoders
        /// </summary>
        BitDecoder[] m_IsRepG2Decoders = new BitDecoder[Base.kNumStates];
        /// <summary>
        /// The m is rep0 long decoders
        /// </summary>
        BitDecoder[] m_IsRep0LongDecoders = new BitDecoder[Base.kNumStates << Base.kNumPosStatesBitsMax];

        /// <summary>
        /// The m position slot decoder
        /// </summary>
        BitTreeDecoder[] m_PosSlotDecoder = new BitTreeDecoder[Base.kNumLenToPosStates];
        /// <summary>
        /// The m position decoders
        /// </summary>
        BitDecoder[] m_PosDecoders = new BitDecoder[Base.kNumFullDistances - Base.kEndPosModelIndex];

        /// <summary>
        /// The m position align decoder
        /// </summary>
        BitTreeDecoder m_PosAlignDecoder = new BitTreeDecoder(Base.kNumAlignBits);

        /// <summary>
        /// The m length decoder
        /// </summary>
        LenDecoder m_LenDecoder = new LenDecoder();
        /// <summary>
        /// The m rep length decoder
        /// </summary>
        LenDecoder m_RepLenDecoder = new LenDecoder();

        /// <summary>
        /// The m literal decoder
        /// </summary>
        LiteralDecoder m_LiteralDecoder = new LiteralDecoder();

        /// <summary>
        /// The m dictionary size
        /// </summary>
        uint m_DictionarySize;
        /// <summary>
        /// The m dictionary size check
        /// </summary>
        uint m_DictionarySizeCheck;

        /// <summary>
        /// The m position state mask
        /// </summary>
        uint m_PosStateMask;

        /// <summary>
        /// Initializes a new instance of the <see cref="Decoder"/> class.
        /// </summary>
        public Decoder()
		{
			m_DictionarySize = 0xFFFFFFFF;
			for (int i = 0; i < Base.kNumLenToPosStates; i++)
				m_PosSlotDecoder[i] = new BitTreeDecoder(Base.kNumPosSlotBits);
		}

        /// <summary>
        /// Sets the size of the dictionary.
        /// </summary>
        /// <param name="dictionarySize">Size of the dictionary.</param>
        void SetDictionarySize(uint dictionarySize)
		{
			if (m_DictionarySize != dictionarySize)
			{
				m_DictionarySize = dictionarySize;
				m_DictionarySizeCheck = Math.Max(m_DictionarySize, 1);
				uint blockSize = Math.Max(m_DictionarySizeCheck, (1 << 12));
				m_OutWindow.Create(blockSize);
			}
		}

        /// <summary>
        /// Sets the literal properties.
        /// </summary>
        /// <param name="lp">The lp.</param>
        /// <param name="lc">The lc.</param>
        /// <exception cref="InvalidParamException">
        /// </exception>
        void SetLiteralProperties(int lp, int lc)
		{
			if (lp > 8)
				throw new InvalidParamException();
			if (lc > 8)
				throw new InvalidParamException();
			m_LiteralDecoder.Create(lp, lc);
		}

        /// <summary>
        /// Sets the position bits properties.
        /// </summary>
        /// <param name="pb">The pb.</param>
        /// <exception cref="InvalidParamException"></exception>
        void SetPosBitsProperties(int pb)
		{
			if (pb > Base.kNumPosStatesBitsMax)
				throw new InvalidParamException();
			uint numPosStates = (uint)1 << pb;
			m_LenDecoder.Create(numPosStates);
			m_RepLenDecoder.Create(numPosStates);
			m_PosStateMask = numPosStates - 1;
		}

        /// <summary>
        /// Initializes the specified in stream.
        /// </summary>
        /// <param name="inStream">The in stream.</param>
        /// <param name="outStream">The out stream.</param>
        void Init(System.IO.Stream inStream, System.IO.Stream outStream)
		{
			m_RangeDecoder.Init(inStream);
			m_OutWindow.Init(outStream);

			uint i;
			for (i = 0; i < Base.kNumStates; i++)
			{
				for (uint j = 0; j <= m_PosStateMask; j++)
				{
					uint index = (i << Base.kNumPosStatesBitsMax) + j;
					m_IsMatchDecoders[index].Init();
					m_IsRep0LongDecoders[index].Init();
				}
				m_IsRepDecoders[i].Init();
				m_IsRepG0Decoders[i].Init();
				m_IsRepG1Decoders[i].Init();
				m_IsRepG2Decoders[i].Init();
			}

			m_LiteralDecoder.Init();
			for (i = 0; i < Base.kNumLenToPosStates; i++)
				m_PosSlotDecoder[i].Init();
			// m_PosSpecDecoder.Init();
			for (i = 0; i < Base.kNumFullDistances - Base.kEndPosModelIndex; i++)
				m_PosDecoders[i].Init();

			m_LenDecoder.Init();
			m_RepLenDecoder.Init();
			m_PosAlignDecoder.Init();
		}

        /// <summary>
        /// Codes streams.
        /// </summary>
        /// <param name="inStream">input Stream.</param>
        /// <param name="outStream">output Stream.</param>
        /// <param name="inSize">input Size. -1 if unknown.</param>
        /// <param name="outSize">output Size. -1 if unknown.</param>
        /// <param name="progress">callback progress reference.</param>
        /// <exception cref="DataErrorException">
        /// </exception>
        public void Code(System.IO.Stream inStream, System.IO.Stream outStream,
			Int64 inSize, Int64 outSize, ICodeProgress progress)
		{
			Init(inStream, outStream);

			Base.State state = new Base.State();
			state.Init();
			uint rep0 = 0, rep1 = 0, rep2 = 0, rep3 = 0;

			UInt64 nowPos64 = 0;
			UInt64 outSize64 = (UInt64)outSize;
			if (nowPos64 < outSize64)
			{
				if (m_IsMatchDecoders[state.Index << Base.kNumPosStatesBitsMax].Decode(m_RangeDecoder) != 0)
					throw new DataErrorException();
				state.UpdateChar();
				byte b = m_LiteralDecoder.DecodeNormal(m_RangeDecoder, 0, 0);
				m_OutWindow.PutByte(b);
				nowPos64++;
			}
			while (nowPos64 < outSize64)
			{
				// UInt64 next = Math.Min(nowPos64 + (1 << 18), outSize64);
					// while(nowPos64 < next)
				{
					uint posState = (uint)nowPos64 & m_PosStateMask;
					if (m_IsMatchDecoders[(state.Index << Base.kNumPosStatesBitsMax) + posState].Decode(m_RangeDecoder) == 0)
					{
						byte b;
						byte prevByte = m_OutWindow.GetByte(0);
						if (!state.IsCharState())
							b = m_LiteralDecoder.DecodeWithMatchByte(m_RangeDecoder,
								(uint)nowPos64, prevByte, m_OutWindow.GetByte(rep0));
						else
							b = m_LiteralDecoder.DecodeNormal(m_RangeDecoder, (uint)nowPos64, prevByte);
						m_OutWindow.PutByte(b);
						state.UpdateChar();
						nowPos64++;
					}
					else
					{
						uint len;
						if (m_IsRepDecoders[state.Index].Decode(m_RangeDecoder) == 1)
						{
							if (m_IsRepG0Decoders[state.Index].Decode(m_RangeDecoder) == 0)
							{
								if (m_IsRep0LongDecoders[(state.Index << Base.kNumPosStatesBitsMax) + posState].Decode(m_RangeDecoder) == 0)
								{
									state.UpdateShortRep();
									m_OutWindow.PutByte(m_OutWindow.GetByte(rep0));
									nowPos64++;
									continue;
								}
							}
							else
							{
								UInt32 distance;
								if (m_IsRepG1Decoders[state.Index].Decode(m_RangeDecoder) == 0)
								{
									distance = rep1;
								}
								else
								{
									if (m_IsRepG2Decoders[state.Index].Decode(m_RangeDecoder) == 0)
										distance = rep2;
									else
									{
										distance = rep3;
										rep3 = rep2;
									}
									rep2 = rep1;
								}
								rep1 = rep0;
								rep0 = distance;
							}
							len = m_RepLenDecoder.Decode(m_RangeDecoder, posState) + Base.kMatchMinLen;
							state.UpdateRep();
						}
						else
						{
							rep3 = rep2;
							rep2 = rep1;
							rep1 = rep0;
							len = Base.kMatchMinLen + m_LenDecoder.Decode(m_RangeDecoder, posState);
							state.UpdateMatch();
							uint posSlot = m_PosSlotDecoder[Base.GetLenToPosState(len)].Decode(m_RangeDecoder);
							if (posSlot >= Base.kStartPosModelIndex)
							{
								int numDirectBits = (int)((posSlot >> 1) - 1);
								rep0 = ((2 | (posSlot & 1)) << numDirectBits);
								if (posSlot < Base.kEndPosModelIndex)
									rep0 += BitTreeDecoder.ReverseDecode(m_PosDecoders,
											rep0 - posSlot - 1, m_RangeDecoder, numDirectBits);
								else
								{
									rep0 += (m_RangeDecoder.DecodeDirectBits(
										numDirectBits - Base.kNumAlignBits) << Base.kNumAlignBits);
									rep0 += m_PosAlignDecoder.ReverseDecode(m_RangeDecoder);
								}
							}
							else
								rep0 = posSlot;
						}
						if (rep0 >= nowPos64 || rep0 >= m_DictionarySizeCheck)
						{
							if (rep0 == 0xFFFFFFFF)
								break;
							throw new DataErrorException();
						}
						m_OutWindow.CopyBlock(rep0, len);
						nowPos64 += len;
					}
				}
			}
			m_OutWindow.Flush();
			m_OutWindow.ReleaseStream();
			m_RangeDecoder.ReleaseStream();
		}

        /// <summary>
        /// Sets the decoder properties.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <exception cref="InvalidParamException">
        /// </exception>
        public void SetDecoderProperties(byte[] properties)
		{
			if (properties.Length < 5)
				throw new InvalidParamException();
			int lc = properties[0] % 9;
			int remainder = properties[0] / 9;
			int lp = remainder % 5;
			int pb = remainder / 5;
			if (pb > Base.kNumPosStatesBitsMax)
				throw new InvalidParamException();
			UInt32 dictionarySize = 0;
			for (int i = 0; i < 4; i++)
				dictionarySize += ((UInt32)(properties[1 + i])) << (i * 8);
			SetDictionarySize(dictionarySize);
			SetLiteralProperties(lp, lc);
			SetPosBitsProperties(pb);
		}

		/*
		public override bool CanRead { get { return true; }}
		public override bool CanWrite { get { return true; }}
		public override bool CanSeek { get { return true; }}
		public override long Length { get { return 0; }}
		public override long Position
		{
			get { return 0;	}
			set { }
		}
		public override void Flush() { }
		public override int Read(byte[] buffer, int offset, int count) 
		{
			return 0;
		}
		public override void Write(byte[] buffer, int offset, int count)
		{
		}
		public override long Seek(long offset, System.IO.SeekOrigin origin)
		{
			return 0;
		}
		public override void SetLength(long value) {}
		*/
	}
}
