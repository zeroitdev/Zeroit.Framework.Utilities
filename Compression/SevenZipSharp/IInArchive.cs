// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="IInArchive.cs" company="Zeroit Dev Technologies">
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
