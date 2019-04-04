// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="Decoder.cs" company="Zeroit Dev Technologies">
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
