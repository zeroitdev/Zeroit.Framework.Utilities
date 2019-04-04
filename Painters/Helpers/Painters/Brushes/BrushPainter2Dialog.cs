// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="BrushPainter2Dialog.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.Brushes
{
    /// <summary>
    /// Implements a dialog which allows design and editing of a <c>BrushPainter2</c> object.
    /// May be used in designer.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class BrushPainter2EditorDialog : System.Windows.Forms.Form
    {
        /// <summary>
        /// Initializes a new instance of <c>BrushPainter2EditorDialog</c> using an empty <c>BrushPainter2</c>
        /// at the default window position.
        /// </summary>
        public BrushPainter2EditorDialog() : this(BrushPainter2.Empty())
        {
        }

        /// <summary>
        /// Initializes a new instance of <c>BrushPainter2EditorDialog</c> using an existing <c>BrushPainter2</c>
        /// at the default window position.
        /// </summary>
        /// <param name="filler">Existing <c>BrushPainter2</c> object.</param>
        /// <exception cref="ArgumentNullException">filler</exception>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="filler" /> is null.</exception>
        public BrushPainter2EditorDialog(BrushPainter2 filler)
        {
            if (filler == null)
            {
                throw new ArgumentNullException("filler");
            }

            InitializeComponent();
            AdjustDialogSize();
            SetControlsToInitialValues(filler);
        }

        /// <summary>
        /// Initializes a new instance of <c>BrushPainter2EditorDialog</c> using an empty <c>BrushPainter2</c>
        /// and positioned beneath the specified control.
        /// </summary>
        /// <param name="c">Control beneath which the dialog should be placed.</param>
        public BrushPainter2EditorDialog(Control c) : this(BrushPainter2.Empty(), c)
        {
        }

        /// <summary>
        /// Initializes a new instance of <c>BrushPainter2EditorDialog</c> using an existing <c>BrushPainter2</c>
        /// and positioned beneath the specified control.
        /// </summary>
        /// <param name="filler">Existing <c>BrushPainter2</c> object.</param>
        /// <param name="c">Control beneath which the dialog should be placed.</param>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="filler" /> is null.</exception>
        public BrushPainter2EditorDialog(BrushPainter2 filler, Control c) : this(filler)
        {
            Utils.SetStartPositionBelowControl(this, c);
        }

        /// <summary>
        /// Adjusts the size of the dialog.
        /// </summary>
        private void AdjustDialogSize()
        {
            // Three different possible group boxes - move them all to one coordinate
            int x = solidGroupBox.Location.X;
            int y = typeGroupBox.Location.Y;

            solidGroupBox.Location = new Point(x, y);
            hatchGroupBox.Location = new Point(x, y);
            gradientGroupBox.Location = new Point(x, y);

            int bottomY = Math.Max(solidGroupBox.Bounds.Bottom,
                          Math.Max(hatchGroupBox.Bounds.Bottom,
                             Math.Max(gradientGroupBox.Bounds.Bottom,
                                   typeGroupBox.Bounds.Bottom)));

            int newHeight = bottomY + typeGroupBox.Location.Y;

            this.Size = new Size(Size.Width, Size.Height - (ClientSize.Height - newHeight));
        }

        /// <summary>
        /// Sets the controls to initial values.
        /// </summary>
        /// <param name="filler">The filler.</param>
        private void SetControlsToInitialValues(BrushPainter2 filler)
        {
            Init(filler.SolidColor, solidColorLabel, solidAlphaNud);
            Init(filler.HatchColor, hatchColorLabel, hatchAlphaNud);
            Init(filler.BackColor, backColorLabel, backAlphaNud);
            gradientEditor.Blend = filler.GradientColors;

            hatchComboBox.SelectedIndex = 0;
            for (int i = 0; i < hatchComboBox.Items.Count; i++)
            {
                if (filler.HatchStyle == (HatchStyle)(hatchComboBox.Items[i]))
                {
                    hatchComboBox.SelectedIndex = i;
                }
            }
            UpdateHatch();

            UpdateSolid();

            if (filler.FillType == BrushPainter2Type.None)
            {
                noneRadioButton.Checked = true;
            }
            else if (filler.FillType == BrushPainter2Type.Solid)
            {
                solidRadioButton.Checked = true;
            }
            else if (filler.FillType == BrushPainter2Type.Hatch)
            {
                hatchRadioButton.Checked = true;
            }
            else
            {
                gradientRadioButton.Checked = true;
            }
        }

        /// <summary>
        /// Initializes the specified c.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="label">The label.</param>
        /// <param name="alphaNud">The alpha nud.</param>
        private void Init(Color c, Label label, NumericUpDown alphaNud)
        {
            label.BackColor = RGB(c);
            alphaNud.Value = (decimal)c.A;
        }

        /// <summary>
        /// Froms the label nud.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <param name="alphaNud">The alpha nud.</param>
        /// <returns>Color.</returns>
        private Color FromLabelNud(Label label, NumericUpDown alphaNud)
        {
            return Color.FromArgb((int)alphaNud.Value, label.BackColor);
        }

        /// <summary>
        /// RGBs the specified c.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns>Color.</returns>
        private Color RGB(Color c)
        {
            return Color.FromArgb(255, c);
        }

        /// <summary>
        /// The filler
        /// </summary>
        private BrushPainter2 filler;
        /// <summary>
        /// Gets current filler.
        /// </summary>
        /// <value>Current filler.</value>
        public BrushPainter2 BrushPainter
        {
            get { return filler; }
        }

        /// <summary>
        /// Updates the solid.
        /// </summary>
        private void UpdateSolid()
        {
            sampleSolidPanel.BackColor = FromLabelNud(solidColorLabel, solidAlphaNud);
        }

        /// <summary>
        /// Updates the hatch.
        /// </summary>
        private void UpdateHatch()
        {
            sampleHatchPanel.Set(hatchComboBox.SelectedHatchStyle,
                                 FromLabelNud(hatchColorLabel, hatchAlphaNud),
                                 FromLabelNud(backColorLabel, backAlphaNud));
        }

        /// <summary>
        /// Handles the Click event of the solidColorButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void solidColorButton_Click(object sender, EventArgs e)
        {
            ComboColorPickerDialog d = new ComboColorPickerDialog(solidColorLabel.BackColor, solidColorButton);
            if (d.ShowDialog() == DialogResult.OK)
            {
                solidColorLabel.BackColor = d.Color;
            }
            UpdateSolid();
        }

        /// <summary>
        /// Handles the ValueChanged event of the solidAlphaNud control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void solidAlphaNud_ValueChanged(object sender, EventArgs e)
        {
            UpdateSolid();
        }

        /// <summary>
        /// Handles the Click event of the hatchColorButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void hatchColorButton_Click(object sender, EventArgs e)
        {
            ComboColorPickerDialog d = new ComboColorPickerDialog(hatchColorLabel.BackColor, hatchColorButton);
            if (d.ShowDialog() == DialogResult.OK)
            {
                hatchColorLabel.BackColor = Color.FromArgb((int)hatchAlphaNud.Value, d.Color);
            }
            UpdateHatch();
        }

        /// <summary>
        /// Handles the ValueChanged event of the hatchAlphaNud control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void hatchAlphaNud_ValueChanged(object sender, EventArgs e)
        {
            UpdateHatch();
        }

        /// <summary>
        /// Handles the Click event of the backColorButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void backColorButton_Click(object sender, EventArgs e)
        {
            ComboColorPickerDialog d = new ComboColorPickerDialog(backColorLabel.BackColor, backColorButton);
            if (d.ShowDialog() == DialogResult.OK)
            {
                backColorLabel.BackColor = d.Color;
            }
            UpdateHatch();
        }

        /// <summary>
        /// Handles the ValueChanged event of the backAlphaNud control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void backAlphaNud_ValueChanged(object sender, EventArgs e)
        {
            UpdateHatch();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the hatchComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void hatchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateHatch();
        }

        /// <summary>
        /// Fillers the type changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void fillerTypeChanged(object sender, EventArgs e)
        {
            if (solidRadioButton.Checked)
            {
                solidGroupBox.Visible = true;
                hatchGroupBox.Visible = false;
                gradientGroupBox.Visible = false;
            }
            else if (hatchRadioButton.Checked)
            {
                solidGroupBox.Visible = false;
                hatchGroupBox.Visible = true;
                gradientGroupBox.Visible = false;
            }
            else if (gradientRadioButton.Checked)
            {
                solidGroupBox.Visible = false;
                hatchGroupBox.Visible = false;
                gradientGroupBox.Visible = true;
            }
            else
            {
                solidGroupBox.Visible = false;
                hatchGroupBox.Visible = false;
                gradientGroupBox.Visible = false;
            }
        }

        /// <summary>
        /// Handles the Click event of the okButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void okButton_Click(object sender, EventArgs e)
        {
            if (solidRadioButton.Checked)
            {
                filler = new BrushPainter2(FromLabelNud(solidColorLabel, solidAlphaNud));
            }
            else if (hatchRadioButton.Checked)
            {
                filler = new BrushPainter2(hatchComboBox.SelectedHatchStyle,
                                     FromLabelNud(hatchColorLabel, hatchAlphaNud),
                                     FromLabelNud(backColorLabel, backAlphaNud));
            }
            else if (gradientRadioButton.Checked)
            {
                filler = new BrushPainter2(gradientEditor.Blend);
            }
            else
            {
                filler = BrushPainter2.Empty();
            }
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
        /// Handles the MouseEnter event of the solidColorButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void solidColorButton_MouseEnter(object sender, EventArgs e)
        {
            solidColorButton.FlatAppearance.BorderColor = Color.FromArgb(128, 255, 255);
        }

        /// <summary>
        /// Handles the Click event of the CloseBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the MouseLeave event of the solidColorButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void solidColorButton_MouseLeave(object sender, EventArgs e)
        {
            solidColorButton.FlatAppearance.BorderColor = Color.FromArgb(56, 56, 56);
        }

        /// <summary>
        /// Handles the MouseEnter event of the hatchColorButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void hatchColorButton_MouseEnter(object sender, EventArgs e)
        {
            hatchColorButton.FlatAppearance.BorderColor = Color.FromArgb(128, 255, 255);
        }

        /// <summary>
        /// Handles the MouseLeave event of the hatchColorButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void hatchColorButton_MouseLeave(object sender, EventArgs e)
        {
            hatchColorButton.FlatAppearance.BorderColor = Color.FromArgb(56, 56, 56);
        }

        /// <summary>
        /// Handles the MouseEnter event of the backColorButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void backColorButton_MouseEnter(object sender, EventArgs e)
        {
            backColorButton.FlatAppearance.BorderColor = Color.FromArgb(128, 255, 255);
        }

        /// <summary>
        /// Handles the MouseLeave event of the backColorButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void backColorButton_MouseLeave(object sender, EventArgs e)
        {
            backColorButton.FlatAppearance.BorderColor = Color.FromArgb(56, 56, 56);
        }

        /// <summary>
        /// Handles the Load event of the BrushPainter2EditorDialog control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BrushPainter2EditorDialog_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Paint event of the panel1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    /// <summary>
    /// The <c>UITypeEditor</c> derived class which indicates how a <c>BrushPainter2</c>
    /// object can be edited directly from Visual Studio Designer.
    /// </summary>
    /// <seealso cref="System.Drawing.Design.UITypeEditor" />
    /// <remarks>Note that this class is <b>NOT</b> meant to be invoked directly</remarks>
	public class BrushPainter2Editor : System.Drawing.Design.UITypeEditor
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
        /// Creates and displays a <c>BrushPainter2EditorDialog</c> dialog if <c>value</c> is a <c>BrushPainter2</c>.
        /// </summary>
        /// <param name="context">An ITypeDescriptorContext that can be used to gain additional context information.</param>
        /// <param name="provider">An IServiceProvider through which editing services may be obtained.</param>
        /// <param name="value">An instance of <c>BrushPainter2</c> being edited.</param>
        /// <returns>The new value of the <c>BrushPainter2</c> being edited.</returns>
		public override object EditValue(System.ComponentModel.ITypeDescriptorContext context,
                                         System.IServiceProvider provider,
                                         object value)
        {
            if (value is BrushPainter2)
            {
                BrushPainter2EditorDialog dialog = new BrushPainter2EditorDialog((BrushPainter2)value);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.BrushPainter;
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
        /// Paint a representation of the simple filler (usually in designer).
        /// </summary>
        /// <param name="e">A <c>PaintValueEventArgs</c> that indicates what to paint and where to paint it.</param>
		public override void PaintValue(PaintValueEventArgs e)
        {
            if (e.Value is BrushPainter2)
            {
                Brush br = ((BrushPainter2)e.Value).GetUITypeEditorBrush(e.Bounds);
                if (br != null)
                {
                    e.Graphics.FillRectangle(br, e.Bounds /*r*/);
                }
            }
        }
    }

}
