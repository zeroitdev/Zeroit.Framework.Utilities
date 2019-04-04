// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Delegates.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Delegate HOOK_PROC_CALLBACK
    /// </summary>
    /// <param name="nCode">The n code.</param>
    /// <param name="wParam">The w parameter.</param>
    /// <param name="lParam">The l parameter.</param>
    /// <returns>System.Int32.</returns>
    public delegate int HOOK_PROC_CALLBACK(int nCode, IntPtr wParam, IntPtr lParam);
}
