// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="ArchiveOpenCallback.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.SevenZip
{
  internal sealed class ArchiveOpenCallback : SevenZipBase, IArchiveOpenCallback, IArchiveOpenVolumeCallback, ICryptoGetTextPassword, IDisposable
  {
    private Dictionary<string, InStreamWrapper> _Wrappers = new Dictionary<string, InStreamWrapper>();
    private FileInfo _FileInfo;

    private void Init(string fileName)
    {
      if (string.IsNullOrEmpty(fileName))
        return;
      this._FileInfo = new FileInfo(fileName);
    }

    public ArchiveOpenCallback(string fileName)
    {
      this.Init(fileName);
    }

    public ArchiveOpenCallback(string fileName, string password)
      : base(password)
    {
      this.Init(fileName);
    }

    public void SetTotal(IntPtr files, IntPtr bytes)
    {
    }

    public void SetCompleted(IntPtr files, IntPtr bytes)
    {
    }

    public int GetProperty(ItemPropId propId, ref PropVariant value)
    {
      switch (propId)
      {
        case ItemPropId.Name:
          value.VarType = VarEnum.VT_BSTR;
          value.Value = Marshal.StringToBSTR(this._FileInfo.FullName);
          break;
        case ItemPropId.IsDirectory:
          value.VarType = VarEnum.VT_BOOL;
          value.UInt64Value = (ulong) (byte) (this._FileInfo.Attributes & FileAttributes.Directory);
          break;
        case ItemPropId.Size:
          value.VarType = VarEnum.VT_UI8;
          value.UInt64Value = (ulong) this._FileInfo.Length;
          break;
        case ItemPropId.Attributes:
          value.VarType = VarEnum.VT_UI4;
          value.UInt32Value = (uint) this._FileInfo.Attributes;
          break;
        case ItemPropId.CreationTime:
          value.VarType = VarEnum.VT_FILETIME;
          value.Int64Value = this._FileInfo.CreationTime.ToFileTime();
          break;
        case ItemPropId.LastAccessTime:
          value.VarType = VarEnum.VT_FILETIME;
          value.Int64Value = this._FileInfo.LastAccessTime.ToFileTime();
          break;
        case ItemPropId.LastWriteTime:
          value.VarType = VarEnum.VT_FILETIME;
          value.Int64Value = this._FileInfo.LastWriteTime.ToFileTime();
          break;
      }
      return 0;
    }

    public int GetStream(string name, out IInStream inStream)
    {
      if (!File.Exists(name))
      {
        name = Path.Combine(Path.GetDirectoryName(this._FileInfo.FullName), name);
        if (!File.Exists(name))
        {
          inStream = (IInStream) null;
          return 1;
        }
      }
      if (this._Wrappers.ContainsKey(name))
      {
        inStream = (IInStream) this._Wrappers[name];
      }
      else
      {
        InStreamWrapper inStreamWrapper = new InStreamWrapper((Stream) new FileStream(name, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), true);
        this._Wrappers.Add(name, inStreamWrapper);
        inStream = (IInStream) inStreamWrapper;
      }
      return 0;
    }

    public int CryptoGetTextPassword(out string password)
    {
      password = this.Password;
      return 0;
    }

    public void Dispose()
    {
      if (this._Wrappers != null)
      {
        foreach (StreamWrapper streamWrapper in this._Wrappers.Values)
          streamWrapper.Dispose();
        this._Wrappers = (Dictionary<string, InStreamWrapper>) null;
      }
      GC.SuppressFinalize((object) this);
    }
  }
}
