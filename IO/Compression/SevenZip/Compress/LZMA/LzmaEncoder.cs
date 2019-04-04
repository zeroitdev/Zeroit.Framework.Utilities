// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-22-2018
// ***********************************************************************
// <copyright file="LzmaEncoder.cs" company="Zeroit Dev Technologies">
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
    /// Class Encoder.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.IO.Compression.SevenZip.ICoder" />
    /// <seealso cref="Zeroit.Framework.Utilities.IO.Compression.SevenZip.ISetCoderProperties" />
    /// <seealso cref="Zeroit.Framework.Utilities.IO.Compression.SevenZip.IWriteCoderProperties" />
    public class Encoder : ICoder, ISetCoderProperties, IWriteCoderProperties
	{
        /// <summary>
        /// Enum EMatchFinderType
        /// </summary>
        enum EMatchFinderType
		{
            /// <summary>
            /// The b t2
            /// </summary>
            BT2,
            /// <summary>
            /// The b t4
            /// </summary>
            BT4,
		};

        /// <summary>
        /// The k ifinity price
        /// </summary>
        const UInt32 kIfinityPrice = 0xFFFFFFF;

        /// <summary>
        /// The g fast position
        /// </summary>
        static Byte[] g_FastPos = new Byte[1 << 11];

        /// <summary>
        /// Initializes static members of the <see cref="Encoder"/> class.
        /// </summary>
        static Encoder()
		{
			const Byte kFastSlots = 22;
			int c = 2;
			g_FastPos[0] = 0;
			g_FastPos[1] = 1;
			for (Byte slotFast = 2; slotFast < kFastSlots; slotFast++)
			{
				UInt32 k = ((UInt32)1 << ((slotFast >> 1) - 1));
				for (UInt32 j = 0; j < k; j++, c++)
					g_FastPos[c] = slotFast;
			}
		}

        /// <summary>
        /// Gets the position slot.
        /// </summary>
        /// <param name="pos">The position.</param>
        /// <returns>UInt32.</returns>
        static UInt32 GetPosSlot(UInt32 pos)
		{
			if (pos < (1 << 11))
				return g_FastPos[pos];
			if (pos < (1 << 21))
				return (UInt32)(g_FastPos[pos >> 10] + 20);
			return (UInt32)(g_FastPos[pos >> 20] + 40);
		}

        /// <summary>
        /// Gets the position slot2.
        /// </summary>
        /// <param name="pos">The position.</param>
        /// <returns>UInt32.</returns>
        static UInt32 GetPosSlot2(UInt32 pos)
		{
			if (pos < (1 << 17))
				return (UInt32)(g_FastPos[pos >> 6] + 12);
			if (pos < (1 << 27))
				return (UInt32)(g_FastPos[pos >> 16] + 32);
			return (UInt32)(g_FastPos[pos >> 26] + 52);
		}

        /// <summary>
        /// The state
        /// </summary>
        Base.State _state = new Base.State();
        /// <summary>
        /// The previous byte
        /// </summary>
        Byte _previousByte;
        /// <summary>
        /// The rep distances
        /// </summary>
        UInt32[] _repDistances = new UInt32[Base.kNumRepDistances];

        /// <summary>
        /// Bases the initialize.
        /// </summary>
        void BaseInit()
		{
			_state.Init();
			_previousByte = 0;
			for (UInt32 i = 0; i < Base.kNumRepDistances; i++)
				_repDistances[i] = 0;
		}

        /// <summary>
        /// The k default dictionary log size
        /// </summary>
        const int kDefaultDictionaryLogSize = 22;
        /// <summary>
        /// The k number fast bytes default
        /// </summary>
        const UInt32 kNumFastBytesDefault = 0x20;

        /// <summary>
        /// Class LiteralEncoder.
        /// </summary>
        class LiteralEncoder
		{
            /// <summary>
            /// Struct Encoder2
            /// </summary>
            public struct Encoder2
			{
                /// <summary>
                /// The m encoders
                /// </summary>
                BitEncoder[] m_Encoders;

                /// <summary>
                /// Creates this instance.
                /// </summary>
                public void Create() { m_Encoders = new BitEncoder[0x300]; }

                /// <summary>
                /// Initializes this instance.
                /// </summary>
                public void Init() { for (int i = 0; i < 0x300; i++) m_Encoders[i].Init(); }

                /// <summary>
                /// Encodes the specified range encoder.
                /// </summary>
                /// <param name="rangeEncoder">The range encoder.</param>
                /// <param name="symbol">The symbol.</param>
                public void Encode(RangeCoder.Encoder rangeEncoder, byte symbol)
				{
					uint context = 1;
					for (int i = 7; i >= 0; i--)
					{
						uint bit = (uint)((symbol >> i) & 1);
						m_Encoders[context].Encode(rangeEncoder, bit);
						context = (context << 1) | bit;
					}
				}

                /// <summary>
                /// Encodes the matched.
                /// </summary>
                /// <param name="rangeEncoder">The range encoder.</param>
                /// <param name="matchByte">The match byte.</param>
                /// <param name="symbol">The symbol.</param>
                public void EncodeMatched(RangeCoder.Encoder rangeEncoder, byte matchByte, byte symbol)
				{
					uint context = 1;
					bool same = true;
					for (int i = 7; i >= 0; i--)
					{
						uint bit = (uint)((symbol >> i) & 1);
						uint state = context;
						if (same)
						{
							uint matchBit = (uint)((matchByte >> i) & 1);
							state += ((1 + matchBit) << 8);
							same = (matchBit == bit);
						}
						m_Encoders[state].Encode(rangeEncoder, bit);
						context = (context << 1) | bit;
					}
				}

                /// <summary>
                /// Gets the price.
                /// </summary>
                /// <param name="matchMode">if set to <c>true</c> [match mode].</param>
                /// <param name="matchByte">The match byte.</param>
                /// <param name="symbol">The symbol.</param>
                /// <returns>System.UInt32.</returns>
                public uint GetPrice(bool matchMode, byte matchByte, byte symbol)
				{
					uint price = 0;
					uint context = 1;
					int i = 7;
					if (matchMode)
					{
						for (; i >= 0; i--)
						{
							uint matchBit = (uint)(matchByte >> i) & 1;
							uint bit = (uint)(symbol >> i) & 1;
							price += m_Encoders[((1 + matchBit) << 8) + context].GetPrice(bit);
							context = (context << 1) | bit;
							if (matchBit != bit)
							{
								i--;
								break;
							}
						}
					}
					for (; i >= 0; i--)
					{
						uint bit = (uint)(symbol >> i) & 1;
						price += m_Encoders[context].GetPrice(bit);
						context = (context << 1) | bit;
					}
					return price;
				}
			}

            /// <summary>
            /// The m coders
            /// </summary>
            Encoder2[] m_Coders;
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
				if (m_Coders != null && m_NumPrevBits == numPrevBits && m_NumPosBits == numPosBits)
					return;
				m_NumPosBits = numPosBits;
				m_PosMask = ((uint)1 << numPosBits) - 1;
				m_NumPrevBits = numPrevBits;
				uint numStates = (uint)1 << (m_NumPrevBits + m_NumPosBits);
				m_Coders = new Encoder2[numStates];
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
            /// Gets the sub coder.
            /// </summary>
            /// <param name="pos">The position.</param>
            /// <param name="prevByte">The previous byte.</param>
            /// <returns>Encoder2.</returns>
            public Encoder2 GetSubCoder(UInt32 pos, Byte prevByte)
			{ return m_Coders[((pos & m_PosMask) << m_NumPrevBits) + (uint)(prevByte >> (8 - m_NumPrevBits))]; }
		}

        /// <summary>
        /// Class LenEncoder.
        /// </summary>
        class LenEncoder
		{
            /// <summary>
            /// The choice
            /// </summary>
            RangeCoder.BitEncoder _choice = new RangeCoder.BitEncoder();
            /// <summary>
            /// The choice2
            /// </summary>
            RangeCoder.BitEncoder _choice2 = new RangeCoder.BitEncoder();
            /// <summary>
            /// The low coder
            /// </summary>
            RangeCoder.BitTreeEncoder[] _lowCoder = new RangeCoder.BitTreeEncoder[Base.kNumPosStatesEncodingMax];
            /// <summary>
            /// The mid coder
            /// </summary>
            RangeCoder.BitTreeEncoder[] _midCoder = new RangeCoder.BitTreeEncoder[Base.kNumPosStatesEncodingMax];
            /// <summary>
            /// The high coder
            /// </summary>
            RangeCoder.BitTreeEncoder _highCoder = new RangeCoder.BitTreeEncoder(Base.kNumHighLenBits);

            /// <summary>
            /// Initializes a new instance of the <see cref="LenEncoder"/> class.
            /// </summary>
            public LenEncoder()
			{
				for (UInt32 posState = 0; posState < Base.kNumPosStatesEncodingMax; posState++)
				{
					_lowCoder[posState] = new RangeCoder.BitTreeEncoder(Base.kNumLowLenBits);
					_midCoder[posState] = new RangeCoder.BitTreeEncoder(Base.kNumMidLenBits);
				}
			}

            /// <summary>
            /// Initializes the specified number position states.
            /// </summary>
            /// <param name="numPosStates">The number position states.</param>
            public void Init(UInt32 numPosStates)
			{
				_choice.Init();
				_choice2.Init();
				for (UInt32 posState = 0; posState < numPosStates; posState++)
				{
					_lowCoder[posState].Init();
					_midCoder[posState].Init();
				}
				_highCoder.Init();
			}

            /// <summary>
            /// Encodes the specified range encoder.
            /// </summary>
            /// <param name="rangeEncoder">The range encoder.</param>
            /// <param name="symbol">The symbol.</param>
            /// <param name="posState">State of the position.</param>
            public void Encode(RangeCoder.Encoder rangeEncoder, UInt32 symbol, UInt32 posState)
			{
				if (symbol < Base.kNumLowLenSymbols)
				{
					_choice.Encode(rangeEncoder, 0);
					_lowCoder[posState].Encode(rangeEncoder, symbol);
				}
				else
				{
					symbol -= Base.kNumLowLenSymbols;
					_choice.Encode(rangeEncoder, 1);
					if (symbol < Base.kNumMidLenSymbols)
					{
						_choice2.Encode(rangeEncoder, 0);
						_midCoder[posState].Encode(rangeEncoder, symbol);
					}
					else
					{
						_choice2.Encode(rangeEncoder, 1);
						_highCoder.Encode(rangeEncoder, symbol - Base.kNumMidLenSymbols);
					}
				}
			}

            /// <summary>
            /// Sets the prices.
            /// </summary>
            /// <param name="posState">State of the position.</param>
            /// <param name="numSymbols">The number symbols.</param>
            /// <param name="prices">The prices.</param>
            /// <param name="st">The st.</param>
            public void SetPrices(UInt32 posState, UInt32 numSymbols, UInt32[] prices, UInt32 st)
			{
				UInt32 a0 = _choice.GetPrice0();
				UInt32 a1 = _choice.GetPrice1();
				UInt32 b0 = a1 + _choice2.GetPrice0();
				UInt32 b1 = a1 + _choice2.GetPrice1();
				UInt32 i = 0;
				for (i = 0; i < Base.kNumLowLenSymbols; i++)
				{
					if (i >= numSymbols)
						return;
					prices[st + i] = a0 + _lowCoder[posState].GetPrice(i);
				}
				for (; i < Base.kNumLowLenSymbols + Base.kNumMidLenSymbols; i++)
				{
					if (i >= numSymbols)
						return;
					prices[st + i] = b0 + _midCoder[posState].GetPrice(i - Base.kNumLowLenSymbols);
				}
				for (; i < numSymbols; i++)
					prices[st + i] = b1 + _highCoder.GetPrice(i - Base.kNumLowLenSymbols - Base.kNumMidLenSymbols);
			}
		};

        /// <summary>
        /// The k number length spec symbols
        /// </summary>
        const UInt32 kNumLenSpecSymbols = Base.kNumLowLenSymbols + Base.kNumMidLenSymbols;

        /// <summary>
        /// Class LenPriceTableEncoder.
        /// </summary>
        /// <seealso cref="Zeroit.Framework.Utilities.IO.Compression.SevenZip.Compression.LZMA.Encoder.LenEncoder" />
        class LenPriceTableEncoder : LenEncoder
		{
            /// <summary>
            /// The prices
            /// </summary>
            UInt32[] _prices = new UInt32[Base.kNumLenSymbols << Base.kNumPosStatesBitsEncodingMax];
            /// <summary>
            /// The table size
            /// </summary>
            UInt32 _tableSize;
            /// <summary>
            /// The counters
            /// </summary>
            UInt32[] _counters = new UInt32[Base.kNumPosStatesEncodingMax];

            /// <summary>
            /// Sets the size of the table.
            /// </summary>
            /// <param name="tableSize">Size of the table.</param>
            public void SetTableSize(UInt32 tableSize) { _tableSize = tableSize; }

            /// <summary>
            /// Gets the price.
            /// </summary>
            /// <param name="symbol">The symbol.</param>
            /// <param name="posState">State of the position.</param>
            /// <returns>UInt32.</returns>
            public UInt32 GetPrice(UInt32 symbol, UInt32 posState)
			{
				return _prices[posState * Base.kNumLenSymbols + symbol];
			}

            /// <summary>
            /// Updates the table.
            /// </summary>
            /// <param name="posState">State of the position.</param>
            void UpdateTable(UInt32 posState)
			{
				SetPrices(posState, _tableSize, _prices, posState * Base.kNumLenSymbols);
				_counters[posState] = _tableSize;
			}

            /// <summary>
            /// Updates the tables.
            /// </summary>
            /// <param name="numPosStates">The number position states.</param>
            public void UpdateTables(UInt32 numPosStates)
			{
				for (UInt32 posState = 0; posState < numPosStates; posState++)
					UpdateTable(posState);
			}

            /// <summary>
            /// Encodes the specified range encoder.
            /// </summary>
            /// <param name="rangeEncoder">The range encoder.</param>
            /// <param name="symbol">The symbol.</param>
            /// <param name="posState">State of the position.</param>
            public new void Encode(RangeCoder.Encoder rangeEncoder, UInt32 symbol, UInt32 posState)
			{
				base.Encode(rangeEncoder, symbol, posState);
				if (--_counters[posState] == 0)
					UpdateTable(posState);
			}
		}

        /// <summary>
        /// The k number opts
        /// </summary>
        const UInt32 kNumOpts = 1 << 12;
        /// <summary>
        /// Class Optimal.
        /// </summary>
        class Optimal
		{
            /// <summary>
            /// The state
            /// </summary>
            public Base.State State;

            /// <summary>
            /// The prev1 is character
            /// </summary>
            public bool Prev1IsChar;
            /// <summary>
            /// The prev2
            /// </summary>
            public bool Prev2;

            /// <summary>
            /// The position prev2
            /// </summary>
            public UInt32 PosPrev2;
            /// <summary>
            /// The back prev2
            /// </summary>
            public UInt32 BackPrev2;

            /// <summary>
            /// The price
            /// </summary>
            public UInt32 Price;
            /// <summary>
            /// The position previous
            /// </summary>
            public UInt32 PosPrev;
            /// <summary>
            /// The back previous
            /// </summary>
            public UInt32 BackPrev;

            /// <summary>
            /// The backs0
            /// </summary>
            public UInt32 Backs0;
            /// <summary>
            /// The backs1
            /// </summary>
            public UInt32 Backs1;
            /// <summary>
            /// The backs2
            /// </summary>
            public UInt32 Backs2;
            /// <summary>
            /// The backs3
            /// </summary>
            public UInt32 Backs3;

            /// <summary>
            /// Makes as character.
            /// </summary>
            public void MakeAsChar() { BackPrev = 0xFFFFFFFF; Prev1IsChar = false; }
            /// <summary>
            /// Makes as short rep.
            /// </summary>
            public void MakeAsShortRep() { BackPrev = 0; ; Prev1IsChar = false; }
            /// <summary>
            /// Determines whether [is short rep].
            /// </summary>
            /// <returns><c>true</c> if [is short rep]; otherwise, <c>false</c>.</returns>
            public bool IsShortRep() { return (BackPrev == 0); }
		};
        /// <summary>
        /// The optimum
        /// </summary>
        Optimal[] _optimum = new Optimal[kNumOpts];
        /// <summary>
        /// The match finder
        /// </summary>
        LZ.IMatchFinder _matchFinder = null;
        /// <summary>
        /// The range encoder
        /// </summary>
        RangeCoder.Encoder _rangeEncoder = new RangeCoder.Encoder();

        /// <summary>
        /// The is match
        /// </summary>
        RangeCoder.BitEncoder[] _isMatch = new RangeCoder.BitEncoder[Base.kNumStates << Base.kNumPosStatesBitsMax];
        /// <summary>
        /// The is rep
        /// </summary>
        RangeCoder.BitEncoder[] _isRep = new RangeCoder.BitEncoder[Base.kNumStates];
        /// <summary>
        /// The is rep g0
        /// </summary>
        RangeCoder.BitEncoder[] _isRepG0 = new RangeCoder.BitEncoder[Base.kNumStates];
        /// <summary>
        /// The is rep g1
        /// </summary>
        RangeCoder.BitEncoder[] _isRepG1 = new RangeCoder.BitEncoder[Base.kNumStates];
        /// <summary>
        /// The is rep g2
        /// </summary>
        RangeCoder.BitEncoder[] _isRepG2 = new RangeCoder.BitEncoder[Base.kNumStates];
        /// <summary>
        /// The is rep0 long
        /// </summary>
        RangeCoder.BitEncoder[] _isRep0Long = new RangeCoder.BitEncoder[Base.kNumStates << Base.kNumPosStatesBitsMax];

        /// <summary>
        /// The position slot encoder
        /// </summary>
        RangeCoder.BitTreeEncoder[] _posSlotEncoder = new RangeCoder.BitTreeEncoder[Base.kNumLenToPosStates];

        /// <summary>
        /// The position encoders
        /// </summary>
        RangeCoder.BitEncoder[] _posEncoders = new RangeCoder.BitEncoder[Base.kNumFullDistances - Base.kEndPosModelIndex];
        /// <summary>
        /// The position align encoder
        /// </summary>
        RangeCoder.BitTreeEncoder _posAlignEncoder = new RangeCoder.BitTreeEncoder(Base.kNumAlignBits);

        /// <summary>
        /// The length encoder
        /// </summary>
        LenPriceTableEncoder _lenEncoder = new LenPriceTableEncoder();
        /// <summary>
        /// The rep match length encoder
        /// </summary>
        LenPriceTableEncoder _repMatchLenEncoder = new LenPriceTableEncoder();

        /// <summary>
        /// The literal encoder
        /// </summary>
        LiteralEncoder _literalEncoder = new LiteralEncoder();

        /// <summary>
        /// The match distances
        /// </summary>
        UInt32[] _matchDistances = new UInt32[Base.kMatchMaxLen * 2 + 2];

        /// <summary>
        /// The number fast bytes
        /// </summary>
        UInt32 _numFastBytes = kNumFastBytesDefault;
        /// <summary>
        /// The longest match length
        /// </summary>
        UInt32 _longestMatchLength;
        /// <summary>
        /// The number distance pairs
        /// </summary>
        UInt32 _numDistancePairs;

        /// <summary>
        /// The additional offset
        /// </summary>
        UInt32 _additionalOffset;

        /// <summary>
        /// The optimum end index
        /// </summary>
        UInt32 _optimumEndIndex;
        /// <summary>
        /// The optimum current index
        /// </summary>
        UInt32 _optimumCurrentIndex;

        /// <summary>
        /// The longest match was found
        /// </summary>
        bool _longestMatchWasFound;

        /// <summary>
        /// The position slot prices
        /// </summary>
        UInt32[] _posSlotPrices = new UInt32[1 << (Base.kNumPosSlotBits + Base.kNumLenToPosStatesBits)];
        /// <summary>
        /// The distances prices
        /// </summary>
        UInt32[] _distancesPrices = new UInt32[Base.kNumFullDistances << Base.kNumLenToPosStatesBits];
        /// <summary>
        /// The align prices
        /// </summary>
        UInt32[] _alignPrices = new UInt32[Base.kAlignTableSize];
        /// <summary>
        /// The align price count
        /// </summary>
        UInt32 _alignPriceCount;

        /// <summary>
        /// The dist table size
        /// </summary>
        UInt32 _distTableSize = (kDefaultDictionaryLogSize * 2);

        /// <summary>
        /// The position state bits
        /// </summary>
        int _posStateBits = 2;
        /// <summary>
        /// The position state mask
        /// </summary>
        UInt32 _posStateMask = (4 - 1);
        /// <summary>
        /// The number literal position state bits
        /// </summary>
        int _numLiteralPosStateBits = 0;
        /// <summary>
        /// The number literal context bits
        /// </summary>
        int _numLiteralContextBits = 3;

        /// <summary>
        /// The dictionary size
        /// </summary>
        UInt32 _dictionarySize = (1 << kDefaultDictionaryLogSize);
        /// <summary>
        /// The dictionary size previous
        /// </summary>
        UInt32 _dictionarySizePrev = 0xFFFFFFFF;
        /// <summary>
        /// The number fast bytes previous
        /// </summary>
        UInt32 _numFastBytesPrev = 0xFFFFFFFF;

        /// <summary>
        /// The now pos64
        /// </summary>
        Int64 nowPos64;
        /// <summary>
        /// The finished
        /// </summary>
        bool _finished;
        /// <summary>
        /// The in stream
        /// </summary>
        System.IO.Stream _inStream;

        /// <summary>
        /// The match finder type
        /// </summary>
        EMatchFinderType _matchFinderType = EMatchFinderType.BT4;
        /// <summary>
        /// The write end mark
        /// </summary>
        bool _writeEndMark = false;

        /// <summary>
        /// The need release mf stream
        /// </summary>
        bool _needReleaseMFStream;

        /// <summary>
        /// Creates this instance.
        /// </summary>
        void Create()
		{
			if (_matchFinder == null)
			{
				LZ.BinTree bt = new LZ.BinTree();
				int numHashBytes = 4;
				if (_matchFinderType == EMatchFinderType.BT2)
					numHashBytes = 2;
				bt.SetType(numHashBytes);
				_matchFinder = bt;
			}
			_literalEncoder.Create(_numLiteralPosStateBits, _numLiteralContextBits);

			if (_dictionarySize == _dictionarySizePrev && _numFastBytesPrev == _numFastBytes)
				return;
			_matchFinder.Create(_dictionarySize, kNumOpts, _numFastBytes, Base.kMatchMaxLen + 1);
			_dictionarySizePrev = _dictionarySize;
			_numFastBytesPrev = _numFastBytes;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="Encoder"/> class.
        /// </summary>
        public Encoder()
		{
			for (int i = 0; i < kNumOpts; i++)
				_optimum[i] = new Optimal();
			for (int i = 0; i < Base.kNumLenToPosStates; i++)
				_posSlotEncoder[i] = new RangeCoder.BitTreeEncoder(Base.kNumPosSlotBits);
		}

        /// <summary>
        /// Sets the write end marker mode.
        /// </summary>
        /// <param name="writeEndMarker">if set to <c>true</c> [write end marker].</param>
        void SetWriteEndMarkerMode(bool writeEndMarker)
		{
			_writeEndMark = writeEndMarker;
		}

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        void Init()
		{
			BaseInit();
			_rangeEncoder.Init();

			uint i;
			for (i = 0; i < Base.kNumStates; i++)
			{
				for (uint j = 0; j <= _posStateMask; j++)
				{
					uint complexState = (i << Base.kNumPosStatesBitsMax) + j;
					_isMatch[complexState].Init();
					_isRep0Long[complexState].Init();
				}
				_isRep[i].Init();
				_isRepG0[i].Init();
				_isRepG1[i].Init();
				_isRepG2[i].Init();
			}
			_literalEncoder.Init();
			for (i = 0; i < Base.kNumLenToPosStates; i++)
				_posSlotEncoder[i].Init();
			for (i = 0; i < Base.kNumFullDistances - Base.kEndPosModelIndex; i++)
				_posEncoders[i].Init();

			_lenEncoder.Init((UInt32)1 << _posStateBits);
			_repMatchLenEncoder.Init((UInt32)1 << _posStateBits);

			_posAlignEncoder.Init();

			_longestMatchWasFound = false;
			_optimumEndIndex = 0;
			_optimumCurrentIndex = 0;
			_additionalOffset = 0;
		}

        /// <summary>
        /// Reads the match distances.
        /// </summary>
        /// <param name="lenRes">The length resource.</param>
        /// <param name="numDistancePairs">The number distance pairs.</param>
        void ReadMatchDistances(out UInt32 lenRes, out UInt32 numDistancePairs)
		{
			lenRes = 0;
			numDistancePairs = _matchFinder.GetMatches(_matchDistances);
			if (numDistancePairs > 0)
			{
				lenRes = _matchDistances[numDistancePairs - 2];
				if (lenRes == _numFastBytes)
					lenRes += _matchFinder.GetMatchLen((int)lenRes - 1, _matchDistances[numDistancePairs - 1],
						Base.kMatchMaxLen - lenRes);
			}
			_additionalOffset++;
		}


        /// <summary>
        /// Moves the position.
        /// </summary>
        /// <param name="num">The number.</param>
        void MovePos(UInt32 num)
		{
			if (num > 0)
			{
				_matchFinder.Skip(num);
				_additionalOffset += num;
			}
		}

        /// <summary>
        /// Gets the rep len1 price.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="posState">State of the position.</param>
        /// <returns>UInt32.</returns>
        UInt32 GetRepLen1Price(Base.State state, UInt32 posState)
		{
			return _isRepG0[state.Index].GetPrice0() +
					_isRep0Long[(state.Index << Base.kNumPosStatesBitsMax) + posState].GetPrice0();
		}

        /// <summary>
        /// Gets the pure rep price.
        /// </summary>
        /// <param name="repIndex">Index of the rep.</param>
        /// <param name="state">The state.</param>
        /// <param name="posState">State of the position.</param>
        /// <returns>UInt32.</returns>
        UInt32 GetPureRepPrice(UInt32 repIndex, Base.State state, UInt32 posState)
		{
			UInt32 price;
			if (repIndex == 0)
			{
				price = _isRepG0[state.Index].GetPrice0();
				price += _isRep0Long[(state.Index << Base.kNumPosStatesBitsMax) + posState].GetPrice1();
			}
			else
			{
				price = _isRepG0[state.Index].GetPrice1();
				if (repIndex == 1)
					price += _isRepG1[state.Index].GetPrice0();
				else
				{
					price += _isRepG1[state.Index].GetPrice1();
					price += _isRepG2[state.Index].GetPrice(repIndex - 2);
				}
			}
			return price;
		}

        /// <summary>
        /// Gets the rep price.
        /// </summary>
        /// <param name="repIndex">Index of the rep.</param>
        /// <param name="len">The length.</param>
        /// <param name="state">The state.</param>
        /// <param name="posState">State of the position.</param>
        /// <returns>UInt32.</returns>
        UInt32 GetRepPrice(UInt32 repIndex, UInt32 len, Base.State state, UInt32 posState)
		{
			UInt32 price = _repMatchLenEncoder.GetPrice(len - Base.kMatchMinLen, posState);
			return price + GetPureRepPrice(repIndex, state, posState);
		}

        /// <summary>
        /// Gets the position length price.
        /// </summary>
        /// <param name="pos">The position.</param>
        /// <param name="len">The length.</param>
        /// <param name="posState">State of the position.</param>
        /// <returns>UInt32.</returns>
        UInt32 GetPosLenPrice(UInt32 pos, UInt32 len, UInt32 posState)
		{
			UInt32 price;
			UInt32 lenToPosState = Base.GetLenToPosState(len);
			if (pos < Base.kNumFullDistances)
				price = _distancesPrices[(lenToPosState * Base.kNumFullDistances) + pos];
			else
				price = _posSlotPrices[(lenToPosState << Base.kNumPosSlotBits) + GetPosSlot2(pos)] +
					_alignPrices[pos & Base.kAlignMask];
			return price + _lenEncoder.GetPrice(len - Base.kMatchMinLen, posState);
		}

        /// <summary>
        /// Backwards the specified back resource.
        /// </summary>
        /// <param name="backRes">The back resource.</param>
        /// <param name="cur">The current.</param>
        /// <returns>UInt32.</returns>
        UInt32 Backward(out UInt32 backRes, UInt32 cur)
		{
			_optimumEndIndex = cur;
			UInt32 posMem = _optimum[cur].PosPrev;
			UInt32 backMem = _optimum[cur].BackPrev;
			do
			{
				if (_optimum[cur].Prev1IsChar)
				{
					_optimum[posMem].MakeAsChar();
					_optimum[posMem].PosPrev = posMem - 1;
					if (_optimum[cur].Prev2)
					{
						_optimum[posMem - 1].Prev1IsChar = false;
						_optimum[posMem - 1].PosPrev = _optimum[cur].PosPrev2;
						_optimum[posMem - 1].BackPrev = _optimum[cur].BackPrev2;
					}
				}
				UInt32 posPrev = posMem;
				UInt32 backCur = backMem;

				backMem = _optimum[posPrev].BackPrev;
				posMem = _optimum[posPrev].PosPrev;

				_optimum[posPrev].BackPrev = backCur;
				_optimum[posPrev].PosPrev = cur;
				cur = posPrev;
			}
			while (cur > 0);
			backRes = _optimum[0].BackPrev;
			_optimumCurrentIndex = _optimum[0].PosPrev;
			return _optimumCurrentIndex;
		}

        /// <summary>
        /// The reps
        /// </summary>
        UInt32[] reps = new UInt32[Base.kNumRepDistances];
        /// <summary>
        /// The rep lens
        /// </summary>
        UInt32[] repLens = new UInt32[Base.kNumRepDistances];


        /// <summary>
        /// Gets the optimum.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="backRes">The back resource.</param>
        /// <returns>UInt32.</returns>
        UInt32 GetOptimum(UInt32 position, out UInt32 backRes)
		{
			if (_optimumEndIndex != _optimumCurrentIndex)
			{
				UInt32 lenRes = _optimum[_optimumCurrentIndex].PosPrev - _optimumCurrentIndex;
				backRes = _optimum[_optimumCurrentIndex].BackPrev;
				_optimumCurrentIndex = _optimum[_optimumCurrentIndex].PosPrev;
				return lenRes;
			}
			_optimumCurrentIndex = _optimumEndIndex = 0;

			UInt32 lenMain, numDistancePairs;
			if (!_longestMatchWasFound)
			{
				ReadMatchDistances(out lenMain, out numDistancePairs);
			}
			else
			{
				lenMain = _longestMatchLength;
				numDistancePairs = _numDistancePairs;
				_longestMatchWasFound = false;
			}

			UInt32 numAvailableBytes = _matchFinder.GetNumAvailableBytes() + 1;
			if (numAvailableBytes < 2)
			{
				backRes = 0xFFFFFFFF;
				return 1;
			}
			if (numAvailableBytes > Base.kMatchMaxLen)
				numAvailableBytes = Base.kMatchMaxLen;

			UInt32 repMaxIndex = 0;
			UInt32 i;			
			for (i = 0; i < Base.kNumRepDistances; i++)
			{
				reps[i] = _repDistances[i];
				repLens[i] = _matchFinder.GetMatchLen(0 - 1, reps[i], Base.kMatchMaxLen);
				if (repLens[i] > repLens[repMaxIndex])
					repMaxIndex = i;
			}
			if (repLens[repMaxIndex] >= _numFastBytes)
			{
				backRes = repMaxIndex;
				UInt32 lenRes = repLens[repMaxIndex];
				MovePos(lenRes - 1);
				return lenRes;
			}

			if (lenMain >= _numFastBytes)
			{
				backRes = _matchDistances[numDistancePairs - 1] + Base.kNumRepDistances;
				MovePos(lenMain - 1);
				return lenMain;
			}
			
			Byte currentByte = _matchFinder.GetIndexByte(0 - 1);
			Byte matchByte = _matchFinder.GetIndexByte((Int32)(0 - _repDistances[0] - 1 - 1));

			if (lenMain < 2 && currentByte != matchByte && repLens[repMaxIndex] < 2)
			{
				backRes = (UInt32)0xFFFFFFFF;
				return 1;
			}

			_optimum[0].State = _state;

			UInt32 posState = (position & _posStateMask);

			_optimum[1].Price = _isMatch[(_state.Index << Base.kNumPosStatesBitsMax) + posState].GetPrice0() +
					_literalEncoder.GetSubCoder(position, _previousByte).GetPrice(!_state.IsCharState(), matchByte, currentByte);
			_optimum[1].MakeAsChar();

			UInt32 matchPrice = _isMatch[(_state.Index << Base.kNumPosStatesBitsMax) + posState].GetPrice1();
			UInt32 repMatchPrice = matchPrice + _isRep[_state.Index].GetPrice1();

			if (matchByte == currentByte)
			{
				UInt32 shortRepPrice = repMatchPrice + GetRepLen1Price(_state, posState);
				if (shortRepPrice < _optimum[1].Price)
				{
					_optimum[1].Price = shortRepPrice;
					_optimum[1].MakeAsShortRep();
				}
			}

			UInt32 lenEnd = ((lenMain >= repLens[repMaxIndex]) ? lenMain : repLens[repMaxIndex]);

			if(lenEnd < 2)
			{
				backRes = _optimum[1].BackPrev;
				return 1;
			}
			
			_optimum[1].PosPrev = 0;

			_optimum[0].Backs0 = reps[0];
			_optimum[0].Backs1 = reps[1];
			_optimum[0].Backs2 = reps[2];
			_optimum[0].Backs3 = reps[3];

			UInt32 len = lenEnd;
			do
				_optimum[len--].Price = kIfinityPrice;
			while (len >= 2);

			for (i = 0; i < Base.kNumRepDistances; i++)
			{
				UInt32 repLen = repLens[i];
				if (repLen < 2)
					continue;
				UInt32 price = repMatchPrice + GetPureRepPrice(i, _state, posState);
				do
				{
					UInt32 curAndLenPrice = price + _repMatchLenEncoder.GetPrice(repLen - 2, posState);
					Optimal optimum = _optimum[repLen];
					if (curAndLenPrice < optimum.Price)
					{
						optimum.Price = curAndLenPrice;
						optimum.PosPrev = 0;
						optimum.BackPrev = i;
						optimum.Prev1IsChar = false;
					}
				}
				while (--repLen >= 2);
			}

			UInt32 normalMatchPrice = matchPrice + _isRep[_state.Index].GetPrice0();
			
			len = ((repLens[0] >= 2) ? repLens[0] + 1 : 2);
			if (len <= lenMain)
			{
				UInt32 offs = 0;
				while (len > _matchDistances[offs])
					offs += 2;
				for (; ; len++)
				{
					UInt32 distance = _matchDistances[offs + 1];
					UInt32 curAndLenPrice = normalMatchPrice + GetPosLenPrice(distance, len, posState);
					Optimal optimum = _optimum[len];
					if (curAndLenPrice < optimum.Price)
					{
						optimum.Price = curAndLenPrice;
						optimum.PosPrev = 0;
						optimum.BackPrev = distance + Base.kNumRepDistances;
						optimum.Prev1IsChar = false;
					}
					if (len == _matchDistances[offs])
					{
						offs += 2;
						if (offs == numDistancePairs)
							break;
					}
				}
			}

			UInt32 cur = 0;

			while (true)
			{
				cur++;
				if (cur == lenEnd)
					return Backward(out backRes, cur);
				UInt32 newLen;
				ReadMatchDistances(out newLen, out numDistancePairs);
				if (newLen >= _numFastBytes)
				{
					_numDistancePairs = numDistancePairs;
					_longestMatchLength = newLen;
					_longestMatchWasFound = true;
					return Backward(out backRes, cur);
				}
				position++;
				UInt32 posPrev = _optimum[cur].PosPrev;
				Base.State state;
				if (_optimum[cur].Prev1IsChar)
				{
					posPrev--;
					if (_optimum[cur].Prev2)
					{
						state = _optimum[_optimum[cur].PosPrev2].State;
						if (_optimum[cur].BackPrev2 < Base.kNumRepDistances)
							state.UpdateRep();
						else
							state.UpdateMatch();
					}
					else
						state = _optimum[posPrev].State;
					state.UpdateChar();
				}
				else
					state = _optimum[posPrev].State;
				if (posPrev == cur - 1)
				{
					if (_optimum[cur].IsShortRep())
						state.UpdateShortRep();
					else
						state.UpdateChar();
				}
				else
				{
					UInt32 pos;
					if (_optimum[cur].Prev1IsChar && _optimum[cur].Prev2)
					{
						posPrev = _optimum[cur].PosPrev2;
						pos = _optimum[cur].BackPrev2;
						state.UpdateRep();
					}
					else
					{
						pos = _optimum[cur].BackPrev;
						if (pos < Base.kNumRepDistances)
							state.UpdateRep();
						else
							state.UpdateMatch();
					}
					Optimal opt = _optimum[posPrev];
					if (pos < Base.kNumRepDistances)
					{
						if (pos == 0)
						{
							reps[0] = opt.Backs0;
							reps[1] = opt.Backs1;
							reps[2] = opt.Backs2;
							reps[3] = opt.Backs3;
						}
						else if (pos == 1)
						{
							reps[0] = opt.Backs1;
							reps[1] = opt.Backs0;
							reps[2] = opt.Backs2;
							reps[3] = opt.Backs3;
						}
						else if (pos == 2)
						{
							reps[0] = opt.Backs2;
							reps[1] = opt.Backs0;
							reps[2] = opt.Backs1;
							reps[3] = opt.Backs3;
						}
						else
						{
							reps[0] = opt.Backs3;
							reps[1] = opt.Backs0;
							reps[2] = opt.Backs1;
							reps[3] = opt.Backs2;
						}
					}
					else
					{
						reps[0] = (pos - Base.kNumRepDistances);
						reps[1] = opt.Backs0;
						reps[2] = opt.Backs1;
						reps[3] = opt.Backs2;
					}
				}
				_optimum[cur].State = state;
				_optimum[cur].Backs0 = reps[0];
				_optimum[cur].Backs1 = reps[1];
				_optimum[cur].Backs2 = reps[2];
				_optimum[cur].Backs3 = reps[3];
				UInt32 curPrice = _optimum[cur].Price;

				currentByte = _matchFinder.GetIndexByte(0 - 1);
				matchByte = _matchFinder.GetIndexByte((Int32)(0 - reps[0] - 1 - 1));

				posState = (position & _posStateMask);

				UInt32 curAnd1Price = curPrice +
					_isMatch[(state.Index << Base.kNumPosStatesBitsMax) + posState].GetPrice0() +
					_literalEncoder.GetSubCoder(position, _matchFinder.GetIndexByte(0 - 2)).
					GetPrice(!state.IsCharState(), matchByte, currentByte);

				Optimal nextOptimum = _optimum[cur + 1];

				bool nextIsChar = false;
				if (curAnd1Price < nextOptimum.Price)
				{
					nextOptimum.Price = curAnd1Price;
					nextOptimum.PosPrev = cur;
					nextOptimum.MakeAsChar();
					nextIsChar = true;
				}

				matchPrice = curPrice + _isMatch[(state.Index << Base.kNumPosStatesBitsMax) + posState].GetPrice1();
				repMatchPrice = matchPrice + _isRep[state.Index].GetPrice1();

				if (matchByte == currentByte &&
					!(nextOptimum.PosPrev < cur && nextOptimum.BackPrev == 0))
				{
					UInt32 shortRepPrice = repMatchPrice + GetRepLen1Price(state, posState);
					if (shortRepPrice <= nextOptimum.Price)
					{
						nextOptimum.Price = shortRepPrice;
						nextOptimum.PosPrev = cur;
						nextOptimum.MakeAsShortRep();
						nextIsChar = true;
					}
				}

				UInt32 numAvailableBytesFull = _matchFinder.GetNumAvailableBytes() + 1;
				numAvailableBytesFull = Math.Min(kNumOpts - 1 - cur, numAvailableBytesFull);
				numAvailableBytes = numAvailableBytesFull;

				if (numAvailableBytes < 2)
					continue;
				if (numAvailableBytes > _numFastBytes)
					numAvailableBytes = _numFastBytes;
				if (!nextIsChar && matchByte != currentByte)
				{
					// try Literal + rep0
					UInt32 t = Math.Min(numAvailableBytesFull - 1, _numFastBytes);
					UInt32 lenTest2 = _matchFinder.GetMatchLen(0, reps[0], t);
					if (lenTest2 >= 2)
					{
						Base.State state2 = state;
						state2.UpdateChar();
						UInt32 posStateNext = (position + 1) & _posStateMask;
						UInt32 nextRepMatchPrice = curAnd1Price +
							_isMatch[(state2.Index << Base.kNumPosStatesBitsMax) + posStateNext].GetPrice1() +
							_isRep[state2.Index].GetPrice1();
						{
							UInt32 offset = cur + 1 + lenTest2;
							while (lenEnd < offset)
								_optimum[++lenEnd].Price = kIfinityPrice;
							UInt32 curAndLenPrice = nextRepMatchPrice + GetRepPrice(
								0, lenTest2, state2, posStateNext);
							Optimal optimum = _optimum[offset];
							if (curAndLenPrice < optimum.Price)
							{
								optimum.Price = curAndLenPrice;
								optimum.PosPrev = cur + 1;
								optimum.BackPrev = 0;
								optimum.Prev1IsChar = true;
								optimum.Prev2 = false;
							}
						}
					}
				}

				UInt32 startLen = 2; // speed optimization 

				for (UInt32 repIndex = 0; repIndex < Base.kNumRepDistances; repIndex++)
				{
					UInt32 lenTest = _matchFinder.GetMatchLen(0 - 1, reps[repIndex], numAvailableBytes);
					if (lenTest < 2)
						continue;
					UInt32 lenTestTemp = lenTest;
					do
					{
						while (lenEnd < cur + lenTest)
							_optimum[++lenEnd].Price = kIfinityPrice;
						UInt32 curAndLenPrice = repMatchPrice + GetRepPrice(repIndex, lenTest, state, posState);
						Optimal optimum = _optimum[cur + lenTest];
						if (curAndLenPrice < optimum.Price)
						{
							optimum.Price = curAndLenPrice;
							optimum.PosPrev = cur;
							optimum.BackPrev = repIndex;
							optimum.Prev1IsChar = false;
						}
					}
					while(--lenTest >= 2);
					lenTest = lenTestTemp;

					if (repIndex == 0)
						startLen = lenTest + 1;

					// if (_maxMode)
					if (lenTest < numAvailableBytesFull)
					{
						UInt32 t = Math.Min(numAvailableBytesFull - 1 - lenTest, _numFastBytes);
						UInt32 lenTest2 = _matchFinder.GetMatchLen((Int32)lenTest, reps[repIndex], t);
						if (lenTest2 >= 2)
						{
							Base.State state2 = state;
							state2.UpdateRep();
							UInt32 posStateNext = (position + lenTest) & _posStateMask;
							UInt32 curAndLenCharPrice = 
									repMatchPrice + GetRepPrice(repIndex, lenTest, state, posState) + 
									_isMatch[(state2.Index << Base.kNumPosStatesBitsMax) + posStateNext].GetPrice0() +
									_literalEncoder.GetSubCoder(position + lenTest, 
									_matchFinder.GetIndexByte((Int32)lenTest - 1 - 1)).GetPrice(true,
									_matchFinder.GetIndexByte((Int32)((Int32)lenTest - 1 - (Int32)(reps[repIndex] + 1))), 
									_matchFinder.GetIndexByte((Int32)lenTest - 1));
							state2.UpdateChar();
							posStateNext = (position + lenTest + 1) & _posStateMask;
							UInt32 nextMatchPrice = curAndLenCharPrice + _isMatch[(state2.Index << Base.kNumPosStatesBitsMax) + posStateNext].GetPrice1();
							UInt32 nextRepMatchPrice = nextMatchPrice + _isRep[state2.Index].GetPrice1();
							
							// for(; lenTest2 >= 2; lenTest2--)
							{
								UInt32 offset = lenTest + 1 + lenTest2;
								while(lenEnd < cur + offset)
									_optimum[++lenEnd].Price = kIfinityPrice;
								UInt32 curAndLenPrice = nextRepMatchPrice + GetRepPrice(0, lenTest2, state2, posStateNext);
								Optimal optimum = _optimum[cur + offset];
								if (curAndLenPrice < optimum.Price) 
								{
									optimum.Price = curAndLenPrice;
									optimum.PosPrev = cur + lenTest + 1;
									optimum.BackPrev = 0;
									optimum.Prev1IsChar = true;
									optimum.Prev2 = true;
									optimum.PosPrev2 = cur;
									optimum.BackPrev2 = repIndex;
								}
							}
						}
					}
				}

				if (newLen > numAvailableBytes)
				{
					newLen = numAvailableBytes;
					for (numDistancePairs = 0; newLen > _matchDistances[numDistancePairs]; numDistancePairs += 2) ;
					_matchDistances[numDistancePairs] = newLen;
					numDistancePairs += 2;
				}
				if (newLen >= startLen)
				{
					normalMatchPrice = matchPrice + _isRep[state.Index].GetPrice0();
					while (lenEnd < cur + newLen)
						_optimum[++lenEnd].Price = kIfinityPrice;

					UInt32 offs = 0;
					while (startLen > _matchDistances[offs])
						offs += 2;

					for (UInt32 lenTest = startLen; ; lenTest++)
					{
						UInt32 curBack = _matchDistances[offs + 1];
						UInt32 curAndLenPrice = normalMatchPrice + GetPosLenPrice(curBack, lenTest, posState);
						Optimal optimum = _optimum[cur + lenTest];
						if (curAndLenPrice < optimum.Price)
						{
							optimum.Price = curAndLenPrice;
							optimum.PosPrev = cur;
							optimum.BackPrev = curBack + Base.kNumRepDistances;
							optimum.Prev1IsChar = false;
						}

						if (lenTest == _matchDistances[offs])
						{
							if (lenTest < numAvailableBytesFull)
							{
								UInt32 t = Math.Min(numAvailableBytesFull - 1 - lenTest, _numFastBytes);
								UInt32 lenTest2 = _matchFinder.GetMatchLen((Int32)lenTest, curBack, t);
								if (lenTest2 >= 2)
								{
									Base.State state2 = state;
									state2.UpdateMatch();
									UInt32 posStateNext = (position + lenTest) & _posStateMask;
									UInt32 curAndLenCharPrice = curAndLenPrice +
										_isMatch[(state2.Index << Base.kNumPosStatesBitsMax) + posStateNext].GetPrice0() +
										_literalEncoder.GetSubCoder(position + lenTest,
										_matchFinder.GetIndexByte((Int32)lenTest - 1 - 1)).
										GetPrice(true,
										_matchFinder.GetIndexByte((Int32)lenTest - (Int32)(curBack + 1) - 1),
										_matchFinder.GetIndexByte((Int32)lenTest - 1));
									state2.UpdateChar();
									posStateNext = (position + lenTest + 1) & _posStateMask;
									UInt32 nextMatchPrice = curAndLenCharPrice + _isMatch[(state2.Index << Base.kNumPosStatesBitsMax) + posStateNext].GetPrice1();
									UInt32 nextRepMatchPrice = nextMatchPrice + _isRep[state2.Index].GetPrice1();

									UInt32 offset = lenTest + 1 + lenTest2;
									while (lenEnd < cur + offset)
										_optimum[++lenEnd].Price = kIfinityPrice;
									curAndLenPrice = nextRepMatchPrice + GetRepPrice(0, lenTest2, state2, posStateNext);
									optimum = _optimum[cur + offset];
									if (curAndLenPrice < optimum.Price)
									{
										optimum.Price = curAndLenPrice;
										optimum.PosPrev = cur + lenTest + 1;
										optimum.BackPrev = 0;
										optimum.Prev1IsChar = true;
										optimum.Prev2 = true;
										optimum.PosPrev2 = cur;
										optimum.BackPrev2 = curBack + Base.kNumRepDistances;
									}
								}
							}
							offs += 2;
							if (offs == numDistancePairs)
								break;
						}
					}
				}
			}
		}

        /// <summary>
        /// Changes the pair.
        /// </summary>
        /// <param name="smallDist">The small dist.</param>
        /// <param name="bigDist">The big dist.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool ChangePair(UInt32 smallDist, UInt32 bigDist)
		{
			const int kDif = 7;
			return (smallDist < ((UInt32)(1) << (32 - kDif)) && bigDist >= (smallDist << kDif));
		}

        /// <summary>
        /// Writes the end marker.
        /// </summary>
        /// <param name="posState">State of the position.</param>
        void WriteEndMarker(UInt32 posState)
		{
			if (!_writeEndMark)
				return;

			_isMatch[(_state.Index << Base.kNumPosStatesBitsMax) + posState].Encode(_rangeEncoder, 1);
			_isRep[_state.Index].Encode(_rangeEncoder, 0);
			_state.UpdateMatch();
			UInt32 len = Base.kMatchMinLen;
			_lenEncoder.Encode(_rangeEncoder, len - Base.kMatchMinLen, posState);
			UInt32 posSlot = (1 << Base.kNumPosSlotBits) - 1;
			UInt32 lenToPosState = Base.GetLenToPosState(len);
			_posSlotEncoder[lenToPosState].Encode(_rangeEncoder, posSlot);
			int footerBits = 30;
			UInt32 posReduced = (((UInt32)1) << footerBits) - 1;
			_rangeEncoder.EncodeDirectBits(posReduced >> Base.kNumAlignBits, footerBits - Base.kNumAlignBits);
			_posAlignEncoder.ReverseEncode(_rangeEncoder, posReduced & Base.kAlignMask);
		}

        /// <summary>
        /// Flushes the specified now position.
        /// </summary>
        /// <param name="nowPos">The now position.</param>
        void Flush(UInt32 nowPos)
		{
			ReleaseMFStream();
			WriteEndMarker(nowPos & _posStateMask);
			_rangeEncoder.FlushData();
			_rangeEncoder.FlushStream();
		}

        /// <summary>
        /// Codes the one block.
        /// </summary>
        /// <param name="inSize">Size of the in.</param>
        /// <param name="outSize">Size of the out.</param>
        /// <param name="finished">if set to <c>true</c> [finished].</param>
        public void CodeOneBlock(out Int64 inSize, out Int64 outSize, out bool finished)
		{
			inSize = 0;
			outSize = 0;
			finished = true;

			if (_inStream != null)
			{
				_matchFinder.SetStream(_inStream);
				_matchFinder.Init();
				_needReleaseMFStream = true;
				_inStream = null;
			}

			if (_finished)
				return;
			_finished = true;


			Int64 progressPosValuePrev = nowPos64;
			if (nowPos64 == 0)
			{
				if (_matchFinder.GetNumAvailableBytes() == 0)
				{
					Flush((UInt32)nowPos64);
					return;
				}
				UInt32 len, numDistancePairs; // it's not used
				ReadMatchDistances(out len, out numDistancePairs);
				UInt32 posState = (UInt32)(nowPos64) & _posStateMask;
				_isMatch[(_state.Index << Base.kNumPosStatesBitsMax) + posState].Encode(_rangeEncoder, 0);
				_state.UpdateChar();
				Byte curByte = _matchFinder.GetIndexByte((Int32)(0 - _additionalOffset));
				_literalEncoder.GetSubCoder((UInt32)(nowPos64), _previousByte).Encode(_rangeEncoder, curByte);
				_previousByte = curByte;
				_additionalOffset--;
				nowPos64++;
			}
			if (_matchFinder.GetNumAvailableBytes() == 0)
			{
				Flush((UInt32)nowPos64);
				return;
			}
			while (true)
			{
				UInt32 pos;
				UInt32 len = GetOptimum((UInt32)nowPos64, out pos);
				
				UInt32 posState = ((UInt32)nowPos64) & _posStateMask;
				UInt32 complexState = (_state.Index << Base.kNumPosStatesBitsMax) + posState;
				if (len == 1 && pos == 0xFFFFFFFF)
				{
					_isMatch[complexState].Encode(_rangeEncoder, 0);
					Byte curByte = _matchFinder.GetIndexByte((Int32)(0 - _additionalOffset));
					LiteralEncoder.Encoder2 subCoder = _literalEncoder.GetSubCoder((UInt32)nowPos64, _previousByte);
					if (!_state.IsCharState())
					{
						Byte matchByte = _matchFinder.GetIndexByte((Int32)(0 - _repDistances[0] - 1 - _additionalOffset));
						subCoder.EncodeMatched(_rangeEncoder, matchByte, curByte);
					}
					else
						subCoder.Encode(_rangeEncoder, curByte);
					_previousByte = curByte;
					_state.UpdateChar();
				}
				else
				{
					_isMatch[complexState].Encode(_rangeEncoder, 1);
					if (pos < Base.kNumRepDistances)
					{
						_isRep[_state.Index].Encode(_rangeEncoder, 1);
						if (pos == 0)
						{
							_isRepG0[_state.Index].Encode(_rangeEncoder, 0);
							if (len == 1)
								_isRep0Long[complexState].Encode(_rangeEncoder, 0);
							else
								_isRep0Long[complexState].Encode(_rangeEncoder, 1);
						}
						else
						{
							_isRepG0[_state.Index].Encode(_rangeEncoder, 1);
							if (pos == 1)
								_isRepG1[_state.Index].Encode(_rangeEncoder, 0);
							else
							{
								_isRepG1[_state.Index].Encode(_rangeEncoder, 1);
								_isRepG2[_state.Index].Encode(_rangeEncoder, pos - 2);
							}
						}
						if (len == 1)
							_state.UpdateShortRep();
						else
						{
							_repMatchLenEncoder.Encode(_rangeEncoder, len - Base.kMatchMinLen, posState);
							_state.UpdateRep();
						}
						UInt32 distance = _repDistances[pos];
						if (pos != 0)
						{
							for (UInt32 i = pos; i >= 1; i--)
								_repDistances[i] = _repDistances[i - 1];
							_repDistances[0] = distance;
						}
					}
					else
					{
						_isRep[_state.Index].Encode(_rangeEncoder, 0);
						_state.UpdateMatch();
						_lenEncoder.Encode(_rangeEncoder, len - Base.kMatchMinLen, posState);
						pos -= Base.kNumRepDistances;
						UInt32 posSlot = GetPosSlot(pos);
						UInt32 lenToPosState = Base.GetLenToPosState(len);
						_posSlotEncoder[lenToPosState].Encode(_rangeEncoder, posSlot);

						if (posSlot >= Base.kStartPosModelIndex)
						{
							int footerBits = (int)((posSlot >> 1) - 1);
							UInt32 baseVal = ((2 | (posSlot & 1)) << footerBits);
							UInt32 posReduced = pos - baseVal;

							if (posSlot < Base.kEndPosModelIndex)
								RangeCoder.BitTreeEncoder.ReverseEncode(_posEncoders,
										baseVal - posSlot - 1, _rangeEncoder, footerBits, posReduced);
							else
							{
								_rangeEncoder.EncodeDirectBits(posReduced >> Base.kNumAlignBits, footerBits - Base.kNumAlignBits);
								_posAlignEncoder.ReverseEncode(_rangeEncoder, posReduced & Base.kAlignMask);
								_alignPriceCount++;
							}
						}
						UInt32 distance = pos;
						for (UInt32 i = Base.kNumRepDistances - 1; i >= 1; i--)
							_repDistances[i] = _repDistances[i - 1];
						_repDistances[0] = distance;
						_matchPriceCount++;
					}
					_previousByte = _matchFinder.GetIndexByte((Int32)(len - 1 - _additionalOffset));
				}
				_additionalOffset -= len;
				nowPos64 += len;
				if (_additionalOffset == 0)
				{
					// if (!_fastMode)
					if (_matchPriceCount >= (1 << 7))
						FillDistancesPrices();
					if (_alignPriceCount >= Base.kAlignTableSize)
						FillAlignPrices();
					inSize = nowPos64;
					outSize = _rangeEncoder.GetProcessedSizeAdd();
					if (_matchFinder.GetNumAvailableBytes() == 0)
					{
						Flush((UInt32)nowPos64);
						return;
					}

					if (nowPos64 - progressPosValuePrev >= (1 << 12))
					{
						_finished = false;
						finished = false;
						return;
					}
				}
			}
		}

        /// <summary>
        /// Releases the mf stream.
        /// </summary>
        void ReleaseMFStream()
		{
			if (_matchFinder != null && _needReleaseMFStream)
			{
				_matchFinder.ReleaseStream();
				_needReleaseMFStream = false;
			}
		}

        /// <summary>
        /// Sets the out stream.
        /// </summary>
        /// <param name="outStream">The out stream.</param>
        void SetOutStream(System.IO.Stream outStream) { _rangeEncoder.SetStream(outStream); }
        /// <summary>
        /// Releases the out stream.
        /// </summary>
        void ReleaseOutStream() { _rangeEncoder.ReleaseStream(); }

        /// <summary>
        /// Releases the streams.
        /// </summary>
        void ReleaseStreams()
		{
			ReleaseMFStream();
			ReleaseOutStream();
		}

        /// <summary>
        /// Sets the streams.
        /// </summary>
        /// <param name="inStream">The in stream.</param>
        /// <param name="outStream">The out stream.</param>
        /// <param name="inSize">Size of the in.</param>
        /// <param name="outSize">Size of the out.</param>
        void SetStreams(System.IO.Stream inStream, System.IO.Stream outStream,
				Int64 inSize, Int64 outSize)
		{
			_inStream = inStream;
			_finished = false;
			Create();
			SetOutStream(outStream);
			Init();

			// if (!_fastMode)
			{
				FillDistancesPrices();
				FillAlignPrices();
			}

			_lenEncoder.SetTableSize(_numFastBytes + 1 - Base.kMatchMinLen);
			_lenEncoder.UpdateTables((UInt32)1 << _posStateBits);
			_repMatchLenEncoder.SetTableSize(_numFastBytes + 1 - Base.kMatchMinLen);
			_repMatchLenEncoder.UpdateTables((UInt32)1 << _posStateBits);

			nowPos64 = 0;
		}


        /// <summary>
        /// Codes streams.
        /// </summary>
        /// <param name="inStream">input Stream.</param>
        /// <param name="outStream">output Stream.</param>
        /// <param name="inSize">input Size. -1 if unknown.</param>
        /// <param name="outSize">output Size. -1 if unknown.</param>
        /// <param name="progress">callback progress reference.</param>
        public void Code(System.IO.Stream inStream, System.IO.Stream outStream,
			Int64 inSize, Int64 outSize, ICodeProgress progress)
		{
			_needReleaseMFStream = false;
			try
			{
				SetStreams(inStream, outStream, inSize, outSize);
				while (true)
				{
					Int64 processedInSize;
					Int64 processedOutSize;
					bool finished;
					CodeOneBlock(out processedInSize, out processedOutSize, out finished);
					if (finished)
						return;
					if (progress != null)
					{
						progress.SetProgress(processedInSize, processedOutSize);
					}
				}
			}
			finally
			{
				ReleaseStreams();
			}
		}

        /// <summary>
        /// The k property size
        /// </summary>
        const int kPropSize = 5;
        /// <summary>
        /// The properties
        /// </summary>
        Byte[] properties = new Byte[kPropSize];

        /// <summary>
        /// Writes the coder properties.
        /// </summary>
        /// <param name="outStream">The out stream.</param>
        public void WriteCoderProperties(System.IO.Stream outStream)
		{
			properties[0] = (Byte)((_posStateBits * 5 + _numLiteralPosStateBits) * 9 + _numLiteralContextBits);
			for (int i = 0; i < 4; i++)
				properties[1 + i] = (Byte)(_dictionarySize >> (8 * i));
			outStream.Write(properties, 0, kPropSize);
		}

        /// <summary>
        /// The temporary prices
        /// </summary>
        UInt32[] tempPrices = new UInt32[Base.kNumFullDistances];
        /// <summary>
        /// The match price count
        /// </summary>
        UInt32 _matchPriceCount;

        /// <summary>
        /// Fills the distances prices.
        /// </summary>
        void FillDistancesPrices()
		{
			for (UInt32 i = Base.kStartPosModelIndex; i < Base.kNumFullDistances; i++)
			{ 
				UInt32 posSlot = GetPosSlot(i);
				int footerBits = (int)((posSlot >> 1) - 1);
				UInt32 baseVal = ((2 | (posSlot & 1)) << footerBits);
				tempPrices[i] = BitTreeEncoder.ReverseGetPrice(_posEncoders, 
					baseVal - posSlot - 1, footerBits, i - baseVal);
			}

			for (UInt32 lenToPosState = 0; lenToPosState < Base.kNumLenToPosStates; lenToPosState++)
			{
				UInt32 posSlot;
				RangeCoder.BitTreeEncoder encoder = _posSlotEncoder[lenToPosState];
			
				UInt32 st = (lenToPosState << Base.kNumPosSlotBits);
				for (posSlot = 0; posSlot < _distTableSize; posSlot++)
					_posSlotPrices[st + posSlot] = encoder.GetPrice(posSlot);
				for (posSlot = Base.kEndPosModelIndex; posSlot < _distTableSize; posSlot++)
					_posSlotPrices[st + posSlot] += ((((posSlot >> 1) - 1) - Base.kNumAlignBits) << RangeCoder.BitEncoder.kNumBitPriceShiftBits);

				UInt32 st2 = lenToPosState * Base.kNumFullDistances;
				UInt32 i;
				for (i = 0; i < Base.kStartPosModelIndex; i++)
					_distancesPrices[st2 + i] = _posSlotPrices[st + i];
				for (; i < Base.kNumFullDistances; i++)
					_distancesPrices[st2 + i] = _posSlotPrices[st + GetPosSlot(i)] + tempPrices[i];
			}
			_matchPriceCount = 0;
		}

        /// <summary>
        /// Fills the align prices.
        /// </summary>
        void FillAlignPrices()
		{
			for (UInt32 i = 0; i < Base.kAlignTableSize; i++)
				_alignPrices[i] = _posAlignEncoder.ReverseGetPrice(i);
			_alignPriceCount = 0;
		}


        /// <summary>
        /// The k match finder i ds
        /// </summary>
        static string[] kMatchFinderIDs = 
		{
			"BT2",
			"BT4",
		};

        /// <summary>
        /// Finds the match finder.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>System.Int32.</returns>
        static int FindMatchFinder(string s)
		{
			for (int m = 0; m < kMatchFinderIDs.Length; m++)
				if (s == kMatchFinderIDs[m])
					return m;
			return -1;
		}

        /// <summary>
        /// Sets the coder properties.
        /// </summary>
        /// <param name="propIDs">The property i ds.</param>
        /// <param name="properties">The properties.</param>
        /// <exception cref="InvalidParamException">
        /// </exception>
        public void SetCoderProperties(CoderPropID[] propIDs, object[] properties)
		{
			for (UInt32 i = 0; i < properties.Length; i++)
			{
				object prop = properties[i];
				switch (propIDs[i])
				{
					case CoderPropID.NumFastBytes:
					{
						if (!(prop is Int32))
							throw new InvalidParamException();
						Int32 numFastBytes = (Int32)prop;
						if (numFastBytes < 5 || numFastBytes > Base.kMatchMaxLen)
							throw new InvalidParamException();
						_numFastBytes = (UInt32)numFastBytes;
						break;
					}
					case CoderPropID.Algorithm:
					{
						/*
						if (!(prop is Int32))
							throw new InvalidParamException();
						Int32 maximize = (Int32)prop;
						_fastMode = (maximize == 0);
						_maxMode = (maximize >= 2);
						*/
						break;
					}
					case CoderPropID.MatchFinder:
					{
						if (!(prop is String))
							throw new InvalidParamException();
						EMatchFinderType matchFinderIndexPrev = _matchFinderType;
						int m = FindMatchFinder(((string)prop).ToUpper());
						if (m < 0)
							throw new InvalidParamException();
						_matchFinderType = (EMatchFinderType)m;
						if (_matchFinder != null && matchFinderIndexPrev != _matchFinderType)
							{
							_dictionarySizePrev = 0xFFFFFFFF;
							_matchFinder = null;
							}
						break;
					}
					case CoderPropID.DictionarySize:
					{
						const int kDicLogSizeMaxCompress = 30;
						if (!(prop is Int32))
							throw new InvalidParamException(); ;
						Int32 dictionarySize = (Int32)prop;
						if (dictionarySize < (UInt32)(1 << Base.kDicLogSizeMin) ||
							dictionarySize > (UInt32)(1 << kDicLogSizeMaxCompress))
							throw new InvalidParamException();
						_dictionarySize = (UInt32)dictionarySize;
						int dicLogSize;
						for (dicLogSize = 0; dicLogSize < (UInt32)kDicLogSizeMaxCompress; dicLogSize++)
							if (dictionarySize <= ((UInt32)(1) << dicLogSize))
								break;
						_distTableSize = (UInt32)dicLogSize * 2;
						break;
					}
					case CoderPropID.PosStateBits:
					{
						if (!(prop is Int32))
							throw new InvalidParamException();
						Int32 v = (Int32)prop;
						if (v < 0 || v > (UInt32)Base.kNumPosStatesBitsEncodingMax)
							throw new InvalidParamException();
						_posStateBits = (int)v;
						_posStateMask = (((UInt32)1) << (int)_posStateBits) - 1;
						break;
					}
					case CoderPropID.LitPosBits:
					{
						if (!(prop is Int32))
							throw new InvalidParamException();
						Int32 v = (Int32)prop;
						if (v < 0 || v > (UInt32)Base.kNumLitPosStatesBitsEncodingMax)
							throw new InvalidParamException();
						_numLiteralPosStateBits = (int)v;
						break;
					}
					case CoderPropID.LitContextBits:
					{
						if (!(prop is Int32))
							throw new InvalidParamException();
						Int32 v = (Int32)prop;
						if (v < 0 || v > (UInt32)Base.kNumLitContextBitsMax)
							throw new InvalidParamException(); ;
						_numLiteralContextBits = (int)v;
						break;
					}
					case CoderPropID.EndMarker:
					{
						if (!(prop is Boolean))
							throw new InvalidParamException();
						SetWriteEndMarkerMode((Boolean)prop);
						break;
					}
					default:
						throw new InvalidParamException();
				}
			}
		}
	}
}
