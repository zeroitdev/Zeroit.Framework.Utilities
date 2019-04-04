// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-22-2018
// ***********************************************************************
// <copyright file="Control.cs" company="Zeroit Dev Technologies">
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
namespace Zeroit.Framework.Utilities.Simulation
{
    /// <summary>
    /// Class Control.
    /// </summary>
    public static class Control
    {
        /// <summary>
        /// Delegate PressEnter_Delegate
        /// </summary>
        /// <param name="xControl">The x control.</param>
        public delegate void PressEnter_Delegate(System.Windows.Forms.Control xControl);

        /// <summary>
        /// Presses the enter.
        /// </summary>
        /// <param name="xControl">The x control.</param>
        public static void PressEnter(System.Windows.Forms.Control xControl)
        {
            if (xControl.InvokeRequired)
            {
                PressEnter_Delegate xFun = new PressEnter_Delegate(PressEnter);
                xControl.Invoke(xFun, new object[] { xControl });
                return;
            }
            xControl.Focus();
            System.Windows.Forms.SendKeys.SendWait("{ENTER}");
        }


    }

}
