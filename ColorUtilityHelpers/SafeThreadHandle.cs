// Decompiled with JetBrains decompiler
// Type: Microsoft.Win32.SafeHandles.SafeThreadHandle
// Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: CA2931B9-6ADD-4B1A-8D45-C0A71B069EBD
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.dll

using System;
using System.Security;
using Microsoft.Win32.SafeHandles;

namespace Zeroit.Framework.Utilities
{
    [SuppressUnmanagedCodeSecurity]
    internal sealed class SafeThreadHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        internal SafeThreadHandle()
            : base(true)
        {
        }

        internal void InitialSetHandle(IntPtr h)
        {
            this.SetHandle(h);
        }

        protected override bool ReleaseHandle()
        {
            return SafeNativeMethods.CloseHandle(this.handle);
        }
    }
}
