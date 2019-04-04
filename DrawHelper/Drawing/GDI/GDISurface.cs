// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="GDISurface.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Drawing;
using System.Windows.Forms;
using Zeroit.Framework.Utilities.Win32;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing.GDI
{
    /// <summary>
    /// Class GDISurface.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.Drawing.GDI.GDIObject" />
    public class GDISurface : GDIObject
	{
        /// <summary>
        /// The mh dc
        /// </summary>
        protected IntPtr mhDC;
        /// <summary>
        /// The mh BMP
        /// </summary>
        protected IntPtr mhBMP;
        /// <summary>
        /// The m width
        /// </summary>
        protected int mWidth;
        /// <summary>
        /// The m height
        /// </summary>
        protected int mHeight;
        /// <summary>
        /// The m tab size
        /// </summary>
        protected int mTabSize = 4;
        /// <summary>
        /// The old font
        /// </summary>
        protected IntPtr _OldFont = IntPtr.Zero;
        /// <summary>
        /// The old pen
        /// </summary>
        protected IntPtr _OldPen = IntPtr.Zero;
        /// <summary>
        /// The old brush
        /// </summary>
        protected IntPtr _OldBrush = IntPtr.Zero;
        /// <summary>
        /// The old BMP
        /// </summary>
        protected IntPtr _OldBmp = IntPtr.Zero;


        /// <summary>
        /// The control
        /// </summary>
        private WeakReference _Control = null;

        /// <summary>
        /// Gets or sets the control.
        /// </summary>
        /// <value>The control.</value>
        private Control Control
		{
			get
			{
				if (_Control != null)
					return (Control) _Control.Target;
				else
					return null;
			}
			set { _Control = new WeakReference(value); }
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="GDISurface"/> class.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        public GDISurface(IntPtr hDC)
		{
			mhDC = hDC;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="GDISurface"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public GDISurface(int width, int height)
		{
            // added: 31/01/06
			//TODO: test it
            IntPtr deskDC = NativeUser32Api.GetDC(new IntPtr(0));
            Init(width, height, deskDC);
            Create();
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="GDISurface"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="hdc">The HDC.</param>
        public GDISurface(int width, int height, IntPtr hdc)
		{
			Init(width, height, hdc);
			Create();
		}

        /// <summary>
        /// Initializes the specified width.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="hdc">The HDC.</param>
        protected void Init(int width, int height, IntPtr hdc)
		{
			mWidth = width;
			mHeight = height;
            mhDC = NativeGdi32Api.CreateCompatibleDC(hdc);

            mhBMP = NativeGdi32Api.CreateCompatibleBitmap(hdc, width, height);

            IntPtr ret = NativeGdi32Api.SelectObject(mhDC, mhBMP);
			_OldBmp = ret;

			if (mhDC == (IntPtr) 0)
				MessageBox.Show("hDC creation FAILED!!");

			if (mhDC == (IntPtr) 0)
				MessageBox.Show("hBMP creation FAILED!!");


		}

        /// <summary>
        /// Initializes a new instance of the <see cref="GDISurface"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="surface">The surface.</param>
        public GDISurface(int width, int height, GDISurface surface)
		{
			Init(width, height, surface.hDC);
			Create();
		}


        /// <summary>
        /// Initializes a new instance of the <see cref="GDISurface"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="compatibleControl">The compatible control.</param>
        /// <param name="bindControl">if set to <c>true</c> [bind control].</param>
        public GDISurface(int width, int height, Control compatibleControl, bool bindControl)
		{
            IntPtr hDCControk = NativeUser32Api.ControlDC(compatibleControl);
			Init(width, height, hDCControk);
            NativeUser32Api.ReleaseDC(compatibleControl.Handle, hDCControk);

			if (bindControl)
			{
				Control = compatibleControl;
			}
			else
			{
			}

			Create();
		}


        /// <summary>
        /// Gets the h dc.
        /// </summary>
        /// <value>The h dc.</value>
        public IntPtr hDC
		{
			get { return mhDC; }
		}

        /// <summary>
        /// Gets the h BMP.
        /// </summary>
        /// <value>The h BMP.</value>
        public IntPtr hBMP
		{
			get { return mhBMP; }
		}

        /// <summary>
        /// Gets or sets the color of the text fore.
        /// </summary>
        /// <value>The color of the text fore.</value>
        public Color TextForeColor
		{
			//map get,settextcolor
            get { return NativeUser32Api.IntToColor(NativeGdi32Api.GetTextColor(mhDC)); }
            set { NativeGdi32Api.SetTextColor(mhDC, NativeUser32Api.ColorToInt(value)); }
		}

        /// <summary>
        /// Gets or sets the color of the text back.
        /// </summary>
        /// <value>The color of the text back.</value>
        public Color TextBackColor
		{
			//map get,setbkcolor
            get { return NativeUser32Api.IntToColor(NativeGdi32Api.GetBkColor(mhDC)); }
            set { NativeGdi32Api.SetBkColor(mhDC, NativeUser32Api.ColorToInt(value)); }
		}


        /// <summary>
        /// Gets or sets a value indicating whether [font transparent].
        /// </summary>
        /// <value><c>true</c> if [font transparent]; otherwise, <c>false</c>.</value>
        public bool FontTransparent
		{
			//map get,setbkmode
			//1=transparent , 2=solid
            get { return NativeGdi32Api.GetBkMode(mhDC) < 2; }
            set { NativeGdi32Api.SetBkMode(mhDC, value ? 1 : 2); }
		}


        /// <summary>
        /// Measures the string.
        /// </summary>
        /// <param name="Text">The text.</param>
        /// <returns>Size.</returns>
        public Size MeasureString(string Text)
		{
			//map GetTabbedTextExtent
			//to be implemented
			return new Size(0, 0);
		}

        /// <summary>
        /// Measures the tabbed string.
        /// </summary>
        /// <param name="Text">The text.</param>
        /// <param name="tabsize">The tabsize.</param>
        /// <returns>Size.</returns>
        public Size MeasureTabbedString(string Text, int tabsize)
		{
            uint ret = NativeUser32Api.GetTabbedTextExtent(mhDC, Text, Text.Length, 1, ref tabsize);
			return new Size((int)(ret & 0xFFFF), (int)((ret >> 16) & 0xFFFF));
		}

        /// <summary>
        /// Draws the string.
        /// </summary>
        /// <param name="Text">The text.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public void DrawString(string Text, int x, int y, int width, int height)
		{
			//to be implemented
			//map DrawText

		}

        /// <summary>
        /// Draws the tabbed string.
        /// </summary>
        /// <param name="Text">The text.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="taborigin">The taborigin.</param>
        /// <param name="tabsize">The tabsize.</param>
        /// <returns>Size.</returns>
        public Size DrawTabbedString(string Text, int x, int y, int taborigin, int tabsize)
		{
            int ret = NativeUser32Api.TabbedTextOut(mhDC, x, y, Text, Text.Length, 1, ref tabsize, taborigin);
			return new Size(ret & 0xFFFF, (ret >> 16) & 0xFFFF);
		}


        //---------------------------------------
        //render methods , 
        //render to dc ,
        //render to control
        //render to gdisurface

        /// <summary>
        /// Renders to.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public void RenderTo(IntPtr hdc, int x, int y)
		{
            NativeGdi32Api.BitBlt(hdc, x, y, mWidth, mHeight, mhDC, 0, 0, (int) GDIRop.SrcCopy);
		}


        /// <summary>
        /// Renders to.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public void RenderTo(GDISurface target, int x, int y)
		{
			RenderTo(target.hDC, x, y);
		}

        /// <summary>
        /// Renders to.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="SourceX">The source x.</param>
        /// <param name="SourceY">The source y.</param>
        /// <param name="Width">The width.</param>
        /// <param name="Height">The height.</param>
        /// <param name="DestX">The dest x.</param>
        /// <param name="DestY">The dest y.</param>
        public void RenderTo(GDISurface target, int SourceX, int SourceY, int Width, int Height, int DestX, int DestY)
		{
            NativeGdi32Api.BitBlt(target.hDC, DestX, DestY, Width, Height, this.hDC, SourceX, SourceY, (int)GDIRop.SrcCopy);
		}

        /// <summary>
        /// Renders to control.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public void RenderToControl(int x, int y)
		{
            IntPtr hdc = NativeUser32Api.ControlDC(Control);

			RenderTo(hdc, x, y);
            NativeUser32Api.ReleaseDC(Control.Handle, hdc);
		}

        //---------------------------------------

        /// <summary>
        /// Creates the graphics.
        /// </summary>
        /// <returns>Graphics.</returns>
        public Graphics CreateGraphics()
		{
			return Graphics.FromHdc(mhDC);
		}

        //---------------------------------------

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>The font.</value>
        public GDIFont Font
		{
			get
			{
				GDITextMetric tm = new GDITextMetric();
				string fontname = "                                                ";

                NativeGdi32Api.GetTextMetrics(mhDC, ref tm);
                NativeGdi32Api.GetTextFace(mhDC, 79, fontname);

				GDIFont gf = new GDIFont();
				gf.FontName = fontname;
				gf.Bold = (tm.tmWeight > 400); //400=fw_normal
				gf.Italic = (tm.tmItalic != 0);
				gf.Underline = (tm.tmUnderlined != 0);
				gf.Strikethrough = (tm.tmStruckOut != 0);

				gf.Size = (int) (((double) (tm.tmMemoryHeight)/(double) tm.tmDigitizedAspectY)*72);
				return gf;
			}
			set
			{
                IntPtr res = NativeGdi32Api.SelectObject(mhDC, value.hFont);
				if (_OldFont == IntPtr.Zero)
					_OldFont = res;
			}
		}

        /// <summary>
        /// Fills the rect.
        /// </summary>
        /// <param name="brush">The brush.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public void FillRect(GDIBrush brush, int x, int y, int width, int height)
		{
            RECTAPI gr;
			gr.Top = y;
			gr.Left = x;
			gr.Right = width + x;
			gr.Bottom = height + y;

            NativeUser32Api.FillRect(mhDC, ref gr, brush.hBrush);
		}

        /// <summary>
        /// Draws the focus rect.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public void DrawFocusRect(int x, int y, int width, int height)
		{
            RECTAPI gr;
			gr.Top = y;
			gr.Left = x;
			gr.Right = width + x;
			gr.Bottom = height + y;

            NativeUser32Api.DrawFocusRect(mhDC, ref gr);
		}

        /// <summary>
        /// Fills the rect.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public void FillRect(Color color, int x, int y, int width, int height)
		{
			GDIBrush b = new GDIBrush(color);
			FillRect(b, x, y, width, height);
			b.Dispose();
		}

        /// <summary>
        /// Inverts the rect.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public void InvertRect(int x, int y, int width, int height)
		{
            RECTAPI gr;
			gr.Top = y;
			gr.Left = x;
			gr.Right = width + x;
			gr.Bottom = height + y;

            NativeUser32Api.InvertRect(mhDC, ref gr);
		}

        /// <summary>
        /// Draws the line.
        /// </summary>
        /// <param name="pen">The pen.</param>
        /// <param name="p1">The p1.</param>
        /// <param name="p2">The p2.</param>
        public void DrawLine(GDIPen pen, Point p1, Point p2)
		{
            IntPtr oldpen = NativeGdi32Api.SelectObject(mhDC, pen.hPen);
			POINTAPI gp;
			gp.X = 0;
			gp.Y = 0;
            NativeGdi32Api.MoveToEx(mhDC, p1.X, p1.Y, ref gp);
            NativeGdi32Api.LineTo(mhDC, p2.X, p2.Y);
            IntPtr crap = NativeGdi32Api.SelectObject(mhDC, oldpen);
		}

        /// <summary>
        /// Draws the line.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="p1">The p1.</param>
        /// <param name="p2">The p2.</param>
        public void DrawLine(Color color, Point p1, Point p2)
		{
			GDIPen p = new GDIPen(color, 1);
			DrawLine(p, p1, p2);
			p.Dispose();
		}

        /// <summary>
        /// Draws the rect.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public void DrawRect(Color color, int left, int top, int width, int height)
		{
			GDIPen p = new GDIPen(color, 1);
			this.DrawRect(p, left, top, width, height);
			p.Dispose();
		}

        /// <summary>
        /// Draws the rect.
        /// </summary>
        /// <param name="pen">The pen.</param>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public void DrawRect(GDIPen pen, int left, int top, int width, int height)
		{
			this.DrawLine(pen, new Point(left, top), new Point(left + width, top));
			this.DrawLine(pen, new Point(left, top + height), new Point(left + width, top + height));
			this.DrawLine(pen, new Point(left, top), new Point(left, top + height));
			this.DrawLine(pen, new Point(left + width, top), new Point(left + width, top + height + 1));
		}

        /// <summary>
        /// Clears the specified color.
        /// </summary>
        /// <param name="color">The color.</param>
        public void Clear(Color color)
		{
			GDIBrush b = new GDIBrush(color);
			Clear(b);
			b.Dispose();
		}

        /// <summary>
        /// Clears the specified brush.
        /// </summary>
        /// <param name="brush">The brush.</param>
        public void Clear(GDIBrush brush)
		{
			FillRect(brush, 0, 0, mWidth, mHeight);
		}

        /// <summary>
        /// Flushes this instance.
        /// </summary>
        public void Flush()
		{
			NativeGdi32Api.GdiFlush();
		}

        /// <summary>
        /// Destroys this instance.
        /// </summary>
        protected override void Destroy()
		{
			if (_OldBmp != IntPtr.Zero)
                NativeGdi32Api.SelectObject(this.hDC, _OldBmp);

			if (_OldFont != IntPtr.Zero)
                NativeGdi32Api.SelectObject(this.hDC, _OldFont);

			if (_OldPen != IntPtr.Zero)
                NativeGdi32Api.SelectObject(this.hDC, _OldPen);

			if (_OldBrush != IntPtr.Zero)
                NativeGdi32Api.SelectObject(this.hDC, _OldBrush);

			if (mhBMP != (IntPtr) 0)
                NativeGdi32Api.DeleteObject(mhBMP);

			if (mhDC != (IntPtr) 0)
                NativeGdi32Api.DeleteDC(mhDC);

			mhBMP = (IntPtr) 0;
			mhDC = (IntPtr) 0;

			base.Destroy();
		}

        /// <summary>
        /// Sets the brush org.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public void SetBrushOrg(int x, int y)
		{
            POINTAPI p;
			p.X = 0;
			p.Y = 0;
            NativeGdi32Api.SetBrushOrgEx(mhDC, x, y, ref p);
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