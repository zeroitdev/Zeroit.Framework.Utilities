// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="NativeMethods.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.SevenZip
{
  internal static class NativeMethods
  {
    [DllImport("kernel32.dll", ThrowOnUnmappableChar = true, BestFitMapping = false)]
    public static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)] string fileName);

    [DllImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool FreeLibrary(IntPtr hModule);

    [DllImport("kernel32.dll", ThrowOnUnmappableChar = true, BestFitMapping = false)]
    public static extern IntPtr GetProcAddress(IntPtr hModule, [MarshalAs(UnmanagedType.LPStr)] string procName);

    public static T SafeCast<T>(PropVariant var, T def)
    {
      object obj;
      try
      {
        obj = var.Object;
      }
      catch (Exception ex)
      {
        return def;
      }
      if (obj != null && obj is T)
        return (T) obj;
      return def;
    }

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int CreateObjectDelegate([In] ref Guid classID, [In] ref Guid interfaceID, [MarshalAs(UnmanagedType.Interface)] out object outObject);
  }
}
