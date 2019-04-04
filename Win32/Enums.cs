// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Enums.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace Zeroit.Framework.Utilities.Win32
{
    /// <summary>
    /// Enum AlphaFlags
    /// </summary>
    public enum AlphaFlags : byte
    {
        /// <summary>
        /// The ac source alpha
        /// </summary>
        AC_SRC_ALPHA = 1,
        /// <summary>
        /// The ac source over
        /// </summary>
        AC_SRC_OVER = 0
    }

    /// <summary>
    /// Enum Cursors
    /// </summary>
    public enum Cursors : uint
    {
        /// <summary>
        /// The idc appstarting
        /// </summary>
        IDC_APPSTARTING = 0x7f8a,
        /// <summary>
        /// The idc arrow
        /// </summary>
        IDC_ARROW = 0x7f00,
        /// <summary>
        /// The idc cross
        /// </summary>
        IDC_CROSS = 0x7f03,
        /// <summary>
        /// The idc hand
        /// </summary>
        IDC_HAND = 0x7f89,
        /// <summary>
        /// The idc help
        /// </summary>
        IDC_HELP = 0x7f8b,
        /// <summary>
        /// The idc ibeam
        /// </summary>
        IDC_IBEAM = 0x7f01,
        /// <summary>
        /// The idc icon
        /// </summary>
        IDC_ICON = 0x7f81,
        /// <summary>
        /// The idc no
        /// </summary>
        IDC_NO = 0x7f88,
        /// <summary>
        /// The idc size
        /// </summary>
        IDC_SIZE = 0x7f80,
        /// <summary>
        /// The idc sizeall
        /// </summary>
        IDC_SIZEALL = 0x7f86,
        /// <summary>
        /// The idc sizenesw
        /// </summary>
        IDC_SIZENESW = 0x7f83,
        /// <summary>
        /// The idc sizens
        /// </summary>
        IDC_SIZENS = 0x7f85,
        /// <summary>
        /// The idc sizenwse
        /// </summary>
        IDC_SIZENWSE = 0x7f82,
        /// <summary>
        /// The idc sizewe
        /// </summary>
        IDC_SIZEWE = 0x7f84,
        /// <summary>
        /// The idc uparrow
        /// </summary>
        IDC_UPARROW = 0x7f04,
        /// <summary>
        /// The idc wait
        /// </summary>
        IDC_WAIT = 0x7f02
    }

    /// <summary>
    /// Enum HitTest
    /// </summary>
    public enum HitTest
    {
        /// <summary>
        /// The htborder
        /// </summary>
        HTBORDER = 0x12,
        /// <summary>
        /// The htbottom
        /// </summary>
        HTBOTTOM = 15,
        /// <summary>
        /// The htbottomleft
        /// </summary>
        HTBOTTOMLEFT = 0x10,
        /// <summary>
        /// The htbottomright
        /// </summary>
        HTBOTTOMRIGHT = 0x11,
        /// <summary>
        /// The htcaption
        /// </summary>
        HTCAPTION = 2,
        /// <summary>
        /// The htclient
        /// </summary>
        HTCLIENT = 1,
        /// <summary>
        /// The htclose
        /// </summary>
        HTCLOSE = 20,
        /// <summary>
        /// The hterror
        /// </summary>
        HTERROR = -2,
        /// <summary>
        /// The htgrowbox
        /// </summary>
        HTGROWBOX = 4,
        /// <summary>
        /// The hthelp
        /// </summary>
        HTHELP = 0x15,
        /// <summary>
        /// The hthscroll
        /// </summary>
        HTHSCROLL = 6,
        /// <summary>
        /// The htleft
        /// </summary>
        HTLEFT = 10,
        /// <summary>
        /// The htmaxbutton
        /// </summary>
        HTMAXBUTTON = 9,
        /// <summary>
        /// The htmenu
        /// </summary>
        HTMENU = 5,
        /// <summary>
        /// The htminbutton
        /// </summary>
        HTMINBUTTON = 8,
        /// <summary>
        /// The htnowhere
        /// </summary>
        HTNOWHERE = 0,
        /// <summary>
        /// The htobject
        /// </summary>
        HTOBJECT = 0x13,
        /// <summary>
        /// The htreduce
        /// </summary>
        HTREDUCE = 8,
        /// <summary>
        /// The htright
        /// </summary>
        HTRIGHT = 11,
        /// <summary>
        /// The htsize
        /// </summary>
        HTSIZE = 4,
        /// <summary>
        /// The htsizefirst
        /// </summary>
        HTSIZEFIRST = 10,
        /// <summary>
        /// The htsizelast
        /// </summary>
        HTSIZELAST = 0x11,
        /// <summary>
        /// The htsysmenu
        /// </summary>
        HTSYSMENU = 3,
        /// <summary>
        /// The httop
        /// </summary>
        HTTOP = 12,
        /// <summary>
        /// The httopleft
        /// </summary>
        HTTOPLEFT = 13,
        /// <summary>
        /// The httopright
        /// </summary>
        HTTOPRIGHT = 14,
        /// <summary>
        /// The httransparent
        /// </summary>
        HTTRANSPARENT = -1,
        /// <summary>
        /// The htvscroll
        /// </summary>
        HTVSCROLL = 7,
        /// <summary>
        /// The htzoom
        /// </summary>
        HTZOOM = 9
    }

    #region Messages
    /// <summary>
    /// Enum WindowMessage
    /// </summary>
    public enum WindowMessage
    {
        /// <summary>
        /// The wm activate
        /// </summary>
        WM_ACTIVATE = 6,
        /// <summary>
        /// The wm activateapp
        /// </summary>
        WM_ACTIVATEAPP = 0x1c,
        /// <summary>
        /// The wm afxfirst
        /// </summary>
        WM_AFXFIRST = 0x360,
        /// <summary>
        /// The wm afxlast
        /// </summary>
        WM_AFXLAST = 0x37f,
        /// <summary>
        /// The wm application
        /// </summary>
        WM_APP = 0x8000,
        /// <summary>
        /// The wm askcbformatname
        /// </summary>
        WM_ASKCBFORMATNAME = 780,
        /// <summary>
        /// The wm canceljournal
        /// </summary>
        WM_CANCELJOURNAL = 0x4b,
        /// <summary>
        /// The wm cancelmode
        /// </summary>
        WM_CANCELMODE = 0x1f,
        /// <summary>
        /// The wm capturechanged
        /// </summary>
        WM_CAPTURECHANGED = 0x215,
        /// <summary>
        /// The wm changecbchain
        /// </summary>
        WM_CHANGECBCHAIN = 0x30d,
        /// <summary>
        /// The wm character
        /// </summary>
        WM_CHAR = 0x102,
        /// <summary>
        /// The wm chartoitem
        /// </summary>
        WM_CHARTOITEM = 0x2f,
        /// <summary>
        /// The wm childactivate
        /// </summary>
        WM_CHILDACTIVATE = 0x22,
        /// <summary>
        /// The wm clear
        /// </summary>
        WM_CLEAR = 0x303,
        /// <summary>
        /// The wm close
        /// </summary>
        WM_CLOSE = 0x10,
        /// <summary>
        /// The wm command
        /// </summary>
        WM_COMMAND = 0x111,
        /// <summary>
        /// The wm commnotify
        /// </summary>
        WM_COMMNOTIFY = 0x44,
        /// <summary>
        /// The wm compacting
        /// </summary>
        WM_COMPACTING = 0x41,
        /// <summary>
        /// The wm compareitem
        /// </summary>
        WM_COMPAREITEM = 0x39,
        /// <summary>
        /// The wm contextmenu
        /// </summary>
        WM_CONTEXTMENU = 0x7b,
        /// <summary>
        /// The wm copy
        /// </summary>
        WM_COPY = 0x301,
        /// <summary>
        /// The wm copydata
        /// </summary>
        WM_COPYDATA = 0x4a,
        /// <summary>
        /// The wm create
        /// </summary>
        WM_CREATE = 1,
        /// <summary>
        /// The wm ctlcolorbtn
        /// </summary>
        WM_CTLCOLORBTN = 0x135,
        /// <summary>
        /// The wm ctlcolordlg
        /// </summary>
        WM_CTLCOLORDLG = 310,
        /// <summary>
        /// The wm ctlcoloredit
        /// </summary>
        WM_CTLCOLOREDIT = 0x133,
        /// <summary>
        /// The wm ctlcolorlistbox
        /// </summary>
        WM_CTLCOLORLISTBOX = 0x134,
        /// <summary>
        /// The wm ctlcolormsgbox
        /// </summary>
        WM_CTLCOLORMSGBOX = 0x132,
        /// <summary>
        /// The wm ctlcolorscrollbar
        /// </summary>
        WM_CTLCOLORSCROLLBAR = 0x137,
        /// <summary>
        /// The wm ctlcolorstatic
        /// </summary>
        WM_CTLCOLORSTATIC = 0x138,
        /// <summary>
        /// The wm cut
        /// </summary>
        WM_CUT = 0x300,
        /// <summary>
        /// The wm deadchar
        /// </summary>
        WM_DEADCHAR = 0x103,
        /// <summary>
        /// The wm deleteitem
        /// </summary>
        WM_DELETEITEM = 0x2d,
        /// <summary>
        /// The wm destroy
        /// </summary>
        WM_DESTROY = 2,
        /// <summary>
        /// The wm destroyclipboard
        /// </summary>
        WM_DESTROYCLIPBOARD = 0x307,
        /// <summary>
        /// The wm devicechange
        /// </summary>
        WM_DEVICECHANGE = 0x219,
        /// <summary>
        /// The wm devmodechange
        /// </summary>
        WM_DEVMODECHANGE = 0x1b,
        /// <summary>
        /// The wm displaychange
        /// </summary>
        WM_DISPLAYCHANGE = 0x7e,
        /// <summary>
        /// The wm drawclipboard
        /// </summary>
        WM_DRAWCLIPBOARD = 0x308,
        /// <summary>
        /// The wm drawitem
        /// </summary>
        WM_DRAWITEM = 0x2b,
        /// <summary>
        /// The wm dropfiles
        /// </summary>
        WM_DROPFILES = 0x233,
        /// <summary>
        /// The wm enable
        /// </summary>
        WM_ENABLE = 10,
        /// <summary>
        /// The wm endsession
        /// </summary>
        WM_ENDSESSION = 0x16,
        /// <summary>
        /// The wm enteridle
        /// </summary>
        WM_ENTERIDLE = 0x121,
        /// <summary>
        /// The wm entermenuloop
        /// </summary>
        WM_ENTERMENULOOP = 0x211,
        /// <summary>
        /// The wm entersizemove
        /// </summary>
        WM_ENTERSIZEMOVE = 0x231,
        /// <summary>
        /// The wm erasebkgnd
        /// </summary>
        WM_ERASEBKGND = 20,
        /// <summary>
        /// The wm exitmenuloop
        /// </summary>
        WM_EXITMENULOOP = 530,
        /// <summary>
        /// The wm exitsizemove
        /// </summary>
        WM_EXITSIZEMOVE = 0x232,
        /// <summary>
        /// The wm fontchange
        /// </summary>
        WM_FONTCHANGE = 0x1d,
        /// <summary>
        /// The wm getdlgcode
        /// </summary>
        WM_GETDLGCODE = 0x87,
        /// <summary>
        /// The wm getfont
        /// </summary>
        WM_GETFONT = 0x31,
        /// <summary>
        /// The wm gethotkey
        /// </summary>
        WM_GETHOTKEY = 0x33,
        /// <summary>
        /// The wm geticon
        /// </summary>
        WM_GETICON = 0x7f,
        /// <summary>
        /// The wm getminmaxinfo
        /// </summary>
        WM_GETMINMAXINFO = 0x24,
        /// <summary>
        /// The wm getobject
        /// </summary>
        WM_GETOBJECT = 0x3d,
        /// <summary>
        /// The wm gettext
        /// </summary>
        WM_GETTEXT = 13,
        /// <summary>
        /// The wm gettextlength
        /// </summary>
        WM_GETTEXTLENGTH = 14,
        /// <summary>
        /// The wm handheldfirst
        /// </summary>
        WM_HANDHELDFIRST = 0x358,
        /// <summary>
        /// The wm handheldlast
        /// </summary>
        WM_HANDHELDLAST = 0x35f,
        /// <summary>
        /// The wm help
        /// </summary>
        WM_HELP = 0x53,
        /// <summary>
        /// The wm hotkey
        /// </summary>
        WM_HOTKEY = 0x312,
        /// <summary>
        /// The wm hscroll
        /// </summary>
        WM_HSCROLL = 0x114,
        /// <summary>
        /// The wm hscrollclipboard
        /// </summary>
        WM_HSCROLLCLIPBOARD = 0x30e,
        /// <summary>
        /// The wm iconerasebkgnd
        /// </summary>
        WM_ICONERASEBKGND = 0x27,
        /// <summary>
        /// The wm IME character
        /// </summary>
        WM_IME_CHAR = 0x286,
        /// <summary>
        /// The wm IME composition
        /// </summary>
        WM_IME_COMPOSITION = 0x10f,
        /// <summary>
        /// The wm IME compositionfull
        /// </summary>
        WM_IME_COMPOSITIONFULL = 0x284,
        /// <summary>
        /// The wm IME control
        /// </summary>
        WM_IME_CONTROL = 0x283,
        /// <summary>
        /// The wm IME endcomposition
        /// </summary>
        WM_IME_ENDCOMPOSITION = 270,
        /// <summary>
        /// The wm IME keydown
        /// </summary>
        WM_IME_KEYDOWN = 0x290,
        /// <summary>
        /// The wm IME keylast
        /// </summary>
        WM_IME_KEYLAST = 0x10f,
        /// <summary>
        /// The wm IME keyup
        /// </summary>
        WM_IME_KEYUP = 0x291,
        /// <summary>
        /// The wm IME notify
        /// </summary>
        WM_IME_NOTIFY = 0x282,
        /// <summary>
        /// The wm IME request
        /// </summary>
        WM_IME_REQUEST = 0x288,
        /// <summary>
        /// The wm IME select
        /// </summary>
        WM_IME_SELECT = 0x285,
        /// <summary>
        /// The wm IME setcontext
        /// </summary>
        WM_IME_SETCONTEXT = 0x281,
        /// <summary>
        /// The wm IME startcomposition
        /// </summary>
        WM_IME_STARTCOMPOSITION = 0x10d,
        /// <summary>
        /// The wm initdialog
        /// </summary>
        WM_INITDIALOG = 0x110,
        /// <summary>
        /// The wm initmenu
        /// </summary>
        WM_INITMENU = 0x116,
        /// <summary>
        /// The wm initmenupopup
        /// </summary>
        WM_INITMENUPOPUP = 0x117,
        /// <summary>
        /// The wm inputlangchange
        /// </summary>
        WM_INPUTLANGCHANGE = 0x51,
        /// <summary>
        /// The wm inputlangchangerequest
        /// </summary>
        WM_INPUTLANGCHANGEREQUEST = 80,
        /// <summary>
        /// The wm keydown
        /// </summary>
        WM_KEYDOWN = 0x100,
        /// <summary>
        /// The wm keylast
        /// </summary>
        WM_KEYLAST = 0x108,
        /// <summary>
        /// The wm keyup
        /// </summary>
        WM_KEYUP = 0x101,
        /// <summary>
        /// The wm killfocus
        /// </summary>
        WM_KILLFOCUS = 8,
        /// <summary>
        /// The wm lbuttondblclk
        /// </summary>
        WM_LBUTTONDBLCLK = 0x203,
        /// <summary>
        /// The wm lbuttondown
        /// </summary>
        WM_LBUTTONDOWN = 0x201,
        /// <summary>
        /// The wm lbuttonup
        /// </summary>
        WM_LBUTTONUP = 0x202,
        /// <summary>
        /// The wm mbuttondblclk
        /// </summary>
        WM_MBUTTONDBLCLK = 0x209,
        /// <summary>
        /// The wm mbuttondown
        /// </summary>
        WM_MBUTTONDOWN = 0x207,
        /// <summary>
        /// The wm mbuttonup
        /// </summary>
        WM_MBUTTONUP = 520,
        /// <summary>
        /// The wm mdiactivate
        /// </summary>
        WM_MDIACTIVATE = 0x222,
        /// <summary>
        /// The wm mdicascade
        /// </summary>
        WM_MDICASCADE = 0x227,
        /// <summary>
        /// The wm mdicreate
        /// </summary>
        WM_MDICREATE = 0x220,
        /// <summary>
        /// The wm mdidestroy
        /// </summary>
        WM_MDIDESTROY = 0x221,
        /// <summary>
        /// The wm mdigetactive
        /// </summary>
        WM_MDIGETACTIVE = 0x229,
        /// <summary>
        /// The wm mdiiconarrange
        /// </summary>
        WM_MDIICONARRANGE = 0x228,
        /// <summary>
        /// The wm mdimaximize
        /// </summary>
        WM_MDIMAXIMIZE = 0x225,
        /// <summary>
        /// The wm mdinext
        /// </summary>
        WM_MDINEXT = 0x224,
        /// <summary>
        /// The wm mdirefreshmenu
        /// </summary>
        WM_MDIREFRESHMENU = 0x234,
        /// <summary>
        /// The wm mdirestore
        /// </summary>
        WM_MDIRESTORE = 0x223,
        /// <summary>
        /// The wm mdisetmenu
        /// </summary>
        WM_MDISETMENU = 560,
        /// <summary>
        /// The wm mditile
        /// </summary>
        WM_MDITILE = 550,
        /// <summary>
        /// The wm measureitem
        /// </summary>
        WM_MEASUREITEM = 0x2c,
        /// <summary>
        /// The wm menuchar
        /// </summary>
        WM_MENUCHAR = 0x120,
        /// <summary>
        /// The wm menucommand
        /// </summary>
        WM_MENUCOMMAND = 0x126,
        /// <summary>
        /// The wm menudrag
        /// </summary>
        WM_MENUDRAG = 0x123,
        /// <summary>
        /// The wm menugetobject
        /// </summary>
        WM_MENUGETOBJECT = 0x124,
        /// <summary>
        /// The wm menurbuttonup
        /// </summary>
        WM_MENURBUTTONUP = 290,
        /// <summary>
        /// The wm menuselect
        /// </summary>
        WM_MENUSELECT = 0x11f,
        /// <summary>
        /// The wm mouseactivate
        /// </summary>
        WM_MOUSEACTIVATE = 0x21,
        /// <summary>
        /// The wm mousehover
        /// </summary>
        WM_MOUSEHOVER = 0x2a1,
        /// <summary>
        /// The wm mouseleave
        /// </summary>
        WM_MOUSELEAVE = 0x2a3,
        /// <summary>
        /// The wm mousemove
        /// </summary>
        WM_MOUSEMOVE = 0x200,
        /// <summary>
        /// The wm mousewheel
        /// </summary>
        WM_MOUSEWHEEL = 0x20a,
        /// <summary>
        /// The wm move
        /// </summary>
        WM_MOVE = 3,
        /// <summary>
        /// The wm moving
        /// </summary>
        WM_MOVING = 0x216,
        /// <summary>
        /// The wm ncactivate
        /// </summary>
        WM_NCACTIVATE = 0x86,
        /// <summary>
        /// The wm nccalcsize
        /// </summary>
        WM_NCCALCSIZE = 0x83,
        /// <summary>
        /// The wm nccreate
        /// </summary>
        WM_NCCREATE = 0x81,
        /// <summary>
        /// The wm ncdestroy
        /// </summary>
        WM_NCDESTROY = 130,
        /// <summary>
        /// The wm nchittest
        /// </summary>
        WM_NCHITTEST = 0x84,
        /// <summary>
        /// The wm nclbuttondblclk
        /// </summary>
        WM_NCLBUTTONDBLCLK = 0xa3,
        /// <summary>
        /// The wm nclbuttondown
        /// </summary>
        WM_NCLBUTTONDOWN = 0xa1,
        /// <summary>
        /// The wm nclbuttonup
        /// </summary>
        WM_NCLBUTTONUP = 0xa2,
        /// <summary>
        /// The wm ncmbuttondblclk
        /// </summary>
        WM_NCMBUTTONDBLCLK = 0xa9,
        /// <summary>
        /// The wm ncmbuttondown
        /// </summary>
        WM_NCMBUTTONDOWN = 0xa7,
        /// <summary>
        /// The wm ncmbuttonup
        /// </summary>
        WM_NCMBUTTONUP = 0xa8,
        /// <summary>
        /// The wm ncmousemove
        /// </summary>
        WM_NCMOUSEMOVE = 160,
        /// <summary>
        /// The wm ncpaint
        /// </summary>
        WM_NCPAINT = 0x85,
        /// <summary>
        /// The wm ncrbuttondblclk
        /// </summary>
        WM_NCRBUTTONDBLCLK = 0xa6,
        /// <summary>
        /// The wm ncrbuttondown
        /// </summary>
        WM_NCRBUTTONDOWN = 0xa4,
        /// <summary>
        /// The wm ncrbuttonup
        /// </summary>
        WM_NCRBUTTONUP = 0xa5,
        /// <summary>
        /// The wm ncxbuttondown
        /// </summary>
        WM_NCXBUTTONDOWN = 0xab,
        /// <summary>
        /// The wm ncxbuttonup
        /// </summary>
        WM_NCXBUTTONUP = 0xac,
        /// <summary>
        /// The wm nextdlgctl
        /// </summary>
        WM_NEXTDLGCTL = 40,
        /// <summary>
        /// The wm nextmenu
        /// </summary>
        WM_NEXTMENU = 0x213,
        /// <summary>
        /// The wm notify
        /// </summary>
        WM_NOTIFY = 0x4e,
        /// <summary>
        /// The wm notifyformat
        /// </summary>
        WM_NOTIFYFORMAT = 0x55,
        /// <summary>
        /// The wm null
        /// </summary>
        WM_NULL = 0,
        /// <summary>
        /// The wm paint
        /// </summary>
        WM_PAINT = 15,
        /// <summary>
        /// The wm paintclipboard
        /// </summary>
        WM_PAINTCLIPBOARD = 0x309,
        /// <summary>
        /// The wm painticon
        /// </summary>
        WM_PAINTICON = 0x26,
        /// <summary>
        /// The wm palettechanged
        /// </summary>
        WM_PALETTECHANGED = 0x311,
        /// <summary>
        /// The wm paletteischanging
        /// </summary>
        WM_PALETTEISCHANGING = 0x310,
        /// <summary>
        /// The wm parentnotify
        /// </summary>
        WM_PARENTNOTIFY = 0x210,
        /// <summary>
        /// The wm paste
        /// </summary>
        WM_PASTE = 770,
        /// <summary>
        /// The wm penwinfirst
        /// </summary>
        WM_PENWINFIRST = 0x380,
        /// <summary>
        /// The wm penwinlast
        /// </summary>
        WM_PENWINLAST = 0x38f,
        /// <summary>
        /// The wm power
        /// </summary>
        WM_POWER = 0x48,
        /// <summary>
        /// The wm print
        /// </summary>
        WM_PRINT = 0x317,
        /// <summary>
        /// The wm printclient
        /// </summary>
        WM_PRINTCLIENT = 0x318,
        /// <summary>
        /// The wm querydragicon
        /// </summary>
        WM_QUERYDRAGICON = 0x37,
        /// <summary>
        /// The wm queryendsession
        /// </summary>
        WM_QUERYENDSESSION = 0x11,
        /// <summary>
        /// The wm querynewpalette
        /// </summary>
        WM_QUERYNEWPALETTE = 0x30f,
        /// <summary>
        /// The wm queryopen
        /// </summary>
        WM_QUERYOPEN = 0x13,
        /// <summary>
        /// The wm queuesync
        /// </summary>
        WM_QUEUESYNC = 0x23,
        /// <summary>
        /// The wm quit
        /// </summary>
        WM_QUIT = 0x12,
        /// <summary>
        /// The wm rbuttondblclk
        /// </summary>
        WM_RBUTTONDBLCLK = 0x206,
        /// <summary>
        /// The wm rbuttondown
        /// </summary>
        WM_RBUTTONDOWN = 0x204,
        /// <summary>
        /// The wm rbuttonup
        /// </summary>
        WM_RBUTTONUP = 0x205,
        /// <summary>
        /// The wm renderallformats
        /// </summary>
        WM_RENDERALLFORMATS = 0x306,
        /// <summary>
        /// The wm renderformat
        /// </summary>
        WM_RENDERFORMAT = 0x305,
        /// <summary>
        /// The wm setcursor
        /// </summary>
        WM_SETCURSOR = 0x20,
        /// <summary>
        /// The wm setfocus
        /// </summary>
        WM_SETFOCUS = 7,
        /// <summary>
        /// The wm setfont
        /// </summary>
        WM_SETFONT = 0x30,
        /// <summary>
        /// The wm sethotkey
        /// </summary>
        WM_SETHOTKEY = 50,
        /// <summary>
        /// The wm seticon
        /// </summary>
        WM_SETICON = 0x80,
        /// <summary>
        /// The wm setredraw
        /// </summary>
        WM_SETREDRAW = 11,
        /// <summary>
        /// The wm settext
        /// </summary>
        WM_SETTEXT = 12,
        /// <summary>
        /// The wm settingchange
        /// </summary>
        WM_SETTINGCHANGE = 0x1a,
        /// <summary>
        /// The wm showwindow
        /// </summary>
        WM_SHOWWINDOW = 0x18,
        /// <summary>
        /// The wm size
        /// </summary>
        WM_SIZE = 5,
        /// <summary>
        /// The wm sizeclipboard
        /// </summary>
        WM_SIZECLIPBOARD = 0x30b,
        /// <summary>
        /// The wm sizing
        /// </summary>
        WM_SIZING = 0x214,
        /// <summary>
        /// The wm spoolerstatus
        /// </summary>
        WM_SPOOLERSTATUS = 0x2a,
        /// <summary>
        /// The wm stylechanged
        /// </summary>
        WM_STYLECHANGED = 0x7d,
        /// <summary>
        /// The wm stylechanging
        /// </summary>
        WM_STYLECHANGING = 0x7c,
        /// <summary>
        /// The wm syncpaint
        /// </summary>
        WM_SYNCPAINT = 0x88,
        /// <summary>
        /// The wm syschar
        /// </summary>
        WM_SYSCHAR = 0x106,
        /// <summary>
        /// The wm syscolorchange
        /// </summary>
        WM_SYSCOLORCHANGE = 0x15,
        /// <summary>
        /// The wm syscommand
        /// </summary>
        WM_SYSCOMMAND = 0x112,
        /// <summary>
        /// The wm sysdeadchar
        /// </summary>
        WM_SYSDEADCHAR = 0x107,
        /// <summary>
        /// The wm syskeydown
        /// </summary>
        WM_SYSKEYDOWN = 260,
        /// <summary>
        /// The wm syskeyup
        /// </summary>
        WM_SYSKEYUP = 0x105,
        /// <summary>
        /// The wm tcard
        /// </summary>
        WM_TCARD = 0x52,
        /// <summary>
        /// The wm timechange
        /// </summary>
        WM_TIMECHANGE = 30,
        /// <summary>
        /// The wm timer
        /// </summary>
        WM_TIMER = 0x113,
        /// <summary>
        /// The wm undo
        /// </summary>
        WM_UNDO = 0x304,
        /// <summary>
        /// The wm uninitmenupopup
        /// </summary>
        WM_UNINITMENUPOPUP = 0x125,
        /// <summary>
        /// The wm user
        /// </summary>
        WM_USER = 0x400,
        /// <summary>
        /// The wm userchanged
        /// </summary>
        WM_USERCHANGED = 0x54,
        /// <summary>
        /// The wm vkeytoitem
        /// </summary>
        WM_VKEYTOITEM = 0x2e,
        /// <summary>
        /// The wm vscroll
        /// </summary>
        WM_VSCROLL = 0x115,
        /// <summary>
        /// The wm vscrollclipboard
        /// </summary>
        WM_VSCROLLCLIPBOARD = 0x30a,
        /// <summary>
        /// The wm windowposchanged
        /// </summary>
        WM_WINDOWPOSCHANGED = 0x47,
        /// <summary>
        /// The wm windowposchanging
        /// </summary>
        WM_WINDOWPOSCHANGING = 70,
        /// <summary>
        /// The wm wininichange
        /// </summary>
        WM_WININICHANGE = 0x1a,
        /// <summary>
        /// The wm xbuttondblclk
        /// </summary>
        WM_XBUTTONDBLCLK = 0x20d,
        /// <summary>
        /// The wm xbuttondown
        /// </summary>
        WM_XBUTTONDOWN = 0x20b,
        /// <summary>
        /// The wm xbuttonup
        /// </summary>
        WM_XBUTTONUP = 0x20c
    }

    /// <summary>
    /// Enum GDIRop
    /// </summary>
    public enum GDIRop
    {
        /// <summary>
        /// The source copy
        /// </summary>
        SrcCopy = 13369376,
        /// <summary>
        /// The blackness
        /// </summary>
        Blackness = 0, //to be implemented
        /// <summary>
        /// The whiteness
        /// </summary>
        Whiteness = 0
    }

    /// <summary>
    /// Enum PeekMessageFlags
    /// </summary>
    public enum PeekMessageFlags
    {
        /// <summary>
        /// The pm noremove
        /// </summary>
        PM_NOREMOVE,
        /// <summary>
        /// The pm remove
        /// </summary>
        PM_REMOVE,
        /// <summary>
        /// The pm noyield
        /// </summary>
        PM_NOYIELD
    }

    /// <summary>
    /// Enum SetWindowPosFlags
    /// </summary>
    public enum SetWindowPosFlags : uint
    {
        /// <summary>
        /// The SWP asyncwindowpos
        /// </summary>
        SWP_ASYNCWINDOWPOS = 0x4000,
        /// <summary>
        /// The SWP defererase
        /// </summary>
        SWP_DEFERERASE = 0x2000,
        /// <summary>
        /// The SWP drawframe
        /// </summary>
        SWP_DRAWFRAME = 0x20,
        /// <summary>
        /// The SWP framechanged
        /// </summary>
        SWP_FRAMECHANGED = 0x20,
        /// <summary>
        /// The SWP hidewindow
        /// </summary>
        SWP_HIDEWINDOW = 0x80,
        /// <summary>
        /// The SWP noactivate
        /// </summary>
        SWP_NOACTIVATE = 0x10,
        /// <summary>
        /// The SWP nocopybits
        /// </summary>
        SWP_NOCOPYBITS = 0x100,
        /// <summary>
        /// The SWP nomove
        /// </summary>
        SWP_NOMOVE = 2,
        /// <summary>
        /// The SWP noownerzorder
        /// </summary>
        SWP_NOOWNERZORDER = 0x200,
        /// <summary>
        /// The SWP noredraw
        /// </summary>
        SWP_NOREDRAW = 8,
        /// <summary>
        /// The SWP noreposition
        /// </summary>
        SWP_NOREPOSITION = 0x200,
        /// <summary>
        /// The SWP nosendchanging
        /// </summary>
        SWP_NOSENDCHANGING = 0x400,
        /// <summary>
        /// The SWP nosize
        /// </summary>
        SWP_NOSIZE = 1,
        /// <summary>
        /// The SWP nozorder
        /// </summary>
        SWP_NOZORDER = 4,
        /// <summary>
        /// The SWP showwindow
        /// </summary>
        SWP_SHOWWINDOW = 0x40
    }

    /// <summary>
    /// Enum ShowWindowStyles
    /// </summary>
    public enum ShowWindowStyles : short
    {
        /// <summary>
        /// The sw forceminimize
        /// </summary>
        SW_FORCEMINIMIZE = 11,
        /// <summary>
        /// The sw hide
        /// </summary>
        SW_HIDE = 0,
        /// <summary>
        /// The sw maximum
        /// </summary>
        SW_MAX = 11,
        /// <summary>
        /// The sw maximize
        /// </summary>
        SW_MAXIMIZE = 3,
        /// <summary>
        /// The sw minimize
        /// </summary>
        SW_MINIMIZE = 6,
        /// <summary>
        /// The sw normal
        /// </summary>
        SW_NORMAL = 1,
        /// <summary>
        /// The sw restore
        /// </summary>
        SW_RESTORE = 9,
        /// <summary>
        /// The sw show
        /// </summary>
        SW_SHOW = 5,
        /// <summary>
        /// The sw showdefault
        /// </summary>
        SW_SHOWDEFAULT = 10,
        /// <summary>
        /// The sw showmaximized
        /// </summary>
        SW_SHOWMAXIMIZED = 3,
        /// <summary>
        /// The sw showminimized
        /// </summary>
        SW_SHOWMINIMIZED = 2,
        /// <summary>
        /// The sw showminnoactive
        /// </summary>
        SW_SHOWMINNOACTIVE = 7,
        /// <summary>
        /// The sw showna
        /// </summary>
        SW_SHOWNA = 8,
        /// <summary>
        /// The sw shownoactivate
        /// </summary>
        SW_SHOWNOACTIVATE = 4,
        /// <summary>
        /// The sw shownormal
        /// </summary>
        SW_SHOWNORMAL = 1
    }

    /// <summary>
    /// Enum SetWindowPosZ
    /// </summary>
    public enum SetWindowPosZ
    {
        /// <summary>
        /// The HWND bottom
        /// </summary>
        HWND_BOTTOM = 1,
        /// <summary>
        /// The HWND notopmost
        /// </summary>
        HWND_NOTOPMOST = -2,
        /// <summary>
        /// The HWND top
        /// </summary>
        HWND_TOP = 0,
        /// <summary>
        /// The HWND topmost
        /// </summary>
        HWND_TOPMOST = -1
    }

    /// <summary>
    /// Enum UpdateLayeredWindowsFlags
    /// </summary>
    public enum UpdateLayeredWindowsFlags
    {
        /// <summary>
        /// The ulw alpha
        /// </summary>
        ULW_ALPHA = 2,
        /// <summary>
        /// The ulw colorkey
        /// </summary>
        ULW_COLORKEY = 1,
        /// <summary>
        /// The ulw opaque
        /// </summary>
        ULW_OPAQUE = 4
    }

    /// <summary>
    /// Enum VirtualKeys
    /// </summary>
    public enum VirtualKeys
    {
        /// <summary>
        /// The vk 0
        /// </summary>
        VK_0 = 0x30,
        /// <summary>
        /// The vk 1
        /// </summary>
        VK_1 = 0x31,
        /// <summary>
        /// The vk 2
        /// </summary>
        VK_2 = 50,
        /// <summary>
        /// The vk 3
        /// </summary>
        VK_3 = 0x33,
        /// <summary>
        /// The vk 4
        /// </summary>
        VK_4 = 0x34,
        /// <summary>
        /// The vk 5
        /// </summary>
        VK_5 = 0x35,
        /// <summary>
        /// The vk 6
        /// </summary>
        VK_6 = 0x36,
        /// <summary>
        /// The vk 7
        /// </summary>
        VK_7 = 0x37,
        /// <summary>
        /// The vk 8
        /// </summary>
        VK_8 = 0x38,
        /// <summary>
        /// The vk 9
        /// </summary>
        VK_9 = 0x39,
        /// <summary>
        /// The vk a
        /// </summary>
        VK_A = 0x41,
        /// <summary>
        /// The vk add
        /// </summary>
        VK_ADD = 0x6b,
        /// <summary>
        /// The vk apps
        /// </summary>
        VK_APPS = 0x5d,
        /// <summary>
        /// The vk attn
        /// </summary>
        VK_ATTN = 0xf6,
        /// <summary>
        /// The vk b
        /// </summary>
        VK_B = 0x42,
        /// <summary>
        /// The vk back
        /// </summary>
        VK_BACK = 8,
        /// <summary>
        /// The vk c
        /// </summary>
        VK_C = 0x43,
        /// <summary>
        /// The vk cancel
        /// </summary>
        VK_CANCEL = 3,
        /// <summary>
        /// The vk capital
        /// </summary>
        VK_CAPITAL = 20,
        /// <summary>
        /// The vk clear
        /// </summary>
        VK_CLEAR = 12,
        /// <summary>
        /// The vk control
        /// </summary>
        VK_CONTROL = 0x11,
        /// <summary>
        /// The vk crsel
        /// </summary>
        VK_CRSEL = 0xf7,
        /// <summary>
        /// The vk d
        /// </summary>
        VK_D = 0x44,
        /// <summary>
        /// The vk decimal
        /// </summary>
        VK_DECIMAL = 110,
        /// <summary>
        /// The vk divide
        /// </summary>
        VK_DIVIDE = 0x6f,
        /// <summary>
        /// The vk down
        /// </summary>
        VK_DOWN = 40,
        /// <summary>
        /// The vk e
        /// </summary>
        VK_E = 0x45,
        /// <summary>
        /// The vk end
        /// </summary>
        VK_END = 0x23,
        /// <summary>
        /// The vk ereof
        /// </summary>
        VK_EREOF = 0xf9,
        /// <summary>
        /// The vk escape
        /// </summary>
        VK_ESCAPE = 0x1b,
        /// <summary>
        /// The vk execute
        /// </summary>
        VK_EXECUTE = 0x2b,
        /// <summary>
        /// The vk exsel
        /// </summary>
        VK_EXSEL = 0xf8,
        /// <summary>
        /// The vk f
        /// </summary>
        VK_F = 70,
        /// <summary>
        /// The vk g
        /// </summary>
        VK_G = 0x47,
        /// <summary>
        /// The vk h
        /// </summary>
        VK_H = 0x48,
        /// <summary>
        /// The vk help
        /// </summary>
        VK_HELP = 0x2f,
        /// <summary>
        /// The vk home
        /// </summary>
        VK_HOME = 0x24,
        /// <summary>
        /// The vk i
        /// </summary>
        VK_I = 0x49,
        /// <summary>
        /// The vk j
        /// </summary>
        VK_J = 0x4a,
        /// <summary>
        /// The vk k
        /// </summary>
        VK_K = 0x4b,
        /// <summary>
        /// The vk l
        /// </summary>
        VK_L = 0x4c,
        /// <summary>
        /// The vk lbutton
        /// </summary>
        VK_LBUTTON = 1,
        /// <summary>
        /// The vk lcontrol
        /// </summary>
        VK_LCONTROL = 0xa2,
        /// <summary>
        /// The vk left
        /// </summary>
        VK_LEFT = 0x25,
        /// <summary>
        /// The vk lmenu
        /// </summary>
        VK_LMENU = 0xa4,
        /// <summary>
        /// The vk lshift
        /// </summary>
        VK_LSHIFT = 160,
        /// <summary>
        /// The vk lwin
        /// </summary>
        VK_LWIN = 0x5b,
        /// <summary>
        /// The vk m
        /// </summary>
        VK_M = 0x4d,
        /// <summary>
        /// The vk menu
        /// </summary>
        VK_MENU = 0x12,
        /// <summary>
        /// The vk multiply
        /// </summary>
        VK_MULTIPLY = 0x6a,
        /// <summary>
        /// The vk n
        /// </summary>
        VK_N = 0x4e,
        /// <summary>
        /// The vk next
        /// </summary>
        VK_NEXT = 0x22,
        /// <summary>
        /// The vk noname
        /// </summary>
        VK_NONAME = 0xfc,
        /// <summary>
        /// The vk numpa d0
        /// </summary>
        VK_NUMPAD0 = 0x60,
        /// <summary>
        /// The vk numpa d1
        /// </summary>
        VK_NUMPAD1 = 0x61,
        /// <summary>
        /// The vk numpa d2
        /// </summary>
        VK_NUMPAD2 = 0x62,
        /// <summary>
        /// The vk numpa d3
        /// </summary>
        VK_NUMPAD3 = 0x63,
        /// <summary>
        /// The vk numpa d4
        /// </summary>
        VK_NUMPAD4 = 100,
        /// <summary>
        /// The vk numpa d5
        /// </summary>
        VK_NUMPAD5 = 0x65,
        /// <summary>
        /// The vk numpa d6
        /// </summary>
        VK_NUMPAD6 = 0x66,
        /// <summary>
        /// The vk numpa d7
        /// </summary>
        VK_NUMPAD7 = 0x67,
        /// <summary>
        /// The vk numpa d8
        /// </summary>
        VK_NUMPAD8 = 0x68,
        /// <summary>
        /// The vk numpa d9
        /// </summary>
        VK_NUMPAD9 = 0x69,
        /// <summary>
        /// The vk o
        /// </summary>
        VK_O = 0x4f,
        /// <summary>
        /// The vk oem clear
        /// </summary>
        VK_OEM_CLEAR = 0xfe,
        /// <summary>
        /// The vk p
        /// </summary>
        VK_P = 80,
        /// <summary>
        /// The vk p a1
        /// </summary>
        VK_PA1 = 0xfd,
        /// <summary>
        /// The vk play
        /// </summary>
        VK_PLAY = 250,
        /// <summary>
        /// The vk prior
        /// </summary>
        VK_PRIOR = 0x21,
        /// <summary>
        /// The vk q
        /// </summary>
        VK_Q = 0x51,
        /// <summary>
        /// The vk r
        /// </summary>
        VK_R = 0x52,
        /// <summary>
        /// The vk rcontrol
        /// </summary>
        VK_RCONTROL = 0xa3,
        /// <summary>
        /// The vk return
        /// </summary>
        VK_RETURN = 13,
        /// <summary>
        /// The vk right
        /// </summary>
        VK_RIGHT = 0x27,
        /// <summary>
        /// The vk rmenu
        /// </summary>
        VK_RMENU = 0xa5,
        /// <summary>
        /// The vk rshift
        /// </summary>
        VK_RSHIFT = 0xa1,
        /// <summary>
        /// The vk rwin
        /// </summary>
        VK_RWIN = 0x5c,
        /// <summary>
        /// The vk s
        /// </summary>
        VK_S = 0x53,
        /// <summary>
        /// The vk select
        /// </summary>
        VK_SELECT = 0x29,
        /// <summary>
        /// The vk separator
        /// </summary>
        VK_SEPARATOR = 0x6c,
        /// <summary>
        /// The vk shift
        /// </summary>
        VK_SHIFT = 0x10,
        /// <summary>
        /// The vk snapshot
        /// </summary>
        VK_SNAPSHOT = 0x2c,
        /// <summary>
        /// The vk space
        /// </summary>
        VK_SPACE = 0x20,
        /// <summary>
        /// The vk subtract
        /// </summary>
        VK_SUBTRACT = 0x6d,
        /// <summary>
        /// The vk t
        /// </summary>
        VK_T = 0x54,
        /// <summary>
        /// The vk tab
        /// </summary>
        VK_TAB = 9,
        /// <summary>
        /// The vk u
        /// </summary>
        VK_U = 0x55,
        /// <summary>
        /// The vk up
        /// </summary>
        VK_UP = 0x26,
        /// <summary>
        /// The vk v
        /// </summary>
        VK_V = 0x56,
        /// <summary>
        /// The vk w
        /// </summary>
        VK_W = 0x57,
        /// <summary>
        /// The vk x
        /// </summary>
        VK_X = 0x58,
        /// <summary>
        /// The vk y
        /// </summary>
        VK_Y = 0x59,
        /// <summary>
        /// The vk z
        /// </summary>
        VK_Z = 90,
        /// <summary>
        /// The vk zoom
        /// </summary>
        VK_ZOOM = 0xfb
    }

    /// <summary>
    /// Enum WindowExStyles
    /// </summary>
    public enum WindowExStyles
    {
        /// <summary>
        /// The ws ex acceptfiles
        /// </summary>
        WS_EX_ACCEPTFILES = 0x10,
        /// <summary>
        /// The ws ex appwindow
        /// </summary>
        WS_EX_APPWINDOW = 0x40000,
        /// <summary>
        /// The ws ex clientedge
        /// </summary>
        WS_EX_CLIENTEDGE = 0x200,
        /// <summary>
        /// The ws ex contexthelp
        /// </summary>
        WS_EX_CONTEXTHELP = 0x400,
        /// <summary>
        /// The ws ex controlparent
        /// </summary>
        WS_EX_CONTROLPARENT = 0x10000,
        /// <summary>
        /// The ws ex dlgmodalframe
        /// </summary>
        WS_EX_DLGMODALFRAME = 1,
        /// <summary>
        /// The ws ex layered
        /// </summary>
        WS_EX_LAYERED = 0x80000,
        /// <summary>
        /// The ws ex left
        /// </summary>
        WS_EX_LEFT = 0,
        /// <summary>
        /// The ws ex leftscrollbar
        /// </summary>
        WS_EX_LEFTSCROLLBAR = 0x4000,
        /// <summary>
        /// The ws ex ltrreading
        /// </summary>
        WS_EX_LTRREADING = 0,
        /// <summary>
        /// The ws ex mdichild
        /// </summary>
        WS_EX_MDICHILD = 0x40,
        /// <summary>
        /// The ws ex noparentnotify
        /// </summary>
        WS_EX_NOPARENTNOTIFY = 4,
        /// <summary>
        /// The ws ex overlappedwindow
        /// </summary>
        WS_EX_OVERLAPPEDWINDOW = 0x300,
        /// <summary>
        /// The ws ex palettewindow
        /// </summary>
        WS_EX_PALETTEWINDOW = 0x188,
        /// <summary>
        /// The ws ex right
        /// </summary>
        WS_EX_RIGHT = 0x1000,
        /// <summary>
        /// The ws ex rightscrollbar
        /// </summary>
        WS_EX_RIGHTSCROLLBAR = 0,
        /// <summary>
        /// The ws ex rtlreading
        /// </summary>
        WS_EX_RTLREADING = 0x2000,
        /// <summary>
        /// The ws ex staticedge
        /// </summary>
        WS_EX_STATICEDGE = 0x20000,
        /// <summary>
        /// The ws ex toolwindow
        /// </summary>
        WS_EX_TOOLWINDOW = 0x80,
        /// <summary>
        /// The ws ex topmost
        /// </summary>
        WS_EX_TOPMOST = 8,
        /// <summary>
        /// The ws ex transparent
        /// </summary>
        WS_EX_TRANSPARENT = 0x20,
        /// <summary>
        /// The ws ex windowedge
        /// </summary>
        WS_EX_WINDOWEDGE = 0x100
    }

    /// <summary>
    /// Enum WindowStyles
    /// </summary>
    public enum WindowStyles : uint
    {
        /// <summary>
        /// The ws border
        /// </summary>
        WS_BORDER = 0x800000,
        /// <summary>
        /// The ws caption
        /// </summary>
        WS_CAPTION = 0xc00000,
        /// <summary>
        /// The ws child
        /// </summary>
        WS_CHILD = 0x40000000,
        /// <summary>
        /// The ws childwindow
        /// </summary>
        WS_CHILDWINDOW = 0x40000000,
        /// <summary>
        /// The ws clipchildren
        /// </summary>
        WS_CLIPCHILDREN = 0x2000000,
        /// <summary>
        /// The ws clipsiblings
        /// </summary>
        WS_CLIPSIBLINGS = 0x4000000,
        /// <summary>
        /// The ws disabled
        /// </summary>
        WS_DISABLED = 0x8000000,
        /// <summary>
        /// The ws dlgframe
        /// </summary>
        WS_DLGFRAME = 0x400000,
        /// <summary>
        /// The ws group
        /// </summary>
        WS_GROUP = 0x20000,
        /// <summary>
        /// The ws hscroll
        /// </summary>
        WS_HSCROLL = 0x100000,
        /// <summary>
        /// The ws iconic
        /// </summary>
        WS_ICONIC = 0x20000000,
        /// <summary>
        /// The ws maximize
        /// </summary>
        WS_MAXIMIZE = 0x1000000,
        /// <summary>
        /// The ws maximizebox
        /// </summary>
        WS_MAXIMIZEBOX = 0x10000,
        /// <summary>
        /// The ws minimize
        /// </summary>
        WS_MINIMIZE = 0x20000000,
        /// <summary>
        /// The ws minimizebox
        /// </summary>
        WS_MINIMIZEBOX = 0x20000,
        /// <summary>
        /// The ws overlapped
        /// </summary>
        WS_OVERLAPPED = 0,
        /// <summary>
        /// The ws overlappedwindow
        /// </summary>
        WS_OVERLAPPEDWINDOW = 0xcf0000,
        /// <summary>
        /// The ws popup
        /// </summary>
        WS_POPUP = 0x80000000,
        /// <summary>
        /// The ws popupwindow
        /// </summary>
        WS_POPUPWINDOW = 0x80880000,
        /// <summary>
        /// The ws sizebox
        /// </summary>
        WS_SIZEBOX = 0x40000,
        /// <summary>
        /// The ws sysmenu
        /// </summary>
        WS_SYSMENU = 0x80000,
        /// <summary>
        /// The ws tabstop
        /// </summary>
        WS_TABSTOP = 0x10000,
        /// <summary>
        /// The ws thickframe
        /// </summary>
        WS_THICKFRAME = 0x40000,
        /// <summary>
        /// The ws tiled
        /// </summary>
        WS_TILED = 0,
        /// <summary>
        /// The ws tiledwindow
        /// </summary>
        WS_TILEDWINDOW = 0xcf0000,
        /// <summary>
        /// The ws visible
        /// </summary>
        WS_VISIBLE = 0x10000000,
        /// <summary>
        /// The ws vscroll
        /// </summary>
        WS_VSCROLL = 0x200000
    }

    #endregion

    /// <summary>
    /// Enum DrawTextFlags
    /// </summary>
    public enum DrawTextFlags
    {
        /// <summary>
        /// The dt top
        /// </summary>
        DT_TOP = 0x00000000,
        /// <summary>
        /// The dt left
        /// </summary>
        DT_LEFT = 0x00000000,
        /// <summary>
        /// The dt center
        /// </summary>
        DT_CENTER = 0x00000001,
        /// <summary>
        /// The dt right
        /// </summary>
        DT_RIGHT = 0x00000002,
        /// <summary>
        /// The dt vcenter
        /// </summary>
        DT_VCENTER = 0x00000004,
        /// <summary>
        /// The dt bottom
        /// </summary>
        DT_BOTTOM = 0x00000008,
        /// <summary>
        /// The dt wordbreak
        /// </summary>
        DT_WORDBREAK = 0x00000010,
        /// <summary>
        /// The dt singleline
        /// </summary>
        DT_SINGLELINE = 0x00000020,
        /// <summary>
        /// The dt expandtabs
        /// </summary>
        DT_EXPANDTABS = 0x00000040,
        /// <summary>
        /// The dt tabstop
        /// </summary>
        DT_TABSTOP = 0x00000080,
        /// <summary>
        /// The dt noclip
        /// </summary>
        DT_NOCLIP = 0x00000100,
        /// <summary>
        /// The dt externalleading
        /// </summary>
        DT_EXTERNALLEADING = 0x00000200,
        /// <summary>
        /// The dt calcrect
        /// </summary>
        DT_CALCRECT = 0x00000400,
        /// <summary>
        /// The dt noprefix
        /// </summary>
        DT_NOPREFIX = 0x00000800,
        /// <summary>
        /// The dt internal
        /// </summary>
        DT_INTERNAL = 0x00001000,
        /// <summary>
        /// The dt editcontrol
        /// </summary>
        DT_EDITCONTROL = 0x00002000,
        /// <summary>
        /// The dt path ellipsis
        /// </summary>
        DT_PATH_ELLIPSIS = 0x00004000,
        /// <summary>
        /// The dt end ellipsis
        /// </summary>
        DT_END_ELLIPSIS = 0x00008000,
        /// <summary>
        /// The dt modifystring
        /// </summary>
        DT_MODIFYSTRING = 0x00010000,
        /// <summary>
        /// The dt rtlreading
        /// </summary>
        DT_RTLREADING = 0x00020000,
        /// <summary>
        /// The dt word ellipsis
        /// </summary>
        DT_WORD_ELLIPSIS = 0x00040000,
        /// <summary>
        /// The dt nofullwidthcharbreak
        /// </summary>
        DT_NOFULLWIDTHCHARBREAK = 0x00080000,
        /// <summary>
        /// The dt hideprefix
        /// </summary>
        DT_HIDEPREFIX = 0x00100000,
        /// <summary>
        /// The dt prefixonly
        /// </summary>
        DT_PREFIXONLY = 0x00200000,
    }

    /// <summary>
    /// Enum TextBoxNotifications
    /// </summary>
    public enum TextBoxNotifications
    {
        /// <summary>
        /// The en setfocus
        /// </summary>
        EN_SETFOCUS = 0x0100,
        /// <summary>
        /// The en killfocus
        /// </summary>
        EN_KILLFOCUS = 0x0200,
        /// <summary>
        /// The en change
        /// </summary>
        EN_CHANGE = 0x0300,
        /// <summary>
        /// The en update
        /// </summary>
        EN_UPDATE = 0x0400,
        /// <summary>
        /// The en errspace
        /// </summary>
        EN_ERRSPACE = 0x0500,
        /// <summary>
        /// The en maxtext
        /// </summary>
        EN_MAXTEXT = 0x0501,
        /// <summary>
        /// The en hscroll
        /// </summary>
        EN_HSCROLL = 0x0601,
        /// <summary>
        /// The en vscroll
        /// </summary>
        EN_VSCROLL = 0x0602,
    }

    /// <summary>
    /// Enum TextBoxMessages
    /// </summary>
    public enum TextBoxMessages
    {
        /// <summary>
        /// The em getsel
        /// </summary>
        EM_GETSEL = 0x00B0,
        /// <summary>
        /// The em lineindex
        /// </summary>
        EM_LINEINDEX = 0x00BB,
        /// <summary>
        /// The em linefromchar
        /// </summary>
        EM_LINEFROMCHAR = 0x00C9,
        /// <summary>
        /// The em posfromchar
        /// </summary>
        EM_POSFROMCHAR = 0x00D6,
    }

    /// <summary>
    /// Enum TextBoxStyles
    /// </summary>
    public enum TextBoxStyles
    {
        /// <summary>
        /// The es left
        /// </summary>
        ES_LEFT = 0x0000,
        /// <summary>
        /// The es center
        /// </summary>
        ES_CENTER = 0x0001,
        /// <summary>
        /// The es right
        /// </summary>
        ES_RIGHT = 0x0002,
        /// <summary>
        /// The es multiline
        /// </summary>
        ES_MULTILINE = 0x0004,
        /// <summary>
        /// The es uppercase
        /// </summary>
        ES_UPPERCASE = 0x0008,
        /// <summary>
        /// The es lowercase
        /// </summary>
        ES_LOWERCASE = 0x0010,
        /// <summary>
        /// The es password
        /// </summary>
        ES_PASSWORD = 0x0020,
        /// <summary>
        /// The es autovscroll
        /// </summary>
        ES_AUTOVSCROLL = 0x0040,
        /// <summary>
        /// The es autohscroll
        /// </summary>
        ES_AUTOHSCROLL = 0x0080,
        /// <summary>
        /// The es nohidesel
        /// </summary>
        ES_NOHIDESEL = 0x0100,
        /// <summary>
        /// The es oemconvert
        /// </summary>
        ES_OEMCONVERT = 0x0400,
        /// <summary>
        /// The es readonly
        /// </summary>
        ES_READONLY = 0x0800,
        /// <summary>
        /// The es wantreturn
        /// </summary>
        ES_WANTRETURN = 0x1000,
    }

    /// <summary>
    /// Enum WMPrintFlags
    /// </summary>
    [Flags()]
    public enum WMPrintFlags
    {
        /// <summary>
        /// The PRF checkvisible
        /// </summary>
        PRF_CHECKVISIBLE = 0x00000001,
        /// <summary>
        /// The PRF nonclient
        /// </summary>
        PRF_NONCLIENT = 0x00000002,
        /// <summary>
        /// The PRF client
        /// </summary>
        PRF_CLIENT = 0x00000004,
        /// <summary>
        /// The PRF erasebkgnd
        /// </summary>
        PRF_ERASEBKGND = 0x00000008,
        /// <summary>
        /// The PRF children
        /// </summary>
        PRF_CHILDREN = 0x00000010,
        /// <summary>
        /// The PRF owned
        /// </summary>
        PRF_OWNED = 0x0000020,
    }

    #region Shell Enumerations

    /// <summary>
    /// Enum SHGNO
    /// </summary>
    [Flags]
    public enum SHGNO : uint
    {
        /// <summary>
        /// The SHGDN normal
        /// </summary>
        SHGDN_NORMAL = 0x0000,                 // Default (display purpose)
        /// <summary>
        /// The SHGDN infolder
        /// </summary>
        SHGDN_INFOLDER = 0x0001,               // Displayed under a folder (relative)
        /// <summary>
        /// The SHGDN forediting
        /// </summary>
        SHGDN_FOREDITING = 0x1000,             // For in-place editing
        /// <summary>
        /// The SHGDN foraddressbar
        /// </summary>
        SHGDN_FORADDRESSBAR = 0x4000,          // UI friendly parsing name (remove ugly stuff)
        /// <summary>
        /// The SHGDN forparsing
        /// </summary>
        SHGDN_FORPARSING = 0x8000,             // Parsing name for ParseDisplayName()
    }

    /// <summary>
    /// Enum SHCONTF
    /// </summary>
    [Flags]
    public enum SHCONTF : uint
    {
        /// <summary>
        /// The shcontf folders
        /// </summary>
        SHCONTF_FOLDERS = 0x0020,              // Only want folders enumerated (SFGAO_FOLDER)
        /// <summary>
        /// The shcontf nonfolders
        /// </summary>
        SHCONTF_NONFOLDERS = 0x0040,           // Include non folders
        /// <summary>
        /// The shcontf includehidden
        /// </summary>
        SHCONTF_INCLUDEHIDDEN = 0x0080,        // Show items normally hidden
        /// <summary>
        /// The shcontf initialize on first next
        /// </summary>
        SHCONTF_INIT_ON_FIRST_NEXT = 0x0100,   // Allow EnumObject() to return before validating enum
        /// <summary>
        /// The shcontf netprintersrch
        /// </summary>
        SHCONTF_NETPRINTERSRCH = 0x0200,       // Hint that client is looking for printers
        /// <summary>
        /// The shcontf shareable
        /// </summary>
        SHCONTF_SHAREABLE = 0x0400,            // Hint that client is looking sharable resources (remote shares)
        /// <summary>
        /// The shcontf storage
        /// </summary>
        SHCONTF_STORAGE = 0x0800,              // Include all items with accessible storage and their ancestors
    }

    /// <summary>
    /// Enum SFGAOF
    /// </summary>
    [Flags]
    public enum SFGAOF : uint
    {
        /// <summary>
        /// The sfgao cancopy
        /// </summary>
        SFGAO_CANCOPY = 0x1,                   // Objects can be copied  (DROPEFFECT_COPY)
        /// <summary>
        /// The sfgao canmove
        /// </summary>
        SFGAO_CANMOVE = 0x2,                   // Objects can be moved   (DROPEFFECT_MOVE)
        /// <summary>
        /// The sfgao canlink
        /// </summary>
        SFGAO_CANLINK = 0x4,                   // Objects can be linked  (DROPEFFECT_LINK)
        /// <summary>
        /// The sfgao storage
        /// </summary>
        SFGAO_STORAGE = 0x00000008,            // Supports BindToObject(IID_IStorage)
        /// <summary>
        /// The sfgao canrename
        /// </summary>
        SFGAO_CANRENAME = 0x00000010,          // Objects can be renamed
        /// <summary>
        /// The sfgao candelete
        /// </summary>
        SFGAO_CANDELETE = 0x00000020,          // Objects can be deleted
        /// <summary>
        /// The sfgao haspropsheet
        /// </summary>
        SFGAO_HASPROPSHEET = 0x00000040,       // Objects have property sheets
        /// <summary>
        /// The sfgao droptarget
        /// </summary>
        SFGAO_DROPTARGET = 0x00000100,         // Objects are drop target
        /// <summary>
        /// The sfgao capabilitymask
        /// </summary>
        SFGAO_CAPABILITYMASK = 0x00000177,
        /// <summary>
        /// The sfgao encrypted
        /// </summary>
        SFGAO_ENCRYPTED = 0x00002000,          // Object is encrypted (use alt color)
        /// <summary>
        /// The sfgao isslow
        /// </summary>
        SFGAO_ISSLOW = 0x00004000,             // 'Slow' object
        /// <summary>
        /// The sfgao ghosted
        /// </summary>
        SFGAO_GHOSTED = 0x00008000,            // Ghosted icon
        /// <summary>
        /// The sfgao link
        /// </summary>
        SFGAO_LINK = 0x00010000,               // Shortcut (link)
        /// <summary>
        /// The sfgao share
        /// </summary>
        SFGAO_SHARE = 0x00020000,              // Shared
        /// <summary>
        /// The sfgao readonly
        /// </summary>
        SFGAO_READONLY = 0x00040000,           // Read-only
        /// <summary>
        /// The sfgao hidden
        /// </summary>
        SFGAO_HIDDEN = 0x00080000,             // Hidden object
        /// <summary>
        /// The sfgao displayattrmask
        /// </summary>
        SFGAO_DISPLAYATTRMASK = 0x000FC000,
        /// <summary>
        /// The sfgao filesysancestor
        /// </summary>
        SFGAO_FILESYSANCESTOR = 0x10000000,    // May contain children with SFGAO_FILESYSTEM
        /// <summary>
        /// The sfgao folder
        /// </summary>
        SFGAO_FOLDER = 0x20000000,             // Support BindToObject(IID_IShellFolder)
        /// <summary>
        /// The sfgao filesystem
        /// </summary>
        SFGAO_FILESYSTEM = 0x40000000,         // Is a win32 file system object (file/folder/root)
        /// <summary>
        /// The sfgao hassubfolder
        /// </summary>
        SFGAO_HASSUBFOLDER = 0x80000000,       // May contain children with SFGAO_FOLDER
        /// <summary>
        /// The sfgao contentsmask
        /// </summary>
        SFGAO_CONTENTSMASK = 0x80000000,
        /// <summary>
        /// The sfgao validate
        /// </summary>
        SFGAO_VALIDATE = 0x01000000,           // Invalidate cached information
        /// <summary>
        /// The sfgao removable
        /// </summary>
        SFGAO_REMOVABLE = 0x02000000,          // Is this removeable media?
        /// <summary>
        /// The sfgao compressed
        /// </summary>
        SFGAO_COMPRESSED = 0x04000000,         // Object is compressed (use alt color)
        /// <summary>
        /// The sfgao browsable
        /// </summary>
        SFGAO_BROWSABLE = 0x08000000,          // Supports IShellFolder, but only implements CreateViewObject() (non-folder view)
        /// <summary>
        /// The sfgao nonenumerated
        /// </summary>
        SFGAO_NONENUMERATED = 0x00100000,      // Is a non-enumerated object
        /// <summary>
        /// The sfgao newcontent
        /// </summary>
        SFGAO_NEWCONTENT = 0x00200000,         // Should show bold in explorer tree
        /// <summary>
        /// The sfgao canmoniker
        /// </summary>
        SFGAO_CANMONIKER = 0x00400000,         // Defunct
        /// <summary>
        /// The sfgao hasstorage
        /// </summary>
        SFGAO_HASSTORAGE = 0x00400000,         // Defunct
        /// <summary>
        /// The sfgao stream
        /// </summary>
        SFGAO_STREAM = 0x00400000,             // Supports BindToObject(IID_IStream)
        /// <summary>
        /// The sfgao storageancestor
        /// </summary>
        SFGAO_STORAGEANCESTOR = 0x00800000,    // May contain children with SFGAO_STORAGE or SFGAO_STREAM
        /// <summary>
        /// The sfgao storagecapmask
        /// </summary>
        SFGAO_STORAGECAPMASK = 0x70C50008,     // For determining storage capabilities, ie for open/save semantics
    }

    /// <summary>
    /// Enum STRRET
    /// </summary>
    [Flags]
    public enum STRRET : uint
    {
        /// <summary>
        /// The strret WSTR
        /// </summary>
        STRRET_WSTR = 0,
        /// <summary>
        /// The strret offset
        /// </summary>
        STRRET_OFFSET = 0x1,
        /// <summary>
        /// The strret CSTR
        /// </summary>
        STRRET_CSTR = 0x2,
    }

    /// <summary>
    /// Enum SHGFI
    /// </summary>
    [Flags]
    public enum SHGFI
    {
        /// <summary>
        /// The shgfi icon
        /// </summary>
        SHGFI_ICON = 0x000000100,
        /// <summary>
        /// The shgfi displayname
        /// </summary>
        SHGFI_DISPLAYNAME = 0x000000200,
        /// <summary>
        /// The shgfi typename
        /// </summary>
        SHGFI_TYPENAME = 0x000000400,
        /// <summary>
        /// The shgfi attributes
        /// </summary>
        SHGFI_ATTRIBUTES = 0x000000800,
        /// <summary>
        /// The shgfi iconlocation
        /// </summary>
        SHGFI_ICONLOCATION = 0x000001000,
        /// <summary>
        /// The shgfi exetype
        /// </summary>
        SHGFI_EXETYPE = 0x000002000,
        /// <summary>
        /// The shgfi sysiconindex
        /// </summary>
        SHGFI_SYSICONINDEX = 0x000004000,
        /// <summary>
        /// The shgfi linkoverlay
        /// </summary>
        SHGFI_LINKOVERLAY = 0x000008000,
        /// <summary>
        /// The shgfi selected
        /// </summary>
        SHGFI_SELECTED = 0x000010000,
        /// <summary>
        /// The shgfi attribute specified
        /// </summary>
        SHGFI_ATTR_SPECIFIED = 0x000020000,
        /// <summary>
        /// The shgfi largeicon
        /// </summary>
        SHGFI_LARGEICON = 0x000000000,
        /// <summary>
        /// The shgfi smallicon
        /// </summary>
        SHGFI_SMALLICON = 0x000000001,
        /// <summary>
        /// The shgfi openicon
        /// </summary>
        SHGFI_OPENICON = 0x000000002,
        /// <summary>
        /// The shgfi shelliconsize
        /// </summary>
        SHGFI_SHELLICONSIZE = 0x000000004,
        /// <summary>
        /// The shgfi pidl
        /// </summary>
        SHGFI_PIDL = 0x000000008,
        /// <summary>
        /// The shgfi usefileattributes
        /// </summary>
        SHGFI_USEFILEATTRIBUTES = 0x000000010,
        /// <summary>
        /// The shgfi addoverlays
        /// </summary>
        SHGFI_ADDOVERLAYS = 0x000000020,
        /// <summary>
        /// The shgfi overlayindex
        /// </summary>
        SHGFI_OVERLAYINDEX = 0x000000040
    }

    /// <summary>
    /// Enum CSIDL
    /// </summary>
    [Flags]
    public enum CSIDL : uint
    {
        /// <summary>
        /// The csidl desktop
        /// </summary>
        CSIDL_DESKTOP = 0x0000,
        /// <summary>
        /// The csidl windows
        /// </summary>
        CSIDL_WINDOWS = 0x0024
    }

    #endregion
}
