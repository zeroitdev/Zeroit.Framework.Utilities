// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="FakeOutStreamWrapper.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.SevenZip
{
  internal sealed class FakeOutStreamWrapper : ISequentialOutStream, IDisposable
  {
    public void Dispose()
    {
      GC.SuppressFinalize((object) this);
    }

    public int Write(byte[] data, uint size, IntPtr processedSize)
    {
      this.OnBytesWritten(new IntEventArgs((int) size));
      if (processedSize != IntPtr.Zero)
        Marshal.WriteInt32(processedSize, (int) size);
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
