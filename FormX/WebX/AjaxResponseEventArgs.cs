// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="AjaxResponseEventArgs.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.Web
{
    /// <summary>
    /// Represents the ajax event arguments for having a response.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.Web.AjaxEventArgs" />
    public class AjaxResponseEventArgs : AjaxEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AjaxResponseEventArgs"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="text">The text.</param>
        /// <param name="response">The response.</param>
        public AjaxResponseEventArgs (AjaxRequestOptions options, string text, object response) : base(options)
	    {
            ResponseText = text;
            Response = response;
	    }

        /// <summary>
        /// Gets the received text.
        /// </summary>
        /// <value>The response text.</value>
        public string ResponseText { get; private set; }

        /// <summary>
        /// Gets the requested object from the response.
        /// </summary>
        /// <value>The response.</value>
        public object Response { get; private set; }
    }
}
