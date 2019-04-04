// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="PixelBufferRenderer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Drawing;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Drawing2D
{
    /// <summary>
    /// Class PixelBufferRenderer.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public abstract class PixelBufferRenderer:IDisposable
    {
        /// <summary>
        /// Occurs when [render begin].
        /// </summary>
        public abstract event PixelBufferRenderDelegate RenderBegin;
        /// <summary>
        /// Occurs when [render complete].
        /// </summary>
        public abstract event PixelBufferRenderDelegate RenderComplete;

        /// <summary>
        /// The pixel buffer
        /// </summary>
        protected PixelBuffer pixelBuffer;

        /// <summary>
        /// The use transparent background
        /// </summary>
        private bool _useTransparentBackground;
        /// <summary>
        /// The back color
        /// </summary>
        private Color _backColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="PixelBufferRenderer"/> class.
        /// </summary>
        /// <param name="pixelBuffer">The pixel buffer.</param>
        protected PixelBufferRenderer(PixelBuffer pixelBuffer)
        {
            this.pixelBuffer = pixelBuffer;
            _useTransparentBackground = false;
            _backColor = Color.Black;
        }
        /// <summary>
        /// Finalizes an instance of the <see cref="PixelBufferRenderer"/> class.
        /// </summary>
        ~PixelBufferRenderer()
        {
            this.Dispose();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            pixelBuffer = null;
        }

        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>The color of the background.</value>
        public virtual Color BackgroundColor
        {
            get
            {
                return _backColor;
            }
            set
            {
                _backColor = value;
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [use transparent background].
        /// </summary>
        /// <value><c>true</c> if [use transparent background]; otherwise, <c>false</c>.</value>
        public virtual bool UseTransparentBackground
        {
            get
            {
                return _useTransparentBackground;
            }
            set
            {
                _useTransparentBackground = value;
            }
        }

        /// <summary>
        /// Renders the specified render information.
        /// </summary>
        /// <param name="renderInfo">The render information.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public abstract void Render(PixelBufferRenderInfo renderInfo, int x, int y);
        /// <summary>
        /// Renders the specified render information.
        /// </summary>
        /// <param name="renderInfo">The render information.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public abstract void Render(PixelBufferRenderInfo renderInfo, int x, int y, int width, int height);
        /// <summary>
        /// Renders the specified render information.
        /// </summary>
        /// <param name="renderInfo">The render information.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public abstract void Render(PixelBufferRenderInfo renderInfo, float x, float y);
        /// <summary>
        /// Renders the specified render information.
        /// </summary>
        /// <param name="renderInfo">The render information.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public abstract void Render(PixelBufferRenderInfo renderInfo, float x, float y, float width, float height);

    }
}
