// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="NCCALCSIZE_PARAMS.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Struct NCCALCSIZE_PARAMS
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NCCALCSIZE_PARAMS
    {
        /// <summary>
        /// The rect0
        /// </summary>
        public RECT rect0;
        /// <summary>
        /// The rect1
        /// </summary>
        public RECT rect1;
        /// <summary>
        /// The rect2
        /// </summary>
        public RECT rect2;
        /// <summary>
        /// The lppos
        /// </summary>
        public IntPtr lppos;
    }
}
