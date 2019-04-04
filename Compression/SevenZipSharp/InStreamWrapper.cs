// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="InStreamWrapper.cs" company="Zeroit Dev Technologies">
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
  internal sealed class InStreamWrapper : StreamWrapper, ISequentialInStream, IInStream
  {
    public InStreamWrapper(Stream baseStream, bool disposeStream)
      : base(baseStream, disposeStream)
    {
    }

    public int Read(byte[] data, uint size)
    {
      int num = 0;
      if (this.BaseStream != null)
      {
        num = this.BaseStream.Read(data, 0, (int) size);
        if (num > 0)
          this.OnBytesRead(new IntEventArgs(num));
      }
      return num;
    }

    public event EventHandler<IntEventArgs> BytesRead;

    private void OnBytesRead(IntEventArgs e)
    {
      if (this.BytesRead == null)
        return;
      this.BytesRead((object) this, e);
    }
  }
}
