// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="NativeGdi32Api.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.Win32
{

    /// <summary>
    /// Delegate FONTENUMPROC
    /// </summary>
    /// <param name="f">The f.</param>
    /// <param name="lpntme">The lpntme.</param>
    /// <param name="FontType">Type of the font.</param>
    /// <param name="lParam">The l parameter.</param>
    /// <returns>System.Int32.</returns>
    public delegate int FONTENUMPROC(ENUMLOGFONTEX f, int lpntme, int FontType, int lParam);

    /// <summary>
    /// Class NativeGdi32Api.
    /// </summary>
    public static class NativeGdi32Api
    {
        /// <summary>
        /// Sets the di bits.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <param name="hBitmap">The h bitmap.</param>
        /// <param name="nStartScan">The n start scan.</param>
        /// <param name="nNumScans">The n number scans.</param>
        /// <param name="lpBits">The lp bits.</param>
        /// <param name="lpBI">The lp bi.</param>
        /// <param name="wUsage">The w usage.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("gdi32.dll")]
        public static extern int SetDIBits(IntPtr hdc, IntPtr hBitmap, int nStartScan, int nNumScans, IntPtr lpBits, IntPtr lpBI, int wUsage);

        /// <summary>
        /// Sets the di bits to device.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="dx">The dx.</param>
        /// <param name="dy">The dy.</param>
        /// <param name="SrcX">The source x.</param>
        /// <param name="SrcY">The source y.</param>
        /// <param name="Scan">The scan.</param>
        /// <param name="NumScans">The number scans.</param>
        /// <param name="Bits">The bits.</param>
        /// <param name="BitsInfo">The bits information.</param>
        /// <param name="wUsage">The w usage.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("gdi32.dll")]
        public static extern int SetDIBitsToDevice(IntPtr hdc, int x, int y, int dx, int dy, int SrcX, int SrcY, int Scan, int NumScans, IntPtr Bits, IntPtr BitsInfo, int wUsage);

        /// <summary>
        /// Creates the dib section.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <param name="pBitmapInfo">The p bitmap information.</param>
        /// <param name="un">The un.</param>
        /// <param name="lplpVoid">The LPLP void.</param>
        /// <param name="handle">The handle.</param>
        /// <param name="dw">The dw.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateDIBSection(IntPtr hdc, IntPtr pBitmapInfo, int un, IntPtr lplpVoid, IntPtr handle, int dw);

        /// <summary>
        /// Sets the pixel.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="crColor">Color of the cr.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public static extern int SetPixel(IntPtr hdc, int x, int y, int crColor);

        /// <summary>
        /// Gets the pixel.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public static extern int GetPixel(IntPtr hdc, int x, int y);


        /// <summary>
        /// Combines the RGN.
        /// </summary>
        /// <param name="dest">The dest.</param>
        /// <param name="src1">The SRC1.</param>
        /// <param name="src2">The SRC2.</param>
        /// <param name="flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("gdi32.dll", CharSet=CharSet.Auto)]
        public static extern int CombineRgn(IntPtr dest, IntPtr src1, IntPtr src2, int flags);

        /// <summary>
        /// Creates the brush indirect.
        /// </summary>
        /// <param name="brush">The brush.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll", CharSet=CharSet.Auto)]
        public static extern IntPtr CreateBrushIndirect(ref LOGBRUSH brush);


        /// <summary>
        /// Creates the rect RGN indirect.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll", CharSet=CharSet.Auto)]
        public static extern IntPtr CreateRectRgnIndirect(ref RECTAPI rect);


        /// <summary>
        /// Gets the clip box.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <param name="rectBox">The rect box.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("gdi32.dll", CharSet=CharSet.Auto)]
        public static extern int GetClipBox(IntPtr hDC, ref RECTAPI rectBox);

        /// <summary>
        /// Pats the BLT.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="flags">The flags.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("gdi32.dll", CharSet=CharSet.Auto)]
        public static extern bool PatBlt(IntPtr hDC, int x, int y, int width, int height, uint flags);

        /// <summary>
        /// Selects the clip RGN.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <param name="hRgn">The h RGN.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("gdi32.dll", CharSet=CharSet.Auto)]
        public static extern int SelectClipRgn(IntPtr hDC, IntPtr hRgn);



        /// <summary>
        /// Moves to ex.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="lpPoint">The lp point.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall,SetLastError=true)]
        public static extern IntPtr MoveToEx(IntPtr hDC, int x, int y, ref POINTAPI lpPoint);

        /// <summary>
        /// Lines to.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall,SetLastError=true)]
        public static extern IntPtr LineTo(IntPtr hDC, int x, int y);

        /// <summary>
        /// Creates the pen.
        /// </summary>
        /// <param name="nPenStyle">The n pen style.</param>
        /// <param name="nWidth">Width of the n.</param>
        /// <param name="crColor">Color of the cr.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall,SetLastError=true)]
        public static extern IntPtr CreatePen(int nPenStyle, int nWidth, int crColor);

        /// <summary>
        /// Sets the brush org ex.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="p">The p.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall,SetLastError=true)]
        public static extern int SetBrushOrgEx(IntPtr hDC, int x, int y, ref POINTAPI p);

        /// <summary>
        /// Creates the pattern brush.
        /// </summary>
        /// <param name="hBMP">The h BMP.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall,SetLastError=true)]
        public static extern IntPtr CreatePatternBrush(IntPtr hBMP);

        /// <summary>
        /// Gets the text face.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <param name="nCount">The n count.</param>
        /// <param name="lpFacename">The lp facename.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall,SetLastError=true)]
        public static extern int GetTextFace(IntPtr hDC, int nCount, string lpFacename);

        /// <summary>
        /// Gets the text metrics.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <param name="TextMetric">The text metric.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall,SetLastError=true)]
        public static extern int GetTextMetrics(IntPtr hDC, ref GDITextMetric TextMetric);

        /// <summary>
        /// Creates the font indirect.
        /// </summary>
        /// <param name="LogFont">The log font.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall,SetLastError=true)]
        public static extern IntPtr CreateFontIndirect([MarshalAs(UnmanagedType.LPStruct)]LogFont LogFont);

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
        /// <returns>System.Int32.</returns>
        [DllImport("gdi32.dll", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int BitBlt(IntPtr hDestDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        /// <summary>
        /// Creates the solid brush.
        /// </summary>
        /// <param name="crColor">Color of the cr.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall,SetLastError=true)]
        public static extern IntPtr CreateSolidBrush(int crColor);

        /// <summary>
        /// Rectangles the specified h dc.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="right">The right.</param>
        /// <param name="bottom">The bottom.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall,SetLastError=true)]
        public static extern int Rectangle(IntPtr hDC, int left, int top, int right, int bottom);

        /// <summary>
        /// Creates the hatch brush.
        /// </summary>
        /// <param name="Style">The style.</param>
        /// <param name="crColor">Color of the cr.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall,SetLastError=true)]
        public static extern IntPtr CreateHatchBrush(int Style, int crColor);


        /// <summary>
        /// Creates the compatible bitmap.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <param name="nWidth">Width of the n.</param>
        /// <param name="nHeight">Height of the n.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall,SetLastError=true)]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight);

        /// <summary>
        /// Creates the compatible dc.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall,SetLastError=true)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        /// <summary>
        /// Selects the object.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <param name="hObject">The h object.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall,SetLastError=true)]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

        /// <summary>
        /// Deletes the object.
        /// </summary>
        /// <param name="hObject">The h object.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall,SetLastError=true)]
        public static extern IntPtr DeleteObject(IntPtr hObject);

        /// <summary>
        /// Gets the color of the text.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("gdi32.dll", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetTextColor(IntPtr hDC);

        /// <summary>
        /// Sets the color of the text.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <param name="crColor">Color of the cr.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("gdi32.dll", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetTextColor(IntPtr hDC, int crColor);

        /// <summary>
        /// Gets the color of the bk.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("gdi32.dll", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetBkColor(IntPtr hDC);

        /// <summary>
        /// Gets the bk mode.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("gdi32.dll", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetBkMode(IntPtr hDC);

        /// <summary>
        /// Deletes the dc.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall,SetLastError=true)]
        public static extern IntPtr DeleteDC(IntPtr hDC);

        /// <summary>
        /// Sets the color of the bk.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <param name="crColor">Color of the cr.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("gdi32.dll", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetBkColor(IntPtr hDC, int crColor);

        /// <summary>
        /// Sets the bk mode.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <param name="Mode">The mode.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("gdi32.dll", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetBkMode(IntPtr hDC, int Mode);

        /// <summary>
        /// GDIs the flush.
        /// </summary>
        /// <returns>System.Int32.</returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall,SetLastError=true)]
        public static extern int GdiFlush();

        /// <summary>
        /// Enums the font families ex.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <param name="lf">The lf.</param>
        /// <param name="proc">The proc.</param>
        /// <param name="LParam">The l parameter.</param>
        /// <param name="DW">The dw.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("gdi32.dll", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int EnumFontFamiliesEx(IntPtr hDC, [MarshalAs(UnmanagedType.LPStruct)] LogFont lf, FONTENUMPROC proc, Int64 LParam, Int64 DW);

        /// <summary>
        /// Alphas the blend.
        /// </summary>
        /// <param name="hdcDest">The HDC dest.</param>
        /// <param name="nXOriginDest">The n x origin dest.</param>
        /// <param name="nYOriginDest">The n y origin dest.</param>
        /// <param name="nWidthDest">The n width dest.</param>
        /// <param name="nHeightDest">The n height dest.</param>
        /// <param name="hdcSrc">The HDC source.</param>
        /// <param name="nXOriginSrc">The n x origin source.</param>
        /// <param name="nYOriginSrc">The n y origin source.</param>
        /// <param name="nWidthSrc">The n width source.</param>
        /// <param name="nHeightSrc">The n height source.</param>
        /// <param name="blendFunction">The blend function.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("gdi32.dll", EntryPoint = "GdiAlphaBlend")]
        public static extern bool AlphaBlend(
          IntPtr hdcDest,                 // handle to destination DC
          int nXOriginDest,            // x-coord of upper-left corner
          int nYOriginDest,            // y-coord of upper-left corner
          int nWidthDest,              // destination width
          int nHeightDest,             // destination height
          IntPtr hdcSrc,                  // handle to source DC
          int nXOriginSrc,             // x-coord of upper-left corner
          int nYOriginSrc,             // y-coord of upper-left corner
          int nWidthSrc,               // source width
          int nHeightSrc,              // source height
          BLENDFUNCTION blendFunction  // alpha-blending function
        );
    }
}

