// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-05-2018
// ***********************************************************************
// <copyright file="CatColorPicker.Designer.cs" company="Zeroit Dev Technologies">
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
    /// Class CatColorPicker.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.BaseColorPicker" />
    partial class CatColorPicker
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
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.panel = new Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.NoFlickerPanel();
            this.SuspendLayout();
            // 
            // vScrollBar
            // 
            this.vScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar.LargeChange = 1;
            this.vScrollBar.Location = new System.Drawing.Point(133, 0);
            this.vScrollBar.Maximum = 2;
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(17, 150);
            this.vScrollBar.TabIndex = 1;
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_Scroll);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(133, 150);
            this.panel.TabIndex = 0;
            this.panel.SizeChanged += new System.EventHandler(this.panel_SizeChanged);
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            this.panel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.panel_KeyDown);
            this.panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_MouseClick);
            // 
            // CatColorPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.Controls.Add(this.panel);
            this.Controls.Add(this.vScrollBar);
            this.Name = "CatColorPicker";
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The v scroll bar
        /// </summary>
        private System.Windows.Forms.VScrollBar vScrollBar;
        /// <summary>
        /// The panel
        /// </summary>
        private NoFlickerPanel panel;
    }
}
