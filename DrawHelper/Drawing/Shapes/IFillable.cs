// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="IFillable.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Drawing;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes
{

    /// <summary>
    /// Interface IFillable
    /// </summary>
    public interface IFillable  
	{

        /// <summary>
        /// Gets or sets the brush.
        /// </summary>
        /// <value>The brush.</value>
        Brush Brush {get;set;}
        /// <summary>
        /// Fills the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        void Fill(Graphics graphics);

	}
}