// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-05-2018
// ***********************************************************************
// <copyright file="SystemColorPickerDialog.Designer.cs" company="Zeroit Dev Technologies">
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
    /// Class SystemColorPickerDialog.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class SystemColorPickerDialog
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
            this.systemColorPicker = new Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.SystemColorPicker();
            this.SuspendLayout();
            // 
            // systemColorPicker
            // 
            this.systemColorPicker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.systemColorPicker.ColorBoxOffset = 2;
            this.systemColorPicker.ColorBoxWidth = 40;
            this.systemColorPicker.ColorFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systemColorPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.systemColorPicker.Location = new System.Drawing.Point(0, 0);
            this.systemColorPicker.Name = "systemColorPicker";
            this.systemColorPicker.Size = new System.Drawing.Size(188, 164);
            this.systemColorPicker.TabIndex = 0;
            this.systemColorPicker.TitleColor = System.Drawing.Color.DarkGray;
            this.systemColorPicker.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.systemColorPicker.ColorSelected += new Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.BaseColorPicker.ColorSelectedEventHandler(this.systemColorPicker_ColorSelected);
            // 
            // SystemColorPickerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(188, 164);
            this.Controls.Add(this.systemColorPicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SystemColorPickerDialog";
            this.Text = "System Color Picker";
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The system color picker
        /// </summary>
        private Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.SystemColorPicker systemColorPicker;
    }
}