// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="OutMultiStreamWrapper.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.SevenZip
{
  internal sealed class OutMultiStreamWrapper : MultiStreamWrapper, ISequentialOutStream, IOutStream
  {
    private readonly string _ArchiveName;
    private readonly int _VolumeSize;
    private long _OverallLength;

    public OutMultiStreamWrapper(string archiveName, int volumeSize)
      : base(true)
    {
      this._ArchiveName = archiveName;
      this._VolumeSize = volumeSize;
      this.CurrentStream = -1;
      this.NewVolumeStream();
    }

    public int SetSize(long newSize)
    {
      return 0;
    }

    public int Write(byte[] data, uint size, IntPtr processedSize)
    {
      int offset = 0;
      int val = (int) size;
      this.Position += (long) size;
      this._OverallLength = Math.Max(this.Position + 1L, this._OverallLength);
      while ((long) size > (long) this._VolumeSize - this.Streams[this.CurrentStream].Position)
      {
        int count = (int) ((long) this._VolumeSize - this.Streams[this.CurrentStream].Position);
        this.Streams[this.CurrentStream].Write(data, offset, count);
        size -= (uint) count;
        offset += count;
        this.NewVolumeStream();
      }
      this.Streams[this.CurrentStream].Write(data, offset, (int) size);
      if (processedSize != IntPtr.Zero)
        Marshal.WriteInt32(processedSize, val);
      return 0;
    }

    public override void Dispose()
    {
      int index = this.Streams.Count - 1;
      this.Streams[index].SetLength(index > 0 ? this.Streams[index].Position : this._OverallLength);
      base.Dispose();
    }

    private void NewVolumeStream()
    {
      ++this.CurrentStream;
      this.Streams.Add((Stream) File.Create(this._ArchiveName + MultiStreamWrapper.VolumeNumber(this.CurrentStream + 1)));
      this.Streams[this.CurrentStream].SetLength((long) this._VolumeSize);
      this.StreamOffsets.Add(this.CurrentStream, new KeyValuePair<long, long>(0L, (long) (this._VolumeSize - 1)));
    }
  }
}
