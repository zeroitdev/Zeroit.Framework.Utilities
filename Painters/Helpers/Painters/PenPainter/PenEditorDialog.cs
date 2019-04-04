// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="PenEditorDialog.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.PenPainter
{
    /// <summary>
    /// Implements a dialog which allows design and editing of a <c>PenPainter</c> object.
    /// May be used in designer.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class PenPainterEditorDialog : System.Windows.Forms.Form
    {
        /// <summary>
        /// Initializes a new instance of <c>PenPainterEditorDialog</c> with a default <c>PenPainter</c>
        /// and default window position.
        /// </summary>
        public PenPainterEditorDialog() : this((PenPainter)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of <c>PenPainterEditorDialog</c> using an existing <c>PenPainter</c>
        /// and default window position.
        /// </summary>
        /// <param name="line">Existing <c>PenPainter</c>.</param>
        public PenPainterEditorDialog(PenPainter line)
        {
            InitializeComponent();
            SetPenPainter(line);
            ShowPenPainter();
        }

        /// <summary>
        /// Initializes a new instance of <c>PenPainterEditorDialog</c> with a default <c>PenPainter</c>
        /// and starting beneath a specified control.
        /// </summary>
        /// <param name="c">Control beneath which the dialog should be placed.</param>
		public PenPainterEditorDialog(Control c) : this(null, c)
        {
        }

        /// <summary>
        /// Initializes a new instance of <c>PenPainterEditorDialog</c> using an existing <c>PenPainter</c>
        /// and starting beneath a specified control.
        /// </summary>
        /// <param name="line">Existing <c>PenPainter</c>.</param>
        /// <param name="c">Control beneath which the dialog should be placed.</param>
		public PenPainterEditorDialog(PenPainter line, Control c)
        {
            InitializeComponent();
            Utils.SetStartPositionBelowControl(this, c);
            SetPenPainter(line);
        }

        /// <summary>
        /// Sets the pen painter.
        /// </summary>
        /// <param name="line">The line.</param>
        private void SetPenPainter(PenPainter line)
        {
            if (line == null)
            {
                line = new PenPainter();
            }
            colorLabel.BackColor = Color.FromArgb(255, line.Color);
            alphaNud.Value = (decimal)line.Color.A;
            dashStyleComboBox.SelectedDashStyle = line.DashStyle;
            widthNud.Value = (decimal)line.Width;
            ShowPenPainter();
        }

        /// <summary>
        /// Gets the line selected by the user.
        /// </summary>
        /// <value>The line selected by the user.</value>
		public PenPainter PenPainter
        {
            get
            {
                return new PenPainter(Color.FromArgb((int)alphaNud.Value, colorLabel.BackColor),
                                (float)widthNud.Value,
                                dashStyleComboBox.SelectedDashStyle);
            }
        }

        /// <summary>
        /// Shows the pen painter.
        /// </summary>
        private void ShowPenPainter()
        {
            PenPainter line = PenPainter;
            linePanel1.PenPainter = line;
            linePanel2.PenPainter = line;
        }

        /// <summary>
        /// Handles the Click event of the okButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

        }

        /// <summary>
        /// Handles the Click event of the cancelButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Handles the Click event of the colorButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void colorButton_Click(object sender, EventArgs e)
        {
            ComboColorPickerDialog d = new ComboColorPickerDialog(colorLabel.BackColor, colorButton);
            if (d.ShowDialog() == DialogResult.OK)
            {
                colorLabel.BackColor = d.Color;
                ShowPenPainter();
            }
        }

        /// <summary>
        /// Handles the SelectedValueChanged event of the dashStyleComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void dashStyleComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ShowPenPainter();
        }

        /// <summary>
        /// Handles the ValueChanged event of the widthNud control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void widthNud_ValueChanged(object sender, EventArgs e)
        {
            ShowPenPainter();
        }

        /// <summary>
        /// Handles the ValueChanged event of the alphaNud control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void alphaNud_ValueChanged(object sender, EventArgs e)
        {
            ShowPenPainter();
        }

        /// <summary>
        /// Handles the MouseEnter event of the colorButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void colorButton_MouseEnter(object sender, EventArgs e)
        {
            colorButton.FlatAppearance.BorderColor = Color.FromArgb(128, 255, 255);
        }

        /// <summary>
        /// Handles the MouseLeave event of the colorButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void colorButton_MouseLeave(object sender, EventArgs e)
        {
            colorButton.FlatAppearance.BorderColor = Color.FromArgb(56, 56, 56);
        }

        /// <summary>
        /// Handles the Click event of the closeBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the MouseEnter event of the CloseBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CloseBtn_MouseEnter(object sender, EventArgs e)
        {
            CloseBtn.BackColor = Color.Red;
        }

        /// <summary>
        /// Handles the MouseLeave event of the CloseBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CloseBtn_MouseLeave(object sender, EventArgs e)
        {
            CloseBtn.BackColor = Color.FromArgb(34, 34, 34);
        }
    }

    /// <summary>
    /// The <c>UITypeEditor</c> derived class which indicates how a <c>PenPainter</c>
    /// object can be edited directly from Visual Studio Designer.
    /// </summary>
    /// <seealso cref="System.Drawing.Design.UITypeEditor" />
    /// <remarks>Note that this class is <b>NOT</b> meant to be invoked directly</remarks>
	public class PenPainterEditor : System.Drawing.Design.UITypeEditor
    {
        /// <summary>
        /// Gets the editor style used by the <c>EditValue</c> method.
        /// </summary>
        /// <param name="context">An ITypeDescriptorContext that can be used to gain additional context information.</param>
        /// <returns><c>UITypeEditorEditStyle.Modal</c></returns>
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        /// <summary>
        /// Creates and displays a <c>PenPainterEditorDialog</c> dialog if <c>value</c> is a <c>PenPainter</c>.
        /// </summary>
        /// <param name="context">An ITypeDescriptorContext that can be used to gain additional context information.</param>
        /// <param name="provider">An IServiceProvider through which editing services may be obtained.</param>
        /// <param name="value">An instance of <c>PenPainter</c> being edited.</param>
        /// <returns>The new value of the <c>PenPainter</c> being edited.</returns>
		public override object EditValue(System.ComponentModel.ITypeDescriptorContext context,
                                         System.IServiceProvider provider,
                                         object value)
        {
            if (value is PenPainter)
            {
                Editors.PenPainter.PenPainterEditorDialog dialog = new Editors.PenPainter.PenPainterEditorDialog((PenPainter)value);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.PenPainter;
                }
            }
            return value;
        }

        /// <summary>
        /// Indicates that painting is supported.
        /// </summary>
        /// <param name="context">An ITypeDescriptorContext that can be used to gain additional context information.</param>
        /// <returns><c>true</c>.</returns>
		public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        /// <summary>
        /// Paint a representation of the line (usually in designer).
        /// </summary>
        /// <param name="e">A <c>PaintValueEventArgs</c> that indicates what to paint and where to paint it.</param>
		public override void PaintValue(PaintValueEventArgs e)
        {
            if (e.Value is PenPainter)
            {
                int y = e.Bounds.Height / 2;
                Pen pen = ((PenPainter)e.Value).GetPen();
                if (pen != null)
                {
                    e.Graphics.DrawLine(pen, e.Bounds.X, y, e.Bounds.X + e.Bounds.Width - 1, y);
                }
            }
        }
    }
}
