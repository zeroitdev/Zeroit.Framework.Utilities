// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="FileInfoEventArgs.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Zeroit.Framework.Utilities.SevenZip
{
  public sealed class FileInfoEventArgs : PercentDoneEventArgs
  {
    private readonly ArchiveFileInfo _FileInfo;

    public FileInfoEventArgs(ArchiveFileInfo fileInfo, byte percentDone)
      : base(percentDone)
    {
      this._FileInfo = fileInfo;
    }

    public ArchiveFileInfo FileInfo
    {
      get
      {
        return this._FileInfo;
      }
    }
  }
}
