// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DWM_PRESENT_PARAMETERS.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Struct DWM_PRESENT_PARAMETERS
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DWM_PRESENT_PARAMETERS
    {
        /// <summary>
        /// The cb size
        /// </summary>
        public int cbSize;
        /// <summary>
        /// The f queue
        /// </summary>
        public int fQueue;
        /// <summary>
        /// The c refresh start
        /// </summary>
        public long cRefreshStart;
        /// <summary>
        /// The c buffer
        /// </summary>
        public int cBuffer;
        /// <summary>
        /// The f use source rate
        /// </summary>
        public int fUseSourceRate;
        /// <summary>
        /// The rate source
        /// </summary>
        public UNSIGNED_RATIO rateSource;
        /// <summary>
        /// The c refreshes per frame
        /// </summary>
        public int cRefreshesPerFrame;
        /// <summary>
        /// The e sampling
        /// </summary>
        public DWM_SOURCE_FRAME_SAMPLING eSampling;
    }
}
