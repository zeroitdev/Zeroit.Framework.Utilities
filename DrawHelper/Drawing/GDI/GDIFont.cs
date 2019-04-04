// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="GDIFont.cs" company="Zeroit Dev Technologies">
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
using Zeroit.Framework.Utilities.Win32;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing.GDI
{
    /// <summary>
    /// Class GDIFont.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.Drawing.GDI.GDIObject" />
    public class GDIFont : GDIObject
	{
        /// <summary>
        /// The bold
        /// </summary>
        public bool Bold;
        /// <summary>
        /// The italic
        /// </summary>
        public bool Italic;
        /// <summary>
        /// The underline
        /// </summary>
        public bool Underline;
        /// <summary>
        /// The strikethrough
        /// </summary>
        public bool Strikethrough;
        /// <summary>
        /// The size
        /// </summary>
        public float Size;
        /// <summary>
        /// The font name
        /// </summary>
        public string FontName;
        /// <summary>
        /// The charset
        /// </summary>
        public byte Charset;
        /// <summary>
        /// The h font
        /// </summary>
        public IntPtr hFont;


        /// <summary>
        /// Initializes a new instance of the <see cref="GDIFont"/> class.
        /// </summary>
        public GDIFont()
		{
			Create();
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="GDIFont"/> class.
        /// </summary>
        /// <param name="fontname">The fontname.</param>
        /// <param name="size">The size.</param>
        public GDIFont(string fontname, float size)
		{
			Init(fontname, size, false, false, false, false);
			Create();
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="GDIFont"/> class.
        /// </summary>
        /// <param name="fontname">The fontname.</param>
        /// <param name="size">The size.</param>
        /// <param name="bold">if set to <c>true</c> [bold].</param>
        /// <param name="italic">if set to <c>true</c> [italic].</param>
        /// <param name="underline">if set to <c>true</c> [underline].</param>
        /// <param name="strikethrough">if set to <c>true</c> [strikethrough].</param>
        public GDIFont(string fontname, float size, bool bold, bool italic, bool underline, bool strikethrough)
		{
			Init(fontname, size, bold, italic, underline, strikethrough);
			Create();
		}

        /// <summary>
        /// Initializes the specified fontname.
        /// </summary>
        /// <param name="fontname">The fontname.</param>
        /// <param name="size">The size.</param>
        /// <param name="bold">if set to <c>true</c> [bold].</param>
        /// <param name="italic">if set to <c>true</c> [italic].</param>
        /// <param name="underline">if set to <c>true</c> [underline].</param>
        /// <param name="strikethrough">if set to <c>true</c> [strikethrough].</param>
        protected void Init(string fontname, float size, bool bold, bool italic, bool underline, bool strikethrough)
		{
			FontName = fontname;
			Size = size;
			Bold = bold;
			Italic = italic;
			Underline = underline;
			Strikethrough = strikethrough;

			LogFont tFont = new LogFont();
			tFont.lfItalic = (byte) (this.Italic ? 1 : 0);
			tFont.lfStrikeOut = (byte) (this.Strikethrough ? 1 : 0);
			tFont.lfUnderline = (byte) (this.Underline ? 1 : 0);
			tFont.lfWeight = this.Bold ? 700 : 400;
			tFont.lfWidth = 0;
			tFont.lfHeight = (int) (-this.Size*1.3333333333333);
			tFont.lfCharSet = 1;

			tFont.lfFaceName = this.FontName;


            hFont = NativeGdi32Api.CreateFontIndirect(tFont);
		}

        /// <summary>
        /// Finalizes an instance of the <see cref="GDIFont"/> class.
        /// </summary>
        ~GDIFont()
		{
			Destroy();
		}

        /// <summary>
        /// Destroys this instance.
        /// </summary>
        protected override void Destroy()
		{
			if (hFont != (IntPtr) 0)
				NativeGdi32Api.DeleteObject(hFont);
			base.Destroy();
			hFont = (IntPtr) 0;
		}

        /// <summary>
        /// Creates this instance.
        /// </summary>
        protected override void Create()
		{
			base.Create();
		}

	}
}