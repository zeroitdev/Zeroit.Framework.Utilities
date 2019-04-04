// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="InStreamWrapper.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.IO;

namespace Zeroit.Framework.Utilities.SevenZip
{
  internal sealed class InStreamWrapper : StreamWrapper, ISequentialInStream, IInStream
  {
    public InStreamWrapper(Stream baseStream, bool disposeStream)
      : base(baseStream, disposeStream)
    {
    }

    public int Read(byte[] data, uint size)
    {
      int num = 0;
      if (this.BaseStream != null)
      {
        num = this.BaseStream.Read(data, 0, (int) size);
        if (num > 0)
          this.OnBytesRead(new IntEventArgs(num));
      }
      return num;
    }

    public event EventHandler<IntEventArgs> BytesRead;

    private void OnBytesRead(IntEventArgs e)
    {
      if (this.BytesRead == null)
        return;
      this.BytesRead((object) this, e);
    }
  }
}
