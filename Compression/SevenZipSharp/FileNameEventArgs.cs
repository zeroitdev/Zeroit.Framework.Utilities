// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="FileNameEventArgs.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Zeroit.Framework.Utilities.SevenZip
{
  public sealed class FileNameEventArgs : PercentDoneEventArgs
  {
    private readonly string _FileName;

    public FileNameEventArgs(string fileName, byte percentDone)
      : base(percentDone)
    {
      this._FileName = fileName;
    }

    public string FileName
    {
      get
      {
        return this._FileName;
      }
    }
  }
}
