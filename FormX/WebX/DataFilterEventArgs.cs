// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DataFilterEventArgs.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.Web
{
    /// <summary>
    /// Represents the event arguments for filtering data.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.Web.AjaxEventArgs" />
    public class DataFilterEventArgs : AjaxEventArgs
    {
        /// <summary>
        /// The Constructor.
        /// </summary>
        /// <param name="options">The given AjaxRequest options.</param>
        /// <param name="data">The received data as a string.</param>
        public DataFilterEventArgs(AjaxRequestOptions options, string data) : base(options)
        {
            OriginalData = data;
            ModifiedData = data;
        }

        /// <summary>
        /// Gets the original data.
        /// </summary>
        /// <value>The original data.</value>
        public string OriginalData { get; private set; }

        /// <summary>
        /// Gets or sets the modified data.
        /// </summary>
        /// <value>The modified data.</value>
        public string ModifiedData { get; set; }
    }
}
