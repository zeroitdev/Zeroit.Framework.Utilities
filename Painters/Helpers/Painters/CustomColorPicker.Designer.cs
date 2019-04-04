// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-05-2018
// ***********************************************************************
// <copyright file="CustomColorPicker.Designer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors
{
    /// <summary>
    /// Class CustomColorPicker.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.BaseColorPicker" />
    partial class CustomColorPicker
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
            this.selectButton = new System.Windows.Forms.Button();
            this.hueLabel = new System.Windows.Forms.Label();
            this.hueTextBox = new System.Windows.Forms.TextBox();
            this.satTextBox = new System.Windows.Forms.TextBox();
            this.satLabel = new System.Windows.Forms.Label();
            this.lumTextBox = new System.Windows.Forms.TextBox();
            this.lumLabel = new System.Windows.Forms.Label();
            this.blueTextBox = new System.Windows.Forms.TextBox();
            this.blueLabel = new System.Windows.Forms.Label();
            this.greenTextBox = new System.Windows.Forms.TextBox();
            this.greenLabel = new System.Windows.Forms.Label();
            this.redTextBox = new System.Windows.Forms.TextBox();
            this.redLabel = new System.Windows.Forms.Label();
            this.colorLabel = new System.Windows.Forms.Label();
            this.bitmapPanel = new Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.NoFlickerPanel();
            this.lumPanel = new Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.NoFlickerPanel();
            this.alphaLabel = new System.Windows.Forms.Label();
            this.alphaNud = new System.Windows.Forms.NumericUpDown();
            this.colorALabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.alphaNud)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectButton
            // 
            this.selectButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.GrayText;
            this.selectButton.FlatAppearance.BorderSize = 0;
            this.selectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.selectButton.Location = new System.Drawing.Point(217, 84);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(56, 23);
            this.selectButton.TabIndex = 17;
            this.selectButton.Text = "S&elect";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            this.selectButton.MouseEnter += new System.EventHandler(this.Select_Btn_MouseEnter);
            this.selectButton.MouseLeave += new System.EventHandler(this.Select_Btn_MouseLeave);
            // 
            // hueLabel
            // 
            this.hueLabel.AutoSize = true;
            this.hueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.hueLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.hueLabel.Location = new System.Drawing.Point(8, 14);
            this.hueLabel.Name = "hueLabel";
            this.hueLabel.Size = new System.Drawing.Size(27, 13);
            this.hueLabel.TabIndex = 2;
            this.hueLabel.Text = "&Hue";
            this.hueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hueTextBox
            // 
            this.hueTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.hueTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hueTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.hueTextBox.Location = new System.Drawing.Point(44, 11);
            this.hueTextBox.Name = "hueTextBox";
            this.hueTextBox.Size = new System.Drawing.Size(40, 20);
            this.hueTextBox.TabIndex = 3;
            this.hueTextBox.TextChanged += new System.EventHandler(this.hueTextBox_TextChanged);
            this.hueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.num_KeyPress);
            // 
            // satTextBox
            // 
            this.satTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.satTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.satTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.satTextBox.Location = new System.Drawing.Point(44, 35);
            this.satTextBox.Name = "satTextBox";
            this.satTextBox.Size = new System.Drawing.Size(40, 20);
            this.satTextBox.TabIndex = 5;
            this.satTextBox.TextChanged += new System.EventHandler(this.satTextBox_TextChanged);
            this.satTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.num_KeyPress);
            // 
            // satLabel
            // 
            this.satLabel.AutoSize = true;
            this.satLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.satLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.satLabel.Location = new System.Drawing.Point(8, 38);
            this.satLabel.Name = "satLabel";
            this.satLabel.Size = new System.Drawing.Size(23, 13);
            this.satLabel.TabIndex = 4;
            this.satLabel.Text = "&Sat";
            this.satLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lumTextBox
            // 
            this.lumTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.lumTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lumTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lumTextBox.Location = new System.Drawing.Point(44, 59);
            this.lumTextBox.Name = "lumTextBox";
            this.lumTextBox.Size = new System.Drawing.Size(40, 20);
            this.lumTextBox.TabIndex = 7;
            this.lumTextBox.TextChanged += new System.EventHandler(this.lumTextBox_TextChanged);
            this.lumTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.num_KeyPress);
            // 
            // lumLabel
            // 
            this.lumLabel.AutoSize = true;
            this.lumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lumLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lumLabel.Location = new System.Drawing.Point(8, 62);
            this.lumLabel.Name = "lumLabel";
            this.lumLabel.Size = new System.Drawing.Size(27, 13);
            this.lumLabel.TabIndex = 6;
            this.lumLabel.Text = "&Lum";
            this.lumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // blueTextBox
            // 
            this.blueTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.blueTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.blueTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.blueTextBox.Location = new System.Drawing.Point(147, 61);
            this.blueTextBox.Name = "blueTextBox";
            this.blueTextBox.Size = new System.Drawing.Size(48, 20);
            this.blueTextBox.TabIndex = 13;
            this.blueTextBox.TextChanged += new System.EventHandler(this.blueTextBox_TextChanged);
            this.blueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.num_KeyPress);
            // 
            // blueLabel
            // 
            this.blueLabel.AutoSize = true;
            this.blueLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.blueLabel.Location = new System.Drawing.Point(105, 64);
            this.blueLabel.Name = "blueLabel";
            this.blueLabel.Size = new System.Drawing.Size(28, 13);
            this.blueLabel.TabIndex = 12;
            this.blueLabel.Text = "&Blue";
            this.blueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // greenTextBox
            // 
            this.greenTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.greenTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.greenTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.greenTextBox.Location = new System.Drawing.Point(147, 36);
            this.greenTextBox.Name = "greenTextBox";
            this.greenTextBox.Size = new System.Drawing.Size(48, 20);
            this.greenTextBox.TabIndex = 11;
            this.greenTextBox.TextChanged += new System.EventHandler(this.greenTextBox_TextChanged);
            this.greenTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.num_KeyPress);
            // 
            // greenLabel
            // 
            this.greenLabel.AutoSize = true;
            this.greenLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.greenLabel.Location = new System.Drawing.Point(105, 39);
            this.greenLabel.Name = "greenLabel";
            this.greenLabel.Size = new System.Drawing.Size(36, 13);
            this.greenLabel.TabIndex = 10;
            this.greenLabel.Text = "&Green";
            this.greenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // redTextBox
            // 
            this.redTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.redTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.redTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.redTextBox.Location = new System.Drawing.Point(147, 11);
            this.redTextBox.Name = "redTextBox";
            this.redTextBox.Size = new System.Drawing.Size(48, 20);
            this.redTextBox.TabIndex = 9;
            this.redTextBox.TextChanged += new System.EventHandler(this.redTextBox_TextChanged);
            this.redTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.num_KeyPress);
            // 
            // redLabel
            // 
            this.redLabel.AutoSize = true;
            this.redLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.redLabel.Location = new System.Drawing.Point(105, 14);
            this.redLabel.Name = "redLabel";
            this.redLabel.Size = new System.Drawing.Size(27, 13);
            this.redLabel.TabIndex = 8;
            this.redLabel.Text = "&Red";
            this.redLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // colorLabel
            // 
            this.colorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorLabel.Location = new System.Drawing.Point(217, 11);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(56, 34);
            this.colorLabel.TabIndex = 16;
            // 
            // bitmapPanel
            // 
            this.bitmapPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.bitmapPanel.Location = new System.Drawing.Point(8, 8);
            this.bitmapPanel.Name = "bitmapPanel";
            this.bitmapPanel.Size = new System.Drawing.Size(216, 216);
            this.bitmapPanel.TabIndex = 0;
            this.bitmapPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.bitmapPanel_Paint);
            this.bitmapPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bitmapPanel_MouseDown);
            this.bitmapPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bitmapPanel_MouseMove);
            this.bitmapPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bitmapPanel_MouseUp);
            // 
            // lumPanel
            // 
            this.lumPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.lumPanel.Location = new System.Drawing.Point(232, 8);
            this.lumPanel.Name = "lumPanel";
            this.lumPanel.Size = new System.Drawing.Size(56, 216);
            this.lumPanel.TabIndex = 1;
            this.lumPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.lumPanel_Paint);
            this.lumPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lumPanel_MouseDown);
            this.lumPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lumPanel_MouseMove);
            this.lumPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lumPanel_MouseUp);
            // 
            // alphaLabel
            // 
            this.alphaLabel.AutoSize = true;
            this.alphaLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.alphaLabel.Location = new System.Drawing.Point(104, 89);
            this.alphaLabel.Name = "alphaLabel";
            this.alphaLabel.Size = new System.Drawing.Size(37, 13);
            this.alphaLabel.TabIndex = 14;
            this.alphaLabel.Text = "&Alpha:";
            this.alphaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // alphaNud
            // 
            this.alphaNud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.alphaNud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.alphaNud.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alphaNud.ForeColor = System.Drawing.SystemColors.GrayText;
            this.alphaNud.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.alphaNud.Location = new System.Drawing.Point(147, 86);
            this.alphaNud.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.alphaNud.Name = "alphaNud";
            this.alphaNud.Size = new System.Drawing.Size(48, 20);
            this.alphaNud.TabIndex = 15;
            this.alphaNud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.alphaNud.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.alphaNud.ValueChanged += new System.EventHandler(this.alphaNud_ValueChanged);
            // 
            // colorALabel
            // 
            this.colorALabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorALabel.Location = new System.Drawing.Point(217, 44);
            this.colorALabel.Name = "colorALabel";
            this.colorALabel.Size = new System.Drawing.Size(56, 34);
            this.colorALabel.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.colorLabel);
            this.panel1.Controls.Add(this.colorALabel);
            this.panel1.Controls.Add(this.selectButton);
            this.panel1.Controls.Add(this.alphaNud);
            this.panel1.Controls.Add(this.hueLabel);
            this.panel1.Controls.Add(this.alphaLabel);
            this.panel1.Controls.Add(this.hueTextBox);
            this.panel1.Controls.Add(this.satLabel);
            this.panel1.Controls.Add(this.satTextBox);
            this.panel1.Controls.Add(this.lumLabel);
            this.panel1.Controls.Add(this.blueTextBox);
            this.panel1.Controls.Add(this.lumTextBox);
            this.panel1.Controls.Add(this.blueLabel);
            this.panel1.Controls.Add(this.redLabel);
            this.panel1.Controls.Add(this.greenTextBox);
            this.panel1.Controls.Add(this.redTextBox);
            this.panel1.Controls.Add(this.greenLabel);
            this.panel1.Location = new System.Drawing.Point(8, 231);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 117);
            this.panel1.TabIndex = 19;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // CustomColorPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lumPanel);
            this.Controls.Add(this.bitmapPanel);
            this.MinimumSize = new System.Drawing.Size(296, 336);
            this.Name = "CustomColorPicker";
            this.Size = new System.Drawing.Size(296, 353);
            ((System.ComponentModel.ISupportInitialize)(this.alphaNud)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The select button
        /// </summary>
        private System.Windows.Forms.Button selectButton;
        /// <summary>
        /// The hue label
        /// </summary>
        private System.Windows.Forms.Label hueLabel;
        /// <summary>
        /// The hue text box
        /// </summary>
        private System.Windows.Forms.TextBox hueTextBox;
        /// <summary>
        /// The sat text box
        /// </summary>
        private System.Windows.Forms.TextBox satTextBox;
        /// <summary>
        /// The sat label
        /// </summary>
        private System.Windows.Forms.Label satLabel;
        /// <summary>
        /// The lum text box
        /// </summary>
        private System.Windows.Forms.TextBox lumTextBox;
        /// <summary>
        /// The lum label
        /// </summary>
        private System.Windows.Forms.Label lumLabel;
        /// <summary>
        /// The blue text box
        /// </summary>
        private System.Windows.Forms.TextBox blueTextBox;
        /// <summary>
        /// The blue label
        /// </summary>
        private System.Windows.Forms.Label blueLabel;
        /// <summary>
        /// The green text box
        /// </summary>
        private System.Windows.Forms.TextBox greenTextBox;
        /// <summary>
        /// The green label
        /// </summary>
        private System.Windows.Forms.Label greenLabel;
        /// <summary>
        /// The red text box
        /// </summary>
        private System.Windows.Forms.TextBox redTextBox;
        /// <summary>
        /// The red label
        /// </summary>
        private System.Windows.Forms.Label redLabel;
        /// <summary>
        /// The color label
        /// </summary>
        private System.Windows.Forms.Label colorLabel;
        /// <summary>
        /// The bitmap panel
        /// </summary>
        private NoFlickerPanel bitmapPanel;
        /// <summary>
        /// The lum panel
        /// </summary>
        private NoFlickerPanel lumPanel;
        /// <summary>
        /// The alpha label
        /// </summary>
        private System.Windows.Forms.Label alphaLabel;
        /// <summary>
        /// The alpha nud
        /// </summary>
        private System.Windows.Forms.NumericUpDown alphaNud;
        /// <summary>
        /// The color a label
        /// </summary>
        private System.Windows.Forms.Label colorALabel;
        /// <summary>
        /// The panel1
        /// </summary>
        private System.Windows.Forms.Panel panel1;
    }
}
