// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-05-2018
// ***********************************************************************
// <copyright file="ComboColorPicker.Designer.cs" company="Zeroit Dev Technologies">
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

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors
{
    /// <summary>
    /// Class ComboColorPicker.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.BaseColorPicker" />
    partial class ComboColorPicker
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageWeb = new System.Windows.Forms.TabPage();
            this.webColorPicker = new Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.WebColorPicker();
            this.tabPageSystem = new System.Windows.Forms.TabPage();
            this.systemColorPicker = new Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.SystemColorPicker();
            this.tabPageCustom = new System.Windows.Forms.TabPage();
            this.customColorPicker = new Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.CustomColorPicker();
            this.tabControl.SuspendLayout();
            this.tabPageWeb.SuspendLayout();
            this.tabPageSystem.SuspendLayout();
            this.tabPageCustom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageWeb);
            this.tabControl.Controls.Add(this.tabPageSystem);
            this.tabControl.Controls.Add(this.tabPageCustom);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(304, 360);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageWeb
            // 
            this.tabPageWeb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.tabPageWeb.Controls.Add(this.webColorPicker);
            this.tabPageWeb.Location = new System.Drawing.Point(4, 22);
            this.tabPageWeb.Name = "tabPageWeb";
            this.tabPageWeb.Size = new System.Drawing.Size(296, 334);
            this.tabPageWeb.TabIndex = 0;
            this.tabPageWeb.Text = "Web";
            // 
            // webColorPicker
            // 
            this.webColorPicker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.webColorPicker.ColorBoxOffset = 2;
            this.webColorPicker.ColorBoxWidth = 40;
            this.webColorPicker.ColorFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.webColorPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webColorPicker.Location = new System.Drawing.Point(0, 0);
            this.webColorPicker.Name = "webColorPicker";
            this.webColorPicker.Size = new System.Drawing.Size(296, 334);
            this.webColorPicker.TabIndex = 0;
            this.webColorPicker.TitleColor = System.Drawing.Color.DarkGray;
            this.webColorPicker.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.webColorPicker.ColorSelected += new Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.BaseColorPicker.ColorSelectedEventHandler(this.tab_ColorSelected);
            // 
            // tabPageSystem
            // 
            this.tabPageSystem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.tabPageSystem.Controls.Add(this.systemColorPicker);
            this.tabPageSystem.Location = new System.Drawing.Point(4, 22);
            this.tabPageSystem.Name = "tabPageSystem";
            this.tabPageSystem.Size = new System.Drawing.Size(296, 334);
            this.tabPageSystem.TabIndex = 1;
            this.tabPageSystem.Text = "System";
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
            this.systemColorPicker.Size = new System.Drawing.Size(296, 334);
            this.systemColorPicker.TabIndex = 0;
            this.systemColorPicker.TitleColor = System.Drawing.Color.DarkGray;
            this.systemColorPicker.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.systemColorPicker.ColorSelected += new Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.BaseColorPicker.ColorSelectedEventHandler(this.tab_ColorSelected);
            // 
            // tabPageCustom
            // 
            this.tabPageCustom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.tabPageCustom.Controls.Add(this.customColorPicker);
            this.tabPageCustom.Location = new System.Drawing.Point(4, 22);
            this.tabPageCustom.Name = "tabPageCustom";
            this.tabPageCustom.Size = new System.Drawing.Size(296, 334);
            this.tabPageCustom.TabIndex = 2;
            this.tabPageCustom.Text = "Custom";
            // 
            // customColorPicker
            // 
            this.customColorPicker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.customColorPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customColorPicker.Location = new System.Drawing.Point(0, 0);
            this.customColorPicker.MinimumSize = new System.Drawing.Size(120, 120);
            this.customColorPicker.Name = "customColorPicker";
            this.customColorPicker.Size = new System.Drawing.Size(296, 334);
            this.customColorPicker.TabIndex = 0;
            this.customColorPicker.ColorSelected += new Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors.BaseColorPicker.ColorSelectedEventHandler(this.tab_ColorSelected);
            // 
            // ComboColorPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.Controls.Add(this.tabControl);
            this.MinimumSize = new System.Drawing.Size(304, 338);
            this.Name = "ComboColorPicker";
            this.Size = new System.Drawing.Size(304, 360);
            this.tabControl.ResumeLayout(false);
            this.tabPageWeb.ResumeLayout(false);
            this.tabPageSystem.ResumeLayout(false);
            this.tabPageCustom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The tab control
        /// </summary>
        private System.Windows.Forms.TabControl tabControl;
        /// <summary>
        /// The tab page web
        /// </summary>
        private System.Windows.Forms.TabPage tabPageWeb;
        /// <summary>
        /// The web color picker
        /// </summary>
        private WebColorPicker webColorPicker;
        /// <summary>
        /// The tab page system
        /// </summary>
        private System.Windows.Forms.TabPage tabPageSystem;
        /// <summary>
        /// The system color picker
        /// </summary>
        private SystemColorPicker systemColorPicker;
        /// <summary>
        /// The tab page custom
        /// </summary>
        private System.Windows.Forms.TabPage tabPageCustom;
        /// <summary>
        /// The custom color picker
        /// </summary>
        private CustomColorPicker customColorPicker;
    }
}
