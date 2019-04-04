// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="StreamWrapper.cs" company="Zeroit Dev Technologies">
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
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.SevenZip
{
  internal class StreamWrapper : DisposeVariableWrapper, IDisposable
  {
    private readonly string _FileName;
    private readonly DateTime _FileTime;
    private Stream _BaseStream;

    protected StreamWrapper(Stream baseStream, string fileName, DateTime time, bool disposeStream)
      : base(disposeStream)
    {
      this._BaseStream = baseStream;
      this._FileName = fileName;
      this._FileTime = time;
    }

    protected StreamWrapper(Stream baseStream, bool disposeStream)
      : base(disposeStream)
    {
      this._BaseStream = baseStream;
    }

    protected Stream BaseStream
    {
      get
      {
        return this._BaseStream;
      }
    }

    public void Dispose()
    {
      if (this.DisposeStream)
      {
        if (this._BaseStream != null)
        {
          try
          {
            this._BaseStream.Dispose();
          }
          catch (ObjectDisposedException ex)
          {
          }
          this._BaseStream = (Stream) null;
        }
      }
      GC.SuppressFinalize((object) this);
      if (string.IsNullOrEmpty(this._FileName))
        return;
      if (!File.Exists(this._FileName))
        return;
      try
      {
        File.SetLastWriteTime(this._FileName, this._FileTime);
        File.SetLastAccessTime(this._FileName, this._FileTime);
        File.SetCreationTime(this._FileName, this._FileTime);
      }
      catch (ArgumentOutOfRangeException ex)
      {
      }
    }

    public event EventHandler<IntEventArgs> StreamSeek;

    public virtual void Seek(long offset, SeekOrigin seekOrigin, IntPtr newPosition)
    {
      if (this.BaseStream == null)
        return;
      if (this.StreamSeek != null && this.BaseStream.Position > offset && seekOrigin == SeekOrigin.Begin)
        this.StreamSeek((object) this, new IntEventArgs((int) (offset - this.BaseStream.Position)));
      long val = this.BaseStream.Seek(offset, seekOrigin);
      if (!(newPosition != IntPtr.Zero))
        return;
      Marshal.WriteInt64(newPosition, val);
    }
  }
}
