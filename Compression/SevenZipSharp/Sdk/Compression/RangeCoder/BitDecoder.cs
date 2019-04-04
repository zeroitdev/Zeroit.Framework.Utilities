// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="BitDecoder.cs" company="Zeroit Dev Technologies">
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
