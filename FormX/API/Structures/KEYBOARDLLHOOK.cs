// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="KEYBOARDLLHOOK.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Class KEYBOARDLLHOOK.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class KEYBOARDLLHOOK
    {
        /// <summary>
        /// The vk code
        /// </summary>
        public int vkCode;
        /// <summary>
        /// The scan code
        /// </summary>
        public int scanCode;
        /// <summary>
        /// The flags
        /// </summary>
        public int flags;
        /// <summary>
        /// The time
        /// </summary>
        public int time;
        /// <summary>
        /// The dw extra information
        /// </summary>
        public int dwExtraInfo;
    }
}
