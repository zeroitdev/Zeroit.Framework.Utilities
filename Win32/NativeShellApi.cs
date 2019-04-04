// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="NativeShellApi.cs" company="Zeroit Dev Technologies">
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
using System.Text;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.Win32
{
    /// <summary>
    /// Class NativeShellApi.
    /// </summary>
    public static class NativeShellApi
    {

        /// <summary>
        /// The file attribute normal
        /// </summary>
        public const Int32 FILE_ATTRIBUTE_NORMAL = 0x80;
        /// <summary>
        /// The iid i shell folder
        /// </summary>
        public static Guid IID_IShellFolder = new Guid("000214E6-0000-0000-C000-000000000046");


        /// <summary>
        /// Shes the automatic complete.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("shlwapi.dll", SetLastError = true)]
        public static extern int SHAutoComplete(IntPtr hWnd, UInt32 flags);

        /// <summary>
        /// Shes the get desktop folder.
        /// </summary>
        /// <param name="ppshf">The PPSHF.</param>
        /// <returns>Int32.</returns>
        [DllImport("shell32.dll")]
        public static extern Int32 SHGetDesktopFolder(ref IShellFolder ppshf);

        /// <summary>
        /// Shes the get file information.
        /// </summary>
        /// <param name="pszPath">The PSZ path.</param>
        /// <param name="dwFileAttribs">The dw file attribs.</param>
        /// <param name="psfi">The psfi.</param>
        /// <param name="cbFileInfo">The cb file information.</param>
        /// <param name="uFlags">The u flags.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttribs, out SHFILEINFO psfi, uint cbFileInfo, SHGFI uFlags);

        /// <summary>
        /// Shes the get file information.
        /// </summary>
        /// <param name="pIDL">The p IDL.</param>
        /// <param name="dwFileAttributes">The dw file attributes.</param>
        /// <param name="psfi">The psfi.</param>
        /// <param name="cbFileInfo">The cb file information.</param>
        /// <param name="uFlags">The u flags.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(IntPtr pIDL, uint dwFileAttributes, out SHFILEINFO psfi, uint cbFileInfo, SHGFI uFlags);

        /// <summary>
        /// Shes the get special folder location.
        /// </summary>
        /// <param name="hwndOwner">The HWND owner.</param>
        /// <param name="nFolder">The n folder.</param>
        /// <param name="ppidl">The ppidl.</param>
        /// <returns>Int32.</returns>
        [DllImport("shell32.dll")]
        public static extern Int32 SHGetSpecialFolderLocation(IntPtr hwndOwner, CSIDL nFolder, ref IntPtr ppidl);

        /// <summary>
        /// Ils the combine.
        /// </summary>
        /// <param name="pIDLParent">The p IDL parent.</param>
        /// <param name="pIDLChild">The p IDL child.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("shell32.dll")]
        public static extern IntPtr ILCombine(IntPtr pIDLParent, IntPtr pIDLChild);

        /// <summary>
        /// Shes the get path from identifier list.
        /// </summary>
        /// <param name="pIDL">The p IDL.</param>
        /// <param name="strPath">The string path.</param>
        /// <returns>Int32.</returns>
        [DllImport("shell32.dll")]
        public static extern Int32 SHGetPathFromIDList(IntPtr pIDL, StringBuilder strPath);
    }
}
