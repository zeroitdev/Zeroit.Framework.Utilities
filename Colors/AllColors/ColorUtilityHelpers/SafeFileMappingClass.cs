using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace Zeroit.Framework.Utilities.Colors.AllColors
{
    [SuppressUnmanagedCodeSecurity]
    [HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
    internal sealed class SafeFileMappingHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
        internal SafeFileMappingHandle()
            : base(true)
        {
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr handle);

        protected override bool ReleaseHandle()
        {
            return SafeFileMappingHandle.CloseHandle(this.handle);
        }
    }
}
