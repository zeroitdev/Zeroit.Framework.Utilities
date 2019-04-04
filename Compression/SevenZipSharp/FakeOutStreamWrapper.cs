// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="FakeOutStreamWrapper.cs" company="Zeroit Dev Technologies">
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
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.SevenZip
{
  internal sealed class FakeOutStreamWrapper : ISequentialOutStream, IDisposable
  {
    public void Dispose()
    {
      GC.SuppressFinalize((object) this);
    }

    public int Write(byte[] data, uint size, IntPtr processedSize)
    {
      this.OnBytesWritten(new IntEventArgs((int) size));
      if (processedSize != IntPtr.Zero)
        Marshal.WriteInt32(processedSize, (int) size);
      return 0;
    }

    public event EventHandler<IntEventArgs> BytesWritten;

    private void OnBytesWritten(IntEventArgs e)
    {
      if (this.BytesWritten == null)
        return;
      this.BytesWritten((object) this, e);
    }
  }
}
