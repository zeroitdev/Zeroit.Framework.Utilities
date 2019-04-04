// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="LUID_AND_ATTRIBUTES.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Struct LUID_AND_ATTRIBUTES
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct LUID_AND_ATTRIBUTES
    {
        /// <summary>
        /// The p luid
        /// </summary>
        public LUID pLuid;
        /// <summary>
        /// The attributes
        /// </summary>
        public Int32 Attributes;
    }
}
