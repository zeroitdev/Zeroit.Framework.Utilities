// Decompiled with JetBrains decompiler
// Type: Microsoft.Win32.SafeHandles.SafeProcessHandle
// Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: CA2931B9-6ADD-4B1A-8D45-C0A71B069EBD
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.dll

using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using Microsoft.Win32.SafeHandles;

namespace Zeroit.Framework.Utilities
{
    /// <summary>Provides a managed wrapper for a process handle.</summary>
    [SuppressUnmanagedCodeSecurity]
    public sealed class SafeProcessHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        internal static SafeProcessHandle InvalidHandle = new SafeProcessHandle(IntPtr.Zero);

        internal SafeProcessHandle()
            : base(true)
        {
        }

        internal SafeProcessHandle(IntPtr handle)
            : base(true)
        {
            this.SetHandle(handle);
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Win32.SafeHandles.SafeProcessHandle" /> class from the specified handle, indicating whether to release the handle during the finalization phase. </summary>
        /// <param name="existingHandle">The handle to be wrapped.</param>
        /// <param name="ownsHandle">true to reliably let <see cref="T:Microsoft.Win32.SafeHandles.SafeProcessHandle" /> release the handle during the finalization phase; otherwise, false.</param>
        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
        public SafeProcessHandle(IntPtr existingHandle, bool ownsHandle)
            : base(ownsHandle)
        {
            this.SetHandle(existingHandle);
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern SafeProcessHandle OpenProcess(int access, bool inherit, int processId);

        internal void InitialSetHandle(IntPtr h)
        {
            this.handle = h;
        }

        protected override bool ReleaseHandle()
        {
            return Zeroit.Framework.Utilities.SafeNativeMethods.CloseHandle(this.handle);
        }
    }
}