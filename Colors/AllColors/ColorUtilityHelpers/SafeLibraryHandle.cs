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
    internal sealed class SafeLibraryHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        internal SafeLibraryHandle()
            : base(true)
        {
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern SafeLibraryHandle LoadLibraryEx(string libFilename, IntPtr reserved, int flags);

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern bool FreeLibrary(IntPtr hModule);

        protected override bool ReleaseHandle()
        {
            return SafeLibraryHandle.FreeLibrary(this.handle);
        }
    }
}
