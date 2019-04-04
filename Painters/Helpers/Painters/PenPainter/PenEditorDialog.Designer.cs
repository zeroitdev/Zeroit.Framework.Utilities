// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-05-2018
// ***********************************************************************
// <copyright file="PenEditorDialog.Designer.cs" company="Zeroit Dev Technologies">
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
namespace Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.PenPainter
{
    /// <summary>
    /// Class PenPainterEditorDialog.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class PenPainterEditorDialog
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
            this.thematic1501 = new Zeroit.Framework.Utilities.GraphicsExtension.ThemeManagers.SpicyLips();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.alphaPreLabel = new System.Windows.Forms.Label();
            this.alphaNud = new System.Windows.Forms.NumericUpDown();
            this.widthNud = new System.Windows.Forms.NumericUpDown();
            this.widthPreLabel = new System.Windows.Forms.Label();
            this.dashStyleComboBox = new Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.DashStyleComboBox();
            this.dashStylePreLabel = new System.Windows.Forms.Label();
            this.colorLabel = new System.Windows.Forms.Label();
            this.colorButton = new System.Windows.Forms.Button();
            this.colorPreLabel = new System.Windows.Forms.Label();
            this.linePanel2 = new Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.PenPainter.PenPainterPanel();
            this.linePanel1 = new Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.PenPainter.PenPainterPanel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.thematic1501.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alphaNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthNud)).BeginInit();
            this.SuspendLayout();
            // 
            // thematic1501
            // 
            this.thematic1501.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.thematic1501.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.thematic1501.Colors = new Zeroit.Framework.Utilities.GraphicsExtension.ThemeManagers.Bloom[0];
            this.thematic1501.Controls.Add(this.CloseBtn);
            this.thematic1501.Controls.Add(this.alphaPreLabel);
            this.thematic1501.Controls.Add(this.alphaNud);
            this.thematic1501.Controls.Add(this.widthNud);
            this.thematic1501.Controls.Add(this.widthPreLabel);
            this.thematic1501.Controls.Add(this.dashStyleComboBox);
            this.thematic1501.Controls.Add(this.dashStylePreLabel);
            this.thematic1501.Controls.Add(this.colorLabel);
            this.thematic1501.Controls.Add(this.colorButton);
            this.thematic1501.Controls.Add(this.colorPreLabel);
            this.thematic1501.Controls.Add(this.linePanel2);
            this.thematic1501.Controls.Add(this.linePanel1);
            this.thematic1501.Controls.Add(this.cancelButton);
            this.thematic1501.Controls.Add(this.okButton);
            this.thematic1501.Customization = "";
            this.thematic1501.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thematic1501.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.thematic1501.Image = null;
            this.thematic1501.Location = new System.Drawing.Point(0, 0);
            this.thematic1501.Movable = true;
            this.thematic1501.Name = "thematic1501";
            this.thematic1501.NoRounding = false;
            this.thematic1501.Sizable = true;
            this.thematic1501.Size = new System.Drawing.Size(320, 315);
            this.thematic1501.SmartBounds = true;
            this.thematic1501.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.thematic1501.TabIndex = 0;
            this.thematic1501.Text = "Pen Editor";
            this.thematic1501.TransparencyKey = System.Drawing.Color.Empty;
            this.thematic1501.Transparent = false;
            // 
            // CloseBtn
            // 
            this.CloseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.CloseBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.CloseBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.CloseBtn.Location = new System.Drawing.Point(302, 3);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(15, 15);
            this.CloseBtn.TabIndex = 26;
            this.CloseBtn.Text = "x";
            this.CloseBtn.UseCompatibleTextRendering = true;
            this.CloseBtn.UseVisualStyleBackColor = false;
            this.CloseBtn.Click += new System.EventHandler(this.closeBtn_Click);
            this.CloseBtn.MouseEnter += new System.EventHandler(this.CloseBtn_MouseEnter);
            this.CloseBtn.MouseLeave += new System.EventHandler(this.CloseBtn_MouseLeave);
            // 
            // alphaPreLabel
            // 
            this.alphaPreLabel.AutoSize = true;
            this.alphaPreLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.alphaPreLabel.Location = new System.Drawing.Point(136, 196);
            this.alphaPreLabel.Name = "alphaPreLabel";
            this.alphaPreLabel.Size = new System.Drawing.Size(44, 19);
            this.alphaPreLabel.TabIndex = 18;
            this.alphaPreLabel.Text = "Alpha";
            this.alphaPreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // alphaNud
            // 
            this.alphaNud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.alphaNud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.alphaNud.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.alphaNud.ForeColor = System.Drawing.Color.White;
            this.alphaNud.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.alphaNud.Location = new System.Drawing.Point(188, 196);
            this.alphaNud.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.alphaNud.Name = "alphaNud";
            this.alphaNud.Size = new System.Drawing.Size(72, 25);
            this.alphaNud.TabIndex = 19;
            this.alphaNud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.alphaNud.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.alphaNud.Click += new System.EventHandler(this.alphaNud_ValueChanged);
            // 
            // widthNud
            // 
            this.widthNud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.widthNud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.widthNud.DecimalPlaces = 1;
            this.widthNud.ForeColor = System.Drawing.Color.White;
            this.widthNud.Location = new System.Drawing.Point(188, 115);
            this.widthNud.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.widthNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.widthNud.Name = "widthNud";
            this.widthNud.Size = new System.Drawing.Size(72, 25);
            this.widthNud.TabIndex = 23;
            this.widthNud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.widthNud.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.widthNud.ValueChanged += new System.EventHandler(this.widthNud_ValueChanged);
            // 
            // widthPreLabel
            // 
            this.widthPreLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.widthPreLabel.Location = new System.Drawing.Point(132, 115);
            this.widthPreLabel.Name = "widthPreLabel";
            this.widthPreLabel.Size = new System.Drawing.Size(48, 21);
            this.widthPreLabel.TabIndex = 22;
            this.widthPreLabel.Text = "Width:";
            this.widthPreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dashStyleComboBox
            // 
            this.dashStyleComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.dashStyleComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashStyleComboBox.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dashStyleComboBox.FormattingEnabled = true;
            this.dashStyleComboBox.Location = new System.Drawing.Point(188, 69);
            this.dashStyleComboBox.Name = "dashStyleComboBox";
            this.dashStyleComboBox.SelectedDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.dashStyleComboBox.Size = new System.Drawing.Size(96, 26);
            this.dashStyleComboBox.TabIndex = 21;
            this.dashStyleComboBox.SelectedValueChanged += new System.EventHandler(this.dashStyleComboBox_SelectedValueChanged);
            // 
            // dashStylePreLabel
            // 
            this.dashStylePreLabel.AutoSize = true;
            this.dashStylePreLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dashStylePreLabel.Location = new System.Drawing.Point(132, 69);
            this.dashStylePreLabel.Name = "dashStylePreLabel";
            this.dashStylePreLabel.Size = new System.Drawing.Size(38, 19);
            this.dashStylePreLabel.TabIndex = 20;
            this.dashStylePreLabel.Text = "Style";
            this.dashStylePreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // colorLabel
            // 
            this.colorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorLabel.Location = new System.Drawing.Point(188, 159);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(72, 21);
            this.colorLabel.TabIndex = 16;
            this.colorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // colorButton
            // 
            this.colorButton.BackgroundImage = global::Zeroit.Framework.Utilities.Properties.Resources.Down;
            this.colorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.colorButton.FlatAppearance.BorderSize = 0;
            this.colorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorButton.Location = new System.Drawing.Point(260, 159);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(24, 23);
            this.colorButton.TabIndex = 17;
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            this.colorButton.MouseEnter += new System.EventHandler(this.colorButton_MouseEnter);
            this.colorButton.MouseLeave += new System.EventHandler(this.colorButton_MouseLeave);
            // 
            // colorPreLabel
            // 
            this.colorPreLabel.AutoSize = true;
            this.colorPreLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.colorPreLabel.Location = new System.Drawing.Point(134, 159);
            this.colorPreLabel.Name = "colorPreLabel";
            this.colorPreLabel.Size = new System.Drawing.Size(42, 19);
            this.colorPreLabel.TabIndex = 15;
            this.colorPreLabel.Text = "Color";
            this.colorPreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // linePanel2
            // 
            this.linePanel2.BackColor = System.Drawing.Color.Black;
            this.linePanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linePanel2.Location = new System.Drawing.Point(70, 69);
            this.linePanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.linePanel2.Name = "linePanel2";
            this.linePanel2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.linePanel2.Size = new System.Drawing.Size(37, 146);
            this.linePanel2.TabIndex = 14;
            // 
            // linePanel1
            // 
            this.linePanel1.BackColor = System.Drawing.Color.White;
            this.linePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linePanel1.Location = new System.Drawing.Point(24, 69);
            this.linePanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.linePanel1.Name = "linePanel1";
            this.linePanel1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.linePanel1.Size = new System.Drawing.Size(37, 146);
            this.linePanel1.TabIndex = 13;
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.Red;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cancelButton.Location = new System.Drawing.Point(199, 264);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(85, 39);
            this.cancelButton.TabIndex = 25;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.okButton.FlatAppearance.BorderSize = 0;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.okButton.Location = new System.Drawing.Point(108, 264);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(85, 39);
            this.okButton.TabIndex = 24;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // PenPainterEditorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 315);
            this.Controls.Add(this.thematic1501);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PenPainterEditorDialog";
            this.Text = "PenEditorDialog";
            this.thematic1501.ResumeLayout(false);
            this.thematic1501.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alphaNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthNud)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The thematic1501
        /// </summary>
        private Zeroit.Framework.Utilities.GraphicsExtension.ThemeManagers.SpicyLips thematic1501;
        /// <summary>
        /// The alpha pre label
        /// </summary>
        private System.Windows.Forms.Label alphaPreLabel;
        /// <summary>
        /// The alpha nud
        /// </summary>
        private System.Windows.Forms.NumericUpDown alphaNud;
        /// <summary>
        /// The width nud
        /// </summary>
        private System.Windows.Forms.NumericUpDown widthNud;
        /// <summary>
        /// The width pre label
        /// </summary>
        private System.Windows.Forms.Label widthPreLabel;
        /// <summary>
        /// The dash style ComboBox
        /// </summary>
        private DashStyleComboBox dashStyleComboBox;
        /// <summary>
        /// The dash style pre label
        /// </summary>
        private System.Windows.Forms.Label dashStylePreLabel;
        /// <summary>
        /// The color label
        /// </summary>
        private System.Windows.Forms.Label colorLabel;
        /// <summary>
        /// The color button
        /// </summary>
        private System.Windows.Forms.Button colorButton;
        /// <summary>
        /// The color pre label
        /// </summary>
        private System.Windows.Forms.Label colorPreLabel;
        /// <summary>
        /// The line panel2
        /// </summary>
        private PenPainterPanel linePanel2;
        /// <summary>
        /// The line panel1
        /// </summary>
        private PenPainterPanel linePanel1;
        /// <summary>
        /// The cancel button
        /// </summary>
        private System.Windows.Forms.Button cancelButton;
        /// <summary>
        /// The ok button
        /// </summary>
        private System.Windows.Forms.Button okButton;
        /// <summary>
        /// The close BTN
        /// </summary>
        private System.Windows.Forms.Button CloseBtn;
    }
}