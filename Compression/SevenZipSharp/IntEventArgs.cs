// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="IntEventArgs.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace Zeroit.Framework.Utilities.SevenZip
{
  public sealed class IntEventArgs : EventArgs
  {
    private readonly int _Value;

    public IntEventArgs(int value)
    {
      this._Value = value;
    }

    public int Value
    {
      get
      {
        return this._Value;
      }
    }
  }
}
