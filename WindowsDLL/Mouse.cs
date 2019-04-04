// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-25-2018
// ***********************************************************************
// <copyright file="Mouse.cs" company="Zeroit Dev Technologies">
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
using System;
using System.Runtime.InteropServices;
using System.Drawing;
using Zeroit.Framework.Utilities.WindowsDLL.User32;

namespace Zeroit.Framework.Utilities.WindowsDLL
{
    /// <summary>
    /// Description of Mouse.
    /// </summary>
    public static class Mouse
	{


        /// <summary>
        /// Lefts the click.
        /// </summary>
        /// <param name="xPoint">The x point.</param>
        public static void LeftClick(Point xPoint)
        {
            SendInputDLL.MOUSEINPUT xMouseInput = new SendInputDLL.MOUSEINPUT();
            SendInputDLL.INPUT xInput = new SendInputDLL.INPUT();
            //			MouseEventFlags xFlags= MouseEventFlags.LEFTDOWN&MouseEventFlags.LEFTUP&MouseEventFlags.ABSOLUTE&MouseEventFlags.ABSOLUTE;
            SendInputDLL.MouseEventFlags xFlags = SendInputDLL.MouseEventFlags.ABSOLUTE & SendInputDLL.MouseEventFlags.MOVE;
            xMouseInput.mouseData = 0;
            xMouseInput.time = 0;
            xMouseInput.dx = xPoint.X;
            xMouseInput.dy = xPoint.Y;
            xMouseInput.dwFlags = (int)xFlags;
            xMouseInput.dwExtraInfo = IntPtr.Zero;

            xInput.mi = xMouseInput;
            xInput.type = (int)SendInputDLL.InputType.Mouse;

            int xSize = Marshal.SizeOf(xInput);
            SendInputDLL.SendInput(1, new SendInputDLL.INPUT[] { xInput }, xSize);

            xInput.mi.dwFlags = (int)SendInputDLL.MouseEventFlags.LEFTDOWN;
            xMouseInput.dx = 0;
            xMouseInput.dy = 0;
            SendInputDLL.SendInput(1, new SendInputDLL.INPUT[] { xInput }, xSize);

            xInput.mi.dwFlags = (int)SendInputDLL.MouseEventFlags.LEFTUP;
            xMouseInput.dx = 0;
            xMouseInput.dy = 0;
            SendInputDLL.SendInput(1, new SendInputDLL.INPUT[] { xInput }, xSize);
            
        }

	}
}
