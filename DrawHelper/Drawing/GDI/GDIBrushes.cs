// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="GDIBrushes.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using Zeroit.Framework.Utilities.Win32;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing.GDI
{
    //wrapper class for gdi brushes
    /// <summary>
    /// Class GDIBrush.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.Drawing.GDI.GDIObject" />
    public class GDIBrush : GDIObject
	{
        /// <summary>
        /// The h brush
        /// </summary>
        public IntPtr hBrush;
        /// <summary>
        /// The m system brush
        /// </summary>
        protected bool mSystemBrush;

        /// <summary>
        /// Initializes a new instance of the <see cref="GDIBrush"/> class.
        /// </summary>
        /// <param name="color">The color.</param>
        public GDIBrush(Color color)
		{
            hBrush = NativeGdi32Api.CreateSolidBrush(NativeUser32Api.ColorToInt(color));
			Create();
		}


        /// <summary>
        /// Initializes a new instance of the <see cref="GDIBrush"/> class.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        public GDIBrush(Bitmap pattern)
		{
            hBrush = NativeGdi32Api.CreatePatternBrush(pattern.GetHbitmap());
			Create();
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="GDIBrush"/> class.
        /// </summary>
        /// <param name="hBMP_Pattern">The h BMP pattern.</param>
        public GDIBrush(IntPtr hBMP_Pattern)
		{
            hBrush = NativeGdi32Api.CreatePatternBrush(hBMP_Pattern);
			//if (hBrush==(IntPtr)0)
			//Puzzle.Debug.Debugger.WriteLine ("Failed to create brush with color : {0}",color.ToString());

			Create();
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="GDIBrush"/> class.
        /// </summary>
        /// <param name="Style">The style.</param>
        /// <param name="color">The color.</param>
        public GDIBrush(int Style, Color color)
		{
            hBrush = NativeGdi32Api.CreateHatchBrush(Style, NativeUser32Api.ColorToInt(color));
			Create();
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="GDIBrush"/> class.
        /// </summary>
        /// <param name="BrushIndex">Index of the brush.</param>
        public GDIBrush(int BrushIndex)
		{
			hBrush = (IntPtr) BrushIndex;
			mSystemBrush = true;
			Create();
		}

        /// <summary>
        /// Destroys this instance.
        /// </summary>
        protected override void Destroy()
		{
			//only destroy if brush is created by us
			if (!mSystemBrush)
			{
				if (hBrush != (IntPtr) 0)
                    NativeGdi32Api.DeleteObject(hBrush);
			}

			base.Destroy();
			hBrush = (IntPtr) 0;
		}

        /// <summary>
        /// Creates this instance.
        /// </summary>
        protected override void Create()
		{
			base.Create();
		}


	}


    //needs to be recoded , cant create new instances for the same colors
    /// <summary>
    /// Class GDIBrushes.
    /// </summary>
    public class GDIBrushes
	{
        /// <summary>
        /// Gets the black.
        /// </summary>
        /// <value>The black.</value>
        public static GDIBrush Black
		{
			get { return new GDIBrush(0); }
		}

        /// <summary>
        /// Gets the white.
        /// </summary>
        /// <value>The white.</value>
        public static GDIBrush White
		{
			get { return new GDIBrush(0); }
		}

        /// <summary>
        /// Gets the red.
        /// </summary>
        /// <value>The red.</value>
        public static GDIBrush Red
		{
			get { return new GDIBrush(0); }
		}

        /// <summary>
        /// Gets the cyan.
        /// </summary>
        /// <value>The cyan.</value>
        public static GDIBrush Cyan
		{
			get { return new GDIBrush(0); }
		}

        /// <summary>
        /// Gets the green.
        /// </summary>
        /// <value>The green.</value>
        public static GDIBrush Green
		{
			get { return new GDIBrush(0); }
		}

        /// <summary>
        /// Gets the blue.
        /// </summary>
        /// <value>The blue.</value>
        public static GDIBrush Blue
		{
			get { return new GDIBrush(0); }
		}

        /// <summary>
        /// Gets the yellow.
        /// </summary>
        /// <value>The yellow.</value>
        public static GDIBrush Yellow
		{
			get { return new GDIBrush(0); }
		}

        /// <summary>
        /// Gets the orange.
        /// </summary>
        /// <value>The orange.</value>
        public static GDIBrush Orange
		{
			get { return new GDIBrush(0); }
		}

        /// <summary>
        /// Gets the purple.
        /// </summary>
        /// <value>The purple.</value>
        public static GDIBrush Purple
		{
			get { return new GDIBrush(0); }
		}
	}

    /// <summary>
    /// Class GDISystemBrushes.
    /// </summary>
    public class GDISystemBrushes
	{
        /// <summary>
        /// Gets the active border.
        /// </summary>
        /// <value>The active border.</value>
        public static GDIBrush ActiveBorder
		{
			get { return new GDIBrush(0); }
		}

        /// <summary>
        /// Gets the active caption.
        /// </summary>
        /// <value>The active caption.</value>
        public static GDIBrush ActiveCaption
		{
			get { return new GDIBrush(0); }
		}

        /// <summary>
        /// Gets the active caption text.
        /// </summary>
        /// <value>The active caption text.</value>
        public static GDIBrush ActiveCaptionText
		{
			get { return new GDIBrush(0); }
		}

        /// <summary>
        /// Gets the application workspace.
        /// </summary>
        /// <value>The application workspace.</value>
        public static GDIBrush AppWorkspace
		{
			get { return new GDIBrush(0); }
		}

        /// <summary>
        /// Gets the control.
        /// </summary>
        /// <value>The control.</value>
        public static GDIBrush Control
		{
			get { return new GDIBrush(0); }
		}

        /// <summary>
        /// Gets the control dark.
        /// </summary>
        /// <value>The control dark.</value>
        public static GDIBrush ControlDark
		{
			get { return new GDIBrush(0); }
		}

        /// <summary>
        /// Gets the control dark dark.
        /// </summary>
        /// <value>The control dark dark.</value>
        public static GDIBrush ControlDarkDark
		{
			get { return new GDIBrush(0); }
		}

        /// <summary>
        /// Gets the control light.
        /// </summary>
        /// <value>The control light.</value>
        public static GDIBrush ControlLight
		{
			get { return new GDIBrush(0); }
		}

        /// <summary>
        /// Gets the control light light.
        /// </summary>
        /// <value>The control light light.</value>
        public static GDIBrush ControlLightLight
		{
			get { return new GDIBrush(0); }
		}

        /// <summary>
        /// Gets the control text.
        /// </summary>
        /// <value>The control text.</value>
        public static GDIBrush ControlText
		{
			get { return new GDIBrush(0); }
		}

        /// <summary>
        /// Gets the desktop.
        /// </summary>
        /// <value>The desktop.</value>
        public static GDIBrush Desktop
		{
			get { return new GDIBrush(0); }
		}

        /// <summary>
        /// Gets the highlight.
        /// </summary>
        /// <value>The highlight.</value>
        public static GDIBrush Highlight
		{
			get { return new GDIBrush(0); }
		}

        /// <summary>
        /// Gets the highlight text.
        /// </summary>
        /// <value>The highlight text.</value>
        public static GDIBrush HighlightText
		{
			get { return new GDIBrush(0); }
		}

        /// <summary>
        /// Gets the hot track.
        /// </summary>
        /// <value>The hot track.</value>
        public static GDIBrush HotTrack
		{
			get { return new GDIBrush(0); }
		}

        /// <summary>
        /// Gets the inactive border.
        /// </summary>
        /// <value>The inactive border.</value>
        public static GDIBrush InactiveBorder
		{
			get { return new GDIBrush(0); }
		}

        /// <summary>
        /// Gets the inactive caption.
        /// </summary>
        /// <value>The inactive caption.</value>
        public static GDIBrush InactiveCaption
		{
			get { return new GDIBrush(0); }
		}

        /// <summary>
        /// Gets the information.
        /// </summary>
        /// <value>The information.</value>
        public static GDIBrush Info
		{
			get { return new GDIBrush(0); }
		}

        /// <summary>
        /// Gets the menu.
        /// </summary>
        /// <value>The menu.</value>
        public static GDIBrush Menu
		{
			get { return new GDIBrush(0); }
		}

        /// <summary>
        /// Gets the scroll bar.
        /// </summary>
        /// <value>The scroll bar.</value>
        public static GDIBrush ScrollBar
		{
			get { return new GDIBrush(0); }
		}

        /// <summary>
        /// Gets the window.
        /// </summary>
        /// <value>The window.</value>
        public static GDIBrush Window
		{
			get { return new GDIBrush(0); }
		}

        /// <summary>
        /// Gets the window text.
        /// </summary>
        /// <value>The window text.</value>
        public static GDIBrush WindowText
		{
			get { return new GDIBrush(0); }
		}
	}
}