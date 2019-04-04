// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="File.cs" company="Zeroit Dev Technologies">
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
    /// Provides API calls for file management
    /// </summary>
    public class File
    {
        /// <summary>
        /// Creates the file w.
        /// </summary>
        /// <param name="lpFileName">Name of the lp file.</param>
        /// <param name="dwDesiredAccess">The dw desired access.</param>
        /// <param name="dwShareMode">The dw share mode.</param>
        /// <param name="lpSecurityAttributes">The lp security attributes.</param>
        /// <param name="dwCreationDisposition">The dw creation disposition.</param>
        /// <param name="dwFlagsAndAttributes">The dw flags and attributes.</param>
        /// <param name="hTemplateFile">The h template file.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr CreateFileW(IntPtr lpFileName, Int32 dwDesiredAccess, Int32 dwShareMode, IntPtr lpSecurityAttributes, Int32 dwCreationDisposition, UInt32 dwFlagsAndAttributes, IntPtr hTemplateFile);

        /// <summary>
        /// Sets the file pointer ex.
        /// </summary>
        /// <param name="hFile">The h file.</param>
        /// <param name="liDistanceToMove">The li distance to move.</param>
        /// <param name="lpNewFilePointer">The lp new file pointer.</param>
        /// <param name="dwMoveMethod">The dw move method.</param>
        /// <returns>Boolean.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean SetFilePointerEx(IntPtr hFile, long liDistanceToMove, [Out, Optional] IntPtr lpNewFilePointer, UInt32 dwMoveMethod);

        /// <summary>
        /// Writes the file.
        /// </summary>
        /// <param name="hFile">The h file.</param>
        /// <param name="lpBuffer">The lp buffer.</param>
        /// <param name="nNumberOfBytesToWrite">The n number of bytes to write.</param>
        /// <param name="lpNumberOfBytesWritten">The lp number of bytes written.</param>
        /// <param name="lpOverlapped">The lp overlapped.</param>
        /// <returns>Int32.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Int32 WriteFile(IntPtr hFile, IntPtr lpBuffer, UInt32 nNumberOfBytesToWrite, ref UInt32 lpNumberOfBytesWritten, IntPtr lpOverlapped);

        /// <summary>
        /// Reads the file.
        /// </summary>
        /// <param name="hFile">The h file.</param>
        /// <param name="lpBuffer">The lp buffer.</param>
        /// <param name="nNumberOfBytesToRead">The n number of bytes to read.</param>
        /// <param name="lpNumberOfBytesRead">The lp number of bytes read.</param>
        /// <param name="lpOverlapped">The lp overlapped.</param>
        /// <returns>Int32.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Int32 ReadFile(IntPtr hFile, IntPtr lpBuffer, UInt32 nNumberOfBytesToRead, ref UInt32 lpNumberOfBytesRead, IntPtr lpOverlapped);

        /// <summary>
        /// Closes the handle.
        /// </summary>
        /// <param name="hObject">The h object.</param>
        /// <returns>Int32.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Int32 CloseHandle(IntPtr hObject);

        /// <summary>
        /// Flushes the file buffers.
        /// </summary>
        /// <param name="hFile">The h file.</param>
        /// <returns>Int32.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Int32 FlushFileBuffers(IntPtr hFile);

        /// <summary>
        /// Sets the file attributes w.
        /// </summary>
        /// <param name="lpFileName">Name of the lp file.</param>
        /// <param name="dwFileAttributes">The dw file attributes.</param>
        /// <returns>Int32.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Int32 SetFileAttributesW([MarshalAs(UnmanagedType.LPWStr)]string lpFileName, Int32 dwFileAttributes);

        /// <summary>
        /// Gets the short path name w.
        /// </summary>
        /// <param name="lLongPath">The l long path.</param>
        /// <param name="lShortPath">The l short path.</param>
        /// <param name="lBuffer">The l buffer.</param>
        /// <returns>Int32.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Int32 GetShortPathNameW([MarshalAs(UnmanagedType.LPWStr)]string lLongPath, [MarshalAs(UnmanagedType.LPWStr)]string lShortPath, Int32 lBuffer);

        /// <summary>
        /// Gets the file size ex.
        /// </summary>
        /// <param name="hFile">The h file.</param>
        /// <param name="lpFileSize">Size of the lp file.</param>
        /// <returns>Boolean.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean GetFileSizeEx(IntPtr hFile, out UInt32 lpFileSize);

        /// <summary>
        /// Moves the file ex w.
        /// </summary>
        /// <param name="lpExistingFileName">Name of the lp existing file.</param>
        /// <param name="lpNewFileName">Name of the lp new file.</param>
        /// <param name="dwFlags">The dw flags.</param>
        /// <returns>Int32.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Int32 MoveFileExW([MarshalAs(UnmanagedType.LPWStr)]string lpExistingFileName, [MarshalAs(UnmanagedType.LPWStr)]string lpNewFileName, Int32 dwFlags);

        /// <summary>
        /// Deletes the file w.
        /// </summary>
        /// <param name="lpFileName">Name of the lp file.</param>
        /// <returns>Int32.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Int32 DeleteFileW([MarshalAs(UnmanagedType.LPWStr)]string lpFileName);

        /// <summary>
        /// Removes the directory w.
        /// </summary>
        /// <param name="lpPathName">Name of the lp path.</param>
        /// <returns>Int32.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Int32 RemoveDirectoryW([MarshalAs(UnmanagedType.LPWStr)]string lpPathName);

        /// <summary>
        /// Devices the io control.
        /// </summary>
        /// <param name="hDevice">The h device.</param>
        /// <param name="dwIoControlCode">The dw io control code.</param>
        /// <param name="lpInBuffer">The lp in buffer.</param>
        /// <param name="nInBufferSize">Size of the n in buffer.</param>
        /// <param name="lpOutBuffer">The lp out buffer.</param>
        /// <param name="nOutBufferSize">Size of the n out buffer.</param>
        /// <param name="lpBytesReturned">The lp bytes returned.</param>
        /// <param name="lpOverlapped">The lp overlapped.</param>
        /// <returns>Boolean.</returns>
        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean DeviceIoControl(IntPtr hDevice, UInt32 dwIoControlCode, IntPtr lpInBuffer, UInt32 nInBufferSize, IntPtr lpOutBuffer, [Optional] UInt32 nOutBufferSize, out UInt32 lpBytesReturned, IntPtr lpOverlapped);

        /// <summary>
        /// Finds the first file w.
        /// </summary>
        /// <param name="lpFileName">Name of the lp file.</param>
        /// <param name="lpFindFileData">The lp find file data.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr FindFirstFileW([MarshalAs(UnmanagedType.LPWStr)]string lpFileName, out WIN32_FIND_DATAW lpFindFileData);

        /// <summary>
        /// Finds the next file w.
        /// </summary>
        /// <param name="hFindFile">The h find file.</param>
        /// <param name="lpFindFileData">The lp find file data.</param>
        /// <returns>Boolean.</returns>
        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean FindNextFileW(IntPtr hFindFile, out WIN32_FIND_DATAW lpFindFileData);

        /// <summary>
        /// Finds the close.
        /// </summary>
        /// <param name="hFindFile">The h find file.</param>
        /// <returns>Boolean.</returns>
        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean FindClose(IntPtr hFindFile);
    }
}
