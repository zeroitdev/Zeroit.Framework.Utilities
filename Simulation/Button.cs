// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-22-2018
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
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



//using System.Windows.Forms;


namespace Zeroit.Framework.Utilities.Simulation
{
    /// <summary>
    /// Description of Simulate.
    /// </summary>
    public static class Button
	{


        /// <summary>
        /// Delegate PerformClick_Delegate
        /// </summary>
        /// <param name="xButton">The x button.</param>
        public delegate void PerformClick_Delegate(System.Windows.Forms.Button xButton);

        /// <summary>
        /// Presses the enter.
        /// </summary>
        /// <param name="xButton">The x button.</param>
        public static void PressEnter(System.Windows.Forms.Button xButton)
		{
            //Simulation.Control.PressEnter(xButton);
		}

        /// <summary>
        /// Performs the click.
        /// </summary>
        /// <param name="xButton">The x button.</param>
        public static void PerformClick(System.Windows.Forms.Button xButton)
        {
            if (xButton.InvokeRequired)
            {
                PerformClick_Delegate xFun = new PerformClick_Delegate(PerformClick);
                xButton.Invoke(xFun, new object[] { xButton });
                return;
            }
            xButton.PerformClick();
        }
	}
}
