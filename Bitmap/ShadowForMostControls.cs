// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ShadowForMostControls.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.BitmapUtils
{
    /// <summary>
    /// A class to set shadow for most controls Hypothetically.
    /// </summary>
    public class ShadowForMostControls
    {
        /// <summary>
        /// Drop Shadow
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Paint Event Arguments</param>
        public void DropShadowForAllControls_Panel(Panel panel, PaintEventArgs e)
        {
            //Panel panel = (Panel)sender;
            Color[] shadow = new Color[3];
            shadow[0] = Color.FromArgb(181, 181, 181);
            shadow[1] = Color.FromArgb(195, 195, 195);
            shadow[2] = Color.FromArgb(211, 211, 211);
            Pen pen = new Pen(shadow[0]);
            using (pen)
            {
                foreach (Panel p in panel.Controls.OfType<Panel>())
                {
                    Point pt = p.Location;
                    pt.Y += p.Height;
                    for (var sp = 0; sp < 3; sp++)
                    {
                        pen.Color = shadow[sp];
                        e.Graphics.DrawLine(pen, pt.X, pt.Y, pt.X + p.Width - 1, pt.Y);
                        pt.Y++;
                    }
                }
            }
        }
        

    }
}
