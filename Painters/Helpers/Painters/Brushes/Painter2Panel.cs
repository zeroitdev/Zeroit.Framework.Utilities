// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Painter2Panel.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.Brushes
{
    /// <summary>
    /// Represents a control for displaying a <c>BrushPainter2</c> value.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [ToolboxItem(false)]
    public partial class BrushPainter2Panel : UserControl
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public BrushPainter2Panel()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.UserPaint, true);

            this.UpdateStyles();
        }

        /// <summary>
        /// The filler
        /// </summary>
        private BrushPainter2 filler = new BrushPainter2();
        /// <summary>
        /// Gets or sets the simple filler.
        /// </summary>
        /// <value>The simple filler.</value>
        /// <exception cref="ArgumentNullException">BrushPainter</exception>
        public BrushPainter2 BrushPainter
        {
            get { return filler; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("BrushPainter");
                }
                filler = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Handles the Paint event of the this control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void this_Paint(object sender, PaintEventArgs e)
        {
            Brush br = filler.GetBrush(ClientRectangle);
            if (br != null)
            {
                e.Graphics.FillRectangle(br, ClientRectangle);
                br.Dispose();
            }
        }
    }
}
