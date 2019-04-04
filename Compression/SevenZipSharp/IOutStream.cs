// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="IOutStream.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.SevenZip
{
  [Guid("23170F69-40C1-278A-0000-000300040000")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [ComImport]
  internal interface IOutStream
  {
    [MethodImpl(MethodImplOptions.PreserveSig)]
    int Write([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1), In] byte[] data, uint size, IntPtr processedSize);

    void Seek(long offset, SeekOrigin seekOrigin, IntPtr newPosition);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    int SetSize(long newSize);
  }
}
