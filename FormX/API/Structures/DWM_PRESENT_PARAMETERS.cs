// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DWM_PRESENT_PARAMETERS.cs" company="Zeroit Dev Technologies">
//    This program contains Utilities for all C# programming activities.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
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
