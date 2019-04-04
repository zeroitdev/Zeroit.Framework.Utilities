// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="Camera.cs" company="Zeroit Dev Technologies">
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

using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.Camera
{
    /// <summary>
    /// Class WebCam.
    /// </summary>
    public class WebCam
    {

        /// <summary>
        /// The h WND
        /// </summary>
        private int hWnd;
        /// <summary>
        /// The wm cap start
        /// </summary>
        const int WM_CAP_START = 1024;
        /// <summary>
        /// The ws child
        /// </summary>
        const int WS_CHILD = 1073741824;
        /// <summary>
        /// The ws visible
        /// </summary>
        const int WS_VISIBLE = 268435456;
        /// <summary>
        /// The wm cap driver connect
        /// </summary>
        const int WM_CAP_DRIVER_CONNECT = (WM_CAP_START + 10);
        /// <summary>
        /// The wm cap driver disconnect
        /// </summary>
        const int WM_CAP_DRIVER_DISCONNECT = (WM_CAP_START + 11);
        /// <summary>
        /// The wm cap edit copy
        /// </summary>
        const int WM_CAP_EDIT_COPY = (WM_CAP_START + 30);
        /// <summary>
        /// The wm cap sequence
        /// </summary>
        const int WM_CAP_SEQUENCE = (WM_CAP_START + 62);
        /// <summary>
        /// The wm cap file saveas
        /// </summary>
        const int WM_CAP_FILE_SAVEAS = (WM_CAP_START + 23);
        /// <summary>
        /// The wm cap set scale
        /// </summary>
        const int WM_CAP_SET_SCALE = (WM_CAP_START + 53);
        /// <summary>
        /// The wm cap set previewrate
        /// </summary>
        const int WM_CAP_SET_PREVIEWRATE = (WM_CAP_START + 52);
        /// <summary>
        /// The wm cap set preview
        /// </summary>
        const int WM_CAP_SET_PREVIEW = (WM_CAP_START + 50);
        /// <summary>
        /// The SWP nomove
        /// </summary>
        const int SWP_NOMOVE = 2;
        /// <summary>
        /// The SWP nosize
        /// </summary>
        const int SWP_NOSIZE = 1;
        /// <summary>
        /// The SWP nozorder
        /// </summary>
        const int SWP_NOZORDER = 4;
        /// <summary>
        /// The HWND bottom
        /// </summary>
        const int HWND_BOTTOM = 1;


        //---The capGetDriverDescription function retrieves the
        // version description of the capture driver---
        /// <summary>
        /// Caps the get driver description a.
        /// </summary>
        /// <param name="wDriverIndex">Index of the w driver.</param>
        /// <param name="lpszName">Name of the LPSZ.</param>
        /// <param name="cbName">Name of the cb.</param>
        /// <param name="lpszVer">The LPSZ ver.</param>
        /// <param name="cbVer">The cb ver.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [System.Runtime.InteropServices.DllImport("avicap32.dll")]
        static extern bool capGetDriverDescriptionA(
        short wDriverIndex, string lpszName,
        int cbName, string lpszVer, int cbVer);

        //---The capCreateCaptureWindow function creates a capture
        // window---
        /// <summary>
        /// Caps the create capture window a.
        /// </summary>
        /// <param name="lpszWindowName">Name of the LPSZ window.</param>
        /// <param name="dwStyle">The dw style.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="nWidth">Width of the n.</param>
        /// <param name="nHeight">Height of the n.</param>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="nID">The n identifier.</param>
        /// <returns>System.Int32.</returns>
        [System.Runtime.InteropServices.DllImport("avicap32.dll")]
        static extern int capCreateCaptureWindowA(
        string lpszWindowName, int dwStyle, int x, int y,
        int nWidth, short nHeight, int hWnd, int nID);

        //---This function sends the specified message to a window or
        // windows---
        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="Msg">The MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>System.Int32.</returns>
        [System.Runtime.InteropServices.DllImport(
            "user32", EntryPoint = "SendMessageA")]
        static extern int SendMessage(
        int hwnd, int Msg, int wParam,
        [MarshalAs(UnmanagedType.AsAny)] object lParam);

        //---Sets the position of the window relative to the screen
        // buffer---
        /// <summary>
        /// Sets the window position.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="hWndInsertAfter">The h WND insert after.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="cx">The cx.</param>
        /// <param name="cy">The cy.</param>
        /// <param name="wFlags">The w flags.</param>
        /// <returns>System.Int32.</returns>
        [System.Runtime.InteropServices.DllImport(
            "user32", EntryPoint = "SetWindowPos")]
        static extern int SetWindowPos(
        int hwnd, int hWndInsertAfter, int x, int y,
        int cx, int cy, int wFlags);

        //--This function destroys the specified window--
        /// <summary>
        /// Destroys the window.
        /// </summary>
        /// <param name="hndw">The HNDW.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [System.Runtime.InteropServices.DllImport("user32")]
        static extern bool DestroyWindow(int hndw);

        /// <summary>
        /// Previews the video.
        /// </summary>
        /// <param name="pbCtrl">The pb control.</param>
        public void PreviewVideo(PictureBox pbCtrl)
        {
            hWnd = capCreateCaptureWindowA("0", WS_VISIBLE | WS_CHILD, 0, 0, 0, 0, pbCtrl.Handle.ToInt32(), 0);
            if (SendMessage(hWnd, WM_CAP_DRIVER_CONNECT, 0, 0) != 0)
            {
                SendMessage(hWnd, WM_CAP_SET_SCALE, 1, 0);
                SendMessage(hWnd, WM_CAP_SET_PREVIEWRATE, 30, 0);
                SendMessage(hWnd, WM_CAP_SET_PREVIEW, 1, 0);
                SetWindowPos(hWnd, HWND_BOTTOM, 0, 0, pbCtrl.Width, pbCtrl.Height, SWP_NOMOVE | SWP_NOZORDER);
            }
            else
            {
                DestroyWindow(hWnd);
            }
        }

        /// <summary>
        /// Stops the recording.
        /// </summary>
        /// <param name="Path">The path.</param>
        /// <param name="Format">The format.</param>
        public void StopRecording(string Path, string Format)
        {
            Application.DoEvents();
            //---save the recording to file---
            SendMessage(hWnd, WM_CAP_FILE_SAVEAS, 0,
            Path + System.DateTime.Now.ToFileTime() + string.Format("."+"{0}",Format));
        }

        /// <summary>
        /// Starts the recording.
        /// </summary>
        public void StartRecording()
        {

           
            Application.DoEvents();
            //---start recording---
            SendMessage(hWnd, WM_CAP_SEQUENCE, 0, 0);

        }

        /// <summary>
        /// Takes the snap shot.
        /// </summary>
        /// <param name="Path">The path.</param>
        /// <param name="Format">The format.</param>
        public void TakeSnapShot(string Path, string Format)
        {

            IDataObject data;
            Image bmap;
            //---copy the image to the Clipboard---
            SendMessage(hWnd, WM_CAP_EDIT_COPY, 0, 0);
            //---retrieve the image from Clipboard and convert it
            // to the bitmap format---
            data = Clipboard.GetDataObject();

            if (data.GetDataPresent(typeof(System.Drawing.Bitmap)))
            {
                bmap =
                    ((Image)(data.GetData(typeof(
                        System.Drawing.Bitmap))));
                bmap.Save(Path + System.DateTime.Now.ToFileTime() +
                          string.Format("." + "{0}", Format));
            }


        }

        

    }
}
