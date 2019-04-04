// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="IMEWindow.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using System;
using System.Drawing; 
using Zeroit.Framework.Utilities.Win32;

namespace Zeroit.Framework.Utilities.Globalization
{
    /// <summary>
    /// Class IMEWindow.
    /// </summary>
    public class IMEWindow
    {
        /// <summary>
        /// The imc setcompositionwindow
        /// </summary>
        private const int IMC_SETCOMPOSITIONWINDOW = 0x000c;
        /// <summary>
        /// The CFS point
        /// </summary>
        private const int CFS_POINT = 0x0002;
        /// <summary>
        /// The imc setcompositionfont
        /// </summary>
        private const int IMC_SETCOMPOSITIONFONT = 0x000a;
        /// <summary>
        /// The ff modern
        /// </summary>
        private const byte FF_MODERN = 48;
        /// <summary>
        /// The fixed pitch
        /// </summary>
        private const byte FIXED_PITCH = 1;
        /// <summary>
        /// The h IME WND
        /// </summary>
        private IntPtr hIMEWnd;

        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="IMEWindow"/> class.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="fontname">The fontname.</param>
        /// <param name="fontsize">The fontsize.</param>
        public IMEWindow(IntPtr hWnd, string fontname, float fontsize)
        {
            hIMEWnd = NativeImm32Api.ImmGetDefaultIMEWnd(hWnd);
            SetFont(fontname, fontsize);
        }

        #endregion

        #region PUBLIC PROPERTY FONT

        /// <summary>
        /// The font
        /// </summary>
        private Font _Font = null;

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>The font.</value>
        public Font Font
        {
            get { return _Font; }
            set
            {
                if (_Font.Equals(value) == false)
                {
                    SetFont(value);
                    _Font = value;
                }
            }
        }

        /// <summary>
        /// Sets the font.
        /// </summary>
        /// <param name="font">The font.</param>
        public void SetFont(Font font)
        {
            LogFont lf = new LogFont();
            font.ToLogFont(lf);
            lf.lfPitchAndFamily = FIXED_PITCH | FF_MODERN;

            NativeUser32Api.SendMessage(
                hIMEWnd, (int)WindowMessage.WM_IME_CONTROL,
                IMC_SETCOMPOSITIONFONT,
                lf
                );
        }

        /// <summary>
        /// Sets the font.
        /// </summary>
        /// <param name="fontname">The fontname.</param>
        /// <param name="fontsize">The fontsize.</param>
        public void SetFont(string fontname, float fontsize)
        {
            LogFont tFont = new LogFont();
            tFont.lfItalic = (byte)0;
            tFont.lfStrikeOut = (byte)0;
            tFont.lfUnderline = (byte)0;
            tFont.lfWeight = 400;
            tFont.lfWidth = 0;
            tFont.lfHeight = (int)(-fontsize * 1.3333333333333);
            tFont.lfCharSet = 1;
            tFont.lfPitchAndFamily = FIXED_PITCH | FF_MODERN;
            tFont.lfFaceName = fontname;

            LogFont lf = tFont;

            NativeUser32Api.SendMessage(
                hIMEWnd, (int)WindowMessage.WM_IME_CONTROL,
                IMC_SETCOMPOSITIONFONT,
                lf
                );
        }

        #endregion

        #region PUBLIC PROPERTY LOATION

        /// <summary>
        /// The loation
        /// </summary>
        private Point _Loation;

        /// <summary>
        /// Gets or sets the loation.
        /// </summary>
        /// <value>The loation.</value>
        public Point Loation
        {
            get { return _Loation; }
            set
            {
                _Loation = value;

                POINTAPI p = new POINTAPI();
                p.X = value.X;
                p.Y = value.Y;

                COMPOSITIONFORM lParam = new COMPOSITIONFORM();
                lParam.dwStyle = CFS_POINT;
                lParam.ptCurrentPos = p;
                lParam.rcArea = new RECTAPI();

                NativeUser32Api.SendMessage(
                    hIMEWnd,
                    (int)WindowMessage.WM_IME_CONTROL,
                    IMC_SETCOMPOSITIONWINDOW,
                    lParam
                    );
            }
        }

        #endregion
    }
}