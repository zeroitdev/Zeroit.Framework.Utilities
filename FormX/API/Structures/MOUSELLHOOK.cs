// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="MOUSELLHOOK.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Class MOUSELLHOOK.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class MOUSELLHOOK
    {
        /// <summary>
        /// The pt
        /// </summary>
        public POINT pt;
        /// <summary>
        /// The mouse data
        /// </summary>
        public int mouseData;
        /// <summary>
        /// The flags
        /// </summary>
        public int flags;
        /// <summary>
        /// The time
        /// </summary>
        public int time;
        /// <summary>
        /// The extra information
        /// </summary>
        public int extraInfo;
    }
}
