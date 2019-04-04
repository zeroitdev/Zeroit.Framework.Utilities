// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-22-2018
// ***********************************************************************
// <copyright file="LzmaBase.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Zeroit.Framework.Utilities.IO.Compression.SevenZip.Compression.LZMA
{
    /// <summary>
    /// Class Base.
    /// </summary>
    internal abstract class Base
	{
        /// <summary>
        /// The k number rep distances
        /// </summary>
        public const uint kNumRepDistances = 4;
        /// <summary>
        /// The k number states
        /// </summary>
        public const uint kNumStates = 12;

        // static byte []kLiteralNextStates  = {0, 0, 0, 0, 1, 2, 3, 4,  5,  6,   4, 5};
        // static byte []kMatchNextStates    = {7, 7, 7, 7, 7, 7, 7, 10, 10, 10, 10, 10};
        // static byte []kRepNextStates      = {8, 8, 8, 8, 8, 8, 8, 11, 11, 11, 11, 11};
        // static byte []kShortRepNextStates = {9, 9, 9, 9, 9, 9, 9, 11, 11, 11, 11, 11};

        /// <summary>
        /// Struct State
        /// </summary>
        public struct State
		{
            /// <summary>
            /// The index
            /// </summary>
            public uint Index;
            /// <summary>
            /// Initializes this instance.
            /// </summary>
            public void Init() { Index = 0; }
            /// <summary>
            /// Updates the character.
            /// </summary>
            public void UpdateChar()
			{
				if (Index < 4) Index = 0;
				else if (Index < 10) Index -= 3;
				else Index -= 6;
			}
            /// <summary>
            /// Updates the match.
            /// </summary>
            public void UpdateMatch() { Index = (uint)(Index < 7 ? 7 : 10); }
            /// <summary>
            /// Updates the rep.
            /// </summary>
            public void UpdateRep() { Index = (uint)(Index < 7 ? 8 : 11); }
            /// <summary>
            /// Updates the short rep.
            /// </summary>
            public void UpdateShortRep() { Index = (uint)(Index < 7 ? 9 : 11); }
            /// <summary>
            /// Determines whether [is character state].
            /// </summary>
            /// <returns><c>true</c> if [is character state]; otherwise, <c>false</c>.</returns>
            public bool IsCharState() { return Index < 7; }
		}

        /// <summary>
        /// The k number position slot bits
        /// </summary>
        public const int kNumPosSlotBits = 6;
        /// <summary>
        /// The k dic log size minimum
        /// </summary>
        public const int kDicLogSizeMin = 0;
        // public const int kDicLogSizeMax = 30;
        // public const uint kDistTableSizeMax = kDicLogSizeMax * 2;

        /// <summary>
        /// The k number length to position states bits
        /// </summary>
        public const int kNumLenToPosStatesBits = 2; // it's for speed optimization
                                                     /// <summary>
                                                     /// The k number length to position states
                                                     /// </summary>
        public const uint kNumLenToPosStates = 1 << kNumLenToPosStatesBits;

        /// <summary>
        /// The k match minimum length
        /// </summary>
        public const uint kMatchMinLen = 2;

        /// <summary>
        /// Gets the state of the length to position.
        /// </summary>
        /// <param name="len">The length.</param>
        /// <returns>System.UInt32.</returns>
        public static uint GetLenToPosState(uint len)
		{
			len -= kMatchMinLen;
			if (len < kNumLenToPosStates)
				return len;
			return (uint)(kNumLenToPosStates - 1);
		}

        /// <summary>
        /// The k number align bits
        /// </summary>
        public const int kNumAlignBits = 4;
        /// <summary>
        /// The k align table size
        /// </summary>
        public const uint kAlignTableSize = 1 << kNumAlignBits;
        /// <summary>
        /// The k align mask
        /// </summary>
        public const uint kAlignMask = (kAlignTableSize - 1);

        /// <summary>
        /// The k start position model index
        /// </summary>
        public const uint kStartPosModelIndex = 4;
        /// <summary>
        /// The k end position model index
        /// </summary>
        public const uint kEndPosModelIndex = 14;
        /// <summary>
        /// The k number position models
        /// </summary>
        public const uint kNumPosModels = kEndPosModelIndex - kStartPosModelIndex;

        /// <summary>
        /// The k number full distances
        /// </summary>
        public const uint kNumFullDistances = 1 << ((int)kEndPosModelIndex / 2);

        /// <summary>
        /// The k number lit position states bits encoding maximum
        /// </summary>
        public const uint kNumLitPosStatesBitsEncodingMax = 4;
        /// <summary>
        /// The k number lit context bits maximum
        /// </summary>
        public const uint kNumLitContextBitsMax = 8;

        /// <summary>
        /// The k number position states bits maximum
        /// </summary>
        public const int kNumPosStatesBitsMax = 4;
        /// <summary>
        /// The k number position states maximum
        /// </summary>
        public const uint kNumPosStatesMax = (1 << kNumPosStatesBitsMax);
        /// <summary>
        /// The k number position states bits encoding maximum
        /// </summary>
        public const int kNumPosStatesBitsEncodingMax = 4;
        /// <summary>
        /// The k number position states encoding maximum
        /// </summary>
        public const uint kNumPosStatesEncodingMax = (1 << kNumPosStatesBitsEncodingMax);

        /// <summary>
        /// The k number low length bits
        /// </summary>
        public const int kNumLowLenBits = 3;
        /// <summary>
        /// The k number mid length bits
        /// </summary>
        public const int kNumMidLenBits = 3;
        /// <summary>
        /// The k number high length bits
        /// </summary>
        public const int kNumHighLenBits = 8;
        /// <summary>
        /// The k number low length symbols
        /// </summary>
        public const uint kNumLowLenSymbols = 1 << kNumLowLenBits;
        /// <summary>
        /// The k number mid length symbols
        /// </summary>
        public const uint kNumMidLenSymbols = 1 << kNumMidLenBits;
        /// <summary>
        /// The k number length symbols
        /// </summary>
        public const uint kNumLenSymbols = kNumLowLenSymbols + kNumMidLenSymbols +
				(1 << kNumHighLenBits);
        /// <summary>
        /// The k match maximum length
        /// </summary>
        public const uint kMatchMaxLen = kMatchMinLen + kNumLenSymbols - 1;
	}
}
