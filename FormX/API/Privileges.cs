// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Privileges.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Provides API access to make privilege changes and such
    /// </summary>
    public class Privileges
    {
        /// <summary>
        /// Adjusts the token privileges.
        /// </summary>
        /// <param name="TokenHandle">The token handle.</param>
        /// <param name="DisableAllPrivileges">if set to <c>true</c> [disable all privileges].</param>
        /// <param name="NewState">The new state.</param>
        /// <param name="BufferLength">Length of the buffer.</param>
        /// <param name="PreviousState">State of the previous.</param>
        /// <param name="ReturnLength">Length of the return.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AdjustTokenPrivileges(IntPtr TokenHandle, [MarshalAs(UnmanagedType.Bool)]bool DisableAllPrivileges, ref TOKEN_PRIVILEGES NewState, UInt32 BufferLength, IntPtr PreviousState, IntPtr ReturnLength);

        /// <summary>
        /// Lookups the privilege value w.
        /// </summary>
        /// <param name="lpSystemName">Name of the lp system.</param>
        /// <param name="lpName">Name of the lp.</param>
        /// <param name="lpLuid">The lp luid.</param>
        /// <returns>Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Int32 LookupPrivilegeValueW(Int32 lpSystemName, [MarshalAs(UnmanagedType.LPWStr)]string lpName, ref LUID lpLuid);

        /// <summary>
        /// Adjusts the token privileges.
        /// </summary>
        /// <param name="TokenHandle">The token handle.</param>
        /// <param name="DisableAllPriv">The disable all priv.</param>
        /// <param name="NewState">The new state.</param>
        /// <param name="BufferLength">Length of the buffer.</param>
        /// <param name="PreviousState">State of the previous.</param>
        /// <param name="ReturnLength">Length of the return.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AdjustTokenPrivileges", SetLastError = true)]
        public static extern int AdjustTokenPrivileges(IntPtr TokenHandle, int DisableAllPriv, ref TOKEN_PRIVILEGES NewState, int BufferLength, int PreviousState, int ReturnLength);

        /// <summary>
        /// Lookups the privilege value a.
        /// </summary>
        /// <param name="lpSystemName">Name of the lp system.</param>
        /// <param name="lpName">Name of the lp.</param>
        /// <param name="lpLuid">The lp luid.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "LookupPrivilegeValueA", SetLastError = true)]
        public static extern int LookupPrivilegeValueA(int lpSystemName, [MarshalAs(UnmanagedType.LPStr)]string lpName, ref LUID lpLuid);
    }
}
