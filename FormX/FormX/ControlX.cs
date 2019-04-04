// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ControlX.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
