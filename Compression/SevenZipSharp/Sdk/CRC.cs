// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="CRC.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
