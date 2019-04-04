// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-05-2018
// ***********************************************************************
// <copyright file="LineEditorDialog.Designer.cs" company="Zeroit Dev Technologies">
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
namespace Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors
{
    /// <summary>
    /// Class LineEditorDialog.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class LineEditorDialog
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.widthNud = new System.Windows.Forms.NumericUpDown();
            this.widthPreLabel = new System.Windows.Forms.Label();
            this.dashStylePreLabel = new System.Windows.Forms.Label();
            this.colorLabel = new System.Windows.Forms.Label();
            this.colorButton = new System.Windows.Forms.Button();
            this.colorPreLabel = new System.Windows.Forms.Label();
            this.alphaPreLabel = new System.Windows.Forms.Label();
            this.alphaNud = new System.Windows.Forms.NumericUpDown();
            this.opacityPreLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Button();
            this.dashStyleComboBox = new Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.DashStyleComboBox();
            this.linePanel2 = new Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.LinePanel();
            this.linePanel1 = new Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.LinePanel();
            this.formName = new System.Windows.Forms.Label();
            this.dragControl1 = new Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.DragControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.widthNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alphaNud)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.SlateGray;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cancelButton.Location = new System.Drawing.Point(256, 74);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(64, 28);
            this.cancelButton.TabIndex = 12;
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
            this.okButton.Location = new System.Drawing.Point(256, 42);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(64, 28);
            this.okButton.TabIndex = 11;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // widthNud
            // 
            this.widthNud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.widthNud.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.widthNud.DecimalPlaces = 1;
            this.widthNud.Location = new System.Drawing.Point(144, 135);
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
            this.widthNud.Size = new System.Drawing.Size(56, 16);
            this.widthNud.TabIndex = 10;
            this.widthNud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.widthPreLabel.Location = new System.Drawing.Point(96, 130);
            this.widthPreLabel.Name = "widthPreLabel";
            this.widthPreLabel.Size = new System.Drawing.Size(48, 21);
            this.widthPreLabel.TabIndex = 9;
            this.widthPreLabel.Text = "Width:";
            this.widthPreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dashStylePreLabel
            // 
            this.dashStylePreLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dashStylePreLabel.Location = new System.Drawing.Point(96, 98);
            this.dashStylePreLabel.Name = "dashStylePreLabel";
            this.dashStylePreLabel.Size = new System.Drawing.Size(48, 21);
            this.dashStylePreLabel.TabIndex = 7;
            this.dashStylePreLabel.Text = "Style:";
            this.dashStylePreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // colorLabel
            // 
            this.colorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorLabel.Location = new System.Drawing.Point(144, 42);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(72, 21);
            this.colorLabel.TabIndex = 3;
            this.colorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // colorButton
            // 
            this.colorButton.BackgroundImage = global::Zeroit.Framework.Utilities.Properties.Resources.Down;
            this.colorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.colorButton.FlatAppearance.BorderSize = 0;
            this.colorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorButton.Location = new System.Drawing.Point(216, 42);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(24, 23);
            this.colorButton.TabIndex = 4;
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            this.colorButton.MouseEnter += new System.EventHandler(this.colorButton_MouseEnter);
            this.colorButton.MouseLeave += new System.EventHandler(this.colorButton_MouseLeave);
            // 
            // colorPreLabel
            // 
            this.colorPreLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.colorPreLabel.Location = new System.Drawing.Point(96, 42);
            this.colorPreLabel.Name = "colorPreLabel";
            this.colorPreLabel.Size = new System.Drawing.Size(48, 21);
            this.colorPreLabel.TabIndex = 2;
            this.colorPreLabel.Text = "Color:";
            this.colorPreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // alphaPreLabel
            // 
            this.alphaPreLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.alphaPreLabel.Location = new System.Drawing.Point(96, 66);
            this.alphaPreLabel.Name = "alphaPreLabel";
            this.alphaPreLabel.Size = new System.Drawing.Size(48, 21);
            this.alphaPreLabel.TabIndex = 5;
            this.alphaPreLabel.Text = "Alpha:";
            this.alphaPreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // alphaNud
            // 
            this.alphaNud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.alphaNud.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.alphaNud.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alphaNud.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.alphaNud.Location = new System.Drawing.Point(144, 71);
            this.alphaNud.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.alphaNud.Name = "alphaNud";
            this.alphaNud.Size = new System.Drawing.Size(48, 17);
            this.alphaNud.TabIndex = 6;
            this.alphaNud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.alphaNud.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.alphaNud.ValueChanged += new System.EventHandler(this.alphaNud_ValueChanged);
            // 
            // opacityPreLabel
            // 
            this.opacityPreLabel.Location = new System.Drawing.Point(96, 66);
            this.opacityPreLabel.Name = "opacityPreLabel";
            this.opacityPreLabel.Size = new System.Drawing.Size(48, 21);
            this.opacityPreLabel.TabIndex = 5;
            this.opacityPreLabel.Text = "Alpha:";
            this.opacityPreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(96, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "Style:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Red;
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.closeBtn.Location = new System.Drawing.Point(320, 3);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(28, 23);
            this.closeBtn.TabIndex = 13;
            this.closeBtn.Text = "X";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // dashStyleComboBox
            // 
            this.dashStyleComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.dashStyleComboBox.FormattingEnabled = true;
            this.dashStyleComboBox.Location = new System.Drawing.Point(144, 98);
            this.dashStyleComboBox.Name = "dashStyleComboBox";
            this.dashStyleComboBox.SelectedDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.dashStyleComboBox.Size = new System.Drawing.Size(96, 21);
            this.dashStyleComboBox.TabIndex = 8;
            this.dashStyleComboBox.SelectedValueChanged += new System.EventHandler(this.dashStyleComboBox_SelectedValueChanged);
            // 
            // linePanel2
            // 
            this.linePanel2.BackColor = System.Drawing.Color.Black;
            this.linePanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linePanel2.Line = new Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.Line(System.Drawing.Color.Black, 1F, System.Drawing.Drawing2D.DashStyle.Solid);
            this.linePanel2.Location = new System.Drawing.Point(56, 42);
            this.linePanel2.Name = "linePanel2";
            this.linePanel2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.linePanel2.Size = new System.Drawing.Size(32, 112);
            this.linePanel2.TabIndex = 1;
            // 
            // linePanel1
            // 
            this.linePanel1.BackColor = System.Drawing.Color.White;
            this.linePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linePanel1.Line = new Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.Line(System.Drawing.Color.Black, 1F, System.Drawing.Drawing2D.DashStyle.Solid);
            this.linePanel1.Location = new System.Drawing.Point(16, 42);
            this.linePanel1.Name = "linePanel1";
            this.linePanel1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.linePanel1.Size = new System.Drawing.Size(32, 112);
            this.linePanel1.TabIndex = 0;
            // 
            // formName
            // 
            this.formName.AutoSize = true;
            this.formName.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.formName.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.formName.Location = new System.Drawing.Point(12, 3);
            this.formName.Name = "formName";
            this.formName.Size = new System.Drawing.Size(89, 21);
            this.formName.TabIndex = 14;
            this.formName.Text = "Line Editor";
            // 
            // dragControl1
            // 
            this.dragControl1.Caption = 32;
            this.dragControl1.Fixed = true;
            this.dragControl1.Horizontal = true;
            this.dragControl1.SizeGrip = 10;
            this.dragControl1.TargetControl = this;
            this.dragControl1.Vertical = true;
            // 
            // LineEditorDialog
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(351, 179);
            this.Controls.Add(this.formName);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.alphaPreLabel);
            this.Controls.Add(this.alphaNud);
            this.Controls.Add(this.widthNud);
            this.Controls.Add(this.widthPreLabel);
            this.Controls.Add(this.dashStyleComboBox);
            this.Controls.Add(this.dashStylePreLabel);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.colorPreLabel);
            this.Controls.Add(this.linePanel2);
            this.Controls.Add(this.linePanel1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LineEditorDialog";
            this.Text = "Line Editor";
            ((System.ComponentModel.ISupportInitialize)(this.widthNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alphaNud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /// <summary>
        /// The cancel button
        /// </summary>
        private System.Windows.Forms.Button cancelButton;
        /// <summary>
        /// The ok button
        /// </summary>
        private System.Windows.Forms.Button okButton;
        /// <summary>
        /// The line panel1
        /// </summary>
        private LinePanel linePanel1;
        /// <summary>
        /// The line panel2
        /// </summary>
        private LinePanel linePanel2;
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
        /// The alpha pre label
        /// </summary>
        private System.Windows.Forms.Label alphaPreLabel;
        /// <summary>
        /// The alpha nud
        /// </summary>
        private System.Windows.Forms.NumericUpDown alphaNud;
        /// <summary>
        /// The opacity pre label
        /// </summary>
        private System.Windows.Forms.Label opacityPreLabel;
        /// <summary>
        /// The label1
        /// </summary>
        private System.Windows.Forms.Label label1;
        /// <summary>
        /// The close BTN
        /// </summary>
        private System.Windows.Forms.Button closeBtn;
        /// <summary>
        /// The form name
        /// </summary>
        private System.Windows.Forms.Label formName;
        /// <summary>
        /// The drag control1
        /// </summary>
        private DragControl dragControl1;
    }
}