// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="MultiStreamWrapper.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.SevenZip
{
  internal class MultiStreamWrapper : DisposeVariableWrapper, IDisposable
  {
    protected readonly Dictionary<int, KeyValuePair<long, long>> StreamOffsets = new Dictionary<int, KeyValuePair<long, long>>();
    protected readonly List<Stream> Streams = new List<Stream>();
    protected int CurrentStream;
    protected long Position;
    protected long StreamLength;

    protected MultiStreamWrapper(bool dispose)
      : base(dispose)
    {
    }

    public long Length
    {
      get
      {
        return this.StreamLength;
      }
    }

    public virtual void Dispose()
    {
      if (this.DisposeStream)
      {
        foreach (Stream stream in this.Streams)
        {
          try
          {
            stream.Dispose();
          }
          catch (ObjectDisposedException ex)
          {
          }
        }
        this.Streams.Clear();
      }
      GC.SuppressFinalize((object) this);
    }

    protected static string VolumeNumber(int num)
    {
      if (num < 10)
        return ".00" + num.ToString((IFormatProvider) CultureInfo.InvariantCulture);
      if (num > 9 && num < 100)
        return ".0" + num.ToString((IFormatProvider) CultureInfo.InvariantCulture);
      if (num > 99 && num < 1000)
        return "." + num.ToString((IFormatProvider) CultureInfo.InvariantCulture);
      return string.Empty;
    }

    private int StreamNumberByOffset(long offset)
    {
      foreach (int key in this.StreamOffsets.Keys)
      {
        if (this.StreamOffsets[key].Key <= offset && this.StreamOffsets[key].Value >= offset)
          return key;
      }
      return -1;
    }

    public void Seek(long offset, SeekOrigin seekOrigin, IntPtr newPosition)
    {
      long offset1 = seekOrigin == SeekOrigin.Current ? this.Position + offset : offset;
      this.CurrentStream = this.StreamNumberByOffset(offset1);
      this.Position = this.StreamOffsets[this.CurrentStream].Key + this.Streams[this.CurrentStream].Seek(offset1 - this.StreamOffsets[this.CurrentStream].Key, SeekOrigin.Begin);
      if (!(newPosition != IntPtr.Zero))
        return;
      Marshal.WriteInt64(newPosition, this.Position);
    }
  }
}
