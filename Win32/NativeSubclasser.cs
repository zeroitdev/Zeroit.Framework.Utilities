// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="NativeSubclasser.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.Win32
{

    #region params

    /// <summary>
    /// Class NativeMessageArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class NativeMessageArgs : EventArgs
	{
        /// <summary>
        /// The message
        /// </summary>
        public Message Message;
        /// <summary>
        /// The cancel
        /// </summary>
        public bool Cancel;
	}

    /// <summary>
    /// Delegate NativeMessageHandler
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="e">The e.</param>
    public delegate void NativeMessageHandler(object s, NativeMessageArgs e);

    #endregion

    /// <summary>
    /// Class NativeSubclasser.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.NativeWindow" />
    public class NativeSubclasser : NativeWindow
	{
        /// <summary>
        /// Occurs when [message].
        /// </summary>
        public event NativeMessageHandler Message = null;

        /// <summary>
        /// Called when [message].
        /// </summary>
        /// <param name="e">The e.</param>
        protected virtual void OnMessage(NativeMessageArgs e)
		{
			if (Message != null)
				Message(this, e);
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="NativeSubclasser"/> class.
        /// </summary>
        public NativeSubclasser()
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="NativeSubclasser"/> class.
        /// </summary>
        /// <param name="Target">The target.</param>
        public NativeSubclasser(Control Target)
		{
			this.AssignHandle(Target.Handle);
			Target.HandleCreated += new EventHandler(this.Handle_Created);
			Target.HandleDestroyed += new EventHandler(this.Handle_Destroyed);
		}

        /// <summary>
        /// Handles the Created event of the Handle control.
        /// </summary>
        /// <param name="o">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Handle_Created(object o, EventArgs e)
		{
			this.AssignHandle(((Control) o).Handle);
		}

        /// <summary>
        /// Handles the Destroyed event of the Handle control.
        /// </summary>
        /// <param name="o">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Handle_Destroyed(object o, EventArgs e)
		{
			this.ReleaseHandle();
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="NativeSubclasser"/> class.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        public NativeSubclasser(IntPtr hWnd)
		{
			this.AssignHandle(hWnd);
		}

        /// <summary>
        /// Detatches this instance.
        /// </summary>
        public void Detatch()
		{
			//	this.ReleaseHandle ();
		}

        /// <summary>
        /// Invokes the default window procedure associated with this window.
        /// </summary>
        /// <param name="m">A <see cref="T:System.Windows.Forms.Message" /> that is associated with the current Windows message.</param>
        protected override void WndProc(ref Message m)
		{
			try
			{
				NativeMessageArgs e = new NativeMessageArgs();
				e.Message = m;
				e.Cancel = false;

				OnMessage(e);

				if (!e.Cancel)
					base.WndProc(ref m);
			}
			catch (Exception x)
			{
				Console.WriteLine(x.Message);
			}
		}
	}
}