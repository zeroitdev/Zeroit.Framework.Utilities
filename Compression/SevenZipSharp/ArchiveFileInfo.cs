// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="ArchiveFileInfo.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Globalization;

namespace Zeroit.Framework.Utilities.SevenZip
{
  public struct ArchiveFileInfo
  {
    [CLSCompliant(false)]
    public int Index { get; set; }

    public string FileName { get; set; }

    public DateTime LastWriteTime { get; set; }

    public DateTime CreationTime { get; set; }

    public DateTime LastAccessTime { get; set; }

    [CLSCompliant(false)]
    public ulong Size { get; set; }

    [CLSCompliant(false)]
    public uint Crc { get; set; }

    [CLSCompliant(false)]
    public uint Attributes { get; set; }

    public bool IsDirectory { get; set; }

    public bool Encrypted { get; set; }

    public string Comment { get; set; }

    public override bool Equals(object obj)
    {
      if (!(obj is ArchiveFileInfo))
        return false;
      return this.Equals((ArchiveFileInfo) obj);
    }

    public bool Equals(ArchiveFileInfo afi)
    {
      if (afi.Index == this.Index)
        return afi.FileName == this.FileName;
      return false;
    }

    public override int GetHashCode()
    {
      return this.FileName.GetHashCode() ^ this.Index;
    }

    public override string ToString()
    {
      return "[" + this.Index.ToString((IFormatProvider) CultureInfo.CurrentCulture) + "] " + this.FileName;
    }

    public static bool operator ==(ArchiveFileInfo afi1, ArchiveFileInfo afi2)
    {
      return afi1.Equals(afi2);
    }

    public static bool operator !=(ArchiveFileInfo afi1, ArchiveFileInfo afi2)
    {
      return !afi1.Equals(afi2);
    }
  }
}
