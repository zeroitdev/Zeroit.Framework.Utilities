// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="NoMatchFoundException.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// This is thrown on String.DehumanizeTo enum when the provided string cannot be mapped to the target enum
    /// </summary>
    /// <seealso cref="System.Exception" />
#pragma warning disable 1591
    public class NoMatchFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoMatchFoundException"/> class.
        /// </summary>
        public NoMatchFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoMatchFoundException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public NoMatchFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoMatchFoundException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public NoMatchFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
#pragma warning restore 1591
}