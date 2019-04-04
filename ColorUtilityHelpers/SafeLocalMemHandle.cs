// Decompiled with JetBrains decompiler
// Type: Microsoft.Win32.SafeHandles.SafeLocalMemHandle
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
    internal sealed class SafeLocalMemHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        internal SafeLocalMemHandle()
            : base(true)
        {
        }

        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
        internal SafeLocalMemHandle(IntPtr existingHandle, bool ownsHandle)
            : base(ownsHandle)
        {
            this.SetHandle(existingHandle);
        }

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false)]
        internal static extern bool ConvertStringSecurityDescriptorToSecurityDescriptor(string StringSecurityDescriptor, int StringSDRevision, out SafeLocalMemHandle pSecurityDescriptor, IntPtr SecurityDescriptorSize);

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [DllImport("kernel32.dll")]
        private static extern IntPtr LocalFree(IntPtr hMem);

        protected override bool ReleaseHandle()
        {
            return SafeLocalMemHandle.LocalFree(this.handle) == IntPtr.Zero;
        }
    }
}
