// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="SECURITY_ATTRIBUTES.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Struct SECURITY_ATTRIBUTES
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SECURITY_ATTRIBUTES
    {
        /// <summary>
        /// The n length
        /// </summary>
        public int nLength;
        /// <summary>
        /// The lp security descriptor
        /// </summary>
        public int lpSecurityDescriptor;
        /// <summary>
        /// The b inherit handle
        /// </summary>
        public bool bInheritHandle;
    }
}
