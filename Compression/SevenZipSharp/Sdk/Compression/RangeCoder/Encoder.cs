// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="Encoder.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.IO;

namespace Zeroit.Framework.Utilities.SevenZip.Sdk.Compression.RangeCoder
{
  internal class Encoder
  {
    public const uint kTopValue = 16777216;
    private byte _cache;
    private uint _cacheSize;
    public ulong Low;
    public uint Range;
    private long StartPosition;
    private Stream Stream;

    public void SetStream(Stream stream)
    {
      this.Stream = stream;
    }

    public void ReleaseStream()
    {
      this.Stream = (Stream) null;
    }

    public void Init()
    {
      this.StartPosition = this.Stream.Position;
      this.Low = 0UL;
      this.Range = uint.MaxValue;
      this._cacheSize = 1U;
      this._cache = (byte) 0;
    }

    public void FlushData()
    {
      for (int index = 0; index < 5; ++index)
        this.ShiftLow();
    }

    public void FlushStream()
    {
      this.Stream.Flush();
    }

    public void ShiftLow()
    {
      if ((uint) this.Low < 4278190080U || (uint) (this.Low >> 32) == 1U)
      {
        byte num = this._cache;
        do
        {
          this.Stream.WriteByte((byte) ((ulong) num + (this.Low >> 32)));
          num = byte.MaxValue;
        }
        while (--this._cacheSize != 0U);
        this._cache = (byte) ((uint) this.Low >> 24);
      }
      ++this._cacheSize;
      this.Low = (ulong) ((uint) this.Low << 8);
    }

    public void EncodeDirectBits(uint v, int numTotalBits)
    {
      for (int index = numTotalBits - 1; index >= 0; --index)
      {
        this.Range >>= 1;
        if (((int) (v >> index) & 1) == 1)
          this.Low += (ulong) this.Range;
        if (this.Range < 16777216U)
        {
          this.Range <<= 8;
          this.ShiftLow();
        }
      }
    }

    public long GetProcessedSizeAdd()
    {
      return (long) this._cacheSize + this.Stream.Position - this.StartPosition + 4L;
    }
  }
}
