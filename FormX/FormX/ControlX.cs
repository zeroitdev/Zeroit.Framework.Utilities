// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ControlX.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.ControlUtils
{
    /// <summary>
    /// Class ControlX.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Windows.Forms.Control" />
    internal class ControlX<T> : Control where T : Control
    {
        //http://www.codeproject.com/Articles/26878/Making-Transparent-Controls-No-Flickering

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlX{T}"/> class.
        /// </summary>
        public ControlX()
        {
            //TODO Inherit coordinates etc. of former / usual element

            //TODO Contain the element with DockStyle.Fill
        }

        
        /// <summary>
        /// Sets the events propagate.
        /// </summary>
        /// <param name="events">The events.</param>
        public void SetEventsPropagate(object events)
        {
            //TODO This method could allow events to propagate
        }
    }

    //TODO:
    //Include PRISM style classes to creating composite regions
    //http://www.codeproject.com/Articles/48287/Getting-Started-with-Prism-2-1-for-WPF
    //http://compositewpf.codeplex.com/

    //TODO:
    //Include some MVVM style classes - so that binding gets a lot easier

    //TODO:
    //Binding to value of control (like width) -- if value changes then an animation should occur! [ CSS3 Transition style ]
}
