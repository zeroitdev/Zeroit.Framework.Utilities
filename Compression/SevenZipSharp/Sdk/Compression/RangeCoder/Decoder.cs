// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="Decoder.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.IO;

namespace Zeroit.Framework.Utilities.SevenZip.Sdk.Compression.RangeCoder
{
  internal class Decoder
  {
    public const uint kTopValue = 16777216;
    public uint Code;
    public uint Range;
    public Stream Stream;

    public void Init(Stream stream)
    {
      this.Stream = stream;
      this.Code = 0U;
      this.Range = uint.MaxValue;
      for (int index = 0; index < 5; ++index)
        this.Code = this.Code << 8 | (uint) (byte) this.Stream.ReadByte();
    }

    public void ReleaseStream()
    {
      this.Stream = (Stream) null;
    }

    public uint DecodeDirectBits(int numTotalBits)
    {
      uint range = this.Range;
      uint num1 = this.Code;
      uint num2 = 0;
      for (int index = numTotalBits; index > 0; --index)
      {
        range >>= 1;
        uint num3 = num1 - range >> 31;
        num1 -= range & num3 - 1U;
        num2 = (uint) ((int) num2 << 1 | 1 - (int) num3);
        if (range < 16777216U)
        {
          num1 = num1 << 8 | (uint) (byte) this.Stream.ReadByte();
          range <<= 8;
        }
      }
      this.Range = range;
      this.Code = num1;
      return num2;
    }
  }
}
