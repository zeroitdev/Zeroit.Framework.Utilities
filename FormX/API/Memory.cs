// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Memory.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Provides API access to memory allocation and other memory functions
    /// </summary>
    public class Memory
    {
        /// <summary>
        /// Virtuals the alloc.
        /// </summary>
        /// <param name="lpAddress">The lp address.</param>
        /// <param name="dwSize">Size of the dw.</param>
        /// <param name="flAllocationType">Type of the fl allocation.</param>
        /// <param name="flProtect">The fl protect.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr VirtualAlloc(IntPtr lpAddress, UInt32 dwSize, UInt32 flAllocationType, UInt32 flProtect);

        /// <summary>
        /// Virtuals the free.
        /// </summary>
        /// <param name="lpAddress">The lp address.</param>
        /// <param name="dwSize">Size of the dw.</param>
        /// <param name="dwFreeType">Type of the dw free.</param>
        /// <returns>Boolean.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean VirtualFree(IntPtr lpAddress, UInt32 dwSize, UInt32 dwFreeType);

        /// <summary>
        /// RTLs the zero memory.
        /// </summary>
        /// <param name="dest">The dest.</param>
        /// <param name="size">The size.</param>
        [DllImport("kernel32.dll", SetLastError = false)]
        public static extern void RtlZeroMemory(IntPtr dest, IntPtr size);

        /// <summary>
        /// RTLs the fill memory.
        /// </summary>
        /// <param name="Destination">The destination.</param>
        /// <param name="length">The length.</param>
        /// <param name="fill">The fill.</param>
        /// <returns>Int32.</returns>
        [DllImport("ntdll.dll", SetLastError = false)]
        public static extern Int32 RtlFillMemory([In] IntPtr Destination, UInt32 length, byte fill);

        /// <summary>
        /// RTLs the zero memory.
        /// </summary>
        /// <param name="Destination">The destination.</param>
        /// <param name="length">The length.</param>
        [DllImport("ntdll.dll", SetLastError = true)]
        public static extern void RtlZeroMemory(IntPtr Destination, uint length);

        /// <summary>
        /// RTLs the compare memory.
        /// </summary>
        /// <param name="Source1">The source1.</param>
        /// <param name="Source2">The source2.</param>
        /// <param name="length">The length.</param>
        /// <returns>UInt32.</returns>
        [DllImport("ntdll.dll", SetLastError = false)]
        public static extern UInt32 RtlCompareMemory(IntPtr Source1, IntPtr Source2, UInt32 length);

        /// <summary>
        /// RTLs the move memory.
        /// </summary>
        /// <param name="Destination">The destination.</param>
        /// <param name="Source">The source.</param>
        /// <param name="Length">The length.</param>
        /// <returns>Int32.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Int32 RtlMoveMemory(ref byte Destination, ref byte Source, IntPtr Length);

        /// <summary>
        /// RTLs the move memory.
        /// </summary>
        /// <param name="Destination">The destination.</param>
        /// <param name="Source">The source.</param>
        /// <param name="Length">The length.</param>
        /// <returns>Int32.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Int32 RtlMoveMemory(ref byte Destination, ref IntPtr Source, IntPtr Length);
    }
}
