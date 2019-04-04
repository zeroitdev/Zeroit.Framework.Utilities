// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="AjaxResponseEventArgs.cs" company="Zeroit Dev Technologies">
//    This program contains Utilities for all C# programming activities.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
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
