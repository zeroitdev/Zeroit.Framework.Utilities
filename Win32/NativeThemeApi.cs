// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="NativeThemeApi.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.Win32
{
    /// <summary>
    /// Class NativeThemeApi.
    /// </summary>
    public static class NativeThemeApi
    {
        #region uxTheme.dll

        /// <summary>
        /// Opens the theme data.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="pszClassList">The PSZ class list.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("uxtheme.dll", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr OpenThemeData(IntPtr hwnd, [MarshalAs(UnmanagedType.LPWStr)] string pszClassList);

        /// <summary>
        /// Closes the theme data.
        /// </summary>
        /// <param name="hTheme">The h theme.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("uxtheme.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr CloseThemeData(IntPtr hTheme);

        /// <summary>
        /// Determines whether [is theme active].
        /// </summary>
        /// <returns><c>true</c> if [is theme active]; otherwise, <c>false</c>.</returns>
        [DllImport("uxtheme.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool IsThemeActive();

        /// <summary>
        /// Draws the theme background.
        /// </summary>
        /// <param name="hTheme">The h theme.</param>
        /// <param name="hdc">The HDC.</param>
        /// <param name="iPartId">The i part identifier.</param>
        /// <param name="iStateId">The i state identifier.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="clipRect">The clip rect.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("uxtheme.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int DrawThemeBackground(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, ref RECTAPI rect, ref RECTAPI clipRect);

        /// <summary>
        /// Draws the theme text.
        /// </summary>
        /// <param name="hTheme">The h theme.</param>
        /// <param name="hdc">The HDC.</param>
        /// <param name="iPartId">The i part identifier.</param>
        /// <param name="iStateId">The i state identifier.</param>
        /// <param name="pszText">The PSZ text.</param>
        /// <param name="iCharCount">The i character count.</param>
        /// <param name="dwTextFlags">The dw text flags.</param>
        /// <param name="dwTextFlags2">The dw text flags2.</param>
        /// <param name="rect">The rect.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("uxtheme.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int DrawThemeText(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, string pszText, int iCharCount, uint dwTextFlags, uint dwTextFlags2, [MarshalAs(UnmanagedType.Struct)] ref RECTAPI rect);

        /// <summary>
        /// Gets the color of the theme.
        /// </summary>
        /// <param name="hTheme">The h theme.</param>
        /// <param name="iPartId">The i part identifier.</param>
        /// <param name="iStateId">The i state identifier.</param>
        /// <param name="iPropId">The i property identifier.</param>
        /// <param name="color">The color.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("uxtheme.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetThemeColor(IntPtr hTheme, int iPartId, int iStateId, int iPropId, out ulong color);

        /*
        [DllImportAttribute( "uxtheme.dll")]
        public static extern void GetThemeBackgroundContentRect( int hTheme, IntPtr hdc, int iPartId, int iStateId, ref RECT pBoundingRect, ref RECT pContentRect );

        [DllImportAttribute( "uxtheme.dll" )]
        public static extern void GetThemeBackgroundExtent( int hTheme, IntPtr hdc, int iPartId, int iStateId, ref RECT pContentRect, ref RECT pExtentRect );

        [DllImportAttribute( "uxtheme.dll")]
        public static extern uint GetThemePartSize( IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, IntPtr prc, int sizeType, out SIZE psz );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern uint GetThemeTextExtent( IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, string pszText, int iCharCount, uint dwTextFlags, [MarshalAs( UnmanagedType.Struct )] ref RECT pBoundingRect, out RECT pExtentRect );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong GetThemeTextMetrics( IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, out TEXTMETRIC ptm );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong GetThemeBackgroundRegion( IntPtr hTheme, int iPartId, int iStateId, RECT pRect, out IntPtr pRegion );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong HitTestThemeBackground( IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, ulong dwOptions, RECT pRect, IntPtr hrgn, POINT ptTest, out uint wHitTestCode );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong DrawThemeLine( IntPtr hTheme, IntPtr hdc, int iStateId, RECT pRect, ulong dwDtlFlags );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong DrawThemeEdge( IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, RECT pDestRect, uint uEdge, uint uFlags, out RECT contentRect );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong DrawThemeBorder( IntPtr hTheme, IntPtr hdc, int iStateId, RECT pRect );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong DrawThemeIcon( IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, RECT pRect, IntPtr himl, int iImageIndex );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern bool IsThemePartDefined( IntPtr hTheme, int iPartId, int iStateId );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern bool IsThemeBackgroundPartiallyTransparent( IntPtr hTheme, int iPartId, int iStateId );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern int GetThemeColor( IntPtr hTheme, int iPartId, int iStateId, int iPropId, out ulong color );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong GetThemeMetric( IntPtr hTheme, int iPartId, int iStateId, int iPropId, out int iVal );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong GetThemeString( IntPtr hTheme, int iPartId, int iStateId, int iPropId, out string pszBuff, int cchMaxBuffChars );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong GetThemeBool( IntPtr hTheme, int iPartId, int iStateId, int iPropId, out bool fVal );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong GetThemeInt( IntPtr hTheme, int iPartId, int iStateId, int iPropId, out int iVal );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong GetThemeEnumValue( IntPtr hTheme, int iPartId, int iStateId, int iPropId, out int iVal );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong GetThemePosition( IntPtr hTheme, int iPartId, int iStateId, int iPropId, out POINT point );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong GetThemeFont( IntPtr hTheme, int iPartId, int iStateId, int iPropId, out LOGFONT font );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong GetThemeRect( IntPtr hTheme, int iPartId, int iStateId, int iPropId, out RECT pRect );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong GetThemeMargins( IntPtr hTheme, int iPartId, int iStateId, int iPropId, out MARGINS margins );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong GetThemeIntList( IntPtr hTheme, int iPartId, int iStateId, int iPropId, out INTLIST intList );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong GetThemePropertyOrigin( IntPtr hTheme, int iPartId, int iStateId, int iPropId, out int origin );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong SetWindowTheme( IntPtr hwnd, string pszSubAppName, string pszSubIdList );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong GetThemeFilename( IntPtr hTheme, int iPartId, int iStateId, int iPropId, out string pszThemeFileName, int cchMaxBuffChars );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong GetThemeSysColor( IntPtr hTheme, int iColorId );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern IntPtr GetThemeSysColorBrush( IntPtr hTheme, int iColorId );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern int GetThemeSysSize( IntPtr hTheme, int iSizeId );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern bool GetThemeSysBool( IntPtr hTheme, int iBoolId );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong GetThemeSysFont( IntPtr hTheme, int iFontId, out LOGFONT lf );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong GetThemeSysString( IntPtr hTheme, int iStringId, out string pszStringBuff, int cchMaxStringChars );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong GetThemeSysInt( IntPtr hTheme, int iIntId, out int iValue );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern bool IsAppThemed();

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern IntPtr GetWindowTheme( IntPtr hwnd );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong EnableThemeDialogTexture( IntPtr hwnd, bool fEnable );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern bool IsThemeDialogTextureEnabled( IntPtr hwnd );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong GetThemeAppProperties();

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern void SetThemeAppProperties( ulong dwFlags );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong GetCurrentThemeName( out string pszThemeFileName, int cchMaxNameChars, out string pszColorBuff, int cchMaxColorChars, out string pszSizeBuff, int cchMaxSizeChars );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong GetThemeDocumentationProperty( string pszThemeName, string pszPropertyName, out string pszValueBuff, int cchMaxValChars );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong GetThemeLastErrorContext( out THEME_ERROR_CONTEXT context );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong FormatThemeMessage( ulong dwLanguageId, THEME_ERROR_CONTEXT context, out string pszMessageBuff, int cchMaxMessageChars );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern ulong GetThemeImageFromParent( IntPtr hwnd, IntPtr hdc, RECT rc );

        [DllImportAttribute( "uxtheme.dll", CharSet=CharSet.Auto )]
        public static extern IntPtr DrawThemeParentBackground( IntPtr hwnd, IntPtr hdc, ref RECT prc );
*/

        #endregion
    }
}
