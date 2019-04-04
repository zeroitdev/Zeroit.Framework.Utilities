// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DriveSpaceAvailable.cs" company="Zeroit Dev Technologies">
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
/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/
using System;
using System.IO;

namespace Zeroit.Framework.Utilities.FileSystemOperations
{
    /// <summary>
    /// A class for checking the space available on drive
    /// </summary>
    public static class DriveSpaceAvailable
    {
        /// <summary>
        /// Total free space formatted
        /// </summary>
        /// <param name="driveInfo">Set drive info</param>
        /// <param name="sizeUnit">Set disk size unit</param>
        /// <returns>System.Double.</returns>
        public static double TotalFreeSpaceFormatted(this DriveInfo driveInfo, DiskSizeUnit sizeUnit)
        {
            double freeSpace = -1;
            double formatDivideBy = 1;

            if (driveInfo != null)
            {
                long freeSpaceNative = driveInfo.TotalFreeSpace;
                formatDivideBy = Math.Pow(1024, (int)sizeUnit);

                freeSpace = freeSpaceNative / formatDivideBy;
            }

            return freeSpace;
        }

        /// <summary>
        /// Available Free space formatted
        /// </summary>
        /// <param name="driveInfo">Set drive info</param>
        /// <param name="sizeUnit">Set size unit</param>
        /// <returns>System.Double.</returns>
        public static double AvailableFreeSpaceFormatted(this DriveInfo driveInfo, DiskSizeUnit sizeUnit)
        {
            double freeSpace = -1;
            double formatDivideBy = 1;

            if (driveInfo != null)
            {
                long freeSpaceNative = driveInfo.AvailableFreeSpace;
                formatDivideBy = Math.Pow(1024, (int)sizeUnit);

                freeSpace = freeSpaceNative / formatDivideBy;
            }

            return freeSpace;
        }
    }

    /// <summary>
    /// Set disk size unit
    /// </summary>
    public enum DiskSizeUnit
    {
        /// <summary>
        /// The bytes
        /// </summary>
        Bytes = 0,
        /// <summary>
        /// The kilo bytes
        /// </summary>
        KiloBytes = 1,
        /// <summary>
        /// The mega bytes
        /// </summary>
        MegaBytes = 2,
        /// <summary>
        /// The giga bytes
        /// </summary>
        GigaBytes = 3,
        /// <summary>
        /// The tera bytes
        /// </summary>
        TeraBytes = 4
    }

}
