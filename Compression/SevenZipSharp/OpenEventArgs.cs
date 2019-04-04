// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="OpenEventArgs.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace Zeroit.Framework.Utilities.SevenZip
{
  public sealed class OpenEventArgs : EventArgs
  {
    private readonly ulong _TotalSize;

    [CLSCompliant(false)]
    public OpenEventArgs(ulong totalSize)
    {
      this._TotalSize = totalSize;
    }

    [CLSCompliant(false)]
    public ulong TotalSize
    {
      get
      {
        return this._TotalSize;
      }
    }
  }
}
