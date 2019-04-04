// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-05-2018
// ***********************************************************************
// <copyright file="PolyEditorDialog.Designer.cs" company="Zeroit Dev Technologies">
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
namespace Zeroit.Framework.Utilities.GraphicsExtension
{
    /// <summary>
    /// Class PolyEditorDialog.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class PolyEditorDialog
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
                timer.Stop();
                timer.Dispose();
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
            this.spicyLips1 = new Zeroit.Framework.Utilities.GraphicsExtension.ThemeManagers.SpicyLips();
            this.showCordinatesCheckBox = new System.Windows.Forms.CheckBox();
            this.cordinatesLabel = new System.Windows.Forms.Label();
            this.showVerticesCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fillModeCombo = new System.Windows.Forms.ComboBox();
            this.curvedCheckBox = new System.Windows.Forms.CheckBox();
            this.zoomCheckBox = new System.Windows.Forms.CheckBox();
            this.magnifierScreen = new System.Windows.Forms.PictureBox();
            this.magnifierSettingsBtn = new System.Windows.Forms.PictureBox();
            this.magnifierBtn = new System.Windows.Forms.PictureBox();
            this.zoomLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.zoomTrackBar = new System.Windows.Forms.TrackBar();
            this.gridLinesCheckBox = new System.Windows.Forms.CheckBox();
            this.snapPointsCheckBox = new System.Windows.Forms.CheckBox();
            this.drawAxis = new System.Windows.Forms.CheckBox();
            this.showNumbersCheckBox = new System.Windows.Forms.CheckBox();
            this.closeBtn = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.cordinateLabelTransparent = new Zeroit.Framework.Utilities.GraphicsExtension.TransparentText();
            this.spicyLips1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.magnifierScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.magnifierSettingsBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.magnifierBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // spicyLips1
            // 
            this.spicyLips1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.spicyLips1.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.spicyLips1.Colors = new Zeroit.Framework.Utilities.GraphicsExtension.ThemeManagers.Bloom[0];
            this.spicyLips1.Controls.Add(this.cordinateLabelTransparent);
            this.spicyLips1.Controls.Add(this.showCordinatesCheckBox);
            this.spicyLips1.Controls.Add(this.cordinatesLabel);
            this.spicyLips1.Controls.Add(this.showVerticesCheckBox);
            this.spicyLips1.Controls.Add(this.label2);
            this.spicyLips1.Controls.Add(this.fillModeCombo);
            this.spicyLips1.Controls.Add(this.curvedCheckBox);
            this.spicyLips1.Controls.Add(this.zoomCheckBox);
            this.spicyLips1.Controls.Add(this.magnifierScreen);
            this.spicyLips1.Controls.Add(this.magnifierSettingsBtn);
            this.spicyLips1.Controls.Add(this.magnifierBtn);
            this.spicyLips1.Controls.Add(this.zoomLabel);
            this.spicyLips1.Controls.Add(this.label1);
            this.spicyLips1.Controls.Add(this.zoomTrackBar);
            this.spicyLips1.Controls.Add(this.gridLinesCheckBox);
            this.spicyLips1.Controls.Add(this.snapPointsCheckBox);
            this.spicyLips1.Controls.Add(this.drawAxis);
            this.spicyLips1.Controls.Add(this.showNumbersCheckBox);
            this.spicyLips1.Controls.Add(this.closeBtn);
            this.spicyLips1.Controls.Add(this.listBox1);
            this.spicyLips1.Controls.Add(this.cancelBtn);
            this.spicyLips1.Controls.Add(this.okBtn);
            this.spicyLips1.Controls.Add(this.picCanvas);
            this.spicyLips1.Customization = "";
            this.spicyLips1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spicyLips1.Font = new System.Drawing.Font("Verdana", 8F);
            this.spicyLips1.Image = null;
            this.spicyLips1.Location = new System.Drawing.Point(0, 0);
            this.spicyLips1.Movable = true;
            this.spicyLips1.Name = "spicyLips1";
            this.spicyLips1.NoRounding = false;
            this.spicyLips1.Sizable = true;
            this.spicyLips1.Size = new System.Drawing.Size(600, 418);
            this.spicyLips1.SmartBounds = true;
            this.spicyLips1.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.spicyLips1.TabIndex = 4;
            this.spicyLips1.Text = "Polygon Editor";
            this.spicyLips1.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.spicyLips1.Transparent = false;
            // 
            // showCordinatesCheckBox
            // 
            this.showCordinatesCheckBox.AutoSize = true;
            this.showCordinatesCheckBox.Checked = true;
            this.showCordinatesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showCordinatesCheckBox.ForeColor = System.Drawing.Color.White;
            this.showCordinatesCheckBox.Location = new System.Drawing.Point(254, 303);
            this.showCordinatesCheckBox.Name = "showCordinatesCheckBox";
            this.showCordinatesCheckBox.Size = new System.Drawing.Size(123, 17);
            this.showCordinatesCheckBox.TabIndex = 24;
            this.showCordinatesCheckBox.Text = "Show Cordinates";
            this.showCordinatesCheckBox.UseVisualStyleBackColor = true;
            this.showCordinatesCheckBox.CheckedChanged += new System.EventHandler(this.showCordinatesCheckBox_CheckedChanged);
            // 
            // cordinatesLabel
            // 
            this.cordinatesLabel.AutoSize = true;
            this.cordinatesLabel.BackColor = System.Drawing.Color.Transparent;
            this.cordinatesLabel.ForeColor = System.Drawing.Color.White;
            this.cordinatesLabel.Location = new System.Drawing.Point(265, 335);
            this.cordinatesLabel.Name = "cordinatesLabel";
            this.cordinatesLabel.Size = new System.Drawing.Size(41, 13);
            this.cordinatesLabel.TabIndex = 23;
            this.cordinatesLabel.Text = "Points";
            this.cordinatesLabel.Visible = false;
            // 
            // showVerticesCheckBox
            // 
            this.showVerticesCheckBox.AutoSize = true;
            this.showVerticesCheckBox.Checked = true;
            this.showVerticesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showVerticesCheckBox.ForeColor = System.Drawing.Color.White;
            this.showVerticesCheckBox.Location = new System.Drawing.Point(254, 275);
            this.showVerticesCheckBox.Name = "showVerticesCheckBox";
            this.showVerticesCheckBox.Size = new System.Drawing.Size(106, 17);
            this.showVerticesCheckBox.TabIndex = 22;
            this.showVerticesCheckBox.Text = "Show Vertices";
            this.showVerticesCheckBox.UseVisualStyleBackColor = true;
            this.showVerticesCheckBox.CheckedChanged += new System.EventHandler(this.showVerticesCheckBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(20, 364);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Fill Mode";
            // 
            // fillModeCombo
            // 
            this.fillModeCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.fillModeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fillModeCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fillModeCombo.ForeColor = System.Drawing.Color.White;
            this.fillModeCombo.FormattingEnabled = true;
            this.fillModeCombo.Location = new System.Drawing.Point(108, 361);
            this.fillModeCombo.Name = "fillModeCombo";
            this.fillModeCombo.Size = new System.Drawing.Size(100, 21);
            this.fillModeCombo.TabIndex = 20;
            this.fillModeCombo.SelectedIndexChanged += new System.EventHandler(this.fillModeCombo_SelectedIndexChanged);
            // 
            // curvedCheckBox
            // 
            this.curvedCheckBox.AutoSize = true;
            this.curvedCheckBox.Checked = true;
            this.curvedCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.curvedCheckBox.ForeColor = System.Drawing.Color.White;
            this.curvedCheckBox.Location = new System.Drawing.Point(21, 303);
            this.curvedCheckBox.Name = "curvedCheckBox";
            this.curvedCheckBox.Size = new System.Drawing.Size(68, 17);
            this.curvedCheckBox.TabIndex = 19;
            this.curvedCheckBox.Text = "Curved";
            this.curvedCheckBox.UseVisualStyleBackColor = true;
            this.curvedCheckBox.CheckedChanged += new System.EventHandler(this.curvedCheckBox_CheckedChanged);
            // 
            // zoomCheckBox
            // 
            this.zoomCheckBox.AutoSize = true;
            this.zoomCheckBox.Checked = true;
            this.zoomCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.zoomCheckBox.ForeColor = System.Drawing.Color.White;
            this.zoomCheckBox.Location = new System.Drawing.Point(21, 275);
            this.zoomCheckBox.Name = "zoomCheckBox";
            this.zoomCheckBox.Size = new System.Drawing.Size(59, 17);
            this.zoomCheckBox.TabIndex = 18;
            this.zoomCheckBox.Text = "Zoom";
            this.zoomCheckBox.UseVisualStyleBackColor = true;
            this.zoomCheckBox.CheckedChanged += new System.EventHandler(this.zoomCheckBox_CheckedChanged);
            // 
            // magnifierScreen
            // 
            this.magnifierScreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.magnifierScreen.Location = new System.Drawing.Point(378, 155);
            this.magnifierScreen.Name = "magnifierScreen";
            this.magnifierScreen.Size = new System.Drawing.Size(208, 159);
            this.magnifierScreen.TabIndex = 17;
            this.magnifierScreen.TabStop = false;
            // 
            // magnifierSettingsBtn
            // 
            this.magnifierSettingsBtn.Image = global::Zeroit.Framework.Utilities.Properties.Resources.magnifierSettings;
            this.magnifierSettingsBtn.Location = new System.Drawing.Point(568, 320);
            this.magnifierSettingsBtn.Name = "magnifierSettingsBtn";
            this.magnifierSettingsBtn.Size = new System.Drawing.Size(12, 12);
            this.magnifierSettingsBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.magnifierSettingsBtn.TabIndex = 16;
            this.magnifierSettingsBtn.TabStop = false;
            this.magnifierSettingsBtn.Visible = false;
            this.magnifierSettingsBtn.Click += new System.EventHandler(this.magnifierSettingsBtn_Click);
            // 
            // magnifierBtn
            // 
            this.magnifierBtn.Image = global::Zeroit.Framework.Utilities.Properties.Resources.magnifier_search;
            this.magnifierBtn.Location = new System.Drawing.Point(546, 319);
            this.magnifierBtn.Name = "magnifierBtn";
            this.magnifierBtn.Size = new System.Drawing.Size(16, 16);
            this.magnifierBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.magnifierBtn.TabIndex = 15;
            this.magnifierBtn.TabStop = false;
            this.magnifierBtn.Visible = false;
            this.magnifierBtn.Click += new System.EventHandler(this.magnifierBtn_Click);
            this.magnifierBtn.MouseEnter += new System.EventHandler(this.magnifierBtn_MouseEnter);
            this.magnifierBtn.MouseLeave += new System.EventHandler(this.magnifierBtn_MouseLeave);
            // 
            // zoomLabel
            // 
            this.zoomLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.zoomLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zoomLabel.Font = new System.Drawing.Font("Verdana", 8F);
            this.zoomLabel.ForeColor = System.Drawing.Color.White;
            this.zoomLabel.Location = new System.Drawing.Point(60, 226);
            this.zoomLabel.Name = "zoomLabel";
            this.zoomLabel.Size = new System.Drawing.Size(42, 24);
            this.zoomLabel.TabIndex = 13;
            this.zoomLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.label1.Font = new System.Drawing.Font("Verdana", 8F);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(18, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Zoom";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zoomTrackBar
            // 
            this.zoomTrackBar.Location = new System.Drawing.Point(108, 224);
            this.zoomTrackBar.Maximum = 23;
            this.zoomTrackBar.Minimum = 13;
            this.zoomTrackBar.Name = "zoomTrackBar";
            this.zoomTrackBar.Size = new System.Drawing.Size(198, 45);
            this.zoomTrackBar.TabIndex = 11;
            this.zoomTrackBar.Value = 13;
            this.zoomTrackBar.Scroll += new System.EventHandler(this.zoomTrackBar_Scroll);
            this.zoomTrackBar.ValueChanged += new System.EventHandler(this.zoomTrackBar_ValueChanged);
            this.zoomTrackBar.MouseLeave += new System.EventHandler(this.zoomTrackBar_MouseLeave);
            // 
            // gridLinesCheckBox
            // 
            this.gridLinesCheckBox.AutoSize = true;
            this.gridLinesCheckBox.Checked = true;
            this.gridLinesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gridLinesCheckBox.ForeColor = System.Drawing.Color.White;
            this.gridLinesCheckBox.Location = new System.Drawing.Point(109, 331);
            this.gridLinesCheckBox.Name = "gridLinesCheckBox";
            this.gridLinesCheckBox.Size = new System.Drawing.Size(118, 17);
            this.gridLinesCheckBox.TabIndex = 10;
            this.gridLinesCheckBox.Text = "Show Grid Lines";
            this.gridLinesCheckBox.UseVisualStyleBackColor = true;
            this.gridLinesCheckBox.CheckedChanged += new System.EventHandler(this.gridLinesCheckBox_CheckedChanged);
            // 
            // snapPointsCheckBox
            // 
            this.snapPointsCheckBox.AutoSize = true;
            this.snapPointsCheckBox.Checked = true;
            this.snapPointsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.snapPointsCheckBox.ForeColor = System.Drawing.Color.White;
            this.snapPointsCheckBox.Location = new System.Drawing.Point(109, 303);
            this.snapPointsCheckBox.Name = "snapPointsCheckBox";
            this.snapPointsCheckBox.Size = new System.Drawing.Size(128, 17);
            this.snapPointsCheckBox.TabIndex = 9;
            this.snapPointsCheckBox.Text = "Show Snap Points";
            this.snapPointsCheckBox.UseVisualStyleBackColor = true;
            this.snapPointsCheckBox.CheckedChanged += new System.EventHandler(this.snapPointsCheckBox_CheckedChanged);
            // 
            // drawAxis
            // 
            this.drawAxis.AutoSize = true;
            this.drawAxis.Checked = true;
            this.drawAxis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.drawAxis.ForeColor = System.Drawing.Color.White;
            this.drawAxis.Location = new System.Drawing.Point(21, 329);
            this.drawAxis.Name = "drawAxis";
            this.drawAxis.Size = new System.Drawing.Size(85, 17);
            this.drawAxis.TabIndex = 8;
            this.drawAxis.Text = "Show Axis";
            this.drawAxis.UseVisualStyleBackColor = true;
            this.drawAxis.CheckedChanged += new System.EventHandler(this.drawAxis_CheckedChanged);
            // 
            // showNumbersCheckBox
            // 
            this.showNumbersCheckBox.AutoSize = true;
            this.showNumbersCheckBox.Checked = true;
            this.showNumbersCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showNumbersCheckBox.ForeColor = System.Drawing.Color.White;
            this.showNumbersCheckBox.Location = new System.Drawing.Point(109, 275);
            this.showNumbersCheckBox.Name = "showNumbersCheckBox";
            this.showNumbersCheckBox.Size = new System.Drawing.Size(144, 17);
            this.showNumbersCheckBox.TabIndex = 7;
            this.showNumbersCheckBox.Text = "Show Point Numbers";
            this.showNumbersCheckBox.UseVisualStyleBackColor = true;
            this.showNumbersCheckBox.CheckedChanged += new System.EventHandler(this.showNumbersCheckBox_CheckedChanged);
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.closeBtn.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.closeBtn.ForeColor = System.Drawing.Color.White;
            this.closeBtn.Location = new System.Drawing.Point(578, 1);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(20, 20);
            this.closeBtn.TabIndex = 6;
            this.closeBtn.Text = "x";
            this.closeBtn.UseCompatibleTextRendering = true;
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.ForeColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(378, 30);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(208, 119);
            this.listBox1.TabIndex = 5;
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.cancelBtn.FlatAppearance.BorderSize = 0;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.ForeColor = System.Drawing.Color.White;
            this.cancelBtn.Location = new System.Drawing.Point(498, 371);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(82, 35);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.BackColor = System.Drawing.Color.Red;
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.okBtn.FlatAppearance.BorderSize = 0;
            this.okBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okBtn.ForeColor = System.Drawing.Color.White;
            this.okBtn.Location = new System.Drawing.Point(410, 371);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(82, 35);
            this.okBtn.TabIndex = 3;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = false;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picCanvas.Location = new System.Drawing.Point(16, 28);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(356, 195);
            this.picCanvas.TabIndex = 2;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            this.picCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseDown);
            this.picCanvas.MouseLeave += new System.EventHandler(this.picCanvas_MouseLeave);
            this.picCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseMove_NotDrawing);
            this.picCanvas.Resize += new System.EventHandler(this.picCanvas_Resize);
            // 
            // cordinateLabelTransparent
            // 
            this.cordinateLabelTransparent.AllowTransparency = true;
            this.cordinateLabelTransparent.ForeColor = System.Drawing.Color.White;
            this.cordinateLabelTransparent.Location = new System.Drawing.Point(268, 366);
            this.cordinateLabelTransparent.Name = "cordinateLabelTransparent";
            this.cordinateLabelTransparent.Size = new System.Drawing.Size(83, 40);
            this.cordinateLabelTransparent.TabIndex = 25;
            this.cordinateLabelTransparent.Text = "Transparent";
            this.cordinateLabelTransparent.Visible = false;
            // 
            // PolyEditorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 418);
            this.Controls.Add(this.spicyLips1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PolyEditorDialog";
            this.Text = "howto_polygon_editor3";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.spicyLips1.ResumeLayout(false);
            this.spicyLips1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.magnifierScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.magnifierSettingsBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.magnifierBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The spicy lips1
        /// </summary>
        private ThemeManagers.SpicyLips spicyLips1;
        /// <summary>
        /// The close BTN
        /// </summary>
        private System.Windows.Forms.Button closeBtn;
        /// <summary>
        /// The list box1
        /// </summary>
        private System.Windows.Forms.ListBox listBox1;
        /// <summary>
        /// The cancel BTN
        /// </summary>
        private System.Windows.Forms.Button cancelBtn;
        /// <summary>
        /// The ok BTN
        /// </summary>
        private System.Windows.Forms.Button okBtn;
        /// <summary>
        /// The pic canvas
        /// </summary>
        public System.Windows.Forms.PictureBox picCanvas;
        /// <summary>
        /// The draw axis
        /// </summary>
        private System.Windows.Forms.CheckBox drawAxis;
        /// <summary>
        /// The show numbers CheckBox
        /// </summary>
        private System.Windows.Forms.CheckBox showNumbersCheckBox;
        /// <summary>
        /// The grid lines CheckBox
        /// </summary>
        private System.Windows.Forms.CheckBox gridLinesCheckBox;
        /// <summary>
        /// The snap points CheckBox
        /// </summary>
        private System.Windows.Forms.CheckBox snapPointsCheckBox;
        /// <summary>
        /// The zoom track bar
        /// </summary>
        private System.Windows.Forms.TrackBar zoomTrackBar;
        /// <summary>
        /// The zoom label
        /// </summary>
        private System.Windows.Forms.Label zoomLabel;
        /// <summary>
        /// The label1
        /// </summary>
        private System.Windows.Forms.Label label1;
        /// <summary>
        /// The magnifier BTN
        /// </summary>
        private System.Windows.Forms.PictureBox magnifierBtn;
        /// <summary>
        /// The magnifier settings BTN
        /// </summary>
        private System.Windows.Forms.PictureBox magnifierSettingsBtn;
        /// <summary>
        /// The magnifier screen
        /// </summary>
        private System.Windows.Forms.PictureBox magnifierScreen;
        /// <summary>
        /// The zoom CheckBox
        /// </summary>
        private System.Windows.Forms.CheckBox zoomCheckBox;
        /// <summary>
        /// The curved CheckBox
        /// </summary>
        private System.Windows.Forms.CheckBox curvedCheckBox;
        /// <summary>
        /// The fill mode combo
        /// </summary>
        private System.Windows.Forms.ComboBox fillModeCombo;
        /// <summary>
        /// The label2
        /// </summary>
        private System.Windows.Forms.Label label2;
        /// <summary>
        /// The show vertices CheckBox
        /// </summary>
        private System.Windows.Forms.CheckBox showVerticesCheckBox;
        /// <summary>
        /// The cordinates label
        /// </summary>
        private System.Windows.Forms.Label cordinatesLabel;
        /// <summary>
        /// The show cordinates CheckBox
        /// </summary>
        private System.Windows.Forms.CheckBox showCordinatesCheckBox;
        /// <summary>
        /// The cordinate label transparent
        /// </summary>
        private TransparentText cordinateLabelTransparent;
    }
}

