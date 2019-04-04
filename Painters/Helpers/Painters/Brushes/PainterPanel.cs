// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="PainterPanel.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.Brushes
{
    /// <summary>
    /// Represents a control for displaying a <c>BrushPainter</c> value.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [ToolboxItem(false)]
    public partial class BrushPainterPanel : UserControl
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public BrushPainterPanel()
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
        private BrushPainter filler = new BrushPainter();
        /// <summary>
        /// Gets or sets the simple filler.
        /// </summary>
        /// <value>The simple filler.</value>
        public BrushPainter BrushPainter
        {
            get { return filler; }
            set
            {
                filler = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Handles the Paint event of the panel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void panel_Paint(object sender, PaintEventArgs e)
        {
        }

        /// <summary>
        /// Handles the Paint event of the this control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void this_Paint(object sender, PaintEventArgs e)
        {
            if (filler != null)
            {
                Brush brush = filler.GetBrush(ClientRectangle);
                if (brush != null)
                {
                    e.Graphics.FillRectangle(brush, ClientRectangle);
                    brush.Dispose();
                }
            }
        }
    }
}
