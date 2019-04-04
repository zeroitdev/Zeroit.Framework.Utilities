// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="ISequentialInStream.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.SevenZip
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("23170F69-40C1-278A-0000-000300010000")]
  [ComImport]
  internal interface ISequentialInStream
  {
    int Read([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1), Out] byte[] data, uint size);
  }
}
