// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="ICryptoGetTextPassword2.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.SevenZip
{
  [Guid("23170F69-40C1-278A-0000-000500110000")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [ComImport]
  internal interface ICryptoGetTextPassword2
  {
    [MethodImpl(MethodImplOptions.PreserveSig)]
    int CryptoGetTextPassword2(ref int passwordIsDefined, [MarshalAs(UnmanagedType.BStr)] out string password);
  }
}
