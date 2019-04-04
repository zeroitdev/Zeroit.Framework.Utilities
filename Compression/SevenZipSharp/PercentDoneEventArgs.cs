// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="PercentDoneEventArgs.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace Zeroit.Framework.Utilities.SevenZip
{
  public class PercentDoneEventArgs : EventArgs
  {
    private readonly byte _PercentDone;

    public PercentDoneEventArgs(byte percentDone)
    {
      if (percentDone > (byte) 100 || percentDone < (byte) 0)
        throw new ArgumentOutOfRangeException(nameof (percentDone), "The percent of finished work must be between 0 and 100.");
      this._PercentDone = percentDone;
    }

    public byte PercentDone
    {
      get
      {
        return this._PercentDone;
      }
    }

    public bool Cancel { get; set; }

    internal static byte ProducePercentDone(float doneRate)
    {
      return (byte) Math.Round((double) Math.Min(100f * doneRate, 100f), MidpointRounding.AwayFromZero);
    }
  }
}
