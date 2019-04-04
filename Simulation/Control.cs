// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-22-2018
// ***********************************************************************
// <copyright file="Control.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.Simulation
{
    /// <summary>
    /// Class Control.
    /// </summary>
    public static class Control
    {
        /// <summary>
        /// Delegate PressEnter_Delegate
        /// </summary>
        /// <param name="xControl">The x control.</param>
        public delegate void PressEnter_Delegate(System.Windows.Forms.Control xControl);

        /// <summary>
        /// Presses the enter.
        /// </summary>
        /// <param name="xControl">The x control.</param>
        public static void PressEnter(System.Windows.Forms.Control xControl)
        {
            if (xControl.InvokeRequired)
            {
                PressEnter_Delegate xFun = new PressEnter_Delegate(PressEnter);
                xControl.Invoke(xFun, new object[] { xControl });
                return;
            }
            xControl.Focus();
            System.Windows.Forms.SendKeys.SendWait("{ENTER}");
        }


    }

}
