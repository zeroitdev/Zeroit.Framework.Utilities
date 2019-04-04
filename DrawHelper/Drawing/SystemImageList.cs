// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="SystemImageList.cs" company="Zeroit Dev Technologies">
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
using Zeroit.Framework.Utilities.Win32;
using System.Runtime.InteropServices;



namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing
{
    /// <summary>
    /// Class SystemImageList.
    /// </summary>
    public class SystemImageList
    {
        #region Member Variables

        // Used to store the handle of the system image list.
        /// <summary>
        /// The m p img handle
        /// </summary>
        private static IntPtr m_pImgHandle = IntPtr.Zero;

        // Flags whether we've already retrieved the image list handle or not.
        /// <summary>
        /// The m b img initialize
        /// </summary>
        private static Boolean m_bImgInit = false;

        #endregion

        #region Constants

        // TreeView message constants.
        /// <summary>
        /// The tvsil normal
        /// </summary>
        private const UInt32 TVSIL_NORMAL = 0;
        /// <summary>
        /// The TVM setimagelist
        /// </summary>
        private const UInt32 TVM_SETIMAGELIST = 4361;

        #endregion

        #region Private Methods

        /// <summary>
        /// Retrieves the handle of the system image list.
        /// </summary>
        /// <exception cref="Exception">
        /// The system image list handle has already been retrieved.
        /// or
        /// Unable to retrieve system image list handle.
        /// </exception>
        private static void InitImageList()
        {
            // Only initialize once.
            if (m_bImgInit)
                throw new Exception("The system image list handle has already been retrieved.");

            // Retrieve the info for a fake file so we can get the image list handle.
            SHFILEINFO shInfo = new SHFILEINFO();
            SHGFI dwAttribs =
                SHGFI.SHGFI_USEFILEATTRIBUTES |
                SHGFI.SHGFI_SMALLICON |
                SHGFI.SHGFI_SYSICONINDEX;
            m_pImgHandle = NativeShellApi.SHGetFileInfo(".txt", NativeShellApi.FILE_ATTRIBUTE_NORMAL, out shInfo, (uint)Marshal.SizeOf(shInfo), dwAttribs);

            // Make sure we got the handle.
            if (m_pImgHandle.Equals(IntPtr.Zero))
                throw new Exception("Unable to retrieve system image list handle.");

            // Only allow one initialization.
            m_bImgInit = true;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Sets the image list for the TreeView to the system image list.
        /// </summary>
        /// <param name="tvwHandle">The window handle of the TreeView control</param>
        public static void SetTVImageList(IntPtr tvwHandle)
        {
            InitImageList();
            Int32 hRes =NativeUser32Api.SendMessage(tvwHandle, TVM_SETIMAGELIST, TVSIL_NORMAL, m_pImgHandle);
            if (hRes != 0)
                Marshal.ThrowExceptionForHR(hRes);
        }

        #endregion
    }
}
