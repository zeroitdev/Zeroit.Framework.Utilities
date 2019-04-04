// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="NativeUser32Api.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.Win32
{

    /// <summary>
    /// Class NativeUser32Api.
    /// </summary>
    public static class NativeUser32Api
    {


        /// <summary>
        /// The GWL style
        /// </summary>
        public const int GWL_STYLE = -16;
        /// <summary>
        /// The ws child
        /// </summary>
        public const int WS_CHILD = 0x40000000;

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="pWnd">The p WND.</param>
        /// <param name="uMsg">The u MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>Int32.</returns>
        [DllImport("user32.dll")]
        public static extern Int32 SendMessage(IntPtr pWnd, UInt32 uMsg, UInt32 wParam, IntPtr lParam);

        /// <summary>
        /// Animates the window.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="dwTime">The dw time.</param>
        /// <param name="dwFlags">The dw flags.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern bool AnimateWindow(IntPtr hWnd, uint dwTime, uint dwFlags);
        /// <summary>
        /// Begins the paint.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="ps">The ps.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern IntPtr BeginPaint(IntPtr hWnd, ref PAINTSTRUCT ps);
        /// <summary>
        /// Clients to screen.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="pt">The pt.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern bool ClientToScreen(IntPtr hWnd, ref POINTAPI pt);
        /// <summary>
        /// Dispatches the message.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern bool DispatchMessage(ref MSG msg);
        /// <summary>
        /// Draws the focus rect.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="rect">The rect.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern bool DrawFocusRect(IntPtr hWnd, ref RECTAPI rect);
        /// <summary>
        /// Ends the paint.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="ps">The ps.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT ps);
        /// <summary>
        /// Gets the dc.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern IntPtr GetDC(IntPtr hWnd);
        /// <summary>
        /// Gets the focus.
        /// </summary>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern IntPtr GetFocus();
        /// <summary>
        /// Gets the state of the key.
        /// </summary>
        /// <param name="virtKey">The virt key.</param>
        /// <returns>System.UInt16.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern ushort GetKeyState(int virtKey);
        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="wFilterMin">The w filter minimum.</param>
        /// <param name="wFilterMax">The w filter maximum.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern bool GetMessage(ref MSG msg, int hWnd, uint wFilterMin, uint wFilterMax);
        /// <summary>
        /// Gets the parent.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern IntPtr GetParent(IntPtr hWnd);
        /// <summary>
        /// Gets the window long.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="nIndex">Index of the n.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        /// <summary>
        /// Gets the window rect.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="rect">The rect.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECTAPI rect);
        /// <summary>
        /// Hides the caret.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern bool HideCaret(IntPtr hWnd);
        /// <summary>
        /// Invalidates the rect.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="erase">if set to <c>true</c> [erase].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern bool InvalidateRect(IntPtr hWnd, ref RECTAPI rect, bool erase);
        /// <summary>
        /// Loads the cursor.
        /// </summary>
        /// <param name="hInstance">The h instance.</param>
        /// <param name="cursor">The cursor.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern IntPtr LoadCursor(IntPtr hInstance, uint cursor);
        /// <summary>
        /// Moves the window.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="repaint">if set to <c>true</c> [repaint].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int width, int height, bool repaint);
        /// <summary>
        /// Peeks the message.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="wFilterMin">The w filter minimum.</param>
        /// <param name="wFilterMax">The w filter maximum.</param>
        /// <param name="wFlag">The w flag.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern bool PeekMessage(ref MSG msg, int hWnd, uint wFilterMin, uint wFilterMax, uint wFlag);
        /// <summary>
        /// Posts the message.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="Msg">The MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, uint wParam, uint lParam);
        /// <summary>
        /// Releases the capture.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern bool ReleaseCapture();
        /// <summary>
        /// Releases the dc.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="hDC">The h dc.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        /// <summary>
        /// Screens to client.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="pt">The pt.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern bool ScreenToClient(IntPtr hWnd, ref POINTAPI pt);
        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="Msg">The MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>System.UInt32.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern uint SendMessage(IntPtr hWnd, int Msg, uint wParam, uint lParam);
        /// <summary>
        /// Sets the cursor.
        /// </summary>
        /// <param name="hCursor">The h cursor.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern IntPtr SetCursor(IntPtr hCursor);
        /// <summary>
        /// Sets the focus.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern IntPtr SetFocus(IntPtr hWnd);
        /// <summary>
        /// Sets the window long.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="nIndex">Index of the n.</param>
        /// <param name="newLong">The new long.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int newLong);
        /// <summary>
        /// Sets the window position.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="hWndAfter">The h WND after.</param>
        /// <param name="X">The x.</param>
        /// <param name="Y">The y.</param>
        /// <param name="Width">The width.</param>
        /// <param name="Height">The height.</param>
        /// <param name="flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndAfter, int X, int Y, int Width, int Height, uint flags);
        /// <summary>
        /// Sets the window RGN.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="hRgn">The h RGN.</param>
        /// <param name="redraw">if set to <c>true</c> [redraw].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern bool SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool redraw);
        /// <summary>
        /// Shows the caret.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern bool ShowCaret(IntPtr hWnd);
        /// <summary>
        /// Shows the window.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="cmdShow">The command show.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern int ShowWindow(IntPtr hWnd, short cmdShow);
        /// <summary>
        /// Systems the parameters information.
        /// </summary>
        /// <param name="uiAction">The UI action.</param>
        /// <param name="uiParam">The UI parameter.</param>
        /// <param name="bRetValue">The b ret value.</param>
        /// <param name="fWinINI">The f win ini.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, ref int bRetValue, uint fWinINI);
        /// <summary>
        /// Tracks the mouse event.
        /// </summary>
        /// <param name="tme">The tme.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern bool TrackMouseEvent(ref TRACKMOUSEEVENTS tme);
        /// <summary>
        /// Translates the message.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern bool TranslateMessage(ref MSG msg);
        /// <summary>
        /// Updates the layered window.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="hdcDst">The HDC DST.</param>
        /// <param name="pptDst">The PPT DST.</param>
        /// <param name="psize">The psize.</param>
        /// <param name="hdcSrc">The HDC source.</param>
        /// <param name="pprSrc">The PPR source.</param>
        /// <param name="crKey">The cr key.</param>
        /// <param name="pblend">The pblend.</param>
        /// <param name="dwFlags">The dw flags.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref POINTAPI pptDst, ref SIZE psize, IntPtr hdcSrc, ref POINTAPI pprSrc, int crKey, ref BLENDFUNCTION pblend, int dwFlags);
        /// <summary>
        /// Updates the window.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern bool UpdateWindow(IntPtr hwnd);
        /// <summary>
        /// Waits the message.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern bool WaitMessage();

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="msg">The MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, COMPOSITIONFORM lParam);

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="msg">The MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, LogFont lParam);

        /// <summary>
        /// Draws the text.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <param name="lpString">The lp string.</param>
        /// <param name="nCount">The n count.</param>
        /// <param name="Rect">The rect.</param>
        /// <param name="wFormat">The w format.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll", SetLastError = false, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int DrawText(IntPtr hDC, string lpString, int nCount, ref RECTAPI Rect, int wFormat);


        /// <summary>
        /// Gets the desktop window.
        /// </summary>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="hWND">The h WND.</param>
        /// <param name="message">The message.</param>
        /// <param name="WParam">The w parameter.</param>
        /// <param name="LParam">The l parameter.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWND, int message, int WParam, int LParam);


        /// <summary>
        /// Gets the window dc.
        /// </summary>
        /// <param name="hWND">The h WND.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetWindowDC(IntPtr hWND);

        /// <summary>
        /// Windows from dc.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromDC(int hdc);

        /// <summary>
        /// Tabbeds the text out.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="lpString">The lp string.</param>
        /// <param name="nCount">The n count.</param>
        /// <param name="nTabPositions">The n tab positions.</param>
        /// <param name="lpnTabStopPositions">The LPN tab stop positions.</param>
        /// <param name="nTabOrigin">The n tab origin.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll", SetLastError = false, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int TabbedTextOut(IntPtr hDC, int x, int y, string lpString, int nCount, int nTabPositions, ref int lpnTabStopPositions, int nTabOrigin);

        /// <summary>
        /// Fills the rect.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="hBrush">The h brush.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll", SetLastError = false, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int FillRect(IntPtr hDC, ref RECTAPI rect, IntPtr hBrush);

        /// <summary>
        /// Gets the tabbed text extent.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <param name="lpString">The lp string.</param>
        /// <param name="nCount">The n count.</param>
        /// <param name="nTabPositions">The n tab positions.</param>
        /// <param name="lpnTabStopPositions">The LPN tab stop positions.</param>
        /// <returns>System.UInt32.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern uint GetTabbedTextExtent(IntPtr hDC, string lpString, int nCount, int nTabPositions, ref int lpnTabStopPositions);

        /// <summary>
        /// Inverts the rect.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <param name="rect">The rect.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll", SetLastError = false, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int InvertRect(IntPtr hDC, ref RECTAPI rect);


        /// <summary>
        /// Gets the state of the asynchronous key.
        /// </summary>
        /// <param name="vKey">The v key.</param>
        /// <returns>UInt16.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt16 GetAsyncKeyState(int vKey);

        /// <summary>
        /// Creates the window ex.
        /// </summary>
        /// <param name="dwExStyle">The dw ex style.</param>
        /// <param name="lpClassName">Name of the lp class.</param>
        /// <param name="lpWindowName">Name of the lp window.</param>
        /// <param name="dwStyle">The dw style.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="nWidth">Width of the n.</param>
        /// <param name="nHeight">Height of the n.</param>
        /// <param name="hWndParent">The h WND parent.</param>
        /// <param name="hMenu">The h menu.</param>
        /// <param name="hInstance">The h instance.</param>
        /// <param name="lpParam">The lp parameter.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr CreateWindowEx(
           uint dwExStyle,
           string lpClassName,
           string lpWindowName,
           uint dwStyle,
           int x,
           int y,
           int nWidth,
           int nHeight,
           IntPtr hWndParent,
           IntPtr hMenu,
           IntPtr hInstance,
           IntPtr lpParam);


        /// <summary>
        /// Determines whether [is key pressed] [the specified k].
        /// </summary>
        /// <param name="k">The k.</param>
        /// <returns><c>true</c> if [is key pressed] [the specified k]; otherwise, <c>false</c>.</returns>
        public static bool IsKeyPressed(Keys k)
        {
            int s = (int)GetAsyncKeyState((int)k);
            s = (s & 0x8000) >> 15;
            return (s == 1);
        }

        //---------------------------------------
        //helper , return DC of a control
        /// <summary>
        /// Controls the dc.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns>IntPtr.</returns>
        public static IntPtr ControlDC(Control control)
        {
            return GetDC(control.Handle);
        }

        //---------------------------------------

        //---------------------------------------
        //helper , convert from and to colors from int values
        /// <summary>
        /// Colors to int.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>System.Int32.</returns>
        public static int ColorToInt(Color color)
        {
            return (color.B << 16 | color.G << 8 | color.R);
        }

        /// <summary>
        /// Ints to color.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>Color.</returns>
        public static Color IntToColor(int color)
        {
            int b = (color >> 16) & 0xFF;
            int g = (color >> 8) & 0xFF;
            int r = (color) & 0xFF;
            return Color.FromArgb(r, g, b);
        }
    }
}

