// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DTTOPTS.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Struct DTTOPTS
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DTTOPTS
    {
        /// <summary>
        /// The dw size
        /// </summary>
        public uint dwSize;
        /// <summary>
        /// The dw flags
        /// </summary>
        public uint dwFlags;
        /// <summary>
        /// The cr text
        /// </summary>
        public uint crText;
        /// <summary>
        /// The cr border
        /// </summary>
        public uint crBorder;
        /// <summary>
        /// The cr shadow
        /// </summary>
        public uint crShadow;
        /// <summary>
        /// The i text shadow type
        /// </summary>
        public int iTextShadowType;
        /// <summary>
        /// The pt shadow offset
        /// </summary>
        public POINT ptShadowOffset;
        /// <summary>
        /// The i border size
        /// </summary>
        public int iBorderSize;
        /// <summary>
        /// The i font property identifier
        /// </summary>
        public int iFontPropId;
        /// <summary>
        /// The i color property identifier
        /// </summary>
        public int iColorPropId;
        /// <summary>
        /// The i state identifier
        /// </summary>
        public int iStateId;
        /// <summary>
        /// The f apply overlay
        /// </summary>
        public int fApplyOverlay;
        /// <summary>
        /// The i glow size
        /// </summary>
        public int iGlowSize;
        /// <summary>
        /// The PFN draw text callback
        /// </summary>
        public IntPtr pfnDrawTextCallback;
        /// <summary>
        /// The l parameter
        /// </summary>
        public int lParam;
    }
}
