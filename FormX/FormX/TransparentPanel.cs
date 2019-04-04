// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="TransparentPanel.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel;
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.ControlUtils
{
    /// <summary>
    /// Class TransparentPanel.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Panel" />
    [ToolboxItem(false)]
    public class TransparentPanel : Panel
    {
        /// <summary>
        /// The opacity
        /// </summary>
        double opacity;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransparentPanel"/> class.
        /// </summary>
        public TransparentPanel()
        {
            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
        }

        /// <summary>
        /// Gets the required creation parameters when the control handle is created.
        /// </summary>
        /// <value>The create parameters.</value>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
                return createParams;
            }
        }

        /// <summary>
        /// Paints the background of the control.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Do not paint background.
        }
    }
}
