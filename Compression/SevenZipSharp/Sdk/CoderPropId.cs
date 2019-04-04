// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="CoderPropId.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Zeroit.Framework.Utilities.SevenZip.Sdk
{
  public enum CoderPropId
  {
    DefaultProp = 0,
    DictionarySize = 1,
    UsedMemorySize = 2,
    Order = 3,
    BlockSize = 4,
    PosStateBits = 5,
    LitContextBits = 6,
    LitPosBits = 7,
    NumFastBytes = 8,
    MatchFinder = 9,
    MatchFinderCycles = 10, // 0x0000000A
    NumPasses = 11, // 0x0000000B
    Algorithm = 12, // 0x0000000C
    NumThreads = 13, // 0x0000000D
    EndMarker = 1168, // 0x00000490
  }
}
