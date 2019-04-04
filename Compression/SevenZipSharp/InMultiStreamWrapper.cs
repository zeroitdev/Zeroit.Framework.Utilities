// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="InMultiStreamWrapper.cs" company="Zeroit Dev Technologies">
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

using System.Collections.Generic;
using System.IO;

namespace Zeroit.Framework.Utilities.SevenZip
{
  internal sealed class InMultiStreamWrapper : MultiStreamWrapper, ISequentialInStream, IInStream
  {
    public InMultiStreamWrapper(string fileName, bool dispose)
      : base(dispose)
    {
      string str = fileName.Substring(0, fileName.Length - 4);
      int index = 0;
      for (; File.Exists(fileName); fileName = str + MultiStreamWrapper.VolumeNumber(index + 1))
      {
        this.Streams.Add((Stream) new FileStream(fileName, FileMode.Open));
        long length = this.Streams[index].Length;
        this.StreamOffsets.Add(index++, new KeyValuePair<long, long>(this.StreamLength, this.StreamLength + length));
        this.StreamLength += length;
      }
    }

    public int Read(byte[] data, uint size)
    {
      int count1 = (int) size;
      int offset = this.Streams[this.CurrentStream].Read(data, 0, count1);
      int count2 = count1 - offset;
      this.Position += (long) offset;
      while (offset < (int) size && this.CurrentStream != this.Streams.Count - 1)
      {
        ++this.CurrentStream;
        this.Streams[this.CurrentStream].Seek(0L, SeekOrigin.Begin);
        int num = this.Streams[this.CurrentStream].Read(data, offset, count2);
        offset += num;
        count2 -= num;
        this.Position += (long) num;
      }
      return offset;
    }
  }
}
