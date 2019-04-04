// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="NoFlickerPanel.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Colors
{
    // This exists because sometimes we need a panel which can be set to double-buffer
    // And you can't do dat with a reg'lar panel

    /// <summary>
    ///     Represents a panel control with double buffering enabled (does not flicker on update).
    /// </summary>
    [ToolboxItem(false)]
    public partial class NoFlickerPanel : System.Windows.Forms.UserControl
    {
        /// <summary>
        ///     Default constructor.
        /// </summary>
        public NoFlickerPanel()
        {
            InitializeComponent();

			this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
						  ControlStyles.AllPaintingInWmPaint |
						  ControlStyles.UserPaint, true);
			this.UpdateStyles();
        }

		private Keys[] inputKeys;

        /// <summary>
        ///     Set list of input keys.
        /// </summary>
        /// <param name="inputKeys">Array of key values.</param>
		public void SetInputKeys(Keys[] inputKeys)
		{
			this.inputKeys = inputKeys;
		}

        /// <summary>
        ///     Override to capture keys specified in <c>SetInputKeys</c>
        /// </summary>
        /// <param name="keyCode">Keycode.</param>
        /// <returns><c>True</c> if handled, <c>false</c> otherwise.</returns>
		protected override bool IsInputKey(Keys keyCode)
		{
			if (inputKeys != null)
			{
				foreach (Keys key in inputKeys)
				{
					if (keyCode == key)
					{
						return true;
					}
				}
			}
			return false;
		}
    }
}
