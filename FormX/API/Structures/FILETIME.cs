// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="FILETIME.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Struct FILETIME
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct FILETIME
    {
        /// <summary>
        /// The dw low date time
        /// </summary>
        public UInt32 dwLowDateTime;
        /// <summary>
        /// The dw high date time
        /// </summary>
        public UInt32 dwHighDateTime;
    };
}
