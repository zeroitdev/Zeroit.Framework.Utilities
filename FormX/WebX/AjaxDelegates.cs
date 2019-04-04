// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="AjaxDelegates.cs" company="Zeroit Dev Technologies">
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
    /// Represents a delegate to handle events from the AjaxRequest class.
    /// </summary>
    /// <param name="sender">The instance of the AjaxRequest class that initiated the request.</param>
    /// <param name="e">The AjaxEventArgs along with this handler.</param>
    public delegate void AjaxHandler(AjaxRequest sender, AjaxEventArgs e);

    /// <summary>
    /// Represents a delegate to handle events from filtering in the AjaxRequest class.
    /// </summary>
    /// <param name="sender">The instance of the AjaxRequest class that initiated the request.</param>
    /// <param name="e">The DataFilterEventArgs along with this handler.</param>
    public delegate void AjaxFilterHandler(AjaxRequest sender, DataFilterEventArgs e);

    /// <summary>
    /// Represents a delegate to handle the response in the AjaxRequest class.
    /// </summary>
    /// <param name="sender">The instance of the AjaxRequest class that initiated the request.</param>
    /// <param name="e">The AjaxResponseEventArgs along with this handler.</param>
    public delegate void AjaxResponseHandler(AjaxRequest sender, AjaxResponseEventArgs e);
}
