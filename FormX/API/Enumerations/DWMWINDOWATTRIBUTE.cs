// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DWMWINDOWATTRIBUTE.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Enum DWMWINDOWATTRIBUTE
    /// </summary>
    public enum DWMWINDOWATTRIBUTE
    {
        /// <summary>
        /// The dwmwa allow ncpaint
        /// </summary>
        DWMWA_ALLOW_NCPAINT = 4,
        /// <summary>
        /// The dwmwa caption button bounds
        /// </summary>
        DWMWA_CAPTION_BUTTON_BOUNDS = 5,
        /// <summary>
        /// The dwmwa fli p3 d policy
        /// </summary>
        DWMWA_FLIP3D_POLICY = 8,
        /// <summary>
        /// The dwmwa force iconic representation
        /// </summary>
        DWMWA_FORCE_ICONIC_REPRESENTATION = 7,
        /// <summary>
        /// The dwmwa last
        /// </summary>
        DWMWA_LAST = 9,
        /// <summary>
        /// The dwmwa ncrendering enabled
        /// </summary>
        DWMWA_NCRENDERING_ENABLED = 1,
        /// <summary>
        /// The dwmwa ncrendering policy
        /// </summary>
        DWMWA_NCRENDERING_POLICY = 2,
        /// <summary>
        /// The dwmwa nonclient RTL layout
        /// </summary>
        DWMWA_NONCLIENT_RTL_LAYOUT = 6,
        /// <summary>
        /// The dwmwa transitions forcedisabled
        /// </summary>
        DWMWA_TRANSITIONS_FORCEDISABLED = 3
    }
}
