// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="GetControls.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities
{
    /// <summary>
    /// Description of Control.
    /// </summary>
    public static partial class FormUtils
    {

        /// <summary>
        /// Gets the sub control.
        /// </summary>
        /// <param name="Parent">The parent.</param>
        /// <param name="Name">The name.</param>
        /// <param name="SearchSubControls">if set to <c>true</c> [search sub controls].</param>
        /// <returns>Control.</returns>
        public static Control GetSubControl(Control Parent,string Name,bool SearchSubControls)
		{
			Control xControl=Parent.Controls[Name];
			if(xControl!=null)
				return xControl;
			if(SearchSubControls)
			{
				foreach(Control xControlSub in Parent.Controls)
				{
					return GetSubControl(xControlSub,Name,true);
				}
			}
			return null;
		}

        /// <summary>
        /// Gets the sub control.
        /// </summary>
        /// <param name="Parent">The parent.</param>
        /// <param name="Name">The name.</param>
        /// <returns>Control.</returns>
        public static Control GetSubControl(Control Parent,string Name)
		{
			return GetSubControl(Parent,Name,true);
		}
		

	}
}
