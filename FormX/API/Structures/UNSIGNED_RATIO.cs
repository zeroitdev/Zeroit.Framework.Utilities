// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="UNSIGNED_RATIO.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Struct UNSIGNED_RATIO
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct UNSIGNED_RATIO
    {
        /// <summary>
        /// The UI numerator
        /// </summary>
        public int uiNumerator;
        /// <summary>
        /// The UI denominator
        /// </summary>
        public int uiDenominator;
    }
}
