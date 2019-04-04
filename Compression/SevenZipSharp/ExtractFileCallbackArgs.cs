// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="ExtractFileCallbackArgs.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.IO;

namespace Zeroit.Framework.Utilities.SevenZip
{
  public class ExtractFileCallbackArgs : EventArgs
  {
    private readonly ArchiveFileInfo _ArchiveFileInfo;
    private Stream _ExtractToStream;

    public ExtractFileCallbackArgs(ArchiveFileInfo archiveFileInfo)
    {
      this.Reason = ExtractFileCallbackReason.Start;
      this._ArchiveFileInfo = archiveFileInfo;
    }

    public ArchiveFileInfo ArchiveFileInfo
    {
      get
      {
        return this._ArchiveFileInfo;
      }
    }

    public ExtractFileCallbackReason Reason { get; internal set; }

    public Exception Exception { get; set; }

    public bool CancelExtraction { get; set; }

    public string ExtractToFile { get; set; }

    public Stream ExtractToStream
    {
      get
      {
        return this._ExtractToStream;
      }
      set
      {
        if (this._ExtractToStream != null && !this._ExtractToStream.CanWrite)
          throw new ExtractionFailedException("The specified stream is not writable!");
        this._ExtractToStream = value;
      }
    }

    public object ObjectData { get; set; }
  }
}
