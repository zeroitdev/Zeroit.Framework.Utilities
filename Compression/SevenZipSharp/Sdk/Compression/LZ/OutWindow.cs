// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="OutWindow.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.SevenZip.Sdk.Compression.LZ
{
  internal class OutWindow
  {
    private byte[] _buffer;
    private uint _pos;
    private Stream _stream;
    private uint _streamPos;
    private uint _windowSize;
    public uint TrainSize;

    public void Create(uint windowSize)
    {
      if ((int) this._windowSize != (int) windowSize)
        this._buffer = new byte[ windowSize];
      this._windowSize = windowSize;
      this._pos = 0U;
      this._streamPos = 0U;
    }

    public void Init(Stream stream, bool solid)
    {
      this.ReleaseStream();
      this._stream = stream;
      if (solid)
        return;
      this._streamPos = 0U;
      this._pos = 0U;
      this.TrainSize = 0U;
    }

    public bool Train(Stream stream)
    {
      long length = stream.Length;
      uint num1 = length < (long) this._windowSize ? (uint) length : this._windowSize;
      this.TrainSize = num1;
      stream.Position = length - (long) num1;
      this._streamPos = this._pos = 0U;
      while (num1 > 0U)
      {
        uint num2 = this._windowSize - this._pos;
        if (num1 < num2)
          num2 = num1;
        int num3 = stream.Read(this._buffer, (int) this._pos, (int) num2);
        if (num3 == 0)
          return false;
        num1 -= (uint) num3;
        this._pos += (uint) num3;
        this._streamPos += (uint) num3;
        if ((int) this._pos == (int) this._windowSize)
          this._streamPos = this._pos = 0U;
      }
      return true;
    }

    public void ReleaseStream()
    {
      this.Flush();
      this._stream = (Stream) null;
    }

    public void Flush()
    {
      uint num = this._pos - this._streamPos;
      if (num == 0U)
        return;
      this._stream.Write(this._buffer, (int) this._streamPos, (int) num);
      if (this._pos >= this._windowSize)
        this._pos = 0U;
      this._streamPos = this._pos;
    }

    public void CopyBlock(uint distance, uint len)
    {
      uint num = (uint) ((int) this._pos - (int) distance - 1);
      if (num >= this._windowSize)
        num += this._windowSize;
      for (; len > 0U; --len)
      {
        if (num >= this._windowSize)
          num = 0U;
        this._buffer[ this._pos++] = this._buffer[ num++];
        if (this._pos >= this._windowSize)
          this.Flush();
      }
    }

    public void PutByte(byte b)
    {
      this._buffer[ this._pos++] = b;
      if (this._pos < this._windowSize)
        return;
      this.Flush();
    }

    public byte GetByte(uint distance)
    {
      uint num = (uint) ((int) this._pos - (int) distance - 1);
      if (num >= this._windowSize)
        num += this._windowSize;
      return this._buffer[ num];
    }
  }
}
