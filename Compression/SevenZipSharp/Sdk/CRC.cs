// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="CRC.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.SevenZip.Sdk
{
  internal class CRC
  {
    private uint _value = uint.MaxValue;
    public static readonly uint[] Table = new uint[256];

    static CRC()
    {
      for (uint index1 = 0; index1 < 256U; ++index1)
      {
        uint num = index1;
        for (int index2 = 0; index2 < 8; ++index2)
        {
          if (((int) num & 1) != 0)
            num = num >> 1 ^ 3988292384U;
          else
            num >>= 1;
        }
        CRC.Table[index1] = num;
      }
    }

    public void Init()
    {
      this._value = uint.MaxValue;
    }

    public void UpdateByte(byte b)
    {
      this._value = CRC.Table[(int) (byte) this._value ^ (int) b] ^ this._value >> 8;
    }

    public void Update(byte[] data, uint offset, uint size)
    {
      for (uint index = 0; index < size; ++index)
        this._value = CRC.Table[(int) (byte) this._value ^ (int) data[(offset + index)]] ^ this._value >> 8;
    }

    public uint GetDigest()
    {
      return this._value ^ uint.MaxValue;
    }

    private static uint CalculateDigest(byte[] data, uint offset, uint size)
    {
      CRC crc = new CRC();
      crc.Update(data, offset, size);
      return crc.GetDigest();
    }

    private static bool VerifyDigest(uint digest, byte[] data, uint offset, uint size)
    {
      return (int) CRC.CalculateDigest(data, offset, size) == (int) digest;
    }
  }
}
