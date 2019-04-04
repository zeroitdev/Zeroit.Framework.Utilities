// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="GetControls.cs" company="Zeroit Dev Technologies">
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
