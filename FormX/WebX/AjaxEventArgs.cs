// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="AjaxEventArgs.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.Utilities.Web
{
    /// <summary>
    /// Represents the plain Ajax event arguments.
    /// </summary>
    public class AjaxEventArgs : EventArgs
    {
        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="options">We expect some options here.</param>
        public AjaxEventArgs(AjaxRequestOptions options)
        {
            Options = options;
        }

        /// <summary>
        /// Gets the passed AjaxRequestOptions.
        /// </summary>
        public AjaxRequestOptions Options { get; private set; }
    }
}
