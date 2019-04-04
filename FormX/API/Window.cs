// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Window.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Class containing API methods for Window handles
    /// </summary>
    public class Window
    {
        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="Msg">The MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        /// <summary>
        /// Releases the capture.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        /// <summary>
        /// Shows the window asynchronous.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="cmdShow">The command show.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("User32.dll")]
        public static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);

        /// <summary>
        /// Sets the foreground window.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("User32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// Shells the execute.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="lpOperation">The lp operation.</param>
        /// <param name="lpFile">The lp file.</param>
        /// <param name="lpParameters">The lp parameters.</param>
        /// <param name="lpDirectory">The lp directory.</param>
        /// <param name="nShowCmd">The n show command.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern int ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);

        /// <summary>
        /// Gets the version ex.
        /// </summary>
        /// <param name="osvi">The osvi.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("kernel32", EntryPoint = "GetVersionEx")]
        public static extern bool GetVersionEx(ref OSVERSIONINFO osvi);

        /// <summary>
        /// Closes the handle.
        /// </summary>
        /// <param name="hObject">The h object.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseHandle", SetLastError = true)]
        public static extern int CloseHandle(IntPtr hObject);

        /// <summary>
        /// Gets the cursor position.
        /// </summary>
        /// <param name="lpPoint">The lp point.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        /// <summary>
        /// To the ASCII.
        /// </summary>
        /// <param name="uVirtKey">The u virt key.</param>
        /// <param name="uScanCode">The u scan code.</param>
        /// <param name="lpbKeyState">State of the LPB key.</param>
        /// <param name="lpwTransKey">The LPW trans key.</param>
        /// <param name="fuState">State of the fu.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32")]
        public static extern int ToAscii(int uVirtKey, int uScanCode, byte[] lpbKeyState, byte[] lpwTransKey, int fuState);

        /// <summary>
        /// Gets the state of the keyboard.
        /// </summary>
        /// <param name="pbKeyState">State of the pb key.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32")]
        public static extern int GetKeyboardState(byte[] pbKeyState);

        /// <summary>
        /// Gets the state of the key.
        /// </summary>
        /// <param name="vKey">The v key.</param>
        /// <returns>System.Int16.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern short GetKeyState(int vKey);

        /// <summary>
        /// Sets the windows hook ex.
        /// </summary>
        /// <param name="idHook">The identifier hook.</param>
        /// <param name="lpfn">The LPFN.</param>
        /// <param name="hInstance">The h instance.</param>
        /// <param name="threadId">The thread identifier.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll")]
        public static extern int SetWindowsHookEx(int idHook, HOOK_PROC_CALLBACK lpfn, IntPtr hInstance, int threadId);

        /// <summary>
        /// Unhooks the windows hook ex.
        /// </summary>
        /// <param name="idHook">The identifier hook.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        public static extern bool UnhookWindowsHookEx(int idHook);

        /// <summary>
        /// Calls the next hook ex.
        /// </summary>
        /// <param name="idHook">The identifier hook.</param>
        /// <param name="nCode">The n code.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll")]
        public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Gets the dc.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hdc);

        /// <summary>
        /// Saves the dc.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("gdi32.dll")]
        public static extern int SaveDC(IntPtr hdc);

        /// <summary>
        /// Releases the dc.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <param name="state">The state.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hdc, int state);

        /// <summary>
        /// Draws the theme text ex.
        /// </summary>
        /// <param name="hTheme">The h theme.</param>
        /// <param name="hdc">The HDC.</param>
        /// <param name="iPartId">The i part identifier.</param>
        /// <param name="iStateId">The i state identifier.</param>
        /// <param name="text">The text.</param>
        /// <param name="iCharCount">The i character count.</param>
        /// <param name="dwFlags">The dw flags.</param>
        /// <param name="pRect">The p rect.</param>
        /// <param name="pOptions">The p options.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("UxTheme.dll", CharSet = CharSet.Unicode)]
        public static extern int DrawThemeTextEx(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, string text, int iCharCount, int dwFlags, ref RECT pRect, ref DTTOPTS pOptions);

        /// <summary>
        /// Draws the theme text.
        /// </summary>
        /// <param name="hTheme">The h theme.</param>
        /// <param name="hdc">The HDC.</param>
        /// <param name="iPartId">The i part identifier.</param>
        /// <param name="iStateId">The i state identifier.</param>
        /// <param name="text">The text.</param>
        /// <param name="iCharCount">The i character count.</param>
        /// <param name="dwFlags1">The dw flags1.</param>
        /// <param name="dwFlags2">The dw flags2.</param>
        /// <param name="pRect">The p rect.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("UxTheme.dll")]
        public static extern int DrawThemeText(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, string text, int iCharCount, int dwFlags1, int dwFlags2, ref RECT pRect);

        /// <summary>
        /// Creates the dib section.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <param name="pbmi">The pbmi.</param>
        /// <param name="iUsage">The i usage.</param>
        /// <param name="ppvBits">The PPV bits.</param>
        /// <param name="hSection">The h section.</param>
        /// <param name="dwOffset">The dw offset.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateDIBSection(IntPtr hdc, ref BITMAPINFO pbmi, uint iUsage, int ppvBits, IntPtr hSection, uint dwOffset);

        /// <summary>
        /// Bits the BLT.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <param name="nXDest">The n x dest.</param>
        /// <param name="nYDest">The n y dest.</param>
        /// <param name="nWidth">Width of the n.</param>
        /// <param name="nHeight">Height of the n.</param>
        /// <param name="hdcSrc">The HDC source.</param>
        /// <param name="nXSrc">The n x source.</param>
        /// <param name="nYSrc">The n y source.</param>
        /// <param name="dwRop">The dw rop.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("gdi32.dll")]
        public static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);

        /// <summary>
        /// Creates the compatible dc.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        /// <summary>
        /// Selects the object.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <param name="hObject">The h object.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

        /// <summary>
        /// Deletes the object.
        /// </summary>
        /// <param name="hObject">The h object.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        /// <summary>
        /// Deletes the dc.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("gdi32.dll")]
        public static extern bool DeleteDC(IntPtr hdc);

        /// <summary>
        /// DWMs the extend frame into client area.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <param name="marInset">The mar inset.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hdc, ref MARGINS marInset);

        /// <summary>
        /// DWMs the definition window proc.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="msg">The MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <param name="result">The result.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmDefWindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, out IntPtr result);

        /// <summary>
        /// DWMs the is composition enabled.
        /// </summary>
        /// <param name="pfEnabled">The pf enabled.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="Msg">The MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr SendMessage(IntPtr hWnd, Int32 Msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// DWMs the enable composition.
        /// </summary>
        /// <param name="fEnable">The f enable.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmEnableComposition(int fEnable);

        /// <summary>
        /// DWMs the enable MMCSS.
        /// </summary>
        /// <param name="fEnableMMCSS">The f enable MMCSS.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmEnableMMCSS(int fEnableMMCSS);

        /// <summary>
        /// DWMs the color of the get colorization.
        /// </summary>
        /// <param name="pcrColorization">The PCR colorization.</param>
        /// <param name="pfOpaqueBlend">The pf opaque blend.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmGetColorizationColor(ref int pcrColorization, ref int pfOpaqueBlend);

        /// <summary>
        /// DWMs the get composition timing information.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="pTimingInfo">The p timing information.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmGetCompositionTimingInfo(IntPtr hwnd, ref DWM_TIMING_INFO pTimingInfo);

        /// <summary>
        /// DWMs the get window attribute.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="dwAttribute">The dw attribute.</param>
        /// <param name="pvAttribute">The pv attribute.</param>
        /// <param name="cbAttribute">The cb attribute.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmGetWindowAttribute(IntPtr hwnd, int dwAttribute, IntPtr pvAttribute, int cbAttribute);

        /// <summary>
        /// DWMs the duration of the modify previous dx frame.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="cRefreshes">The c refreshes.</param>
        /// <param name="fRelative">The f relative.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmModifyPreviousDxFrameDuration(IntPtr hwnd, int cRefreshes, int fRelative);

        /// <summary>
        /// DWMs the size of the query thumbnail source.
        /// </summary>
        /// <param name="hThumbnail">The h thumbnail.</param>
        /// <param name="pSize">Size of the p.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmQueryThumbnailSourceSize(IntPtr hThumbnail, ref Size pSize);

        /// <summary>
        /// DWMs the register thumbnail.
        /// </summary>
        /// <param name="hwndDestination">The HWND destination.</param>
        /// <param name="hwndSource">The HWND source.</param>
        /// <param name="pMinimizedSize">Size of the p minimized.</param>
        /// <param name="phThumbnailId">The ph thumbnail identifier.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmRegisterThumbnail(IntPtr hwndDestination, IntPtr hwndSource, ref Size pMinimizedSize, ref IntPtr phThumbnailId);

        /// <summary>
        /// DWMs the duration of the set dx frame.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="cRefreshes">The c refreshes.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmSetDxFrameDuration(IntPtr hwnd, int cRefreshes);

        /// <summary>
        /// DWMs the set present parameters.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="pPresentParams">The p present parameters.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmSetPresentParameters(IntPtr hwnd, ref DWM_PRESENT_PARAMETERS pPresentParams);

        /// <summary>
        /// DWMs the set window attribute.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="dwAttribute">The dw attribute.</param>
        /// <param name="pvAttribute">The pv attribute.</param>
        /// <param name="cbAttribute">The cb attribute.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int dwAttribute, IntPtr pvAttribute, int cbAttribute);

        /// <summary>
        /// DWMs the unregister thumbnail.
        /// </summary>
        /// <param name="hThumbnailId">The h thumbnail identifier.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmUnregisterThumbnail(IntPtr hThumbnailId);

        /// <summary>
        /// DWMs the update thumbnail properties.
        /// </summary>
        /// <param name="hThumbnailId">The h thumbnail identifier.</param>
        /// <param name="ptnProperties">The PTN properties.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmUpdateThumbnailProperties(IntPtr hThumbnailId, ref DWM_THUMBNAIL_PROPERTIES ptnProperties);

        /// <summary>
        /// Set The window's theme attributes
        /// </summary>
        /// <param name="hWnd">The handle to the window</param>
        /// <param name="wtype">What type of attributes</param>
        /// <param name="attributes">The attributes to add / remove</param>
        /// <param name="size">The size of the attributes struct</param>
        /// <returns>If the call was successful or not</returns>
        [DllImport("UxTheme.dll")]
        public static extern int SetWindowThemeAttribute(IntPtr hWnd, WTATYPE wtype, ref WTA_OPTIONS attributes, uint size);

        /// <summary>
        /// Checks if Windows is higher or equal than a minimum version.
        /// </summary>
        /// <param name="minimum">The lowest possible version.</param>
        /// <returns>Result of operation system check.</returns>
        public bool VersionCheck(VER_PLATFORM minimum)
        {
            OSVERSIONINFO tVer = new OSVERSIONINFO();
            tVer.dwVersionInfoSize = Marshal.SizeOf(tVer);
            GetVersionEx(ref tVer);
            return ((VER_PLATFORM)tVer.dwPlatformId & minimum) == minimum;
        }
    }
}
