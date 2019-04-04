// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Memory.cs" company="Zeroit Dev Technologies">
//    This program contains Utilities for all C# programming activities.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
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
