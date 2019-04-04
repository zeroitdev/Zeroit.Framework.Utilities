// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ReadyState.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.Web
{
    /// <summary>
    /// Represents the different status of a web request.
    /// </summary>
    public enum ReadyState
    {
        /// <summary>
        /// The uninitialized
        /// </summary>
        Uninitialized = 0,
        /// <summary>
        /// The open
        /// </summary>
        Open = 1,
        /// <summary>
        /// The sent
        /// </summary>
        Sent = 2,
        /// <summary>
        /// The receiving
        /// </summary>
        Receiving = 3,
        /// <summary>
        /// The loaded
        /// </summary>
        Loaded = 4
    }
}
