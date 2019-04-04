// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="GetExecutableIcon.cs" company="Zeroit Dev Technologies">
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
#region Imports

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;


#endregion

namespace Zeroit.Framework.Utilities.BitmapUtils
{
    // *************************************** class GetExecutableIcon

    /// <summary>
    /// Class for creating executable icon
    /// </summary>
    public static class GetExecutableIcon
    {

        // WIN32 ENTRY POINTS ****************************************

        // ********************************************* ExtractIconEx

        // http://www.pinvoke.net/default.aspx/shell32/ExtractIconEx.html"/>

        /// <summary>
        /// returns one or more icons 
        /// </summary>
        /// <param name="szFileName">
        /// null-terminated string specifying the name of an 
        /// executable file, DLL, or icon file from which icons will 
        /// be extracted
        /// </param>
        /// <param name="nIconIndex">
        /// the zero-based index of the first icon to extract. For 
        /// example, if this value is zero, the function extracts the 
        /// first icon in the specified file
        /// 
        /// if this value is a negative number and either phiconLarge 
        /// or phiconSmall is not NULL, the function begins by 
        /// extracting the icon whose resource identifier is equal to 
        /// the absolute value of nIconIndex. For example, use -3 to 
        /// extract the icon whose resource identifier is 3.
        /// </param>
        /// <param name="phiconLarge">
        /// pointer to an array of icon handles that receives handles 
        /// to the large icons extracted from the file; if NULL, no 
        /// large icons are extracted from the file
        /// </param>
        /// <param name="phiconSmall">
        /// pointer to an array of icon handles that receives handles 
        /// to the small icons extracted from the file; if NULL, no 
        /// small icons are extracted from the file
        /// </param>
        /// <param name="nIcons">
        /// specifies the number of icons to extract from the file
        /// </param>
        /// <returns>
        /// the number of icons found
        /// </returns>
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        static extern uint ExtractIconEx(string szFileName,
                                           int nIconIndex,
                                           IntPtr[] phiconLarge,
                                           IntPtr[] phiconSmall,
                                           uint nIcons);

        // *********************************************** DestroyIcon

        /// <summary>
        /// destroys an icon and frees any memory the icon occupied
        /// </summary>
        /// <param name="hIcon">
        /// handle to the icon to be destroyed; the icon must not be 
        /// in use
        /// </param>
        /// <returns>
        /// if succeesful, the return value is nonzero; otherwise, the 
        /// return value is zero
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool DestroyIcon(IntPtr hIcon);

        // C# ENTRY POINTS ******************************************* 

        // *************************************** get_executable_icon

        /// <summary>
        /// Attempts to extract and return the first icon in the 
        /// application's executable file; large icons are returned 
        /// before small icons
        /// </summary>
        /// <returns>
        /// first icon found in the application's executable file; if 
        /// no icons are found in the application's executable file, 
        /// the SystemIcons.Exclamation icon as a 32x32 bit icon
        /// </returns>
        /// <remarks>
        /// the local icons are destroyed by DestroyIcon; the icon 
        /// returned to the invoker must be destroyed by a call to 
        /// Icon.Dispose ( )
        /// </remarks>
        public static Icon get_executable_icon()
        {
            uint count = 0;
            Icon icon = null;
            IntPtr[] large = new IntPtr[] { IntPtr.Zero };
            IntPtr[] small = new IntPtr[] { IntPtr.Zero };

            icon = new Icon(SystemIcons.Exclamation, 32, 32);
            try
            {
                count = ExtractIconEx(Application.ExecutablePath,
                                        0,
                                        large,
                                        small,
                                        1);
                if (count > 0)
                {
                    if (large[0] != IntPtr.Zero)
                    {
                        icon = (Icon)Icon.FromHandle(
                                             large[0]).Clone();
                    }
                    else if (small[0] != IntPtr.Zero)
                    {
                        icon = (Icon)Icon.FromHandle(
                                             small[0]).Clone();
                    }
                    else
                    {
                        // already set default icon
                    }
                }
                else
                {
                    // already set default icon
                }
            }
            catch (Exception ex)
            {
                icon = new Icon(SystemIcons.Exclamation, 32, 32);
            }
            finally
            {
                // release resources
                foreach (IntPtr ptr in large)
                {
                    if (ptr != IntPtr.Zero)
                    {
                        DestroyIcon(ptr);
                    }
                }

                foreach (IntPtr ptr in small)
                {
                    if (ptr != IntPtr.Zero)
                    {
                        DestroyIcon(ptr);
                    }
                }
            }

            return (icon);
        }

    } // class GetExecutableIcon

}
