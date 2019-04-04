// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-05-2018
// ***********************************************************************
// <copyright file="BrushPainter2Dialog.Designer.cs" company="Zeroit Dev Technologies">
//    This program contains Utilities for all C# programming activities.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.Brushes
{
    /// <summary>
    /// Class BrushPainter2EditorDialog.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class BrushPainter2EditorDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Drawing.Drawing2D.ColorBlend colorBlend1 = new System.Drawing.Drawing2D.ColorBlend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrushPainter2EditorDialog));
            this.thematic1502 = new Zeroit.Framework.Utilities.GraphicsExtension.ThemeManagers.SpicyLips();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.gradientGroupBox = new System.Windows.Forms.GroupBox();
            this.gradientEditor = new Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.ColorGradientEditor();
            this.hatchGroupBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.backAlphaNud = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.hatchAlphaNud = new System.Windows.Forms.NumericUpDown();
            this.hatchComboBox = new Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.HatchStyleComboBox();
            this.sampleHatchPanel = new Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.HatchStylePanel();
            this.hatchPatternTextLabel = new System.Windows.Forms.Label();
            this.backColorButton = new System.Windows.Forms.Button();
            this.backColorLabel = new System.Windows.Forms.Label();
            this.backColorTextLabel = new System.Windows.Forms.Label();
            this.hatchColorButton = new System.Windows.Forms.Button();
            this.hatchColorLabel = new System.Windows.Forms.Label();
            this.hatchColorTextLabel = new System.Windows.Forms.Label();
            this.solidGroupBox = new System.Windows.Forms.GroupBox();
            this.sampleSolidPanel = new System.Windows.Forms.Label();
            this.opacityPreLabel = new System.Windows.Forms.Label();
            this.solidAlphaNud = new System.Windows.Forms.NumericUpDown();
            this.solidColorButton = new System.Windows.Forms.Button();
            this.solidColorLabel = new System.Windows.Forms.Label();
            this.solidColorTextLabel = new System.Windows.Forms.Label();
            this.typeGroupBox = new System.Windows.Forms.GroupBox();
            this.gradientRadioButton = new System.Windows.Forms.RadioButton();
            this.hatchRadioButton = new System.Windows.Forms.RadioButton();
            this.noneRadioButton = new System.Windows.Forms.RadioButton();
            this.solidRadioButton = new System.Windows.Forms.RadioButton();
            this.thematic1502.SuspendLayout();
            this.gradientGroupBox.SuspendLayout();
            this.hatchGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backAlphaNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hatchAlphaNud)).BeginInit();
            this.solidGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.solidAlphaNud)).BeginInit();
            this.typeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // thematic1502
            // 
            
            this.thematic1502.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.thematic1502.Colors = new Zeroit.Framework.Utilities.GraphicsExtension.ThemeManagers.Bloom[0];
            this.thematic1502.Controls.Add(this.CloseBtn);
            this.thematic1502.Controls.Add(this.cancelButton);
            this.thematic1502.Controls.Add(this.okButton);
            this.thematic1502.Controls.Add(this.gradientGroupBox);
            this.thematic1502.Controls.Add(this.hatchGroupBox);
            this.thematic1502.Controls.Add(this.solidGroupBox);
            this.thematic1502.Controls.Add(this.typeGroupBox);
            this.thematic1502.Customization = "";
            this.thematic1502.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thematic1502.Image = null;
            this.thematic1502.Location = new System.Drawing.Point(0, 0);
            this.thematic1502.Movable = true;
            this.thematic1502.Name = "thematic1502";
            this.thematic1502.NoRounding = false;
            this.thematic1502.Sizable = false;
            this.thematic1502.Size = new System.Drawing.Size(732, 775);
            this.thematic1502.SmartBounds = true;
            this.thematic1502.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.thematic1502.TabIndex = 1;
            this.thematic1502.Text = "Brush Painter";
            this.thematic1502.TransparencyKey = System.Drawing.Color.Empty;
            this.thematic1502.Transparent = false;
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.CloseBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.CloseBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.CloseBtn.Location = new System.Drawing.Point(713, 4);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(15, 15);
            this.CloseBtn.TabIndex = 12;
            this.CloseBtn.Text = "x";
            this.CloseBtn.UseCompatibleTextRendering = true;
            this.CloseBtn.UseVisualStyleBackColor = false;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.Red;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cancelButton.Location = new System.Drawing.Point(114, 210);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(88, 43);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.okButton.FlatAppearance.BorderSize = 0;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.okButton.Location = new System.Drawing.Point(22, 210);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(88, 43);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // gradientGroupBox
            // 
            this.gradientGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.gradientGroupBox.Controls.Add(this.gradientEditor);
            this.gradientGroupBox.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.gradientGroupBox.Location = new System.Drawing.Point(246, 333);
            this.gradientGroupBox.Name = "gradientGroupBox";
            this.gradientGroupBox.Size = new System.Drawing.Size(460, 367);
            this.gradientGroupBox.TabIndex = 11;
            this.gradientGroupBox.TabStop = false;
            this.gradientGroupBox.Text = " Gradient ";
            // 
            // gradientEditor
            // 
            this.gradientEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            colorBlend1.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))))};
            colorBlend1.Positions = new float[] {
        0F,
        0.5F,
        1F};
            this.gradientEditor.Blend = colorBlend1;
            this.gradientEditor.GradientBackColor = System.Drawing.Color.White;
            this.gradientEditor.GradientBorderColor = System.Drawing.Color.DarkGray;
            this.gradientEditor.GradientHatchColor = System.Drawing.Color.Black;
            this.gradientEditor.Location = new System.Drawing.Point(6, 25);
            this.gradientEditor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gradientEditor.MarkerBorderColor = System.Drawing.Color.Black;
            this.gradientEditor.MarkerFillColor = System.Drawing.Color.White;
            this.gradientEditor.MinimumSize = new System.Drawing.Size(376, 157);
            this.gradientEditor.Name = "gradientEditor";
            this.gradientEditor.SelMarkerFillColor = System.Drawing.Color.Yellow;
            this.gradientEditor.Size = new System.Drawing.Size(444, 328);
            this.gradientEditor.TabIndex = 12;
            // 
            // hatchGroupBox
            // 
            this.hatchGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.hatchGroupBox.Controls.Add(this.label4);
            this.hatchGroupBox.Controls.Add(this.backAlphaNud);
            this.hatchGroupBox.Controls.Add(this.label1);
            this.hatchGroupBox.Controls.Add(this.hatchAlphaNud);
            this.hatchGroupBox.Controls.Add(this.hatchComboBox);
            this.hatchGroupBox.Controls.Add(this.sampleHatchPanel);
            this.hatchGroupBox.Controls.Add(this.hatchPatternTextLabel);
            this.hatchGroupBox.Controls.Add(this.backColorButton);
            this.hatchGroupBox.Controls.Add(this.backColorLabel);
            this.hatchGroupBox.Controls.Add(this.backColorTextLabel);
            this.hatchGroupBox.Controls.Add(this.hatchColorButton);
            this.hatchGroupBox.Controls.Add(this.hatchColorLabel);
            this.hatchGroupBox.Controls.Add(this.hatchColorTextLabel);
            this.hatchGroupBox.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.hatchGroupBox.Location = new System.Drawing.Point(246, 136);
            this.hatchGroupBox.Name = "hatchGroupBox";
            this.hatchGroupBox.Size = new System.Drawing.Size(460, 191);
            this.hatchGroupBox.TabIndex = 10;
            this.hatchGroupBox.TabStop = false;
            this.hatchGroupBox.Text = " Hatch pattern ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(8, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 19);
            this.label4.TabIndex = 15;
            this.label4.Text = "Alpha:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // backAlphaNud
            // 
            this.backAlphaNud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.backAlphaNud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backAlphaNud.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.backAlphaNud.ForeColor = System.Drawing.Color.White;
            this.backAlphaNud.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.backAlphaNud.Location = new System.Drawing.Point(135, 123);
            this.backAlphaNud.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.backAlphaNud.Name = "backAlphaNud";
            this.backAlphaNud.Size = new System.Drawing.Size(72, 25);
            this.backAlphaNud.TabIndex = 16;
            this.backAlphaNud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.backAlphaNud.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.backAlphaNud.ValueChanged += new System.EventHandler(this.hatchAlphaNud_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "Alpha:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hatchAlphaNud
            // 
            this.hatchAlphaNud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.hatchAlphaNud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hatchAlphaNud.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.hatchAlphaNud.ForeColor = System.Drawing.Color.White;
            this.hatchAlphaNud.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.hatchAlphaNud.Location = new System.Drawing.Point(135, 59);
            this.hatchAlphaNud.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.hatchAlphaNud.Name = "hatchAlphaNud";
            this.hatchAlphaNud.Size = new System.Drawing.Size(72, 25);
            this.hatchAlphaNud.TabIndex = 13;
            this.hatchAlphaNud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.hatchAlphaNud.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.hatchAlphaNud.ValueChanged += new System.EventHandler(this.hatchAlphaNud_ValueChanged);
            // 
            // hatchComboBox
            // 
            this.hatchComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.hatchComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hatchComboBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.hatchComboBox.FormattingEnabled = true;
            this.hatchComboBox.Location = new System.Drawing.Point(135, 157);
            this.hatchComboBox.Name = "hatchComboBox";
            this.hatchComboBox.SelectedHatchStyle = System.Drawing.Drawing2D.HatchStyle.Horizontal;
            this.hatchComboBox.Size = new System.Drawing.Size(96, 26);
            this.hatchComboBox.TabIndex = 10;
            this.hatchComboBox.SelectedIndexChanged += new System.EventHandler(this.hatchComboBox_SelectedIndexChanged);
            // 
            // sampleHatchPanel
            // 
            this.sampleHatchPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.sampleHatchPanel.HatchColor = System.Drawing.Color.Gray;
            this.sampleHatchPanel.HatchStyle = System.Drawing.Drawing2D.HatchStyle.LargeGrid;
            this.sampleHatchPanel.Location = new System.Drawing.Point(275, 24);
            this.sampleHatchPanel.Name = "sampleHatchPanel";
            this.sampleHatchPanel.Size = new System.Drawing.Size(177, 161);
            this.sampleHatchPanel.TabIndex = 9;
            // 
            // hatchPatternTextLabel
            // 
            this.hatchPatternTextLabel.AutoSize = true;
            this.hatchPatternTextLabel.ForeColor = System.Drawing.Color.White;
            this.hatchPatternTextLabel.Location = new System.Drawing.Point(8, 157);
            this.hatchPatternTextLabel.Name = "hatchPatternTextLabel";
            this.hatchPatternTextLabel.Size = new System.Drawing.Size(97, 19);
            this.hatchPatternTextLabel.TabIndex = 7;
            this.hatchPatternTextLabel.Text = "Hatch pattern:";
            this.hatchPatternTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // backColorButton
            // 
            this.backColorButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("backColorButton.BackgroundImage")));
            this.backColorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.backColorButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.backColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backColorButton.Location = new System.Drawing.Point(208, 94);
            this.backColorButton.Name = "backColorButton";
            this.backColorButton.Size = new System.Drawing.Size(24, 23);
            this.backColorButton.TabIndex = 6;
            this.backColorButton.UseVisualStyleBackColor = true;
            this.backColorButton.Click += new System.EventHandler(this.backColorButton_Click);
            this.backColorButton.MouseEnter += new System.EventHandler(this.backColorButton_MouseEnter);
            this.backColorButton.MouseLeave += new System.EventHandler(this.backColorButton_MouseLeave);
            // 
            // backColorLabel
            // 
            this.backColorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backColorLabel.ForeColor = System.Drawing.Color.White;
            this.backColorLabel.Location = new System.Drawing.Point(135, 94);
            this.backColorLabel.Name = "backColorLabel";
            this.backColorLabel.Size = new System.Drawing.Size(72, 23);
            this.backColorLabel.TabIndex = 5;
            this.backColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // backColorTextLabel
            // 
            this.backColorTextLabel.AutoSize = true;
            this.backColorTextLabel.ForeColor = System.Drawing.Color.White;
            this.backColorTextLabel.Location = new System.Drawing.Point(8, 94);
            this.backColorTextLabel.Name = "backColorTextLabel";
            this.backColorTextLabel.Size = new System.Drawing.Size(78, 19);
            this.backColorTextLabel.TabIndex = 4;
            this.backColorTextLabel.Text = "Back color: ";
            this.backColorTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hatchColorButton
            // 
            this.hatchColorButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hatchColorButton.BackgroundImage")));
            this.hatchColorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.hatchColorButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.hatchColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hatchColorButton.Location = new System.Drawing.Point(208, 24);
            this.hatchColorButton.Name = "hatchColorButton";
            this.hatchColorButton.Size = new System.Drawing.Size(24, 24);
            this.hatchColorButton.TabIndex = 3;
            this.hatchColorButton.UseVisualStyleBackColor = true;
            this.hatchColorButton.Click += new System.EventHandler(this.hatchColorButton_Click);
            this.hatchColorButton.MouseEnter += new System.EventHandler(this.hatchColorButton_MouseEnter);
            this.hatchColorButton.MouseLeave += new System.EventHandler(this.hatchColorButton_MouseLeave);
            // 
            // hatchColorLabel
            // 
            this.hatchColorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hatchColorLabel.ForeColor = System.Drawing.Color.White;
            this.hatchColorLabel.Location = new System.Drawing.Point(135, 24);
            this.hatchColorLabel.Name = "hatchColorLabel";
            this.hatchColorLabel.Size = new System.Drawing.Size(72, 24);
            this.hatchColorLabel.TabIndex = 2;
            this.hatchColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hatchColorTextLabel
            // 
            this.hatchColorTextLabel.AutoSize = true;
            this.hatchColorTextLabel.ForeColor = System.Drawing.Color.White;
            this.hatchColorTextLabel.Location = new System.Drawing.Point(8, 24);
            this.hatchColorTextLabel.Name = "hatchColorTextLabel";
            this.hatchColorTextLabel.Size = new System.Drawing.Size(86, 19);
            this.hatchColorTextLabel.TabIndex = 1;
            this.hatchColorTextLabel.Text = "Hatch color: ";
            this.hatchColorTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // solidGroupBox
            // 
            this.solidGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.solidGroupBox.Controls.Add(this.sampleSolidPanel);
            this.solidGroupBox.Controls.Add(this.opacityPreLabel);
            this.solidGroupBox.Controls.Add(this.solidAlphaNud);
            this.solidGroupBox.Controls.Add(this.solidColorButton);
            this.solidGroupBox.Controls.Add(this.solidColorLabel);
            this.solidGroupBox.Controls.Add(this.solidColorTextLabel);
            this.solidGroupBox.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.solidGroupBox.Location = new System.Drawing.Point(246, 40);
            this.solidGroupBox.Name = "solidGroupBox";
            this.solidGroupBox.Size = new System.Drawing.Size(460, 88);
            this.solidGroupBox.TabIndex = 9;
            this.solidGroupBox.TabStop = false;
            this.solidGroupBox.Text = " Solid (one color) ";
            // 
            // sampleSolidPanel
            // 
            this.sampleSolidPanel.Location = new System.Drawing.Point(322, 21);
            this.sampleSolidPanel.Name = "sampleSolidPanel";
            this.sampleSolidPanel.Size = new System.Drawing.Size(128, 59);
            this.sampleSolidPanel.TabIndex = 11;
            this.sampleSolidPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // opacityPreLabel
            // 
            this.opacityPreLabel.ForeColor = System.Drawing.Color.White;
            this.opacityPreLabel.Location = new System.Drawing.Point(48, 55);
            this.opacityPreLabel.Name = "opacityPreLabel";
            this.opacityPreLabel.Size = new System.Drawing.Size(48, 21);
            this.opacityPreLabel.TabIndex = 9;
            this.opacityPreLabel.Text = "Alpha:";
            this.opacityPreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // solidAlphaNud
            // 
            this.solidAlphaNud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.solidAlphaNud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.solidAlphaNud.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.solidAlphaNud.ForeColor = System.Drawing.Color.White;
            this.solidAlphaNud.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.solidAlphaNud.Location = new System.Drawing.Point(108, 55);
            this.solidAlphaNud.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.solidAlphaNud.Name = "solidAlphaNud";
            this.solidAlphaNud.Size = new System.Drawing.Size(72, 25);
            this.solidAlphaNud.TabIndex = 10;
            this.solidAlphaNud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.solidAlphaNud.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.solidAlphaNud.ValueChanged += new System.EventHandler(this.solidAlphaNud_ValueChanged);
            // 
            // solidColorButton
            // 
            this.solidColorButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("solidColorButton.BackgroundImage")));
            this.solidColorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.solidColorButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.solidColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.solidColorButton.Location = new System.Drawing.Point(181, 24);
            this.solidColorButton.Name = "solidColorButton";
            this.solidColorButton.Size = new System.Drawing.Size(24, 23);
            this.solidColorButton.TabIndex = 3;
            this.solidColorButton.UseVisualStyleBackColor = true;
            this.solidColorButton.Click += new System.EventHandler(this.solidColorButton_Click);
            this.solidColorButton.MouseEnter += new System.EventHandler(this.solidColorButton_MouseEnter);
            this.solidColorButton.MouseLeave += new System.EventHandler(this.solidColorButton_MouseLeave);
            // 
            // solidColorLabel
            // 
            this.solidColorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.solidColorLabel.ForeColor = System.Drawing.Color.White;
            this.solidColorLabel.Location = new System.Drawing.Point(108, 24);
            this.solidColorLabel.Name = "solidColorLabel";
            this.solidColorLabel.Size = new System.Drawing.Size(72, 23);
            this.solidColorLabel.TabIndex = 2;
            this.solidColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // solidColorTextLabel
            // 
            this.solidColorTextLabel.ForeColor = System.Drawing.Color.White;
            this.solidColorTextLabel.Location = new System.Drawing.Point(8, 24);
            this.solidColorTextLabel.Name = "solidColorTextLabel";
            this.solidColorTextLabel.Size = new System.Drawing.Size(88, 23);
            this.solidColorTextLabel.TabIndex = 1;
            this.solidColorTextLabel.Text = "Color: ";
            this.solidColorTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // typeGroupBox
            // 
            this.typeGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.typeGroupBox.Controls.Add(this.gradientRadioButton);
            this.typeGroupBox.Controls.Add(this.hatchRadioButton);
            this.typeGroupBox.Controls.Add(this.noneRadioButton);
            this.typeGroupBox.Controls.Add(this.solidRadioButton);
            this.typeGroupBox.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.typeGroupBox.Location = new System.Drawing.Point(22, 40);
            this.typeGroupBox.Name = "typeGroupBox";
            this.typeGroupBox.Size = new System.Drawing.Size(180, 164);
            this.typeGroupBox.TabIndex = 6;
            this.typeGroupBox.TabStop = false;
            this.typeGroupBox.Text = " Fill Type ";
            // 
            // gradientRadioButton
            // 
            this.gradientRadioButton.AutoSize = true;
            this.gradientRadioButton.ForeColor = System.Drawing.Color.White;
            this.gradientRadioButton.Location = new System.Drawing.Point(18, 132);
            this.gradientRadioButton.Name = "gradientRadioButton";
            this.gradientRadioButton.Size = new System.Drawing.Size(80, 23);
            this.gradientRadioButton.TabIndex = 3;
            this.gradientRadioButton.TabStop = true;
            this.gradientRadioButton.Text = "Gradient";
            this.gradientRadioButton.UseVisualStyleBackColor = true;
            this.gradientRadioButton.CheckedChanged += new System.EventHandler(this.fillerTypeChanged);
            // 
            // hatchRadioButton
            // 
            this.hatchRadioButton.AutoSize = true;
            this.hatchRadioButton.ForeColor = System.Drawing.Color.White;
            this.hatchRadioButton.Location = new System.Drawing.Point(16, 96);
            this.hatchRadioButton.Name = "hatchRadioButton";
            this.hatchRadioButton.Size = new System.Drawing.Size(112, 23);
            this.hatchRadioButton.TabIndex = 2;
            this.hatchRadioButton.TabStop = true;
            this.hatchRadioButton.Text = "Hatch pattern";
            this.hatchRadioButton.UseVisualStyleBackColor = true;
            this.hatchRadioButton.CheckedChanged += new System.EventHandler(this.fillerTypeChanged);
            // 
            // noneRadioButton
            // 
            this.noneRadioButton.AutoSize = true;
            this.noneRadioButton.ForeColor = System.Drawing.Color.White;
            this.noneRadioButton.Location = new System.Drawing.Point(16, 24);
            this.noneRadioButton.Name = "noneRadioButton";
            this.noneRadioButton.Size = new System.Drawing.Size(143, 23);
            this.noneRadioButton.TabIndex = 0;
            this.noneRadioButton.TabStop = true;
            this.noneRadioButton.Text = "None (transparent)";
            this.noneRadioButton.UseVisualStyleBackColor = true;
            this.noneRadioButton.CheckedChanged += new System.EventHandler(this.fillerTypeChanged);
            // 
            // solidRadioButton
            // 
            this.solidRadioButton.AutoSize = true;
            this.solidRadioButton.ForeColor = System.Drawing.Color.White;
            this.solidRadioButton.Location = new System.Drawing.Point(16, 60);
            this.solidRadioButton.Name = "solidRadioButton";
            this.solidRadioButton.Size = new System.Drawing.Size(125, 23);
            this.solidRadioButton.TabIndex = 1;
            this.solidRadioButton.TabStop = true;
            this.solidRadioButton.Text = "Solid (one color)";
            this.solidRadioButton.UseVisualStyleBackColor = true;
            this.solidRadioButton.CheckedChanged += new System.EventHandler(this.fillerTypeChanged);
            // 
            // BrushPainter2EditorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(thematic1502);
            this.ClientSize = new System.Drawing.Size(732, 775);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BrushPainter2EditorDialog";
            this.Text = "BrushPainter2Dialog";
            this.thematic1502.ResumeLayout(false);
            this.gradientGroupBox.ResumeLayout(false);
            this.hatchGroupBox.ResumeLayout(false);
            this.hatchGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backAlphaNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hatchAlphaNud)).EndInit();
            this.solidGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.solidAlphaNud)).EndInit();
            this.typeGroupBox.ResumeLayout(false);
            this.typeGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion


        /// <summary>
        /// The thematic1502
        /// </summary>
        private Zeroit.Framework.Utilities.GraphicsExtension.ThemeManagers.SpicyLips thematic1502;
        /// <summary>
        /// The close BTN
        /// </summary>
        private System.Windows.Forms.Button CloseBtn;
        /// <summary>
        /// The cancel button
        /// </summary>
        private System.Windows.Forms.Button cancelButton;
        /// <summary>
        /// The ok button
        /// </summary>
        private System.Windows.Forms.Button okButton;
        /// <summary>
        /// The gradient group box
        /// </summary>
        private System.Windows.Forms.GroupBox gradientGroupBox;
        /// <summary>
        /// The gradient editor
        /// </summary>
        private ColorGradientEditor gradientEditor;
        /// <summary>
        /// The hatch group box
        /// </summary>
        private System.Windows.Forms.GroupBox hatchGroupBox;
        /// <summary>
        /// The label4
        /// </summary>
        private System.Windows.Forms.Label label4;
        /// <summary>
        /// The back alpha nud
        /// </summary>
        private System.Windows.Forms.NumericUpDown backAlphaNud;
        /// <summary>
        /// The label1
        /// </summary>
        private System.Windows.Forms.Label label1;
        /// <summary>
        /// The hatch alpha nud
        /// </summary>
        private System.Windows.Forms.NumericUpDown hatchAlphaNud;
        /// <summary>
        /// The hatch ComboBox
        /// </summary>
        private HatchStyleComboBox hatchComboBox;
        /// <summary>
        /// The sample hatch panel
        /// </summary>
        private HatchStylePanel sampleHatchPanel;
        /// <summary>
        /// The hatch pattern text label
        /// </summary>
        private System.Windows.Forms.Label hatchPatternTextLabel;
        /// <summary>
        /// The back color button
        /// </summary>
        private System.Windows.Forms.Button backColorButton;
        /// <summary>
        /// The back color label
        /// </summary>
        private System.Windows.Forms.Label backColorLabel;
        /// <summary>
        /// The back color text label
        /// </summary>
        private System.Windows.Forms.Label backColorTextLabel;
        /// <summary>
        /// The hatch color button
        /// </summary>
        private System.Windows.Forms.Button hatchColorButton;
        /// <summary>
        /// The hatch color label
        /// </summary>
        private System.Windows.Forms.Label hatchColorLabel;
        /// <summary>
        /// The hatch color text label
        /// </summary>
        private System.Windows.Forms.Label hatchColorTextLabel;
        /// <summary>
        /// The solid group box
        /// </summary>
        private System.Windows.Forms.GroupBox solidGroupBox;
        /// <summary>
        /// The sample solid panel
        /// </summary>
        private System.Windows.Forms.Label sampleSolidPanel;
        /// <summary>
        /// The opacity pre label
        /// </summary>
        private System.Windows.Forms.Label opacityPreLabel;
        /// <summary>
        /// The solid alpha nud
        /// </summary>
        private System.Windows.Forms.NumericUpDown solidAlphaNud;
        /// <summary>
        /// The solid color button
        /// </summary>
        private System.Windows.Forms.Button solidColorButton;
        /// <summary>
        /// The solid color label
        /// </summary>
        private System.Windows.Forms.Label solidColorLabel;
        /// <summary>
        /// The solid color text label
        /// </summary>
        private System.Windows.Forms.Label solidColorTextLabel;
        /// <summary>
        /// The type group box
        /// </summary>
        private System.Windows.Forms.GroupBox typeGroupBox;
        /// <summary>
        /// The gradient RadioButton
        /// </summary>
        private System.Windows.Forms.RadioButton gradientRadioButton;
        /// <summary>
        /// The hatch RadioButton
        /// </summary>
        private System.Windows.Forms.RadioButton hatchRadioButton;
        /// <summary>
        /// The none RadioButton
        /// </summary>
        private System.Windows.Forms.RadioButton noneRadioButton;
        /// <summary>
        /// The solid RadioButton
        /// </summary>
        private System.Windows.Forms.RadioButton solidRadioButton;
    }
}