// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Key.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Zeroit.Framework.Utilities.WindowsDLL
{
    /// <summary>
    /// Description of Key.
    /// </summary>
    public static class Key
	{

        //[Flags]
        /// <summary>
        /// Enum KeyEventFlags
        /// </summary>
        public enum KeyEventFlags:int
		{
            /// <summary>
            /// The extendedkey
            /// </summary>
            EXTENDEDKEY = 1,
            /// <summary>
            /// The keyup
            /// </summary>
            KEYUP = 2,
            /// <summary>
            /// The unicode
            /// </summary>
            UNICODE = 2,
            /// <summary>
            /// The scancode
            /// </summary>
            SCANCODE = 2,
		}
        /// <summary>
        /// Enum VK
        /// </summary>
        public enum VK : ushort
		{
            /// <summary>
            /// The shift
            /// </summary>
            SHIFT = 0x10,
            /// <summary>
            /// The control
            /// </summary>
            CONTROL = 0x11,
            /// <summary>
            /// The menu
            /// </summary>
            MENU = 0x12,
            /// <summary>
            /// The escape
            /// </summary>
            ESCAPE = 0x1B,
            /// <summary>
            /// The back
            /// </summary>
            BACK = 0x08,
            /// <summary>
            /// The tab
            /// </summary>
            TAB = 0x09,
            /// <summary>
            /// The return
            /// </summary>
            RETURN = 0x0D,
            /// <summary>
            /// The prior
            /// </summary>
            PRIOR = 0x21,
            /// <summary>
            /// The next
            /// </summary>
            NEXT = 0x22,
            /// <summary>
            /// The end
            /// </summary>
            END = 0x23,
            /// <summary>
            /// The home
            /// </summary>
            HOME = 0x24,
            /// <summary>
            /// The left
            /// </summary>
            LEFT = 0x25,
            /// <summary>
            /// Up
            /// </summary>
            UP = 0x26,
            /// <summary>
            /// The right
            /// </summary>
            RIGHT = 0x27,
            /// <summary>
            /// Down
            /// </summary>
            DOWN = 0x28,
            /// <summary>
            /// The select
            /// </summary>
            SELECT = 0x29,
            /// <summary>
            /// The print
            /// </summary>
            PRINT = 0x2A,
            /// <summary>
            /// The execute
            /// </summary>
            EXECUTE = 0x2B,
            /// <summary>
            /// The snapshot
            /// </summary>
            SNAPSHOT = 0x2C,
            /// <summary>
            /// The insert
            /// </summary>
            INSERT = 0x2D,
            /// <summary>
            /// The delete
            /// </summary>
            DELETE = 0x2E,
            /// <summary>
            /// The help
            /// </summary>
            HELP = 0x2F,
            /// <summary>
            /// The numpa d0
            /// </summary>
            NUMPAD0 = 0x60,
            /// <summary>
            /// The numpa d1
            /// </summary>
            NUMPAD1 = 0x61,
            /// <summary>
            /// The numpa d2
            /// </summary>
            NUMPAD2 = 0x62,
            /// <summary>
            /// The numpa d3
            /// </summary>
            NUMPAD3 = 0x63,
            /// <summary>
            /// The numpa d4
            /// </summary>
            NUMPAD4 = 0x64,
            /// <summary>
            /// The numpa d5
            /// </summary>
            NUMPAD5 = 0x65,
            /// <summary>
            /// The numpa d6
            /// </summary>
            NUMPAD6 = 0x66,
            /// <summary>
            /// The numpa d7
            /// </summary>
            NUMPAD7 = 0x67,
            /// <summary>
            /// The numpa d8
            /// </summary>
            NUMPAD8 = 0x68,
            /// <summary>
            /// The numpa d9
            /// </summary>
            NUMPAD9 = 0x69,
            /// <summary>
            /// The multiply
            /// </summary>
            MULTIPLY = 0x6A,
            /// <summary>
            /// The add
            /// </summary>
            ADD = 0x6B,
            /// <summary>
            /// The separator
            /// </summary>
            SEPARATOR = 0x6C,
            /// <summary>
            /// The subtract
            /// </summary>
            SUBTRACT = 0x6D,
            /// <summary>
            /// The decimal
            /// </summary>
            DECIMAL = 0x6E,
            /// <summary>
            /// The divide
            /// </summary>
            DIVIDE = 0x6F,
            /// <summary>
            /// The f1
            /// </summary>
            F1 = 0x70,
            /// <summary>
            /// The f2
            /// </summary>
            F2 = 0x71,
            /// <summary>
            /// The f3
            /// </summary>
            F3 = 0x72,
            /// <summary>
            /// The f4
            /// </summary>
            F4 = 0x73,
            /// <summary>
            /// The f5
            /// </summary>
            F5 = 0x74,
            /// <summary>
            /// The f6
            /// </summary>
            F6 = 0x75,
            /// <summary>
            /// The f7
            /// </summary>
            F7 = 0x76,
            /// <summary>
            /// The f8
            /// </summary>
            F8 = 0x77,
            /// <summary>
            /// The f9
            /// </summary>
            F9 = 0x78,
            /// <summary>
            /// The F10
            /// </summary>
            F10 = 0x79,
            /// <summary>
            /// The F11
            /// </summary>
            F11 = 0x7A,
            /// <summary>
            /// The F12
            /// </summary>
            F12 = 0x7B,
            /// <summary>
            /// The oem 1
            /// </summary>
            OEM_1 = 0xBA,   // ',:' for US
                                   /// <summary>
                                   /// The oem plus
                                   /// </summary>
            OEM_PLUS = 0xBB,   // '+' any country
                                       /// <summary>
                                       /// The oem comma
                                       /// </summary>
            OEM_COMMA = 0xBC,   // ',' any country
                                       /// <summary>
                                       /// The oem minus
                                       /// </summary>
            OEM_MINUS = 0xBD,   // '-' any country
                                       /// <summary>
                                       /// The oem period
                                       /// </summary>
            OEM_PERIOD = 0xBE,   // '.' any country
                                       /// <summary>
                                       /// The oem 2
                                       /// </summary>
            OEM_2 = 0xBF,   // '/?' for US
                                   /// <summary>
                                   /// The oem 3
                                   /// </summary>
            OEM_3 = 0xC0,   // '`~' for US
                                   /// <summary>
                                   /// The media next track
                                   /// </summary>
            MEDIA_NEXT_TRACK = 0xB0,
            /// <summary>
            /// The media previous track
            /// </summary>
            MEDIA_PREV_TRACK = 0xB1,
            /// <summary>
            /// The media stop
            /// </summary>
            MEDIA_STOP = 0xB2,
            /// <summary>
            /// The media play pause
            /// </summary>
            MEDIA_PLAY_PAUSE = 0xB3,
            /// <summary>
            /// The lwin
            /// </summary>
            LWIN = 0x5B,
            /// <summary>
            /// The rwin
            /// </summary>
            RWIN = 0x5C
		}


		
	}
}
