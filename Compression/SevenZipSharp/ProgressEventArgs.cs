// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="ProgressEventArgs.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Zeroit.Framework.Utilities.SevenZip
{
  public sealed class ProgressEventArgs : PercentDoneEventArgs
  {
    private readonly byte _Delta;

    public ProgressEventArgs(byte percentDone, byte percentDelta)
      : base(percentDone)
    {
      this._Delta = percentDelta;
    }

    public byte PercentDelta
    {
      get
      {
        return this._Delta;
      }
    }
  }
}
