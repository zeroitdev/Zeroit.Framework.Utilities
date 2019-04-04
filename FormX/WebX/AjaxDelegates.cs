// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="AjaxDelegates.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
