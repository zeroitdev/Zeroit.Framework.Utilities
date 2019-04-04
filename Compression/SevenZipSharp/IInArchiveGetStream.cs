// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="IInArchiveGetStream.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.SevenZip
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("23170F69-40C1-278A-0000-000600400000")]
  [ComImport]
  internal interface IInArchiveGetStream
  {
    [return: MarshalAs(UnmanagedType.Interface)]
    ISequentialInStream GetStream(uint index);
  }
}
