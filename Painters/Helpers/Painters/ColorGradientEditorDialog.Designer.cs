// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-05-2018
// ***********************************************************************
// <copyright file="ColorGradientEditorDialog.Designer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors
{
    /// <summary>
    /// Class ColorGradientEditorDialog.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class ColorGradientEditorDialog
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
            System.Drawing.Drawing2D.ColorBlend colorBlend1 = new System.Drawing.Drawing2D.ColorBlend();
            this.colorGradientEditor = new Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.ColorGradientEditor();
            this.splitter = new System.Windows.Forms.SplitContainer();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).BeginInit();
            this.splitter.Panel1.SuspendLayout();
            this.splitter.Panel2.SuspendLayout();
            this.splitter.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // colorGradientEditor
            // 
            this.colorGradientEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            colorBlend1.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))))};
            colorBlend1.Positions = new float[] {
        0F,
        0.5F,
        1F};
            this.colorGradientEditor.Blend = colorBlend1;
            this.colorGradientEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorGradientEditor.GradientBackColor = System.Drawing.Color.White;
            this.colorGradientEditor.GradientBorderColor = System.Drawing.Color.DarkGray;
            this.colorGradientEditor.GradientHatchColor = System.Drawing.Color.Black;
            this.colorGradientEditor.Location = new System.Drawing.Point(0, 0);
            this.colorGradientEditor.MarkerBorderColor = System.Drawing.Color.Black;
            this.colorGradientEditor.MarkerFillColor = System.Drawing.Color.White;
            this.colorGradientEditor.MinimumSize = new System.Drawing.Size(322, 120);
            this.colorGradientEditor.Name = "colorGradientEditor";
            this.colorGradientEditor.SelMarkerFillColor = System.Drawing.Color.Yellow;
            this.colorGradientEditor.Size = new System.Drawing.Size(374, 169);
            this.colorGradientEditor.TabIndex = 0;
            this.colorGradientEditor.Load += new System.EventHandler(this.colorGradientEditor_Load);
            // 
            // splitter
            // 
            this.splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitter.IsSplitterFixed = true;
            this.splitter.Location = new System.Drawing.Point(8, 38);
            this.splitter.Name = "splitter";
            this.splitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitter.Panel1
            // 
            this.splitter.Panel1.Controls.Add(this.colorGradientEditor);
            // 
            // splitter.Panel2
            // 
            this.splitter.Panel2.Controls.Add(this.cancelButton);
            this.splitter.Panel2.Controls.Add(this.okButton);
            this.splitter.Size = new System.Drawing.Size(374, 198);
            this.splitter.SplitterDistance = 169;
            this.splitter.TabIndex = 1;
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.SlateGray;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cancelButton.Location = new System.Drawing.Point(80, 0);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 24);
            this.cancelButton.TabIndex = 1;
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
            this.okButton.Location = new System.Drawing.Point(0, 0);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 24);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 24);
            this.panel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(353, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(18, 21);
            this.button1.TabIndex = 0;
            this.button1.Text = "x";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // ColorGradientEditorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(390, 244);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(356, 200);
            this.Name = "ColorGradientEditorDialog";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "Color Gradient Editor";
            this.splitter.Panel1.ResumeLayout(false);
            this.splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).EndInit();
            this.splitter.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The color gradient editor
        /// </summary>
        private ColorGradientEditor colorGradientEditor;
        /// <summary>
        /// The splitter
        /// </summary>
        private System.Windows.Forms.SplitContainer splitter;
        /// <summary>
        /// The cancel button
        /// </summary>
        private System.Windows.Forms.Button cancelButton;
        /// <summary>
        /// The ok button
        /// </summary>
        private System.Windows.Forms.Button okButton;
        /// <summary>
        /// The panel1
        /// </summary>
        private System.Windows.Forms.Panel panel1;
        /// <summary>
        /// The button1
        /// </summary>
        private System.Windows.Forms.Button button1;
    }
}