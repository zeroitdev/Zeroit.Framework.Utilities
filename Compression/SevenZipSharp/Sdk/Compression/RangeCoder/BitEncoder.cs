// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="BitEncoder.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace Zeroit.Framework.Utilities.SevenZip.Sdk.Compression.RangeCoder
{
  internal struct BitEncoder
  {
    private static readonly uint[] ProbPrices = new uint[Convert.ToUInt32(new IntPtr(512))];
    public const uint kBitModelTotal = 2048;
    public const int kNumBitModelTotalBits = 11;
    public const int kNumBitPriceShiftBits = 6;
    private const int kNumMoveBits = 5;
    private const int kNumMoveReducingBits = 2;
    private uint Prob;

    static BitEncoder()
    {
      for (int index1 = 8; index1 >= 0; --index1)
      {
        uint num1 = (uint) (1 << 9 - index1 - 1);
        uint num2 = (uint) (1 << 9 - index1);
        for (uint index2 = num1; index2 < num2; ++index2)
          BitEncoder.ProbPrices[ index2] = (uint) (index1 << 6) + ((uint) ((int) num2 - (int) index2 << 6) >> 9 - index1 - 1);
      }
    }

    public void Init()
    {
      this.Prob = 1024U;
    }

    public void Encode(Encoder encoder, uint symbol)
    {
      uint num = (encoder.Range >> 11) * this.Prob;
      if (symbol == 0U)
      {
        encoder.Range = num;
        this.Prob += 2048U - this.Prob >> 5;
      }
      else
      {
        encoder.Low += (ulong) num;
        encoder.Range -= num;
        this.Prob -= this.Prob >> 5;
      }
      if (encoder.Range >= 16777216U)
        return;
      encoder.Range <<= 8;
      encoder.ShiftLow();
    }

    public uint GetPrice(uint symbol)
    {
      return BitEncoder.ProbPrices[(((long) (this.Prob - symbol) ^ (long) -(int) symbol) & 2047L) >> 2];
    }

    public uint GetPrice0()
    {
      return BitEncoder.ProbPrices[ (this.Prob >> 2)];
    }

    public uint GetPrice1()
    {
      return BitEncoder.ProbPrices[ (2048U - this.Prob >> 2)];
    }
  }
}
