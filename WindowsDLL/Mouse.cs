// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-25-2018
// ***********************************************************************
// <copyright file="Mouse.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
