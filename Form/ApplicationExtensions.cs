// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-25-2018
// ***********************************************************************
// <copyright file="ApplicationExtensions.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities
{
    /// <summary>
    /// Class FormUtils.
    /// </summary>
    public static partial class FormUtils
    {

        /// <summary>
        /// Shows the window asynchronous.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="nCmdShow">The n command show.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        /// <summary>
        /// Enum ShowWindowConstants
        /// </summary>
        public enum ShowWindowConstants
        {
            /// <summary>
            /// The sw hide
            /// </summary>
            SW_HIDE = 0,
            /// <summary>
            /// The sw shownormal
            /// </summary>
            SW_SHOWNORMAL = 1,
            /// <summary>
            /// The sw normal
            /// </summary>
            SW_NORMAL = 1,
            /// <summary>
            /// The sw showminimized
            /// </summary>
            SW_SHOWMINIMIZED = 2,
            /// <summary>
            /// The sw showmaximized
            /// </summary>
            SW_SHOWMAXIMIZED = 3,
            /// <summary>
            /// The sw maximize
            /// </summary>
            SW_MAXIMIZE = 3,
            /// <summary>
            /// The sw shownoactivate
            /// </summary>
            SW_SHOWNOACTIVATE = 4,
            /// <summary>
            /// The sw show
            /// </summary>
            SW_SHOW = 5,
            /// <summary>
            /// The sw minimize
            /// </summary>
            SW_MINIMIZE = 6,
            /// <summary>
            /// The sw showminnoactive
            /// </summary>
            SW_SHOWMINNOACTIVE = 7,
            /// <summary>
            /// The sw showna
            /// </summary>
            SW_SHOWNA = 8,
            /// <summary>
            /// The sw restore
            /// </summary>
            SW_RESTORE = 9,
            /// <summary>
            /// The sw showdefault
            /// </summary>
            SW_SHOWDEFAULT = 10,
            /// <summary>
            /// The sw forceminimize
            /// </summary>
            SW_FORCEMINIMIZE = 11,
            /// <summary>
            /// The sw maximum
            /// </summary>
            SW_MAX = 11
        }


        /// <summary>
        /// Struct FLASHWINFO
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            /// <summary>
            /// The cb size
            /// </summary>
            public UInt32 cbSize;
            /// <summary>
            /// The HWND
            /// </summary>
            public IntPtr hwnd;
            /// <summary>
            /// The dw flags
            /// </summary>
            public Int32 dwFlags;
            /// <summary>
            /// The u count
            /// </summary>
            public UInt32 uCount;
            /// <summary>
            /// The dw timeout
            /// </summary>
            public Int32 dwTimeout;
        }

        /// <summary>
        /// Enum FLASHWINFOFLAGS
        /// </summary>
        public enum FLASHWINFOFLAGS
        {
            /// <summary>
            /// The flashw stop
            /// </summary>
            FLASHW_STOP = 0,
            /// <summary>
            /// The flashw caption
            /// </summary>
            FLASHW_CAPTION = 0x00000001,
            /// <summary>
            /// The flashw tray
            /// </summary>
            FLASHW_TRAY = 0x00000002,
            /// <summary>
            /// The flashw all
            /// </summary>
            FLASHW_ALL = (FLASHW_CAPTION | FLASHW_TRAY),
            /// <summary>
            /// The flashw timer
            /// </summary>
            FLASHW_TIMER = 0x00000004,
            /// <summary>
            /// The flashw timernofg
            /// </summary>
            FLASHW_TIMERNOFG = 0x0000000C
        }
        /// <summary>
        /// Flashes the window ex.
        /// </summary>
        /// <param name="FlashInfo">The flash information.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll")]
        private static extern int FlashWindowEx(ref FLASHWINFO FlashInfo);


        /// <summary>
        /// Flashes the form.
        /// </summary>
        /// <param name="Handle">The handle.</param>
        public static void FlashForm(IntPtr Handle)
        {
            FLASHWINFO xFlashInfo = new FLASHWINFO();

            xFlashInfo.cbSize = Convert.ToUInt32(System.Runtime.InteropServices.Marshal.SizeOf(typeof(FLASHWINFO)));
            xFlashInfo.hwnd = Handle;
            xFlashInfo.dwFlags = (Int32)(FLASHWINFOFLAGS.FLASHW_ALL | FLASHWINFOFLAGS.FLASHW_TIMERNOFG);
            xFlashInfo.dwTimeout = 0;
            FlashWindowEx(ref xFlashInfo);
        }
        /// <summary>
        /// Checks if application running.
        /// </summary>
        /// <param name="ProcessName">Name of the process.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool CheckIfApplicationRunning(string ProcessName)
        {
            Process[] RunningProcesses = Process.GetProcessesByName(ProcessName);
            return RunningProcesses.Length > 1;
        }
        /// <summary>
        /// Restores the name of from process.
        /// </summary>
        /// <param name="ProcessName">Name of the process.</param>
        public static void RestoreFromProcessName(string ProcessName)
        {
            Process[] RunningProcesses = Process.GetProcessesByName(ProcessName);
            if(RunningProcesses.Length==0)
                return;
            IntPtr MainWindowHandle = RunningProcesses[0].MainWindowHandle;
            ShowWindowAsync(MainWindowHandle, (int)ShowWindowConstants.SW_MINIMIZE);
            ShowWindowAsync(MainWindowHandle, (int)ShowWindowConstants.SW_RESTORE);
        }
    }
}
