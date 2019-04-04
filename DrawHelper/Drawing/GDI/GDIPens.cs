// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="GDIPens.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Drawing;
using Zeroit.Framework.Utilities.Win32;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing.GDI
{
    /// <summary>
    /// Class GDIPen.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.Drawing.GDI.GDIObject" />
    public class GDIPen : GDIObject
	{
        /// <summary>
        /// The h pen
        /// </summary>
        public IntPtr hPen;

        /// <summary>
        /// Initializes a new instance of the <see cref="GDIPen"/> class.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="width">The width.</param>
        public GDIPen(Color color, int width)
		{
            hPen = NativeGdi32Api.CreatePen(0, width, NativeUser32Api.ColorToInt(color));
			Create();
		}

        /// <summary>
        /// Destroys this instance.
        /// </summary>
        protected override void Destroy()
		{
			if (hPen != (IntPtr) 0)
                NativeGdi32Api.DeleteObject(hPen);
			base.Destroy();
			hPen = (IntPtr) 0;
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