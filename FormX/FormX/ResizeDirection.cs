// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ResizeDirection.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.ControlUtils
{
    /// <summary>
    /// Enumeration for resize direction cursors
    /// </summary>
    public enum ResizeDirection
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 0,
        /// <summary>
        /// The left
        /// </summary>
        Left = 1,
        /// <summary>
        /// The top left
        /// </summary>
        TopLeft = 2,
        /// <summary>
        /// The top
        /// </summary>
        Top = 4,
        /// <summary>
        /// The top right
        /// </summary>
        TopRight = 8,
        /// <summary>
        /// The right
        /// </summary>
        Right = 16,
        /// <summary>
        /// The bottom right
        /// </summary>
        BottomRight = 32,
        /// <summary>
        /// The bottom
        /// </summary>
        Bottom = 64,
        /// <summary>
        /// The bottom left
        /// </summary>
        BottomLeft = 128
    }
}
