// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="SimpleToolTip.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;

namespace Zeroit.Framework.Utilities.ToolTip
{
    /// <summary>
    /// A very simple ToolTip wrapper to display tooltips in a more modern fashion.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ToolTip" />
    [ToolboxItem(false)]
    public class SimpleToolTip : System.Windows.Forms.ToolTip
    {
        /// <summary>
        /// The constructor.
        /// </summary>
        public SimpleToolTip()
        {
            InitialDelay = 1000;
            BackColor = Color.Black;
            ForeColor = Color.White;
            UseFading = true;
            UseAnimation = true;
            OwnerDraw = true;
            AutomaticDelay = 500;
            AutoPopDelay = 2000;
            Draw += new DrawToolTipEventHandler(Paint);
        }

        /// <summary>
        /// Paints the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DrawToolTipEventArgs"/> instance containing the event data.</param>
        void Paint(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawText();
        }
    }
}
