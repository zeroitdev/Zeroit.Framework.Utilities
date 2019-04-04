// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DWM_TIMING_INFO.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Struct DWM_TIMING_INFO
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DWM_TIMING_INFO
    {
        /// <summary>
        /// The cb size
        /// </summary>
        public int cbSize;
        /// <summary>
        /// The rate refresh
        /// </summary>
        public UNSIGNED_RATIO rateRefresh;
        /// <summary>
        /// The rate compose
        /// </summary>
        public UNSIGNED_RATIO rateCompose;
        /// <summary>
        /// The QPC v blank
        /// </summary>
        public long qpcVBlank;
        /// <summary>
        /// The c refresh
        /// </summary>
        public long cRefresh;
        /// <summary>
        /// The QPC compose
        /// </summary>
        public long qpcCompose;
        /// <summary>
        /// The c frame
        /// </summary>
        public long cFrame;
        /// <summary>
        /// The c refresh frame
        /// </summary>
        public long cRefreshFrame;
        /// <summary>
        /// The c refresh confirmed
        /// </summary>
        public long cRefreshConfirmed;
        /// <summary>
        /// The c flips outstanding
        /// </summary>
        public int cFlipsOutstanding;
        /// <summary>
        /// The c frame current
        /// </summary>
        public long cFrameCurrent;
        /// <summary>
        /// The c frames available
        /// </summary>
        public long cFramesAvailable;
        /// <summary>
        /// The c frame cleared
        /// </summary>
        public long cFrameCleared;
        /// <summary>
        /// The c frames received
        /// </summary>
        public long cFramesReceived;
        /// <summary>
        /// The c frames displayed
        /// </summary>
        public long cFramesDisplayed;
        /// <summary>
        /// The c frames dropped
        /// </summary>
        public long cFramesDropped;
        /// <summary>
        /// The c frames missed
        /// </summary>
        public long cFramesMissed;
    }
}
