// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="Formats.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.IO;

namespace Zeroit.Framework.Utilities.SevenZip
{
  public static class Formats
  {
    internal static readonly Dictionary<InArchiveFormat, Guid> InFormatGuids = new Dictionary<InArchiveFormat, Guid>(20) { { InArchiveFormat.SevenZip, new Guid("23170f69-40c1-278a-1000-000110070000") }, {
      InArchiveFormat.Arj,
      new Guid("23170f69-40c1-278a-1000-000110040000")
    }, {
      InArchiveFormat.BZip2,
      new Guid("23170f69-40c1-278a-1000-000110020000")
    }, {
      InArchiveFormat.Cab,
      new Guid("23170f69-40c1-278a-1000-000110080000")
    }, {
      InArchiveFormat.Chm,
      new Guid("23170f69-40c1-278a-1000-000110e90000")
    }, {
      InArchiveFormat.Compound,
      new Guid("23170f69-40c1-278a-1000-000110e50000")
    }, {
      InArchiveFormat.Cpio,
      new Guid("23170f69-40c1-278a-1000-000110ed0000")
    }, {
      InArchiveFormat.Deb,
      new Guid("23170f69-40c1-278a-1000-000110ec0000")
    }, {
      InArchiveFormat.GZip,
      new Guid("23170f69-40c1-278a-1000-000110ef0000")
    }, {
      InArchiveFormat.Iso,
      new Guid("23170f69-40c1-278a-1000-000110e70000")
    }, { InArchiveFormat.Lzh, new Guid("23170f69-40c1-278a-1000-000110060000") }, {
      InArchiveFormat.Lzma,
      new Guid("23170f69-40c1-278a-1000-0001100a0000")
    }, {
      InArchiveFormat.Nsis,
      new Guid("23170f69-40c1-278a-1000-000110090000")
    }, {
      InArchiveFormat.Rar,
      new Guid("23170f69-40c1-278a-1000-000110030000")
    }, {
      InArchiveFormat.Rpm,
      new Guid("23170f69-40c1-278a-1000-000110eb0000")
    }, {
      InArchiveFormat.Split,
      new Guid("23170f69-40c1-278a-1000-000110ea0000")
    }, {
      InArchiveFormat.Tar,
      new Guid("23170f69-40c1-278a-1000-000110ee0000")
    }, {
      InArchiveFormat.Wim,
      new Guid("23170f69-40c1-278a-1000-000110e60000")
    }, {
      InArchiveFormat.Lzw,
      new Guid("23170f69-40c1-278a-1000-000110050000")
    }, {
      InArchiveFormat.Zip,
      new Guid("23170f69-40c1-278a-1000-000110010000")
    }, {
      InArchiveFormat.Udf,
      new Guid("23170f69-40c1-278a-1000-000110E00000")
    }, {
      InArchiveFormat.Xar,
      new Guid("23170f69-40c1-278a-1000-000110E10000")
    }, { InArchiveFormat.Mub, new Guid("23170f69-40c1-278a-1000-000110E20000") }, {
      InArchiveFormat.Hfs,
      new Guid("23170f69-40c1-278a-1000-000110E30000")
    }, {
      InArchiveFormat.Dmg,
      new Guid("23170f69-40c1-278a-1000-000110E40000")
    } };
    internal static readonly Dictionary<OutArchiveFormat, Guid> OutFormatGuids = new Dictionary<OutArchiveFormat, Guid>(2) { { OutArchiveFormat.SevenZip, new Guid("23170f69-40c1-278a-1000-000110070000") }, { OutArchiveFormat.Zip, new Guid("23170f69-40c1-278a-1000-000110010000") }, { OutArchiveFormat.BZip2, new Guid("23170f69-40c1-278a-1000-000110020000") }, { OutArchiveFormat.GZip, new Guid("23170f69-40c1-278a-1000-000110ef0000") }, { OutArchiveFormat.Tar, new Guid("23170f69-40c1-278a-1000-000110ee0000") } };
    internal static readonly Dictionary<CompressionMethod, string> MethodNames = new Dictionary<CompressionMethod, string>(6) { { CompressionMethod.Copy, "Copy" }, { CompressionMethod.Deflate, "Deflate" }, { CompressionMethod.Deflate64, "Deflate64" }, { CompressionMethod.Lzma, "LZMA" }, { CompressionMethod.Ppmd, "PPMd" }, { CompressionMethod.BZip2, "BZip2" } };
    internal static readonly Dictionary<OutArchiveFormat, InArchiveFormat> InForOutFormats = new Dictionary<OutArchiveFormat, InArchiveFormat>(6) { { OutArchiveFormat.SevenZip, InArchiveFormat.SevenZip }, { OutArchiveFormat.GZip, InArchiveFormat.GZip }, { OutArchiveFormat.BZip2, InArchiveFormat.BZip2 }, { OutArchiveFormat.Tar, InArchiveFormat.Tar }, { OutArchiveFormat.XZ, InArchiveFormat.XZ }, { OutArchiveFormat.Zip, InArchiveFormat.Zip } };
    private static readonly Dictionary<string, InArchiveFormat> InExtensionFormats = new Dictionary<string, InArchiveFormat>() { { "7z", InArchiveFormat.SevenZip }, { "gz", InArchiveFormat.GZip }, { "tar", InArchiveFormat.Tar }, { "rar", InArchiveFormat.Rar }, { "zip", InArchiveFormat.Zip }, { "lzma", InArchiveFormat.Lzma }, { "lzh", InArchiveFormat.Lzh }, { "arj", InArchiveFormat.Arj }, { "bz2", InArchiveFormat.BZip2 }, { "cab", InArchiveFormat.Cab }, { "chm", InArchiveFormat.Chm }, { "deb", InArchiveFormat.Deb }, { "iso", InArchiveFormat.Iso }, { "rpm", InArchiveFormat.Rpm }, { "wim", InArchiveFormat.Wim }, { "udf", InArchiveFormat.Udf }, { "mub", InArchiveFormat.Mub }, { "xar", InArchiveFormat.Xar }, { "hfs", InArchiveFormat.Hfs }, { "dmg", InArchiveFormat.Dmg }, { "Z", InArchiveFormat.Lzw }, { "MyCustomFormatExtension", InArchiveFormat.Zip } };
    internal static readonly Dictionary<string, InArchiveFormat> InSignatureFormats = new Dictionary<string, InArchiveFormat>() { { "37-7A-BC-AF-27-1C", InArchiveFormat.SevenZip }, { "1F-8B-08", InArchiveFormat.GZip }, { "75-73-74-61-72", InArchiveFormat.Tar }, { "52-61-72-21-1A-07-00", InArchiveFormat.Rar }, { "50-4B-03-04", InArchiveFormat.Zip }, { "5D-00-00-40-00", InArchiveFormat.Lzma }, { "2D-6C-68", InArchiveFormat.Lzh }, { "1F-9D-90", InArchiveFormat.Lzw }, { "60-EA", InArchiveFormat.Arj }, { "42-5A-68", InArchiveFormat.BZip2 }, { "4D-53-43-46", InArchiveFormat.Cab }, { "49-54-53-46", InArchiveFormat.Chm }, { "21-3C-61-72-63-68-3E-0A-64-65-62-69-61-6E-2D-62-69-6E-61-72-79", InArchiveFormat.Deb }, { "43-44-30-30-31", InArchiveFormat.Iso }, { "ED-AB-EE-DB", InArchiveFormat.Rpm }, { "4D-53-57-49-4D-00-00-00", InArchiveFormat.Wim }, { "udf", InArchiveFormat.Udf }, { "mub", InArchiveFormat.Mub }, { "78-61-72-21", InArchiveFormat.Xar }, { "hfs", InArchiveFormat.Hfs }, { "FD-37-7A-58-5A", InArchiveFormat.XZ } };

    public static InArchiveFormat FormatByFileName(string fileName, bool reportErrors)
    {
      if (string.IsNullOrEmpty(fileName) && reportErrors)
        throw new ArgumentException("File name is null or empty string!");
      string key = Path.GetExtension(fileName).Substring(1);
      if (!Formats.InExtensionFormats.ContainsKey(key) && reportErrors)
        throw new ArgumentException("Extension \"" + key + "\" is not a supported archive file name extension.");
      return Formats.InExtensionFormats[key];
    }
  }
}
