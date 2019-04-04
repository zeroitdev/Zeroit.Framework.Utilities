// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="IArchiveUpdateCallback.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.SevenZip
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("23170F69-40C1-278A-0000-000600800000")]
  [ComImport]
  internal interface IArchiveUpdateCallback
  {
    void SetTotal(ulong total);

    void SetCompleted([In] ref ulong completeValue);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    int GetUpdateItemInfo(uint index, ref int newData, ref int newProperties, ref uint indexInArchive);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    int GetProperty(uint index, ItemPropId propId, ref PropVariant value);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    int GetStream(uint index, [MarshalAs(UnmanagedType.Interface)] out ISequentialInStream inStream);

    void SetOperationResult(OperationResult operationResult);

    long EnumProperties(IntPtr enumerator);
  }
}
