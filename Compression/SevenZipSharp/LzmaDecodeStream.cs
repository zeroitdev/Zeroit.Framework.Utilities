// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="LzmaDecodeStream.cs" company="Zeroit Dev Technologies">
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

using Zeroit.Framework.Utilities.SevenZip.Sdk;
using Zeroit.Framework.Utilities.SevenZip.Sdk.Compression.Lzma;
using System;
using System.IO;

namespace Zeroit.Framework.Utilities.SevenZip
{
  public class LzmaDecodeStream : Stream
  {
    private readonly MemoryStream _Buffer = new MemoryStream();
    private readonly Decoder _Decoder = new Decoder();
    private readonly Stream _Input;
    private byte[] _CommonProperties;
    private bool _Error;
    private bool _FirstChunkRead;

    public LzmaDecodeStream(Stream encodedStream)
    {
      if (!encodedStream.CanRead)
        throw new ArgumentException("The specified stream can not read.", nameof (encodedStream));
      this._Input = encodedStream;
    }

    public int ChunkSize
    {
      get
      {
        return (int) this._Buffer.Length;
      }
    }

    public override bool CanRead
    {
      get
      {
        return true;
      }
    }

    public override bool CanSeek
    {
      get
      {
        return false;
      }
    }

    public override bool CanWrite
    {
      get
      {
        return false;
      }
    }

    public override long Length
    {
      get
      {
        if (this._Input.CanSeek)
          return this._Input.Length;
        return this._Buffer.Length;
      }
    }

    public override long Position
    {
      get
      {
        if (this._Input.CanSeek)
          return this._Input.Position;
        return this._Buffer.Position;
      }
      set
      {
        throw new NotSupportedException();
      }
    }

    private void ReadChunk()
    {
      long outSize;
      byte[] lzmaProperties;
      try
      {
        lzmaProperties = SevenZipExtractor.GetLzmaProperties(this._Input, out outSize);
      }
      catch (LzmaException ex)
      {
        this._Error = true;
        return;
      }
      if (!this._FirstChunkRead)
        this._CommonProperties = lzmaProperties;
      if ((int) this._CommonProperties[0] != (int) lzmaProperties[0] || (int) this._CommonProperties[1] != (int) lzmaProperties[1] || ((int) this._CommonProperties[2] != (int) lzmaProperties[2] || (int) this._CommonProperties[3] != (int) lzmaProperties[3]) || (int) this._CommonProperties[4] != (int) lzmaProperties[4])
      {
        this._Error = true;
      }
      else
      {
        if (this._Buffer.Capacity < (int) outSize)
          this._Buffer.Capacity = (int) outSize;
        this._Buffer.SetLength(outSize);
        this._Decoder.SetDecoderProperties(lzmaProperties);
        this._Buffer.Position = 0L;
        this._Decoder.Code(this._Input, (Stream) this._Buffer, 0L, outSize, (ICodeProgress) null);
        this._Buffer.Position = 0L;
      }
    }

    public override void Flush()
    {
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
      if (this._Error)
        return 0;
      if (!this._FirstChunkRead)
      {
        this.ReadChunk();
        this._FirstChunkRead = true;
      }
      int num = 0;
      while ((long) count > this._Buffer.Length - this._Buffer.Position && !this._Error)
      {
        byte[] buffer1 = new byte[this._Buffer.Length - this._Buffer.Position];
        this._Buffer.Read(buffer1, 0, buffer1.Length);
        buffer1.CopyTo((Array) buffer, offset);
        offset += buffer1.Length;
        count -= buffer1.Length;
        num += buffer1.Length;
        this.ReadChunk();
      }
      if (!this._Error)
      {
        this._Buffer.Read(buffer, offset, count);
        num += count;
      }
      return num;
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
      throw new NotSupportedException();
    }

    public override void SetLength(long value)
    {
      throw new NotSupportedException();
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
      throw new NotSupportedException();
    }
  }
}
