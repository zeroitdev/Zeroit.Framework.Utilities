// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="BitTreeDecoder.cs" company="Zeroit Dev Technologies">
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
  internal struct BitTreeDecoder
  {
    private readonly BitDecoder[] Models;
    private readonly int NumBitLevels;

    public BitTreeDecoder(int numBitLevels)
    {
      this.NumBitLevels = numBitLevels;
      this.Models = new BitDecoder[1 << numBitLevels];
    }

    public void Init()
    {
      for (uint index = 1; (long) index < (long) (1 << this.NumBitLevels); ++index)
        this.Models[ index].Init();
    }

    public uint Decode(Decoder rangeDecoder)
    {
      uint num = 1;
      for (int numBitLevels = this.NumBitLevels; numBitLevels > 0; --numBitLevels)
        num = (num << 1) + this.Models[ num].Decode(rangeDecoder);
      return num - (uint) (1 << this.NumBitLevels);
    }

    public uint ReverseDecode(Decoder rangeDecoder)
    {
      uint num1 = 1;
      uint num2 = 0;
      for (int index = 0; index < this.NumBitLevels; ++index)
      {
        uint num3 = this.Models[ num1].Decode(rangeDecoder);
        num1 = (num1 << 1) + num3;
        num2 |= num3 << index;
      }
      return num2;
    }

    public static uint ReverseDecode(BitDecoder[] Models, uint startIndex, Decoder rangeDecoder, int NumBitLevels)
    {
      uint num1 = 1;
      uint num2 = 0;
      for (int index = 0; index < NumBitLevels; ++index)
      {
        uint num3 = Models[ (startIndex + num1)].Decode(rangeDecoder);
        num1 = (num1 << 1) + num3;
        num2 |= num3 << index;
      }
      return num2;
    }
  }
}
