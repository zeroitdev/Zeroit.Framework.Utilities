// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="ArchiveFileInfo.cs" company="Zeroit Dev Technologies">
//    This program contains Utilities for all C# programming activities.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
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
