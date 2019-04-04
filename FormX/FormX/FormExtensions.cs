// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="FormExtensions.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;
using System.Drawing;
using Zeroit.Framework.Utilities.ControlUtils;
using Zeroit.Framework.Utilities.GraphicsExtension.Drawing;
using Zeroit.Framework.Utilities.GraphicsExtension.BitmapUtils;

namespace Zeroit.Framework.Utilities.Notification
{
    /// <summary>
    /// Class with extensions for Form objects
    /// </summary>
    public static class FormExtensions
    {
        /// <summary>
        /// Shows a notification on the form.
        /// </summary>
        /// <param name="form">The form to display the notification.</param>
        /// <param name="message">The message (notification) that should be displayed.</param>
        /// <param name="duration">The duration of the notification (specify -1 for infinite).</param>
        /// <param name="opacity">The opacity of the background (0..1).</param>
        /// <param name="glowColor">The glow color of the message rectangle.</param>
        /// <param name="backColor">The background color of the message rectangle.</param>
        /// <param name="foreColor">The text color of the message.</param>
        /// <returns>Control.</returns>
        public static Control Notify(this Form form, string message, int duration, double opacity, Color glowColor, Color backColor, Color foreColor)
        {
            var font = new Font(form.Font.FontFamily, form.Font.Size * 1.2f, form.Font.Unit);
            var proposedSize = new Size(form.Width * 6 / 10, 0);
            var size = TextRenderer.MeasureText(message, font, proposedSize, TextFormatFlags.WordBreak);
            var panel = new TransparentPanel();
            panel.Size = form.ClientRectangle.Size;
            panel.Location = new Point(0, 0);
            panel.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            panel.Paint += (sender, e) =>
            {
                var g = e.Graphics;
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb((int)Math.Ceiling(255.0 * opacity), Color.Black)), 0, 0, panel.Width, panel.Height);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                var rectangle = new Rectangle(0, 0, size.Width + 20, size.Height + 10);
                rectangle.Offset(form.Width / 2 - rectangle.Width / 2, form.Height / 2 - rectangle.Height / 2);
                g.GlowRectangle(rectangle, glowColor, 30, 10);
                g.FillRoundRectangle(new SolidBrush(backColor), rectangle, 5);
                TextRenderer.DrawText(g, message, font, rectangle, foreColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);
            };
            form.Controls.Add(panel);
            panel.BringToFront();

            if (duration > 0)
            {
                var timer = new Timer();
                timer.Interval = duration;
                timer.Tick += (sender, e) =>
                {
                    form.Controls.Remove(panel);
                    panel = null;
                    timer.Stop();
                };
                timer.Start();
            }

            form.Refresh();
            return panel;
        }

        /// <summary>
        /// Shows a notification on the form with a black background, white text, red glowing and an opaque layer of 0.3 opacity for 5 seconds.
        /// </summary>
        /// <param name="form">The form to display the notification.</param>
        /// <param name="message">The message (notification) that should be displayed.</param>
        /// <returns>Control.</returns>
        public static Control Notify(this Form form, string message)
        {
            return form.Notify(message, 5000);
        }

        /// <summary>
        /// Shows a notification on the form with a black background, white text, red glowing and an opaque layer of 0.3.
        /// </summary>
        /// <param name="form">The form to display the notification.</param>
        /// <param name="message">The message (notification) that should be displayed.</param>
        /// <param name="duration">The duration of the notification (specify -1 for infinite).</param>
        /// <returns>Control.</returns>
        public static Control Notify(this Form form, string message, int duration)
        {
            return form.Notify(message, duration, 0.3);
        }

        /// <summary>
        /// Shows a notification on the form with a black background, white text and red glowing.
        /// </summary>
        /// <param name="form">The form to display the notification.</param>
        /// <param name="message">The message (notification) that should be displayed.</param>
        /// <param name="duration">The duration of the notification (specify -1 for infinite).</param>
        /// <param name="opacity">The opacity of the background (0..1).</param>
        /// <returns>Control.</returns>
        public static Control Notify(this Form form, string message, int duration, double opacity)
        {
            return form.Notify(message, duration, opacity, Color.Red);
        }

        /// <summary>
        /// Shows a notification on the form with a black background, white text and an opaque layer of 0.3 opacity.
        /// </summary>
        /// <param name="form">The form to display the notification.</param>
        /// <param name="message">The message (notification) that should be displayed.</param>
        /// <param name="duration">The duration of the notification (specify -1 for infinite).</param>
        /// <param name="glowColor">The glow color of the message rectangle.</param>
        /// <returns>Control.</returns>
        public static Control Notify(this Form form, string message, int duration, Color glowColor)
        {
            return form.Notify(message, duration, 0.3, glowColor);
        }

        /// <summary>
        /// Shows a notification on the form with a black background and white text.
        /// </summary>
        /// <param name="form">The form to display the notification.</param>
        /// <param name="message">The message (notification) that should be displayed.</param>
        /// <param name="duration">The duration of the notification (specify -1 for infinite).</param>
        /// <param name="opacity">The opacity of the background (0..1).</param>
        /// <param name="glowColor">The glow color of the message rectangle.</param>
        /// <returns>Control.</returns>
        public static Control Notify(this Form form, string message, int duration, double opacity, Color glowColor)
        {
            return form.Notify(message, duration, opacity, glowColor, Color.Black, Color.White);
        }
    }

}
