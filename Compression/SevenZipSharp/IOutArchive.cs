// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="IOutArchive.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.SevenZip
{
  [Guid("23170F69-40C1-278A-0000-000600A00000")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [ComImport]
  internal interface IOutArchive
  {
    [MethodImpl(MethodImplOptions.PreserveSig)]
    int UpdateItems([MarshalAs(UnmanagedType.Interface)] ISequentialOutStream outStream, uint numItems, [MarshalAs(UnmanagedType.Interface)] IArchiveUpdateCallback updateCallback);

    void GetFileTimeType(IntPtr type);
  }
}
