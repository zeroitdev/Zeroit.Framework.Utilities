// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="LUID.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Struct LUID
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct LUID
    {
        /// <summary>
        /// The low part
        /// </summary>
        public Int32 LowPart;
        /// <summary>
        /// The high part
        /// </summary>
        public Int32 HighPart;
    }
}
