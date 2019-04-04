// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="SimpleToolTip.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.Utilities.ToolTip
{
    /// <summary>
    /// A very simple ToolTip wrapper to display tooltips in a more modern fashion.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ToolTip" />
    [ToolboxItem(false)]
    public class SimpleToolTip : System.Windows.Forms.ToolTip
    {
        /// <summary>
        /// The constructor.
        /// </summary>
        public SimpleToolTip()
        {
            InitialDelay = 1000;
            BackColor = Color.Black;
            ForeColor = Color.White;
            UseFading = true;
            UseAnimation = true;
            OwnerDraw = true;
            AutomaticDelay = 500;
            AutoPopDelay = 2000;
            Draw += new DrawToolTipEventHandler(Paint);
        }

        /// <summary>
        /// Paints the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DrawToolTipEventArgs"/> instance containing the event data.</param>
        void Paint(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawText();
        }
    }
}
