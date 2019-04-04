// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DropShadowPanel.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Controls
{
    /// <summary>
    /// Class DropShadowPanel.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Panel" />
    public abstract class DropShadowPanel : Panel
    {
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.ControlAdded" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ControlEventArgs" /> that contains the event data.</param>
        protected override void OnControlAdded(ControlEventArgs e)
        {
            e.Control.Paint += new PaintEventHandler(Control_Paint);
            base.OnControlAdded(e);
        }

        /// <summary>
        /// Handles the Paint event of the Control control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        void Control_Paint(object sender, PaintEventArgs e)
        {
            CheckDrawInnerShadow(sender as Control, e.Graphics);
        }

        /// <summary>
        /// Checks the draw inner shadow.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="g">The g.</param>
        private void CheckDrawInnerShadow(Control sender, Graphics g)
        {
            var dropShadowStruct = GetDropShadowStruct(sender);

            if (dropShadowStruct == null || !dropShadowStruct.Inset)
            {
                return;
            }

            DrawInsetShadow(sender as Control, g);

        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.ControlRemoved" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ControlEventArgs" /> that contains the event data.</param>
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            e.Control.Paint -= new PaintEventHandler(Control_Paint);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawShadow(Controls.OfType<Control>().Where(c => c.Tag != null && c.Tag.ToString().StartsWith("DropShadow")), e.Graphics);
        }

        /// <summary>
        /// Draws the inset shadow.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="g">The g.</param>
        void DrawInsetShadow(Control control, Graphics g)
        {
            var dropShadowStruct = GetDropShadowStruct(control);

            var rInner = new Rectangle(Point.Empty, control.Size);

            var img = new Bitmap(rInner.Width, rInner.Height, g);
            var g2 = Graphics.FromImage(img);

            g2.CompositingMode = CompositingMode.SourceCopy;
            g2.FillRectangle(new SolidBrush(dropShadowStruct.Color), 0, 0, control.Width, control.Height);

            rInner.Offset(dropShadowStruct.HShadow, dropShadowStruct.VShadow);
            rInner.Inflate(dropShadowStruct.Blur, dropShadowStruct.Blur);
            rInner.Inflate(-dropShadowStruct.Spread, -dropShadowStruct.Spread);

            double blurSize = dropShadowStruct.Blur;
            double blurStartSize = blurSize;

            do
            {
                var transparency = blurSize / blurStartSize;
                var color = Color.FromArgb(((int)(255 * (transparency * transparency))), dropShadowStruct.Color);
                rInner.Inflate(-1, -1);
                DrawRoundedRectangle(g2, rInner, (int)blurSize, Pens.Transparent, color);
                blurSize--;
            } while (blurSize > 0);

            g.DrawImage(img, 0, 0);
            g.Flush();

            g2.Dispose();
            img.Dispose();
        }

        /// <summary>
        /// Draws the shadow.
        /// </summary>
        /// <param name="controls">The controls.</param>
        /// <param name="g">The g.</param>
        void DrawShadow(IEnumerable<Control> controls, Graphics g)
        {
            foreach (var control in controls)
            {
                var dropShadowStruct = GetDropShadowStruct(control);

                if (dropShadowStruct.Inset)
                {
                    continue; // must be handled by the control itself
                }

                DrawOutsetShadow(g, dropShadowStruct, control);
            }
        }

        // drawing the loop on an image because of speed
        /// <summary>
        /// Draws the outset shadow.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="dropShadowStruct">The drop shadow structure.</param>
        /// <param name="control">The control.</param>
        private void DrawOutsetShadow(Graphics g, dynamic dropShadowStruct, Control control)
        {
            var rOuter = control.Bounds;
            var rInner = control.Bounds;
            rInner.Offset(dropShadowStruct.HShadow, dropShadowStruct.VShadow);
            rInner.Inflate(-dropShadowStruct.Blur, -dropShadowStruct.Blur);
            rOuter.Inflate(dropShadowStruct.Spread, dropShadowStruct.Spread);
            rOuter.Offset(dropShadowStruct.HShadow, dropShadowStruct.VShadow);
            var originalOuter = rOuter;

            var img = new Bitmap(originalOuter.Width, originalOuter.Height, g);
            var g2 = Graphics.FromImage(img);

            var currentBlur = 0;

            do
            {
                var transparency = (rOuter.Height - rInner.Height) / (double)(dropShadowStruct.Blur * 2 + dropShadowStruct.Spread * 2);
                var color = Color.FromArgb(((int)(255 * (transparency * transparency))), dropShadowStruct.Color);
                var rOutput = rInner;
                rOutput.Offset(-originalOuter.Left, -originalOuter.Top);
                DrawRoundedRectangle(g2, rOutput, currentBlur, Pens.Transparent, color);
                rInner.Inflate(1, 1);
                currentBlur = (int)((double)dropShadowStruct.Blur * (1 - (transparency * transparency)));
            } while (rOuter.Contains(rInner));

            g2.Flush();
            g2.Dispose();

            g.DrawImage(img, originalOuter);

            img.Dispose();
        }

        /// <summary>
        /// Gets the drop shadow structure.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns>dynamic.</returns>
        private static dynamic GetDropShadowStruct(Control control)
        {
            if (control.Tag == null || !(control.Tag is string) || !control.Tag.ToString().StartsWith("DropShadow"))
                return null;

            string[] dropShadowParams = control.Tag.ToString().Split(':')[1].Split(',');
            var dropShadowStruct = new
            {
                HShadow = Convert.ToInt32(dropShadowParams[0]),
                VShadow = Convert.ToInt32(dropShadowParams[1]),
                Blur = Convert.ToInt32(dropShadowParams[2]),
                Spread = Convert.ToInt32(dropShadowParams[3]),
                Color = ColorTranslator.FromHtml(dropShadowParams[4]),
                Inset = dropShadowParams[5].ToLowerInvariant() == "inset"
            };
            return dropShadowStruct;
        }

        /// <summary>
        /// Draws the rounded rectangle.
        /// </summary>
        /// <param name="gfx">The GFX.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="cornerRadius">The corner radius.</param>
        /// <param name="drawPen">The draw pen.</param>
        /// <param name="fillColor">Color of the fill.</param>
        private void DrawRoundedRectangle(Graphics gfx, Rectangle bounds, int cornerRadius, Pen drawPen, Color fillColor)
        {
            int strokeOffset = Convert.ToInt32(Math.Ceiling(drawPen.Width));
            bounds = Rectangle.Inflate(bounds, -strokeOffset, -strokeOffset);

            var gfxPath = new GraphicsPath();
            if (cornerRadius > 0)
            {
                gfxPath.AddArc(bounds.X, bounds.Y, cornerRadius, cornerRadius, 180, 90);
                gfxPath.AddArc(bounds.X + bounds.Width - cornerRadius, bounds.Y, cornerRadius, cornerRadius, 270, 90);
                gfxPath.AddArc(bounds.X + bounds.Width - cornerRadius, bounds.Y + bounds.Height - cornerRadius, cornerRadius,
                               cornerRadius, 0, 90);
                gfxPath.AddArc(bounds.X, bounds.Y + bounds.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            }
            else
            {
                gfxPath.AddRectangle(bounds);
            }
            gfxPath.CloseAllFigures();

            gfx.FillPath(new SolidBrush(fillColor), gfxPath);
            if (drawPen != Pens.Transparent)
            {
                var pen = new Pen(drawPen.Color);
                pen.EndCap = pen.StartCap = LineCap.Round;
                gfx.DrawPath(pen, gfxPath);
            }
        }
    }

}
