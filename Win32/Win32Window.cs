// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Win32Window.cs" company="Zeroit Dev Technologies">
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
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.Win32
{
    /// <summary>
    /// Class Win32Window.
    /// </summary>
    public class Win32Window
    {
        #region Api declarations

        /// <summary>
        /// The srccopy
        /// </summary>
        private const int SRCCOPY = 0x00CC0020;

        /// <summary>
        /// The GWL exstyle
        /// </summary>
        private const int GWL_EXSTYLE = -20;
        /// <summary>
        /// The ws ex toolwindow
        /// </summary>
        private const int WS_EX_TOOLWINDOW = 0x00000080;
        /// <summary>
        /// The ws ex appwindow
        /// </summary>
        private const int WS_EX_APPWINDOW = 0x00040000;

        /// <summary>
        /// Sets the foreground window.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetForegroundWindow(IntPtr window);

        /// <summary>
        /// Sets the focus.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll")]
        private static extern int SetFocus(IntPtr window);

        /// <summary>
        /// Brings the window to top.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        static extern bool BringWindowToTop(IntPtr window);

        /// <summary>
        /// Finds the window ex.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="childAfter">The child after.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="windowName">Name of the window.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll")]
        static extern IntPtr FindWindowEx(IntPtr parent, IntPtr childAfter, string className, string windowName);

        /// <summary>
        /// Finds the window win32.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="windowName">Name of the window.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        static extern IntPtr FindWindowWin32(string className, string windowName);

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <param name="message">The message.</param>
        /// <param name="wparam">The wparam.</param>
        /// <param name="lparam">The lparam.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr window, int message, int wparam, int lparam);

        /// <summary>
        /// Posts the message.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <param name="message">The message.</param>
        /// <param name="wparam">The wparam.</param>
        /// <param name="lparam">The lparam.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll")]
        static extern int PostMessage(IntPtr window, int message, int wparam, int lparam);

        /// <summary>
        /// Gets the parent.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll")]
        static extern IntPtr GetParent(IntPtr window);

        /// <summary>
        /// Gets the desktop window.
        /// </summary>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll")]
        static extern IntPtr GetDesktopWindow();

        /// <summary>
        /// Gets the foreground window.
        /// </summary>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        /// <summary>
        /// Gets the last active popup.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll")]
        static extern IntPtr GetLastActivePopup(IntPtr window);

        /// <summary>
        /// Gets the window text.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <param name="text">The text.</param>
        /// <param name="copyCount">The copy count.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll")]
        static extern int GetWindowText(
            IntPtr window,
            [In][Out] StringBuilder text,
            int copyCount);

        /// <summary>
        /// Sets the window text.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <param name="text">The text.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        static extern bool SetWindowText(
            IntPtr window,
            [MarshalAs(UnmanagedType.LPTStr)]
			string text);

        /// <summary>
        /// Gets the length of the window text.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll")]
        static extern int GetWindowTextLength(IntPtr window);

        /// <summary>
        /// Sets the window long.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <param name="index">The index.</param>
        /// <param name="value">The value.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll")]
        static extern int SetWindowLong(
            IntPtr window,
            int index,
            int value);

        /// <summary>
        /// Gets the window long.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <param name="index">The index.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll")]
        static extern int GetWindowLong(
            IntPtr window,
            int index);

        // BOOL CALLBACK EnumWindowsProc(
        //				  HWND hwnd,      // handle to parent window
        //				  LPARAM lParam   // application-defined value
        //		
        /// <summary>
        /// Delegate EnumWindowsProc
        /// </summary>
        /// <param name="window">The window.</param>
        /// <param name="i">The i.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        delegate bool EnumWindowsProc(
            IntPtr window, int i);

        // BOOL EnumWindows(
        //	WNDENUMPROC lpEnumFunc,  // callback function
        //	LPARAM lParam            // application-defined value
        //	);
        /// <summary>
        /// Enums the child windows.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <param name="callback">The callback.</param>
        /// <param name="i">The i.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        static extern bool EnumChildWindows(
            IntPtr window, EnumWindowsProc callback, int i);

        /// <summary>
        /// Enums the thread windows.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="callback">The callback.</param>
        /// <param name="i">The i.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        static extern bool EnumThreadWindows(
            int threadId, EnumWindowsProc callback, int i);

        /// <summary>
        /// Enums the windows.
        /// </summary>
        /// <param name="callback">The callback.</param>
        /// <param name="i">The i.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        static extern bool EnumWindows(EnumWindowsProc callback, int i);

        /// <summary>
        /// Gets the window thread process identifier.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <param name="processId">The process identifier.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll")]
        static extern int GetWindowThreadProcessId(IntPtr window, ref int processId);

        /// <summary>
        /// Gets the window thread process identifier.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <param name="ptr">The PTR.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll")]
        static extern int GetWindowThreadProcessId(IntPtr window, IntPtr ptr);

        /// <summary>
        /// Gets the window placement.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <param name="position">The position.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        static extern bool GetWindowPlacement(IntPtr window, ref WindowPlacement position);

        /// <summary>
        /// Sets the window placement.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <param name="position">The position.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        static extern bool SetWindowPlacement(IntPtr window, ref WindowPlacement position);

        /// <summary>
        /// Determines whether the specified parent is child.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="window">The window.</param>
        /// <returns><c>true</c> if the specified parent is child; otherwise, <c>false</c>.</returns>
        [DllImport("user32.dll")]
        static extern bool IsChild(IntPtr parent, IntPtr window);

        /// <summary>
        /// Determines whether the specified window is iconic.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <returns><c>true</c> if the specified window is iconic; otherwise, <c>false</c>.</returns>
        [DllImport("user32.dll")]
        static extern bool IsIconic(IntPtr window);

        /// <summary>
        /// Determines whether the specified window is zoomed.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <returns><c>true</c> if the specified window is zoomed; otherwise, <c>false</c>.</returns>
        [DllImport("user32.dll")]
        static extern bool IsZoomed(IntPtr window);

        /// <summary>
        /// Gets the window dc.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);

        /// <summary>
        /// Releases the dc.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="dc">The dc.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr hwnd, IntPtr dc);

        /// <summary>
        /// Gets the window rect.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hwnd, ref RECTAPI rectangle);

        /// <summary>
        /// Gets the client rect.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        private static extern bool GetClientRect(IntPtr hwnd, ref RECTAPI rectangle);

        /// <summary>
        /// Bits the BLT.
        /// </summary>
        /// <param name="hDestDC">The h dest dc.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="nWidth">Width of the n.</param>
        /// <param name="nHeight">Height of the n.</param>
        /// <param name="hSrcDC">The h source dc.</param>
        /// <param name="xSrc">The x source.</param>
        /// <param name="ySrc">The y source.</param>
        /// <param name="dwRop">The dw rop.</param>
        /// <returns>UInt64.</returns>
        [DllImport("gdi32.dll")]
        private static extern UInt64 BitBlt
               (IntPtr hDestDC, int x, int y, int nWidth, int nHeight,
                IntPtr hSrcDC, int xSrc, int ySrc, System.Int32 dwRop);

        /// <summary>
        /// Gets the window information.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="info">The information.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        private static extern bool GetWindowInfo(IntPtr hwnd, ref WindowInfo info);

        #endregion

        #region Static members

        /// <summary>
        /// The top level windows
        /// </summary>
        private static ArrayList _topLevelWindows = null;

        /// <summary>
        /// Enumerates the top level proc.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <param name="i">The i.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private static bool EnumerateTopLevelProc(IntPtr window, int i)
        {
            _topLevelWindows.Add(new Win32Window(window));
            return (true);
        }
        /// <summary>
        /// Enumerates the thread proc.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <param name="i">The i.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private static bool EnumerateThreadProc(IntPtr window, int i)
        {
            _topLevelWindows.Add(new Win32Window(window));
            return (true);
        }

        /// <summary>
        /// Gets the top level windows.
        /// </summary>
        /// <value>The top level windows.</value>
        public static ArrayList TopLevelWindows
        {
            get
            {
                _topLevelWindows = new ArrayList();
                EnumWindows(new EnumWindowsProc(EnumerateTopLevelProc), 0);
                ArrayList top = _topLevelWindows;
                _topLevelWindows = null;
                return top;
            }
        }
        /// <summary>
        /// Gets the desktop window.
        /// </summary>
        /// <value>The desktop window.</value>
        public static Win32Window DesktopWindow
        {
            get
            {
                return new Win32Window(GetDesktopWindow());
            }
        }
        /// <summary>
        /// Gets the foreground window.
        /// </summary>
        /// <value>The foreground window.</value>
        public static Win32Window ForegroundWindow
        {
            get
            {
                return new Win32Window(GetForegroundWindow());
            }
        }

        /// <summary>
        /// Gets the thread windows.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <returns>ArrayList.</returns>
        public static ArrayList GetThreadWindows(int threadId)
        {
            _topLevelWindows = new ArrayList();
            EnumThreadWindows(threadId, new EnumWindowsProc(EnumerateThreadProc), 0);
            ArrayList windows = _topLevelWindows;
            _topLevelWindows = null;
            return windows;
        }
        /// <summary>
        /// Finds the window.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="windowName">Name of the window.</param>
        /// <returns>Win32Window.</returns>
        public static Win32Window FindWindow(string className, string windowName)
        {
            return new Win32Window(FindWindowWin32(className, windowName));
        }
        /// <summary>
        /// Finds the window HWND.
        /// </summary>
        /// <param name="sWild">The s wild.</param>
        /// <returns>Win32Window.</returns>
        private static Win32Window FindWindowHwnd(string sWild)
        {
            string wname = sWild.ToUpper();
            Win32Window wnd = Win32Window.FindWindow("", wname);
            return wnd;
        }
        /// <summary>
        /// Determines whether the specified parent is child.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="window">The window.</param>
        /// <returns><c>true</c> if the specified parent is child; otherwise, <c>false</c>.</returns>
        public static bool IsChild(Win32Window parent, Win32Window window)
        {
            return IsChild(parent._window, window._window);
        }
        /// <summary>
        /// Gets the desktop as bitmap.
        /// </summary>
        /// <value>The desktop as bitmap.</value>
        public static Image DesktopAsBitmap
        {
            get
            {
                Image myImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                    Screen.PrimaryScreen.Bounds.Height);
                Graphics gr1 = Graphics.FromImage(myImage);
                IntPtr dc1 = gr1.GetHdc();
                IntPtr desktopWindow = GetDesktopWindow();
                IntPtr dc2 = GetWindowDC(desktopWindow);
                BitBlt(dc1, 0, 0, Screen.PrimaryScreen.Bounds.Width,
                    Screen.PrimaryScreen.Bounds.Height, dc2, 0, 0, SRCCOPY);
                ReleaseDC(desktopWindow, dc2);
                gr1.ReleaseHdc(dc1);
                gr1.Dispose();
                return myImage;
            }
        }

        #endregion

        #region Istance members

        /// <summary>
        /// The window
        /// </summary>
        private IntPtr _window;
        /// <summary>
        /// The window list
        /// </summary>
        private ArrayList _windowList = null;

        /// <summary>
        /// Enumerates the child proc.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <param name="i">The i.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool EnumerateChildProc(IntPtr window, int i)
        {
            _windowList.Add(new Win32Window(window));
            return (true);
        }

        /// <summary>
        /// Create a Win32Window
        /// </summary>
        /// <param name="window">handle of a window</param>
        public Win32Window(IntPtr window)
        {
            this._window = window;
        }

        /// <summary>
        /// Gets the window.
        /// </summary>
        /// <value>The window.</value>
        public IntPtr Window
		{
			get
			{
				return _window;
			}
		}
        /// <summary>
        /// Gets a value indicating whether this instance is null.
        /// </summary>
        /// <value><c>true</c> if this instance is null; otherwise, <c>false</c>.</value>
        public bool IsNull
		{
			get
			{
				return _window == IntPtr.Zero;
			}
		}
        /// <summary>
        /// Gets the children.
        /// </summary>
        /// <value>The children.</value>
        public ArrayList Children
		{
			get
			{
				_windowList = new ArrayList();
				EnumChildWindows(_window, new EnumWindowsProc(EnumerateChildProc), 0);
				ArrayList children = _windowList;
				_windowList = null;
				return children;
			}
        }
        /// <summary>
        /// Gets the parent.
        /// </summary>
        /// <value>The parent.</value>
        public Win32Window Parent
        {
            get
            {
                return new Win32Window(GetParent(_window));
            }
        }
        /// <summary>
        /// Get the last (topmost) active popup
        /// </summary>
        /// <value>The last active popup.</value>
        public Win32Window LastActivePopup
        {
            get
            {
                IntPtr popup = GetLastActivePopup(_window);
                if (popup == _window)
                    return new Win32Window(IntPtr.Zero);
                else
                    return new Win32Window(popup);
            }
        }
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get
            {
                int length = GetWindowTextLength(_window);
                StringBuilder sb = new StringBuilder(length + 1);
                GetWindowText(_window, sb, sb.Capacity);
                return sb.ToString();
            }
            set
            {
                SetWindowText(_window, value);
            }
        }
        /// <summary>
        /// Gets the thread identifier.
        /// </summary>
        /// <value>The thread identifier.</value>
        public int ThreadId
        {
            get
            {
                return GetWindowThreadProcessId(_window, IntPtr.Zero);
            }
        }
        /// <summary>
        /// Gets the process identifier.
        /// </summary>
        /// <value>The process identifier.</value>
        public int ProcessId
        {
            get
            {
                int processId = 0;
                GetWindowThreadProcessId(_window, ref processId);
                return processId;
            }
        }
        /// <summary>
        /// Gets or sets the window placement.
        /// </summary>
        /// <value>The window placement.</value>
        public WindowPlacement WindowPlacement
        {
            get
            {
                WindowPlacement placement = new WindowPlacement();
                GetWindowPlacement(_window, ref placement);
                return placement;
            }
            set
            {
                SetWindowPlacement(_window, ref value);
            }
        }
        /// <summary>
        /// Gets a value indicating whether this <see cref="Win32Window"/> is minimized.
        /// </summary>
        /// <value><c>true</c> if minimized; otherwise, <c>false</c>.</value>
        public bool Minimized
        {
            get
            {
                return IsIconic(_window);
            }
        }
        /// <summary>
        /// Gets a value indicating whether this <see cref="Win32Window"/> is maximized.
        /// </summary>
        /// <value><c>true</c> if maximized; otherwise, <c>false</c>.</value>
        public bool Maximized
        {
            get
            {
                return IsZoomed(_window);
            }
        }

        /// <summary>
        /// Brings the window to top.
        /// </summary>
        public void BringWindowToTop()
        {
            BringWindowToTop(_window);
        }
        /// <summary>
        /// Find a child of this window
        /// </summary>
        /// <param name="className">Name of the class, or null</param>
        /// <param name="windowName">Name of the window, or null</param>
        /// <returns>Win32Window.</returns>
        public Win32Window FindChild(string className, string windowName)
        {
            return new Win32Window(
                FindWindowEx(_window, IntPtr.Zero, className, windowName));
        }
        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="wparam">The wparam.</param>
        /// <param name="lparam">The lparam.</param>
        /// <returns>System.Int32.</returns>
        public int SendMessage(int message, int wparam, int lparam)
        {
            return SendMessage(_window, message, wparam, lparam);
        }
        /// <summary>
        /// Posts the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="wparam">The wparam.</param>
        /// <param name="lparam">The lparam.</param>
        /// <returns>System.Int32.</returns>
        public int PostMessage(int message, int wparam, int lparam)
        {
            return PostMessage(_window, message, wparam, lparam);
        }
        /// <summary>
        /// Gets the window long.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>System.Int32.</returns>
        public int GetWindowLong(int index)
        {
            return GetWindowLong(_window, index);
        }
        /// <summary>
        /// Sets the window long.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="value">The value.</param>
        /// <returns>System.Int32.</returns>
        public int SetWindowLong(int index, int value)
        {
            return SetWindowLong(_window, index, value);
        }
        /// <summary>
        /// Makes the tool window.
        /// </summary>
        public void MakeToolWindow()
        {
            int windowStyle = GetWindowLong(GWL_EXSTYLE);
            SetWindowLong(GWL_EXSTYLE, windowStyle | WS_EX_TOOLWINDOW);
        }
        /// <summary>
        /// Gets the window as bitmap.
        /// </summary>
        /// <value>The window as bitmap.</value>
        public /*unsafe*/ Image WindowAsBitmap
        {
            get
            {
                if (IsNull)
                    return null;

                this.BringWindowToTop();
                System.Threading.Thread.Sleep(500);

                RECTAPI rect = new RECTAPI();
                if (!GetWindowRect(_window, ref rect))
                    return null;

                WindowInfo windowInfo = new WindowInfo();
                windowInfo.Size = Marshal.SizeOf(typeof(WindowInfo));
                if (!GetWindowInfo(_window, ref windowInfo))
                    return null;

                Image myImage = new Bitmap(rect.Width, rect.Height);
                Graphics gr1 = Graphics.FromImage(myImage);
                IntPtr dc1 = gr1.GetHdc();
                IntPtr dc2 = GetWindowDC(_window);
                BitBlt(dc1, 0, 0, rect.Width, rect.Height, dc2, 0, 0, SRCCOPY);
                ReleaseDC(_window, dc2);
                gr1.ReleaseHdc(dc1);
                gr1.Dispose();
                return myImage;

            }
        }

        /// <summary>
        /// Sets as foreground window.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SetAsForegroundWindow()
        {
            return SetForegroundWindow(_window);
        }

        /// <summary>
        /// Gets the window client as bitmap.
        /// </summary>
        /// <value>The window client as bitmap.</value>
        public /*unsafe*/ Image WindowClientAsBitmap
        {
            get
            {
                if (IsNull)
                    return null;

                this.BringWindowToTop();
                System.Threading.Thread.Sleep(500);

                RECTAPI rect = new RECTAPI();
                if (!GetClientRect(_window, ref rect))
                    return null;

                WindowInfo windowInfo = new WindowInfo();
                windowInfo.Size = Marshal.SizeOf(typeof(WindowInfo));
                if (!GetWindowInfo(_window, ref windowInfo))
                    return null;

                int xOffset = windowInfo.ClientRect.X - windowInfo.WindowRect.X;
                int yOffset = windowInfo.ClientRect.Y - windowInfo.WindowRect.Y;

                Image myImage = new Bitmap(rect.Width, rect.Height);
                Graphics gr1 = Graphics.FromImage(myImage);
                IntPtr dc1 = gr1.GetHdc();
                IntPtr dc2 = GetWindowDC(_window);
                BitBlt(dc1, 0, 0, rect.Width, rect.Height, dc2, xOffset, yOffset, SRCCOPY);
                gr1.ReleaseHdc(dc1);
                return myImage;
            }
        }
        /// <summary>
        /// Focuses this instance.
        /// </summary>
        public void Focus()
        {
            /*UIPermission _permission = new UIPermission(UIPermissionWindow.AllWindows);
            _permission.Demand();*/
            //SetFocus(_window);
            SetForegroundWindow(_window);
        }

        #endregion

	}
}


