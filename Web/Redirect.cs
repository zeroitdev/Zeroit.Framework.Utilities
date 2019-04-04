// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Redirect.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web;

namespace Zeroit.Framework.Utilities.Web
{
    /// <summary>
    /// Class ResponseExtender.
    /// </summary>
    public static class ResponseExtender
    {
        /// <summary>
        /// Redirects the format.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public static void RedirectFormat(this HttpResponse response, string format, params object[] args)
        {
            response.Redirect(String.Format(format, args));
        }
    }
}
