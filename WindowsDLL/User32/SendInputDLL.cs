// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-25-2018
// ***********************************************************************
// <copyright file="SendInputDLL.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.WindowsDLL.User32
{
    /// <summary>
    /// Description of SendInput.
    /// </summary>
    public static class SendInputDLL
	{

        /// <summary>
        /// Sends the input.
        /// </summary>
        /// <param name="nInputs">The n inputs.</param>
        /// <param name="pInputs">The p inputs.</param>
        /// <param name="cbSize">Size of the cb.</param>
        /// <returns>System.UInt32.</returns>
        [DllImport("user32.dll", SetLastError=true)]
		public static extern uint SendInput(uint nInputs, INPUT [] pInputs, int cbSize);

        /// <summary>
        /// Struct MOUSEINPUT
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
		public struct MOUSEINPUT
		{
            /// <summary>
            /// The dx
            /// </summary>
            public int dx;
            /// <summary>
            /// The dy
            /// </summary>
            public int dy;
            /// <summary>
            /// The mouse data
            /// </summary>
            public int mouseData;
            /// <summary>
            /// The dw flags
            /// </summary>
            public int dwFlags;
            /// <summary>
            /// The time
            /// </summary>
            public int time;
            /// <summary>
            /// The dw extra information
            /// </summary>
            public IntPtr dwExtraInfo;
		}

        /// <summary>
        /// Struct KEYBDINPUT
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
		public struct KEYBDINPUT
		{
            /// <summary>
            /// The w vk
            /// </summary>
            public short wVk;
            /// <summary>
            /// The w scan
            /// </summary>
            public short wScan;
            /// <summary>
            /// The dw flags
            /// </summary>
            public int dwFlags;
            /// <summary>
            /// The time
            /// </summary>
            public int time;
            /// <summary>
            /// The dw extra information
            /// </summary>
            public IntPtr dwExtraInfo;
		}

        /// <summary>
        /// Struct HARDWAREINPUT
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
		public struct HARDWAREINPUT
		{
            /// <summary>
            /// The u MSG
            /// </summary>
            public int uMsg;
            /// <summary>
            /// The w parameter l
            /// </summary>
            public short wParamL;
            /// <summary>
            /// The w parameter h
            /// </summary>
            public short wParamH;
		}

        /// <summary>
        /// Struct INPUT
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
		public struct INPUT
		{
            /// <summary>
            /// The type
            /// </summary>
            [FieldOffset(0)]
			public int type;
            /// <summary>
            /// The mi
            /// </summary>
            [FieldOffset(4)]
			public MOUSEINPUT mi;
            /// <summary>
            /// The ki
            /// </summary>
            [FieldOffset(4)]
			public KEYBDINPUT ki;
            /// <summary>
            /// The hi
            /// </summary>
            [FieldOffset(4)]
			public HARDWAREINPUT hi;
		}

        /// <summary>
        /// Enum InputType
        /// </summary>
        public enum InputType:int
		{
            /// <summary>
            /// The mouse
            /// </summary>
            Mouse = 0,
            /// <summary>
            /// The keyboard
            /// </summary>
            Keyboard = 1,
            /// <summary>
            /// The hardware
            /// </summary>
            Hardware = 2

		}
        //[Flags]
        /// <summary>
        /// Enum MouseEventFlags
        /// </summary>
        public enum MouseEventFlags : int
        {
            /// <summary>
            /// The leftdown
            /// </summary>
            LEFTDOWN = 0x00000002,
            /// <summary>
            /// The leftup
            /// </summary>
            LEFTUP = 0x00000004,
            /// <summary>
            /// The middledown
            /// </summary>
            MIDDLEDOWN = 0x00000020,
            /// <summary>
            /// The middleup
            /// </summary>
            MIDDLEUP = 0x00000040,
            /// <summary>
            /// The move
            /// </summary>
            MOVE = 0x00000001,
            /// <summary>
            /// The absolute
            /// </summary>
            ABSOLUTE = 0x00008000,
            /// <summary>
            /// The rightdown
            /// </summary>
            RIGHTDOWN = 0x00000008,
            /// <summary>
            /// The rightup
            /// </summary>
            RIGHTUP = 0x00000010,
            /// <summary>
            /// The xdown
            /// </summary>
            XDOWN = 0x00000080,
            /// <summary>
            /// The xup
            /// </summary>
            XUP = 0x00000100,
            /// <summary>
            /// The virtualdesk
            /// </summary>
            VIRTUALDESK = 0x00000400,
            /// <summary>
            /// The wheel
            /// </summary>
            WHEEL = 0x00000800
        }


	}
}
