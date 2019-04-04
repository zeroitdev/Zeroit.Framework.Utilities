// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="MOVEFILE.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.WindowsAPI.Enumerations
{
    /// <summary>
    /// Enum MOVEFILE
    /// </summary>
    public enum MOVEFILE
    {
        /// <summary>
        /// The replace existing
        /// </summary>
        REPLACE_EXISTING = 0x1,
        /// <summary>
        /// The delay until reboot
        /// </summary>
        DELAY_UNTIL_REBOOT = 0x4,
        /// <summary>
        /// The write through
        /// </summary>
        WRITE_THROUGH = 0x8,
    }
}
