// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-05-2018
// ***********************************************************************
// <copyright file="CustomColorPickerDialog.Designer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors
{
    partial class CustomColorPickerDialog
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.customColorPicker = new Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.CustomColorPicker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CloseBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 33);
            this.panel1.TabIndex = 1;
            // 
            // CloseBtn
            // 
            this.CloseBtn.BackColor = System.Drawing.Color.Red;
            this.CloseBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CloseBtn.Location = new System.Drawing.Point(284, 5);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(25, 23);
            this.CloseBtn.TabIndex = 0;
            this.CloseBtn.Text = "X";
            this.CloseBtn.UseVisualStyleBackColor = false;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // customColorPicker
            // 
            this.customColorPicker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.customColorPicker.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.customColorPicker.Location = new System.Drawing.Point(0, 39);
            this.customColorPicker.MinimumSize = new System.Drawing.Size(288, 300);
            this.customColorPicker.Name = "customColorPicker";
            this.customColorPicker.Size = new System.Drawing.Size(312, 334);
            this.customColorPicker.TabIndex = 0;
            this.customColorPicker.ColorSelected += new Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.BaseColorPicker.ColorSelectedEventHandler(this.customColorPicker_ColorSelected);
            // 
            // CustomColorPickerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(312, 373);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.customColorPicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomColorPickerDialog";
            this.Text = "Custom Color Picker";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.CustomColorPicker customColorPicker;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CloseBtn;
    }
}