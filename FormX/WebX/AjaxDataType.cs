// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="AjaxDataType.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.Web
{
    /// <summary>
    /// Represents the datatype you'll expect from the server.
    /// </summary>
    public enum AjaxDataType
    {
        /// <summary>
        /// The guess
        /// </summary>
        Guess,
        /// <summary>
        /// The XML
        /// </summary>
        Xml,
        /// <summary>
        /// The json
        /// </summary>
        Json,
        /// <summary>
        /// The jsonp
        /// </summary>
        Jsonp,
        /// <summary>
        /// The script
        /// </summary>
        Script,
        /// <summary>
        /// The HTML
        /// </summary>
        Html
    }
}
