// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="IDrawable.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes
{
    /// <summary>
    /// IDrawable interface for shapes
    /// </summary>
	public interface IDrawable  
	{

        /// <summary>
        /// Gets or sets the pen.
        /// </summary>
        /// <value>The pen.</value>
        Pen Pen { get;set;}
        /// <summary>
        /// Draws the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        void Draw(Graphics graphics);
        /// <summary>
        /// Draws the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="smoothingMode">The smoothing mode.</param>
        void Draw(Graphics graphics, SmoothingMode smoothingMode);

	}
}