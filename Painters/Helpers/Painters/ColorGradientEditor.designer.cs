// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-05-2018
// ***********************************************************************
// <copyright file="ColorGradientEditor.designer.cs" company="Zeroit Dev Technologies">
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
    /// Class ColorGradientEditor.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    partial class ColorGradientEditor
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gradientPanel = new Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.NoFlickerPanel();
            this.positionNud = new System.Windows.Forms.NumericUpDown();
            this.prevButton = new System.Windows.Forms.Button();
            this.postionPreLabel = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.colorPreLabel = new System.Windows.Forms.Label();
            this.alphaNud = new System.Windows.Forms.NumericUpDown();
            this.lastButton = new System.Windows.Forms.Button();
            this.firstButton = new System.Windows.Forms.Button();
            this.opacityPreLabel = new System.Windows.Forms.Label();
            this.colorButton = new System.Windows.Forms.Button();
            this.colorLabel = new System.Windows.Forms.Label();
            this.delButton = new System.Windows.Forms.Button();
            this.stopLabel = new System.Windows.Forms.Label();
            this.newAfterButton = new System.Windows.Forms.Button();
            this.newBeforeButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.positionNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alphaNud)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradientPanel
            // 
            this.gradientPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.gradientPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel.Name = "gradientPanel";
            this.gradientPanel.Size = new System.Drawing.Size(384, 162);
            this.gradientPanel.TabIndex = 0;
            this.gradientPanel.SizeChanged += new System.EventHandler(this.gradientPanel_SizeChanged);
            this.gradientPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.gradientPanel_Paint);
            this.gradientPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gradientPanel_MouseDown);
            this.gradientPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gradientPanel_MouseMove);
            this.gradientPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gradientPanel_MouseUp);
            // 
            // positionNud
            // 
            this.positionNud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.positionNud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.positionNud.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.positionNud.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.positionNud.Location = new System.Drawing.Point(64, 54);
            this.positionNud.Name = "positionNud";
            this.positionNud.Size = new System.Drawing.Size(44, 23);
            this.positionNud.TabIndex = 8;
            this.positionNud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.positionNud.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.positionNud.ValueChanged += new System.EventHandler(this.positionNud_ValueChanged);
            // 
            // prevButton
            // 
            this.prevButton.BackgroundImage = global::Zeroit.Framework.Utilities.Properties.Resources.Back;
            this.prevButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.prevButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.prevButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prevButton.Location = new System.Drawing.Point(96, 15);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(24, 23);
            this.prevButton.TabIndex = 1;
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            this.prevButton.MouseEnter += new System.EventHandler(this.prevButton_MouseEnter);
            this.prevButton.MouseLeave += new System.EventHandler(this.prevButton_MouseLeave);
            // 
            // postionPreLabel
            // 
            this.postionPreLabel.AutoSize = true;
            this.postionPreLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.postionPreLabel.Location = new System.Drawing.Point(7, 57);
            this.postionPreLabel.Name = "postionPreLabel";
            this.postionPreLabel.Size = new System.Drawing.Size(44, 13);
            this.postionPreLabel.TabIndex = 7;
            this.postionPreLabel.Text = "Position";
            this.postionPreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nextButton
            // 
            this.nextButton.BackgroundImage = global::Zeroit.Framework.Utilities.Properties.Resources.Forward;
            this.nextButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.nextButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.nextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextButton.Location = new System.Drawing.Point(128, 15);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(24, 23);
            this.nextButton.TabIndex = 2;
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            this.nextButton.MouseEnter += new System.EventHandler(this.nextButton_MouseEnter);
            this.nextButton.MouseLeave += new System.EventHandler(this.nextButton_MouseLeave);
            // 
            // colorPreLabel
            // 
            this.colorPreLabel.AutoSize = true;
            this.colorPreLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.colorPreLabel.Location = new System.Drawing.Point(141, 57);
            this.colorPreLabel.Name = "colorPreLabel";
            this.colorPreLabel.Size = new System.Drawing.Size(31, 13);
            this.colorPreLabel.TabIndex = 9;
            this.colorPreLabel.Text = "Color";
            this.colorPreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // alphaNud
            // 
            this.alphaNud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.alphaNud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.alphaNud.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.alphaNud.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.alphaNud.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.alphaNud.Location = new System.Drawing.Point(329, 53);
            this.alphaNud.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.alphaNud.Name = "alphaNud";
            this.alphaNud.Size = new System.Drawing.Size(48, 23);
            this.alphaNud.TabIndex = 13;
            this.alphaNud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.alphaNud.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.alphaNud.ValueChanged += new System.EventHandler(this.alphaNud_ValueChanged);
            // 
            // lastButton
            // 
            this.lastButton.BackgroundImage = global::Zeroit.Framework.Utilities.Properties.Resources.Double_Right;
            this.lastButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.lastButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.lastButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lastButton.Location = new System.Drawing.Point(160, 15);
            this.lastButton.Name = "lastButton";
            this.lastButton.Size = new System.Drawing.Size(24, 23);
            this.lastButton.TabIndex = 3;
            this.lastButton.UseVisualStyleBackColor = true;
            this.lastButton.Click += new System.EventHandler(this.lastButton_Click);
            this.lastButton.MouseEnter += new System.EventHandler(this.lastButton_MouseEnter);
            this.lastButton.MouseLeave += new System.EventHandler(this.lastButton_MouseLeave);
            // 
            // firstButton
            // 
            this.firstButton.BackgroundImage = global::Zeroit.Framework.Utilities.Properties.Resources.Double_Left;
            this.firstButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.firstButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.firstButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.firstButton.Location = new System.Drawing.Point(63, 15);
            this.firstButton.Name = "firstButton";
            this.firstButton.Size = new System.Drawing.Size(25, 23);
            this.firstButton.TabIndex = 1;
            this.firstButton.UseVisualStyleBackColor = true;
            this.firstButton.Click += new System.EventHandler(this.firstButton_Click);
            this.firstButton.MouseEnter += new System.EventHandler(this.firstButton_MouseEnter);
            this.firstButton.MouseLeave += new System.EventHandler(this.firstButton_MouseLeave);
            // 
            // opacityPreLabel
            // 
            this.opacityPreLabel.AutoSize = true;
            this.opacityPreLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.opacityPreLabel.Location = new System.Drawing.Point(290, 57);
            this.opacityPreLabel.Name = "opacityPreLabel";
            this.opacityPreLabel.Size = new System.Drawing.Size(34, 13);
            this.opacityPreLabel.TabIndex = 12;
            this.opacityPreLabel.Text = "Alpha";
            this.opacityPreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // colorButton
            // 
            this.colorButton.BackgroundImage = global::Zeroit.Framework.Utilities.Properties.Resources.Down;
            this.colorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.colorButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.colorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorButton.Location = new System.Drawing.Point(234, 53);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(23, 24);
            this.colorButton.TabIndex = 11;
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // colorLabel
            // 
            this.colorLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.colorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorLabel.Location = new System.Drawing.Point(176, 53);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(56, 24);
            this.colorLabel.TabIndex = 10;
            this.colorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // delButton
            // 
            this.delButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.delButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.delButton.Location = new System.Drawing.Point(327, 15);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(48, 23);
            this.delButton.TabIndex = 6;
            this.delButton.Text = "Del";
            this.delButton.UseVisualStyleBackColor = true;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            this.delButton.MouseEnter += new System.EventHandler(this.delButton_MouseEnter);
            this.delButton.MouseLeave += new System.EventHandler(this.delButton_MouseLeave);
            // 
            // stopLabel
            // 
            this.stopLabel.AutoSize = true;
            this.stopLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.stopLabel.Location = new System.Drawing.Point(6, 20);
            this.stopLabel.Name = "stopLabel";
            this.stopLabel.Size = new System.Drawing.Size(51, 13);
            this.stopLabel.TabIndex = 0;
            this.stopLabel.Text = "Stop X/Y";
            this.stopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // newAfterButton
            // 
            this.newAfterButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.newAfterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newAfterButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.newAfterButton.Image = global::Zeroit.Framework.Utilities.Properties.Resources.Forward;
            this.newAfterButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.newAfterButton.Location = new System.Drawing.Point(264, 15);
            this.newAfterButton.Name = "newAfterButton";
            this.newAfterButton.Size = new System.Drawing.Size(52, 23);
            this.newAfterButton.TabIndex = 5;
            this.newAfterButton.Text = "New";
            this.newAfterButton.UseVisualStyleBackColor = true;
            this.newAfterButton.Click += new System.EventHandler(this.newAfterButton_Click);
            this.newAfterButton.MouseEnter += new System.EventHandler(this.newAfterButton_MouseEnter);
            this.newAfterButton.MouseLeave += new System.EventHandler(this.newAfterButton_MouseLeave);
            // 
            // newBeforeButton
            // 
            this.newBeforeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.newBeforeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newBeforeButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.newBeforeButton.Image = global::Zeroit.Framework.Utilities.Properties.Resources.Back;
            this.newBeforeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.newBeforeButton.Location = new System.Drawing.Point(202, 15);
            this.newBeforeButton.Name = "newBeforeButton";
            this.newBeforeButton.Size = new System.Drawing.Size(51, 23);
            this.newBeforeButton.TabIndex = 4;
            this.newBeforeButton.Text = "New";
            this.newBeforeButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.newBeforeButton.UseVisualStyleBackColor = true;
            this.newBeforeButton.Click += new System.EventHandler(this.newBeforeButton_Click);
            this.newBeforeButton.MouseEnter += new System.EventHandler(this.newBeforeButton_MouseEnter_1);
            this.newBeforeButton.MouseLeave += new System.EventHandler(this.newBeforeButton_MouseLeave_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.newBeforeButton);
            this.panel1.Controls.Add(this.lastButton);
            this.panel1.Controls.Add(this.positionNud);
            this.panel1.Controls.Add(this.firstButton);
            this.panel1.Controls.Add(this.colorLabel);
            this.panel1.Controls.Add(this.colorButton);
            this.panel1.Controls.Add(this.newAfterButton);
            this.panel1.Controls.Add(this.postionPreLabel);
            this.panel1.Controls.Add(this.prevButton);
            this.panel1.Controls.Add(this.opacityPreLabel);
            this.panel1.Controls.Add(this.stopLabel);
            this.panel1.Controls.Add(this.colorPreLabel);
            this.panel1.Controls.Add(this.delButton);
            this.panel1.Controls.Add(this.alphaNud);
            this.panel1.Controls.Add(this.nextButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 204);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 85);
            this.panel1.TabIndex = 14;
            // 
            // ColorGradientEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gradientPanel);
            this.MinimumSize = new System.Drawing.Size(322, 120);
            this.Name = "ColorGradientEditor";
            this.Size = new System.Drawing.Size(384, 289);
            ((System.ComponentModel.ISupportInitialize)(this.positionNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alphaNud)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        /// <summary>
        /// The gradient panel
        /// </summary>
        private NoFlickerPanel gradientPanel;
        /// <summary>
        /// The position nud
        /// </summary>
        private System.Windows.Forms.NumericUpDown positionNud;
        /// <summary>
        /// The previous button
        /// </summary>
        private System.Windows.Forms.Button prevButton;
        /// <summary>
        /// The postion pre label
        /// </summary>
        private System.Windows.Forms.Label postionPreLabel;
        /// <summary>
        /// The next button
        /// </summary>
        private System.Windows.Forms.Button nextButton;
        /// <summary>
        /// The color pre label
        /// </summary>
        private System.Windows.Forms.Label colorPreLabel;
        /// <summary>
        /// The alpha nud
        /// </summary>
        private System.Windows.Forms.NumericUpDown alphaNud;
        /// <summary>
        /// The last button
        /// </summary>
        private System.Windows.Forms.Button lastButton;
        /// <summary>
        /// The first button
        /// </summary>
        private System.Windows.Forms.Button firstButton;
        /// <summary>
        /// The opacity pre label
        /// </summary>
        private System.Windows.Forms.Label opacityPreLabel;
        /// <summary>
        /// The color button
        /// </summary>
        private System.Windows.Forms.Button colorButton;
        /// <summary>
        /// The color label
        /// </summary>
        private System.Windows.Forms.Label colorLabel;
        /// <summary>
        /// The delete button
        /// </summary>
        private System.Windows.Forms.Button delButton;
        /// <summary>
        /// The stop label
        /// </summary>
        private System.Windows.Forms.Label stopLabel;
        /// <summary>
        /// The new after button
        /// </summary>
        private System.Windows.Forms.Button newAfterButton;
        /// <summary>
        /// The new before button
        /// </summary>
        private System.Windows.Forms.Button newBeforeButton;
        /// <summary>
        /// The panel1
        /// </summary>
        private System.Windows.Forms.Panel panel1;
    }
}
