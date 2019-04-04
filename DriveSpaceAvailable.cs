// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DriveSpaceAvailable.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
