// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Process.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Provides API access to process resources
    /// </summary>
    public class Process
    {
        /// <summary>
        /// Enums the processes.
        /// </summary>
        /// <param name="processIds">The process ids.</param>
        /// <param name="arraySizeBytes">The array size bytes.</param>
        /// <param name="bytesCopied">The bytes copied.</param>
        /// <returns>Boolean.</returns>
        [DllImport("psapi.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean EnumProcesses([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U4)] [In][Out] UInt32[] processIds, UInt32 arraySizeBytes, [MarshalAs(UnmanagedType.U4)] out UInt32 bytesCopied);

        /// <summary>
        /// Enums the process modules.
        /// </summary>
        /// <param name="hProcess">The h process.</param>
        /// <param name="lphModule">The LPH module.</param>
        /// <param name="cb">The cb.</param>
        /// <param name="lpcbNeeded">The LPCB needed.</param>
        /// <returns>Boolean.</returns>
        [DllImport("psapi.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean EnumProcessModules(IntPtr hProcess, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U4)] [In][Out] UInt32[] lphModule, UInt32 cb, [MarshalAs(UnmanagedType.U4)] out UInt32 lpcbNeeded);

        /// <summary>
        /// Gets the module file name ex a.
        /// </summary>
        /// <param name="hProcess">The h process.</param>
        /// <param name="hModule">The h module.</param>
        /// <param name="lpBaseName">Name of the lp base.</param>
        /// <param name="nSize">Size of the n.</param>
        /// <returns>UInt32.</returns>
        [DllImport("psapi.dll", SetLastError = true)]
        public static extern UInt32 GetModuleFileNameExA(IntPtr hProcess, IntPtr hModule,
        [Out] StringBuilder lpBaseName, [In] [MarshalAs(UnmanagedType.U4)] UInt32 nSize);

        /// <summary>
        /// Nts the terminate process.
        /// </summary>
        /// <param name="ProcessHandle">The process handle.</param>
        /// <param name="ExitStatus">The exit status.</param>
        /// <returns>UInt32.</returns>
        [DllImport("ntdll.dll", SetLastError = true)]
        public static extern UInt32 NtTerminateProcess(IntPtr ProcessHandle, UInt32 ExitStatus);

        /// <summary>
        /// Gets the exit code process.
        /// </summary>
        /// <param name="hProcess">The h process.</param>
        /// <param name="lpExitCode">The lp exit code.</param>
        /// <returns>Boolean.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean GetExitCodeProcess(IntPtr hProcess, out UInt32 lpExitCode);

        /// <summary>
        /// Waits for multiple objects.
        /// </summary>
        /// <param name="nCount">The n count.</param>
        /// <param name="pHandles">The p handles.</param>
        /// <param name="bWaitAll">The b wait all.</param>
        /// <param name="dwMilliseconds">The dw milliseconds.</param>
        /// <returns>System.UInt32.</returns>
        [DllImport("kernel32.dll")]
        public static extern uint WaitForMultipleObjects(uint nCount, IntPtr[] pHandles, Boolean bWaitAll, uint dwMilliseconds);

        /// <summary>
        /// Gets the current process identifier.
        /// </summary>
        /// <returns>System.Int32.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCurrentProcessId", SetLastError = true)]
        public static extern int GetCurrentProcessId();

        /// <summary>
        /// Opens the process token.
        /// </summary>
        /// <param name="ProcessHandle">The process handle.</param>
        /// <param name="DesiredAccess">The desired access.</param>
        /// <param name="TokenHandle">The token handle.</param>
        /// <returns>Int32.</returns>
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern Int32 OpenProcessToken(IntPtr ProcessHandle, UInt32 DesiredAccess, ref IntPtr TokenHandle);

        /// <summary>
        /// Opens the process.
        /// </summary>
        /// <param name="dwDesiredAccess">The dw desired access.</param>
        /// <param name="blnheritHandle">The blnherit handle.</param>
        /// <param name="dwAppProcessId">The dw application process identifier.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(Int32 dwDesiredAccess, Int32 blnheritHandle, UInt32 dwAppProcessId);

        /// <summary>
        /// Opens the process.
        /// </summary>
        /// <param name="dwDesiredAccess">The dw desired access.</param>
        /// <param name="blnheritHandle">The blnherit handle.</param>
        /// <param name="dwAppProcessId">The dw application process identifier.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "OpenProcess", SetLastError = true)]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, int blnheritHandle, int dwAppProcessId);
    }
}
