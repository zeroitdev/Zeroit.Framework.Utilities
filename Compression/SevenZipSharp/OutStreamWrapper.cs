// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="OutStreamWrapper.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.SevenZip
{
  internal sealed class OutStreamWrapper : StreamWrapper, ISequentialOutStream, IOutStream
  {
    public OutStreamWrapper(Stream baseStream, string fileName, DateTime time, bool disposeStream)
      : base(baseStream, fileName, time, disposeStream)
    {
    }

    public OutStreamWrapper(Stream baseStream, bool disposeStream)
      : base(baseStream, disposeStream)
    {
    }

    public int SetSize(long newSize)
    {
      this.BaseStream.SetLength(newSize);
      return 0;
    }

    public int Write(byte[] data, uint size, IntPtr processedSize)
    {
      this.BaseStream.Write(data, 0, (int) size);
      if (processedSize != IntPtr.Zero)
        Marshal.WriteInt32(processedSize, (int) size);
      this.OnBytesWritten(new IntEventArgs((int) size));
      return 0;
    }

    public event EventHandler<IntEventArgs> BytesWritten;

    private void OnBytesWritten(IntEventArgs e)
    {
      if (this.BytesWritten == null)
        return;
      this.BytesWritten((object) this, e);
    }
  }
}
