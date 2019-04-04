// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-05-2018
// ***********************************************************************
// <copyright file="ScreenCapture.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Imaging;
using System.Windows.Forms;


namespace Zeroit.Framework.Utilities.ScreenOperation
{

    /// <summary>
    /// Provides functions to capture the entire screen, or a particular window, and save it to a file.
    /// </summary>
    public static class ScreenCapture
    {

        /// <summary>
        /// Creates an Image object containing a screen shot of the entire desktop
        /// </summary>
        /// <returns>Image.</returns>
        public static Image CaptureScreen()
        {
            return CaptureWindow(User32.GetDesktopWindow());
        }
        /// <summary>
        /// Creates an Image object containing a screen shot of a specific window
        /// </summary>
        /// <param name="handle">The handle to the window. (In windows forms, this is obtained by the Handle property)</param>
        /// <returns>Image.</returns>
        public static Image CaptureWindow(IntPtr handle)
        {
            // get te hDC of the target window
            IntPtr hdcSrc = User32.GetWindowDC(handle);
            // get the size
            User32.RECT windowRect = new User32.RECT();
            User32.GetWindowRect(handle, ref windowRect);
            int width = windowRect.right - windowRect.left;
            int height = windowRect.bottom - windowRect.top;
            // create a device context we can copy to
            IntPtr hdcDest = GDI32.CreateCompatibleDC(hdcSrc);
            // create a bitmap we can copy it to,
            // using GetDeviceCaps to get the width/height
            IntPtr hBitmap = GDI32.CreateCompatibleBitmap(hdcSrc, width, height);
            // select the bitmap object
            IntPtr hOld = GDI32.SelectObject(hdcDest, hBitmap);
            // bitblt over
            GDI32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, GDI32.SRCCOPY);
            // restore selection
            GDI32.SelectObject(hdcDest, hOld);
            // clean up 
            GDI32.DeleteDC(hdcDest);
            User32.ReleaseDC(handle, hdcSrc);
            // get a .NET image object for it
            Image img = Image.FromHbitmap(hBitmap);
            // free up the Bitmap object
            GDI32.DeleteObject(hBitmap);
            return img;
        }
        /// <summary>
        /// Captures a screen shot of a specific window, and saves it to a file
        /// </summary>
        /// <param name="handle">Set the handle</param>
        /// <param name="filename">Set file name</param>
        /// <param name="format">Set file format</param>
        public static void CaptureWindowToFile(IntPtr handle, string filename, ImageFormat format)
        {
            Image img = CaptureWindow(handle);
            img.Save(filename, format);
        }
        /// <summary>
        /// Captures a screen shot of the entire desktop, and saves it to a file
        /// </summary>
        /// <param name="filename">Set file name</param>
        /// <param name="format">Set file format</param>
        public static void CaptureScreenToFile(string filename, ImageFormat format)
        {
            Image img = CaptureScreen();
            img.Save(filename, format);
        }

        /// <summary>
        /// Helper class containing Gdi32 API functions
        /// </summary>
        private class GDI32
        {

            /// <summary>
            /// The srccopy
            /// </summary>
            public const int SRCCOPY = 0x00CC0020; // BitBlt dwRop parameter
            /// <summary>
            /// Bits the BLT.
            /// </summary>
            /// <param name="hObject">The h object.</param>
            /// <param name="nXDest">The n x dest.</param>
            /// <param name="nYDest">The n y dest.</param>
            /// <param name="nWidth">Width of the n.</param>
            /// <param name="nHeight">Height of the n.</param>
            /// <param name="hObjectSource">The h object source.</param>
            /// <param name="nXSrc">The n x source.</param>
            /// <param name="nYSrc">The n y source.</param>
            /// <param name="dwRop">The dw rop.</param>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            [DllImport("gdi32.dll")]
            public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest,
                int nWidth, int nHeight, IntPtr hObjectSource,
                int nXSrc, int nYSrc, int dwRop);
            /// <summary>
            /// Creates the compatible bitmap.
            /// </summary>
            /// <param name="hDC">The h dc.</param>
            /// <param name="nWidth">Width of the n.</param>
            /// <param name="nHeight">Height of the n.</param>
            /// <returns>IntPtr.</returns>
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth,
                int nHeight);
            /// <summary>
            /// Creates the compatible dc.
            /// </summary>
            /// <param name="hDC">The h dc.</param>
            /// <returns>IntPtr.</returns>
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
            /// <summary>
            /// Deletes the dc.
            /// </summary>
            /// <param name="hDC">The h dc.</param>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            [DllImport("gdi32.dll")]
            public static extern bool DeleteDC(IntPtr hDC);
            /// <summary>
            /// Deletes the object.
            /// </summary>
            /// <param name="hObject">The h object.</param>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            [DllImport("gdi32.dll")]
            public static extern bool DeleteObject(IntPtr hObject);
            /// <summary>
            /// Selects the object.
            /// </summary>
            /// <param name="hDC">The h dc.</param>
            /// <param name="hObject">The h object.</param>
            /// <returns>IntPtr.</returns>
            [DllImport("gdi32.dll")]
            public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        }

        /// <summary>
        /// Helper class containing User32 API functions
        /// </summary>
        private class User32
        {
            /// <summary>
            /// Struct RECT
            /// </summary>
            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                /// <summary>
                /// The left
                /// </summary>
                public int left;
                /// <summary>
                /// The top
                /// </summary>
                public int top;
                /// <summary>
                /// The right
                /// </summary>
                public int right;
                /// <summary>
                /// The bottom
                /// </summary>
                public int bottom;
            }
            /// <summary>
            /// Gets the desktop window.
            /// </summary>
            /// <returns>IntPtr.</returns>
            [DllImport("user32.dll")]
            public static extern IntPtr GetDesktopWindow();
            /// <summary>
            /// Gets the window dc.
            /// </summary>
            /// <param name="hWnd">The h WND.</param>
            /// <returns>IntPtr.</returns>
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowDC(IntPtr hWnd);
            /// <summary>
            /// Releases the dc.
            /// </summary>
            /// <param name="hWnd">The h WND.</param>
            /// <param name="hDC">The h dc.</param>
            /// <returns>IntPtr.</returns>
            [DllImport("user32.dll")]
            public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
            /// <summary>
            /// Gets the window rect.
            /// </summary>
            /// <param name="hWnd">The h WND.</param>
            /// <param name="rect">The rect.</param>
            /// <returns>IntPtr.</returns>
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);
        }


        /// <summary>
        /// Creates a screenshot of the active winform window.
        /// It uses the ScreenCapture class.
        /// // Use like :
        /// WindowScreenshot(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "window_screenshot.jpg", ImageFormat.Jpeg);
        /// </summary>
        /// <param name="filepath">Set file path</param>
        /// <param name="filename">Set file name</param>
        /// <param name="format">Set file format</param>
        /// <param name="control">The control.</param>
        public static void WindowScreenshot(String filepath, String filename, ImageFormat format, Control control)
        {
            //ScreenCapture sc = new ScreenCapture();

            string fullpath = filepath + "\\" + filename;

            
            //------Uncomment this section---------//
            CaptureWindowToFile(control.Handle, fullpath, format);
        }

        /// <summary>
        /// Take the screenshot of the active window using the CopyFromScreen method relative to the bounds of the form.
        /// Use it like :
        /// WindowScreenshotWithoutClass(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "window_screen_noclass.jpg", ImageFormat.Jpeg);
        /// </summary>
        /// <param name="filepath">Set file path</param>
        /// <param name="filename">Set file name</param>
        /// <param name="format">Set file format</param>
        /// <param name="control">The control.</param>
        public static void WindowScreenshotWithoutClass(String filepath, String filename, ImageFormat format, Control control)
        {
            //------Uncomment this section---------//
            Rectangle bounds = control.Bounds;

            using (System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(bounds.Width, bounds.Height))
            {
                using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                }

                string fullpath = filepath + "\\" + filename;

                bitmap.Save(fullpath, format);
            }
        }

        /// <summary>
        /// Takes a fullscreen screenshot of the monitor and saves the specified file in a directory with custom name.
        /// It expects the Format of the file.
        /// Implementation
        /// FullScreenshot(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "screenshot.jpg", ImageFormat.Jpeg);
        /// </summary>
        /// <param name="filepath">Set file path</param>
        /// <param name="filename">Set file name</param>
        /// <param name="format">Set file format</param>
        public static void FullScreenshot(String filepath, String filename, ImageFormat format)
        {
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            using (System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(bounds.Width, bounds.Height))
            {
                using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }

                string fullpath = filepath + "\\" + filename;

                bitmap.Save(fullpath, format);
            }
        }

        /// <summary>
        /// Creates a screenshot using the ScreenCapture class.
        /// Implementation
        /// FullScreenshotWithClass(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "screenshotfull_class.jpg", ImageFormat.Jpeg);
        /// </summary>
        /// <param name="filepath">Set file path</param>
        /// <param name="filename">Set file name</param>
        /// <param name="format">Set file format</param>
        public static void FullScreenshotWithClass(String filepath, String filename, ImageFormat format)
        {
            //ScreenCapture sc = new ScreenCapture();
            //Image img = sc.CaptureScreen();

            Image img = CaptureScreen();

            string fullpath = filepath + "\\" + filename;

            img.Save(fullpath, format);
        }
        

    }




}