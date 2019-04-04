// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Animation.cs" company="Zeroit Dev Technologies">
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
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using Zeroit.Framework.Utilities.GraphicsExtension.Drawing;
using System.Reflection;

namespace Zeroit.Framework.Utilities.Animation
{
    /// <summary>
    /// Class with extensions for Control objects
    /// </summary>
    public static class ControlAnimation
    {
        #region Animation

        /// <summary>
        /// Animates the current control with some values.
        /// </summary>
        /// <param name="c">The control to animate.</param>
        /// <param name="properties">The anonymous object with name / value pairs.</param>
        public static void Animate(this Control c, object properties)
        {
            Animate(c, properties, 200, Easing.Linear, null);
        }

        /// <summary>
        /// Animates the current control with some values.
        /// </summary>
        /// <param name="c">The control to animate.</param>
        /// <param name="properties">The anonymous object with name / value pairs.</param>
        /// <param name="duration">The duration of the animation.</param>
        public static void Animate(this Control c, object properties, int duration)
        {
            Animate(c, properties, duration, Easing.Linear, null);
        }

        /// <summary>
        /// Animates the current control with some values.
        /// </summary>
        /// <param name="c">The control to animate.</param>
        /// <param name="properties">The anonymous object with name / value pairs.</param>
        /// <param name="duration">The duration of the animation.</param>
        /// <param name="easing">The Easing object to use.</param>
        public static void Animate(this Control c, object properties, int duration, Easing easing)
        {
            Animate(c, properties, duration, easing, null);
        }

        /// <summary>
        /// Animates the current control with some values.
        /// </summary>
        /// <param name="c">The control to animate.</param>
        /// <param name="properties">The anonymous object with name / value pairs.</param>
        /// <param name="duration">The duration of the animation.</param>
        /// <param name="easing">The Easing object to use.</param>
        /// <param name="complete">The callback method to invoke when the animation is finished.</param>
        public static void Animate(this Control c, object properties, int duration, Easing easing, Action complete)
        {
            var t = new Timer();
            t.Interval = 30;
            var frame = 0;
            var maxframes = (int)Math.Ceiling(duration / 30.0);
            var reflection = properties.GetType();
            var target = c.GetType();
            var props = reflection.GetProperties();
            var values = new ReflectionCache[props.Length];

            for (int i = 0; i < props.Length; i++)
            {
                values[i] = new ReflectionCache(target.GetProperty(props[i].Name));
                values[i].SetStart(values[i].Info.GetValue(c, null));
                values[i].SetEnd(props[i].GetValue(properties, null));
            }

            t.Tick += (s, e) =>
            {
                frame++;

                for (int i = 0; i < values.Length; i++)
                {
                    values[i].Execute(c, easing, frame, maxframes);
                }

                if (frame == maxframes)
                {
                    t.Stop();

                    if (complete != null)
                        complete();
                }
            };

            t.Start();
        }

        /// <summary>
        /// Class ReflectionCache.
        /// </summary>
        class ReflectionCache
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ReflectionCache"/> class.
            /// </summary>
            /// <param name="info">The information.</param>
            /// <exception cref="ArgumentException">Invalid property to animate. The given properties have to match a property of the control.</exception>
            public ReflectionCache(PropertyInfo info)
            {
                Info = info;

                if(info == null)
                    throw new ArgumentException("Invalid property to animate. The given properties have to match a property of the control.");

                var subprops = info.PropertyType.GetProperties().Where(m => m.CanRead && m.CanWrite).ToArray();

                if (subprops.Length > 0)
                {
                    SubList = new ReflectionCache[subprops.Length];

                    for (int i = 0; i < subprops.Length; i++)
                        SubList[i] = new ReflectionCache(subprops[i]);
                }
            }

            /// <summary>
            /// Gets or sets the start.
            /// </summary>
            /// <value>The start.</value>
            public double Start { get; private set; }

            /// <summary>
            /// Gets or sets the end.
            /// </summary>
            /// <value>The end.</value>
            public double End { get; private set; }

            /// <summary>
            /// Gets a value indicating whether this instance has items.
            /// </summary>
            /// <value><c>true</c> if this instance has items; otherwise, <c>false</c>.</value>
            public bool HasItems { get { return SubList != null; } }

            /// <summary>
            /// Gets or sets the type of the list.
            /// </summary>
            /// <value>The type of the list.</value>
            public Type ListType { get; private set; }

            /// <summary>
            /// Gets or sets the sub list.
            /// </summary>
            /// <value>The sub list.</value>
            public ReflectionCache[] SubList { get; private set; }

            /// <summary>
            /// Gets or sets the information.
            /// </summary>
            /// <value>The information.</value>
            public PropertyInfo Info { get; private set; }

            /// <summary>
            /// Gets or sets the set value.
            /// </summary>
            /// <value>The set value.</value>
            public Action<object, object> SetValue { get; private set; }

            /// <summary>
            /// Executes the specified c.
            /// </summary>
            /// <param name="c">The c.</param>
            /// <param name="easing">The easing.</param>
            /// <param name="frame">The frame.</param>
            /// <param name="frames">The frames.</param>
            public void Execute(object c, Easing easing, int frame, int frames)
            {
                if (HasItems)
                {
                    var cp = Activator.CreateInstance(ListType);

                    foreach (var item in SubList)
                    {
                        item.Execute(cp, easing, frame, frames);
                    }

                    Info.SetValue(c, cp, null);
                }
                else
                {
                    var value = easing.CalculateStep(frame, frames, Start, End);
                    this.SetValue(c, value);
                }
            }

            /// <summary>
            /// Sets the start.
            /// </summary>
            /// <param name="value">The value.</param>
            /// <returns>ReflectionCache.</returns>
            public ReflectionCache SetStart(object value)
            {
                if (HasItems)
                {
                    ListType = value.GetType();

                    foreach (var item in SubList)
                    {
                        item.SetStart(item.Info.GetValue(value, null));
                    }
                }
                else
                {
                    Start = Convert.ToDouble(value);

                    if (value is int)
                    {
                        SetValue = (c, v) =>
                        {
                            Info.SetValue(c, Convert.ToInt32(v), null);
                        };
                    }
                    else if (value is long)
                    {
                        SetValue = (c, v) =>
                        {
                            Info.SetValue(c, Convert.ToInt64(v), null);
                        };
                    }
                    else if (value is float)
                    {
                        SetValue = (c, v) =>
                        {
                            Info.SetValue(c, Convert.ToSingle(v), null);
                        };
                    }
                    else if (value is decimal)
                    {
                        SetValue = (c, v) =>
                        {
                            Info.SetValue(c, Convert.ToDecimal(v), null);
                        };
                    }
                    else
                    {
                        SetValue = (c, v) =>
                        {
                            Info.SetValue(c, v, null);
                        };
                    }
                }

                return this;
            }

            /// <summary>
            /// Sets the end.
            /// </summary>
            /// <param name="value">The value.</param>
            /// <returns>ReflectionCache.</returns>
            public ReflectionCache SetEnd(object value)
            {
                if (HasItems)
                {
                    foreach (var item in SubList)
                    {
                        item.SetEnd(item.Info.GetValue(value, null));
                    }
                }
                else
                {
                    End = Convert.ToDouble(value);
                }

                return this;
            }
        }

        #endregion

        #region Presentation

        /// <summary>
        /// Gives a shadow to this control
        /// </summary>
        /// <param name="control">The current control</param>
        /// <param name="color">The shadow's color</param>
        /// <param name="dx">The horizontal offset of the shadow</param>
        /// <param name="dy">The vertical offset of the shadow</param>
        /// <param name="blur">The blurness of the shadow</param>
        public static void Shadow(this Control control, Color color, float dx, float dy, float blur)
        {
            if (control.Parent != null)
            {
                control.Parent.Resize += (s, e) =>
                {
                    (s as Control).Refresh();
                };
                control.Parent.Paint += (s, e) =>
                {
                    e.Graphics.DrawRectangularShadow(new Rectangle(control.Location, control.Size), color, dx, dy, blur);
                }; ;
            }
        }

        #endregion
    }

    
}
