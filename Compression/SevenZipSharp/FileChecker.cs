// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="FileChecker.cs" company="Zeroit Dev Technologies">
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
using System.IO;

namespace Zeroit.Framework.Utilities.SevenZip
{
  internal static class FileChecker
  {
    private const int SignatureSize = 16;

    private static bool SpecialDetect(Stream stream, int offset, InArchiveFormat expectedFormat)
    {
      if (stream.Length > (long) (offset + 16))
      {
        byte[] buffer = new byte[16];
        int count = 16;
        int offset1 = 0;
        stream.Seek((long) offset, SeekOrigin.Begin);
        while (count > 0)
        {
          int num = stream.Read(buffer, offset1, count);
          count -= num;
          offset1 += num;
        }
        string str = BitConverter.ToString(buffer);
        foreach (string key in Formats.InSignatureFormats.Keys)
        {
          if (Formats.InSignatureFormats[key] == expectedFormat && str.StartsWith(key, StringComparison.OrdinalIgnoreCase))
            return true;
        }
      }
      return false;
    }

    public static InArchiveFormat CheckSignature(Stream stream)
    {
      if (!stream.CanRead)
        throw new ArgumentException("The stream must be readable.");
      if (stream.Length < 16L)
        throw new ArgumentException("The stream is invalid.");
      byte[] buffer = new byte[16];
      int count = 16;
      int offset = 0;
      stream.Seek(0L, SeekOrigin.Begin);
      while (count > 0)
      {
        int num = stream.Read(buffer, offset, count);
        count -= num;
        offset += num;
      }
      string str = BitConverter.ToString(buffer);
      foreach (string key in Formats.InSignatureFormats.Keys)
      {
        if (str.StartsWith(key, StringComparison.OrdinalIgnoreCase) || str.Substring(6).StartsWith(key, StringComparison.OrdinalIgnoreCase) && Formats.InSignatureFormats[key] == InArchiveFormat.Lzh)
          return Formats.InSignatureFormats[key];
      }
      try
      {
        FileChecker.SpecialDetect(stream, 257, InArchiveFormat.Tar);
      }
      catch (ArgumentException ex)
      {
      }
      if (FileChecker.SpecialDetect(stream, 32769, InArchiveFormat.Iso) || FileChecker.SpecialDetect(stream, 34817, InArchiveFormat.Iso) || FileChecker.SpecialDetect(stream, 36865, InArchiveFormat.Iso))
        return InArchiveFormat.Iso;
      throw new ArgumentException("The stream is invalid or no corresponding signature was found.");
    }

    public static InArchiveFormat CheckSignature(string fileName)
    {
      using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
      {
        try
        {
          return FileChecker.CheckSignature((Stream) fileStream);
        }
        catch (ArgumentException ex)
        {
          return Formats.FormatByFileName(fileName, true);
        }
      }
    }
  }
}
