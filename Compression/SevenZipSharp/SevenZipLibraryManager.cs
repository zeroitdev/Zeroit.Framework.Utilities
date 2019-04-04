// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="SevenZipLibraryManager.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace Zeroit.Framework.Utilities.SevenZip
{
  internal static class SevenZipLibraryManager
  {
    private static string _LibraryFileName = ConfigurationManager.AppSettings["7zLocation"] ?? Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "7z.dll");
    private static IntPtr _ModulePtr;
    [ThreadStatic]
    private static Dictionary<object, Dictionary<InArchiveFormat, IInArchive>> _InArchives;
    [ThreadStatic]
    private static Dictionary<object, Dictionary<OutArchiveFormat, IOutArchive>> _OutArchives;
    private static bool? _ModifyCapabale;

    private static void InitUserInFormat(object user, InArchiveFormat format)
    {
      if (!SevenZipLibraryManager._InArchives.ContainsKey(user))
        SevenZipLibraryManager._InArchives.Add(user, new Dictionary<InArchiveFormat, IInArchive>());
      if (SevenZipLibraryManager._InArchives[user].ContainsKey(format))
        return;
      SevenZipLibraryManager._InArchives[user].Add(format, (IInArchive) null);
    }

    private static void InitUserOutFormat(object user, OutArchiveFormat format)
    {
      if (!SevenZipLibraryManager._OutArchives.ContainsKey(user))
        SevenZipLibraryManager._OutArchives.Add(user, new Dictionary<OutArchiveFormat, IOutArchive>());
      if (SevenZipLibraryManager._OutArchives[user].ContainsKey(format))
        return;
      SevenZipLibraryManager._OutArchives[user].Add(format, (IOutArchive) null);
    }

    private static void Init()
    {
      SevenZipLibraryManager._InArchives = new Dictionary<object, Dictionary<InArchiveFormat, IInArchive>>();
      SevenZipLibraryManager._OutArchives = new Dictionary<object, Dictionary<OutArchiveFormat, IOutArchive>>();
    }

    public static void LoadLibrary(object user, Enum format)
    {
      if (SevenZipLibraryManager._InArchives == null || SevenZipLibraryManager._OutArchives == null)
        SevenZipLibraryManager.Init();
      if (SevenZipLibraryManager._ModulePtr == IntPtr.Zero)
      {
        if (!File.Exists(SevenZipLibraryManager._LibraryFileName))
          throw new SevenZipLibraryException("DLL file does not exist.");
        if ((SevenZipLibraryManager._ModulePtr = NativeMethods.LoadLibrary(SevenZipLibraryManager._LibraryFileName)) == IntPtr.Zero)
          throw new SevenZipLibraryException("failed to load library.");
        if (NativeMethods.GetProcAddress(SevenZipLibraryManager._ModulePtr, "GetHandlerProperty") == IntPtr.Zero)
        {
          NativeMethods.FreeLibrary(SevenZipLibraryManager._ModulePtr);
          throw new SevenZipLibraryException("library is invalid.");
        }
      }
      if (format is InArchiveFormat)
      {
        SevenZipLibraryManager.InitUserInFormat(user, (InArchiveFormat) format);
      }
      else
      {
        if (!(format is OutArchiveFormat))
          throw new ArgumentException("Enum " + (object) format + " is not a valid archive format attribute!");
        SevenZipLibraryManager.InitUserOutFormat(user, (OutArchiveFormat) format);
      }
    }

    public static bool ModifyCapable
    {
      get
      {
        if (!SevenZipLibraryManager._ModifyCapabale.HasValue)
          SevenZipLibraryManager._ModifyCapabale = new bool?(FileVersionInfo.GetVersionInfo(SevenZipLibraryManager._LibraryFileName).FileMajorPart >= 9);
        return SevenZipLibraryManager._ModifyCapabale.Value;
      }
    }

    public static void FreeLibrary(object user, Enum format)
    {
      new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();
      if (!(SevenZipLibraryManager._ModulePtr != IntPtr.Zero))
        return;
      if (format is InArchiveFormat && SevenZipLibraryManager._InArchives != null && (SevenZipLibraryManager._InArchives.ContainsKey(user) && SevenZipLibraryManager._InArchives[user].ContainsKey((InArchiveFormat) format)))
      {
        if (SevenZipLibraryManager._InArchives[user][(InArchiveFormat) format] != null)
        {
          try
          {
            Marshal.ReleaseComObject((object) SevenZipLibraryManager._InArchives[user][(InArchiveFormat) format]);
          }
          catch (InvalidComObjectException ex)
          {
          }
          SevenZipLibraryManager._InArchives[user].Remove((InArchiveFormat) format);
          if (SevenZipLibraryManager._InArchives[user].Count == 0)
            SevenZipLibraryManager._InArchives.Remove(user);
        }
      }
      if (format is OutArchiveFormat && SevenZipLibraryManager._OutArchives != null && (SevenZipLibraryManager._OutArchives.ContainsKey(user) && SevenZipLibraryManager._OutArchives[user].ContainsKey((OutArchiveFormat) format)))
      {
        if (SevenZipLibraryManager._OutArchives[user][(OutArchiveFormat) format] != null)
        {
          try
          {
            Marshal.ReleaseComObject((object) SevenZipLibraryManager._OutArchives[user][(OutArchiveFormat) format]);
          }
          catch (InvalidComObjectException ex)
          {
          }
          SevenZipLibraryManager._OutArchives[user].Remove((OutArchiveFormat) format);
          if (SevenZipLibraryManager._OutArchives[user].Count == 0)
            SevenZipLibraryManager._OutArchives.Remove(user);
        }
      }
      if (SevenZipLibraryManager._InArchives != null && SevenZipLibraryManager._InArchives.Count != 0 || SevenZipLibraryManager._OutArchives != null && SevenZipLibraryManager._OutArchives.Count != 0)
        return;
      SevenZipLibraryManager._InArchives = (Dictionary<object, Dictionary<InArchiveFormat, IInArchive>>) null;
      SevenZipLibraryManager._OutArchives = (Dictionary<object, Dictionary<OutArchiveFormat, IOutArchive>>) null;
      NativeMethods.FreeLibrary(SevenZipLibraryManager._ModulePtr);
      SevenZipLibraryManager._ModulePtr = IntPtr.Zero;
    }

    public static IInArchive InArchive(InArchiveFormat format, object user)
    {
      if (SevenZipLibraryManager._InArchives[user][format] == null)
      {
        new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();
        if (SevenZipLibraryManager._ModulePtr == IntPtr.Zero)
          throw new SevenZipLibraryException();
        NativeMethods.CreateObjectDelegate forFunctionPointer = (NativeMethods.CreateObjectDelegate) Marshal.GetDelegateForFunctionPointer(NativeMethods.GetProcAddress(SevenZipLibraryManager._ModulePtr, "CreateObject"), typeof (NativeMethods.CreateObjectDelegate));
        if (forFunctionPointer == null)
          throw new SevenZipLibraryException();
        Guid guid = typeof (IInArchive).GUID;
        Guid inFormatGuid = Formats.InFormatGuids[format];
        object outObject;
        int num = forFunctionPointer(ref inFormatGuid, ref guid, out outObject);
        if (outObject == null)
          throw new SevenZipLibraryException("Your 7-zip library does not support this archive type.");
        SevenZipLibraryManager.InitUserInFormat(user, format);
        SevenZipLibraryManager._InArchives[user][format] = outObject as IInArchive;
      }
      return SevenZipLibraryManager._InArchives[user][format];
    }

    public static IOutArchive OutArchive(OutArchiveFormat format, object user)
    {
      if (SevenZipLibraryManager._OutArchives[user][format] == null)
      {
        new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();
        if (SevenZipLibraryManager._ModulePtr == IntPtr.Zero)
          throw new SevenZipLibraryException();
        NativeMethods.CreateObjectDelegate forFunctionPointer = (NativeMethods.CreateObjectDelegate) Marshal.GetDelegateForFunctionPointer(NativeMethods.GetProcAddress(SevenZipLibraryManager._ModulePtr, "CreateObject"), typeof (NativeMethods.CreateObjectDelegate));
        if (forFunctionPointer == null)
          throw new SevenZipLibraryException();
        Guid guid = typeof (IOutArchive).GUID;
        Guid outFormatGuid = Formats.OutFormatGuids[format];
        object outObject;
        int num = forFunctionPointer(ref outFormatGuid, ref guid, out outObject);
        if (outObject == null)
          throw new SevenZipLibraryException("Your 7-zip library does not support this archive type.");
        SevenZipLibraryManager.InitUserOutFormat(user, format);
        SevenZipLibraryManager._OutArchives[user][format] = outObject as IOutArchive;
      }
      return SevenZipLibraryManager._OutArchives[user][format];
    }

    public static void SetLibraryPath(string libraryPath)
    {
      if (SevenZipLibraryManager._ModulePtr != IntPtr.Zero)
        throw new SevenZipLibraryException("can not change the library path while the library\"" + SevenZipLibraryManager._LibraryFileName + "\"is being used.");
      if (!File.Exists(libraryPath))
        throw new SevenZipLibraryException("can not change the library path because the file\"" + libraryPath + "\"does not exist.");
      SevenZipLibraryManager._LibraryFileName = libraryPath;
    }
  }
}
