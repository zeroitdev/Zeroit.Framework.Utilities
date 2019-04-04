// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="PushButton.cs" company="Zeroit Dev Technologies">
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
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using Zeroit.Framework.Utilities.ToolTip;

namespace Zeroit.Framework.Utilities.ControlUtils
{
    /// <summary>
    /// A class for a very simple push kind of button.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [ToolboxItem(false)]
    public class PushButton : Control
    {
        #region Members

        /// <summary>
        /// The tool tip text
        /// </summary>
        string _toolTipText;
        /// <summary>
        /// The hover color
        /// </summary>
        Color _hoverColor = Color.Transparent;
        /// <summary>
        /// The push color
        /// </summary>
        Color _pushColor = Color.Transparent;
        /// <summary>
        /// The idle image
        /// </summary>
        Image _idleImage;
        /// <summary>
        /// The hover image
        /// </summary>
        Image _hoverImage;
        /// <summary>
        /// The push image
        /// </summary>
        Image _pushImage;
        /// <summary>
        /// The hover
        /// </summary>
        bool _hover;
        /// <summary>
        /// The push
        /// </summary>
        bool _push;
        /// <summary>
        /// The tt
        /// </summary>
        SimpleToolTip tt;

        #endregion

        /// <summary>
        /// The constructor.
        /// </summary>
        public PushButton()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            tt = new SimpleToolTip();
        }

        #region Properties

        /// <summary>
        /// Gets or sets the tooltip text to display when the mouse is over the button.
        /// </summary>
        /// <value>The tool tip text.</value>
        public string ToolTipText
        {
            get { return _toolTipText; }
            set
            {
                _toolTipText = value;
                tt.RemoveAll();
                tt.SetToolTip(this, value);
            }
        }

        /// <summary>
        /// Gets or sets the color when the mouse is over the button.
        /// </summary>
        /// <value>The color of the hover back.</value>
        public Color HoverBackColor
        {
            get { return _hoverColor; }
            set
            {
                _hoverColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the color when the button is pushed.
        /// </summary>
        /// <value>The color of the push back.</value>
        public Color PushBackColor
        {
            get { return _pushColor; }
            set
            {
                _pushColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the image that is used when the mouse is not over the button.
        /// </summary>
        /// <value>The image.</value>
        public Image Image
        {
            get { return _idleImage; }
            set { _idleImage = value; }
        }

        /// <summary>
        /// Gets or sets the image that is used when the mouse is over the button.
        /// </summary>
        /// <value>The hover image.</value>
        public Image HoverImage
        {
            get { return _hoverImage; }
            set { _hoverImage = value; }
        }

        /// <summary>
        /// Gets or sets the image that is used when the button is pressed.
        /// </summary>
        /// <value>The push image.</value>
        public Image PushImage
        {
            get { return _pushImage; }
            set { _pushImage = value; }
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            _hover = true;
            Refresh();
            base.OnMouseEnter(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            _hover = false;
            Refresh();
            base.OnMouseLeave(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            _push = true;
            Refresh();
            base.OnMouseClick(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            _push = false;
            Refresh();
            base.OnMouseUp(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (_push)
            {
                e.Graphics.Clear(PushBackColor);
                
                if(PushImage != null)
                    e.Graphics.DrawImageUnscaled(PushImage, (Width - PushImage.Width) / 2, (Height - PushImage.Height) / 2);
            }
            else if (_hover)
            {
                e.Graphics.Clear(HoverBackColor);

                if(HoverImage != null)
                    e.Graphics.DrawImageUnscaled(HoverImage, (Width - HoverImage.Width) / 2, (Height - HoverImage.Height) / 2);
            }
            else
            {
                e.Graphics.Clear(BackColor);

                if (Image != null)
                    e.Graphics.DrawImageUnscaled(Image, (Width - Image.Width) / 2, (Height - Image.Height) / 2);
            }

            base.OnPaint(e);
        }

        /// <summary>
        /// Paints the background of the control.
        /// </summary>
        /// <param name="pevent">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains information about the control to paint.</param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //Left blank intentionally.
        }

        #endregion
    }
}
