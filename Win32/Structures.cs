// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="Structures.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.Win32
{
    /// <summary>
    /// Struct BITMAPINFOHEADER
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct BITMAPINFOHEADER //40 bytes
    {
        /// <summary>
        /// The bi size
        /// </summary>
        public int biSize;
        /// <summary>
        /// The bi width
        /// </summary>
        public int biWidth;
        /// <summary>
        /// The bi height
        /// </summary>
        public int biHeight;
        /// <summary>
        /// The bi planes
        /// </summary>
        public short biPlanes;
        /// <summary>
        /// The bi bit count
        /// </summary>
        public short biBitCount;
        /// <summary>
        /// The bi compression
        /// </summary>
        public int biCompression;
        /// <summary>
        /// The bi size image
        /// </summary>
        public int biSizeImage;
        /// <summary>
        /// The bi x pels per meter
        /// </summary>
        public int biXPelsPerMeter;
        /// <summary>
        /// The bi y pels per meter
        /// </summary>
        public int biYPelsPerMeter;
        /// <summary>
        /// The bi color used
        /// </summary>
        public int biClrUsed;
        /// <summary>
        /// The bi color important
        /// </summary>
        public int biClrImportant;
    }

    /// <summary>
    /// Struct RGBQUAD
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RGBQUAD
    {
        /// <summary>
        /// The RGB blue
        /// </summary>
        public byte rgbBlue;
        /// <summary>
        /// The RGB green
        /// </summary>
        public byte rgbGreen;
        /// <summary>
        /// The RGB red
        /// </summary>
        public byte rgbRed;
        /// <summary>
        /// The RGB reserved
        /// </summary>
        public byte rgbReserved;
    }

    /// <summary>
    /// Struct BITMAPINFO
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct BITMAPINFO
    {
        /// <summary>
        /// The bmi header
        /// </summary>
        public BITMAPINFOHEADER bmiHeader;
        /// <summary>
        /// The bmi colors
        /// </summary>
        public RGBQUAD bmiColors;

    }

    /// <summary>
    /// Struct LOGBRUSH
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LOGBRUSH
    {
        /// <summary>
        /// The lb style
        /// </summary>
        public uint lbStyle;
        /// <summary>
        /// The lb color
        /// </summary>
        public uint lbColor;
        /// <summary>
        /// The lb hatch
        /// </summary>
        public uint lbHatch;
    }

    /// <summary>
    /// Struct PAINTSTRUCT
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PAINTSTRUCT
    {
        /// <summary>
        /// The HDC
        /// </summary>
        public IntPtr hdc;
        /// <summary>
        /// The f erase
        /// </summary>
        public int fErase;
        /// <summary>
        /// The rc paint
        /// </summary>
        public Rectangle rcPaint;
        /// <summary>
        /// The f restore
        /// </summary>
        public int fRestore;
        /// <summary>
        /// The f inc update
        /// </summary>
        public int fIncUpdate;
        /// <summary>
        /// The reserved1
        /// </summary>
        public int Reserved1;
        /// <summary>
        /// The reserved2
        /// </summary>
        public int Reserved2;
        /// <summary>
        /// The reserved3
        /// </summary>
        public int Reserved3;
        /// <summary>
        /// The reserved4
        /// </summary>
        public int Reserved4;
        /// <summary>
        /// The reserved5
        /// </summary>
        public int Reserved5;
        /// <summary>
        /// The reserved6
        /// </summary>
        public int Reserved6;
        /// <summary>
        /// The reserved7
        /// </summary>
        public int Reserved7;
        /// <summary>
        /// The reserved8
        /// </summary>
        public int Reserved8;
    }

    /// <summary>
    /// Struct POINTAPI
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct POINTAPI
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="POINTAPI"/> struct.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public POINTAPI(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// The x
        /// </summary>
        public int X;
        /// <summary>
        /// The y
        /// </summary>
        public int Y;
    }

    /// <summary>
    /// Struct RECTAPI
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RECTAPI
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RECTAPI"/> struct.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="right">The right.</param>
        /// <param name="bottom">The bottom.</param>
        public RECTAPI(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        /// <summary>
        /// The left
        /// </summary>
        public int Left;
        /// <summary>
        /// The top
        /// </summary>
        public int Top;
        /// <summary>
        /// The right
        /// </summary>
        public int Right;
        /// <summary>
        /// The bottom
        /// </summary>
        public int Bottom;
        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width
        {
            get
            {
                return Right - Left;
            }
        }
        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height
        {
            get
            {
                return Bottom - Top;
            }
        }
    }

    /// <summary>
    /// Struct SIZE
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SIZE
    {
        /// <summary>
        /// The cx
        /// </summary>
        public int cx;
        /// <summary>
        /// The cy
        /// </summary>
        public int cy;
    }


    /// <summary>
    /// Struct TRACKMOUSEEVENTS
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TRACKMOUSEEVENTS
    {
        /// <summary>
        /// The cb size
        /// </summary>
        public uint cbSize;
        /// <summary>
        /// The dw flags
        /// </summary>
        public uint dwFlags;
        /// <summary>
        /// The h WND
        /// </summary>
        public IntPtr hWnd;
        /// <summary>
        /// The dw hover time
        /// </summary>
        public uint dwHoverTime;
    }

    /// <summary>
    /// Struct MSG
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MSG
    {
        /// <summary>
        /// The HWND
        /// </summary>
        public IntPtr hwnd;
        /// <summary>
        /// The message
        /// </summary>
        public int message;
        /// <summary>
        /// The w parameter
        /// </summary>
        public IntPtr wParam;
        /// <summary>
        /// The l parameter
        /// </summary>
        public IntPtr lParam;
        /// <summary>
        /// The time
        /// </summary>
        public int time;
        /// <summary>
        /// The pt x
        /// </summary>
        public int pt_x;
        /// <summary>
        /// The pt y
        /// </summary>
        public int pt_y;
    }

    /// <summary>
    /// Struct WINDOWPOS
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWPOS
    {
        /// <summary>
        /// The HWND
        /// </summary>
        public IntPtr hwnd;
        /// <summary>
        /// The HWND insert after
        /// </summary>
        public IntPtr hwndInsertAfter;
        /// <summary>
        /// The x
        /// </summary>
        public int x;
        /// <summary>
        /// The y
        /// </summary>
        public int y;
        /// <summary>
        /// The cx
        /// </summary>
        public int cx;
        /// <summary>
        /// The cy
        /// </summary>
        public int cy;
        /// <summary>
        /// The flags
        /// </summary>
        public uint flags;
    }

    /// <summary>
    /// Struct WindowInfo
    /// </summary>
    public struct WindowInfo
    {
        /// <summary>
        /// The size
        /// </summary>
        public int Size;
        /// <summary>
        /// The window rect
        /// </summary>
        public Rectangle WindowRect;
        /// <summary>
        /// The client rect
        /// </summary>
        public Rectangle ClientRect;
        /// <summary>
        /// The style
        /// </summary>
        public int Style;
        /// <summary>
        /// The ex style
        /// </summary>
        public int ExStyle;
        /// <summary>
        /// The window status
        /// </summary>
        public int WindowStatus;
        /// <summary>
        /// The x window borders
        /// </summary>
        public uint XWindowBorders;
        /// <summary>
        /// The y window borders
        /// </summary>
        public uint YWindowBorders;
        /// <summary>
        /// The atom window type
        /// </summary>
        public short AtomWindowType;
        /// <summary>
        /// The creator version
        /// </summary>
        public short CreatorVersion;
    }

    /// <summary>
    /// Struct WindowPlacement
    /// </summary>
    public struct WindowPlacement
    {
        /// <summary>
        /// The length
        /// </summary>
        public int Length;
        /// <summary>
        /// The flags
        /// </summary>
        public int Flags;
        /// <summary>
        /// The show command
        /// </summary>
        public int ShowCmd;
        /// <summary>
        /// The minimum position
        /// </summary>
        public Point MinPosition;
        /// <summary>
        /// The maximum position
        /// </summary>
        public Point MaxPosition;
        /// <summary>
        /// The normal position
        /// </summary>
        public Rectangle NormalPosition;
    }

    #region _NCCALCSIZE_PARAMS

    /// <summary>
    /// Struct _NCCALCSIZE_PARAMS
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct _NCCALCSIZE_PARAMS
    {
        /// <summary>
        /// The new rect
        /// </summary>
        public RECTAPI NewRect;
        /// <summary>
        /// The old rect
        /// </summary>
        public RECTAPI OldRect;
        /// <summary>
        /// The old client rect
        /// </summary>
        public RECTAPI OldClientRect;

        /// <summary>
        /// The lppos
        /// </summary>
        public WINDOWPOS lppos;
    }

    /// <summary>
    /// Struct MyStruct
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MyStruct
    {
        /// <summary>
        /// Some value
        /// </summary>
        public int SomeValue;
        /// <summary>
        /// The b1
        /// </summary>
        public byte b1;
        /// <summary>
        /// The b2
        /// </summary>
        public byte b2;
        /// <summary>
        /// The b3
        /// </summary>
        public byte b3;
        /// <summary>
        /// The b4
        /// </summary>
        public byte b4;
        /// <summary>
        /// The b5
        /// </summary>
        public byte b5;
        /// <summary>
        /// The b6
        /// </summary>
        public byte b6;
        /// <summary>
        /// The b7
        /// </summary>
        public byte b7;
        /// <summary>
        /// The b8
        /// </summary>
        public byte b8;
    }

    /// <summary>
    /// Struct BLENDFUNCTION
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BLENDFUNCTION
    {
        /// <summary>
        /// The blend op
        /// </summary>
        public byte BlendOp;
        /// <summary>
        /// The blend flags
        /// </summary>
        public byte BlendFlags;
        /// <summary>
        /// The source constant alpha
        /// </summary>
        public byte SourceConstantAlpha;
        /// <summary>
        /// The alpha format
        /// </summary>
        public byte AlphaFormat;
    }

    /// <summary>
    /// Struct GDITextMetric
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct GDITextMetric
    {
        /// <summary>
        /// The tm memory height
        /// </summary>
        public int tmMemoryHeight;
        /// <summary>
        /// The tm ascent
        /// </summary>
        public int tmAscent;
        /// <summary>
        /// The tm descent
        /// </summary>
        public int tmDescent;
        /// <summary>
        /// The tm internal leading
        /// </summary>
        public int tmInternalLeading;
        /// <summary>
        /// The tm external leading
        /// </summary>
        public int tmExternalLeading;
        /// <summary>
        /// The tm ave character width
        /// </summary>
        public int tmAveCharWidth;
        /// <summary>
        /// The tm maximum character width
        /// </summary>
        public int tmMaxCharWidth;
        /// <summary>
        /// The tm weight
        /// </summary>
        public int tmWeight;
        /// <summary>
        /// The tm overhang
        /// </summary>
        public int tmOverhang;
        /// <summary>
        /// The tm digitized aspect x
        /// </summary>
        public int tmDigitizedAspectX;
        /// <summary>
        /// The tm digitized aspect y
        /// </summary>
        public int tmDigitizedAspectY;
        /// <summary>
        /// The tm first character
        /// </summary>
        public byte tmFirstChar;
        /// <summary>
        /// The tm last character
        /// </summary>
        public byte tmLastChar;
        /// <summary>
        /// The tm default character
        /// </summary>
        public byte tmDefaultChar;
        /// <summary>
        /// The tm break character
        /// </summary>
        public byte tmBreakChar;
        /// <summary>
        /// The tm italic
        /// </summary>
        public byte tmItalic;
        /// <summary>
        /// The tm underlined
        /// </summary>
        public byte tmUnderlined;
        /// <summary>
        /// The tm struck out
        /// </summary>
        public byte tmStruckOut;
        /// <summary>
        /// The tm pitch and family
        /// </summary>
        public byte tmPitchAndFamily;
        /// <summary>
        /// The tm character set
        /// </summary>
        public byte tmCharSet;
    }

    /// <summary>
    /// Class LogFont.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class LogFont
    {
        /// <summary>
        /// The lf height
        /// </summary>
        public int lfHeight = 0;
        /// <summary>
        /// The lf width
        /// </summary>
        public int lfWidth = 0;
        /// <summary>
        /// The lf escapement
        /// </summary>
        public int lfEscapement = 0;
        /// <summary>
        /// The lf orientation
        /// </summary>
        public int lfOrientation = 0;
        /// <summary>
        /// The lf weight
        /// </summary>
        public int lfWeight = 0;
        /// <summary>
        /// The lf italic
        /// </summary>
        public byte lfItalic = 0;
        /// <summary>
        /// The lf underline
        /// </summary>
        public byte lfUnderline = 0;
        /// <summary>
        /// The lf strike out
        /// </summary>
        public byte lfStrikeOut = 0;
        /// <summary>
        /// The lf character set
        /// </summary>
        public byte lfCharSet = 0;
        /// <summary>
        /// The lf out precision
        /// </summary>
        public byte lfOutPrecision = 0;
        /// <summary>
        /// The lf clip precision
        /// </summary>
        public byte lfClipPrecision = 0;
        /// <summary>
        /// The lf quality
        /// </summary>
        public byte lfQuality = 0;
        /// <summary>
        /// The lf pitch and family
        /// </summary>
        public byte lfPitchAndFamily = 0;

        /// <summary>
        /// The lf face name
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string lfFaceName = "";
    }

    /// <summary>
    /// Class ENUMLOGFONTEX.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class ENUMLOGFONTEX
    {
        /// <summary>
        /// The elf log font
        /// </summary>
        public LogFont elfLogFont = null;
        /// <summary>
        /// The elf full name
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string elfFullName = "";
        /// <summary>
        /// The elf style
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] elfStyle = null;
        /// <summary>
        /// The elf script
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] elfScript = null;
    }

    /// <summary>
    /// Class COMPOSITIONFORM.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class COMPOSITIONFORM
    {
        /// <summary>
        /// The dw style
        /// </summary>
        public int dwStyle = 0;
        /// <summary>
        /// The pt current position
        /// </summary>
        public POINTAPI ptCurrentPos = new POINTAPI();
        /// <summary>
        /// The rc area
        /// </summary>
        public RECTAPI rcArea = new RECTAPI();
    }
    #endregion

    #region Shell Structures

    /// <summary>
    /// Struct SHFILEINFO
    /// </summary>
    public struct SHFILEINFO
    {
        /// <summary>
        /// The h icon
        /// </summary>
        public IntPtr hIcon;
        /// <summary>
        /// The i icon
        /// </summary>
        public int iIcon;
        /// <summary>
        /// The dw attributes
        /// </summary>
        public uint dwAttributes;
        /// <summary>
        /// The sz display name
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        /// <summary>
        /// The sz type name
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
    }

    #endregion
}
