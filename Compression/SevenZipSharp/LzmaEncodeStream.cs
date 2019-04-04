// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="LzmaEncodeStream.cs" company="Zeroit Dev Technologies">
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
  public class LzmaEncodeStream : Stream
  {
    private readonly MemoryStream _Buffer = new MemoryStream();
    private readonly int _BufferCapacity = 262144;
    private const int MaxBufferCapacity = 1073741824;
    private readonly bool _OwnOutput;
    private bool _Disposed;
    private Encoder _LzmaEncoder;
    private Stream _Output;

    public LzmaEncodeStream()
    {
      this._Output = (Stream) new MemoryStream();
      this._OwnOutput = true;
      this.Init();
    }

    public LzmaEncodeStream(int bufferCapacity)
    {
      this._Output = (Stream) new MemoryStream();
      this._OwnOutput = true;
      if (bufferCapacity > 1073741824)
        throw new ArgumentException("Too large capacity.", nameof (bufferCapacity));
      this._BufferCapacity = bufferCapacity;
      this.Init();
    }

    public LzmaEncodeStream(Stream outputStream)
    {
      if (!outputStream.CanWrite)
        throw new ArgumentException("The specified stream can not write.", nameof (outputStream));
      this._Output = outputStream;
      this.Init();
    }

    public LzmaEncodeStream(Stream outputStream, int bufferCapacity)
    {
      if (!outputStream.CanWrite)
        throw new ArgumentException("The specified stream can not write.", nameof (outputStream));
      this._Output = outputStream;
      if (bufferCapacity > 1073741824)
        throw new ArgumentException("Too large capacity.", nameof (bufferCapacity));
      this._BufferCapacity = bufferCapacity;
      this.Init();
    }

    public override bool CanRead
    {
      get
      {
        return false;
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
        this.DisposedCheck();
        return this._Buffer.CanWrite;
      }
    }

    public override long Length
    {
      get
      {
        this.DisposedCheck();
        if (this._Output.CanSeek)
          return this._Output.Length;
        return this._Buffer.Position;
      }
    }

    public override long Position
    {
      get
      {
        this.DisposedCheck();
        if (this._Output.CanSeek)
          return this._Output.Position;
        return this._Buffer.Position;
      }
      set
      {
        throw new NotSupportedException();
      }
    }

    private void Init()
    {
      this._Buffer.Capacity = this._BufferCapacity;
      SevenZipCompressor.LzmaDictionarySize = this._BufferCapacity;
      this._LzmaEncoder = new Encoder();
      SevenZipCompressor.WriteLzmaProperties(this._LzmaEncoder);
    }

    private void DisposedCheck()
    {
      if (this._Disposed)
        throw new ObjectDisposedException("SevenZipExtractor");
    }

    private void WriteChunk()
    {
      this._LzmaEncoder.WriteCoderProperties(this._Output);
      long position = this._Buffer.Position;
      if (this._Buffer.Length != this._Buffer.Position)
        this._Buffer.SetLength(this._Buffer.Position);
      this._Buffer.Position = 0L;
      for (int index = 0; index < 8; ++index)
        this._Output.WriteByte((byte) (position >> 8 * index));
      this._LzmaEncoder.Code((Stream) this._Buffer, this._Output, -1L, -1L, (ICodeProgress) null);
      this._Buffer.Position = 0L;
    }

    public LzmaDecodeStream ToDecodeStream()
    {
      this.DisposedCheck();
      this.Flush();
      return new LzmaDecodeStream(this._Output);
    }

    public override void Flush()
    {
      this.DisposedCheck();
      this.WriteChunk();
    }

    protected override void Dispose(bool disposing)
    {
      if (this._Disposed)
        return;
      if (disposing)
      {
        this.Flush();
        this._Buffer.Close();
        if (this._OwnOutput)
          this._Output.Dispose();
        this._Output = (Stream) null;
      }
      this._Disposed = true;
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
      this.DisposedCheck();
      throw new NotSupportedException();
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
      this.DisposedCheck();
      throw new NotSupportedException();
    }

    public override void SetLength(long value)
    {
      this.DisposedCheck();
      throw new NotSupportedException();
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
      this.DisposedCheck();
      int count1 = Math.Min(buffer.Length - offset, count);
      while (this._Buffer.Position + (long) count1 >= (long) this._BufferCapacity)
      {
        int count2 = this._BufferCapacity - (int) this._Buffer.Position;
        this._Buffer.Write(buffer, offset, count2);
        offset = count2 + offset;
        count1 -= count2;
        this.WriteChunk();
      }
      this._Buffer.Write(buffer, offset, count1);
    }
  }
}
