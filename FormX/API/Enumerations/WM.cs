// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="WM.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Enum WM
    /// </summary>
    public enum WM
    {
        /// <summary>
        /// The null
        /// </summary>
        NULL = 0x0,
        /// <summary>
        /// The create
        /// </summary>
        CREATE = 0x1,
        /// <summary>
        /// The destroy
        /// </summary>
        DESTROY = 0x2,
        /// <summary>
        /// The move
        /// </summary>
        MOVE = 0x3,
        /// <summary>
        /// The size
        /// </summary>
        SIZE = 0x5,
        /// <summary>
        /// The activate
        /// </summary>
        ACTIVATE = 0x6,
        /// <summary>
        /// The setfocus
        /// </summary>
        SETFOCUS = 0x7,
        /// <summary>
        /// The killfocus
        /// </summary>
        KILLFOCUS = 0x8,
        /// <summary>
        /// The enable
        /// </summary>
        ENABLE = 0xa,
        /// <summary>
        /// The setredraw
        /// </summary>
        SETREDRAW = 0xb,
        /// <summary>
        /// The settext
        /// </summary>
        SETTEXT = 0xc,
        /// <summary>
        /// The gettext
        /// </summary>
        GETTEXT = 0xd,
        /// <summary>
        /// The gettextlength
        /// </summary>
        GETTEXTLENGTH = 0xe,
        /// <summary>
        /// The paint
        /// </summary>
        PAINT = 0xf,
        /// <summary>
        /// The close
        /// </summary>
        CLOSE = 0x010,
        /// <summary>
        /// The queryendsession
        /// </summary>
        QUERYENDSESSION = 0x11,
        /// <summary>
        /// The queryopen
        /// </summary>
        QUERYOPEN = 0x13,
        /// <summary>
        /// The endsession
        /// </summary>
        ENDSESSION = 0x16,
        /// <summary>
        /// The quit
        /// </summary>
        QUIT = 0x12,
        /// <summary>
        /// The erasebkgnd
        /// </summary>
        ERASEBKGND = 0x14,
        /// <summary>
        /// The syscolorchange
        /// </summary>
        SYSCOLORCHANGE = 0x15,
        /// <summary>
        /// The showwindow
        /// </summary>
        SHOWWINDOW = 0x18,
        /// <summary>
        /// The wininichange
        /// </summary>
        WININICHANGE = 0x1a,
        /// <summary>
        /// The settingchange
        /// </summary>
        SETTINGCHANGE = WININICHANGE,
        /// <summary>
        /// The devmodechange
        /// </summary>
        DEVMODECHANGE = 0x1b,
        /// <summary>
        /// The activateapp
        /// </summary>
        ACTIVATEAPP = 0x1c,
        /// <summary>
        /// The fontchange
        /// </summary>
        FONTCHANGE = 0x1d,
        /// <summary>
        /// The timechange
        /// </summary>
        TIMECHANGE = 0x1e,
        /// <summary>
        /// The cancelmode
        /// </summary>
        CANCELMODE = 0x1f,
        /// <summary>
        /// The setcursor
        /// </summary>
        SETCURSOR = 0x20,
        /// <summary>
        /// The mouseactivate
        /// </summary>
        MOUSEACTIVATE = 0x21,
        /// <summary>
        /// The childactivate
        /// </summary>
        CHILDACTIVATE = 0x22,
        /// <summary>
        /// The queuesync
        /// </summary>
        QUEUESYNC = 0x23,
        /// <summary>
        /// The getminmaxinfo
        /// </summary>
        GETMINMAXINFO = 0x24,
        /// <summary>
        /// The painticon
        /// </summary>
        PAINTICON = 0x26,
        /// <summary>
        /// The iconerasebkgnd
        /// </summary>
        ICONERASEBKGND = 0x27,
        /// <summary>
        /// The nextdlgctl
        /// </summary>
        NEXTDLGCTL = 0x28,
        /// <summary>
        /// The spoolerstatus
        /// </summary>
        SPOOLERSTATUS = 0x2a,
        /// <summary>
        /// The drawitem
        /// </summary>
        DRAWITEM = 0x2b,
        /// <summary>
        /// The measureitem
        /// </summary>
        MEASUREITEM = 0x2c,
        /// <summary>
        /// The deleteitem
        /// </summary>
        DELETEITEM = 0x2d,
        /// <summary>
        /// The vkeytoitem
        /// </summary>
        VKEYTOITEM = 0x2e,
        /// <summary>
        /// The chartoitem
        /// </summary>
        CHARTOITEM = 0x2f,
        /// <summary>
        /// The setfont
        /// </summary>
        SETFONT = 0x30,
        /// <summary>
        /// The getfont
        /// </summary>
        GETFONT = 0x31,
        /// <summary>
        /// The sethotkey
        /// </summary>
        SETHOTKEY = 0x32,
        /// <summary>
        /// The gethotkey
        /// </summary>
        GETHOTKEY = 0x33,
        /// <summary>
        /// The querydragicon
        /// </summary>
        QUERYDRAGICON = 0x37,
        /// <summary>
        /// The compareitem
        /// </summary>
        COMPAREITEM = 0x39,
        /// <summary>
        /// The getobject
        /// </summary>
        GETOBJECT = 0x3d,
        /// <summary>
        /// The compacting
        /// </summary>
        COMPACTING = 0x41,
        /// <summary>
        /// The commnotify
        /// </summary>
        COMMNOTIFY = 0x44,
        /// <summary>
        /// The windowposchanging
        /// </summary>
        WINDOWPOSCHANGING = 0x46,
        /// <summary>
        /// The windowposchanged
        /// </summary>
        WINDOWPOSCHANGED = 0x47,
        /// <summary>
        /// The power
        /// </summary>
        POWER = 0x48,
        /// <summary>
        /// The copydata
        /// </summary>
        COPYDATA = 0x4a,
        /// <summary>
        /// The canceljournal
        /// </summary>
        CANCELJOURNAL = 0x4b,
        /// <summary>
        /// The notify
        /// </summary>
        NOTIFY = 0x4e,
        /// <summary>
        /// The inputlangchangerequest
        /// </summary>
        INPUTLANGCHANGEREQUEST = 0x50,
        /// <summary>
        /// The inputlangchange
        /// </summary>
        INPUTLANGCHANGE = 0x51,
        /// <summary>
        /// The tcard
        /// </summary>
        TCARD = 0x52,
        /// <summary>
        /// The help
        /// </summary>
        HELP = 0x53,
        /// <summary>
        /// The userchanged
        /// </summary>
        USERCHANGED = 0x54,
        /// <summary>
        /// The notifyformat
        /// </summary>
        NOTIFYFORMAT = 0x55,
        /// <summary>
        /// The contextmenu
        /// </summary>
        CONTEXTMENU = 0x7b,
        /// <summary>
        /// The stylechanging
        /// </summary>
        STYLECHANGING = 0x7c,
        /// <summary>
        /// The stylechanged
        /// </summary>
        STYLECHANGED = 0x7d,
        /// <summary>
        /// The displaychange
        /// </summary>
        DISPLAYCHANGE = 0x7e,
        /// <summary>
        /// The geticon
        /// </summary>
        GETICON = 0x7f,
        /// <summary>
        /// The seticon
        /// </summary>
        SETICON = 0x80,
        /// <summary>
        /// The nccreate
        /// </summary>
        NCCREATE = 0x81,
        /// <summary>
        /// The ncdestroy
        /// </summary>
        NCDESTROY = 0x82,
        /// <summary>
        /// The nccalcsize
        /// </summary>
        NCCALCSIZE = 0x83,
        /// <summary>
        /// The nchittest
        /// </summary>
        NCHITTEST = 0x84,
        /// <summary>
        /// The ncpaint
        /// </summary>
        NCPAINT = 0x85,
        /// <summary>
        /// The ncactivate
        /// </summary>
        NCACTIVATE = 0x86,
        /// <summary>
        /// The getdlgcode
        /// </summary>
        GETDLGCODE = 0x87,
        /// <summary>
        /// The syncpaint
        /// </summary>
        SYNCPAINT = 0x88,
        /// <summary>
        /// The ncmousemove
        /// </summary>
        NCMOUSEMOVE = 0xa0,
        /// <summary>
        /// The nclbuttondown
        /// </summary>
        NCLBUTTONDOWN = 0xa1,
        /// <summary>
        /// The nclbuttonup
        /// </summary>
        NCLBUTTONUP = 0xa2,
        /// <summary>
        /// The nclbuttondblclk
        /// </summary>
        NCLBUTTONDBLCLK = 0xa3,
        /// <summary>
        /// The ncrbuttondown
        /// </summary>
        NCRBUTTONDOWN = 0xa4,
        /// <summary>
        /// The ncrbuttonup
        /// </summary>
        NCRBUTTONUP = 0xa5,
        /// <summary>
        /// The ncrbuttondblclk
        /// </summary>
        NCRBUTTONDBLCLK = 0xa6,
        /// <summary>
        /// The ncmbuttondown
        /// </summary>
        NCMBUTTONDOWN = 0xa7,
        /// <summary>
        /// The ncmbuttonup
        /// </summary>
        NCMBUTTONUP = 0xa8,
        /// <summary>
        /// The ncmbuttondblclk
        /// </summary>
        NCMBUTTONDBLCLK = 0xa9,
        /// <summary>
        /// The ncxbuttondown
        /// </summary>
        NCXBUTTONDOWN = 0xab,
        /// <summary>
        /// The ncxbuttonup
        /// </summary>
        NCXBUTTONUP = 0xac,
        /// <summary>
        /// The ncxbuttondblclk
        /// </summary>
        NCXBUTTONDBLCLK = 0xad,
        /// <summary>
        /// The input
        /// </summary>
        INPUT = 0xff,
        /// <summary>
        /// The keyfirst
        /// </summary>
        KEYFIRST = 0x100,
        /// <summary>
        /// The keydown
        /// </summary>
        KEYDOWN = 0x100,
        /// <summary>
        /// The keyup
        /// </summary>
        KEYUP = 0x101,
        /// <summary>
        /// The character
        /// </summary>
        CHAR = 0x102,
        /// <summary>
        /// The deadchar
        /// </summary>
        DEADCHAR = 0x103,
        /// <summary>
        /// The syskeydown
        /// </summary>
        SYSKEYDOWN = 0x104,
        /// <summary>
        /// The syskeyup
        /// </summary>
        SYSKEYUP = 0x105,
        /// <summary>
        /// The syschar
        /// </summary>
        SYSCHAR = 0x106,
        /// <summary>
        /// The sysdeadchar
        /// </summary>
        SYSDEADCHAR = 0x107,
        /// <summary>
        /// The unichar
        /// </summary>
        UNICHAR = 0x109,
        /// <summary>
        /// The keylast
        /// </summary>
        KEYLAST = 0x108,
        /// <summary>
        /// The IME startcomposition
        /// </summary>
        IME_STARTCOMPOSITION = 0x10d,
        /// <summary>
        /// The IME endcomposition
        /// </summary>
        IME_ENDCOMPOSITION = 0x10e,
        /// <summary>
        /// The IME composition
        /// </summary>
        IME_COMPOSITION = 0x10f,
        /// <summary>
        /// The IME keylast
        /// </summary>
        IME_KEYLAST = 0x10f,
        /// <summary>
        /// The initdialog
        /// </summary>
        INITDIALOG = 0x110,
        /// <summary>
        /// The command
        /// </summary>
        COMMAND = 0x111,
        /// <summary>
        /// The syscommand
        /// </summary>
        SYSCOMMAND = 0x112,
        /// <summary>
        /// The timer
        /// </summary>
        TIMER = 0x113,
        /// <summary>
        /// The hscroll
        /// </summary>
        HSCROLL = 0x114,
        /// <summary>
        /// The vscroll
        /// </summary>
        VSCROLL = 0x115,
        /// <summary>
        /// The initmenu
        /// </summary>
        INITMENU = 0x116,
        /// <summary>
        /// The initmenupopup
        /// </summary>
        INITMENUPOPUP = 0x117,
        /// <summary>
        /// The menuselect
        /// </summary>
        MENUSELECT = 0x11f,
        /// <summary>
        /// The menuchar
        /// </summary>
        MENUCHAR = 0x120,
        /// <summary>
        /// The enteridle
        /// </summary>
        ENTERIDLE = 0x121,
        /// <summary>
        /// The menurbuttonup
        /// </summary>
        MENURBUTTONUP = 0x122,
        /// <summary>
        /// The menudrag
        /// </summary>
        MENUDRAG = 0x123,
        /// <summary>
        /// The menugetobject
        /// </summary>
        MENUGETOBJECT = 0x124,
        /// <summary>
        /// The uninitmenupopup
        /// </summary>
        UNINITMENUPOPUP = 0x125,
        /// <summary>
        /// The menucommand
        /// </summary>
        MENUCOMMAND = 0x126,
        /// <summary>
        /// The changeuistate
        /// </summary>
        CHANGEUISTATE = 0x127,
        /// <summary>
        /// The updateuistate
        /// </summary>
        UPDATEUISTATE = 0x128,
        /// <summary>
        /// The queryuistate
        /// </summary>
        QUERYUISTATE = 0x129,
        /// <summary>
        /// The ctlcolor
        /// </summary>
        CTLCOLOR = 0x19,
        /// <summary>
        /// The ctlcolormsgbox
        /// </summary>
        CTLCOLORMSGBOX = 0x132,
        /// <summary>
        /// The ctlcoloredit
        /// </summary>
        CTLCOLOREDIT = 0x133,
        /// <summary>
        /// The ctlcolorlistbox
        /// </summary>
        CTLCOLORLISTBOX = 0x134,
        /// <summary>
        /// The ctlcolorbtn
        /// </summary>
        CTLCOLORBTN = 0x135,
        /// <summary>
        /// The ctlcolordlg
        /// </summary>
        CTLCOLORDLG = 0x136,
        /// <summary>
        /// The ctlcolorscrollbar
        /// </summary>
        CTLCOLORSCROLLBAR = 0x137,
        /// <summary>
        /// The ctlcolorstatic
        /// </summary>
        CTLCOLORSTATIC = 0x138,
        /// <summary>
        /// The mousefirst
        /// </summary>
        MOUSEFIRST = 0x200,
        /// <summary>
        /// The mousemove
        /// </summary>
        MOUSEMOVE = 0x200,
        /// <summary>
        /// The lbuttondown
        /// </summary>
        LBUTTONDOWN = 0x201,
        /// <summary>
        /// The lbuttonup
        /// </summary>
        LBUTTONUP = 0x202,
        /// <summary>
        /// The lbuttondblclk
        /// </summary>
        LBUTTONDBLCLK = 0x203,
        /// <summary>
        /// The rbuttondown
        /// </summary>
        RBUTTONDOWN = 0x204,
        /// <summary>
        /// The rbuttonup
        /// </summary>
        RBUTTONUP = 0x205,
        /// <summary>
        /// The rbuttondblclk
        /// </summary>
        RBUTTONDBLCLK = 0x206,
        /// <summary>
        /// The mbuttondown
        /// </summary>
        MBUTTONDOWN = 0x207,
        /// <summary>
        /// The mbuttonup
        /// </summary>
        MBUTTONUP = 0x208,
        /// <summary>
        /// The mbuttondblclk
        /// </summary>
        MBUTTONDBLCLK = 0x209,
        /// <summary>
        /// The mousewheel
        /// </summary>
        MOUSEWHEEL = 0x20a,
        /// <summary>
        /// The xbuttondown
        /// </summary>
        XBUTTONDOWN = 0x20b,
        /// <summary>
        /// The xbuttonup
        /// </summary>
        XBUTTONUP = 0x20c,
        /// <summary>
        /// The xbuttondblclk
        /// </summary>
        XBUTTONDBLCLK = 0x20d,
        /// <summary>
        /// The mouselast
        /// </summary>
        MOUSELAST = 0x20d,
        /// <summary>
        /// The parentnotify
        /// </summary>
        PARENTNOTIFY = 0x210,
        /// <summary>
        /// The entermenuloop
        /// </summary>
        ENTERMENULOOP = 0x211,
        /// <summary>
        /// The exitmenuloop
        /// </summary>
        EXITMENULOOP = 0x212,
        /// <summary>
        /// The nextmenu
        /// </summary>
        NEXTMENU = 0x213,
        /// <summary>
        /// The sizing
        /// </summary>
        SIZING = 0x214,
        /// <summary>
        /// The capturechanged
        /// </summary>
        CAPTURECHANGED = 0x215,
        /// <summary>
        /// The moving
        /// </summary>
        MOVING = 0x216,
        /// <summary>
        /// The powerbroadcast
        /// </summary>
        POWERBROADCAST = 0x218,
        /// <summary>
        /// The devicechange
        /// </summary>
        DEVICECHANGE = 0x219,
        /// <summary>
        /// The mdicreate
        /// </summary>
        MDICREATE = 0x220,
        /// <summary>
        /// The mdidestroy
        /// </summary>
        MDIDESTROY = 0x221,
        /// <summary>
        /// The mdiactivate
        /// </summary>
        MDIACTIVATE = 0x222,
        /// <summary>
        /// The mdirestore
        /// </summary>
        MDIRESTORE = 0x223,
        /// <summary>
        /// The mdinext
        /// </summary>
        MDINEXT = 0x224,
        /// <summary>
        /// The mdimaximize
        /// </summary>
        MDIMAXIMIZE = 0x225,
        /// <summary>
        /// The mditile
        /// </summary>
        MDITILE = 0x226,
        /// <summary>
        /// The mdicascade
        /// </summary>
        MDICASCADE = 0x227,
        /// <summary>
        /// The mdiiconarrange
        /// </summary>
        MDIICONARRANGE = 0x228,
        /// <summary>
        /// The mdigetactive
        /// </summary>
        MDIGETACTIVE = 0x229,
        /// <summary>
        /// The mdisetmenu
        /// </summary>
        MDISETMENU = 0x230,
        /// <summary>
        /// The entersizemove
        /// </summary>
        ENTERSIZEMOVE = 0x231,
        /// <summary>
        /// The exitsizemove
        /// </summary>
        EXITSIZEMOVE = 0x232,
        /// <summary>
        /// The dropfiles
        /// </summary>
        DROPFILES = 0x233,
        /// <summary>
        /// The mdirefreshmenu
        /// </summary>
        MDIREFRESHMENU = 0x234,
        /// <summary>
        /// The IME setcontext
        /// </summary>
        IME_SETCONTEXT = 0x281,
        /// <summary>
        /// The IME notify
        /// </summary>
        IME_NOTIFY = 0x282,
        /// <summary>
        /// The IME control
        /// </summary>
        IME_CONTROL = 0x283,
        /// <summary>
        /// The IME compositionfull
        /// </summary>
        IME_COMPOSITIONFULL = 0x284,
        /// <summary>
        /// The IME select
        /// </summary>
        IME_SELECT = 0x285,
        /// <summary>
        /// The IME character
        /// </summary>
        IME_CHAR = 0x286,
        /// <summary>
        /// The IME request
        /// </summary>
        IME_REQUEST = 0x288,
        /// <summary>
        /// The IME keydown
        /// </summary>
        IME_KEYDOWN = 0x290,
        /// <summary>
        /// The IME keyup
        /// </summary>
        IME_KEYUP = 0x291,
        /// <summary>
        /// The mousehover
        /// </summary>
        MOUSEHOVER = 0x2a1,
        /// <summary>
        /// The mouseleave
        /// </summary>
        MOUSELEAVE = 0x2a3,
        /// <summary>
        /// The ncmouseleave
        /// </summary>
        NCMOUSELEAVE = 0x2a2,
        /// <summary>
        /// The wtssession change
        /// </summary>
        WTSSESSION_CHANGE = 0x2b1,
        /// <summary>
        /// The tablet first
        /// </summary>
        TABLET_FIRST = 0x2c0,
        /// <summary>
        /// The tablet last
        /// </summary>
        TABLET_LAST = 0x2df,
        /// <summary>
        /// The cut
        /// </summary>
        CUT = 0x300,
        /// <summary>
        /// The copy
        /// </summary>
        COPY = 0x301,
        /// <summary>
        /// The paste
        /// </summary>
        PASTE = 0x302,
        /// <summary>
        /// The clear
        /// </summary>
        CLEAR = 0x303,
        /// <summary>
        /// The undo
        /// </summary>
        UNDO = 0x304,
        /// <summary>
        /// The renderformat
        /// </summary>
        RENDERFORMAT = 0x305,
        /// <summary>
        /// The renderallformats
        /// </summary>
        RENDERALLFORMATS = 0x306,
        /// <summary>
        /// The destroyclipboard
        /// </summary>
        DESTROYCLIPBOARD = 0x307,
        /// <summary>
        /// The drawclipboard
        /// </summary>
        DRAWCLIPBOARD = 0x308,
        /// <summary>
        /// The paintclipboard
        /// </summary>
        PAINTCLIPBOARD = 0x309,
        /// <summary>
        /// The vscrollclipboard
        /// </summary>
        VSCROLLCLIPBOARD = 0x30a,
        /// <summary>
        /// The sizeclipboard
        /// </summary>
        SIZECLIPBOARD = 0x30b,
        /// <summary>
        /// The askcbformatname
        /// </summary>
        ASKCBFORMATNAME = 0x30c,
        /// <summary>
        /// The changecbchain
        /// </summary>
        CHANGECBCHAIN = 0x30d,
        /// <summary>
        /// The hscrollclipboard
        /// </summary>
        HSCROLLCLIPBOARD = 0x30e,
        /// <summary>
        /// The querynewpalette
        /// </summary>
        QUERYNEWPALETTE = 0x30f,
        /// <summary>
        /// The paletteischanging
        /// </summary>
        PALETTEISCHANGING = 0x310,
        /// <summary>
        /// The palettechanged
        /// </summary>
        PALETTECHANGED = 0x311,
        /// <summary>
        /// The hotkey
        /// </summary>
        HOTKEY = 0x312,
        /// <summary>
        /// The print
        /// </summary>
        PRINT = 0x317,
        /// <summary>
        /// The printclient
        /// </summary>
        PRINTCLIENT = 0x318,
        /// <summary>
        /// The appcommand
        /// </summary>
        APPCOMMAND = 0x319,
        /// <summary>
        /// The themechanged
        /// </summary>
        THEMECHANGED = 0x31a,
        /// <summary>
        /// The handheldfirst
        /// </summary>
        HANDHELDFIRST = 0x358,
        /// <summary>
        /// The handheldlast
        /// </summary>
        HANDHELDLAST = 0x35f,
        /// <summary>
        /// The afxfirst
        /// </summary>
        AFXFIRST = 0x360,
        /// <summary>
        /// The afxlast
        /// </summary>
        AFXLAST = 0x37f,
        /// <summary>
        /// The penwinfirst
        /// </summary>
        PENWINFIRST = 0x380,
        /// <summary>
        /// The penwinlast
        /// </summary>
        PENWINLAST = 0x38f,
        /// <summary>
        /// The user
        /// </summary>
        USER = 0x400,
        /// <summary>
        /// The reflect
        /// </summary>
        REFLECT = 0x2000,
        /// <summary>
        /// The application
        /// </summary>
        APP = 0x8000
    }
}
