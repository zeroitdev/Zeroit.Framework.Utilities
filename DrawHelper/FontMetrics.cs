// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="FontMetrics.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.GraphicsExtension
{
    /// <summary>
    /// Class FontMetricsImpl.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.FontMetrics" />
    public class FontMetricsImpl : FontMetrics
    {
        /// <summary>
        /// Struct TEXTMETRIC
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct TEXTMETRIC
        {
            /// <summary>
            /// The tm height
            /// </summary>
            public int tmHeight;
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
            public char tmFirstChar;
            /// <summary>
            /// The tm last character
            /// </summary>
            public char tmLastChar;
            /// <summary>
            /// The tm default character
            /// </summary>
            public char tmDefaultChar;
            /// <summary>
            /// The tm break character
            /// </summary>
            public char tmBreakChar;
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
        /// Selects the object.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <param name="hgdiobj">The hgdiobj.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
        /// <summary>
        /// Gets the text metrics.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <param name="lptm">The LPTM.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
        public static extern bool GetTextMetrics(IntPtr hdc, out TEXTMETRIC lptm);
        /// <summary>
        /// Deletes the object.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
        public static extern bool DeleteObject(IntPtr hdc);
        /// <summary>
        /// Generates the text metrics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <returns>TEXTMETRIC.</returns>
        private TEXTMETRIC GenerateTextMetrics(
            System.Drawing.Graphics graphics,
            Font font)
        {
            IntPtr hDC = IntPtr.Zero;
            TEXTMETRIC textMetric;
            IntPtr hFont = IntPtr.Zero;
            try
            {
                hDC = graphics.GetHdc();
                hFont = font.ToHfont();
                IntPtr hFontDefault = SelectObject(hDC, hFont);
                bool result = GetTextMetrics(hDC, out textMetric);
                SelectObject(hDC, hFontDefault);
            }
            finally
            {
                if (hFont != IntPtr.Zero) DeleteObject(hFont);
                if (hDC != IntPtr.Zero) graphics.ReleaseHdc(hDC);
            }
            return textMetric;
        }
        /// <summary>
        /// The metrics
        /// </summary>
        private TEXTMETRIC metrics;
        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>The height.</value>
        public override int Height { get { return this.metrics.tmHeight; } }
        /// <summary>
        /// Gets the ascent.
        /// </summary>
        /// <value>The ascent.</value>
        public override int Ascent { get { return this.metrics.tmAscent; } }
        /// <summary>
        /// Gets the descent.
        /// </summary>
        /// <value>The descent.</value>
        public override int Descent { get { return this.metrics.tmDescent; } }
        /// <summary>
        /// Gets the internal leading.
        /// </summary>
        /// <value>The internal leading.</value>
        public override int InternalLeading { get { return this.metrics.tmInternalLeading; } }
        /// <summary>
        /// Gets the external leading.
        /// </summary>
        /// <value>The external leading.</value>
        public override int ExternalLeading { get { return this.metrics.tmExternalLeading; } }
        /// <summary>
        /// Gets the average width of the character.
        /// </summary>
        /// <value>The average width of the character.</value>
        public override int AverageCharacterWidth { get { return this.metrics.tmAveCharWidth; } }
        /// <summary>
        /// Gets the maximum width of the character.
        /// </summary>
        /// <value>The maximum width of the character.</value>
        public override int MaximumCharacterWidth { get { return this.metrics.tmMaxCharWidth; } }
        /// <summary>
        /// Gets the weight.
        /// </summary>
        /// <value>The weight.</value>
        public override int Weight { get { return this.metrics.tmWeight; } }
        /// <summary>
        /// Gets the overhang.
        /// </summary>
        /// <value>The overhang.</value>
        public override int Overhang { get { return this.metrics.tmOverhang; } }
        /// <summary>
        /// Gets the digitized aspect x.
        /// </summary>
        /// <value>The digitized aspect x.</value>
        public override int DigitizedAspectX { get { return this.metrics.tmDigitizedAspectX; } }
        /// <summary>
        /// Gets the digitized aspect y.
        /// </summary>
        /// <value>The digitized aspect y.</value>
        public override int DigitizedAspectY { get { return this.metrics.tmDigitizedAspectY; } }
        /// <summary>
        /// Initializes a new instance of the <see cref="FontMetricsImpl"/> class.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        private FontMetricsImpl(System.Drawing.Graphics graphics, Font font)
        {
            this.metrics = this.GenerateTextMetrics(graphics, font);
        }

        /// <summary>
        /// Gets the font metrics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <returns>FontMetrics.</returns>
        public static FontMetrics GetFontMetrics(
            System.Drawing.Graphics graphics,
            Font font)
        {
            return new FontMetricsImpl(graphics, font);
        }
    }

    /// <summary>
    /// Class FontMetrics.
    /// </summary>
    public abstract class FontMetrics
    {
        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>The height.</value>
        public virtual int Height { get { return 0; } }
        /// <summary>
        /// Gets the ascent.
        /// </summary>
        /// <value>The ascent.</value>
        public virtual int Ascent { get { return 0; } }
        /// <summary>
        /// Gets the descent.
        /// </summary>
        /// <value>The descent.</value>
        public virtual int Descent { get { return 0; } }
        /// <summary>
        /// Gets the internal leading.
        /// </summary>
        /// <value>The internal leading.</value>
        public virtual int InternalLeading { get { return 0; } }
        /// <summary>
        /// Gets the external leading.
        /// </summary>
        /// <value>The external leading.</value>
        public virtual int ExternalLeading { get { return 0; } }
        /// <summary>
        /// Gets the average width of the character.
        /// </summary>
        /// <value>The average width of the character.</value>
        public virtual int AverageCharacterWidth { get { return 0; } }
        /// <summary>
        /// Gets the maximum width of the character.
        /// </summary>
        /// <value>The maximum width of the character.</value>
        public virtual int MaximumCharacterWidth { get { return 0; } }
        /// <summary>
        /// Gets the weight.
        /// </summary>
        /// <value>The weight.</value>
        public virtual int Weight { get { return 0; } }
        /// <summary>
        /// Gets the overhang.
        /// </summary>
        /// <value>The overhang.</value>
        public virtual int Overhang { get { return 0; } }
        /// <summary>
        /// Gets the digitized aspect x.
        /// </summary>
        /// <value>The digitized aspect x.</value>
        public virtual int DigitizedAspectX { get { return 0; } }
        /// <summary>
        /// Gets the digitized aspect y.
        /// </summary>
        /// <value>The digitized aspect y.</value>
        public virtual int DigitizedAspectY { get { return 0; } }
    }
}
