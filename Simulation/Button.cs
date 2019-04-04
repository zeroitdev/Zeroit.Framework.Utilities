// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-22-2018
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************



//using System.Windows.Forms;


namespace Zeroit.Framework.Utilities.Simulation
{
    /// <summary>
    /// Description of Simulate.
    /// </summary>
    public static class Button
	{


        /// <summary>
        /// Delegate PerformClick_Delegate
        /// </summary>
        /// <param name="xButton">The x button.</param>
        public delegate void PerformClick_Delegate(System.Windows.Forms.Button xButton);

        /// <summary>
        /// Presses the enter.
        /// </summary>
        /// <param name="xButton">The x button.</param>
        public static void PressEnter(System.Windows.Forms.Button xButton)
		{
            //Simulation.Control.PressEnter(xButton);
		}

        /// <summary>
        /// Performs the click.
        /// </summary>
        /// <param name="xButton">The x button.</param>
        public static void PerformClick(System.Windows.Forms.Button xButton)
        {
            if (xButton.InvokeRequired)
            {
                PerformClick_Delegate xFun = new PerformClick_Delegate(PerformClick);
                xButton.Invoke(xFun, new object[] { xButton });
                return;
            }
            xButton.PerformClick();
        }
	}
}
