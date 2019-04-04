// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="LinePanel.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.PenPainter
{
    /// <summary>
    /// Represents a control for displaying a line.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [ToolboxItem(false)]
    public partial class PenPainterPanel : UserControl
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public PenPainterPanel()
        {
            InitializeComponent();

			this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
						  ControlStyles.AllPaintingInWmPaint |
						  ControlStyles.ResizeRedraw |
						  ControlStyles.UserPaint, true);

			this.UpdateStyles();

			line = new PenPainter();
        }

        /// <summary>
        /// The line
        /// </summary>
        private PenPainter line;
        /// <summary>
        /// Get line displayed in panel.
        /// </summary>
        /// <value>PenPainter displayed in panel.</value>
        public PenPainter PenPainter
		{
			get { return line; }
			set
			{
				line = value;
				Invalidate();
			}
		}

        /// <summary>
        /// The orient
        /// </summary>
        private Orientation orient;
        /// <summary>
        /// Get display orientation of line.
        /// </summary>
        /// <value>Display orientation of line.</value>
        public Orientation Orientation
		{
			get { return orient; }
			set 
			{
				orient = value;
				Invalidate();
			}
		}

        /// <summary>
        /// Handles the Paint event of the PenPainterPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void PenPainterPanel_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = line.GetPen();
			if (orient == Orientation.Horizontal)
			{
	            int y = ClientSize.Height / 2;
    	        e.Graphics.DrawLine(pen, 0, y, ClientSize.Width - 1, y);
			}
			else
			{
				int x = ClientSize.Width / 2;
				e.Graphics.DrawLine(pen, x, 0, x, ClientSize.Height - 1);
			}
        }
    }
}
