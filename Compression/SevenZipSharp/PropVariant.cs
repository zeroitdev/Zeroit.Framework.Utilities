// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="PropVariant.cs" company="Zeroit Dev Technologies">
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

using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace Zeroit.Framework.Utilities.SevenZip
{
  [StructLayout(LayoutKind.Explicit, Size = 16)]
  internal struct PropVariant
  {
    [FieldOffset(0)]
    private ushort _Vt;
    [FieldOffset(8)]
    private IntPtr _Value;
    [FieldOffset(8)]
    private uint _UInt32Value;
    [FieldOffset(8)]
    private long _Int64Value;
    [FieldOffset(8)]
    private ulong _UInt64Value;
    [FieldOffset(8)]
    private System.Runtime.InteropServices.ComTypes.FILETIME _FileTime;

    public VarEnum VarType
    {
      private get
      {
        return (VarEnum) this._Vt;
      }
      set
      {
        this._Vt = (ushort) value;
      }
    }

    public IntPtr Value
    {
      private get
      {
        return this._Value;
      }
      set
      {
        this._Value = value;
      }
    }

    public uint UInt32Value
    {
      set
      {
        this._UInt32Value = value;
      }
    }

    public long Int64Value
    {
      private get
      {
        return this._Int64Value;
      }
      set
      {
        this._Int64Value = value;
      }
    }

    public ulong UInt64Value
    {
      set
      {
        this._UInt64Value = value;
      }
    }

    public object Object
    {
      get
      {
        new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();
        switch (this.VarType)
        {
          case VarEnum.VT_EMPTY:
            return (object) null;
          case VarEnum.VT_FILETIME:
            try
            {
              return (object) DateTime.FromFileTime(this.Int64Value);
            }
            catch (ArgumentOutOfRangeException ex)
            {
              return (object) DateTime.MinValue;
            }
          default:
            GCHandle gcHandle = GCHandle.Alloc((object) this, GCHandleType.Pinned);
            try
            {
              return Marshal.GetObjectForNativeVariant(gcHandle.AddrOfPinnedObject());
            }
            finally
            {
              gcHandle.Free();
            }
        }
      }
    }

    public override bool Equals(object obj)
    {
      if (!(obj is PropVariant))
        return false;
      return this.Equals((PropVariant) obj);
    }

    private bool Equals(PropVariant afi)
    {
      if (afi.VarType != this.VarType)
        return false;
      if (this.VarType != VarEnum.VT_BSTR)
        return afi.Int64Value == this.Int64Value;
      return afi.Value == this.Value;
    }

    public override int GetHashCode()
    {
      return this.Value.GetHashCode();
    }

    public override string ToString()
    {
      return "[" + (object) this.Value + "] " + this.Int64Value.ToString((IFormatProvider) CultureInfo.CurrentCulture);
    }

    public static bool operator ==(PropVariant afi1, PropVariant afi2)
    {
      return afi1.Equals(afi2);
    }

    public static bool operator !=(PropVariant afi1, PropVariant afi2)
    {
      return !afi1.Equals(afi2);
    }
  }
}
