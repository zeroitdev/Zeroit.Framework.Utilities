// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="IInArchive.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.SevenZip
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("23170F69-40C1-278A-0000-000600600000")]
  [ComImport]
  internal interface IInArchive
  {
    [MethodImpl(MethodImplOptions.PreserveSig)]
    int Open(IInStream stream, [In] ref ulong maxCheckStartPosition, [MarshalAs(UnmanagedType.Interface)] IArchiveOpenCallback openArchiveCallback);

    void Close();

    uint GetNumberOfItems();

    void GetProperty(uint index, ItemPropId propId, ref PropVariant value);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    int Extract([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] indexes, uint numItems, int testMode, [MarshalAs(UnmanagedType.Interface)] IArchiveExtractCallback extractCallback);

    void GetArchiveProperty(ItemPropId propId, ref PropVariant value);

    uint GetNumberOfProperties();

    void GetPropertyInfo(uint index, [MarshalAs(UnmanagedType.BStr)] out string name, out ItemPropId propId, out ushort varType);

    uint GetNumberOfArchiveProperties();

    void GetArchivePropertyInfo(uint index, [MarshalAs(UnmanagedType.BStr)] out string name, out ItemPropId propId, out ushort varType);
  }
}
