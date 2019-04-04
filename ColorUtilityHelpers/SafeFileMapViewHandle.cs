// Decompiled with JetBrains decompiler
// Type: Microsoft.Win32.SafeHandles.SafeFileMapViewHandle
// Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: CA2931B9-6ADD-4B1A-8D45-C0A71B069EBD
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.dll

using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using Microsoft.Win32.SafeHandles;

namespace Zeroit.Framework.Utilities
{
    [SuppressUnmanagedCodeSecurity]
    [HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
    internal sealed class SafeFileMapViewHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        internal SafeFileMapViewHandle()
            : base(true)
        {
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        internal static extern SafeFileMapViewHandle MapViewOfFile(SafeFileMappingHandle hFileMappingObject, int dwDesiredAccess, int dwFileOffsetHigh, int dwFileOffsetLow, UIntPtr dwNumberOfBytesToMap);

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool UnmapViewOfFile(IntPtr handle);

        protected override bool ReleaseHandle()
        {
            return SafeFileMapViewHandle.UnmapViewOfFile(this.handle);
        }
    }
}
