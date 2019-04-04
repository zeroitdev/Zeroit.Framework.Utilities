// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DWM_THUMBNAIL_PROPERTIES.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Struct DWM_THUMBNAIL_PROPERTIES
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DWM_THUMBNAIL_PROPERTIES
    {
        /// <summary>
        /// The dw flags
        /// </summary>
        public int dwFlags;
        /// <summary>
        /// The rc destination
        /// </summary>
        public RECT rcDestination;
        /// <summary>
        /// The rc source
        /// </summary>
        public RECT rcSource;
        /// <summary>
        /// The opacity
        /// </summary>
        public byte opacity;
        /// <summary>
        /// The f visible
        /// </summary>
        public int fVisible;
        /// <summary>
        /// The f source client area only
        /// </summary>
        public int fSourceClientAreaOnly;
    }
}
