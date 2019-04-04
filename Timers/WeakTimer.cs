// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="WeakTimer.cs" company="Zeroit Dev Technologies">
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
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.Timers
{

    #region WeakTimer

    /// <summary>
    /// Class WeakTimer.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Component" />
    [ToolboxItem(false)]
	public class WeakTimer : Component
	{
        /// <summary>
        /// The tick count
        /// </summary>
        private int _TickCount = 0;

        #region public property Interval

        //Created By RogerJ - 28-03-2003

        //member variable
        /// <summary>
        /// The interval
        /// </summary>
        private int _Interval = 100;

        /// <summary>
        /// Gets or sets the interval.
        /// </summary>
        /// <value>The interval.</value>
        public int Interval
		{
			get { return _Interval; }

			set { _Interval = value; }
		}

        #endregion //END PROPERTY Interval

        #region public property Enabled

        //Created By RogerJ - 28-03-2003

        //member variable
        /// <summary>
        /// The enabled
        /// </summary>
        private bool _Enabled = true;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="WeakTimer"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        public bool Enabled
		{
			get { return _Enabled; }

			set { _Enabled = value; }
		}

        #endregion //END PROPERTY Enabled

        /// <summary>
        /// Occurs when [tick].
        /// </summary>
        public event EventHandler Tick = null;
        /// <summary>
        /// The components
        /// </summary>
        private Container components = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeakTimer"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public WeakTimer(IContainer container)
		{
			container.Add(this);
			InitializeComponent();
			Init();
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="WeakTimer"/> class.
        /// </summary>
        public WeakTimer()
		{
			InitializeComponent();
			Init();
		}

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Init()
		{
			WeakTimerHelper.Attach(this);

		}

        /// <summary>
        /// Does the tick.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void DoTick(object s, EventArgs e)
		{
			_TickCount++;
			if (Enabled)
			{
				if (_TickCount >= (this.Interval/WeakTimerHelper.Speed))
				{
					_TickCount = 0;

					try
					{
						if (Tick != null)
							Tick(s, e);
					}
					catch
					{
					}
				}
			}
			//	GC.KeepAlive(Tick.Target);
			//	GC.KeepAlive(this);
		}

        /// <summary>
        /// Finalizes an instance of the <see cref="WeakTimer"/> class.
        /// </summary>
        ~WeakTimer()
		{
			//Console.WriteLine ("killing WeakTimer");
			WeakTimerHelper.Detach(this);
		}

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}

		#endregion
	}

    #endregion

    #region Helper

    /// <summary>
    /// Class WeakTimerHelper.
    /// </summary>
    public class WeakTimerHelper
	{
        /// <summary>
        /// The timer
        /// </summary>
        public static Timer _timer = GetTimer();
        /// <summary>
        /// The listeners
        /// </summary>
        private static ArrayList _listeners = new ArrayList();
        /// <summary>
        /// The speed
        /// </summary>
        public const int Speed = 10;


        /// <summary>
        /// Attaches the specified t.
        /// </summary>
        /// <param name="t">The t.</param>
        public static void Attach(WeakTimer t)
		{
			WeakReference wr = new WeakReference(t);

			_listeners.Add(wr);
		}

        /// <summary>
        /// Detaches the specified t.
        /// </summary>
        /// <param name="t">The t.</param>
        public static void Detach(WeakTimer t)
		{
			for (int i = _listeners.Count - 1; i >= 0; i--)
			{
				WeakReference wr = (WeakReference) _listeners[i];
				try
				{
					if (wr.Target == t)
						_listeners.RemoveAt(i);
				}
				catch
				{
				}
			}
		}

        /// <summary>
        /// Gets the timer.
        /// </summary>
        /// <returns>Timer.</returns>
        private static Timer GetTimer()
		{
			Timer t = new Timer();
			t.Interval = Speed;
			t.Tick += new EventHandler(DoTick);
			t.Enabled = true;
			return t;
		}

        /// <summary>
        /// Does the tick.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private static void DoTick(object s, EventArgs e)
		{
			foreach (WeakReference wr in _listeners)
			{
				if (wr.IsAlive)
				{
					try
					{
						((WeakTimer) wr.Target).DoTick(null, EventArgs.Empty);
					}
					catch
					{
					}
				}
			}
		}

	}

	#endregion
}