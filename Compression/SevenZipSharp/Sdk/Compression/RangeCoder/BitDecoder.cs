// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="BitDecoder.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Zeroit.Framework.Utilities.SevenZip.Sdk.Compression.RangeCoder
{
  internal struct BitDecoder
  {
    public const uint kBitModelTotal = 2048;
    public const int kNumBitModelTotalBits = 11;
    private const int kNumMoveBits = 5;
    private uint Prob;

    public void Init()
    {
      this.Prob = 1024U;
    }

    public uint Decode(Decoder rangeDecoder)
    {
      uint num = (rangeDecoder.Range >> 11) * this.Prob;
      if (rangeDecoder.Code < num)
      {
        rangeDecoder.Range = num;
        this.Prob += 2048U - this.Prob >> 5;
        if (rangeDecoder.Range < 16777216U)
        {
          rangeDecoder.Code = rangeDecoder.Code << 8 | (uint) (byte) rangeDecoder.Stream.ReadByte();
          rangeDecoder.Range <<= 8;
        }
        return 0;
      }
      rangeDecoder.Range -= num;
      rangeDecoder.Code -= num;
      this.Prob -= this.Prob >> 5;
      if (rangeDecoder.Range < 16777216U)
      {
        rangeDecoder.Code = rangeDecoder.Code << 8 | (uint) (byte) rangeDecoder.Stream.ReadByte();
        rangeDecoder.Range <<= 8;
      }
      return 1;
    }
  }
}
